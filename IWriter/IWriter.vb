
Imports System.Configuration
Imports System.IO
Imports System.Messaging
Imports System.data
Imports System.data.sqlclient

Namespace YPWater.DataGather
    Public Class IOmegaWriter
        Private Shared ReadOnly Logger As log4net.ILog = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

        Private oOPCServer As Object

        Private TagTimer As System.Timers.Timer   '控制读指标的时钟
        Private sWorkPath As String       '写文件的总路径，所有数据文件放在该目录下再加上当天的日期的文件夹里面
        Private nWriterInterval As Int16  '写文件时间间隔
        Private nTimerInterval As Int16   '读指标时间间隔

        Private mConn As String

        '各项指标参数

        Private TagID() As String      '指标编号（自己定义的编号）
        Private TagAddress() As String '指标地址（到OPC Server上取指标值所必须的地址）
        Private TagValue0() As Double  '放置指标从OPC Server处取出的原始值
        Private TagValue1() As Double  '放置经过修正后的指标值

        '线性修正系数a
        Private TagPara0() As Double
        '线性修正系数b
        Private TagPara1() As Double
        '计算用参数，对积分运算，此参数为积分周期单位，如1小时为3600秒
        Private TagPara2() As Double

        Private TagCalcType() As Integer '计算类型
        Private TagLastValue() As Double '放置上次取出的指标值
        Private TagTopValue() As Double '放置网络中断前取出的指标值（即指标值突然从大变小时）
        Private TagError() As Int16
        Private TagMax() As Double       '指标最大值，>=时作0处理
        Private TagMin() As Double       '指标最小值，<=时作0处理

        Private bFirst As Boolean
        Private bWaitWrite As Boolean

        Private nOPCState As Integer

        Private fs As FileStream
        Private sw As StreamWriter

        Private CurrentWriter As Integer '当前写的一天中的秒数，表明本次读数据的时间。
        Private LastCount As Integer
        Private FileWriter As Integer '当前文件中的的秒数。

        Private AdjustTimer As System.Timers.Timer

        '记录最后一个新文件的名称，初始时为空
        Private LastFileName As String
        Private LastTableName As String


        Private myMQ As MessageQueue
        '消息队列的名字
        Const QueueName As String = ".\Private$\DataFiles"
        'OPC状态
        Public ReadOnly Property OPCState() As Integer
            Get
                OPCState = nOPCState
            End Get
        End Property
        '数据文件存放路径，写入时只要传入一个总路径名就可以了。读取时会读出总路径名，加上当天的日期。总路径缺省是D:\Dates。
        Public Property WorkPath() As String
            Get
                Dim myPath As String
                myPath = sWorkPath & "\" & Format(Now, "yyyyMMdd")
                If Not Directory.Exists(myPath) Then
                    Directory.CreateDirectory(myPath)
                End If
                WorkPath = myPath
            End Get
            Set(ByVal Value As String)
                If Directory.Exists(Value) Then
                    sWorkPath = Value
                Else
                    Try
                        Directory.CreateDirectory(Value)
                    Catch
                        Value = "D:\KEPWareDatas"
                        If Not Directory.Exists(Value) Then
                            Directory.CreateDirectory(Value)
                        End If
                    Finally
                        sWorkPath = Value
                    End Try
                End If
            End Set
        End Property

        '写文件时间间隔，间隔必须是10的整数倍，必须小于60秒，否则作为10秒写一次处理
        Public Property WriterInterval() As Int16
            Get
                WriterInterval = nWriterInterval
            End Get
            Set(ByVal Value As Int16)
                If Value Mod 10 <> 0 Or Value < 0 Or Value >= 60 Then
                    Value = 10
                End If
                nWriterInterval = Value
                CurrentWriter = Value
            End Set
        End Property

        '读指标时间间隔，间隔必须是1000毫秒的整数倍，即是整数秒，同时必须小于30秒，否则作为1秒处理
        Public Property TimerInterval() As Int16
            Get
                TimerInterval = nTimerInterval
            End Get
            Set(ByVal Value As Int16)
                If Value Mod 1000 <> 0 And Value >= 30000 Then
                    Value = 1000
                End If
                nTimerInterval = Value
            End Set
        End Property
        '数据库连接字符串
        Public Property ConnString() As String
            Get
                Return mConn
            End Get
            Set(ByVal Value As String)
                mConn = Value
            End Set
        End Property
        '连接RSLINX，使用的用VB6编写的控件LinxVB的一个类IOPCServer来同Linx网通讯
        Public Sub ConnectOPC()
            Logger.Debug("ConnectOPC123")
            Dim ProgID, NodeIP, OPCGroup, Action As String

            ProgID = ConfigurationManager.AppSettings("ProgID")
            NodeIP = ConfigurationManager.AppSettings("NodeIP")
            OPCGroup = ConfigurationManager.AppSettings("OPCGroup")


            bWaitWrite = True
            Try
                Logger.Debug("Create LinxVB")
                oOPCServer = CreateObject("LinxVB.IOPCServer")
                If oOPCServer Is Nothing Then
                    Logger.Debug("LinxVB.IOPCServer is Nothing")
                    nOPCState = -999
                Else
                    Logger.Debug("oOPCServer.Connect")
                    nOPCState = oOPCServer.Connect(ProgID, NodeIP, OPCGroup)
                    Logger.Debug("oOPCServer.Connect success")
                End If
                If nOPCState = 0 Then
                    bWaitWrite = False
                End If
            Catch ex As Exception
                Logger.Error(ex.Message, ex)
            End Try
        End Sub
        '初始化消息队列
        Public Sub InitQueue()

            If Not MessageQueue.Exists(QueueName) Then
                MessageQueue.Create(QueueName)
            End If

            myMQ = New MessageQueue(QueueName)
            myMQ.Formatter = New System.Messaging.XmlMessageFormatter(New String() {"System.String"})
        End Sub
        '启动本控件，先初始化队列，然后启动调整时钟
        Public Function Start() As Boolean
            Logger.Debug("IWriter Start()")
            InitQueue()
            TagTimer = New System.Timers.Timer()
            AdjustTimer = New System.Timers.Timer()

            AddHandler AdjustTimer.Elapsed, AddressOf AdjustTimerComes
            AddHandler TagTimer.Elapsed, AddressOf TagTimerComes
            TagTimer.Interval = TimerInterval
            AdjustTimer.Interval = 100
            bWaitWrite = False
            CurrentWriter = -1
            FileWriter = -WriterInterval - 1
            AdjustTimer.Start()
        End Function
        '调整时钟，使读指标时钟TagTimer能在系统启动后的第一分钟前一个读指标时间间隔启动，
        '然后正好在第一分钟0秒触发TagTimerComes事件。
        '例如目前是5000毫秒一个读指标时间间隔,那么在55秒的时候,开始启动读指标时钟.
        Private Sub AdjustTimerComes(ByVal Sender As Object, ByVal e As System.Timers.ElapsedEventArgs)
            If e.SignalTime.Second = 60 - TimerInterval / 1000 And e.SignalTime.Millisecond <= 100 Then
                LastFileName = ""
                LastTableName = "T_TAG_S" & Format(e.SignalTime, "yyyyMMdd")
                TagTimer.Start()
                AdjustTimer.Stop()
            End If
        End Sub

        '***************************************************
        '首先从数据库的表T_TAG_GATHER（I_ACTION = 1，I_ACTION为其他值的不从RSLINX中取值）中取出要到RSLINX网取值的指标，
        '然后把各个值填入到相应的数组中，最后调用oOPCServer.LoadTags(TagAddress)装载指标地址。
        '***************************************************
        Public Function LoadTags() As Integer

            Dim i As Integer
            Dim oAda As SqlDataAdapter
            Dim oConn As SqlConnection
            Dim oTb As DataTable
            Dim nCount As Integer
            Dim action As String
            action = ConfigurationManager.AppSettings("Action")
            Dim sqlStatement As String

            Try
                oConn = New SqlConnection(mConn)
                oConn.Open()
                sqlStatement = String.Format("select a.*,b.CALC_TYPE_BEFORE_HOUR from T_TAG_GATHER a,T_TAG_MS b Where a.I_ACTION = {0} AND a.I_TAG_ID = b.I_TAG_ID ORDER BY a.I_TAG_ID", action)

                oAda = New SqlDataAdapter(sqlStatement, oConn)
                oTb = New DataTable("T_TAG_GATHER")
                oAda.Fill(oTb)
                nCount = oTb.Rows.Count
                Logger.Debug(String.Format("Tag Rows is {0}", nCount))
                bWaitWrite = True
                ReDim TagID(nCount - 1)
                ReDim TagAddress(nCount - 1)
                ReDim TagValue0(nCount - 1)
                ReDim TagValue1(nCount - 1)
                ReDim TagPara0(nCount - 1)
                ReDim TagPara1(nCount - 1)
                ReDim TagPara2(nCount - 1)
                ReDim TagCalcType(nCount - 1)
                ReDim TagLastValue(nCount - 1)
                ReDim TagTopValue(nCount - 1)
                ReDim TagError(nCount - 1)
                ReDim TagMax(nCount - 1)
                ReDim TagMin(nCount - 1)
                bFirst = True
                For i = 0 To nCount - 1
                    TagID(i) = oTb.Rows(i).Item("I_TAG_ID")
                    TagAddress(i) = oTb.Rows(i).Item("I_ADDRESS")
                    TagPara0(i) = oTb.Rows(i).Item("I_PARA_A")
                    TagPara1(i) = oTb.Rows(i).Item("I_PARA_B")
                    TagPara2(i) = oTb.Rows(i).Item("I_PARA_C")
                    TagCalcType(i) = oTb.Rows(i).Item("CALC_TYPE_BEFORE_HOUR")
                    TagMax(i) = oTb.Rows(i).Item("I_MAX")
                    TagMin(i) = oTb.Rows(i).Item("I_MIN")
                    If bWaitWrite Then
                        TagValue0(i) = 0
                        TagValue1(i) = 0
                        TagLastValue(i) = 0
                        TagTopValue(i) = 0
                    End If
                Next i
                oOPCServer.LoadTags(TagAddress)
                oConn.Close()
                bWaitWrite = False
            Catch ex As Exception
                Logger.Error(ex.Message, ex)
                Return 0
            End Try
        End Function
        '*********************************************************
        '指标时钟触发器处理的事件。在这里调用读数据，写文件的函数
        '*********************************************************
        Private Sub TagTimerComes(ByVal Sender As Object, ByVal e As System.Timers.ElapsedEventArgs)
            Dim nGatherID As Integer '一天中的秒数，共86400秒

            'CurrentWriter为当前写的一天中的秒数
            CurrentWriter = e.SignalTime.Hour * 3600 + e.SignalTime.Minute * 60 + e.SignalTime.Second
            nGatherID = CurrentWriter

            '到写时间间隔时结束上次写的文件，同时新建一个文件，将下面一个写时间间隔内读取到的数据写到流sw中。
            '第一次启动时由于是在整分触发，所以肯定触发下面的条件，此时LastFileName=“”，因此只是新建一个文件。
            If (nGatherID >= FileWriter + WriterInterval) Or (nGatherID < FileWriter) Then
                FileWriter = nGatherID
                Try
                    If Not sw Is Nothing Then
                        sw.Close()
                    End If
                Catch ex As Exception
                    Logger.Error(ex.Message, ex)
                End Try
                Try
                    If Not fs Is Nothing Then
                        fs.Close()
                    End If
                Catch ex As Exception
                    Logger.Error(ex.Message, ex)
                End Try
                If LastFileName <> "" Then
                    SendMsg(LastTableName, LastFileName)
                End If
                LastFileName = WorkPath & "\" & Format(nGatherID, "00000") & ".TXT"
                LastTableName = "T_TAG_S" & Format(e.SignalTime, "yyyyMMdd")
                Try
                    fs = File.OpenWrite(LastFileName)
                    sw = New StreamWriter(fs)
                Catch ex As Exception
                    Logger.Error(ex.Message, ex)
                    
                End Try
            End If
            '读数据到流sw中。
            Run(nGatherID)
        End Sub

        '***************************************************
        '必须先调用LoadTags()才能调用本函数。
        '调用oOPCServer.Retrieve(TagAddress, TagValue0)把指标值放在TagValue0数组中，
        '然后调用CalcTags()修正指标值，并把最终指标值放在TagValue1数组中。
        '***************************************************
        Private Function Run(ByVal nGatherID As Integer) As Boolean
            Logger.Debug(String.Format("Run({0})", nGatherID))
            Run = False
            If bWaitWrite Then
                Exit Function
            End If
            Try
                Logger.Debug("OPCServer.Retrieve")
                If oOPCServer.Retrieve(TagAddress, TagValue0) < 0 Then

                End If
            Catch ex As Exception
                Logger.Error("Retrieve error")
                Logger.Error(ex.Message, ex)
            End Try
            Try
                If bFirst Then
                    TagValue0.CopyTo(TagLastValue, 0)
                    bFirst = False
                End If
                CalcTags()

                WriteTo(nGatherID)
            Catch ex As Exception
                Logger.Error(ex.Message, ex)
            End Try

            Run = True
        End Function

        '*******************************************
        '修正指标值（通过参数1，2，3及计算类型），
        '>=MAX AND <=MIN 的指标值作0处理
        '*******************************************
        Private Function CalcTags() As Integer
            Dim i As Integer
            Dim nCount As Integer
            nCount = TagID.Length

            For i = 0 To nCount - 1

                Select Case TagCalcType(i)
                    Case 3
                        '原来为脉冲数，if TagValue0(i) <> TagLastValue(i) then TagValue1(i) = TagPara2(i) else TagValue1(i) = 0 end if
                        If TagValue0(i) > TagLastValue(i) Then
                            '网络恢复后指标值突然从0上升到一个初始值，经过一段时间后该初始值应该大于等于原来的最大值。
                            '如果比最大值小，则表明是设备复位为0，而不是网络中断。
                            If (TagTopValue(i) <> 0) And (TagValue0(i) >= TagTopValue(i)) Then
                                TagValue1(i) = TagValue0(i) - TagTopValue(i)
                                TagTopValue(i) = 0
                                'ElseIf TagTopValue(i) <> 0 And (TagValue0(i) < TagTopValue(i)) Then
                                '    TagValue1(i) = TagValue0(i)
                                '    TagTopValue(i) = 0
                            Else
                                TagValue1(i) = TagValue0(i) - TagLastValue(i)
                            End If
                        Else
                            TagValue1(i) = 0
                            '指标值突然变小时，用TagTopValue记录突变前的值
                            If (TagValue0(i) < TagLastValue(i)) Then
                                TagTopValue(i) = TagLastValue(i)
                            End If
                        End If
                        TagLastValue(i) = TagValue0(i)
                        TagValue1(i) = TagPara0(i) * TagValue1(i) + TagPara1(i)
                    Case 2 '积分
                        '先修正
                        TagValue1(i) = TagPara0(i) * TagValue0(i) + TagPara1(i)
                        '再微分
                        TagValue1(i) = TagValue1(i) / TagPara2(i) * (TimerInterval / 1000)
                    Case Else
                        TagValue1(i) = TagPara0(i) * TagValue0(i) + TagPara1(i)
                End Select

                ' 不合理的数据统统置为0，表明采集失败
                If TagValue1(i) > TagMax(i) Or TagValue1(i) < TagMin(i) Then
                    TagValue1(i) = 0
                End If
            Next
        End Function
        '把数据写到流sw中。每一行为：当前秒数,指标编号,指标原始值,指标修正后的值
        Private Sub WriteTo(ByVal nGatherID As Integer)
            Dim iCount As Integer
            Dim sBuffer As String

            Try
                For iCount = 0 To TagID.Length - 1
                    sBuffer = nGatherID.ToString + ","
                    sBuffer = sBuffer & TagID(iCount).ToString & ","
                    sBuffer = sBuffer & TagValue0(iCount).ToString & ","
                    sBuffer = sBuffer & TagValue1(iCount).ToString
                    sw.WriteLine(sBuffer)
                Next
            Catch ex As Exception
                Logger.Error(ex.Message, ex)
            End Try
        End Sub
        '发消息到消息队列（表名、文件名）
        Private Sub SendMsg(ByVal sTable As String, ByVal sFile As String)
            Dim myMessage As New Message()
            myMessage.Formatter = New ActiveXMessageFormatter()
            myMessage.Body = sTable
            myMessage.Label = sFile
            myMQ.Send(myMessage)
        End Sub

        Public Function TestRun(ByVal nGatherID As Integer) As Boolean
            bWaitWrite = False
            bFirst = True

            Run(nGatherID)
        End Function

        '过滤字段的空值
        Public Function FilterDBNull(ByVal item As Object) As String
            If item Is DBNull.Value Then
                Return ""
            Else
                Return CStr(item)
            End If
        End Function

        Protected Overrides Sub Finalize()
            myMQ.Close()
            MyBase.Finalize()
        End Sub
    End Class

End Namespace

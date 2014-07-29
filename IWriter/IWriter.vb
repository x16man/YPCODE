
Imports System.Configuration
Imports System.IO
Imports System.Messaging
Imports System.data
Imports System.data.sqlclient

Namespace YPWater.DataGather
    Public Class IOmegaWriter
        Private Shared ReadOnly Logger As log4net.ILog = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

        Private oOPCServer As Object

        Private TagTimer As System.Timers.Timer   '���ƶ�ָ���ʱ��
        Private sWorkPath As String       'д�ļ�����·�������������ļ����ڸ�Ŀ¼���ټ��ϵ�������ڵ��ļ�������
        Private nWriterInterval As Int16  'д�ļ�ʱ����
        Private nTimerInterval As Int16   '��ָ��ʱ����

        Private mConn As String

        '����ָ�����

        Private TagID() As String      'ָ���ţ��Լ�����ı�ţ�
        Private TagAddress() As String 'ָ���ַ����OPC Server��ȡָ��ֵ������ĵ�ַ��
        Private TagValue0() As Double  '����ָ���OPC Server��ȡ����ԭʼֵ
        Private TagValue1() As Double  '���þ����������ָ��ֵ

        '��������ϵ��a
        Private TagPara0() As Double
        '��������ϵ��b
        Private TagPara1() As Double
        '�����ò������Ի������㣬�˲���Ϊ�������ڵ�λ����1СʱΪ3600��
        Private TagPara2() As Double

        Private TagCalcType() As Integer '��������
        Private TagLastValue() As Double '�����ϴ�ȡ����ָ��ֵ
        Private TagTopValue() As Double '���������ж�ǰȡ����ָ��ֵ����ָ��ֵͻȻ�Ӵ��Сʱ��
        Private TagError() As Int16
        Private TagMax() As Double       'ָ�����ֵ��>=ʱ��0����
        Private TagMin() As Double       'ָ����Сֵ��<=ʱ��0����

        Private bFirst As Boolean
        Private bWaitWrite As Boolean

        Private nOPCState As Integer

        Private fs As FileStream
        Private sw As StreamWriter

        Private CurrentWriter As Integer '��ǰд��һ���е��������������ζ����ݵ�ʱ�䡣
        Private LastCount As Integer
        Private FileWriter As Integer '��ǰ�ļ��еĵ�������

        Private AdjustTimer As System.Timers.Timer

        '��¼���һ�����ļ������ƣ���ʼʱΪ��
        Private LastFileName As String
        Private LastTableName As String


        Private myMQ As MessageQueue
        '��Ϣ���е�����
        Const QueueName As String = ".\Private$\DataFiles"
        'OPC״̬
        Public ReadOnly Property OPCState() As Integer
            Get
                OPCState = nOPCState
            End Get
        End Property
        '�����ļ����·����д��ʱֻҪ����һ����·�����Ϳ����ˡ���ȡʱ�������·���������ϵ�������ڡ���·��ȱʡ��D:\Dates��
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

        'д�ļ�ʱ���������������10��������������С��60�룬������Ϊ10��дһ�δ���
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

        '��ָ��ʱ���������������1000����������������������룬ͬʱ����С��30�룬������Ϊ1�봦��
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
        '���ݿ������ַ���
        Public Property ConnString() As String
            Get
                Return mConn
            End Get
            Set(ByVal Value As String)
                mConn = Value
            End Set
        End Property
        '����RSLINX��ʹ�õ���VB6��д�Ŀؼ�LinxVB��һ����IOPCServer��ͬLinx��ͨѶ
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
        '��ʼ����Ϣ����
        Public Sub InitQueue()

            If Not MessageQueue.Exists(QueueName) Then
                MessageQueue.Create(QueueName)
            End If

            myMQ = New MessageQueue(QueueName)
            myMQ.Formatter = New System.Messaging.XmlMessageFormatter(New String() {"System.String"})
        End Sub
        '�������ؼ����ȳ�ʼ�����У�Ȼ����������ʱ��
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
        '����ʱ�ӣ�ʹ��ָ��ʱ��TagTimer����ϵͳ������ĵ�һ����ǰһ����ָ��ʱ����������
        'Ȼ�������ڵ�һ����0�봥��TagTimerComes�¼���
        '����Ŀǰ��5000����һ����ָ��ʱ����,��ô��55���ʱ��,��ʼ������ָ��ʱ��.
        Private Sub AdjustTimerComes(ByVal Sender As Object, ByVal e As System.Timers.ElapsedEventArgs)
            If e.SignalTime.Second = 60 - TimerInterval / 1000 And e.SignalTime.Millisecond <= 100 Then
                LastFileName = ""
                LastTableName = "T_TAG_S" & Format(e.SignalTime, "yyyyMMdd")
                TagTimer.Start()
                AdjustTimer.Stop()
            End If
        End Sub

        '***************************************************
        '���ȴ����ݿ�ı�T_TAG_GATHER��I_ACTION = 1��I_ACTIONΪ����ֵ�Ĳ���RSLINX��ȡֵ����ȡ��Ҫ��RSLINX��ȡֵ��ָ�꣬
        'Ȼ��Ѹ���ֵ���뵽��Ӧ�������У�������oOPCServer.LoadTags(TagAddress)װ��ָ���ַ��
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
        'ָ��ʱ�Ӵ�����������¼�����������ö����ݣ�д�ļ��ĺ���
        '*********************************************************
        Private Sub TagTimerComes(ByVal Sender As Object, ByVal e As System.Timers.ElapsedEventArgs)
            Dim nGatherID As Integer 'һ���е���������86400��

            'CurrentWriterΪ��ǰд��һ���е�����
            CurrentWriter = e.SignalTime.Hour * 3600 + e.SignalTime.Minute * 60 + e.SignalTime.Second
            nGatherID = CurrentWriter

            '��дʱ����ʱ�����ϴ�д���ļ���ͬʱ�½�һ���ļ���������һ��дʱ�����ڶ�ȡ��������д����sw�С�
            '��һ������ʱ�����������ִ��������Կ϶������������������ʱLastFileName=���������ֻ���½�һ���ļ���
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
            '�����ݵ���sw�С�
            Run(nGatherID)
        End Sub

        '***************************************************
        '�����ȵ���LoadTags()���ܵ��ñ�������
        '����oOPCServer.Retrieve(TagAddress, TagValue0)��ָ��ֵ����TagValue0�����У�
        'Ȼ�����CalcTags()����ָ��ֵ����������ָ��ֵ����TagValue1�����С�
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
        '����ָ��ֵ��ͨ������1��2��3���������ͣ���
        '>=MAX AND <=MIN ��ָ��ֵ��0����
        '*******************************************
        Private Function CalcTags() As Integer
            Dim i As Integer
            Dim nCount As Integer
            nCount = TagID.Length

            For i = 0 To nCount - 1

                Select Case TagCalcType(i)
                    Case 3
                        'ԭ��Ϊ��������if TagValue0(i) <> TagLastValue(i) then TagValue1(i) = TagPara2(i) else TagValue1(i) = 0 end if
                        If TagValue0(i) > TagLastValue(i) Then
                            '����ָ���ָ��ֵͻȻ��0������һ����ʼֵ������һ��ʱ���ó�ʼֵӦ�ô��ڵ���ԭ�������ֵ��
                            '��������ֵС����������豸��λΪ0�������������жϡ�
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
                            'ָ��ֵͻȻ��Сʱ����TagTopValue��¼ͻ��ǰ��ֵ
                            If (TagValue0(i) < TagLastValue(i)) Then
                                TagTopValue(i) = TagLastValue(i)
                            End If
                        End If
                        TagLastValue(i) = TagValue0(i)
                        TagValue1(i) = TagPara0(i) * TagValue1(i) + TagPara1(i)
                    Case 2 '����
                        '������
                        TagValue1(i) = TagPara0(i) * TagValue0(i) + TagPara1(i)
                        '��΢��
                        TagValue1(i) = TagValue1(i) / TagPara2(i) * (TimerInterval / 1000)
                    Case Else
                        TagValue1(i) = TagPara0(i) * TagValue0(i) + TagPara1(i)
                End Select

                ' �����������ͳͳ��Ϊ0�������ɼ�ʧ��
                If TagValue1(i) > TagMax(i) Or TagValue1(i) < TagMin(i) Then
                    TagValue1(i) = 0
                End If
            Next
        End Function
        '������д����sw�С�ÿһ��Ϊ����ǰ����,ָ����,ָ��ԭʼֵ,ָ���������ֵ
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
        '����Ϣ����Ϣ���У��������ļ�����
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

        '�����ֶεĿ�ֵ
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

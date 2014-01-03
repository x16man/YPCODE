Imports System.Data.SqlClient
Imports System.Configuration

Public Class CSchema

    Private Const ERRINFO_INSPECTREPORT_001 As String = "SQL语句执行错误。"
    Private Const ERRINFO_INSPECTREPORT_002 As String = "报表模板不存在！"
    Private Const ERRINFO_INSPECTREPORT_003 As String = "报表模板有错误！"
    Private Const ERRINFO_INSPECTREPORT_004 As String = "保存出错！"
    Private Const ERRINFO_INSPECTREPORT_005 As String = "报表模板里保存区域里的指标类型有错误！"
    Private Const ERRINFO_INSPECTREPORT_006 As String = "报表模板里里的时间类型在数据库里找不到！"
    Private Const ERRINFO_INSPECTREPORT_007 As String = "输入错误，必须输入数字！"
    Private Const ERRINFO_INSPECTREPORT_008 As String = "输入错误，必须输入时间！"
    Private SQLConn As SqlConnection
    Private CCData, oldXMLData As OWC10.Spreadsheet
    Private mUserConnString As String
    Private Shared ReadOnly Logger As log4net.ILog = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)
    '错误处理
    Private strErrInfo As String
    ' 只读属性，Errinfo, 提供本类错误信息.
    ReadOnly Property ErrInfo() As String
        Get
            Return strErrInfo
        End Get
    End Property        'End  ErrInfo

    Public Sub New()

        mUserConnString = ConfigurationSettings.AppSettings("ConnectionString")
        'Logger.Info(mUserConnString)
        If mUserConnString <> String.Empty Then
            pInitConnection()
        End If

    End Sub

    Private Sub pInitConnection()

        SQLConn = New SqlClient.SqlConnection
        SQLConn.ConnectionString = mUserConnString
        SQLConn.Open()
    End Sub


    '根据选择的方案文件和时间生成数据文件，sXMLFile为方案文件名，nCycleID为时间。
    '可以有多个数据区
    Public Function GetSchema(ByVal Report_Code As String, _
                            ByVal aDate As Date, _
                            ByVal CanModify As Boolean) _
    As String
        If SQLConn.State <> ConnectionState.Open Then
            SQLConn.Open()
        End If
        Logger.Info(SQLConn.ConnectionString)

        strErrInfo = ""
        '载入报表模板
        Dim oAdapter As New SqlClient.SqlDataAdapter("SELECT * FROM T_SCHEMA_MS WHERE I_SCHEMA_ID = '" & Report_Code & "'", SQLConn)

        Dim dtreport As New DataTable("T_TAG_DATA")
        oAdapter.Fill(dtreport)
        oAdapter.Dispose()
        Dim Report_Type, Report_XML, Report_Name, Cycle_Type As String
        If dtreport.Rows.Count > 0 Then
            Report_XML = FilterDBNull(dtreport.Rows(0).Item("I_SCHEMA_XML"))
            Report_Type = FilterDBNull(dtreport.Rows(0).Item("I_SCHEMA_TP"))
            Report_Name = FilterDBNull(dtreport.Rows(0).Item("I_SCHEMA_NM"))
            Cycle_Type = FilterDBNull(dtreport.Rows(0).Item("I_CYCLE_TYPE"))
        End If
        If Report_XML = "" Then
            strErrInfo = Report_Code & ERRINFO_INSPECTREPORT_002
            Return False
        End If
        'Logger.Info(Report_XML)
        Dim i As Integer
        Dim sRetXML, sDateType, sTag, sFill, sTagType, sTagOrient, PrintSet As String
        Dim oXML As Xml.XmlDocument
        Dim oDataNodes As Xml.XmlNodeList
        Dim oDataNode As Xml.XmlNode
        Dim oAttr As Xml.XmlAttribute

        Try
            oXML = New Xml.XmlDocument
            oXML.LoadXml(Report_XML)

            'SQLConn.Open()
            CCData = New OWC10.Spreadsheet
            CCData.XMLData = "<?xml version=""1.0""?>" + oXML.SelectSingleNode("DataSchema/Report").InnerXml

            oDataNodes = oXML.SelectNodes("DataSchema/Retrieve/Item")
            CCData.ActiveSheet.Unprotect()
            '取每个读数据填充区Xpath:DataSchema/Retrieve
            For Each oDataNode In oDataNodes
                sDateType = ""
                sTag = ""
                sFill = ""
                sTagType = ""
                sTagOrient = ""
                '取的数据类型,和目的地址,以及填充区
                For Each oAttr In oDataNode.Attributes
                    Select Case oAttr.Name.ToUpper
                        Case "DATETYPE" '数据导入区的时间特征,小时,天等.
                            sDateType = oAttr.Value.ToUpper
                        Case "TAGRANGE" '数据导入区的指标的定义范围
                            sTag = oAttr.Value.ToUpper
                        Case "FILLRANGE" '数据导入区的指标值的填充范围.
                            sFill = oAttr.Value.ToUpper
                        Case "TAGTYPE" '数据导入区的指标类型,数值指标\字符指标\自定义公示等.
                            sTagType = oAttr.Value.ToUpper
                        Case "TAGORIENT" '数据导入区的指标时间点的方向,从上至下,从左至右.
                            sTagOrient = oAttr.Value.ToUpper
                    End Select
                Next
                If sTagType = "" Then
                    sTagType = "FLOAT" '指标类型缺省为数值型
                End If
                If sTagOrient = "" Then
                    sTagOrient = "0" '排列方向缺省为从上往下
                End If
                '根据报表定义的类型，指标区生成指标数据，并写到EXCEL控件上
                If sTag <> String.Empty Then
                    pGetTagData(aDate, sDateType, sTag, sFill, sTagType, sTagOrient)
                    'Logger.Info("GetTagData")
                End If
            Next

            '读取打印设置
            PrintSet = ""
            oDataNodes = oXML.SelectNodes("DataSchema/Print/Item")
            For Each oDataNode In oDataNodes
                For Each oAttr In oDataNode.Attributes
                    PrintSet = PrintSet + oAttr.Name + "=" + oAttr.Value + "|"
                Next
            Next
            PrintSet = PrintSet + ";"
            'Logger.Info(PrintSet)
            '设置Excelworkbook的属性
            CCData.DisplayGridlines = False
            CCData.DisplayBranding = False
            CCData.AllowPropertyToolbox = False
            CCData.DisplayOfficeLogo = False
            CCData.DisplayRowHeadings = False
            CCData.DisplayColumnHeadings = False
            CCData.DisplayTitleBar = False
            CCData.DisplayToolbar = False
            CCData.DisplayDesignTimeUI = False
            CCData.DisplayWorkbookTabs = False

            If Not CanModify Then
                CCData.Range(CCData.ActiveWindow.ViewableRange).Locked = True
            Else
                '已确认的报表不能修改
                Dim laststate As Short = GetLastOperate(Report_Code, aDate)
                If laststate = 2 Then
                    CCData.Range(CCData.ActiveWindow.ViewableRange).Locked = True
                End If
            End If
            CCData.MaxHeight = "100%"
            CCData.MaxWidth = "100%"
            CCData.AutoFit = True
            CCData.ActiveSheet.Protect()

            'CCData.Export("d:\bb.htm", OWC10.SheetExportActionEnum.ssExportActionNone, OWC10.SheetExportFormat.ssExportHTML)
            Return PrintSet + CCData.XMLData


        Catch er As Exception
            Logger.Error(er.Message, er)

            strErrInfo = ERRINFO_INSPECTREPORT_003 & er.Message
            Return ""
        Finally
            SQLConn.Close()
        End Try

    End Function

    '方法描述:保存OWC报表的数据.
    '--------------------------------------------------------------
    '入口参数说明:
    '--------------------------------------------------------------
    'Report_Code:   报表编号
    'aDate      :   指定日期
    'sXML       :   OWC控件中打开的EXCEL报表的当前XML序列串.
    'oldXML     :   OWC控件中打开的EXCEL报表的原始XML序列串.
    'UserCode   :   当前用户的工号.
    'UserName   :   当前用户的姓名.
    'UserIP     :   当前用户的IP地址.
    '--------------------------------------------------------------
    '返回值     :   boolean
    '--------------------------------------------------------------
    Public Function SaveSchema(ByVal Report_Code As String, _
                                ByVal aDate As Date, _
                                ByVal sXML As String, _
                                ByVal oldXML As String, _
                                ByVal UserCode As String, _
                                ByVal UserName As String, _
                                ByVal UserIP As String) _
    As Boolean
        If SQLConn.State <> ConnectionState.Open Then
            SQLConn.Open()
        End If
        strErrInfo = String.Empty
        '载入报表模板
        Dim oAdapter As New SqlClient.SqlDataAdapter(String.Format("SELECT * FROM T_SCHEMA_MS WHERE I_SCHEMA_ID = '{0}'", Report_Code), SQLConn)
        Dim dtreport As New DataTable("T_TAG_DATA")
        oAdapter.Fill(dtreport)
        oAdapter.Dispose()
        Dim Report_Type, Report_XML, Report_Name As String
        If dtreport.Rows.Count > 0 Then
            Report_XML = FilterDBNull(dtreport.Rows(0).Item("I_SCHEMA_XML"))
            Report_Type = FilterDBNull(dtreport.Rows(0).Item("I_SCHEMA_TP"))
            Report_Name = FilterDBNull(dtreport.Rows(0).Item("I_SCHEMA_NM"))
        End If
        If Report_XML = String.Empty Then
            strErrInfo = Report_Code & ERRINFO_INSPECTREPORT_002
            Return False
        End If

        Dim i As Integer
        Dim sRetXML, sDateType, sTag, sFill, sTagType, sTagOrient As String, saveInfo As String = String.Empty
        Dim oXML As Xml.XmlDocument, oDataNodes As Xml.XmlNodeList, oDataNode As Xml.XmlNode, oAttr As Xml.XmlAttribute

        Try
            oXML = New Xml.XmlDocument
            oXML.LoadXml(Report_XML)

            'SQLConn.Open()

            CCData = New OWC10.Spreadsheet
            CCData.XMLData = sXML
            oldXMLData = New OWC10.Spreadsheet
            oldXMLData.XMLData = oldXML

            oDataNodes = oXML.SelectNodes("DataSchema/Save/Item")
            '取每个保存数据填充区XPATH:DataSchema/Save
            For Each oDataNode In oDataNodes
                sDateType = String.Empty
                sTag = String.Empty
                sFill = String.Empty
                sTagType = String.Empty
                sTagOrient = String.Empty

                '取得日期类型,和指标地址,数据保存区,指标类型
                For Each oAttr In oDataNode.Attributes
                    Select Case oAttr.Name.ToUpper
                        Case "DATETYPE"
                            sDateType = oAttr.Value.ToUpper
                        Case "TAGRANGE"
                            sTag = oAttr.Value.ToUpper
                        Case "SAVERANGE"
                            sFill = oAttr.Value.ToUpper
                        Case "TAGTYPE"
                            sTagType = oAttr.Value.ToUpper
                        Case "TAGORIENT"
                            sTagOrient = oAttr.Value.ToUpper
                    End Select
                Next
                If sTagType = String.Empty Then '指标类型缺省为数值型
                    sTagType = "FLOAT"
                End If
                If sTagOrient = String.Empty Then  '排列方向缺省为从上往下
                    sTagOrient = "0"
                End If
                '根据取得的数据,和保存的定义保存数据
                pSaveData(aDate, sDateType, sTag, sFill, sTagType, sTagOrient, UserName, saveInfo)

            Next
            '全部保存完毕后记录操作日志
            If saveInfo <> String.Empty Then
                '读取打印设置
                'Dim PrintSet As String = ""
                'oDataNodes = oXML.SelectNodes("DataSchema/Print/Item")
                'For Each oDataNode In oDataNodes
                '    For Each oAttr In oDataNode.Attributes
                '        PrintSet = PrintSet + oAttr.Name + "=" + oAttr.Value + "|"
                '    Next
                'Next
                'PrintSet = PrintSet + ";"
                oldXMLData.Range(oldXMLData.ActiveWindow.ViewableRange).Locked = True
                AddOperateInfo(UserCode, UserName, UserIP, Report_Code, 1, aDate, saveInfo, oldXMLData.XMLData)
                Dim objlog As New ApplicationLog
                objlog.WriteInfo(String.Format("{0}[{1}]在{2}上修改了报表:{3}的数据:{4}", UserName, UserCode, UserIP, Report_Name, saveInfo))
            End If

            Return True
        Catch er As Exception
            strErrInfo = ERRINFO_INSPECTREPORT_004 & er.Message
            Return False
        Finally
            SQLConn.Close()
        End Try
    End Function

    '根据日期aDate，时间类型sDateType，指标区域sTagRange，指标类型sTagType，到网格CCData中取出指标数据放到数组aTag中，然后到数据库相应的表中
    '取出这些指标在要取的各时间点的指标值，最后根据填充区域sFill,把值填到CCData上。
    'sTagOrient是指多时间点时各时间点排列方向，0指从上往下排，1指从左往右排，缺省是0。
    Private Function pGetTagData(ByVal aDate As DateTime, _
                                ByVal sDateType As String, _
                                ByVal sTagRange As String, _
                                ByVal sFill As String, _
                                ByVal sTagType As String, _
                                ByVal sTagOrient As String) _
    As Boolean
        Dim sDefineRange As OWC10.Range = CCData.Range(sTagRange)
        '取出指标数据
        Dim aTag As System.Array
        'aTag为2维数组，下标从1开始
        If sDefineRange.Rows.Count = 1 And sDefineRange.Columns.Count = 1 Then
            '当EXCEL网格只有一个时，会出现不能转换到数组的错误，因此先生成数组，再对它进行赋值
            aTag = CCData.Range("A1:B1").Value '目的在于生成一个二维数组,和具体值无关.
            aTag(1, 1) = sDefineRange.Value '重新赋值.
            aTag(1, 2) = ""
        Else
            aTag = sDefineRange.Value
        End If

        '根据数据填充区sFill, 指标类型sTagType, 把指标值填到网格上
        Dim oFillRange As OWC10.Range = CCData.Range(sFill)
        Dim nRowStart, nColStart As Integer
        Dim KK, JJ As Integer

        nRowStart = oFillRange.Row
        nColStart = oFillRange.Column
        '生成指标ID或指标ID|限定条件的拼接字符串.
        Dim sTagIDAll As String = Me.pGenerate_TagIDALL(aTag, sTagType)

        Select Case sTagType.ToUpper
            Case "FLOAT", "STR" '数值和字符数据.
                pGetData_FloatStr(aDate, sTagIDAll, nRowStart, nColStart, aTag, sTagType, sDateType, sTagOrient)
            Case "LINE1" '机泵运行状态图1段
                pGetData_Line(sTagIDAll, nRowStart, nColStart, aTag, 1)
            Case "LINE2" '机泵运行状态图2段
                pGetData_Line(sTagIDAll, nRowStart, nColStart, aTag, 2)
            Case "FUNC" '自定义函数
                Dim sTagID As String = String.Empty
                For JJ = 0 To aTag.GetLength(0) - 1 '指标数组.
                    For KK = 0 To aTag.GetLength(1) - 1
                        sTagID = "" & aTag(JJ + 1, KK + 1)
                        If sTagID.Trim() <> "" Then
                            oFillRange = CType(CCData.Cells._Default(JJ + nRowStart, KK + nColStart), OWC10.Range)
                            oFillRange.Value = pCalcFunc(sTagID, aDate)
                        End If
                    Next
                Next
            Case "AGGREGATION", "MAX", "MIN", "AVG", "SUM", "COUNT" '聚合函数类
                pGetData_Aggregation(aDate, sTagIDAll, nRowStart, nColStart, aTag, sTagType, sDateType, sTagOrient)
            Case "MAXVALUE1DATE" '最大值所在的日期
                pGetData_MaxValue1Date(aDate, sTagIDAll, nRowStart, nColStart, aTag, sTagType, sDateType)
            Case "MINVALUE1DATE" '最小值所在的日期
                pGetData_MinValue1Date(aDate, sTagIDAll, nRowStart, nColStart, aTag, sTagType, sDateType)
            Case "SWITCHCOUNT" '设备开关次数。
                pGetData_SwitchCount(aDate, sTagIDAll, nRowStart, nColStart, aTag, sTagType, sDateType, sTagOrient)
            Case "ONCERUNNINGDATA" '设备开关次数。
                pGetData_OnceRunningData(aDate, sTagIDAll, nRowStart, nColStart, aTag, sTagType, sDateType, sTagOrient)
        End Select
        Return True
    End Function

    '读出数值和字符数据,并写到EXCEL控件上
    Private Function pGetData_FloatStr(ByVal aDate As DateTime, _
                                    ByVal sTagIDAll As String, _
                                    ByVal nRowStart As Integer, _
                                    ByVal nColStart As Integer, _
                                    ByVal aTag As System.Array, _
                                    ByVal sTagType As String, _
                                    ByVal sDateType As String, _
                                    ByVal sTagOrient As String) _
    As Boolean
        Dim JJ, KK, i, j As Integer
        Dim sTagID As String
        Dim oRange As OWC10.Range

        '计算区域,并给相关的参数加入值,这些参数为数据库表的数据
        Dim sTable As String
        If sTagType.ToUpper = "FLOAT" Then
            '数值指标
            sTable = "T_TAG_"
        ElseIf sTagType.ToUpper = "STR" Then
            '字符指标,字符串指标表,目前只存在T_StrTag_Day表,而且表中存在着3001004,3001005指标.
            '但这两个指标在T_Tag_MS表中并不存在.
            sTable = "T_STRTAG_"
        End If

        Dim nStart, nEnd, nTagCount, nTimeCount As Integer
        Dim sBaseKey As String
        '根据指定日期,时间特征来获取指标数据表类型（小时、天等）、开始时间点、结束时间点、总数据点数目等信息。
        '时间特征的信息存储在T_DATE_MS表中.
        If Not pCalcCycleID(aDate, sDateType, sBaseKey, nStart, nEnd, nTimeCount) Then
            strErrInfo = strErrInfo & "  " & sDateType & ERRINFO_INSPECTREPORT_006
            Return False
        End If
        '到数据库取出相应的指标数据
        Dim dtData As New DataTable("T_TAG_DATA")
        Dim dtTag As New DataTable("T_TAG_MS")
        '数据表名
        Dim sSQL As String
        sTable = sTable & sBaseKey.ToUpper

        If nTimeCount = 1 Then
            sSQL = String.Format(" select * from {0} Where I_Cycle_ID = {1} And {2}", sTable, nEnd, Me.pGenerate_TagConditionWhereClause(sTagIDAll))
        Else
            sSQL = String.Format(" select * from {0} WHERE I_CYCLE_ID >= {1} And I_CYCLE_ID <= {2} AND {3}", sTable, nStart, nEnd, Me.pGenerate_TagConditionWhereClause(sTagIDAll))
        End If

        Dim oAdapter As New SqlDataAdapter(sSQL, SQLConn)
        oAdapter.Fill(dtData)
        oAdapter.SelectCommand.CommandText = String.Format("select I_TAG_ID,I_DIG_NUM,MAX_VALUE,MIN_VALUE from T_TAG_MS where ({0}) AND (I_DIG_NUM IS NOT NULL)", Me.pGenerate_TagConditionWhereClause(sTagIDAll))
        oAdapter.Fill(dtTag)
        Dim avalue, maxvalue, minvalue As Double
        '数值指标和字符指标
        If nTimeCount = 1 Then
            For JJ = 0 To aTag.GetLength(0) - 1
                For KK = 0 To aTag.GetLength(1) - 1
                    sTagID = aTag(JJ + 1, KK + 1)
                    If Not (sTagID Is Nothing) Then
                        If sTagID.Trim() <> "" Then
                            oRange = CType(CCData.Cells._Default(JJ + nRowStart, KK + nColStart), OWC10.Range)
                            '&为自定义函数的开始标志
                            If sTagID.Trim().IndexOf("&") = 0 Then
                                oRange.Value = pCalcFunc(sTagID, aDate)
                            Else
                                dtData.DefaultView.RowFilter = String.Format("I_TAG_ID='{0}'", sTagID.Split("|")(0))  '指标定义区域可能指定了限制条件.如:1401001|I_Value_Man>0.1
                                dtTag.DefaultView.RowFilter = String.Format("I_TAG_ID='{0}'", sTagID.Split("|")(0)) '指标定义区域可能指定了限制条件.如:1401001|I_Value_Man>0.1
                                If dtData.DefaultView.Count = 1 Then
                                    If sTagType.ToUpper <> "STR" And dtTag.DefaultView.Count = 1 Then
                                        '四舍五入
                                        avalue = System.Math.Round(dtData.DefaultView.Item(0).Item("I_VALUE_MAN") * System.Math.Pow(10, dtTag.DefaultView.Item(0).Item("I_DIG_NUM"))) * System.Math.Pow(10, -dtTag.DefaultView.Item(0).Item("I_DIG_NUM"))
                                        oRange.Value = avalue
                                        '自动采集的数据改变颜色
                                        '以I_VALUE_ORG为准
                                        Dim i_value_org As Double = Convert.ToDouble(dtData.DefaultView.Item(0).Item("I_VALUE_ORG"))
                                        Dim i_value_man As Double = Convert.ToDouble(dtData.DefaultView.Item(0).Item("I_VALUE_MAN"))
                                        Dim range As Double = Convert.ToDouble(System.Configuration.ConfigurationSettings.AppSettings("RangValue").ToString())
                                        If Not i_value_org = 0 Then
                                            If System.Math.Abs(((i_value_org - i_value_man) / i_value_org)) <= range Then
                                                oRange.Font.Color = "Purple"
                                            Else
                                                oRange.Font.Color = "Black"
                                            End If

                                        Else
                                            If dtData.DefaultView.Item(0).Item("I_VALUE_ORG") = dtData.DefaultView.Item(0).Item("I_VALUE_MAN") Then
                                                oRange.Font.Color = "Purple"
                                            Else
                                                oRange.Font.Color = "Black"
                                            End If
                                        End If
                                        If sBaseKey = "HOUR" And FilterDBNull(dtTag.DefaultView.Item(0).Item("MAX_VALUE")) <> "" And FilterDBNull(dtTag.DefaultView.Item(0).Item("MIN_VALUE")) <> "" Then
                                            '对于设备监测指标（小时数据），当指标值超出最大值、最小值时字体用红色，
                                            If avalue > CDbl(dtTag.DefaultView.Item(0).Item("MAX_VALUE")) Or avalue < CDbl(dtTag.DefaultView.Item(0).Item("MIN_VALUE")) Then
                                                oRange.Font.Color = "Red"
                                            Else
                                                '如果有几秒超出范围，则显示成黄色
                                                If Not dtData.DefaultView.Item(0).Item("UPPER_SECONDS") Is DBNull.Value Then
                                                    If CInt(dtData.DefaultView.Item(0).Item("UPPER_SECONDS")) > 0 Then
                                                        oRange.Font.Color = "Yellow"
                                                    End If
                                                End If
                                                If Not dtData.DefaultView.Item(0).Item("LOWER_SECONDS") Is DBNull.Value Then
                                                    If CInt(dtData.DefaultView.Item(0).Item("LOWER_SECONDS")) > 0 Then
                                                        oRange.Font.Color = "Yellow"
                                                    End If
                                                End If
                                            End If
                                        End If
                                    Else
                                        '字符指标
                                        oRange.Value = dtData.DefaultView.Item(0).Item("I_VALUE_MAN")
                                    End If
                                End If
                            End If
                        End If
                    End If
                Next
            Next
        Else
            '多时间点时要考虑时间点的排列方向
            If sTagOrient = "0" Then
                nTagCount = aTag.GetLength(1) - 1
            Else
                nTagCount = aTag.GetLength(0) - 1
            End If
            For JJ = 0 To nTagCount
                If sTagOrient = "0" Then
                    sTagID = "" & aTag(1, JJ + 1)
                Else
                    sTagID = "" & aTag(JJ + 1, 1)
                End If
                If sTagID.Trim() <> "" Then
                    dtData.DefaultView.RowFilter = String.Format("I_TAG_ID='{0}'", sTagID.Split("|")(0))
                    dtTag.DefaultView.RowFilter = String.Format("I_TAG_ID='{0}'", sTagID.Split("|")(0))
                    For i = 0 To dtData.DefaultView.Count - 1
                        If sBaseKey = "DAY" Then
                            Dim curday, startday As Date
                            Dim str As String = CStr(dtData.DefaultView.Item(i).Item("I_CYCLE_ID"))
                            curday = CDate(str.Substring(0, 4) + "-" + str.Substring(4, 2) + "-" + str.Substring(6, 2))
                            str = nStart.ToString
                            startday = CDate(str.Substring(0, 4) + "-" + str.Substring(4, 2) + "-" + str.Substring(6, 2))
                            j = DateDiff(DateInterval.Day, startday, curday)
                        ElseIf sBaseKey = "MONTH" Then
                            Dim curmon As String = CStr(dtData.DefaultView.Item(i).Item("I_CYCLE_ID"))
                            Dim startmon As String = CStr(nStart)
                            j = (CInt(curmon.Substring(0, 4)) - CInt(startmon.Substring(0, 4))) * 12 + CInt(curmon.Substring(4, 2)) - CInt(startmon.Substring(4, 2))
                        Else
                            j = dtData.DefaultView.Item(i).Item(0) - nStart
                        End If
                        If sTagOrient = "0" Then
                            oRange = CType(CCData.Cells._Default(j + nRowStart, JJ + nColStart), OWC10.Range)
                        Else
                            oRange = CType(CCData.Cells._Default(JJ + nRowStart, j + nColStart), OWC10.Range)
                        End If
                        If sTagType.ToUpper <> "STR" And dtTag.DefaultView.Count = 1 Then
                            '四舍五入
                            avalue = System.Math.Round(dtData.DefaultView.Item(i).Item("I_VALUE_MAN") * System.Math.Pow(10, dtTag.DefaultView.Item(0).Item("I_DIG_NUM"))) * System.Math.Pow(10, -dtTag.DefaultView.Item(0).Item("I_DIG_NUM"))
                            oRange.Value = avalue
                            '自动采集的数据改变颜色
                            'If dtData.DefaultView.Item(i).Item("I_VALUE_ORG") = dtData.DefaultView.Item(i).Item("I_VALUE_MAN") Then
                            'oRange.Font.Color = "Purple"
                            'End If
                            Dim i_value_org As Double = Convert.ToDouble(dtData.DefaultView.Item(0).Item("I_VALUE_ORG"))
                            Dim i_value_man As Double = Convert.ToDouble(dtData.DefaultView.Item(0).Item("I_VALUE_MAN"))
                            Dim range As Double = Convert.ToDouble(System.Configuration.ConfigurationSettings.AppSettings("RangValue").ToString())
                            If Not i_value_org = 0 Then
                                If System.Math.Abs(((i_value_org - i_value_man) / i_value_org)) <= range Then
                                    oRange.Font.Color = "Purple"
                                Else
                                    oRange.Font.Color = "Black"
                                End If

                            Else
                                If dtData.DefaultView.Item(0).Item("I_VALUE_ORG") = dtData.DefaultView.Item(0).Item("I_VALUE_MAN") Then
                                    oRange.Font.Color = "Purple"
                                Else
                                    oRange.Font.Color = "Black"
                                End If
                            End If
                            If sBaseKey = "HOUR" And FilterDBNull(dtTag.DefaultView.Item(0).Item("MAX_VALUE")) <> "" And FilterDBNull(dtTag.DefaultView.Item(0).Item("MIN_VALUE")) <> "" Then
                                '对于设备监测指标（小时数据），当指标值超出最大值、最小值时字体用红色，
                                If avalue > CDbl(dtTag.DefaultView.Item(0).Item("MAX_VALUE")) Or avalue < CDbl(dtTag.DefaultView.Item(0).Item("MIN_VALUE")) Then
                                    oRange.Font.Color = "Red"
                                Else
                                    '如果有几秒超出范围，则显示成黄色
                                    If Not dtData.DefaultView.Item(i).Item("UPPER_SECONDS") Is DBNull.Value Then
                                        If CInt(dtData.DefaultView.Item(i).Item("UPPER_SECONDS")) > 0 Then
                                            oRange.Font.Color = "Yellow"
                                        End If
                                    End If
                                    If Not dtData.DefaultView.Item(i).Item("LOWER_SECONDS") Is DBNull.Value Then
                                        If CInt(dtData.DefaultView.Item(i).Item("LOWER_SECONDS")) > 0 Then
                                            oRange.Font.Color = "Yellow"
                                        End If
                                    End If
                                End If
                            End If
                        Else
                            '字符指标
                            oRange.Value = dtData.DefaultView.Item(i).Item("I_VALUE_MAN")
                        End If
            Next i
                End If
            Next
        End If
    End Function
    '方法说明:聚合类型值的获取.包括MAX,MIN,AVG,SUM,COUNT等的获取.
    '入口参数:
    '           aDate     : 指定日期.
    '           sTagIDALL : 指标字符串,形如('1401001','1401002','1401003','1401004')
    '           nRowStart : 数据填充区域的开始行号.
    '           nColStart : 数据填充区域的开始列号.
    '           aTag      : 由指标定义区域所转换而来的对应的二维数组.当实际指标定义区域为一个单元格时,aTag对应有aTag(1, 1),aTag(1, 2)两个元素,aTag(1,2)的值为"".
    '           sTagType  : 指标类型,(数值指标,字符指标,自定义公式,一段运行状态,二段运行状态,MAX,MIN,AVG,SUM等).
    '           sDateType : 时间特征,时间特征由表T_Date_MS来定义.用来确定指标采样值的取值来源,时间范围,以及数目等信息.
    Private Function pGetData_Aggregation(ByVal aDate As DateTime, _
                                            ByVal sTagIDALL As String, _
                                            ByVal nRowStart As Integer, _
                                            ByVal nColStart As Integer, _
                                            ByVal aTag As System.Array, _
                                            ByVal sTagType As String, _
                                            ByVal sDateType As String, _
                                            ByVal sTagOrient As String) _
    As Boolean
        Dim JJ, KK, i, j As Integer
        Dim sTagID As String
        Dim oRange As OWC10.Range
        Dim maxRange, minRange, avgRange, countRange, regularCountRange As OWC10.Range
        '计算区域,并给相关的参数加入值,这些参数为数据库表的数据
        Dim sTable As String
        sTable = "T_TAG_"

        Dim nStart, nEnd, nTagCount, nTimeCount As Integer
        Dim sBaseKey As String
        '根据指定日期,时间特征来获取指标数据表类型（小时、天等）、开始时间点、结束时间点、总数据点数目等信息。
        '时间特征的信息存储在T_DATE_MS表中.
        If Not pCalcCycleID(aDate, sDateType, sBaseKey, nStart, nEnd, nTimeCount) Then
            strErrInfo = strErrInfo & "  " & sDateType & ERRINFO_INSPECTREPORT_006
            Return False
        End If
        '到数据库取出相应的指标数据
        Dim dtData As New DataTable("T_TAG_DATA")
        Dim dtTag As New DataTable("T_TAG_MS")
        '数据表名
        Dim sqlStatement As String
        sTable = sTable & sBaseKey.ToUpper
        '开启事务.
        Dim mytrans As SqlTransaction = SQLConn.BeginTransaction("CschemaAggregation")
        Dim myCommand As SqlCommand = SQLConn.CreateCommand()
        myCommand.Transaction = mytrans
        '首先将指标值根据时间范围写入临时表.
        '因为在对小时表数据进行检索的时候,在碰到年累计数据的时候,
        '直接以单调SQL语句进行检索的时候,性能很低.而用临时表,对于性能的提升比较大.
        '测试时,如果是一年的数据量,指标个数为28个时,单条SQL执行需要一分钟.
        '而采用临时表则只需6到7秒钟.
        Try
            'sqlStatement = string.Format("Select 
            'SQL示例为  Select  i_tag_id,I_Cycle_ID,I_Value_Man
            '           From    t_tag_day 
            '           Where   I_cycle_ID>=1 And 
            '                   I_Cycle_ID<=10 And 
            '                   (I_Tag_ID ='1401001' OR I_Tag_ID = '1401002') 
            sqlStatement = String.Format("Select I_TAG_ID,I_CYCLE_ID,I_VALUE_MAN " & _
                                         "Into #temp " & _
                                         "From {0} " & _
                                         "Where I_Cycle_ID>={1} And " & _
                                         "      I_Cycle_ID<={2} And " & _
                                         "      {3} ", sTable, nStart, nEnd, pGenerate_PureTagConditionWhereClause(sTagIDALL))
            myCommand.CommandText = sqlStatement
            Logger.Debug(sqlStatement)

            myCommand.ExecuteNonQuery()
            'SQL示例为  Select  i_tag_id,MAX(I_Value_Man) As MaxValue,Min(I_Value_Man) As MinValue,Avg(I_Value_Man) As AvgValue,Count(I_Value_Man)
            '           From    #temp 
            '           Where   I_cycle_ID>=1 And 
            '                   I_Cycle_ID<=10 And 
            '                   (
            '                    (I_Tag_ID = '1401001' And I_Value_Man >=0.1) Or
            '                    (I_Tag_ID = '1401002')
            '                   ) 
            '                   Group By I_Tag_ID.
            sqlStatement = String.Format(" Select   I_TAG_ID, " & _
                                         "          Max(I_Value_Man) As MaxValue," & _
                                         "          Min(I_Value_Man) As MinValue," & _
                                         "          AVG(I_Value_Man) As AvgValue," & _
                                         "          Count(*) As CountValue, " & _
                                         "          Count({0}) AS Regular_CountValue " & _
                                         " From  #temp " & _
                                         " Where I_Cycle_ID>={1} And " & _
                                         "       I_Cycle_ID <={2} And " & _
                                         "       {3} " & _
                                         " Group By I_TAG_ID", pGenerate_TagConditionColumn(sTagIDALL), nStart, nEnd, pGenerate_PureTagConditionWhereClause(sTagIDALL))
            Dim oAdapter As New SqlDataAdapter(sqlStatement, SQLConn)
            Logger.Debug(sqlStatement)

            oAdapter.SelectCommand.Transaction = mytrans
            oAdapter.Fill(dtData)
            '删除掉临时表.
            myCommand.CommandText = "Drop Table #temp"
            Logger.Debug(myCommand.CommandText)

            myCommand.ExecuteNonQuery()

            oAdapter.SelectCommand.CommandText = String.Format("Select I_TAG_ID,I_DIG_NUM,MAX_VALUE,MIN_VALUE" & _
                                                                " From T_TAG_MS " & _
                                                                " Where {0} And  I_DIG_NUM IS NOT NULL", Me.pGenerate_PureTagConditionWhereClause(sTagIDALL))
            oAdapter.Fill(dtTag)
            mytrans.Commit()
        Catch ex As Exception
            mytrans.Rollback()
        End Try
        'Dim avalue As Double
        For JJ = 0 To aTag.GetLength(0) - 1
            For KK = 0 To aTag.GetLength(1) - 1 '遍历指标定义二维数组.
                sTagID = aTag(JJ + 1, KK + 1) '数组的下标从1开始.
                If Not (sTagID Is Nothing) Then
                    If sTagID.Trim() <> String.Empty Then
                        maxRange = CType(CCData.Cells._Default(JJ + nRowStart, KK + nColStart), OWC10.Range) '找到对应指标采样值对应的单元格.(1个单元格)
                        If sTagOrient = "0" Then '从上往下
                            minRange = CType(CCData.Cells._Default(JJ + nRowStart + 1, KK + nColStart), OWC10.Range) '找到对应指标采样值对应的单元格.(1个单元格)
                            avgRange = CType(CCData.Cells._Default(JJ + nRowStart + 2, KK + nColStart), OWC10.Range) '找到对应指标采样值对应的单元格.(1个单元格)
                            countRange = CType(CCData.Cells._Default(JJ + nRowStart + 3, KK + nColStart), OWC10.Range) '找到对应指标采样值对应的单元格.(1个单元格)
                            regularCountRange = CType(CCData.Cells._Default(JJ + nRowStart + 4, KK + nColStart), OWC10.Range) '找到对应指标采样值对应的单元格.(1个单元格)
                        Else '从左到右
                            minRange = CType(CCData.Cells._Default(JJ + nRowStart, KK + nColStart + 1), OWC10.Range) '找到对应指标采样值对应的单元格.(1个单元格)
                            avgRange = CType(CCData.Cells._Default(JJ + nRowStart, KK + nColStart + 2), OWC10.Range) '找到对应指标采样值对应的单元格.(1个单元格)
                            countRange = CType(CCData.Cells._Default(JJ + nRowStart, KK + nColStart + 3), OWC10.Range) '找到对应指标采样值对应的单元格.(1个单元格)
                            regularCountRange = CType(CCData.Cells._Default(JJ + nRowStart, KK + nColStart + 4), OWC10.Range) '找到对应指标采样值对应的单元格.(1个单元格)
                        End If
                        'oRange = CType(CCData.Cells._Default(JJ + nRowStart, KK + nColStart), OWC10.Range) '找到对应指标采样值对应的单元格.(1个单元格)

                        dtData.DefaultView.RowFilter = String.Format("I_TAG_ID='{0}'", sTagID.Split("|")(0))
                        dtTag.DefaultView.RowFilter = String.Format("I_TAG_ID='{0}'", sTagID.Split("|")(0))
                        If dtData.DefaultView.Count = 1 Then '如果指标的采样值记录有一条记录.
                            '定义指标采样值的人工值(并非人工输入的意思,意为可人工修改的),原始值的变量.
                            Dim maxValue, minValue, avgValue, countValue, regularCountValue
                            maxValue = dtData.DefaultView.Item(0).Item("MaxValue")
                            minValue = dtData.DefaultView.Item(0).Item("MinValue")
                            avgValue = dtData.DefaultView.Item(0).Item("AvgValue")
                            countValue = dtData.DefaultView.Item(0).Item("CountValue")
                            regularCountValue = dtData.DefaultView.Item(0).Item("Regular_CountValue")
                            If sTagType.ToUpper <> "STR" And dtTag.DefaultView.Count = 1 Then '如果指标类型(在报表定义中定义)不是字符指标,并且在T_Tag_MS中存在记录.
                                Dim digNum As Object
                                digNum = dtTag.DefaultView.Item(0).Item("I_DIG_NUM")
                                '四舍五入,根据在T_Tag_MS中定义的指标的小数点保留位数.
                                maxValue = System.Math.Round(maxValue * System.Math.Pow(10, digNum)) * System.Math.Pow(10, -digNum)
                                minValue = System.Math.Round(minValue * System.Math.Pow(10, digNum)) * System.Math.Pow(10, -digNum)
                                avgValue = System.Math.Round(avgValue * System.Math.Pow(10, digNum)) * System.Math.Pow(10, -digNum)
                                maxRange.Value = maxValue
                                minRange.Value = minValue
                                avgRange.Value = avgValue
                                countRange.Value = countValue
                                regularCountRange.Value = regularCountValue
                            Else '字符指标,或者该指标没有在T_Tag_MS中定义.
                                maxRange.Value = maxValue
                                minRange.Value = minValue
                                avgRange.Value = avgValue
                                countRange.Value = countValue
                                regularCountRange.Value = regularCountValue
                            End If
                        End If

                    End If
                End If
            Next
        Next
    End Function
    '获取指标采样值最大值所在的第一个日期.

    Private Function pGetData_MaxValue1Date(ByVal aDate As DateTime, _
                                            ByVal sTagIDALL As String, _
                                            ByVal nRowStart As Integer, _
                                            ByVal nColStart As Integer, _
                                            ByVal aTag As System.Array, _
                                            ByVal sTagType As String, _
                                            ByVal sDateType As String) _
    As Boolean
        Dim JJ, KK, i, j As Integer
        Dim sTagID As String
        Dim oRange As OWC10.Range
        '计算区域,并给相关的参数加入值,这些参数为数据库表的数据
        Dim sTable As String = "T_TAG_"

        Dim nStart, nEnd, nTagCount, nTimeCount As Integer
        Dim sBaseKey As String
        '根据指定日期,时间特征来获取指标数据表类型（小时、天等）、开始时间点、结束时间点、总数据点数目等信息。
        '时间特征的信息存储在T_DATE_MS表中.
        If Not pCalcCycleID(aDate, sDateType, sBaseKey, nStart, nEnd, nTimeCount) Then
            strErrInfo = String.Format("{0}  {1}  {2}", strErrInfo, sDateType, ERRINFO_INSPECTREPORT_006)
            Return False
        End If
        '到数据库取出相应的指标数据
        Dim dtData As New DataTable("T_TAG_DATA")
        Dim dtTag As New DataTable("T_TAG_MS")
        '数据表名
        Dim sSQL As String
        sTable = sTable & sBaseKey.ToUpper
        'SQL示例为  Select  i_tag_ID,dbo.HourCycleID2DateTime(Min(I_cycle_ID)) As I_Cycle_ID
        '           from 	t_tag_hour B,
        '                   (Select i_tag_ID as tagID, MAX(I_value_Man) as valueMan
        '                   From    t_tag_hour
        '                   Where   (i_tag_ID ='1401001' OR  i_tag_ID = '1401002') And
        '                           i_cycle_id >=35000 and 
        '                           i_cycle_ID <=35200
        '                   Group by i_tag_id) as A
        '           Where   i_tag_id = tagID And
        '                   i_cycle_id >=35000 and 
        '                   i_cycle_ID <=35200 and
        '                   (i_tag_ID ='1401001' OR  i_tag_ID = '1401002') and
        '                   i_value_man = valueMan
        '           group by i_tag_id
        Dim CycleID2DateTimeFunction As String = String.Empty
        Select Case sBaseKey.ToUpper
            Case "HOUR"
                CycleID2DateTimeFunction = "dbo.HourCycleID2DateTime"
            Case "DAY"
                CycleID2DateTimeFunction = "dbo.DayCycleID2DateTime"
            Case "MONTH"
                CycleID2DateTimeFunction = "dbo.MonthCycleID2DateTime"
            Case "YEAR"
                CycleID2DateTimeFunction = "dbo.YearCycleID2DateTime"
        End Select
        sSQL = String.Format(" Select   I_Tag_ID, {4}(MIN(I_Cycle_ID)) As MaxDate" & _
                            " From  {0} B," & _
                            "       (Select i_tag_ID as tagID, MAX(I_Value_Man) As valueMan" & _
                            "       From    {0} " & _
                            "       Where   {1} And " & _
                            "               i_cycle_ID >= {2} And " & _
                            "               i_cycle_ID <= {3} " & _
                            "       Group By i_tag_ID) As A " & _
                            " Where i_tag_id = tagID And " & _
                            "       I_Cycle_ID >= {2} And " & _
                            "       I_Cycle_ID <= {3} And " & _
                            "       {1} And " & _
                            "       I_Value_Man = valueMan " & _
                            " Group By I_Tag_ID ", sTable, Me.pGenerate_PureTagConditionWhereClause(sTagIDALL), nStart, nEnd, CycleID2DateTimeFunction)
        Logger.Debug("MaxDate: " + sSQL)

        Dim oAdapter As New SqlDataAdapter(sSQL, SQLConn)
        oAdapter.Fill(dtData)

        For JJ = 0 To aTag.GetLength(0) - 1
            For KK = 0 To aTag.GetLength(1) - 1 '遍历指标定义二维数组.
                sTagID = aTag(JJ + 1, KK + 1) '数组的下标从1开始.
                If Not (sTagID Is Nothing) Then
                    If sTagID.Trim() <> String.Empty Then
                        oRange = CType(CCData.Cells._Default(JJ + nRowStart, KK + nColStart), OWC10.Range) '找到对应指标采样值对应的单元格.(1个单元格)
                        '&为自定义函数的开始标志
                        If sTagID.Trim().IndexOf("&") = 0 Then
                            oRange.Value = pCalcFunc(sTagID, aDate) '目前的自定义函数主要用于日期的处理.
                        Else
                            dtData.DefaultView.RowFilter = String.Format("I_TAG_ID='{0}'", sTagID.Split("|".ToCharArray())(0))
                            'dtTag.DefaultView.RowFilter = String.Format("I_TAG_ID='{0}'", sTagID)
                            If dtData.DefaultView.Count = 1 Then '如果指标的采样值记录有一条记录.
                                '定义指标采样值的人工值(并非人工输入的意思,意为可人工修改的),原始值的变量.
                                Dim valueMan
                                valueMan = dtData.DefaultView.Item(0).Item("MaxDate") '此时的I_Value_Man是I_Cycle_ID.
                                oRange.Value = valueMan
                            End If
                        End If
                    End If
                End If
            Next
        Next
    End Function
    '获取指标采样值最小值所在的第一个日期.
    Private Function pGetData_MinValue1Date(ByVal aDate As DateTime, _
                                            ByVal sTagIDALL As String, _
                                            ByVal nRowStart As Integer, _
                                            ByVal nColStart As Integer, _
                                            ByVal aTag As System.Array, _
                                            ByVal sTagType As String, _
                                            ByVal sDateType As String) _
    As Boolean
        Dim JJ, KK, i, j As Integer
        Dim sTagID As String
        Dim oRange As OWC10.Range
        '计算区域,并给相关的参数加入值,这些参数为数据库表的数据
        Dim sTable As String = "T_TAG_"

        Dim nStart, nEnd, nTagCount, nTimeCount As Integer
        Dim sBaseKey As String
        '根据指定日期,时间特征来获取指标数据表类型（小时、天等）、开始时间点、结束时间点、总数据点数目等信息。
        '时间特征的信息存储在T_DATE_MS表中.
        If Not pCalcCycleID(aDate, sDateType, sBaseKey, nStart, nEnd, nTimeCount) Then
            strErrInfo = strErrInfo & "  " & sDateType & ERRINFO_INSPECTREPORT_006
            Return False
        End If
        '到数据库取出相应的指标数据
        Dim dtData As New DataTable("T_TAG_DATA")
        Dim dtTag As New DataTable("T_TAG_MS")
        '数据表名
        Dim sSQL As String
        sTable = sTable & sBaseKey.ToUpper

        'SQL示例为  Select  i_tag_ID,dbo.HourCycleID2DateTime(Min(I_cycle_ID)) As I_Cycle_ID
        '           from 	t_tag_hour B,
        '                   (Select i_tag_ID as tagID, MAX(I_value_Man) as valueMan
        '                   From    t_tag_hour
        '                   Where   (i_tag_ID ='1401001' OR  i_tag_ID = '1401002') And
        '                           i_cycle_id >=35000 and 
        '                           i_cycle_ID <=35200
        '                   Group by i_tag_id) as A
        '           Where   i_tag_id = tagID And
        '                   i_cycle_id >=35000 and 
        '                   i_cycle_ID <=35200 and
        '                   (i_tag_ID ='1401001' OR  i_tag_ID = '1401002') and
        '                   i_value_man = valueMan
        '           group by i_tag_id
        Dim CycleID2DateTimeFunction As String = String.Empty
        Select Case sBaseKey.ToUpper
            Case "HOUR"
                CycleID2DateTimeFunction = "dbo.HourCycleID2DateTime"
            Case "DAY"
                CycleID2DateTimeFunction = "dbo.DayCycleID2DateTime"
            Case "MONTH"
                CycleID2DateTimeFunction = "dbo.MonthCycleID2DateTime"
            Case "YEAR"
                CycleID2DateTimeFunction = "dbo.YearCycleID2DateTime"
        End Select
        sSQL = String.Format(" Select   I_Tag_ID, {4}(MIN(I_Cycle_ID)) As MinDate" & _
                            " From  {0} B," & _
                            "       (Select i_tag_ID as tagID, MIN(I_Value_Man) As valueMan" & _
                            "       From    {0} " & _
                            "       Where   {1} And " & _
                            "               i_cycle_ID >= {2} And " & _
                            "               i_cycle_ID <= {3} " & _
                            "       Group By i_tag_ID) As A " & _
                            " Where i_tag_id = tagID And " & _
                            "       I_Cycle_ID >= {2} And " & _
                            "       I_Cycle_ID <= {3} And " & _
                            "       {1} And " & _
                            "       I_Value_Man = valueMan " & _
                            " Group By I_Tag_ID ", sTable, Me.pGenerate_PureTagConditionWhereClause(sTagIDALL), nStart, nEnd, CycleID2DateTimeFunction)
        Logger.Debug(sSQL)

        Dim oAdapter As New SqlDataAdapter(sSQL, SQLConn)
        oAdapter.Fill(dtData)

        For JJ = 0 To aTag.GetLength(0) - 1
            For KK = 0 To aTag.GetLength(1) - 1 '遍历指标定义二维数组.
                sTagID = aTag(JJ + 1, KK + 1) '数组的下标从1开始.
                If Not (sTagID Is Nothing) Then
                    If sTagID.Trim() <> String.Empty Then
                        oRange = CType(CCData.Cells._Default(JJ + nRowStart, KK + nColStart), OWC10.Range) '找到对应指标采样值对应的单元格.(1个单元格)
                        '&为自定义函数的开始标志
                        If sTagID.Trim().IndexOf("&") = 0 Then
                            oRange.Value = pCalcFunc(sTagID, aDate) '目前的自定义函数主要用于日期的处理.
                        Else
                            dtData.DefaultView.RowFilter = String.Format("I_TAG_ID='{0}'", sTagID.Split("|".ToCharArray())(0))
                            'dtTag.DefaultView.RowFilter = String.Format("I_TAG_ID='{0}'", sTagID)
                            If dtData.DefaultView.Count = 1 Then '如果指标的采样值记录有一条记录.
                                '定义指标采样值的人工值(并非人工输入的意思,意为可人工修改的),原始值的变量.
                                Dim valueMan
                                valueMan = dtData.DefaultView.Item(0).Item("MinDate") '此时的I_Value_Man是I_Cycle_ID.
                                oRange.Value = valueMan
                            End If
                        End If
                    End If
                End If
            Next
        Next
    End Function
    '读出设备当前运行在哪个段上及该设备的运行状态,并写到EXCEL控件上
    Private Function pGetData_Line(ByVal sTagIDAll As String, _
                                    ByVal nRowStart As Integer, _
                                    ByVal nColStart As Integer, _
                                    ByVal aTag As System.Array, _
                                    ByVal line As Short) _
    As Boolean
        Dim JJ, KK, i, j, strleft, strtop As Integer
        Dim sTagID, dev_name As String
        Dim oRange As OWC10.Range

        Dim dtData As New DataTable("T_TAG_DATA")
        dtData = GetDevLine(sTagIDAll, line)
        j = 0
        For JJ = 0 To aTag.GetLength(0) - 1
            For KK = 0 To aTag.GetLength(1) - 1
                sTagID = "" & aTag(JJ + 1, KK + 1)
                If sTagID.Trim() <> "" Then
                    dtData.DefaultView.RowFilter = String.Format("SHOP_CODE='{0}'", sTagID)
                    oRange = CType(CCData.Cells._Default(JJ + nRowStart, KK + nColStart), OWC10.Range)
                    oRange.Value = ""
                    For i = 0 To dtData.DefaultView.Count - 1
                        j = j + 1
                        dev_name = FilterDBNull(dtData.DefaultView.Item(i).Item("Dev_Short_Name"))
                        If dev_name.Length = "1" Then
                            dev_name = "&nbsp;" & dev_name
                            strleft = 13
                        Else
                            strleft = 8
                        End If
                        strleft = strleft + 48 * i
                        If CInt(dtData.DefaultView.Item(i).Item("Status")) = 0 Then
                            oRange.Value = oRange.Value + "&nbsp;<span style='FONT-SIZE: 12pt;COLOR:black'><b>" & dev_name & "</b></span><img border=0 src='Images/jb_stoped.gif' width=35 height=30>"
                        ElseIf CInt(dtData.DefaultView.Item(i).Item("Status")) = 1 Then
                            oRange.Value = oRange.Value + "&nbsp;<span style='FONT-SIZE: 12pt;COLOR:black'><b>" & dev_name & "</b></span><img border=0 src='Images/jb_running.gif' width=35 height=30>"
                        ElseIf CInt(dtData.DefaultView.Item(i).Item("Status")) = 2 Then
                            oRange.Value = "<div id='pic" & j & "' style='Z-INDEX:3;PADDING-LEFT: 4px;PADDING-TOP: 2px;PADDING-BOTTOM: 2px;PADDING-RIGHT: 4px;VISIBILITY:visible;POSITION:relative;'><img border=0 src='Images/Unworkable.gif' width=40 height=40><div id='str" & j & "' style='Z-INDEX:3;LEFT:" & strleft & "px;TOP:9px;VISIBILITY:visible;POSITION:absolute;'><span style='FONT-SIZE: 18pt;COLOR: blue'><b>" & dev_name & "</b></span></div></div>"
                        ElseIf CInt(dtData.DefaultView.Item(i).Item("Status")) = 3 Then
                            oRange.Value = "<div id='pic" & j & "' style='Z-INDEX:3;PADDING-LEFT: 4px;PADDING-TOP: 2px;PADDING-BOTTOM: 2px;PADDING-RIGHT: 4px;VISIBILITY:visible;POSITION:relative;'><img border=0 src='Images/Repairing.gif' width=40 height=40><div id='str" & j & "' style='Z-INDEX:3;LEFT:" & strleft & "px;TOP:9px;VISIBILITY:visible;POSITION:absolute;'><span style='FONT-SIZE: 18pt;COLOR: blue'><b>" & dev_name & "</b></span></div></div>"
                        End If

                        'If dev_name.Length = "1" Then
                        '    strleft = 13
                        'Else
                        '    strleft = 8
                        'End If
                        'strleft = strleft + 43 * i
                        'If CInt(dtData.DefaultView.Item(i).Item("Status")) = 0 Then
                        '    oRange.Value = oRange.Value + "<img border=0 src='Images/jb_stoped.gif' width=35 height=30><div style='Z-INDEX:3;LEFT:" & strleft & "px;TOP:7px;VISIBILITY:visible;POSITION:absolute;'><span style='FONT-SIZE: 12pt;COLOR: blue'><b>" & dev_name & "</b></span></div>"
                        'ElseIf CInt(dtData.DefaultView.Item(i).Item("Status")) = 1 Then
                        '    oRange.Value = oRange.Value + "<img border=0 src='Images/jb_running.gif' width=35 height=30><div style='Z-INDEX:3;LEFT:" & strleft & "px;TOP:7px;VISIBILITY:visible;POSITION:absolute;'><span style='FONT-SIZE: 12pt;COLOR: yellow'><b>" & dev_name & "</b></span></div>"
                        'ElseIf CInt(dtData.DefaultView.Item(i).Item("Status")) = 2 Then
                        '    oRange.Value = "<div id='pic" & j & "' style='Z-INDEX:3;PADDING-LEFT: 4px;PADDING-TOP: 2px;PADDING-BOTTOM: 2px;PADDING-RIGHT: 4px;VISIBILITY:visible;POSITION:relative;'><img border=0 src='Images/Unworkable.gif' width=40 height=40><div id='str" & j & "' style='Z-INDEX:3;LEFT:" & strleft & "px;TOP:9px;VISIBILITY:visible;POSITION:absolute;'><span style='FONT-SIZE: 18pt;COLOR: blue'><b>" & dev_name & "</b></span></div></div>"
                        'ElseIf CInt(dtData.DefaultView.Item(i).Item("Status")) = 3 Then
                        '    oRange.Value = "<div id='pic" & j & "' style='Z-INDEX:3;PADDING-LEFT: 4px;PADDING-TOP: 2px;PADDING-BOTTOM: 2px;PADDING-RIGHT: 4px;VISIBILITY:visible;POSITION:relative;'><img border=0 src='Images/Repairing.gif' width=40 height=40><div id='str" & j & "' style='Z-INDEX:3;LEFT:" & strleft & "px;TOP:9px;VISIBILITY:visible;POSITION:absolute;'><span style='FONT-SIZE: 18pt;COLOR: blue'><b>" & dev_name & "</b></span></div></div>"
                        'End If
                        'If i < dtData.DefaultView.Count - 1 Then
                        '    oRange.Value = oRange.Value & "&nbsp;"
                        'End If

                        'oRange = CType(CCData.Cells._Default(JJ + nRowStart, KK + nColStart + i), OWC10.Range)
                        'If CInt(dtData.DefaultView.Item(i).Item("Status")) = 0 Then
                        '    oRange.Value = "<img style='Z-INDEX:3;PADDING-LEFT: 4px;PADDING-TOP: 2px;PADDING-BOTTOM: 2px;PADDING-RIGHT: 4px;VISIBILITY:visible;' border=0 src='Images/Stoped.gif' width=40 height=40><div id='str" & j & "' style='Z-INDEX:3;LEFT:" & strleft & "px;TOP:9px;VISIBILITY:visible;POSITION:absolute;'><span style='FONT-SIZE: 18pt;COLOR: blue'><b>" & dev_name & "</b></span></div>"
                        'ElseIf CInt(dtData.DefaultView.Item(i).Item("Status")) = 1 Then
                        '    oRange.Value = "<img style='Z-INDEX:3;PADDING-LEFT: 4px;PADDING-TOP: 2px;PADDING-BOTTOM: 2px;PADDING-RIGHT: 4px;VISIBILITY:visible;' border=0 src='Images/Running.gif' width=40 height=40><div id='str" & j & "' style='Z-INDEX:3;LEFT:" & strleft & "px;TOP:9px;VISIBILITY:visible;POSITION:absolute;'><span style='FONT-SIZE: 18pt;COLOR: yellow'><b>" & dev_name & "</b></span></div>"
                        'ElseIf CInt(dtData.DefaultView.Item(i).Item("Status")) = 2 Then
                        '    oRange.Value = "<div id='pic" & j & "' style='Z-INDEX:3;PADDING-LEFT: 4px;PADDING-TOP: 2px;PADDING-BOTTOM: 2px;PADDING-RIGHT: 4px;VISIBILITY:visible;POSITION:relative;'><img border=0 src='Images/Unworkable.gif' width=40 height=40><div id='str" & j & "' style='Z-INDEX:3;LEFT:" & strleft & "px;TOP:9px;VISIBILITY:visible;POSITION:absolute;'><span style='FONT-SIZE: 18pt;COLOR: blue'><b>" & dev_name & "</b></span></div></div>"
                        'ElseIf CInt(dtData.DefaultView.Item(i).Item("Status")) = 3 Then
                        '    oRange.Value = "<div id='pic" & j & "' style='Z-INDEX:3;PADDING-LEFT: 4px;PADDING-TOP: 2px;PADDING-BOTTOM: 2px;PADDING-RIGHT: 4px;VISIBILITY:visible;POSITION:relative;'><img border=0 src='Images/Repairing.gif' width=40 height=40><div id='str" & j & "' style='Z-INDEX:3;LEFT:" & strleft & "px;TOP:9px;VISIBILITY:visible;POSITION:absolute;'><span style='FONT-SIZE: 18pt;COLOR: blue'><b>" & dev_name & "</b></span></div></div>"
                        'End If
                    Next
                    oRange.Value = "<div style='Z-INDEX:3;TEXT-ALIGN: left;PADDING-LEFT: 4px;PADDING-TOP: 0px;PADDING-BOTTOM: 0px;PADDING-RIGHT: 4px;VISIBILITY:visible;POSITION:relative;width:" & (59 * i + 18) & ";height:32;'>" & oRange.Value & "</div>"
                End If
            Next
        Next
    End Function
    '取出车间编号在Shop_Codes运行在Line段的设备的运行状态
    Private Function GetDevLine(ByVal Shop_Codes As String, _
                                ByVal Line As Int16) _
    As DataTable
        Dim strSQL As String = ""
        Dim data As New DataTable
        '给data赋表结构

        data = GetShopDevsByShopCodesLine(Shop_Codes, 10000)

        Dim j, k, l As Integer
        Dim gstatus1, gstatus2, gstatus12, sstatus1, sstatus2, sstatus12 As Short

        Dim dtGlobal As New DataTable
        Dim dtShop As New DataTable
        Dim oAdapter As New SqlDataAdapter("SELECT A.SHOP_CODE,A.SHOP_NAME,A.SHOP_TYPE,A.SWITCH1,A.SWITCH2,A.JOIN12,A.REMARK FROM D_SHOP_SWITCH A WHERE A.SHOP_TYPE = 1 ORDER BY A.SHOP_CODE ", SQLConn)
        oAdapter.Fill(dtGlobal)
        oAdapter.SelectCommand.CommandText = "SELECT A.SHOP_CODE,A.SHOP_NAME,A.SHOP_TYPE,A.SWITCH1,A.SWITCH2,A.JOIN12,A.REMARK FROM D_SHOP_SWITCH A WHERE A.SHOP_CODE IN (" & Shop_Codes.Trim() & ")"
        oAdapter.Fill(dtShop)

        '***********读出各设备工作在哪个段上***********
        '取出总控制开关的状态信息
        If dtGlobal.Rows.Count > 0 Then
            GetSwitchStatus(dtGlobal.Rows(0), gstatus1, gstatus2, gstatus12)
        Else
            gstatus1 = 1
            gstatus2 = 1
            gstatus12 = 0
        End If

        If Line = 1 Then
            '********当前正在读取工作在1段上的设备信息********
            '只有1段总开关闭合时才有设备工作在1段上
            If gstatus1 = 1 Then
                If gstatus12 = 1 And gstatus2 = 0 Then
                    '12段连线开关闭合，2段总控制开关断开时，所有设备都工作在1段上。
                    data = GetShopDevsByShopCodesLine(Shop_Codes)
                ElseIf gstatus12 = 0 Then
                    '12段连线开关断开，1、2段设备分开工作
                    For j = 0 To dtShop.Rows.Count - 1
                        GetSwitchStatus(dtShop.Rows(j), sstatus1, sstatus2, sstatus12)
                        '只有该车间1段开关闭合时才有设备工作在1段上
                        If sstatus1 = 1 Then
                            Dim dt As DataTable
                            If sstatus12 = 1 And sstatus2 = 0 Then
                                '车间级12段连线开关闭合，2段控制开关断开时，该车间的所有设备都工作在1段上。
                                dt = GetShopDevsByShopCodesLine("'" & CStr(dtShop.Rows(j).Item("Shop_Code")) & "'")
                            ElseIf sstatus12 = 0 Then
                                '车间级12段连线开关断开，1、2段设备分开工作
                                dt = GetShopDevsByShopCodesLine("'" & CStr(dtShop.Rows(j).Item("Shop_Code")) & "'", 1)
                            End If
                            For k = 0 To dt.Rows.Count - 1
                                Dim dr As DataRow = data.NewRow
                                For l = 1 To dt.Columns.Count - 1
                                    dr.Item(l) = dt.Rows(k).Item(l)
                                Next
                                data.Rows.Add(dr)
                            Next
                        End If
                    Next
                End If
            End If
        ElseIf Line = 2 Then
            '********当前正在读取工作在2段上的设备信息********
            '只有2段总开关闭合时才有设备工作在2段上
            If gstatus2 = 1 Then
                If gstatus12 = 1 And gstatus1 = 0 Then
                    '12段连线开关闭合，1段总控制开关断开时，所有设备都工作在2段上。
                    data = GetShopDevsByShopCodesLine(Shop_Codes)
                ElseIf gstatus12 = 0 Then
                    '12段连线开关断开，1、2段设备分开工作
                    For j = 0 To dtShop.Rows.Count - 1
                        GetSwitchStatus(dtShop.Rows(j), sstatus1, sstatus2, sstatus12)
                        '只有该车间2段开关闭合时才有设备工作在2段上
                        If sstatus2 = 1 Then
                            Dim dt As DataTable
                            If sstatus12 = 1 And sstatus1 = 0 Then
                                '车间级12段连线开关闭合，1段控制开关断开时，该车间的所有设备都工作在2段上。
                                dt = GetShopDevsByShopCodesLine("'" & CStr(dtShop.Rows(j).Item("Shop_Code")) & "'")
                            ElseIf sstatus12 = 0 Then
                                '车间级12段连线开关断开，1、2段设备分开工作
                                dt = GetShopDevsByShopCodesLine("'" & CStr(dtShop.Rows(j).Item("Shop_Code")) & "'", 2)
                            End If
                            For k = 0 To dt.Rows.Count - 1
                                Dim dr As DataRow = data.NewRow
                                For l = 1 To dt.Columns.Count - 1
                                    dr.Item(l) = dt.Rows(k).Item(l)
                                Next
                                data.Rows.Add(dr)
                            Next
                        End If
                    Next
                End If
            End If
        End If

        '*********读出各设备的运行状态***********
        Dim dev_codes As String = ""
        For j = 0 To data.Rows.Count - 1
            Dim dev_code As String = FilterDBNull(data.Rows(j).Item("Dev_Code"))
            If dev_code <> "" Then
                dev_codes = dev_codes & "'" & dev_code & "',"
            End If
        Next
        Dim dtStatus As New DataTable
        If dev_codes <> "" Then
            '读取最新运行状态
            dev_codes = dev_codes.Substring(0, Len(dev_codes) - 1)
            strSQL = "SELECT A.PKID,A.DEV_CODE,B.DEV_NAME,B.DEV_MODEL,B.DEV_SPEC,B.COM_ARRANGE,B.DEV_SHORT_NAME,A.STATUS,A.BEGIN_TIME,A.END_TIME,A.OPERATOR,A.I_TAG_ID,A.REMARK,A.COM_ARRANGE_TIME,A.ARRANGE_TIME,A.REPORT_TIME FROM D_RUN_STATUS A, D_DEV_ACCOUNT B " & _
                    " WHERE A.DEV_CODE = B.DEV_CODE AND A.DEV_CODE IN (" & dev_codes.Trim & ") AND A.END_TIME IS NULL ORDER BY A.BEGIN_TIME DESC"
            oAdapter.SelectCommand.CommandText = strSQL
            oAdapter.Fill(dtStatus)
        End If
        For j = 0 To data.Rows.Count - 1
            Dim dev_code As String = FilterDBNull(data.Rows(j).Item("Dev_Code"))
            If dev_code <> "" Then
                dtStatus.DefaultView.RowFilter = "DEV_CODE = '" & dev_code & "'"
                If dtStatus.DefaultView.Count >= 1 Then
                    data.Rows(j).Item("Status") = CShort(dtStatus.DefaultView.Item(0).Item("Status"))
                Else
                    data.Rows(j).Item("Status") = 0
                End If
            Else
                '设备缺省的状态是"停止"
                data.Rows(j).Item("Status") = 0
            End If
        Next

        Return data
    End Function
    '取出日期为aDate，由公司布置的设备开停情况
    Private Sub GetSwitchStatus(ByVal aRow As DataRow, _
                                ByRef status1 As Short, _
                                ByRef status2 As Short, _
                                ByRef status12 As Short)
        Dim i As Integer
        Dim sTagIDAll, switch1, switch2, join12 As String

        '设置缺省状态
        status1 = 1
        status2 = 1
        status12 = 0

        switch1 = FilterDBNull(aRow.Item("Switch1"))
        switch2 = FilterDBNull(aRow.Item("Switch2"))
        join12 = FilterDBNull(aRow.Item("Join12"))

        sTagIDAll = ""
        If switch1 <> "" Then
            sTagIDAll = sTagIDAll & "'" & switch1 & "',"
        End If
        If switch2 <> "" Then
            sTagIDAll = sTagIDAll & "'" & switch2 & "',"
        End If
        If join12 <> "" Then
            sTagIDAll = sTagIDAll & "'" & join12 & "',"
        End If
        '去掉最后一个,
        If sTagIDAll <> "" Then
            sTagIDAll = sTagIDAll.Substring(0, Len(sTagIDAll) - 1)
            Dim dtStatusGlobal As New DataTable
            Dim strSQL As String
            strSQL = "SELECT A.PKID,A.STATUS,A.BEGIN_TIME,A.END_TIME,A.OPERATOR,A.I_TAG_ID,A.REMARK,A.COM_ARRANGE_TIME,A.ARRANGE_TIME,A.REPORT_TIME FROM D_RUN_STATUS A " & _
                    " WHERE A.I_TAG_ID IN (" & sTagIDAll.Trim & ") AND A.END_TIME IS NULL ORDER BY A.BEGIN_TIME DESC"
            Dim oAdapter As New SqlDataAdapter(strSQL, SQLConn)
            oAdapter.Fill(dtStatusGlobal)
            oAdapter.Dispose()
            Dim i_tag_id As String
            For i = 0 To dtStatusGlobal.Rows.Count - 1
                i_tag_id = FilterDBNull(dtStatusGlobal.Rows(i).Item("I_Tag_ID"))
                '由于某些原因可能会在D_RUN_STATUS表中一个指标有多行记录,只取第一行为最新的状态
                If switch1 = i_tag_id And status1 = 1 Then
                    status1 = CShort(dtStatusGlobal.Rows(i).Item("Status"))
                End If
                If switch2 = i_tag_id And status2 = 1 Then
                    status2 = CShort(dtStatusGlobal.Rows(i).Item("Status"))
                End If
                If join12 = i_tag_id And status12 = 0 Then
                    status12 = CShort(dtStatusGlobal.Rows(i).Item("Status"))
                End If
            Next
        End If

    End Sub
    ' 查询出Shop_Code车间下工作在Line段上的设备信息，如果没有输入Line，则查询出该车间下的全部设备。
    Private Function GetShopDevsByShopCodesLine(ByVal Shop_Codes As String, _
                                                Optional ByVal Line As Short = -1) _
    As DataTable
        Dim strSQL As String = ""

        strSQL = "  SELECT A.PKID,A.SHOP_CODE,A.SERIAL_NO,A.DEV_CODE,A.DEF_LINE,B.DEV_SHORT_NAME,0 AS STATUS " & _
                "   FROM D_SHOP_DEV A LEFT JOIN D_DEV_ACCOUNT B " & _
                "   ON A.DEV_CODE = B.DEV_CODE " & _
                "   WHERE A.SHOP_CODE IN (" & Shop_Codes.Trim & ") "
        If Line > -1 Then
            strSQL = strSQL & " AND A.DEF_LINE = " & Line
        End If
        strSQL = strSQL & " ORDER BY A.SHOP_CODE,A.SERIAL_NO "
        Dim data As New DataTable
        Dim oAdapter As New SqlDataAdapter(strSQL, SQLConn)
        oAdapter.Fill(data)
        oAdapter.Dispose()
        Return data

    End Function
    '对每个定义的保存区域,保存数据
    '输入
    '1 aDate  保存时间,2  sDateType 时间类型 3 sTagRange 指标区域 4 sSaveRange 要保存的数据区域  5 sTagType 指标类型 6 sTagOrient 时间点排列方向 7 saveInfo 要写到日志中的保存信息
    Private Function pSaveData(ByVal aDate As Date, _
                                ByVal sDateType As String, _
                                ByVal sTagRange As String, _
                                ByVal sSaveRange As String, _
                                ByVal sTagType As String, _
                                ByVal sTagOrient As String, _
                                ByVal username As String, _
                                ByRef saveInfo As String) _
    As Boolean
        '查出用于保存数据的存储过程名
        Dim saveprocname, delprocname As String
        If sTagType.ToUpper = "FLOAT" Then
            '数值指标
            saveprocname = "sp_SaveData"
            delprocname = "sp_DeleteData"
        ElseIf sTagType.ToUpper = "STR" Then
            '字符指标
            saveprocname = "sp_SaveStrTagData"
            delprocname = "sp_DeleteStrTagData"
        Else
            strErrInfo = strErrInfo & "  " & ERRINFO_INSPECTREPORT_005
            Return False
        End If

        Dim nStart, nEnd, nTimeCount, nTagCount, Rows, Cols, i, j As Integer
        Dim sBaseKey, sTagID, curValue, oldValue As String
        '计算起止时间点
        If sTagType.ToUpper = "FLOAT" Or sTagType.ToUpper = "STR" Then
            If Not pCalcCycleID(aDate, sDateType, sBaseKey, nStart, nEnd, nTimeCount) Then
                strErrInfo = strErrInfo & "  " & sDateType & ERRINFO_INSPECTREPORT_006
                Return False
            End If
        End If

        Dim aTagID As System.Array
        Dim aData, oldData, aPKId, aFormula As System.Array
        Dim oSaveCmd, oDelCmd As SqlClient.SqlCommand

        '修改过的指标编号，用“,”隔开
        Dim modtagid As String = ""
        Dim wherestr_func As String = " (1 <> 1) "
        Dim modcycleid(0) As Integer
        modcycleid(0) = -1
        Dim modified As Boolean

        Try
            '该数组的下标从1开始
            If CCData.Range(sTagRange).Rows.Count = 1 And CCData.Range(sTagRange).Columns.Count = 1 Then
                aTagID = CCData.Range("A1:B1").Value
                aTagID(1, 1) = CCData.Range(sTagRange).Value
                aTagID(1, 2) = ""
            Else
                aTagID = CCData.Range(sTagRange).Value
            End If
            If CCData.Range(sSaveRange).Rows.Count = 1 And CCData.Range(sSaveRange).Columns.Count = 1 Then
                aData = CCData.Range("A1:B1").Value
                aData(1, 1) = CCData.Range(sSaveRange).Value
                aData(1, 2) = ""
            Else
                aData = CCData.Range(sSaveRange).Value
            End If
            If oldXMLData.Range(sSaveRange).Rows.Count = 1 And oldXMLData.Range(sSaveRange).Columns.Count = 1 Then
                oldData = oldXMLData.Range("A1:B1").Value
                oldData(1, 1) = oldXMLData.Range(sSaveRange).Value
                oldData(1, 2) = ""
            Else
                oldData = oldXMLData.Range(sSaveRange).Value
            End If
            If CCData.Range(sSaveRange).Rows.Count = 1 And CCData.Range(sSaveRange).Columns.Count = 1 Then
                aFormula = CCData.Range("A1:B1").Formula
                aFormula(1, 1) = CCData.Range(sSaveRange).Formula
                aFormula(1, 2) = ""
            Else
                aFormula = CCData.Range(sSaveRange).Formula
            End If

            '所有要取数据的指标编号，以,隔开
            Dim sTagIDAll As String
            sTagIDAll = ""
            For i = 0 To aTagID.GetLength(0) - 1
                For j = 0 To aTagID.GetLength(1) - 1
                    sTagID = aTagID(i + 1, j + 1)
                    If Not (sTagID Is Nothing) Then
                        If sTagID.Trim() <> "" Then
                            sTagIDAll = sTagIDAll & "'" & sTagID & "',"
                        End If
                    End If
                Next
            Next
            If sTagIDAll <> "" Then
                sTagIDAll = sTagIDAll.Substring(0, Len(sTagIDAll) - 1)
            End If
            Dim dtTag As New DataTable("T_TAG")
            Dim oAdapter As New SqlDataAdapter("select I_TAG_ID,I_TAG_NAME from T_TAG_MS where (I_TAG_ID in ( " & sTagIDAll & ")) ", SQLConn)
            oAdapter.Fill(dtTag)
            Dim oRange As OWC10.Range
            Dim nRowStart, nColStart As Integer
            oRange = CCData.Range(sSaveRange)
            nRowStart = oRange.Row
            nColStart = oRange.Column

            If sTagType.ToUpper = "FLOAT" Or sTagType.ToUpper = "STR" Then
                Dim avalue As Double
                oSaveCmd = New SqlCommand(saveprocname, SQLConn)
                oSaveCmd.CommandType = CommandType.StoredProcedure
                SqlClient.SqlCommandBuilder.DeriveParameters(oSaveCmd)
                oSaveCmd.Prepare()
                oSaveCmd.Parameters("@BASE_KEY").Value = sBaseKey
                '清除数据的过程（格子为空表示删除数据）
                oDelCmd = New SqlCommand(delprocname, SQLConn)
                oDelCmd.CommandType = CommandType.StoredProcedure
                SqlClient.SqlCommandBuilder.DeriveParameters(oDelCmd)
                oDelCmd.Prepare()

                If nTimeCount = 1 Then
                    Rows = CCData.Range(sTagRange).Rows.Count
                    Cols = CCData.Range(sTagRange).Columns.Count
                Else
                    If sTagOrient = "0" Then
                        nTagCount = CCData.Range(sTagRange).Columns.Count
                    Else
                        nTagCount = CCData.Range(sTagRange).Rows.Count
                    End If
                End If

                Dim hasformula As Boolean
                Dim tagname As String
                If nTimeCount = 1 Then
                    '取到保存区域
                    For i = 1 To Rows
                        For j = 1 To Cols
                            '对每个数据进行保存
                            If (Trim("" & aTagID(i, j)) <> "") Then
                                '查询指标名称
                                tagname = ""
                                dtTag.DefaultView.RowFilter = "I_TAG_ID='" & CStr(aTagID(i, j)) & "'"
                                If dtTag.DefaultView.Count > 0 Then
                                    tagname = dtTag.DefaultView.Item(0).Item("I_TAG_NAME")
                                End If
                                '新数据和原来的数据不同才进行保存,*****有公式时必须保存*******
                                '要先转换成string才能进行比较，因为如果其中一个有数值，比较的时候会转换成数字进行比较，而如果另外一个为""，则发生转换错误
                                hasformula = False
                                If CStr(aFormula(i, j)) <> "" Then
                                    If CStr(aFormula(i, j)).Chars(0) = "=" Then
                                        hasformula = True
                                    End If
                                End If
                                If (CStr(aFormula(i, j)) <> "") Or (CStr(aData(i, j)) <> CStr(oldData(i, j))) Then
                                    If Trim(aData(i, j)) <> "" Then
                                        Try
                                            '保存数字型数据时先进行转换，以判断数据输入是否准确。
                                            If sTagType.ToUpper <> "STR" Then
                                                avalue = Double.Parse(Trim(aData(i, j)))
                                            End If
                                            oSaveCmd.Parameters("@I_CYCLE_ID").Value = nEnd
                                            oSaveCmd.Parameters("@I_TAG_ID").Value = aTagID(i, j)
                                            oSaveCmd.Parameters("@I_VALUE_MAN").Value = Trim(aData(i, j))
                                            oSaveCmd.ExecuteNonQuery()
                                        Catch e As Exception
                                            strErrInfo = strErrInfo & "  " & aData(i, j) & ERRINFO_INSPECTREPORT_007
                                        End Try
                                    Else
                                        oDelCmd.Parameters("@I_CYCLE_ID").Value = nEnd
                                        oDelCmd.Parameters("@I_TAG_ID").Value = aTagID(i, j)
                                        oDelCmd.Parameters("@BASE_KEY").Value = sBaseKey
                                        oDelCmd.ExecuteNonQuery()
                                    End If

                                    '如果数值改动了，就写修改日志
                                    If CStr(aData(i, j)) <> CStr(oldData(i, j)) Then
                                        saveInfo = saveInfo + ControlChars.NewLine + "   " + tagname + "[" + CStr(aTagID(i, j)) + "] " + pCalcDateTimeStr(nEnd, sBaseKey) + " 的数据从 (" + CStr(oldData(i, j)) + ") 改成 (" + CStr(aData(i, j)) + ")"
                                        oRange = CType(oldXMLData.Cells._Default(i - 1 + nRowStart, j - 1 + nColStart), OWC10.Range)
                                        oRange.Locked = False
                                        oRange.Interior.Color = "#EEE8AA"
                                    End If
                                    '记录被修改的信息
                                    modtagid = modtagid + "'" + CStr(aTagID(i, j)) + "',"
                                    wherestr_func = wherestr_func + " OR (FUNC LIKE '%" + CStr(aTagID(i, j)) + "%')"
                                    ReDim Preserve modcycleid(modcycleid.GetLength(0))
                                    modcycleid(modcycleid.GetUpperBound(0)) = nEnd
                                End If
                            End If
                        Next
                    Next
                Else
                    '取到保存区域
                    For j = 1 To nTagCount
                        If sTagOrient = "0" Then
                            sTagID = "" & aTagID(1, j)
                        Else
                            sTagID = "" & aTagID(j, 1)
                        End If
                        If sTagID.Trim <> "" Then
                            modified = False
                            '查询指标名称
                            tagname = ""
                            dtTag.DefaultView.RowFilter = "I_TAG_ID='" & sTagID.Trim & "'"
                            If dtTag.DefaultView.Count > 0 Then
                                tagname = dtTag.DefaultView.Item(0).Item("I_TAG_NAME")
                            End If
                            For i = 1 To nTimeCount
                                hasformula = False
                                If sTagOrient = "0" Then
                                    '从上往下
                                    curValue = CStr(aData(i, j))
                                    oldValue = CStr(oldData(i, j))
                                    If CStr(aFormula(i, j)) <> "" Then
                                        If CStr(aFormula(i, j)).Chars(0) = "=" Then
                                            hasformula = True
                                        End If
                                    End If
                                    oRange = CType(oldXMLData.Cells._Default(i + nRowStart - 1, j + nColStart - 1), OWC10.Range)
                                Else
                                    '从左往右
                                    curValue = CStr(aData(j, i))
                                    oldValue = CStr(oldData(j, i))
                                    If CStr(aFormula(j, i)) <> "" Then
                                        If CStr(aFormula(j, i)).Chars(0) = "=" Then
                                            hasformula = True
                                        End If
                                    End If
                                    oRange = CType(oldXMLData.Cells._Default(j + nRowStart - 1, i + nColStart - 1), OWC10.Range)
                                End If
                                '*****有公式时必须保存*******,新数据和原来的数据不同才进行保存
                                If hasformula Or (curValue <> oldValue) Then
                                    '计算当前的I_CYCLE_ID
                                    Dim cur_cycle_id As Integer
                                    If sBaseKey = "DAY" Then
                                        Dim startday As Date
                                        Dim str As String = nStart.ToString
                                        startday = CDate(str.Substring(0, 4) + "-" + str.Substring(4, 2) + "-" + str.Substring(6, 2))
                                        cur_cycle_id = CInt(startday.AddDays(i - 1).ToString("yyyyMMdd"))
                                    ElseIf sBaseKey = "MONTH" Then
                                        Dim startday As Date
                                        Dim str As String = nStart.ToString
                                        startday = CDate(str.Substring(0, 4) + "-" + str.Substring(4, 2) + "-01")
                                        cur_cycle_id = startday.AddMonths(i - 1).ToString("yyyyMM")
                                    Else
                                        cur_cycle_id = nStart + i - 1
                                    End If
                                    If Trim(curValue) <> "" Then
                                        Try
                                            '保存数字型数据时先进行转换，以判断数据输入是否准确。
                                            If sTagType.ToUpper <> "STR" Then
                                                avalue = Double.Parse(Trim(curValue))
                                            End If
                                            oSaveCmd.Parameters("@I_CYCLE_ID").Value = cur_cycle_id
                                            oSaveCmd.Parameters("@I_TAG_ID").Value = sTagID
                                            oSaveCmd.Parameters("@I_VALUE_MAN").Value = Trim(curValue)
                                            oSaveCmd.ExecuteNonQuery()
                                        Catch e As Exception
                                            strErrInfo = strErrInfo & "  " & curValue & ERRINFO_INSPECTREPORT_007
                                        End Try
                                    Else
                                        oDelCmd.Parameters("@I_CYCLE_ID").Value = cur_cycle_id
                                        oDelCmd.Parameters("@I_TAG_ID").Value = sTagID
                                        oDelCmd.Parameters("@BASE_KEY").Value = sBaseKey
                                        oDelCmd.ExecuteNonQuery()
                                    End If
                                    '如果数值改动了，就写修改日志
                                    modified = True
                                    If curValue <> oldValue Then
                                        saveInfo = saveInfo + ControlChars.NewLine + "   " + tagname + "[" + sTagID + "] " + pCalcDateTimeStr(cur_cycle_id, sBaseKey) + " 的数据从 (" + oldValue + ") 改成 (" + curValue + ")"
                                        oRange.Locked = False
                                        oRange.Interior.Color = "#EEE8AA"
                                    End If
                                    ReDim Preserve modcycleid(modcycleid.GetLength(0))
                                    modcycleid(modcycleid.GetUpperBound(0)) = nStart + i - 1
                                End If
                            Next
                            '记录被修改的指标编号
                            modtagid = modtagid + "'" + sTagID + "',"
                            wherestr_func = wherestr_func + " OR (FUNC LIKE '%" + sTagID + "%')"
                        End If
                    Next
                End If

            End If

            '重算数据
            Dim calcres As String
            If modtagid <> "'" And modtagid <> "" Then
                '去掉最后一个“,”,在加上'
                modtagid = modtagid.Substring(0, modtagid.Length - 1)
                Dim objlog As New ApplicationLog
                objlog.WriteInfo("开始重算")
                Dim reCalcCmd As SqlClient.SqlCommand

                '重算合成指标
                Dim comTagTable As Data.DataTable
                Dim comTagAdapter As SqlClient.SqlDataAdapter
                comTagTable = New Data.DataTable("COMTAG")
                '查询出公式中含有修改过指标的小时、天、月、年合成指标
                comTagAdapter = New SqlClient.SqlDataAdapter("SELECT I_TAG_ID FROM T_TAG_MS WHERE ((I_TAG_TYPE = '121') OR (I_TAG_TYPE = '122') OR (I_TAG_TYPE = '123') OR (I_TAG_TYPE = '124')) AND (" + wherestr_func + ")", SQLConn)
                comTagAdapter.Fill(comTagTable)
                If comTagTable.Rows.Count > 0 Then
                    Try
                        Dim comtagid As String = ""
                        For i = 1 To comTagTable.Rows.Count
                            comtagid = comtagid + "'" + comTagTable.Rows(i - 1).Item("I_TAG_ID") + "',"
                        Next
                        comtagid = comtagid.Substring(0, comtagid.Length - 1)
                        '重算日报、月报、年报时要把涉及到的合成指标也相应的重算一次(要把头尾的'去掉)
                        modtagid = modtagid + "," + comtagid

                        reCalcCmd = New SqlCommand("sp_CalcComTag", SQLConn)
                        reCalcCmd.CommandType = CommandType.StoredProcedure
                        reCalcCmd.CommandTimeout = 7200
                        reCalcCmd.Parameters.Add("@BASE_KEY", SqlDbType.NVarChar)
                        reCalcCmd.Parameters("@BASE_KEY").Direction = ParameterDirection.Input
                        reCalcCmd.Parameters("@BASE_KEY").Value = sBaseKey

                        reCalcCmd.Parameters.Add("@StartTime", SqlDbType.NVarChar)
                        reCalcCmd.Parameters("@StartTime").Direction = ParameterDirection.Input

                        reCalcCmd.Parameters.Add("@TOTAL", SqlDbType.Int)
                        reCalcCmd.Parameters("@TOTAL").Direction = ParameterDirection.Input
                        reCalcCmd.Parameters("@TOTAL").Value = 1

                        reCalcCmd.Parameters.Add("@TAG", SqlDbType.NVarChar)
                        reCalcCmd.Parameters("@TAG").Direction = ParameterDirection.Input
                        reCalcCmd.Parameters("@TAG").Value = comtagid

                        For i = 1 To modcycleid.GetUpperBound(0)
                            reCalcCmd.Parameters("@StartTime").Value = pCalcStartTimeStr(modcycleid(i), sBaseKey)
                            reCalcCmd.ExecuteNonQuery()
                        Next
                        objlog.WriteInfo("合成指标重算完成")
                    Catch ex As Exception
                        '此处有被0除错误，写到日志上太多了
                        objlog.WriteInfo("合成指标重算出错：")
                    Finally
                        If Not reCalcCmd Is Nothing Then
                            reCalcCmd.Dispose()
                        End If
                    End Try
                End If
                '当修改了昨天及以前的小时数据时要重算该日的日报数据
                If sBaseKey = "HOUR" And aDate < Now.Date Then
                    Try
                        reCalcCmd = New SqlCommand("sp_HourToDay", SQLConn)
                        reCalcCmd.CommandType = CommandType.StoredProcedure
                        reCalcCmd.CommandTimeout = 7200
                        reCalcCmd.Parameters.Add("@StartTime", SqlDbType.NVarChar)
                        reCalcCmd.Parameters("@StartTime").Direction = ParameterDirection.Input
                        reCalcCmd.Parameters("@StartTime").Value = Format(aDate, "yyyy-MM-dd")

                        reCalcCmd.Parameters.Add("@TOTAL", SqlDbType.Int)
                        reCalcCmd.Parameters("@TOTAL").Direction = ParameterDirection.Input
                        reCalcCmd.Parameters("@TOTAL").Value = 1

                        reCalcCmd.Parameters.Add("@TAG", SqlDbType.NVarChar)
                        reCalcCmd.Parameters("@TAG").Direction = ParameterDirection.Input
                        reCalcCmd.Parameters("@TAG").Value = modtagid

                        reCalcCmd.ExecuteNonQuery()
                        objlog.WriteInfo(Format(aDate, "yyyy-MM-dd") + "日报重算完成")
                    Catch ex As Exception
                        objlog.WriteInfo(Format(aDate, "yyyy-MM-dd") + "日报重算出错：" + ex.Message + " 修改的指标： " + modtagid)
                    Finally
                        If Not reCalcCmd Is Nothing Then
                            reCalcCmd.Dispose()
                        End If
                    End Try
                End If
                '当修改了上个月及以前的小时或日数据时要重算该月的月报数据
                If (sBaseKey = "HOUR" Or sBaseKey = "DAY") And aDate.Month < Now.Month Then
                    Try
                        reCalcCmd = New SqlCommand("sp_DayToMonth", SQLConn)
                        reCalcCmd.CommandType = CommandType.StoredProcedure
                        reCalcCmd.CommandTimeout = 7200
                        reCalcCmd.Parameters.Add("@StartTime", SqlDbType.NVarChar)
                        reCalcCmd.Parameters("@StartTime").Direction = ParameterDirection.Input
                        reCalcCmd.Parameters("@StartTime").Value = Format(aDate, "yyyyMM")

                        reCalcCmd.Parameters.Add("@TAG", SqlDbType.NVarChar)
                        reCalcCmd.Parameters("@TAG").Direction = ParameterDirection.Input
                        reCalcCmd.Parameters("@TAG").Value = modtagid

                        reCalcCmd.ExecuteNonQuery()
                        objlog.WriteInfo(Format(aDate, "yyyyMM") + "月报重算完成")
                    Catch ex As Exception
                        objlog.WriteInfo(Format(aDate, "yyyyMM") + "月报重算出错：" + ex.Message)
                    Finally
                        If Not reCalcCmd Is Nothing Then
                            reCalcCmd.Dispose()
                        End If
                    End Try
                End If
                '当修改了去年及以前的小时或日或年数据时要重算该年的年报数据
                If (sBaseKey = "HOUR" Or sBaseKey = "DAY" Or sBaseKey = "MONTH") And aDate.Year < Now.Year Then
                    Try
                        reCalcCmd = New SqlCommand("sp_MonthToYear", SQLConn)
                        reCalcCmd.CommandType = CommandType.StoredProcedure
                        reCalcCmd.CommandTimeout = 7200
                        reCalcCmd.Parameters.Add("@StartTime", SqlDbType.NVarChar)
                        reCalcCmd.Parameters("@StartTime").Direction = ParameterDirection.Input
                        reCalcCmd.Parameters("@StartTime").Value = Format(aDate, "yyyy")

                        reCalcCmd.Parameters.Add("@TAG", SqlDbType.NVarChar)
                        reCalcCmd.Parameters("@TAG").Direction = ParameterDirection.Input
                        reCalcCmd.Parameters("@TAG").Value = modtagid

                        reCalcCmd.ExecuteNonQuery()
                        objlog.WriteInfo(aDate.Year.ToString + "年报重算完成")
                    Catch ex As Exception
                        objlog.WriteInfo(aDate.Year.ToString + "年报重算出错：" + ex.Message)
                    Finally
                        If Not reCalcCmd Is Nothing Then
                            reCalcCmd.Dispose()
                        End If
                    End Try
                End If

            End If

            Return True
        Catch er As Exception
            'strErrInfo = strErrInfo & "  " & er.Message
            strErrInfo = strErrInfo & "  " & er.ToString()
            Return False
        Finally
            '释放资源
            If Not oSaveCmd Is Nothing Then
                oSaveCmd.Dispose()
            End If
            If Not oDelCmd Is Nothing Then
                oDelCmd.Dispose()
            End If
        End Try

    End Function
    '查询出报表的最后一次状态:-1 没找到, 1 修改, 2 确认, 3 取消
    Public Function GetLastOperate(ByVal Report_Code As String, _
                                    ByVal aDate As Date) _
    As Short
        Dim dttype As New DataTable("T_REPORT_TYPE")
        Dim dt As New DataTable("T_LAST_STATE")
        Dim sda As SqlDataAdapter
        Dim cycle_type As String = ""
        Dim cycle_id As Integer = -1
        sda = New SqlDataAdapter("select I_CYCLE_TYPE from T_SCHEMA_MS Where I_SCHEMA_ID = '" & Report_Code.Trim & "'", SQLConn)
        sda.Fill(dttype)
        If dttype.Rows.Count = 0 Then
            Return -1
        Else
            cycle_type = FilterDBNull(dttype.Rows(0).Item("I_CYCLE_TYPE"))
        End If
        If cycle_type.ToUpper = "DAY" Then
            cycle_id = CInt(Format(aDate, "yyyyMMdd"))
        ElseIf cycle_type.ToUpper = "MONTH" Then
            cycle_id = CInt(Format(aDate, "yyyyMM"))
        ElseIf cycle_type.ToUpper = "YEAR" Then
            cycle_id = CInt(Format(aDate, "yyyy"))
        Else
            Return -1
        End If

        sda.SelectCommand.CommandText = "select TOP 1 OPERATE_TYPE from T_OPERATE_INFO Where REPORT_CODE='" & Report_Code.Trim & "' and I_CYCLE_ID = " & cycle_id & " ORDER BY OPERATE_TIME DESC"
        sda.Fill(dt)
        If dt.Rows.Count = 0 Then
            Return -1
        Else
            Return dt.Rows(0).Item("OPERATE_TYPE")
        End If

    End Function
    '查询报表的操作记录
    Public Function GetOperateInfo(ByVal Report_Code As String, ByVal aDate As Date) As DataTable
        Dim dttype As New DataTable("T_REPORT_TYPE")
        Dim dt As New DataTable("T_Operate_Info")
        Dim sda As SqlDataAdapter
        Dim cycle_type As String = ""
        Dim cycle_id As Integer = -1
        sda = New SqlDataAdapter("select I_CYCLE_TYPE from T_SCHEMA_MS Where I_SCHEMA_ID = '" & Report_Code.Trim & "'", SQLConn)
        sda.Fill(dttype)
        If dttype.Rows.Count = 0 Then
            Return dt
        Else
            cycle_type = FilterDBNull(dttype.Rows(0).Item("I_CYCLE_TYPE"))
        End If

        If cycle_type.ToUpper = "DAY" Then
            cycle_id = CInt(Format(aDate, "yyyyMMdd"))
        ElseIf cycle_type.ToUpper = "MONTH" Then
            cycle_id = CInt(Format(aDate, "yyyyMM"))
        ElseIf cycle_type.ToUpper = "YEAR" Then
            cycle_id = CInt(Format(aDate, "yyyy"))
        Else
            Return dt
        End If

        sda.SelectCommand.CommandText = "select PKID, OPERATE_TIME, OPERATOR_CODE, OPERATOR_NAME, OPERATOR_IP, OPERATE_TYPE, MODIFY_INFO, OLD_XML from T_OPERATE_INFO Where REPORT_CODE='" & Report_Code.Trim & "' and I_CYCLE_ID = " & cycle_id & " ORDER BY OPERATE_TIME"
        sda.Fill(dt)
        Return dt

    End Function
    '增加报表的操作记录
    Public Function AddOperateInfo(ByVal Operate_Code As String, _
                                    ByVal Operate_Name As String, _
                                    ByVal Operate_IP As String, _
                                    ByVal Report_Code As String, _
                                    ByVal Operate_Type As Short, _
                                    ByVal aDate As Date, _
                                    ByVal Modify_Info As String, _
                                    ByVal Old_XML As String) As Boolean
        Dim dttype As New DataTable("T_REPORT_TYPE")
        Dim dt As New DataTable("T_Operate_Info")
        Dim sda As SqlDataAdapter
        Dim cycle_type As String = ""
        Dim cycle_id As Integer = -1
        If SQLConn.State <> ConnectionState.Open Then
            SQLConn.Open()
        End If
        sda = New SqlDataAdapter("select I_CYCLE_TYPE from T_SCHEMA_MS Where I_SCHEMA_ID = '" & Report_Code.Trim & "'", SQLConn)
        sda.Fill(dttype)
        If dttype.Rows.Count = 0 Then
            Return False
        Else
            cycle_type = FilterDBNull(dttype.Rows(0).Item("I_CYCLE_TYPE"))
        End If

        If cycle_type.ToUpper = "DAY" Then
            cycle_id = CInt(Format(aDate, "yyyyMMdd"))
        ElseIf cycle_type.ToUpper = "MONTH" Then
            cycle_id = CInt(Format(aDate, "yyyyMM"))
        ElseIf cycle_type.ToUpper = "YEAR" Then
            cycle_id = CInt(Format(aDate, "yyyy"))
        Else
            Return False
        End If

        Try
            sda.SelectCommand.CommandText = "INSERT INTO T_OPERATE_INFO (OPERATE_TIME, OPERATOR_CODE, OPERATOR_NAME, OPERATOR_IP, REPORT_CODE, OPERATE_TYPE, I_CYCLE_ID, MODIFY_INFO, OLD_XML) VALUES(@OPERATE_TIME, @OPERATOR_CODE, @OPERATOR_NAME, @OPERATOR_IP, @REPORT_CODE, @OPERATE_TYPE, @I_CYCLE_ID, @MODIFY_INFO, @OLD_XML)"
            With sda.SelectCommand.Parameters
                .Add(New SqlParameter("@OPERATE_TIME", SqlDbType.DateTime))
                .Add(New SqlParameter("@OPERATOR_CODE", SqlDbType.VarChar, 20))
                .Add(New SqlParameter("@OPERATOR_NAME", SqlDbType.VarChar, 50))
                .Add(New SqlParameter("@OPERATOR_IP", SqlDbType.VarChar, 20))
                .Add(New SqlParameter("@REPORT_CODE", SqlDbType.VarChar, 20))
                .Add(New SqlParameter("@OPERATE_TYPE", SqlDbType.SmallInt))
                .Add(New SqlParameter("@I_CYCLE_ID", SqlDbType.Int))
                .Add(New SqlParameter("@MODIFY_INFO", SqlDbType.Text))
                .Add(New SqlParameter("@OLD_XML", SqlDbType.Text))

                .Item("@OPERATE_TIME").Value = Now
                .Item("@OPERATOR_CODE").Value = Operate_Code
                .Item("@OPERATOR_NAME").Value = Operate_Name
                .Item("@OPERATOR_IP").Value = Operate_IP
                .Item("@REPORT_CODE").Value = Report_Code
                .Item("@OPERATE_TYPE").Value = Operate_Type
                .Item("@I_CYCLE_ID").Value = cycle_id
                .Item("@MODIFY_INFO").Value = Modify_Info
                .Item("@OLD_XML").Value = Old_XML
            End With
            If sda.SelectCommand.ExecuteNonQuery() > 0 Then
                Return True
            Else
                Return False
            End If
        Catch er As Exception
            strErrInfo = " 插入操作信息出错: " & er.Message
            Return False
        End Try

    End Function
    '查询报表的操作记录
    Public Function GetOldSchema(ByVal PKID As Decimal) As String
        Dim dt As New DataTable("T_Operate_Info")
        Dim sda As SqlDataAdapter
        sda = New SqlDataAdapter("select OLD_XML from T_OPERATE_INFO Where PKID = '" & PKID & "'", SQLConn)
        sda.Fill(dt)
        If dt.Rows.Count = 0 Then
            Return ""
        Else
            Return FilterDBNull(dt.Rows(0).Item("OLD_XML"))
        End If

    End Function
    '根据报表类型sDateType查询表T_DATE_MS，查出表名参数sBaseKey，然后结合当前报表时间aDate，
    '计算出该报表要统计的开始时间点nStart，结束时间点nEnd，及时间点数。
    Private Function pCalcCycleID(ByVal aDate As DateTime, _
                                  ByVal sDateType As String, _
                                  ByRef sBaseKey As String, _
                                  ByRef nStart As Integer, _
                                  ByRef nEnd As Integer, _
                                  ByRef nTimeCount As Integer) _
    As Boolean
        Dim dtDateType As DataTable
        Dim oData As SqlDataAdapter
        oData = New SqlDataAdapter("select * from T_DATE_MS Where I_DATE_KEY='" & sDateType & "'", SQLConn)
        dtDateType = New DataTable("T_DATE_MS")
        oData.Fill(dtDateType)
        If dtDateType.Rows.Count = 0 Then
            Return False
        End If

        sBaseKey = dtDateType.Rows(0).Item("I_BASE_KEY")
        '时间点数，如果为I_COUNT为0，则自动算，否则为该值（对于季度报表，时间点数应该为1，如果直接用nEnd - nStart，则为3）
        nTimeCount = dtDateType.Rows(0).Item("I_COUNT")

        Select Case sBaseKey.ToUpper
            Case "MIN15"
               
            Case "HOUR"
                '在T_TAG_HOUR表中当前小时数以从2002/01/01开始的小时数的形式存放，
                '如果字段I_START为-100，则开始小时为该日所在月份的第一个小时；
                '如果字段I_START为-200,则开始小时为该日所在年份的第一个小时;
                '如果字段I_START<=0，则开始小时为该时的前I_START小时；如果I_START为其他值，则开始小时为该日的第I_START小时。
                '如果字段I_END为-100，则结束小时为该日所在月份的最后一个小时；
                '如果字段I_END为0，则结束小时为该时的前I_END小时1；如果字段I_END为其他值，则结束小时为该日的第I_END小时；
                '对于夜班，结束时间为第二天的早上，所以要把结束时间加上24。
                nStart = dtDateType.Rows(0).Item("I_START")
                If nStart = -100 Then
                    nStart = (DateDiff(DateInterval.Day, BaseDate, aDate) - aDate.Day + 1) * 24 + 1
                ElseIf nStart = -200 Then '开始小时为该日所在年份的第一个小时.
                    nStart = (DateDiff(DateInterval.Day, BaseDate, aDate) - aDate.DayOfYear + 1) * 24 + 1
                ElseIf nStart = -300 Then '开始小时为该日所在年份的第一个小时.
                    Select Case aDate.Month
                        Case 1, 2, 3
                            nStart = (DateDiff(DateInterval.Day, BaseDate, aDate) - New DateTime(aDate.Year, 1, 1).DayOfYear + 1) * 24 + 1
                        Case 4, 5, 6
                            nStart = (DateDiff(DateInterval.Day, BaseDate, aDate) - New DateTime(aDate.Year, 4, 1).DayOfYear + 1) * 24 + 1
                        Case 7, 8, 9
                            nStart = (DateDiff(DateInterval.Day, BaseDate, aDate) - New DateTime(aDate.Year, 7, 1).DayOfYear + 1) * 24 + 1
                        Case 10, 11, 12
                            nStart = (DateDiff(DateInterval.Day, BaseDate, aDate) - New DateTime(aDate.Year, 10, 1).DayOfYear + 1) * 24 + 1
                    End Select
                Else
                    If nStart <= 0 Then
                        nStart = aDate.Hour + nStart
                    End If
                    nStart = DateDiff(DateInterval.Day, BaseDate, aDate) * 24 + nStart
                End If
                nEnd = dtDateType.Rows(0).Item("I_END")

                If nEnd = -100 Then '该日所在月份的最后一个小时.
                    nEnd = (DateDiff(DateInterval.Day, BaseDate, aDate) - aDate.Day + 1 + DateTime.DaysInMonth(aDate.Year, aDate.Month)) * 24 + 1
                Else
                    If nEnd <= 0 Then
                        nEnd = aDate.Hour + nEnd
                    End If
                    nEnd = DateDiff(DateInterval.Day, BaseDate, aDate) * 24 + nEnd
                End If

                If nEnd < nStart Then
                    nEnd = nEnd + 24
                End If
            Case "DAY"
                '在T_TAG_DAY表中当前天数以yyyyMMdd的形式存放，
                '如果字段I_START为-200，则开始日期为该日所在年份的第一天；
                '如果字段I_START<=0，则开始日期为该日的前I_START天；如果I_START为其他值，则开始日期为该日所在月份的第I_START天。
                '如果字段I_END<=0，则结束日期为该日的前I_END天；如果字段I_END为-100，则结束日期为该日所在月份的最后一天；
                '如果字段I_END为-200，则结束日期为该日所在年份的最后一天；
                '如果I_END为其他值，则结束日期为该日所在月份的第I_END天。
                nStart = dtDateType.Rows(0).Item("I_START")
                If nStart = -200 Then
                    nStart = aDate.Year * 10000 + 101
                    If DateTime.IsLeapYear(aDate.Year) Then
                        nTimeCount = 366
                    Else
                        nTimeCount = 365
                    End If
                ElseIf nStart = -300 Then '该日所在季度的第一天.
                    Select Case aDate.Month
                        Case 1, 2, 3
                            nStart = aDate.Year * 10000 + 101
                        Case 4, 5, 6
                            nStart = aDate.Year * 10000 + 401
                        Case 7, 8, 9
                            nStart = aDate.Year * 10000 + 701
                        Case 10, 11, 12
                            nStart = aDate.Year * 10000 + 1001
                    End Select
                ElseIf nStart > 0 Then
                    nStart = aDate.Year * 10000 + aDate.Month * 100 + nStart
                Else
                    nStart = CInt(Format(aDate.AddDays(nStart), "yyyyMMdd"))
                End If
                nEnd = dtDateType.Rows(0).Item("I_END")
                If nEnd = -100 Then
                    nEnd = aDate.Year * 10000 + aDate.Month * 100 + DateTime.DaysInMonth(aDate.Year, aDate.Month)
                ElseIf nEnd = -200 Then
                    nEnd = aDate.Year * 10000 + 1231
                ElseIf nEnd > 0 Then
                    nEnd = aDate.Year * 10000 + aDate.Month * 100 + nEnd
                Else
                    nEnd = CInt(Format(aDate.AddDays(nEnd), "yyyyMMdd"))
                End If
            Case "DAY_L"    '上个月的日报表
                '在T_TAG_DAY表中当前天数以yyyyMMdd的形式存放，
                '如果字段I_START<=0，则开始日期为该日的前I_START天；如果I_START为其他值，则开始日期为该日所在月份的第I_START天。
                '如果字段I_END<=0，则结束日期为该日的前I_END天；如果字段I_END为-100，则结束日期为该日所在月份的最后一天；
                '如果I_END为其他值，则结束日期为该日所在月份的第I_END天。
                Dim lastday As DateTime
                sBaseKey = "DAY"
                lastday = aDate.AddMonths(-1)
                nStart = dtDateType.Rows(0).Item("I_START")
                If nStart > 0 Then
                    nStart = lastday.Year * 10000 + lastday.Month * 100 + nStart
                Else
                    nStart = CInt(Format(lastday.AddDays(nStart), "yyyyMMdd"))
                End If
                nEnd = dtDateType.Rows(0).Item("I_END")
                If nEnd = -100 Then
                    nEnd = lastday.Year * 10000 + lastday.Month * 100 + DateTime.DaysInMonth(lastday.Year, lastday.Month)
                ElseIf nEnd > 0 Then
                    nEnd = lastday.Year * 10000 + lastday.Month * 100 + nEnd
                Else
                    nEnd = CInt(Format(lastday.AddDays(nEnd), "yyyyMMdd"))
                End If
            Case "WEEK" '周报表，数据存在天表T_TAG_DAY中（由于中国的周是从周一开始，而电脑上的周是从周日开始，所以要注意开始日期）
                '在T_TAG_DAY表中当前天数以yyyyMMdd的形式存放，
                '如果字段I_START<=0，则开始日期为该日的前I_START天；如果I_START为其他值，则开始日期为该日所在星期的第I_START天。
                '如果字段I_END<=0，则结束日期为该日的前I_END天；如果I_END为其他值，则结束日期为该日所在月份的第I_END天。
                sBaseKey = "DAY"
                nStart = dtDateType.Rows(0).Item("I_START")
                Dim firstdate As DateTime '本周的第一天：周日
                firstdate = aDate.AddDays(-aDate.DayOfWeek())
                If nStart > 0 Then
                    nStart = CInt(Format(firstdate.AddDays(nStart), "yyyyMMdd")) '该周的第I_START天
                Else
                    nStart = CInt(Format(aDate.AddDays(nStart), "yyyyMMdd"))
                End If
                nEnd = dtDateType.Rows(0).Item("I_END")
                If nEnd > 0 Then
                    nEnd = CInt(Format(firstdate.AddDays(nEnd), "yyyyMMdd")) '该周的第nEnd天
                Else
                    nEnd = CInt(Format(aDate.AddDays(nEnd), "yyyyMMdd"))
                End If
            Case "WEEK_L" '上周报表，数据存在天表T_TAG_DAY中
                '在T_TAG_DAY表中当前天数以yyyyMMdd的形式存放，
                '如果字段I_START<=0，则开始日期为该日的前I_START天；如果I_START为其他值，则开始日期为该日所在星期的第I_START天。
                '如果字段I_END<=0，则结束日期为该日的前I_END天；如果I_END为其他值，则结束日期为该日所在月份的第I_END天。
                sBaseKey = "DAY"
                nStart = dtDateType.Rows(0).Item("I_START")
                Dim firstdate As DateTime '上周的第一天：周日
                firstdate = aDate.AddDays(-aDate.DayOfWeek() - 7)
                If nStart > 0 Then
                    nStart = CInt(Format(firstdate.AddDays(nStart), "yyyyMMdd")) '上周的第I_START天
                Else
                    nStart = CInt(Format(aDate.AddDays(nStart - 7), "yyyyMMdd"))
                End If
                nEnd = dtDateType.Rows(0).Item("I_END")
                If nEnd > 0 Then
                    nEnd = CInt(Format(firstdate.AddDays(nEnd), "yyyyMMdd")) '上周的第nEnd天
                Else
                    nEnd = CInt(Format(aDate.AddDays(nEnd - 7), "yyyyMMdd"))
                End If
            Case "MONTH"
                '在T_TAG_MONTH表中当前月数以yyyyMM的形式存放，
                '如果字段I_START<=0，则开始月份为该日所在的月份的前I_START个月；如果I_START为其他值，则开始日期为该日所在年份的第I_START月。
                '如果字段I_END<=0，则结束日期为该日所在的月份的前I_END个月；如果I_END为其他值，则结束日期为该日所在年份的第I_END月。
                nStart = dtDateType.Rows(0).Item("I_START")
                If nStart > 0 Then
                    nStart = aDate.Year * 100 + nStart
                Else
                    nStart = CInt(Format(aDate.AddMonths(nStart), "yyyyMM"))
                End If
                nEnd = dtDateType.Rows(0).Item("I_END")
                If nEnd > 0 Then
                    nEnd = aDate.Year * 100 + nEnd
                Else
                    nEnd = CInt(Format(aDate.AddMonths(nEnd), "yyyyMM"))
                End If
            Case "MONTH_L"   '去年的月报表数据
                '在T_TAG_MONTH表中当前月数以yyyyMM的形式存放，
                '如果字段I_START<=0，则开始月份为去年该日所在的月份的前I_START个月；如果I_START为其他值，则开始日期为去年该日所在年份的第I_START月。
                '如果字段I_END<=0，则结束日期为去年该日所在的月份的前I_END个月；如果I_END为其他值，则结束日期为去年该日所在年份的第I_END月。
                sBaseKey = "MONTH"
                nStart = dtDateType.Rows(0).Item("I_START")
                If nStart > 0 Then
                    nStart = (aDate.Year - 1) * 100 + nStart
                Else
                    nStart = CInt(Format(aDate.AddYears(-1).AddMonths(nStart), "yyyyMM"))
                End If
                nEnd = dtDateType.Rows(0).Item("I_END")
                If nEnd > 0 Then
                    nEnd = (aDate.Year - 1) * 100 + nEnd
                Else
                    nEnd = CInt(Format(aDate.AddYears(-1).AddMonths(nEnd), "yyyyMM"))
                End If
            Case "YEAR"
                '在T_TAG_YEAR表中当前年数以yyyy的形式存放，
                '开始年份为该日所在的年份+I_START，结束年份为该日所在的年份+I_END。
                nStart = aDate.Year + dtDateType.Rows(0).Item("I_START")
                nEnd = aDate.Year + dtDateType.Rows(0).Item("I_END")
        End Select
        If nTimeCount = 0 Then
            nTimeCount = nEnd - nStart + 1
        End If
        dtDateType.Dispose()
        Return True
    End Function
    '计算自定义函数.
    Private Function pCalcFunc(ByVal aFunc As String, ByVal aDate As DateTime) As String
        Dim resstr, weekstr As String

        Select Case aDate.DayOfWeek
            Case DayOfWeek.Monday : weekstr = "一"
            Case DayOfWeek.Tuesday : weekstr = "二"
            Case DayOfWeek.Wednesday : weekstr = "三"
            Case DayOfWeek.Thursday : weekstr = "四"
            Case DayOfWeek.Friday : weekstr = "五"
            Case DayOfWeek.Saturday : weekstr = "六"
            Case DayOfWeek.Sunday : weekstr = "日"
        End Select
        Dim i As Integer = aFunc.IndexOf("&")
        If i > 0 Then
            resstr = aFunc.Substring(0, i) + aFunc.Substring(i + 1)
        Else
            resstr = aFunc.Substring(1)
        End If
        '转换长日期
        resstr = resstr.Replace("[yyyy]", Format(aDate, "yyyy"))
        resstr = resstr.Replace("[MM]", Format(aDate, "MM"))
        resstr = resstr.Replace("[dd]", Format(aDate, "dd"))
        '转换短日期
        resstr = resstr.Replace("[yy]", Format(aDate, "yy"))
        resstr = resstr.Replace("[M]", Format(aDate, "%M"))
        resstr = resstr.Replace("[d]", Format(aDate, "%d"))
        '转换星期
        resstr = resstr.Replace("[w]", weekstr)
        Dim firstdate As DateTime '本周的第一天：周日
        firstdate = aDate.AddDays(-aDate.DayOfWeek())
        '中国的星期：周一--周日
        '星期一的日期
        resstr = resstr.Replace("[w1yyyy]", Format(firstdate.AddDays(1), "yyyy"))
        resstr = resstr.Replace("[w1MM]", Format(firstdate.AddDays(1), "MM"))
        resstr = resstr.Replace("[w1dd]", Format(firstdate.AddDays(1), "dd"))
        resstr = resstr.Replace("[w1yy]", Format(firstdate.AddDays(1), "yy"))
        resstr = resstr.Replace("[w1M]", Format(firstdate.AddDays(1), "%M"))
        resstr = resstr.Replace("[w1d]", Format(firstdate.AddDays(1), "%d"))
        '星期日的日期
        resstr = resstr.Replace("[w7yyyy]", Format(firstdate.AddDays(7), "yyyy"))
        resstr = resstr.Replace("[w7MM]", Format(firstdate.AddDays(7), "MM"))
        resstr = resstr.Replace("[w7dd]", Format(firstdate.AddDays(7), "dd"))
        resstr = resstr.Replace("[w7yy]", Format(firstdate.AddDays(7), "yy"))
        resstr = resstr.Replace("[w7M]", Format(firstdate.AddDays(7), "%M"))
        resstr = resstr.Replace("[w7d]", Format(firstdate.AddDays(7), "%d"))

        '英文的星期：周日--周六
        '上星期日的日期
        resstr = resstr.Replace("[w0yyyy]", Format(firstdate, "yyyy"))
        resstr = resstr.Replace("[w0MM]", Format(firstdate, "MM"))
        resstr = resstr.Replace("[w0dd]", Format(firstdate, "dd"))
        resstr = resstr.Replace("[w0yy]", Format(firstdate, "yy"))
        resstr = resstr.Replace("[w0M]", Format(firstdate, "%M"))
        resstr = resstr.Replace("[w0d]", Format(firstdate, "%d"))
        '星期六的日期
        resstr = resstr.Replace("[w6yyyy]", Format(firstdate.AddDays(6), "yyyy"))
        resstr = resstr.Replace("[w6MM]", Format(firstdate.AddDays(6), "MM"))
        resstr = resstr.Replace("[w6dd]", Format(firstdate.AddDays(6), "dd"))
        resstr = resstr.Replace("[w6yy]", Format(firstdate.AddDays(6), "yy"))
        resstr = resstr.Replace("[w6M]", Format(firstdate.AddDays(6), "%M"))
        resstr = resstr.Replace("[w6d]", Format(firstdate.AddDays(6), "%d"))
        Return resstr
    End Function
    '根据cycleID和BaseKey计算出相应的以字符表示的时间，用于写保存日志
    Private Function pCalcDateTimeStr(ByVal aCycleID As Integer, ByVal aBaseKey As String) As String
        Select Case aBaseKey
            Case "MIN15"
                Dim aTimeSpan As TimeSpan = New System.TimeSpan(0, (aCycleID - 1) / 4, ((aCycleID - 1) Mod 4) * 15, 0)
                Return BaseDate.Add(aTimeSpan).ToLongDateString + " " + BaseDate.Add(aTimeSpan).ToLongTimeString
            Case "HOUR"
                Dim aTimeSpan As TimeSpan = New System.TimeSpan(0, aCycleID - 1, 0, 0)
                Return BaseDate.Add(aTimeSpan).ToLongDateString + " " + BaseDate.Add(aTimeSpan).ToLongTimeString
            Case "DAY"
                Return aCycleID.ToString.Substring(0, 4) + "-" + aCycleID.ToString.Substring(4, 2) + "-" + aCycleID.ToString.Substring(6, 2)
            Case "MONTH"
                Return aCycleID.ToString.Substring(0, 4) + "年" + aCycleID.ToString.Substring(4, 2) + "月"
            Case "YEAR"
                Return aCycleID.ToString.Substring(0, 4) + "年"
        End Select
    End Function
    '根据cycleid 和 BaseKey 计算开始时间四个存储过程sp_CalcComTag、sp_HoutToDay、sp_DayToMonth、sp_MonthToYear的StartTime
    Private Function pCalcStartTimeStr(ByVal aCycleID As Integer, ByVal aBaseKey As String) As String
        Select Case aBaseKey
            Case "HOUR"
                Dim aTimeSpan As TimeSpan = New System.TimeSpan(0, aCycleID - 1, 0, 0)
                Return BaseDate.Add(aTimeSpan).ToShortDateString + " " + BaseDate.Add(aTimeSpan).ToShortTimeString
            Case "DAY"
                Return aCycleID.ToString.Substring(0, 4) + "-" + aCycleID.ToString.Substring(4, 2) + "-" + aCycleID.ToString.Substring(6, 2)
            Case "MONTH"
                Return aCycleID.ToString
            Case "YEAR"
                Return aCycleID.ToString
        End Select
    End Function
    '生成指标定义区的字符串拼接串.
    '由于原先的指标定义区域只能定义指标ID,现在对指标定义的功能做了扩充,
    '可以通过"指标ID|WhereClause"的方式进行查询条件的限定.例如:1401001|I_Value_Man>0.1
    '由此对于指标ID的连接拼接方式起了一些变化,在用到条件限定功能的几个地方,
    '拼接的时候,无需增加单引号.
    Private Function pGenerate_TagIDALL(ByVal aTag As System.Array, ByVal sTagType As String) As String
        '所有要取数据的指标编号，以,隔开,组成'指标1','指标2'形式的字符串.
        Dim i, j As Integer
        Dim sTagIDAll As String = String.Empty, sTagID As String = String.Empty
        'aTag 是一个二维数组,所以数组下标从1开始.

        Select Case sTagType.ToUpper
            Case "FLOAT", "STR", "MAX", "MIN", "AVG", "SUM", "COUNT", "AGGREGATION", "MAXVALUE1DATE", "MINVALUE1DATE", "SWITCHCOUNT", "ONCERUNNINGDATA" '数值和字符数据.
                For i = 1 To aTag.GetLength(0)
                    For j = 1 To aTag.GetLength(1)
                        sTagID = aTag(i, j)
                        If Not (sTagID Is Nothing) Then
                            If sTagID.Trim() <> String.Empty Then
                                sTagIDAll += String.Format(IIf(sTagIDAll.Length > 0, ",{0}", "{0}"), sTagID) '不带单引号
                            End If
                        End If
                    Next
                Next
            Case "LINE1", "LINE2", "FUNC" '机泵运行状态图1段
                For i = 1 To aTag.GetLength(0)
                    For j = 1 To aTag.GetLength(1)
                        sTagID = aTag(i, j)
                        If Not (sTagID Is Nothing) Then
                            If sTagID.Trim() <> String.Empty Then
                                sTagIDAll += String.Format(IIf(sTagIDAll.Length > 0, ",'{0}'", "'{0}'"), sTagID) '带单引号
                            End If
                        End If
                    Next
                Next
        End Select
        Return sTagIDAll
    End Function
    '根据指标的合格条件创建一个合格条件的计数自读.
    Private Function pGenerate_TagConditionColumn(ByVal aTagIDALL As String) As String
        Dim aTag_Condition As System.Array = aTagIDALL.Split(",")
        Dim sTag_Column As String = "Case "
        Dim i As Integer
        Dim sTag_Condition As String
        For i = 0 To aTag_Condition.Length - 1
            sTag_Condition = aTag_Condition(i)
            If sTag_Condition.Split("|").Length = 1 Then
                sTag_Column += String.Format(" When I_Tag_ID='{0}' Then I_Value_Man ", sTag_Condition)
            Else '如果指标指定了采样值的限定条件.
                Dim tagID, tagCondition As String
                tagID = sTag_Condition.Split("|")(0)
                tagCondition = sTag_Condition.Split("|")(1)
                sTag_Column += String.Format(" When I_Tag_ID='{0}' And {1} Then I_Value_Man ", tagID, tagCondition)
            End If
        Next
        sTag_Column += " Else Null End"
        Return sTag_Column
    End Function
    '针对有些报表中会对指标的采样值有条件限定.比如出厂水的浊度,合格的为采样值>0.1.
    '部分报表会进行合格数的统计.如出厂水的合格采样数目和合格率等.
    '入口参数说明:
    '   aTagIDALL:指标定义区域所对应的指标链接串.
    '   例如:   1401001,1401002,
    '           1401001|I_VALUE_MAN>0.1,1401002
    '           1401001|I_VALUE_MAN>0.1,1401002|I_VALUE_MAN>0.2 
    '返回值: 一个拼接好的WhereClause的部分.形如
    '        ((I__Tag_ID ='1401001') OR (I_Tag_ID = '1401002' And I_Value_Man > 0.1))
    Private Function pGenerate_TagConditionWhereClause(ByVal aTagIDALL As String) As String
        Dim aTag_Condition As System.Array = aTagIDALL.Split(",") 'System.Array的下标是从0开始的.
        Dim sTag_WhereClause As String = "("
        Dim i As Integer
        Dim sTag_Condition As String
        For i = 0 To aTag_Condition.Length - 1
            sTag_Condition = aTag_Condition(i)
            If sTag_Condition.Split("|").Length = 1 Then '如果指标没有指定采样值限定条件
                sTag_WhereClause += String.Format("(I_Tag_ID='{0}') OR ", sTag_Condition)
            Else '如果指标指定了采样值的限定条件.
                Dim tagID, tagCondition As String
                tagID = sTag_Condition.Split("|")(0)
                tagCondition = sTag_Condition.Split("|")(1)
                sTag_WhereClause += String.Format("(I_Tag_ID='{0}' And {1}) OR ", tagID, tagCondition)
            End If
        Next
        sTag_WhereClause = sTag_WhereClause.Substring(0, sTag_WhereClause.Length - 3)
        sTag_WhereClause += ")"
        Return sTag_WhereClause
    End Function
    '以纯指标ID拼接起来的字符串.
    Private Function pGenerate_PureTagConditionWhereClause(ByVal aTagIDALL As String, Optional ByVal fieldName As String = "I_Tag_ID") As String
        Dim aTag_Condition As System.Array = aTagIDALL.Split(",") 'System.Array的下标是从0开始的.
        Dim sTag_WhereClause As String = "("
        Dim i As Integer
        Dim sTag_Condition As String
        For i = 0 To aTag_Condition.Length - 1
            sTag_Condition = aTag_Condition(i)
            If sTag_Condition.Split("|").Length = 1 Then '如果指标没有指定采样值限定条件
                sTag_WhereClause += String.Format("({0}='{1}') OR ", fieldName, sTag_Condition)
            Else '如果指标指定了采样值的限定条件.
                Dim tagID, tagCondition As String
                tagID = sTag_Condition.Split("|")(0)
                tagCondition = sTag_Condition.Split("|")(1)
                sTag_WhereClause += String.Format("({0}='{1}') OR ", fieldName, tagID)
            End If
        Next
        sTag_WhereClause = sTag_WhereClause.Substring(0, sTag_WhereClause.Length - 3)
        sTag_WhereClause += ")"
        Return sTag_WhereClause
    End Function

    '过滤字段的空值
    Public Shared Function FilterDBNull(ByVal item As Object) As String
        If item Is DBNull.Value Then
            Return ""
        Else
            Return CStr(item)
        End If
    End Function

    Public Sub Close()
        SQLConn.Close()
    End Sub

    Public ReadOnly Property BaseDate() As DateTime
        Get
            Return CDate("2002/01/01")
        End Get
    End Property

    Public Function GetDBDateTime() As DateTime
        If SQLConn.State <> ConnectionState.Open Then
            SQLConn.Open()
        End If

        Dim strSQL As String = " Select getDate() As DBDateTime"
        Dim oAdapterTemp As New SqlDataAdapter(strSQL, SQLConn)
        Dim dtDataTemp As New DataTable("T_TAG_DATETEMP")
        oAdapterTemp.Fill(dtDataTemp)
        Return dtDataTemp.DefaultView.Item(0).Item("DBDateTime")
    End Function
    '增加报表模板.
    Public Function AddSchemaXML(ByVal schemaID As String, _
                                ByVal schemaName As String, _
                                ByVal schemaType As String, _
                                ByVal schemaXML As String, _
                                ByVal cycleType As String) _
    As Boolean
        If SQLConn.State <> ConnectionState.Open Then
            SQLConn.Open()
        End If
        strErrInfo = ""
        Dim retCount As Integer
        Dim mySQLCommand As SqlCommand = New SqlCommand("_T_Schema_MS_Insert", SQLConn)
        mySQLCommand.CommandType = CommandType.StoredProcedure
        mySQLCommand.Parameters.Add("@I_Schema_ID", SqlDbType.VarChar, 20, "I_Schema_ID")
        mySQLCommand.Parameters.Add("@I_Schema_NM", SqlDbType.NVarChar, 100, "I_Schema_NM")
        mySQLCommand.Parameters.Add("@I_Schema_TP", SqlDbType.VarChar, 10, "I_Schema_TP")
        mySQLCommand.Parameters.Add("@I_Schema_XML", SqlDbType.Text)
        mySQLCommand.Parameters.Add("@I_Cycle_Type", SqlDbType.VarChar, 10, "I_Cycle_Type")

        mySQLCommand.UpdatedRowSource = UpdateRowSource.None

        mySQLCommand.Parameters(0).Value = schemaID
        mySQLCommand.Parameters(1).Value = schemaName
        mySQLCommand.Parameters(2).Value = schemaType
        mySQLCommand.Parameters(3).Value = schemaXML
        mySQLCommand.Parameters(4).Value = cycleType

        retCount = mySQLCommand.ExecuteNonQuery()
        Return IIf(retCount = 1, True, False)
    End Function
    '更新报表模板.
    Public Function UpdateSchemaXML(ByVal schemaID As String, _
                                ByVal schemaName As String, _
                                ByVal schemaType As String, _
                                ByVal schemaXML As String, _
                                ByVal cycleType As String) _
    As Boolean
        If SQLConn.State <> ConnectionState.Open Then
            SQLConn.Open()
        End If
        strErrInfo = ""
        Dim retCount As Integer
        Dim mySQLCommand As SqlCommand = New SqlCommand("_T_Schema_MS_Update", SQLConn)
        mySQLCommand.CommandType = CommandType.StoredProcedure
        mySQLCommand.Parameters.Add("@I_Schema_ID", SqlDbType.VarChar, 20, "I_Schema_ID")
        mySQLCommand.Parameters.Add("@I_Schema_NM", SqlDbType.NVarChar, 100, "I_Schema_NM")
        mySQLCommand.Parameters.Add("@I_Schema_TP", SqlDbType.VarChar, 10, "I_Schema_TP")
        mySQLCommand.Parameters.Add("@I_Schema_XML", SqlDbType.Text)
        mySQLCommand.Parameters.Add("@I_Cycle_Type", SqlDbType.VarChar, 10, "I_Cycle_Type")

        mySQLCommand.UpdatedRowSource = UpdateRowSource.None

        mySQLCommand.Parameters(0).Value = schemaID
        mySQLCommand.Parameters(1).Value = schemaName
        mySQLCommand.Parameters(2).Value = schemaType
        mySQLCommand.Parameters(3).Value = schemaXML
        mySQLCommand.Parameters(4).Value = cycleType

        retCount = mySQLCommand.ExecuteNonQuery()
        Return IIf(retCount = 1, True, False)
    End Function

    ''' <summary>
    ''' 设备开关次数统计。
    ''' </summary>
    ''' <param name="aDate"></param>
    ''' <param name="sTagIDAll"></param>
    ''' <param name="nRowStart"></param>
    ''' <param name="nColStart"></param>
    ''' <param name="aTag"></param>
    ''' <param name="sTagType"></param>
    ''' <param name="sDateType"></param>
    ''' <param name="sTagOrient"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function pGetData_SwitchCount(ByVal aDate As DateTime, _
                                    ByVal sTagIDAll As String, _
                                    ByVal nRowStart As Integer, _
                                    ByVal nColStart As Integer, _
                                    ByVal aTag As System.Array, _
                                    ByVal sTagType As String, _
                                    ByVal sDateType As String, _
                                    ByVal sTagOrient As String) _
    As Boolean

        Dim i, j As Integer
        Dim startTime, endTime As DateTime
        Dim sTagID As String
        Dim oRange As OWC10.Range
        Dim startJ As Int32

        Dim nStart, nEnd, nTimeCount As Integer
        Dim sBaseKey As String = ""
        '根据指定日期,时间特征来获取指标数据表类型（小时、天等）、开始时间点、结束时间点、总数据点数目等信息。
        '时间特征的信息存储在T_DATE_MS表中.
        If Not pCalcCycleID(aDate, sDateType, sBaseKey, nStart, nEnd, nTimeCount) Then
            strErrInfo = strErrInfo & "  " & sDateType & ERRINFO_INSPECTREPORT_006
            Return False
        End If

        Dim strDatePart As String = ""
        Select Case sBaseKey.ToUpper
            Case "MIN15"
                startTime = BaseDate.AddMinutes(nStart * 15)
                endTime = BaseDate.AddMinutes(nEnd * 15)
            Case "HOUR"
                startTime = BaseDate.AddHours(nStart)
                endTime = BaseDate.AddHours(nEnd) '.AddHours(1)
                strDatePart = "hh"
                startJ = DatePart(DateInterval.Hour, startTime)
            Case "DAY"
                Dim strStart As String = nStart.ToString()
                Dim strEnd As String = nEnd.ToString()
                startTime = New DateTime(Int32.Parse(strStart.Substring(0, 4)), Int32.Parse(strStart.Substring(4, 2)), Int32.Parse(strStart.Substring(6, 2)))
                endTime = New DateTime(Int32.Parse(strEnd.Substring(0, 4)), Int32.Parse(strEnd.Substring(4, 2)), Int32.Parse(strEnd.Substring(6, 2))).AddDays(1)
                strDatePart = "dd"
                startJ = DatePart(DateInterval.Day, startTime)
            Case "DAY_L"    '上个月的日报表
                Dim strStart As String = nStart.ToString()
                Dim strEnd As String = nEnd.ToString()
                startTime = New DateTime(Int32.Parse(strStart.Substring(0, 4)), Int32.Parse(strStart.Substring(4, 2)), Int32.Parse(strStart.Substring(6, 2)))
                endTime = New DateTime(Int32.Parse(strEnd.Substring(0, 4)), Int32.Parse(strEnd.Substring(4, 2)), Int32.Parse(strEnd.Substring(6, 2))).AddDays(1)
                strDatePart = "dd"
                startJ = DatePart(DateInterval.Day, startTime)
            Case "WEEK" '周报表，数据存在天表T_TAG_DAY中（由于中国的周是从周一开始，而电脑上的周是从周日开始，所以要注意开始日期）                
                Dim strStart As String = nStart.ToString()
                Dim strEnd As String = nEnd.ToString()
                startTime = New DateTime(Int32.Parse(strStart.Substring(0, 4)), Int32.Parse(strStart.Substring(4, 2)), Int32.Parse(strStart.Substring(6, 2)))
                endTime = New DateTime(Int32.Parse(strEnd.Substring(0, 4)), Int32.Parse(strEnd.Substring(4, 2)), Int32.Parse(strEnd.Substring(6, 2))).AddDays(1)
                strDatePart = "dw"
                startJ = DatePart(DateInterval.Weekday, startTime)
                startJ = startJ - 1 '由于中国的周是从周一开始
            Case "WEEK_L" '上周报表，数据存在天表T_TAG_DAY中
                Dim strStart As String = nStart.ToString()
                Dim strEnd As String = nEnd.ToString()
                startTime = New DateTime(Int32.Parse(strStart.Substring(0, 4)), Int32.Parse(strStart.Substring(4, 2)), Int32.Parse(strStart.Substring(6, 2)))
                endTime = New DateTime(Int32.Parse(strEnd.Substring(0, 4)), Int32.Parse(strEnd.Substring(4, 2)), Int32.Parse(strEnd.Substring(6, 2))).AddDays(1)
                strDatePart = "dw"
                startJ = DatePart(DateInterval.Weekday, startTime)
                startJ = startJ - 1 '由于中国的周是从周一开始
            Case "MONTH"
                Dim strStart As String = nStart.ToString()
                Dim strEnd As String = nEnd.ToString()
                startTime = New DateTime(Int32.Parse(strStart.Substring(0, 4)), Int32.Parse(strStart.Substring(4, 2)), 1)
                endTime = New DateTime(Int32.Parse(strEnd.Substring(0, 4)), Int32.Parse(strEnd.Substring(4, 2)), 1).AddMonths(1)
                strDatePart = "mm"
                startJ = DatePart(DateInterval.Month, startTime)
            Case "MONTH_L"   '去年的月报表数据
                Dim strStart As String = nStart.ToString()
                Dim strEnd As String = nEnd.ToString()
                startTime = New DateTime(Int32.Parse(strStart.Substring(0, 4)), Int32.Parse(strStart.Substring(4, 2)), 1)
                endTime = New DateTime(Int32.Parse(strEnd.Substring(0, 4)), Int32.Parse(strEnd.Substring(4, 2)), 1).AddMonths(1)
                strDatePart = "mm"
                startJ = DatePart(DateInterval.Month, startTime)
            Case "YEAR"
                Dim strStart As String = nStart.ToString()
                Dim strEnd As String = nEnd.ToString()
                startTime = New DateTime(Int32.Parse(strStart.Substring(0, 4)), 1, 1)
                endTime = New DateTime(Int32.Parse(strEnd.Substring(0, 4)), 1, 1).AddYears(1)
                strDatePart = "yy"
                startJ = DatePart(DateInterval.Year, startTime)
        End Select
        'ApplicationLog.WriteInfo("数量:" + nTimeCount.ToString())
        '到数据库取出相应的指标数据
        Dim dtData As New DataTable()
        '数据表名
        Dim strSQL As String

        If nTimeCount = 1 Then
            strSQL = String.Format("SELECT [SwitchTagId], COUNT([SwitchTagId]) AS [SwitchCount] FROM T_Tag_Switch " _
                & " WHERE [TurnonTime] BETWEEN '{0}' AND '{1}' AND {2}" _
                & " GROUP BY [SwitchTagId]", startTime.ToString("yyyy-MM-dd HH:mm:ss"), endTime.ToString("yyyy-MM-dd HH:mm:ss"), Me.pGenerate_PureTagConditionWhereClause(sTagIDAll, "SwitchTagId"))
        Else
            strSQL = String.Format("SELECT [SwitchTagId], COUNT([SwitchTagId]) AS [SwitchCount], DATEPART({3}, [TurnonTime]) AS [Part] FROM T_Tag_Switch " _
                & " WHERE [TurnonTime] BETWEEN '{0}' AND '{1}' AND {2}" _
                & " GROUP BY [SwitchTagId], DATEPART({3}, [TurnonTime]) ORDER BY DATEPART({3}, [TurnonTime])", startTime.ToString("yyyy-MM-dd HH:mm:ss"), endTime.ToString("yyyy-MM-dd HH:mm:ss"), Me.pGenerate_PureTagConditionWhereClause(sTagIDAll, "SwitchTagId"), strDatePart)
        End If
        'ApplicationLog.WriteInfo("SwitchCount_SQL:" + strSQL)
        '开启事务.
        Dim myTrans As SqlTransaction = SQLConn.BeginTransaction("GetData_SwitchCount")
        Try
            Dim myCommand As SqlCommand = SQLConn.CreateCommand()
            myCommand.Transaction = myTrans
            Dim oAdapter As New SqlDataAdapter(strSQL, SQLConn)
            oAdapter.SelectCommand.Transaction = myTrans
            oAdapter.Fill(dtData)
            myTrans.Commit()
        Catch ex As Exception
            myTrans.Rollback()
            ApplicationLog.WriteInfo(ex.Message)
            Return False
        End Try

        If nTimeCount = 1 Then
            Try
                For i = 0 To aTag.GetLength(0) - 1
                    For j = 0 To aTag.GetLength(1) - 1 '遍历指标定义二维数组.
                        sTagID = aTag(i + 1, j + 1) '数组的下标从1开始.

                        If Not (sTagID Is Nothing) Then
                            If sTagID.Trim() <> String.Empty Then
                                oRange = CType(CCData.Cells._Default(i + nRowStart, j + nColStart), OWC10.Range) '找到对应指标采样值对应的单元格.(1个单元格)
                                dtData.DefaultView.RowFilter = String.Format("SwitchTagId='{0}'", sTagID.Split("|")(0))
                                If dtData.DefaultView.Count = 1 Then '如果指标的采样值记录有一条记录.
                                    oRange.Value2 = dtData.DefaultView.Item(0).Item("SwitchCount")
                                End If
                            End If
                        End If
                    Next
                Next
            Catch ex As Exception
                ApplicationLog.WriteError(ex.ToString())
            End Try
        Else
            Try
                Dim nTagCount, JJ As Int32
                '多时间点时要考虑时间点的排列方向
                If sTagOrient = "0" Then
                    nTagCount = aTag.GetLength(1) - 1
                Else
                    nTagCount = aTag.GetLength(0) - 1
                End If
                For JJ = 0 To nTagCount
                    If sTagOrient = "0" Then
                        sTagID = "" & aTag(1, JJ + 1)
                    Else
                        sTagID = "" & aTag(JJ + 1, 1)
                    End If
                    If sTagID.Trim() <> "" Then
                        dtData.DefaultView.RowFilter = String.Format("SwitchTagId='{0}'", sTagID.Split("|")(0))
                        Dim part As Int32
                        For i = 0 To dtData.DefaultView.Count - 1
                            part = CInt(dtData.DefaultView.Item(i).Item("Part"))
                            j = part - startJ
                            If sTagOrient = "0" Then
                                oRange = CType(CCData.Cells._Default(j + nRowStart, JJ + nColStart), OWC10.Range)
                                'ApplicationLog.WriteInfo(String.Format("oRange = CType(CCData.Cells._Default({0}, {1}), OWC10.Range)", j + nRowStart, JJ + nColStart))
                            Else
                                oRange = CType(CCData.Cells._Default(JJ + nRowStart, j + nColStart), OWC10.Range)
                                'ApplicationLog.WriteInfo(String.Format("oRange = CType(CCData.Cells._Default({0}, {1}), OWC10.Range)", JJ + nRowStart, j + nColStart))
                            End If
                            oRange.Value = dtData.DefaultView.Item(i).Item("SwitchCount")
                        Next i
                    End If
                Next
            Catch ex As Exception
                ApplicationLog.WriteError(ex.ToString())
            End Try
        End If

    End Function
    ''' <summary>
    ''' 设备开关一次的数值。
    ''' </summary>
    ''' <param name="aDate"></param>
    ''' <param name="sTagIDAll"></param>
    ''' <param name="nRowStart"></param>
    ''' <param name="nColStart"></param>
    ''' <param name="aTag"></param>
    ''' <param name="sTagType"></param>
    ''' <param name="sDateType"></param>
    ''' <param name="sTagOrient"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function pGetData_OnceRunningData(ByVal aDate As DateTime, _
                                    ByVal sTagIDAll As String, _
                                    ByVal nRowStart As Integer, _
                                    ByVal nColStart As Integer, _
                                    ByVal aTag As System.Array, _
                                    ByVal sTagType As String, _
                                    ByVal sDateType As String, _
                                    ByVal sTagOrient As String) _
    As Boolean



        Dim i As Integer
        Dim startTime, endTime As DateTime
        Dim sTagID As String

        Dim nStart, nEnd, nTimeCount As Integer
        Dim sBaseKey As String = ""
        '根据指定日期,时间特征来获取指标数据表类型（小时、天等）、开始时间点、结束时间点、总数据点数目等信息。
        '时间特征的信息存储在T_DATE_MS表中.
        If Not pCalcCycleID(aDate, sDateType, sBaseKey, nStart, nEnd, nTimeCount) Then
            strErrInfo = strErrInfo & "  " & sDateType & ERRINFO_INSPECTREPORT_006
            Return False
        End If
        Select Case sBaseKey.ToUpper
            Case "MIN15"
                startTime = BaseDate.AddMinutes(nStart * 15)
                endTime = BaseDate.AddMinutes(nEnd * 15)
            Case "HOUR"
                startTime = BaseDate.AddHours(nStart)
                endTime = BaseDate.AddHours(nEnd) '.AddHours(1)               
            Case "DAY"
                Dim strStart As String = nStart.ToString()
                Dim strEnd As String = nEnd.ToString()
                startTime = New DateTime(Int32.Parse(strStart.Substring(0, 4)), Int32.Parse(strStart.Substring(4, 2)), Int32.Parse(strStart.Substring(6, 2)))
                endTime = New DateTime(Int32.Parse(strEnd.Substring(0, 4)), Int32.Parse(strEnd.Substring(4, 2)), Int32.Parse(strEnd.Substring(6, 2))).AddDays(1)
            Case "DAY_L"    '上个月的日报表
                Dim strStart As String = nStart.ToString()
                Dim strEnd As String = nEnd.ToString()
                startTime = New DateTime(Int32.Parse(strStart.Substring(0, 4)), Int32.Parse(strStart.Substring(4, 2)), Int32.Parse(strStart.Substring(6, 2)))
                endTime = New DateTime(Int32.Parse(strEnd.Substring(0, 4)), Int32.Parse(strEnd.Substring(4, 2)), Int32.Parse(strEnd.Substring(6, 2))).AddDays(1)
            Case "WEEK" '周报表，数据存在天表T_TAG_DAY中（由于中国的周是从周一开始，而电脑上的周是从周日开始，所以要注意开始日期）                
                Dim strStart As String = nStart.ToString()
                Dim strEnd As String = nEnd.ToString()
                startTime = New DateTime(Int32.Parse(strStart.Substring(0, 4)), Int32.Parse(strStart.Substring(4, 2)), Int32.Parse(strStart.Substring(6, 2)))
                endTime = New DateTime(Int32.Parse(strEnd.Substring(0, 4)), Int32.Parse(strEnd.Substring(4, 2)), Int32.Parse(strEnd.Substring(6, 2))).AddDays(1)
            Case "WEEK_L" '上周报表，数据存在天表T_TAG_DAY中
                Dim strStart As String = nStart.ToString()
                Dim strEnd As String = nEnd.ToString()
                startTime = New DateTime(Int32.Parse(strStart.Substring(0, 4)), Int32.Parse(strStart.Substring(4, 2)), Int32.Parse(strStart.Substring(6, 2)))
                endTime = New DateTime(Int32.Parse(strEnd.Substring(0, 4)), Int32.Parse(strEnd.Substring(4, 2)), Int32.Parse(strEnd.Substring(6, 2))).AddDays(1)
            Case "MONTH"
                Dim strStart As String = nStart.ToString()
                Dim strEnd As String = nEnd.ToString()
                startTime = New DateTime(Int32.Parse(strStart.Substring(0, 4)), Int32.Parse(strStart.Substring(4, 2)), 1)
                endTime = New DateTime(Int32.Parse(strEnd.Substring(0, 4)), Int32.Parse(strEnd.Substring(4, 2)), 1).AddMonths(1)
            Case "MONTH_L"   '去年的月报表数据
                Dim strStart As String = nStart.ToString()
                Dim strEnd As String = nEnd.ToString()
                startTime = New DateTime(Int32.Parse(strStart.Substring(0, 4)), Int32.Parse(strStart.Substring(4, 2)), 1)
                endTime = New DateTime(Int32.Parse(strEnd.Substring(0, 4)), Int32.Parse(strEnd.Substring(4, 2)), 1).AddMonths(1)
            Case "YEAR"
                Dim strStart As String = nStart.ToString()
                Dim strEnd As String = nEnd.ToString()
                startTime = New DateTime(Int32.Parse(strStart.Substring(0, 4)), 1, 1)
                endTime = New DateTime(Int32.Parse(strEnd.Substring(0, 4)), 1, 1).AddYears(1)
        End Select

        Dim dtData As New DataTable()
        Dim dtTag As New DataTable()
        Dim strSQL As String

        strSQL = String.Format("SELECT B.[TagId], A.[TurnonTime], A.[TurnoffTime], B.[DiffValue] FROM T_Tag_Switch A" _
            & " INNER JOIN T_Tag_SwitchDetail B ON A.[PKID] = B.[SwitchPKID] " _
            & " WHERE [TurnonTime] BETWEEN '{0}' AND '{1}' AND {2}", _
            startTime.ToString("yyyy-MM-dd HH:mm:ss"), endTime.ToString("yyyy-MM-dd HH:mm:ss"), Me.pGenerate_PureTagConditionWhereClause(sTagIDAll, "TagId"))
        'ApplicationLog.WriteInfo("OnceRunningData_SQL:" + strSQL)
        '开启事务.
        Dim myTrans As SqlTransaction = SQLConn.BeginTransaction("GetData_OnceRunningData")
        Try
            Dim myCommand As SqlCommand = SQLConn.CreateCommand()
            myCommand.Transaction = myTrans
            Dim oAdapter As New SqlDataAdapter(strSQL, SQLConn)
            oAdapter.SelectCommand.Transaction = myTrans
            oAdapter.Fill(dtData)

            oAdapter.SelectCommand.CommandText = String.Format("Select I_TAG_ID,I_DIG_NUM,MAX_VALUE,MIN_VALUE" & _
                            " From T_TAG_MS " & _
                            " Where {0} And  I_DIG_NUM IS NOT NULL", Me.pGenerate_PureTagConditionWhereClause(sTagIDAll))
            oAdapter.Fill(dtTag)
            myTrans.Commit()
        Catch ex As Exception
            myTrans.Rollback()
            ApplicationLog.WriteInfo(ex.Message)
            Return False
        End Try

        Try
            Dim nTagCount, JJ As Int32
            Dim rangeTurnonTime As OWC10.Range
            Dim rangeTurnoffTime As OWC10.Range
            Dim rangeDiffValue As OWC10.Range
            '多时间点时要考虑时间点的排列方向
            If sTagOrient = "0" Then
                nTagCount = aTag.GetLength(1) - 1
            Else
                nTagCount = aTag.GetLength(0) - 1
            End If
            For JJ = 0 To nTagCount
                If sTagOrient = "0" Then
                    sTagID = "" & aTag(1, JJ + 1)
                Else
                    sTagID = "" & aTag(JJ + 1, 1)
                End If
                If sTagID.Trim() <> "" Then
                    dtData.DefaultView.RowFilter = String.Format("TagId='{0}'", sTagID.Split("|")(0))
                    dtTag.DefaultView.RowFilter = String.Format("I_TAG_ID='{0}'", sTagID.Split("|")(0))
                    For i = 0 To dtData.DefaultView.Count - 1
                        If sTagOrient = "0" Then '从上到下
                            rangeTurnonTime = CType(CCData.Cells._Default(i + nRowStart, JJ * 3 + 0 + nColStart), OWC10.Range)
                            rangeTurnoffTime = CType(CCData.Cells._Default(i + nRowStart, JJ * 3 + 1 + nColStart), OWC10.Range)
                            rangeDiffValue = CType(CCData.Cells._Default(i + nRowStart, JJ * 3 + 2 + nColStart), OWC10.Range)
                            'ApplicationLog.WriteInfo(String.Format("oRange = CType(CCData.Cells._Default({0}, {1}), OWC10.Range)", i + nRowStart, JJ * 3 + 0 + nColStart))
                            'ApplicationLog.WriteInfo(String.Format("oRange = CType(CCData.Cells._Default({0}, {1}), OWC10.Range)", i + nRowStart, JJ * 3 + 1 + nColStart))
                            'ApplicationLog.WriteInfo(String.Format("oRange = CType(CCData.Cells._Default({0}, {1}), OWC10.Range)", i + nRowStart, JJ * 3 + 2 + nColStart))
                            'ApplicationLog.WriteInfo("--------------------")
                        Else '从左到右
                            rangeTurnonTime = CType(CCData.Cells._Default(JJ + nRowStart, i * 3 + nColStart), OWC10.Range)
                            rangeTurnoffTime = CType(CCData.Cells._Default(JJ + nRowStart, i * 3 + 1 + nColStart), OWC10.Range)
                            rangeDiffValue = CType(CCData.Cells._Default(JJ + nRowStart, i * 3 + 2 + nColStart), OWC10.Range)
                            'ApplicationLog.WriteInfo(String.Format("oRange = CType(CCData.Cells._Default({0}, {1}), OWC10.Range)", JJ + nRowStart, i * 3 + nColStart))
                            'ApplicationLog.WriteInfo(String.Format("oRange = CType(CCData.Cells._Default({0}, {1}), OWC10.Range)", JJ + nRowStart, i * 3 + 1 + nColStart))
                            'ApplicationLog.WriteInfo(String.Format("oRange = CType(CCData.Cells._Default({0}, {1}), OWC10.Range)", JJ + nRowStart, i * 3 + 2 + nColStart))
                            'ApplicationLog.WriteInfo("--------------------")
                        End If
                        Dim diffValue As Double
                        diffValue = dtData.DefaultView.Item(i).Item("DiffValue")
                        If dtTag.DefaultView.Count = 1 Then
                            Dim digNum As Object
                            digNum = dtTag.DefaultView.Item(0).Item("I_DIG_NUM")
                            '四舍五入,根据在T_Tag_MS中定义的指标的小数点保留位数.
                            diffValue = System.Math.Round(diffValue * System.Math.Pow(10, digNum)) * System.Math.Pow(10, -digNum)
                        End If
                        rangeTurnonTime.Value = dtData.DefaultView.Item(i).Item("TurnonTime")
                        rangeTurnoffTime.Value = dtData.DefaultView.Item(i).Item("TurnoffTime")
                        rangeDiffValue.Value = diffValue
                    Next i
                End If
            Next
        Catch ex As Exception
            ApplicationLog.WriteError(ex.ToString())
        End Try
        dtData.Dispose()
        dtTag.Dispose()
    End Function


End Class


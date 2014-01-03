Imports System.Data.SqlClient
Imports System.Configuration

Public Class CSchema

    Private Const ERRINFO_INSPECTREPORT_001 As String = "SQL���ִ�д���"
    Private Const ERRINFO_INSPECTREPORT_002 As String = "����ģ�岻���ڣ�"
    Private Const ERRINFO_INSPECTREPORT_003 As String = "����ģ���д���"
    Private Const ERRINFO_INSPECTREPORT_004 As String = "�������"
    Private Const ERRINFO_INSPECTREPORT_005 As String = "����ģ���ﱣ���������ָ�������д���"
    Private Const ERRINFO_INSPECTREPORT_006 As String = "����ģ�������ʱ�����������ݿ����Ҳ�����"
    Private Const ERRINFO_INSPECTREPORT_007 As String = "������󣬱����������֣�"
    Private Const ERRINFO_INSPECTREPORT_008 As String = "������󣬱�������ʱ�䣡"
    Private SQLConn As SqlConnection
    Private CCData, oldXMLData As OWC10.Spreadsheet
    Private mUserConnString As String
    Private Shared ReadOnly Logger As log4net.ILog = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)
    '������
    Private strErrInfo As String
    ' ֻ�����ԣ�Errinfo, �ṩ���������Ϣ.
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


    '����ѡ��ķ����ļ���ʱ�����������ļ���sXMLFileΪ�����ļ�����nCycleIDΪʱ�䡣
    '�����ж��������
    Public Function GetSchema(ByVal Report_Code As String, _
                            ByVal aDate As Date, _
                            ByVal CanModify As Boolean) _
    As String
        If SQLConn.State <> ConnectionState.Open Then
            SQLConn.Open()
        End If
        Logger.Info(SQLConn.ConnectionString)

        strErrInfo = ""
        '���뱨��ģ��
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
            'ȡÿ�������������Xpath:DataSchema/Retrieve
            For Each oDataNode In oDataNodes
                sDateType = ""
                sTag = ""
                sFill = ""
                sTagType = ""
                sTagOrient = ""
                'ȡ����������,��Ŀ�ĵ�ַ,�Լ������
                For Each oAttr In oDataNode.Attributes
                    Select Case oAttr.Name.ToUpper
                        Case "DATETYPE" '���ݵ�������ʱ������,Сʱ,���.
                            sDateType = oAttr.Value.ToUpper
                        Case "TAGRANGE" '���ݵ�������ָ��Ķ��巶Χ
                            sTag = oAttr.Value.ToUpper
                        Case "FILLRANGE" '���ݵ�������ָ��ֵ����䷶Χ.
                            sFill = oAttr.Value.ToUpper
                        Case "TAGTYPE" '���ݵ�������ָ������,��ֵָ��\�ַ�ָ��\�Զ��幫ʾ��.
                            sTagType = oAttr.Value.ToUpper
                        Case "TAGORIENT" '���ݵ�������ָ��ʱ���ķ���,��������,��������.
                            sTagOrient = oAttr.Value.ToUpper
                    End Select
                Next
                If sTagType = "" Then
                    sTagType = "FLOAT" 'ָ������ȱʡΪ��ֵ��
                End If
                If sTagOrient = "" Then
                    sTagOrient = "0" '���з���ȱʡΪ��������
                End If
                '���ݱ���������ͣ�ָ��������ָ�����ݣ���д��EXCEL�ؼ���
                If sTag <> String.Empty Then
                    pGetTagData(aDate, sDateType, sTag, sFill, sTagType, sTagOrient)
                    'Logger.Info("GetTagData")
                End If
            Next

            '��ȡ��ӡ����
            PrintSet = ""
            oDataNodes = oXML.SelectNodes("DataSchema/Print/Item")
            For Each oDataNode In oDataNodes
                For Each oAttr In oDataNode.Attributes
                    PrintSet = PrintSet + oAttr.Name + "=" + oAttr.Value + "|"
                Next
            Next
            PrintSet = PrintSet + ";"
            'Logger.Info(PrintSet)
            '����Excelworkbook������
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
                '��ȷ�ϵı������޸�
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

    '��������:����OWC���������.
    '--------------------------------------------------------------
    '��ڲ���˵��:
    '--------------------------------------------------------------
    'Report_Code:   ������
    'aDate      :   ָ������
    'sXML       :   OWC�ؼ��д򿪵�EXCEL����ĵ�ǰXML���д�.
    'oldXML     :   OWC�ؼ��д򿪵�EXCEL�����ԭʼXML���д�.
    'UserCode   :   ��ǰ�û��Ĺ���.
    'UserName   :   ��ǰ�û�������.
    'UserIP     :   ��ǰ�û���IP��ַ.
    '--------------------------------------------------------------
    '����ֵ     :   boolean
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
        '���뱨��ģ��
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
            'ȡÿ���������������XPATH:DataSchema/Save
            For Each oDataNode In oDataNodes
                sDateType = String.Empty
                sTag = String.Empty
                sFill = String.Empty
                sTagType = String.Empty
                sTagOrient = String.Empty

                'ȡ����������,��ָ���ַ,���ݱ�����,ָ������
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
                If sTagType = String.Empty Then 'ָ������ȱʡΪ��ֵ��
                    sTagType = "FLOAT"
                End If
                If sTagOrient = String.Empty Then  '���з���ȱʡΪ��������
                    sTagOrient = "0"
                End If
                '����ȡ�õ�����,�ͱ���Ķ��屣������
                pSaveData(aDate, sDateType, sTag, sFill, sTagType, sTagOrient, UserName, saveInfo)

            Next
            'ȫ��������Ϻ��¼������־
            If saveInfo <> String.Empty Then
                '��ȡ��ӡ����
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
                objlog.WriteInfo(String.Format("{0}[{1}]��{2}���޸��˱���:{3}������:{4}", UserName, UserCode, UserIP, Report_Name, saveInfo))
            End If

            Return True
        Catch er As Exception
            strErrInfo = ERRINFO_INSPECTREPORT_004 & er.Message
            Return False
        Finally
            SQLConn.Close()
        End Try
    End Function

    '��������aDate��ʱ������sDateType��ָ������sTagRange��ָ������sTagType��������CCData��ȡ��ָ�����ݷŵ�����aTag�У�Ȼ�����ݿ���Ӧ�ı���
    'ȡ����Щָ����Ҫȡ�ĸ�ʱ����ָ��ֵ���������������sFill,��ֵ�CCData�ϡ�
    'sTagOrient��ָ��ʱ���ʱ��ʱ������з���0ָ���������ţ�1ָ���������ţ�ȱʡ��0��
    Private Function pGetTagData(ByVal aDate As DateTime, _
                                ByVal sDateType As String, _
                                ByVal sTagRange As String, _
                                ByVal sFill As String, _
                                ByVal sTagType As String, _
                                ByVal sTagOrient As String) _
    As Boolean
        Dim sDefineRange As OWC10.Range = CCData.Range(sTagRange)
        'ȡ��ָ������
        Dim aTag As System.Array
        'aTagΪ2ά���飬�±��1��ʼ
        If sDefineRange.Rows.Count = 1 And sDefineRange.Columns.Count = 1 Then
            '��EXCEL����ֻ��һ��ʱ������ֲ���ת��������Ĵ���������������飬�ٶ������и�ֵ
            aTag = CCData.Range("A1:B1").Value 'Ŀ����������һ����ά����,�;���ֵ�޹�.
            aTag(1, 1) = sDefineRange.Value '���¸�ֵ.
            aTag(1, 2) = ""
        Else
            aTag = sDefineRange.Value
        End If

        '�������������sFill, ָ������sTagType, ��ָ��ֵ�������
        Dim oFillRange As OWC10.Range = CCData.Range(sFill)
        Dim nRowStart, nColStart As Integer
        Dim KK, JJ As Integer

        nRowStart = oFillRange.Row
        nColStart = oFillRange.Column
        '����ָ��ID��ָ��ID|�޶�������ƴ���ַ���.
        Dim sTagIDAll As String = Me.pGenerate_TagIDALL(aTag, sTagType)

        Select Case sTagType.ToUpper
            Case "FLOAT", "STR" '��ֵ���ַ�����.
                pGetData_FloatStr(aDate, sTagIDAll, nRowStart, nColStart, aTag, sTagType, sDateType, sTagOrient)
            Case "LINE1" '��������״̬ͼ1��
                pGetData_Line(sTagIDAll, nRowStart, nColStart, aTag, 1)
            Case "LINE2" '��������״̬ͼ2��
                pGetData_Line(sTagIDAll, nRowStart, nColStart, aTag, 2)
            Case "FUNC" '�Զ��庯��
                Dim sTagID As String = String.Empty
                For JJ = 0 To aTag.GetLength(0) - 1 'ָ������.
                    For KK = 0 To aTag.GetLength(1) - 1
                        sTagID = "" & aTag(JJ + 1, KK + 1)
                        If sTagID.Trim() <> "" Then
                            oFillRange = CType(CCData.Cells._Default(JJ + nRowStart, KK + nColStart), OWC10.Range)
                            oFillRange.Value = pCalcFunc(sTagID, aDate)
                        End If
                    Next
                Next
            Case "AGGREGATION", "MAX", "MIN", "AVG", "SUM", "COUNT" '�ۺϺ�����
                pGetData_Aggregation(aDate, sTagIDAll, nRowStart, nColStart, aTag, sTagType, sDateType, sTagOrient)
            Case "MAXVALUE1DATE" '���ֵ���ڵ�����
                pGetData_MaxValue1Date(aDate, sTagIDAll, nRowStart, nColStart, aTag, sTagType, sDateType)
            Case "MINVALUE1DATE" '��Сֵ���ڵ�����
                pGetData_MinValue1Date(aDate, sTagIDAll, nRowStart, nColStart, aTag, sTagType, sDateType)
            Case "SWITCHCOUNT" '�豸���ش�����
                pGetData_SwitchCount(aDate, sTagIDAll, nRowStart, nColStart, aTag, sTagType, sDateType, sTagOrient)
            Case "ONCERUNNINGDATA" '�豸���ش�����
                pGetData_OnceRunningData(aDate, sTagIDAll, nRowStart, nColStart, aTag, sTagType, sDateType, sTagOrient)
        End Select
        Return True
    End Function

    '������ֵ���ַ�����,��д��EXCEL�ؼ���
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

        '��������,������صĲ�������ֵ,��Щ����Ϊ���ݿ�������
        Dim sTable As String
        If sTagType.ToUpper = "FLOAT" Then
            '��ֵָ��
            sTable = "T_TAG_"
        ElseIf sTagType.ToUpper = "STR" Then
            '�ַ�ָ��,�ַ���ָ���,Ŀǰֻ����T_StrTag_Day��,���ұ��д�����3001004,3001005ָ��.
            '��������ָ����T_Tag_MS���в�������.
            sTable = "T_STRTAG_"
        End If

        Dim nStart, nEnd, nTagCount, nTimeCount As Integer
        Dim sBaseKey As String
        '����ָ������,ʱ����������ȡָ�����ݱ����ͣ�Сʱ����ȣ�����ʼʱ��㡢����ʱ��㡢�����ݵ���Ŀ����Ϣ��
        'ʱ����������Ϣ�洢��T_DATE_MS����.
        If Not pCalcCycleID(aDate, sDateType, sBaseKey, nStart, nEnd, nTimeCount) Then
            strErrInfo = strErrInfo & "  " & sDateType & ERRINFO_INSPECTREPORT_006
            Return False
        End If
        '�����ݿ�ȡ����Ӧ��ָ������
        Dim dtData As New DataTable("T_TAG_DATA")
        Dim dtTag As New DataTable("T_TAG_MS")
        '���ݱ���
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
        '��ֵָ����ַ�ָ��
        If nTimeCount = 1 Then
            For JJ = 0 To aTag.GetLength(0) - 1
                For KK = 0 To aTag.GetLength(1) - 1
                    sTagID = aTag(JJ + 1, KK + 1)
                    If Not (sTagID Is Nothing) Then
                        If sTagID.Trim() <> "" Then
                            oRange = CType(CCData.Cells._Default(JJ + nRowStart, KK + nColStart), OWC10.Range)
                            '&Ϊ�Զ��庯���Ŀ�ʼ��־
                            If sTagID.Trim().IndexOf("&") = 0 Then
                                oRange.Value = pCalcFunc(sTagID, aDate)
                            Else
                                dtData.DefaultView.RowFilter = String.Format("I_TAG_ID='{0}'", sTagID.Split("|")(0))  'ָ�궨���������ָ������������.��:1401001|I_Value_Man>0.1
                                dtTag.DefaultView.RowFilter = String.Format("I_TAG_ID='{0}'", sTagID.Split("|")(0)) 'ָ�궨���������ָ������������.��:1401001|I_Value_Man>0.1
                                If dtData.DefaultView.Count = 1 Then
                                    If sTagType.ToUpper <> "STR" And dtTag.DefaultView.Count = 1 Then
                                        '��������
                                        avalue = System.Math.Round(dtData.DefaultView.Item(0).Item("I_VALUE_MAN") * System.Math.Pow(10, dtTag.DefaultView.Item(0).Item("I_DIG_NUM"))) * System.Math.Pow(10, -dtTag.DefaultView.Item(0).Item("I_DIG_NUM"))
                                        oRange.Value = avalue
                                        '�Զ��ɼ������ݸı���ɫ
                                        '��I_VALUE_ORGΪ׼
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
                                            '�����豸���ָ�꣨Сʱ���ݣ�����ָ��ֵ�������ֵ����Сֵʱ�����ú�ɫ��
                                            If avalue > CDbl(dtTag.DefaultView.Item(0).Item("MAX_VALUE")) Or avalue < CDbl(dtTag.DefaultView.Item(0).Item("MIN_VALUE")) Then
                                                oRange.Font.Color = "Red"
                                            Else
                                                '����м��볬����Χ������ʾ�ɻ�ɫ
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
                                        '�ַ�ָ��
                                        oRange.Value = dtData.DefaultView.Item(0).Item("I_VALUE_MAN")
                                    End If
                                End If
                            End If
                        End If
                    End If
                Next
            Next
        Else
            '��ʱ���ʱҪ����ʱ�������з���
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
                            '��������
                            avalue = System.Math.Round(dtData.DefaultView.Item(i).Item("I_VALUE_MAN") * System.Math.Pow(10, dtTag.DefaultView.Item(0).Item("I_DIG_NUM"))) * System.Math.Pow(10, -dtTag.DefaultView.Item(0).Item("I_DIG_NUM"))
                            oRange.Value = avalue
                            '�Զ��ɼ������ݸı���ɫ
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
                                '�����豸���ָ�꣨Сʱ���ݣ�����ָ��ֵ�������ֵ����Сֵʱ�����ú�ɫ��
                                If avalue > CDbl(dtTag.DefaultView.Item(0).Item("MAX_VALUE")) Or avalue < CDbl(dtTag.DefaultView.Item(0).Item("MIN_VALUE")) Then
                                    oRange.Font.Color = "Red"
                                Else
                                    '����м��볬����Χ������ʾ�ɻ�ɫ
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
                            '�ַ�ָ��
                            oRange.Value = dtData.DefaultView.Item(i).Item("I_VALUE_MAN")
                        End If
            Next i
                End If
            Next
        End If
    End Function
    '����˵��:�ۺ�����ֵ�Ļ�ȡ.����MAX,MIN,AVG,SUM,COUNT�ȵĻ�ȡ.
    '��ڲ���:
    '           aDate     : ָ������.
    '           sTagIDALL : ָ���ַ���,����('1401001','1401002','1401003','1401004')
    '           nRowStart : �����������Ŀ�ʼ�к�.
    '           nColStart : �����������Ŀ�ʼ�к�.
    '           aTag      : ��ָ�궨��������ת�������Ķ�Ӧ�Ķ�ά����.��ʵ��ָ�궨������Ϊһ����Ԫ��ʱ,aTag��Ӧ��aTag(1, 1),aTag(1, 2)����Ԫ��,aTag(1,2)��ֵΪ"".
    '           sTagType  : ָ������,(��ֵָ��,�ַ�ָ��,�Զ��幫ʽ,һ������״̬,��������״̬,MAX,MIN,AVG,SUM��).
    '           sDateType : ʱ������,ʱ�������ɱ�T_Date_MS������.����ȷ��ָ�����ֵ��ȡֵ��Դ,ʱ�䷶Χ,�Լ���Ŀ����Ϣ.
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
        '��������,������صĲ�������ֵ,��Щ����Ϊ���ݿ�������
        Dim sTable As String
        sTable = "T_TAG_"

        Dim nStart, nEnd, nTagCount, nTimeCount As Integer
        Dim sBaseKey As String
        '����ָ������,ʱ����������ȡָ�����ݱ����ͣ�Сʱ����ȣ�����ʼʱ��㡢����ʱ��㡢�����ݵ���Ŀ����Ϣ��
        'ʱ����������Ϣ�洢��T_DATE_MS����.
        If Not pCalcCycleID(aDate, sDateType, sBaseKey, nStart, nEnd, nTimeCount) Then
            strErrInfo = strErrInfo & "  " & sDateType & ERRINFO_INSPECTREPORT_006
            Return False
        End If
        '�����ݿ�ȡ����Ӧ��ָ������
        Dim dtData As New DataTable("T_TAG_DATA")
        Dim dtTag As New DataTable("T_TAG_MS")
        '���ݱ���
        Dim sqlStatement As String
        sTable = sTable & sBaseKey.ToUpper
        '��������.
        Dim mytrans As SqlTransaction = SQLConn.BeginTransaction("CschemaAggregation")
        Dim myCommand As SqlCommand = SQLConn.CreateCommand()
        myCommand.Transaction = mytrans
        '���Ƚ�ָ��ֵ����ʱ�䷶Χд����ʱ��.
        '��Ϊ�ڶ�Сʱ�����ݽ��м�����ʱ��,���������ۼ����ݵ�ʱ��,
        'ֱ���Ե���SQL�����м�����ʱ��,���ܺܵ�.������ʱ��,�������ܵ������Ƚϴ�.
        '����ʱ,�����һ���������,ָ�����Ϊ28��ʱ,����SQLִ����Ҫһ����.
        '��������ʱ����ֻ��6��7����.
        Try
            'sqlStatement = string.Format("Select 
            'SQLʾ��Ϊ  Select  i_tag_id,I_Cycle_ID,I_Value_Man
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
            'SQLʾ��Ϊ  Select  i_tag_id,MAX(I_Value_Man) As MaxValue,Min(I_Value_Man) As MinValue,Avg(I_Value_Man) As AvgValue,Count(I_Value_Man)
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
            'ɾ������ʱ��.
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
            For KK = 0 To aTag.GetLength(1) - 1 '����ָ�궨���ά����.
                sTagID = aTag(JJ + 1, KK + 1) '������±��1��ʼ.
                If Not (sTagID Is Nothing) Then
                    If sTagID.Trim() <> String.Empty Then
                        maxRange = CType(CCData.Cells._Default(JJ + nRowStart, KK + nColStart), OWC10.Range) '�ҵ���Ӧָ�����ֵ��Ӧ�ĵ�Ԫ��.(1����Ԫ��)
                        If sTagOrient = "0" Then '��������
                            minRange = CType(CCData.Cells._Default(JJ + nRowStart + 1, KK + nColStart), OWC10.Range) '�ҵ���Ӧָ�����ֵ��Ӧ�ĵ�Ԫ��.(1����Ԫ��)
                            avgRange = CType(CCData.Cells._Default(JJ + nRowStart + 2, KK + nColStart), OWC10.Range) '�ҵ���Ӧָ�����ֵ��Ӧ�ĵ�Ԫ��.(1����Ԫ��)
                            countRange = CType(CCData.Cells._Default(JJ + nRowStart + 3, KK + nColStart), OWC10.Range) '�ҵ���Ӧָ�����ֵ��Ӧ�ĵ�Ԫ��.(1����Ԫ��)
                            regularCountRange = CType(CCData.Cells._Default(JJ + nRowStart + 4, KK + nColStart), OWC10.Range) '�ҵ���Ӧָ�����ֵ��Ӧ�ĵ�Ԫ��.(1����Ԫ��)
                        Else '������
                            minRange = CType(CCData.Cells._Default(JJ + nRowStart, KK + nColStart + 1), OWC10.Range) '�ҵ���Ӧָ�����ֵ��Ӧ�ĵ�Ԫ��.(1����Ԫ��)
                            avgRange = CType(CCData.Cells._Default(JJ + nRowStart, KK + nColStart + 2), OWC10.Range) '�ҵ���Ӧָ�����ֵ��Ӧ�ĵ�Ԫ��.(1����Ԫ��)
                            countRange = CType(CCData.Cells._Default(JJ + nRowStart, KK + nColStart + 3), OWC10.Range) '�ҵ���Ӧָ�����ֵ��Ӧ�ĵ�Ԫ��.(1����Ԫ��)
                            regularCountRange = CType(CCData.Cells._Default(JJ + nRowStart, KK + nColStart + 4), OWC10.Range) '�ҵ���Ӧָ�����ֵ��Ӧ�ĵ�Ԫ��.(1����Ԫ��)
                        End If
                        'oRange = CType(CCData.Cells._Default(JJ + nRowStart, KK + nColStart), OWC10.Range) '�ҵ���Ӧָ�����ֵ��Ӧ�ĵ�Ԫ��.(1����Ԫ��)

                        dtData.DefaultView.RowFilter = String.Format("I_TAG_ID='{0}'", sTagID.Split("|")(0))
                        dtTag.DefaultView.RowFilter = String.Format("I_TAG_ID='{0}'", sTagID.Split("|")(0))
                        If dtData.DefaultView.Count = 1 Then '���ָ��Ĳ���ֵ��¼��һ����¼.
                            '����ָ�����ֵ���˹�ֵ(�����˹��������˼,��Ϊ���˹��޸ĵ�),ԭʼֵ�ı���.
                            Dim maxValue, minValue, avgValue, countValue, regularCountValue
                            maxValue = dtData.DefaultView.Item(0).Item("MaxValue")
                            minValue = dtData.DefaultView.Item(0).Item("MinValue")
                            avgValue = dtData.DefaultView.Item(0).Item("AvgValue")
                            countValue = dtData.DefaultView.Item(0).Item("CountValue")
                            regularCountValue = dtData.DefaultView.Item(0).Item("Regular_CountValue")
                            If sTagType.ToUpper <> "STR" And dtTag.DefaultView.Count = 1 Then '���ָ������(�ڱ������ж���)�����ַ�ָ��,������T_Tag_MS�д��ڼ�¼.
                                Dim digNum As Object
                                digNum = dtTag.DefaultView.Item(0).Item("I_DIG_NUM")
                                '��������,������T_Tag_MS�ж����ָ���С���㱣��λ��.
                                maxValue = System.Math.Round(maxValue * System.Math.Pow(10, digNum)) * System.Math.Pow(10, -digNum)
                                minValue = System.Math.Round(minValue * System.Math.Pow(10, digNum)) * System.Math.Pow(10, -digNum)
                                avgValue = System.Math.Round(avgValue * System.Math.Pow(10, digNum)) * System.Math.Pow(10, -digNum)
                                maxRange.Value = maxValue
                                minRange.Value = minValue
                                avgRange.Value = avgValue
                                countRange.Value = countValue
                                regularCountRange.Value = regularCountValue
                            Else '�ַ�ָ��,���߸�ָ��û����T_Tag_MS�ж���.
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
    '��ȡָ�����ֵ���ֵ���ڵĵ�һ������.

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
        '��������,������صĲ�������ֵ,��Щ����Ϊ���ݿ�������
        Dim sTable As String = "T_TAG_"

        Dim nStart, nEnd, nTagCount, nTimeCount As Integer
        Dim sBaseKey As String
        '����ָ������,ʱ����������ȡָ�����ݱ����ͣ�Сʱ����ȣ�����ʼʱ��㡢����ʱ��㡢�����ݵ���Ŀ����Ϣ��
        'ʱ����������Ϣ�洢��T_DATE_MS����.
        If Not pCalcCycleID(aDate, sDateType, sBaseKey, nStart, nEnd, nTimeCount) Then
            strErrInfo = String.Format("{0}  {1}  {2}", strErrInfo, sDateType, ERRINFO_INSPECTREPORT_006)
            Return False
        End If
        '�����ݿ�ȡ����Ӧ��ָ������
        Dim dtData As New DataTable("T_TAG_DATA")
        Dim dtTag As New DataTable("T_TAG_MS")
        '���ݱ���
        Dim sSQL As String
        sTable = sTable & sBaseKey.ToUpper
        'SQLʾ��Ϊ  Select  i_tag_ID,dbo.HourCycleID2DateTime(Min(I_cycle_ID)) As I_Cycle_ID
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
            For KK = 0 To aTag.GetLength(1) - 1 '����ָ�궨���ά����.
                sTagID = aTag(JJ + 1, KK + 1) '������±��1��ʼ.
                If Not (sTagID Is Nothing) Then
                    If sTagID.Trim() <> String.Empty Then
                        oRange = CType(CCData.Cells._Default(JJ + nRowStart, KK + nColStart), OWC10.Range) '�ҵ���Ӧָ�����ֵ��Ӧ�ĵ�Ԫ��.(1����Ԫ��)
                        '&Ϊ�Զ��庯���Ŀ�ʼ��־
                        If sTagID.Trim().IndexOf("&") = 0 Then
                            oRange.Value = pCalcFunc(sTagID, aDate) 'Ŀǰ���Զ��庯����Ҫ�������ڵĴ���.
                        Else
                            dtData.DefaultView.RowFilter = String.Format("I_TAG_ID='{0}'", sTagID.Split("|".ToCharArray())(0))
                            'dtTag.DefaultView.RowFilter = String.Format("I_TAG_ID='{0}'", sTagID)
                            If dtData.DefaultView.Count = 1 Then '���ָ��Ĳ���ֵ��¼��һ����¼.
                                '����ָ�����ֵ���˹�ֵ(�����˹��������˼,��Ϊ���˹��޸ĵ�),ԭʼֵ�ı���.
                                Dim valueMan
                                valueMan = dtData.DefaultView.Item(0).Item("MaxDate") '��ʱ��I_Value_Man��I_Cycle_ID.
                                oRange.Value = valueMan
                            End If
                        End If
                    End If
                End If
            Next
        Next
    End Function
    '��ȡָ�����ֵ��Сֵ���ڵĵ�һ������.
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
        '��������,������صĲ�������ֵ,��Щ����Ϊ���ݿ�������
        Dim sTable As String = "T_TAG_"

        Dim nStart, nEnd, nTagCount, nTimeCount As Integer
        Dim sBaseKey As String
        '����ָ������,ʱ����������ȡָ�����ݱ����ͣ�Сʱ����ȣ�����ʼʱ��㡢����ʱ��㡢�����ݵ���Ŀ����Ϣ��
        'ʱ����������Ϣ�洢��T_DATE_MS����.
        If Not pCalcCycleID(aDate, sDateType, sBaseKey, nStart, nEnd, nTimeCount) Then
            strErrInfo = strErrInfo & "  " & sDateType & ERRINFO_INSPECTREPORT_006
            Return False
        End If
        '�����ݿ�ȡ����Ӧ��ָ������
        Dim dtData As New DataTable("T_TAG_DATA")
        Dim dtTag As New DataTable("T_TAG_MS")
        '���ݱ���
        Dim sSQL As String
        sTable = sTable & sBaseKey.ToUpper

        'SQLʾ��Ϊ  Select  i_tag_ID,dbo.HourCycleID2DateTime(Min(I_cycle_ID)) As I_Cycle_ID
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
            For KK = 0 To aTag.GetLength(1) - 1 '����ָ�궨���ά����.
                sTagID = aTag(JJ + 1, KK + 1) '������±��1��ʼ.
                If Not (sTagID Is Nothing) Then
                    If sTagID.Trim() <> String.Empty Then
                        oRange = CType(CCData.Cells._Default(JJ + nRowStart, KK + nColStart), OWC10.Range) '�ҵ���Ӧָ�����ֵ��Ӧ�ĵ�Ԫ��.(1����Ԫ��)
                        '&Ϊ�Զ��庯���Ŀ�ʼ��־
                        If sTagID.Trim().IndexOf("&") = 0 Then
                            oRange.Value = pCalcFunc(sTagID, aDate) 'Ŀǰ���Զ��庯����Ҫ�������ڵĴ���.
                        Else
                            dtData.DefaultView.RowFilter = String.Format("I_TAG_ID='{0}'", sTagID.Split("|".ToCharArray())(0))
                            'dtTag.DefaultView.RowFilter = String.Format("I_TAG_ID='{0}'", sTagID)
                            If dtData.DefaultView.Count = 1 Then '���ָ��Ĳ���ֵ��¼��һ����¼.
                                '����ָ�����ֵ���˹�ֵ(�����˹��������˼,��Ϊ���˹��޸ĵ�),ԭʼֵ�ı���.
                                Dim valueMan
                                valueMan = dtData.DefaultView.Item(0).Item("MinDate") '��ʱ��I_Value_Man��I_Cycle_ID.
                                oRange.Value = valueMan
                            End If
                        End If
                    End If
                End If
            Next
        Next
    End Function
    '�����豸��ǰ�������ĸ����ϼ����豸������״̬,��д��EXCEL�ؼ���
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
    'ȡ����������Shop_Codes������Line�ε��豸������״̬
    Private Function GetDevLine(ByVal Shop_Codes As String, _
                                ByVal Line As Int16) _
    As DataTable
        Dim strSQL As String = ""
        Dim data As New DataTable
        '��data����ṹ

        data = GetShopDevsByShopCodesLine(Shop_Codes, 10000)

        Dim j, k, l As Integer
        Dim gstatus1, gstatus2, gstatus12, sstatus1, sstatus2, sstatus12 As Short

        Dim dtGlobal As New DataTable
        Dim dtShop As New DataTable
        Dim oAdapter As New SqlDataAdapter("SELECT A.SHOP_CODE,A.SHOP_NAME,A.SHOP_TYPE,A.SWITCH1,A.SWITCH2,A.JOIN12,A.REMARK FROM D_SHOP_SWITCH A WHERE A.SHOP_TYPE = 1 ORDER BY A.SHOP_CODE ", SQLConn)
        oAdapter.Fill(dtGlobal)
        oAdapter.SelectCommand.CommandText = "SELECT A.SHOP_CODE,A.SHOP_NAME,A.SHOP_TYPE,A.SWITCH1,A.SWITCH2,A.JOIN12,A.REMARK FROM D_SHOP_SWITCH A WHERE A.SHOP_CODE IN (" & Shop_Codes.Trim() & ")"
        oAdapter.Fill(dtShop)

        '***********�������豸�������ĸ�����***********
        'ȡ���ܿ��ƿ��ص�״̬��Ϣ
        If dtGlobal.Rows.Count > 0 Then
            GetSwitchStatus(dtGlobal.Rows(0), gstatus1, gstatus2, gstatus12)
        Else
            gstatus1 = 1
            gstatus2 = 1
            gstatus12 = 0
        End If

        If Line = 1 Then
            '********��ǰ���ڶ�ȡ������1���ϵ��豸��Ϣ********
            'ֻ��1���ܿ��رպ�ʱ�����豸������1����
            If gstatus1 = 1 Then
                If gstatus12 = 1 And gstatus2 = 0 Then
                    '12�����߿��رպϣ�2���ܿ��ƿ��ضϿ�ʱ�������豸��������1���ϡ�
                    data = GetShopDevsByShopCodesLine(Shop_Codes)
                ElseIf gstatus12 = 0 Then
                    '12�����߿��ضϿ���1��2���豸�ֿ�����
                    For j = 0 To dtShop.Rows.Count - 1
                        GetSwitchStatus(dtShop.Rows(j), sstatus1, sstatus2, sstatus12)
                        'ֻ�иó���1�ο��رպ�ʱ�����豸������1����
                        If sstatus1 = 1 Then
                            Dim dt As DataTable
                            If sstatus12 = 1 And sstatus2 = 0 Then
                                '���伶12�����߿��رպϣ�2�ο��ƿ��ضϿ�ʱ���ó���������豸��������1���ϡ�
                                dt = GetShopDevsByShopCodesLine("'" & CStr(dtShop.Rows(j).Item("Shop_Code")) & "'")
                            ElseIf sstatus12 = 0 Then
                                '���伶12�����߿��ضϿ���1��2���豸�ֿ�����
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
            '********��ǰ���ڶ�ȡ������2���ϵ��豸��Ϣ********
            'ֻ��2���ܿ��رպ�ʱ�����豸������2����
            If gstatus2 = 1 Then
                If gstatus12 = 1 And gstatus1 = 0 Then
                    '12�����߿��رպϣ�1���ܿ��ƿ��ضϿ�ʱ�������豸��������2���ϡ�
                    data = GetShopDevsByShopCodesLine(Shop_Codes)
                ElseIf gstatus12 = 0 Then
                    '12�����߿��ضϿ���1��2���豸�ֿ�����
                    For j = 0 To dtShop.Rows.Count - 1
                        GetSwitchStatus(dtShop.Rows(j), sstatus1, sstatus2, sstatus12)
                        'ֻ�иó���2�ο��رպ�ʱ�����豸������2����
                        If sstatus2 = 1 Then
                            Dim dt As DataTable
                            If sstatus12 = 1 And sstatus1 = 0 Then
                                '���伶12�����߿��رպϣ�1�ο��ƿ��ضϿ�ʱ���ó���������豸��������2���ϡ�
                                dt = GetShopDevsByShopCodesLine("'" & CStr(dtShop.Rows(j).Item("Shop_Code")) & "'")
                            ElseIf sstatus12 = 0 Then
                                '���伶12�����߿��ضϿ���1��2���豸�ֿ�����
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

        '*********�������豸������״̬***********
        Dim dev_codes As String = ""
        For j = 0 To data.Rows.Count - 1
            Dim dev_code As String = FilterDBNull(data.Rows(j).Item("Dev_Code"))
            If dev_code <> "" Then
                dev_codes = dev_codes & "'" & dev_code & "',"
            End If
        Next
        Dim dtStatus As New DataTable
        If dev_codes <> "" Then
            '��ȡ��������״̬
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
                '�豸ȱʡ��״̬��"ֹͣ"
                data.Rows(j).Item("Status") = 0
            End If
        Next

        Return data
    End Function
    'ȡ������ΪaDate���ɹ�˾���õ��豸��ͣ���
    Private Sub GetSwitchStatus(ByVal aRow As DataRow, _
                                ByRef status1 As Short, _
                                ByRef status2 As Short, _
                                ByRef status12 As Short)
        Dim i As Integer
        Dim sTagIDAll, switch1, switch2, join12 As String

        '����ȱʡ״̬
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
        'ȥ�����һ��,
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
                '����ĳЩԭ����ܻ���D_RUN_STATUS����һ��ָ���ж��м�¼,ֻȡ��һ��Ϊ���µ�״̬
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
    ' ��ѯ��Shop_Code�����¹�����Line���ϵ��豸��Ϣ�����û������Line�����ѯ���ó����µ�ȫ���豸��
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
    '��ÿ������ı�������,��������
    '����
    '1 aDate  ����ʱ��,2  sDateType ʱ������ 3 sTagRange ָ������ 4 sSaveRange Ҫ�������������  5 sTagType ָ������ 6 sTagOrient ʱ������з��� 7 saveInfo Ҫд����־�еı�����Ϣ
    Private Function pSaveData(ByVal aDate As Date, _
                                ByVal sDateType As String, _
                                ByVal sTagRange As String, _
                                ByVal sSaveRange As String, _
                                ByVal sTagType As String, _
                                ByVal sTagOrient As String, _
                                ByVal username As String, _
                                ByRef saveInfo As String) _
    As Boolean
        '������ڱ������ݵĴ洢������
        Dim saveprocname, delprocname As String
        If sTagType.ToUpper = "FLOAT" Then
            '��ֵָ��
            saveprocname = "sp_SaveData"
            delprocname = "sp_DeleteData"
        ElseIf sTagType.ToUpper = "STR" Then
            '�ַ�ָ��
            saveprocname = "sp_SaveStrTagData"
            delprocname = "sp_DeleteStrTagData"
        Else
            strErrInfo = strErrInfo & "  " & ERRINFO_INSPECTREPORT_005
            Return False
        End If

        Dim nStart, nEnd, nTimeCount, nTagCount, Rows, Cols, i, j As Integer
        Dim sBaseKey, sTagID, curValue, oldValue As String
        '������ֹʱ���
        If sTagType.ToUpper = "FLOAT" Or sTagType.ToUpper = "STR" Then
            If Not pCalcCycleID(aDate, sDateType, sBaseKey, nStart, nEnd, nTimeCount) Then
                strErrInfo = strErrInfo & "  " & sDateType & ERRINFO_INSPECTREPORT_006
                Return False
            End If
        End If

        Dim aTagID As System.Array
        Dim aData, oldData, aPKId, aFormula As System.Array
        Dim oSaveCmd, oDelCmd As SqlClient.SqlCommand

        '�޸Ĺ���ָ���ţ��á�,������
        Dim modtagid As String = ""
        Dim wherestr_func As String = " (1 <> 1) "
        Dim modcycleid(0) As Integer
        modcycleid(0) = -1
        Dim modified As Boolean

        Try
            '��������±��1��ʼ
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

            '����Ҫȡ���ݵ�ָ���ţ���,����
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
                '������ݵĹ��̣�����Ϊ�ձ�ʾɾ�����ݣ�
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
                    'ȡ����������
                    For i = 1 To Rows
                        For j = 1 To Cols
                            '��ÿ�����ݽ��б���
                            If (Trim("" & aTagID(i, j)) <> "") Then
                                '��ѯָ������
                                tagname = ""
                                dtTag.DefaultView.RowFilter = "I_TAG_ID='" & CStr(aTagID(i, j)) & "'"
                                If dtTag.DefaultView.Count > 0 Then
                                    tagname = dtTag.DefaultView.Item(0).Item("I_TAG_NAME")
                                End If
                                '�����ݺ�ԭ�������ݲ�ͬ�Ž��б���,*****�й�ʽʱ���뱣��*******
                                'Ҫ��ת����string���ܽ��бȽϣ���Ϊ�������һ������ֵ���Ƚϵ�ʱ���ת�������ֽ��бȽϣ����������һ��Ϊ""������ת������
                                hasformula = False
                                If CStr(aFormula(i, j)) <> "" Then
                                    If CStr(aFormula(i, j)).Chars(0) = "=" Then
                                        hasformula = True
                                    End If
                                End If
                                If (CStr(aFormula(i, j)) <> "") Or (CStr(aData(i, j)) <> CStr(oldData(i, j))) Then
                                    If Trim(aData(i, j)) <> "" Then
                                        Try
                                            '��������������ʱ�Ƚ���ת�������ж����������Ƿ�׼ȷ��
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

                                    '�����ֵ�Ķ��ˣ���д�޸���־
                                    If CStr(aData(i, j)) <> CStr(oldData(i, j)) Then
                                        saveInfo = saveInfo + ControlChars.NewLine + "   " + tagname + "[" + CStr(aTagID(i, j)) + "] " + pCalcDateTimeStr(nEnd, sBaseKey) + " �����ݴ� (" + CStr(oldData(i, j)) + ") �ĳ� (" + CStr(aData(i, j)) + ")"
                                        oRange = CType(oldXMLData.Cells._Default(i - 1 + nRowStart, j - 1 + nColStart), OWC10.Range)
                                        oRange.Locked = False
                                        oRange.Interior.Color = "#EEE8AA"
                                    End If
                                    '��¼���޸ĵ���Ϣ
                                    modtagid = modtagid + "'" + CStr(aTagID(i, j)) + "',"
                                    wherestr_func = wherestr_func + " OR (FUNC LIKE '%" + CStr(aTagID(i, j)) + "%')"
                                    ReDim Preserve modcycleid(modcycleid.GetLength(0))
                                    modcycleid(modcycleid.GetUpperBound(0)) = nEnd
                                End If
                            End If
                        Next
                    Next
                Else
                    'ȡ����������
                    For j = 1 To nTagCount
                        If sTagOrient = "0" Then
                            sTagID = "" & aTagID(1, j)
                        Else
                            sTagID = "" & aTagID(j, 1)
                        End If
                        If sTagID.Trim <> "" Then
                            modified = False
                            '��ѯָ������
                            tagname = ""
                            dtTag.DefaultView.RowFilter = "I_TAG_ID='" & sTagID.Trim & "'"
                            If dtTag.DefaultView.Count > 0 Then
                                tagname = dtTag.DefaultView.Item(0).Item("I_TAG_NAME")
                            End If
                            For i = 1 To nTimeCount
                                hasformula = False
                                If sTagOrient = "0" Then
                                    '��������
                                    curValue = CStr(aData(i, j))
                                    oldValue = CStr(oldData(i, j))
                                    If CStr(aFormula(i, j)) <> "" Then
                                        If CStr(aFormula(i, j)).Chars(0) = "=" Then
                                            hasformula = True
                                        End If
                                    End If
                                    oRange = CType(oldXMLData.Cells._Default(i + nRowStart - 1, j + nColStart - 1), OWC10.Range)
                                Else
                                    '��������
                                    curValue = CStr(aData(j, i))
                                    oldValue = CStr(oldData(j, i))
                                    If CStr(aFormula(j, i)) <> "" Then
                                        If CStr(aFormula(j, i)).Chars(0) = "=" Then
                                            hasformula = True
                                        End If
                                    End If
                                    oRange = CType(oldXMLData.Cells._Default(j + nRowStart - 1, i + nColStart - 1), OWC10.Range)
                                End If
                                '*****�й�ʽʱ���뱣��*******,�����ݺ�ԭ�������ݲ�ͬ�Ž��б���
                                If hasformula Or (curValue <> oldValue) Then
                                    '���㵱ǰ��I_CYCLE_ID
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
                                            '��������������ʱ�Ƚ���ת�������ж����������Ƿ�׼ȷ��
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
                                    '�����ֵ�Ķ��ˣ���д�޸���־
                                    modified = True
                                    If curValue <> oldValue Then
                                        saveInfo = saveInfo + ControlChars.NewLine + "   " + tagname + "[" + sTagID + "] " + pCalcDateTimeStr(cur_cycle_id, sBaseKey) + " �����ݴ� (" + oldValue + ") �ĳ� (" + curValue + ")"
                                        oRange.Locked = False
                                        oRange.Interior.Color = "#EEE8AA"
                                    End If
                                    ReDim Preserve modcycleid(modcycleid.GetLength(0))
                                    modcycleid(modcycleid.GetUpperBound(0)) = nStart + i - 1
                                End If
                            Next
                            '��¼���޸ĵ�ָ����
                            modtagid = modtagid + "'" + sTagID + "',"
                            wherestr_func = wherestr_func + " OR (FUNC LIKE '%" + sTagID + "%')"
                        End If
                    Next
                End If

            End If

            '��������
            Dim calcres As String
            If modtagid <> "'" And modtagid <> "" Then
                'ȥ�����һ����,��,�ڼ���'
                modtagid = modtagid.Substring(0, modtagid.Length - 1)
                Dim objlog As New ApplicationLog
                objlog.WriteInfo("��ʼ����")
                Dim reCalcCmd As SqlClient.SqlCommand

                '����ϳ�ָ��
                Dim comTagTable As Data.DataTable
                Dim comTagAdapter As SqlClient.SqlDataAdapter
                comTagTable = New Data.DataTable("COMTAG")
                '��ѯ����ʽ�к����޸Ĺ�ָ���Сʱ���졢�¡���ϳ�ָ��
                comTagAdapter = New SqlClient.SqlDataAdapter("SELECT I_TAG_ID FROM T_TAG_MS WHERE ((I_TAG_TYPE = '121') OR (I_TAG_TYPE = '122') OR (I_TAG_TYPE = '123') OR (I_TAG_TYPE = '124')) AND (" + wherestr_func + ")", SQLConn)
                comTagAdapter.Fill(comTagTable)
                If comTagTable.Rows.Count > 0 Then
                    Try
                        Dim comtagid As String = ""
                        For i = 1 To comTagTable.Rows.Count
                            comtagid = comtagid + "'" + comTagTable.Rows(i - 1).Item("I_TAG_ID") + "',"
                        Next
                        comtagid = comtagid.Substring(0, comtagid.Length - 1)
                        '�����ձ����±����걨ʱҪ���漰���ĺϳ�ָ��Ҳ��Ӧ������һ��(Ҫ��ͷβ��'ȥ��)
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
                        objlog.WriteInfo("�ϳ�ָ���������")
                    Catch ex As Exception
                        '�˴��б�0������д����־��̫����
                        objlog.WriteInfo("�ϳ�ָ���������")
                    Finally
                        If Not reCalcCmd Is Nothing Then
                            reCalcCmd.Dispose()
                        End If
                    End Try
                End If
                '���޸������켰��ǰ��Сʱ����ʱҪ������յ��ձ�����
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
                        objlog.WriteInfo(Format(aDate, "yyyy-MM-dd") + "�ձ��������")
                    Catch ex As Exception
                        objlog.WriteInfo(Format(aDate, "yyyy-MM-dd") + "�ձ��������" + ex.Message + " �޸ĵ�ָ�꣺ " + modtagid)
                    Finally
                        If Not reCalcCmd Is Nothing Then
                            reCalcCmd.Dispose()
                        End If
                    End Try
                End If
                '���޸����ϸ��¼���ǰ��Сʱ��������ʱҪ������µ��±�����
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
                        objlog.WriteInfo(Format(aDate, "yyyyMM") + "�±��������")
                    Catch ex As Exception
                        objlog.WriteInfo(Format(aDate, "yyyyMM") + "�±��������" + ex.Message)
                    Finally
                        If Not reCalcCmd Is Nothing Then
                            reCalcCmd.Dispose()
                        End If
                    End Try
                End If
                '���޸���ȥ�꼰��ǰ��Сʱ���ջ�������ʱҪ���������걨����
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
                        objlog.WriteInfo(aDate.Year.ToString + "�걨�������")
                    Catch ex As Exception
                        objlog.WriteInfo(aDate.Year.ToString + "�걨�������" + ex.Message)
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
            '�ͷ���Դ
            If Not oSaveCmd Is Nothing Then
                oSaveCmd.Dispose()
            End If
            If Not oDelCmd Is Nothing Then
                oDelCmd.Dispose()
            End If
        End Try

    End Function
    '��ѯ����������һ��״̬:-1 û�ҵ�, 1 �޸�, 2 ȷ��, 3 ȡ��
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
    '��ѯ����Ĳ�����¼
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
    '���ӱ���Ĳ�����¼
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
            strErrInfo = " ���������Ϣ����: " & er.Message
            Return False
        End Try

    End Function
    '��ѯ����Ĳ�����¼
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
    '���ݱ�������sDateType��ѯ��T_DATE_MS�������������sBaseKey��Ȼ���ϵ�ǰ����ʱ��aDate��
    '������ñ���Ҫͳ�ƵĿ�ʼʱ���nStart������ʱ���nEnd����ʱ�������
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
        'ʱ����������ΪI_COUNTΪ0�����Զ��㣬����Ϊ��ֵ�����ڼ��ȱ���ʱ�����Ӧ��Ϊ1�����ֱ����nEnd - nStart����Ϊ3��
        nTimeCount = dtDateType.Rows(0).Item("I_COUNT")

        Select Case sBaseKey.ToUpper
            Case "MIN15"
               
            Case "HOUR"
                '��T_TAG_HOUR���е�ǰСʱ���Դ�2002/01/01��ʼ��Сʱ������ʽ��ţ�
                '����ֶ�I_STARTΪ-100����ʼСʱΪ���������·ݵĵ�һ��Сʱ��
                '����ֶ�I_STARTΪ-200,��ʼСʱΪ����������ݵĵ�һ��Сʱ;
                '����ֶ�I_START<=0����ʼСʱΪ��ʱ��ǰI_STARTСʱ�����I_STARTΪ����ֵ����ʼСʱΪ���յĵ�I_STARTСʱ��
                '����ֶ�I_ENDΪ-100�������СʱΪ���������·ݵ����һ��Сʱ��
                '����ֶ�I_ENDΪ0�������СʱΪ��ʱ��ǰI_ENDСʱ1������ֶ�I_ENDΪ����ֵ�������СʱΪ���յĵ�I_ENDСʱ��
                '����ҹ�࣬����ʱ��Ϊ�ڶ�������ϣ�����Ҫ�ѽ���ʱ�����24��
                nStart = dtDateType.Rows(0).Item("I_START")
                If nStart = -100 Then
                    nStart = (DateDiff(DateInterval.Day, BaseDate, aDate) - aDate.Day + 1) * 24 + 1
                ElseIf nStart = -200 Then '��ʼСʱΪ����������ݵĵ�һ��Сʱ.
                    nStart = (DateDiff(DateInterval.Day, BaseDate, aDate) - aDate.DayOfYear + 1) * 24 + 1
                ElseIf nStart = -300 Then '��ʼСʱΪ����������ݵĵ�һ��Сʱ.
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

                If nEnd = -100 Then '���������·ݵ����һ��Сʱ.
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
                '��T_TAG_DAY���е�ǰ������yyyyMMdd����ʽ��ţ�
                '����ֶ�I_STARTΪ-200����ʼ����Ϊ����������ݵĵ�һ�죻
                '����ֶ�I_START<=0����ʼ����Ϊ���յ�ǰI_START�죻���I_STARTΪ����ֵ����ʼ����Ϊ���������·ݵĵ�I_START�졣
                '����ֶ�I_END<=0�����������Ϊ���յ�ǰI_END�죻����ֶ�I_ENDΪ-100�����������Ϊ���������·ݵ����һ�죻
                '����ֶ�I_ENDΪ-200�����������Ϊ����������ݵ����һ�죻
                '���I_ENDΪ����ֵ�����������Ϊ���������·ݵĵ�I_END�졣
                nStart = dtDateType.Rows(0).Item("I_START")
                If nStart = -200 Then
                    nStart = aDate.Year * 10000 + 101
                    If DateTime.IsLeapYear(aDate.Year) Then
                        nTimeCount = 366
                    Else
                        nTimeCount = 365
                    End If
                ElseIf nStart = -300 Then '�������ڼ��ȵĵ�һ��.
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
            Case "DAY_L"    '�ϸ��µ��ձ���
                '��T_TAG_DAY���е�ǰ������yyyyMMdd����ʽ��ţ�
                '����ֶ�I_START<=0����ʼ����Ϊ���յ�ǰI_START�죻���I_STARTΪ����ֵ����ʼ����Ϊ���������·ݵĵ�I_START�졣
                '����ֶ�I_END<=0�����������Ϊ���յ�ǰI_END�죻����ֶ�I_ENDΪ-100�����������Ϊ���������·ݵ����һ�죻
                '���I_ENDΪ����ֵ�����������Ϊ���������·ݵĵ�I_END�졣
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
            Case "WEEK" '�ܱ������ݴ������T_TAG_DAY�У������й������Ǵ���һ��ʼ���������ϵ����Ǵ����տ�ʼ������Ҫע�⿪ʼ���ڣ�
                '��T_TAG_DAY���е�ǰ������yyyyMMdd����ʽ��ţ�
                '����ֶ�I_START<=0����ʼ����Ϊ���յ�ǰI_START�죻���I_STARTΪ����ֵ����ʼ����Ϊ�����������ڵĵ�I_START�졣
                '����ֶ�I_END<=0�����������Ϊ���յ�ǰI_END�죻���I_ENDΪ����ֵ�����������Ϊ���������·ݵĵ�I_END�졣
                sBaseKey = "DAY"
                nStart = dtDateType.Rows(0).Item("I_START")
                Dim firstdate As DateTime '���ܵĵ�һ�죺����
                firstdate = aDate.AddDays(-aDate.DayOfWeek())
                If nStart > 0 Then
                    nStart = CInt(Format(firstdate.AddDays(nStart), "yyyyMMdd")) '���ܵĵ�I_START��
                Else
                    nStart = CInt(Format(aDate.AddDays(nStart), "yyyyMMdd"))
                End If
                nEnd = dtDateType.Rows(0).Item("I_END")
                If nEnd > 0 Then
                    nEnd = CInt(Format(firstdate.AddDays(nEnd), "yyyyMMdd")) '���ܵĵ�nEnd��
                Else
                    nEnd = CInt(Format(aDate.AddDays(nEnd), "yyyyMMdd"))
                End If
            Case "WEEK_L" '���ܱ������ݴ������T_TAG_DAY��
                '��T_TAG_DAY���е�ǰ������yyyyMMdd����ʽ��ţ�
                '����ֶ�I_START<=0����ʼ����Ϊ���յ�ǰI_START�죻���I_STARTΪ����ֵ����ʼ����Ϊ�����������ڵĵ�I_START�졣
                '����ֶ�I_END<=0�����������Ϊ���յ�ǰI_END�죻���I_ENDΪ����ֵ�����������Ϊ���������·ݵĵ�I_END�졣
                sBaseKey = "DAY"
                nStart = dtDateType.Rows(0).Item("I_START")
                Dim firstdate As DateTime '���ܵĵ�һ�죺����
                firstdate = aDate.AddDays(-aDate.DayOfWeek() - 7)
                If nStart > 0 Then
                    nStart = CInt(Format(firstdate.AddDays(nStart), "yyyyMMdd")) '���ܵĵ�I_START��
                Else
                    nStart = CInt(Format(aDate.AddDays(nStart - 7), "yyyyMMdd"))
                End If
                nEnd = dtDateType.Rows(0).Item("I_END")
                If nEnd > 0 Then
                    nEnd = CInt(Format(firstdate.AddDays(nEnd), "yyyyMMdd")) '���ܵĵ�nEnd��
                Else
                    nEnd = CInt(Format(aDate.AddDays(nEnd - 7), "yyyyMMdd"))
                End If
            Case "MONTH"
                '��T_TAG_MONTH���е�ǰ������yyyyMM����ʽ��ţ�
                '����ֶ�I_START<=0����ʼ�·�Ϊ�������ڵ��·ݵ�ǰI_START���£����I_STARTΪ����ֵ����ʼ����Ϊ����������ݵĵ�I_START�¡�
                '����ֶ�I_END<=0�����������Ϊ�������ڵ��·ݵ�ǰI_END���£����I_ENDΪ����ֵ�����������Ϊ����������ݵĵ�I_END�¡�
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
            Case "MONTH_L"   'ȥ����±�������
                '��T_TAG_MONTH���е�ǰ������yyyyMM����ʽ��ţ�
                '����ֶ�I_START<=0����ʼ�·�Ϊȥ��������ڵ��·ݵ�ǰI_START���£����I_STARTΪ����ֵ����ʼ����Ϊȥ�����������ݵĵ�I_START�¡�
                '����ֶ�I_END<=0�����������Ϊȥ��������ڵ��·ݵ�ǰI_END���£����I_ENDΪ����ֵ�����������Ϊȥ�����������ݵĵ�I_END�¡�
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
                '��T_TAG_YEAR���е�ǰ������yyyy����ʽ��ţ�
                '��ʼ���Ϊ�������ڵ����+I_START���������Ϊ�������ڵ����+I_END��
                nStart = aDate.Year + dtDateType.Rows(0).Item("I_START")
                nEnd = aDate.Year + dtDateType.Rows(0).Item("I_END")
        End Select
        If nTimeCount = 0 Then
            nTimeCount = nEnd - nStart + 1
        End If
        dtDateType.Dispose()
        Return True
    End Function
    '�����Զ��庯��.
    Private Function pCalcFunc(ByVal aFunc As String, ByVal aDate As DateTime) As String
        Dim resstr, weekstr As String

        Select Case aDate.DayOfWeek
            Case DayOfWeek.Monday : weekstr = "һ"
            Case DayOfWeek.Tuesday : weekstr = "��"
            Case DayOfWeek.Wednesday : weekstr = "��"
            Case DayOfWeek.Thursday : weekstr = "��"
            Case DayOfWeek.Friday : weekstr = "��"
            Case DayOfWeek.Saturday : weekstr = "��"
            Case DayOfWeek.Sunday : weekstr = "��"
        End Select
        Dim i As Integer = aFunc.IndexOf("&")
        If i > 0 Then
            resstr = aFunc.Substring(0, i) + aFunc.Substring(i + 1)
        Else
            resstr = aFunc.Substring(1)
        End If
        'ת��������
        resstr = resstr.Replace("[yyyy]", Format(aDate, "yyyy"))
        resstr = resstr.Replace("[MM]", Format(aDate, "MM"))
        resstr = resstr.Replace("[dd]", Format(aDate, "dd"))
        'ת��������
        resstr = resstr.Replace("[yy]", Format(aDate, "yy"))
        resstr = resstr.Replace("[M]", Format(aDate, "%M"))
        resstr = resstr.Replace("[d]", Format(aDate, "%d"))
        'ת������
        resstr = resstr.Replace("[w]", weekstr)
        Dim firstdate As DateTime '���ܵĵ�һ�죺����
        firstdate = aDate.AddDays(-aDate.DayOfWeek())
        '�й������ڣ���һ--����
        '����һ������
        resstr = resstr.Replace("[w1yyyy]", Format(firstdate.AddDays(1), "yyyy"))
        resstr = resstr.Replace("[w1MM]", Format(firstdate.AddDays(1), "MM"))
        resstr = resstr.Replace("[w1dd]", Format(firstdate.AddDays(1), "dd"))
        resstr = resstr.Replace("[w1yy]", Format(firstdate.AddDays(1), "yy"))
        resstr = resstr.Replace("[w1M]", Format(firstdate.AddDays(1), "%M"))
        resstr = resstr.Replace("[w1d]", Format(firstdate.AddDays(1), "%d"))
        '�����յ�����
        resstr = resstr.Replace("[w7yyyy]", Format(firstdate.AddDays(7), "yyyy"))
        resstr = resstr.Replace("[w7MM]", Format(firstdate.AddDays(7), "MM"))
        resstr = resstr.Replace("[w7dd]", Format(firstdate.AddDays(7), "dd"))
        resstr = resstr.Replace("[w7yy]", Format(firstdate.AddDays(7), "yy"))
        resstr = resstr.Replace("[w7M]", Format(firstdate.AddDays(7), "%M"))
        resstr = resstr.Replace("[w7d]", Format(firstdate.AddDays(7), "%d"))

        'Ӣ�ĵ����ڣ�����--����
        '�������յ�����
        resstr = resstr.Replace("[w0yyyy]", Format(firstdate, "yyyy"))
        resstr = resstr.Replace("[w0MM]", Format(firstdate, "MM"))
        resstr = resstr.Replace("[w0dd]", Format(firstdate, "dd"))
        resstr = resstr.Replace("[w0yy]", Format(firstdate, "yy"))
        resstr = resstr.Replace("[w0M]", Format(firstdate, "%M"))
        resstr = resstr.Replace("[w0d]", Format(firstdate, "%d"))
        '������������
        resstr = resstr.Replace("[w6yyyy]", Format(firstdate.AddDays(6), "yyyy"))
        resstr = resstr.Replace("[w6MM]", Format(firstdate.AddDays(6), "MM"))
        resstr = resstr.Replace("[w6dd]", Format(firstdate.AddDays(6), "dd"))
        resstr = resstr.Replace("[w6yy]", Format(firstdate.AddDays(6), "yy"))
        resstr = resstr.Replace("[w6M]", Format(firstdate.AddDays(6), "%M"))
        resstr = resstr.Replace("[w6d]", Format(firstdate.AddDays(6), "%d"))
        Return resstr
    End Function
    '����cycleID��BaseKey�������Ӧ�����ַ���ʾ��ʱ�䣬����д������־
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
                Return aCycleID.ToString.Substring(0, 4) + "��" + aCycleID.ToString.Substring(4, 2) + "��"
            Case "YEAR"
                Return aCycleID.ToString.Substring(0, 4) + "��"
        End Select
    End Function
    '����cycleid �� BaseKey ���㿪ʼʱ���ĸ��洢����sp_CalcComTag��sp_HoutToDay��sp_DayToMonth��sp_MonthToYear��StartTime
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
    '����ָ�궨�������ַ���ƴ�Ӵ�.
    '����ԭ�ȵ�ָ�궨������ֻ�ܶ���ָ��ID,���ڶ�ָ�궨��Ĺ�����������,
    '����ͨ��"ָ��ID|WhereClause"�ķ�ʽ���в�ѯ�������޶�.����:1401001|I_Value_Man>0.1
    '�ɴ˶���ָ��ID������ƴ�ӷ�ʽ����һЩ�仯,���õ������޶����ܵļ����ط�,
    'ƴ�ӵ�ʱ��,�������ӵ�����.
    Private Function pGenerate_TagIDALL(ByVal aTag As System.Array, ByVal sTagType As String) As String
        '����Ҫȡ���ݵ�ָ���ţ���,����,���'ָ��1','ָ��2'��ʽ���ַ���.
        Dim i, j As Integer
        Dim sTagIDAll As String = String.Empty, sTagID As String = String.Empty
        'aTag ��һ����ά����,���������±��1��ʼ.

        Select Case sTagType.ToUpper
            Case "FLOAT", "STR", "MAX", "MIN", "AVG", "SUM", "COUNT", "AGGREGATION", "MAXVALUE1DATE", "MINVALUE1DATE", "SWITCHCOUNT", "ONCERUNNINGDATA" '��ֵ���ַ�����.
                For i = 1 To aTag.GetLength(0)
                    For j = 1 To aTag.GetLength(1)
                        sTagID = aTag(i, j)
                        If Not (sTagID Is Nothing) Then
                            If sTagID.Trim() <> String.Empty Then
                                sTagIDAll += String.Format(IIf(sTagIDAll.Length > 0, ",{0}", "{0}"), sTagID) '����������
                            End If
                        End If
                    Next
                Next
            Case "LINE1", "LINE2", "FUNC" '��������״̬ͼ1��
                For i = 1 To aTag.GetLength(0)
                    For j = 1 To aTag.GetLength(1)
                        sTagID = aTag(i, j)
                        If Not (sTagID Is Nothing) Then
                            If sTagID.Trim() <> String.Empty Then
                                sTagIDAll += String.Format(IIf(sTagIDAll.Length > 0, ",'{0}'", "'{0}'"), sTagID) '��������
                            End If
                        End If
                    Next
                Next
        End Select
        Return sTagIDAll
    End Function
    '����ָ��ĺϸ���������һ���ϸ������ļ����Զ�.
    Private Function pGenerate_TagConditionColumn(ByVal aTagIDALL As String) As String
        Dim aTag_Condition As System.Array = aTagIDALL.Split(",")
        Dim sTag_Column As String = "Case "
        Dim i As Integer
        Dim sTag_Condition As String
        For i = 0 To aTag_Condition.Length - 1
            sTag_Condition = aTag_Condition(i)
            If sTag_Condition.Split("|").Length = 1 Then
                sTag_Column += String.Format(" When I_Tag_ID='{0}' Then I_Value_Man ", sTag_Condition)
            Else '���ָ��ָ���˲���ֵ���޶�����.
                Dim tagID, tagCondition As String
                tagID = sTag_Condition.Split("|")(0)
                tagCondition = sTag_Condition.Split("|")(1)
                sTag_Column += String.Format(" When I_Tag_ID='{0}' And {1} Then I_Value_Man ", tagID, tagCondition)
            End If
        Next
        sTag_Column += " Else Null End"
        Return sTag_Column
    End Function
    '�����Щ�����л��ָ��Ĳ���ֵ�������޶�.�������ˮ���Ƕ�,�ϸ��Ϊ����ֵ>0.1.
    '���ֱ������кϸ�����ͳ��.�����ˮ�ĺϸ������Ŀ�ͺϸ��ʵ�.
    '��ڲ���˵��:
    '   aTagIDALL:ָ�궨����������Ӧ��ָ�����Ӵ�.
    '   ����:   1401001,1401002,
    '           1401001|I_VALUE_MAN>0.1,1401002
    '           1401001|I_VALUE_MAN>0.1,1401002|I_VALUE_MAN>0.2 
    '����ֵ: һ��ƴ�Ӻõ�WhereClause�Ĳ���.����
    '        ((I__Tag_ID ='1401001') OR (I_Tag_ID = '1401002' And I_Value_Man > 0.1))
    Private Function pGenerate_TagConditionWhereClause(ByVal aTagIDALL As String) As String
        Dim aTag_Condition As System.Array = aTagIDALL.Split(",") 'System.Array���±��Ǵ�0��ʼ��.
        Dim sTag_WhereClause As String = "("
        Dim i As Integer
        Dim sTag_Condition As String
        For i = 0 To aTag_Condition.Length - 1
            sTag_Condition = aTag_Condition(i)
            If sTag_Condition.Split("|").Length = 1 Then '���ָ��û��ָ������ֵ�޶�����
                sTag_WhereClause += String.Format("(I_Tag_ID='{0}') OR ", sTag_Condition)
            Else '���ָ��ָ���˲���ֵ���޶�����.
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
    '�Դ�ָ��IDƴ���������ַ���.
    Private Function pGenerate_PureTagConditionWhereClause(ByVal aTagIDALL As String, Optional ByVal fieldName As String = "I_Tag_ID") As String
        Dim aTag_Condition As System.Array = aTagIDALL.Split(",") 'System.Array���±��Ǵ�0��ʼ��.
        Dim sTag_WhereClause As String = "("
        Dim i As Integer
        Dim sTag_Condition As String
        For i = 0 To aTag_Condition.Length - 1
            sTag_Condition = aTag_Condition(i)
            If sTag_Condition.Split("|").Length = 1 Then '���ָ��û��ָ������ֵ�޶�����
                sTag_WhereClause += String.Format("({0}='{1}') OR ", fieldName, sTag_Condition)
            Else '���ָ��ָ���˲���ֵ���޶�����.
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

    '�����ֶεĿ�ֵ
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
    '���ӱ���ģ��.
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
    '���±���ģ��.
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
    ''' �豸���ش���ͳ�ơ�
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
        '����ָ������,ʱ����������ȡָ�����ݱ����ͣ�Сʱ����ȣ�����ʼʱ��㡢����ʱ��㡢�����ݵ���Ŀ����Ϣ��
        'ʱ����������Ϣ�洢��T_DATE_MS����.
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
            Case "DAY_L"    '�ϸ��µ��ձ���
                Dim strStart As String = nStart.ToString()
                Dim strEnd As String = nEnd.ToString()
                startTime = New DateTime(Int32.Parse(strStart.Substring(0, 4)), Int32.Parse(strStart.Substring(4, 2)), Int32.Parse(strStart.Substring(6, 2)))
                endTime = New DateTime(Int32.Parse(strEnd.Substring(0, 4)), Int32.Parse(strEnd.Substring(4, 2)), Int32.Parse(strEnd.Substring(6, 2))).AddDays(1)
                strDatePart = "dd"
                startJ = DatePart(DateInterval.Day, startTime)
            Case "WEEK" '�ܱ������ݴ������T_TAG_DAY�У������й������Ǵ���һ��ʼ���������ϵ����Ǵ����տ�ʼ������Ҫע�⿪ʼ���ڣ�                
                Dim strStart As String = nStart.ToString()
                Dim strEnd As String = nEnd.ToString()
                startTime = New DateTime(Int32.Parse(strStart.Substring(0, 4)), Int32.Parse(strStart.Substring(4, 2)), Int32.Parse(strStart.Substring(6, 2)))
                endTime = New DateTime(Int32.Parse(strEnd.Substring(0, 4)), Int32.Parse(strEnd.Substring(4, 2)), Int32.Parse(strEnd.Substring(6, 2))).AddDays(1)
                strDatePart = "dw"
                startJ = DatePart(DateInterval.Weekday, startTime)
                startJ = startJ - 1 '�����й������Ǵ���һ��ʼ
            Case "WEEK_L" '���ܱ������ݴ������T_TAG_DAY��
                Dim strStart As String = nStart.ToString()
                Dim strEnd As String = nEnd.ToString()
                startTime = New DateTime(Int32.Parse(strStart.Substring(0, 4)), Int32.Parse(strStart.Substring(4, 2)), Int32.Parse(strStart.Substring(6, 2)))
                endTime = New DateTime(Int32.Parse(strEnd.Substring(0, 4)), Int32.Parse(strEnd.Substring(4, 2)), Int32.Parse(strEnd.Substring(6, 2))).AddDays(1)
                strDatePart = "dw"
                startJ = DatePart(DateInterval.Weekday, startTime)
                startJ = startJ - 1 '�����й������Ǵ���һ��ʼ
            Case "MONTH"
                Dim strStart As String = nStart.ToString()
                Dim strEnd As String = nEnd.ToString()
                startTime = New DateTime(Int32.Parse(strStart.Substring(0, 4)), Int32.Parse(strStart.Substring(4, 2)), 1)
                endTime = New DateTime(Int32.Parse(strEnd.Substring(0, 4)), Int32.Parse(strEnd.Substring(4, 2)), 1).AddMonths(1)
                strDatePart = "mm"
                startJ = DatePart(DateInterval.Month, startTime)
            Case "MONTH_L"   'ȥ����±�������
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
        'ApplicationLog.WriteInfo("����:" + nTimeCount.ToString())
        '�����ݿ�ȡ����Ӧ��ָ������
        Dim dtData As New DataTable()
        '���ݱ���
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
        '��������.
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
                    For j = 0 To aTag.GetLength(1) - 1 '����ָ�궨���ά����.
                        sTagID = aTag(i + 1, j + 1) '������±��1��ʼ.

                        If Not (sTagID Is Nothing) Then
                            If sTagID.Trim() <> String.Empty Then
                                oRange = CType(CCData.Cells._Default(i + nRowStart, j + nColStart), OWC10.Range) '�ҵ���Ӧָ�����ֵ��Ӧ�ĵ�Ԫ��.(1����Ԫ��)
                                dtData.DefaultView.RowFilter = String.Format("SwitchTagId='{0}'", sTagID.Split("|")(0))
                                If dtData.DefaultView.Count = 1 Then '���ָ��Ĳ���ֵ��¼��һ����¼.
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
                '��ʱ���ʱҪ����ʱ�������з���
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
    ''' �豸����һ�ε���ֵ��
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
        '����ָ������,ʱ����������ȡָ�����ݱ����ͣ�Сʱ����ȣ�����ʼʱ��㡢����ʱ��㡢�����ݵ���Ŀ����Ϣ��
        'ʱ����������Ϣ�洢��T_DATE_MS����.
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
            Case "DAY_L"    '�ϸ��µ��ձ���
                Dim strStart As String = nStart.ToString()
                Dim strEnd As String = nEnd.ToString()
                startTime = New DateTime(Int32.Parse(strStart.Substring(0, 4)), Int32.Parse(strStart.Substring(4, 2)), Int32.Parse(strStart.Substring(6, 2)))
                endTime = New DateTime(Int32.Parse(strEnd.Substring(0, 4)), Int32.Parse(strEnd.Substring(4, 2)), Int32.Parse(strEnd.Substring(6, 2))).AddDays(1)
            Case "WEEK" '�ܱ������ݴ������T_TAG_DAY�У������й������Ǵ���һ��ʼ���������ϵ����Ǵ����տ�ʼ������Ҫע�⿪ʼ���ڣ�                
                Dim strStart As String = nStart.ToString()
                Dim strEnd As String = nEnd.ToString()
                startTime = New DateTime(Int32.Parse(strStart.Substring(0, 4)), Int32.Parse(strStart.Substring(4, 2)), Int32.Parse(strStart.Substring(6, 2)))
                endTime = New DateTime(Int32.Parse(strEnd.Substring(0, 4)), Int32.Parse(strEnd.Substring(4, 2)), Int32.Parse(strEnd.Substring(6, 2))).AddDays(1)
            Case "WEEK_L" '���ܱ������ݴ������T_TAG_DAY��
                Dim strStart As String = nStart.ToString()
                Dim strEnd As String = nEnd.ToString()
                startTime = New DateTime(Int32.Parse(strStart.Substring(0, 4)), Int32.Parse(strStart.Substring(4, 2)), Int32.Parse(strStart.Substring(6, 2)))
                endTime = New DateTime(Int32.Parse(strEnd.Substring(0, 4)), Int32.Parse(strEnd.Substring(4, 2)), Int32.Parse(strEnd.Substring(6, 2))).AddDays(1)
            Case "MONTH"
                Dim strStart As String = nStart.ToString()
                Dim strEnd As String = nEnd.ToString()
                startTime = New DateTime(Int32.Parse(strStart.Substring(0, 4)), Int32.Parse(strStart.Substring(4, 2)), 1)
                endTime = New DateTime(Int32.Parse(strEnd.Substring(0, 4)), Int32.Parse(strEnd.Substring(4, 2)), 1).AddMonths(1)
            Case "MONTH_L"   'ȥ����±�������
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
        '��������.
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
            '��ʱ���ʱҪ����ʱ�������з���
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
                        If sTagOrient = "0" Then '���ϵ���
                            rangeTurnonTime = CType(CCData.Cells._Default(i + nRowStart, JJ * 3 + 0 + nColStart), OWC10.Range)
                            rangeTurnoffTime = CType(CCData.Cells._Default(i + nRowStart, JJ * 3 + 1 + nColStart), OWC10.Range)
                            rangeDiffValue = CType(CCData.Cells._Default(i + nRowStart, JJ * 3 + 2 + nColStart), OWC10.Range)
                            'ApplicationLog.WriteInfo(String.Format("oRange = CType(CCData.Cells._Default({0}, {1}), OWC10.Range)", i + nRowStart, JJ * 3 + 0 + nColStart))
                            'ApplicationLog.WriteInfo(String.Format("oRange = CType(CCData.Cells._Default({0}, {1}), OWC10.Range)", i + nRowStart, JJ * 3 + 1 + nColStart))
                            'ApplicationLog.WriteInfo(String.Format("oRange = CType(CCData.Cells._Default({0}, {1}), OWC10.Range)", i + nRowStart, JJ * 3 + 2 + nColStart))
                            'ApplicationLog.WriteInfo("--------------------")
                        Else '������
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
                            '��������,������T_Tag_MS�ж����ָ���С���㱣��λ��.
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


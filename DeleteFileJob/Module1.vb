Imports System.IO
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Data
Imports System.Collections.Generic
Imports System.Data.OleDb
Imports OWC10
Imports Shmzh.Gather.Data
Imports Shmzh.Gather.Data.Model
Imports YPWater.Web
Imports System.Xml

Module Module1
    Private ReadOnly Logger As log4net.ILog = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)
    Private _exportDirectory As String
    Private _exportDateDirectory As String
    Private _exportDateTimeDirectory As String

    '��ڲ���˵����
    '   ��һ������:��ʾ�������͡�
    '       0��ɾ�������ɼ����ɵ��ı��ļ���
    '       1������ϳ�ָ�ꣻ
    '       2�������̨����
    '       3���ϱ����ݵ����߹�˾�����ݿ⣻
    '   �ڶ���������
    '       �����һ��������0����ڶ����������ı��ļ��Ĵ��·����
    '
    Sub Main(ByVal args() As String)

        Dim tag As Integer

        Dim owcxmlleavedays As Integer = 10
        Try
            owcxmlleavedays = CInt(ConfigurationManager.AppSettings.Item("OWCXMLLeaveDays"))
        Catch ex As Exception
            Logger.Error(ex.Message, ex)
        End Try


        _exportDirectory = Environment.CurrentDirectory & "\export"
        If Directory.Exists(_exportDirectory) = False Then
            Directory.CreateDirectory(_exportDirectory)
        End If
        _exportDateDirectory = _exportDirectory & "\" & DateTime.Now.ToString("yyyyMMdd")
        If Directory.Exists(_exportDateDirectory) = False Then
            Directory.CreateDirectory(_exportDateDirectory)
            Logger.Debug(String.Format("CreateDirectory {0}", _exportDateDirectory))

        End If
        _exportDateTimeDirectory = _exportDateDirectory & "\" & DateTime.Now.ToString("HH")
        If (Directory.Exists(_exportDateTimeDirectory) = False) Then
            Directory.CreateDirectory(_exportDateTimeDirectory)
            Logger.Debug(String.Format("CreateDirctory {0}", _exportDateTimeDirectory))
        End If
        Dim childDirs As String()

        childDirs = Directory.GetDirectories(_exportDirectory)

        Dim minDate As DateTime = DateTime.Today.AddDays(-owcxmlleavedays)

        For Each childDir As String In childDirs
            'Console.WriteLine(childDir.Substring(childDir.LastIndexOf("\")))
            Logger.Debug(childDir.Substring(childDir.LastIndexOf("\") + 1))

            If childDir.Substring(childDir.LastIndexOf("\") + 1) < minDate.ToString("yyyyMMdd") Then
                Console.WriteLine("delete " & childDir)
                Logger.Debug("Delete directory " & childDir.Substring(childDir.LastIndexOf("\") + 1))

                Directory.Delete(childDir, True)
            End If
        Next
        If args.Length > 0 Then


            tag = args(0) '��һ�������ǲ������ͣ�0:ɾ�������ļ�;1:����ϳ�ָ�ꡣ2Ϊ�����̨����        
            Select Case tag
                Case 0
                    'ɾ�������ļ�
                    DeleteFile(args(1).ToUpper)
                Case 1
                    'ִ�м���ϳ�ָ��Ĵ洢���̡��ù���ֱ�ӷ�����ҵ��������ʱ���ڻ���������ʱ��ĸΪ0�����¼�����;�˳���
                    CalcComTag(args(1).ToUpper)
                Case 2
                    'ִ�м����̨����ʱ���������,-1��������,0�������,����һ��������������
                    If args.GetUpperBound(0) = 2 Then
                        CalcReport(args(1), args(2))
                    ElseIf args.GetUpperBound(0) = 1 Then 'û�е���������������Ϊ���ձ����档
                        CalcReport(args(1), "report")
                    End If
                Case 3
                    'ת�����ݵ����߹�˾�����ݿ���
                    If args.GetUpperBound(0) = 2 Then
                        TransToSG(args(1).ToUpper, args(2))
                    Else
                        TransToSG(args(1).ToUpper, "")
                    End If

            End Select
        End If
        Logger.Debug("log test")
    End Sub
    '*************************************
    'ɾ�������ļ�
    '*************************************
    Sub DeleteFile(ByVal FilePath As String)
        Dim leavedays As Integer

        Try
            ' Obtain the file system entries in the directory path.
            leavedays = Integer.Parse(ConfigurationManager.AppSettings("LeaveDays"))
            Dim directoryEntries As String()
            directoryEntries = System.IO.Directory.GetFileSystemEntries(FilePath)

            Dim str As String
            For Each str In directoryEntries

                Dim tempFileName As String()
                tempFileName = str.Split("\")
                Dim iLength = tempFileName.Length - 1
                Try
                    If (iLength > 0) Then
                        'tempFileName(iLength)���ļ�·����d:\dates\20000101�������һ��\������ַ����������ڴ�
                        Dim currentDate As DateTime = CDate(tempFileName(iLength).Substring(0, 4) + "/" + tempFileName(iLength).Substring(4, 2) + "/" + tempFileName(iLength).Substring(6, 2))

                        If (currentDate.AddDays(leavedays) < DateTime.Today) Then
                            Directory.Delete(str, True)
                            Console.WriteLine("�ļ���" + str + "�ѱ�ɾ��!")
                            Exit Sub
                        End If
                    End If
                Catch exp As Exception
                End Try
            Next str
        Catch exp As ArgumentNullException
            Console.WriteLine("Path is a null reference.")
        Catch exp As Security.SecurityException
            Console.WriteLine("The caller does not have the " + _
                                    "required permission.")
        Catch exp As ArgumentException
            Console.WriteLine("Path is an empty string, " + _
                                    "contains only white spaces, " + _
                                    "or contains invalid characters.")
        Catch exp As DirectoryNotFoundException
            Console.WriteLine("The path encapsulated in the " + _
                                    "Directory object does not exist.")
        End Try
    End Sub

    '*************************************
    'ִ�м���ϳ�ָ��Ĵ洢���̡��ù���ֱ�ӷ�����ҵ��������ʱ���ڻ���������ʱ��ĸΪ0�����¼�����;�˳���
    '*************************************
    Sub CalcComTag(ByVal basekey As String)
        Dim conn As SqlConnection
        Try
            conn = New SqlConnection(ConfigurationManager.AppSettings("ConnectionString"))
            conn.Open()
            Dim sqlcom As SqlCommand
            sqlcom = New SqlCommand("sp_CalcComTag " + basekey, conn)
            sqlcom.ExecuteNonQuery()
        Catch ex As Exception
        Finally
            conn.Close()
        End Try
    End Sub

    '*************************************
    'ִ�м����̨����
    '*************************************
    Sub CalcReport(ByVal starttime As String, ByVal userid As String)
        'Dim reader As XmlTextReader
        'Dim myXmlDocument As XmlDocument
        'Dim i, j As Integer
        Dim mycschema As CSchema = New CSchema()
        Dim myexcel As OWC10.Spreadsheet = New OWC10.Spreadsheet()
        Dim strtime As String
        Dim oldxml As String
        Try
            'reader = New XmlTextReader(ConfigurationManager.AppSettings("XmlFileUsers"))
            'reader.WhitespaceHandling = WhitespaceHandling.None

            '' �� XmlTextReader ���� XmlDocument
            'myXmlDocument = New XmlDocument()
            'myXmlDocument.Load(reader)

            'Dim nodes As XmlNodeList
            'nodes = myXmlDocument.DocumentElement.ChildNodes
            ''�����û����������û�Ŀ¼��
            'For i = 0 To nodes.Count - 1
            '    Dim anode As XmlNode = nodes(i)
            '    Dim map As XmlNamedNodeMap = anode.Attributes

            '    If (map.GetNamedItem("UserID").Value.ToLower = userid.ToLower) Then
            '        '���û����ʱ�䣬�ͱ�ʾת����һ�������
            '        Dim curtime As Date
            '        If starttime = "-1" Then
            '            curtime = System.DateTime.Now.Date.AddDays(-1)
            '        ElseIf starttime = "0" Then
            '            curtime = System.DateTime.Now.Date
            '        Else
            '            curtime = CDate(starttime)
            '        End If
            '        LoadChildNodes(anode, curtime)
            '        Exit For
            '    End If
            'Next
            '���û����ʱ�䣬�ͱ�ʾת����һ�������
            Dim curtime As Date
            If starttime = "-1" Then
                curtime = DateTime.Now.Date.AddDays(-1)
            ElseIf starttime = "0" Then
                'curtime = DateTime.Now.Date
                curtime = DateTime.Now.AddHours(-1).Date '��ǰһ��Сʱ��Ϊ�˴����ڸչ�0��ʱ�򣬵ı����棬������Ҫ���������24���Ǹ�Сʱ��ֵ���������ڴ�����ʱ���ǽ����ˣ����Ի���ؽ���ı��������ܴﵽ����24���Сʱֵ�����Խ���ǰʱ����ǰһ��Сʱ������0��ʱ�������еı���ͻ������յı���
            Else
                curtime = CDate(starttime)
            End If
            strtime = Format(curtime, "yyyy/MM/dd")

            Dim str As String
            Dim obj As CategoryInfo
            'Console.WriteLine(userid)

            obj = DataRepository.CategoryProvider.GetByName(userid)

            If Not (obj Is Nothing) Then
                Dim objs As List(Of RelationInfo)
                objs = CType(DataRepository.RelationProvider.GetByCategoryId(obj.Id), List(Of RelationInfo))
                objs.Sort(Function(x, y) x.Sort.CompareTo(y.Sort))
                'Console.WriteLine(obj.Id)

                If (objs.Count > 0) Then
                    Dim item As RelationInfo

                    For Each item In objs
                        str = mycschema.GetSchema(item.SchemaId, curtime, False)
                        Logger.Info(DateTime.Now & " " & item.SchemaId & "- " & item.SchemaName & " ��ȡ�ɹ�")
                        Console.WriteLine(DateTime.Now & " " & item.SchemaId & "- " & item.SchemaName & " ��ȡ�ɹ�")
                        Dim t As Integer = str.IndexOf(";")

                        If t >= 0 Then
                            oldxml = str.Substring(t + 1, str.Length - t - 1)
                            myexcel.XMLData = oldxml

                            myexcel.Export(_exportDateTimeDirectory & "\" & item.SchemaId & "@" & DateTime.Now.ToString("mmss") & ".xml", SheetExportActionEnum.ssExportActionNone, SheetExportFormat.ssExportXMLSpreadsheet)
                            Logger.Debug(_exportDateTimeDirectory & "\" & item.SchemaId & "@" & DateTime.Now.ToString("mmss") & ".xml")
                        Else
                            oldxml = str
                            myexcel.XMLData = str
                        End If

                        myexcel.Calculate()
                        'Logger.Debug("-----------------------------------------------------------------------")
                        'Logger.Debug(oldxml)
                        'Logger.Debug("-----------------------------------------------------------------------")
                        'Logger.Debug(myexcel.XMLData)
                        Dim result As Boolean
                        result = mycschema.SaveSchema(item.SchemaId, curtime, myexcel.XMLData, oldxml, "Database Server", "[��̨��������]", "")
                        If result Then
                            Logger.Info(DateTime.Now & " " & item.SchemaId & "- " & item.SchemaName & " ����ɹ�")
                            Console.WriteLine(DateTime.Now & " " & item.SchemaId & "- " & item.SchemaName & " ����ɹ�")
                        Else
                            Logger.Info(DateTime.Now & " " & item.SchemaId & "- " & item.SchemaName & " ����ʧ��")
                            Console.WriteLine(DateTime.Now & " " & item.SchemaId & "- " & item.SchemaName & " ����ʧ��")
                        End If
                    Next

                End If
            End If
            Logger.Info(DateTime.Now & " ��̨����������")
            Console.WriteLine(DateTime.Now & " ��̨����������")
        Catch e As Exception
            Logger.Error(DateTime.Now & " ��̨��������쳣")
            Logger.Error(e.Message, e)
            Console.WriteLine(DateTime.Now & " ��̨��������쳣��", e.Message)
        Finally
            'If Not (reader Is Nothing) Then
            '    reader.Close()
            'End If
        End Try
    End Sub

    '�����²�ӵ�
    Private Sub LoadChildNodes(ByVal pNode As XmlNode, ByVal curtime As Date)
        Dim i, j As Integer
        Dim mycschema As CSchema = New CSchema()
        Dim myexcel As OWC10.Spreadsheet = New OWC10.Spreadsheet()

        Dim strtime As String
        Dim oldxml As String

        strtime = Format(curtime, "yyyy/MM/dd")
        Try
            '�����û����������û�Ŀ¼��
            For i = 0 To pNode.ChildNodes.Count - 1
                Dim anode As XmlNode = pNode.ChildNodes(i)

                If Not (anode.Attributes.GetNamedItem("Leaf") Is Nothing) Then
                    If (anode.Attributes.GetNamedItem("Leaf").Value.ToLower = "yes") Then
                        Dim report_code As String = anode.InnerText()
                        Dim str As String
                        str = mycschema.GetSchema(report_code, curtime, False)
                        System.Console.WriteLine(System.DateTime.Now & " " & report_code & " ��ȡ�ɹ�")
                        Dim t As Integer = str.IndexOf(";")
                        If t >= 0 Then
                            oldxml = str.Substring(t + 1, str.Length - t - 1)
                            myexcel.XMLData = oldxml
                        Else
                            oldxml = str
                            myexcel.XMLData = str
                        End If

                        myexcel.Calculate()

                        mycschema.SaveSchema(report_code, curtime, myexcel.XMLData, oldxml, "Database Server", "[��̨��������]", "")
                        System.Console.WriteLine(System.DateTime.Now & " " & report_code & " ����ɹ�")
                    End If
                Else
                    LoadChildNodes(anode, curtime)
                End If
            Next
        Catch e As Exception
            System.Console.WriteLine(System.DateTime.Now & "��̨��������쳣��", e.Message)
        End Try
    End Sub
    '*************************************
    'ת�����ݵ����߹�˾�����ݿ���
    '*************************************
    Sub TransToSG(ByVal basekey As String, ByVal starttime As String)
        Dim conn As SqlConnection
        Dim oleconn As OleDbConnection
        Dim data, tempdata As DataTable
        Dim sqlda As SqlDataAdapter
        Dim olecom1, olecom2 As OleDbCommand
        Dim selftime As DateTime
        Dim sgtime, sgtime1, sgtime2 As String
        Dim oldstartid, startid, endid As Integer
        Try
            '���û����ʱ�䣬�ͱ�ʾת����һ�����һ�µ�����
            If starttime = "" Then
                If basekey = "MONTH" Then
                    selftime = System.DateTime.Now.AddMonths(-1)
                Else
                    selftime = System.DateTime.Now.AddDays(-1)
                End If
            Else
                selftime = CDate(starttime)
            End If
            '������������ݿ����ʱ�估��ʼ�ͽ���ʱ���
            If basekey = "HOUR" Then
                Dim basedate As Date = CDate("2002-01-01")
                Dim aTimeSpan As TimeSpan
                aTimeSpan = CDate(Format(selftime, "yyyy-MM-dd")).Subtract(basedate)
                startid = CInt(aTimeSpan.TotalHours) + 1
                endid = startid + 23
                sgtime1 = Format(selftime, "yyyy.MM.dd")
                sgtime2 = Format(selftime.AddDays(1), "yyyy.MM.dd")
            ElseIf basekey = "DAY" Then
                startid = CInt(Format(selftime, "yyyyMMdd"))
                endid = startid
                sgtime = Format(selftime, "yyyy.MM.dd")
            ElseIf basekey = "MONTH" Then
                startid = CInt(Format(selftime, "yyyyMM"))
                endid = startid
                sgtime = Format(selftime, "yyyy.MM") & ".01"
            End If
            oldstartid = startid
            conn = New SqlConnection(ConfigurationManager.AppSettings("ConnectionString"))
            conn.Open()

            tempdata = New DataTable("TEMP")
            Dim j As Integer

            'ת��ˮ������
            oleconn = New OleDbConnection(ConfigurationManager.AppSettings("ConnectionString_SBSZ"))
            oleconn.Open()
            olecom1 = New OleDbCommand()
            olecom1.Connection = oleconn
            olecom2 = New OleDbCommand()
            olecom2.Connection = oleconn
            j = 1
            While startid <= endid
                If basekey = "HOUR" Then
                    If j < 24 Then
                        sgtime = sgtime1 & " " & Format(j, "00") & ":00:00"
                    Else
                        sgtime = sgtime2 & " 00:00:00"
                    End If
                End If
                'ѡ��ˮ������
                data = New DataTable("DATA")
                sqlda = New SqlDataAdapter("select a.CODES,b.I_VALUE_MAN,c.I_DIG_NUM from T_SGCFG a, T_TAG_" & basekey & " b,T_TAG_MS c where a.TYPE = 2 and a.STATE = 1 and a.BASE_KEY = '" & basekey & "' and a.I_TAG_ID = b.I_TAG_ID and b.I_TAG_ID = c.I_TAG_ID and b.I_CYCLE_ID = " & startid & " ORDER BY a.CODES", conn)
                sqlda.Fill(data)
                Dim i As Integer
                For i = 0 To data.Rows.Count - 1
                    '�ȼ���ʱ���ָ����������������ݿ����Ƿ��Ѵ���
                    olecom1.CommandText = "select status from yx" & basekey.ToLower & " where datadate = '" & sgtime & "' and datacode = '" & data.Rows(i).Item("CODES") & "'"
                    Dim status As Object = olecom1.ExecuteScalar()
                    If Not status Is Nothing Then
                        '����ʱ���״̬����C���Ѵ��䣩������и��ģ�������������Ѿ��ϴ�����˾���������޸ġ�
                        If CType(status, String) <> "C" Then
                            olecom2.CommandText = "update yx" & basekey.ToLower & " set datavalue = '" & CStr(data.Rows(i).Item("I_VALUE_MAN")) & "' where datadate = '" & sgtime & "' and datacode = '" & data.Rows(i).Item("CODES") & "'"
                            olecom2.ExecuteNonQuery()
                        End If
                    Else
                        '������ʱ�Ͳ���
                        olecom2.CommandText = "insert into yx" & basekey.ToLower & " (datadate,datacode,datavalue,status,datasign,czno) values('" & sgtime & "','" & data.Rows(i).Item("CODES") & "','" & CStr(data.Rows(i).Item("I_VALUE_MAN")) & "','A','',4)"
                        olecom2.ExecuteNonQuery()
                    End If
                Next
                startid += 1
                j += 1
                sqlda.Dispose()
            End While
            oleconn.Dispose()
            olecom1.Dispose()
            olecom2.Dispose()

            'ת��ˮ������
            oleconn = New OleDbConnection(ConfigurationManager.AppSettings("ConnectionString_SBSC"))
            oleconn.Open()
            olecom1 = New OleDbCommand()
            olecom1.Connection = oleconn
            olecom2 = New OleDbCommand()
            olecom2.Connection = oleconn
            j = 1
            startid = oldstartid
            While startid <= endid
                If basekey = "HOUR" Then
                    If j < 24 Then
                        sgtime = sgtime1 & " " & Format(j, "00") & ":00:00"
                    Else
                        sgtime = sgtime2 & " 00:00:00"
                    End If
                End If
                'ѡ��ˮ������
                data = New DataTable("DATA")
                sqlda = New SqlDataAdapter("select a.CODES,b.I_VALUE_MAN from T_SGCFG a, T_TAG_" & basekey & " b where a.TYPE = 1 and a.STATE = 1 and a.BASE_KEY = '" & basekey & "' and a.I_TAG_ID = b.I_TAG_ID and b.I_CYCLE_ID = " & startid & " ORDER BY a.CODES", conn)
                sqlda.Fill(data)
                Dim i As Integer
                For i = 0 To data.Rows.Count - 1
                    '�ȼ���ʱ���ָ����������������ݿ����Ƿ��Ѵ���
                    olecom1.CommandText = "select status from yx" & basekey.ToLower & " where datadate = '" & sgtime & "' and datacode = '" & data.Rows(i).Item("CODES") & "'"
                    Dim status As Object = olecom1.ExecuteScalar()
                    If Not status Is Nothing Then
                        '����ʱ���״̬����C���Ѵ��䣩������и��ģ�������������Ѿ��ϴ�����˾���������޸ġ�
                        If CType(status, String) <> "C" Then
                            olecom2.CommandText = "update yx" & basekey.ToLower & " set datavalue = '" & CStr(data.Rows(i).Item("I_VALUE_MAN")) & "' where datadate = '" & sgtime & "' and datacode = '" & data.Rows(i).Item("CODES") & "'"
                            olecom2.ExecuteNonQuery()
                        End If
                    Else
                        '������ʱ�Ͳ���
                        olecom2.CommandText = "insert into yx" & basekey.ToLower & " (datadate,datacode,datavalue,status,datasign,czno) values('" & sgtime & "','" & data.Rows(i).Item("CODES") & "','" & CStr(data.Rows(i).Item("I_VALUE_MAN")) & "','A','',4)"
                        olecom2.ExecuteNonQuery()
                    End If
                Next
                startid += 1
                j += 1
                sqlda.Dispose()
            End While
            oleconn.Dispose()
            olecom1.Dispose()
            olecom2.Dispose()
            System.Console.WriteLine(System.DateTime.Now & "ת��" & sgtime & "�����ݵ����߳ɹ�!")
        Catch ex As Exception
            System.Console.WriteLine(System.DateTime.Now & "ת�����ݵ����߳���" & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

End Module

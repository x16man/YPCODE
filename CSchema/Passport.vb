Imports System.Data.SqlClient
Imports System.Configuration

Public Class PassPort

    Private strErrInfo

    ReadOnly Property ErrInfo() As String
        Get
            Return strErrInfo
        End Get
    End Property

    '插入纪录
    Public Function Insert(ByVal ip As String, ByVal userName As String, ByVal password As String, ByVal sessionID As String, ByVal expireDate As DateTime) As Boolean
        '
        Dim strSQL As String
        Dim dt As DataTable = GetPassport(ip, sessionID)

        If dt.Rows.Count = 0 Then
            strSQL = "INSERT INTO PASSPORT(IP,USERNAME,PASSWORD,SESSIONID,CREATEDATE,EXPIREDATE) VALUES('" & ip & "','" & userName & "','" & password & "','" & sessionID & "','" & Now & "','" & expireDate & "')"
        Else
            '重新设置ExpireDate & CreateDate
            strSQL = "UPDATE PASSPORT SET EXPIREDATE='" & expireDate & "',CREATEDATE='" & Now & "' WHERE IP='" & ip & "' and SESSIONID='" & sessionID & "'"
        End If
        ' strErrInfo = strSQL
        With New PubdataAccess()
            If .ExecUpdate(strSQL) < 0 Then
                strErrInfo = strSQL
                Insert = False
            Else
                Insert = True
            End If
            .Dispose()
        End With

    End Function

    '得到Passport
    Public Function GetPassport(ByVal ip As String, ByVal sessionid As String) As DataTable
        Dim strSQL As String
        Dim data As New DataTable()

        strSQL = "select username,password from passport where ip='" & ip & "' and sessionid='" & sessionid & "'"

        With New PubdataAccess()
            .ExecSelect(strSQL, data)
        End With
        '  strErrInfo = strSQL
        GetPassport = data
    End Function
    '
    '
    Public Sub New()
        MyBase.new()

    End Sub
End Class

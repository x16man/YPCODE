Option Explicit On 
Option Strict On

Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration

Public Class UserValid
    Private connectionString As String
    '�����û�����������֤�û�
    Function validateUser(ByVal userName As String, ByVal password As String) As Boolean
        Dim cnnConnection As New SqlConnection(Me.connectionString)
        Dim obj As Object
        'ִ��SQl��������
        Dim cmdCommand As New SqlCommand("select 1 from T_USER WHERE USER_NAME='" + userName + "' and PASSWORD='" + password + "'")

        Try
            '�����ݿ�����
            cnnConnection.Open()
            cmdCommand.Connection = cnnConnection

            obj = cmdCommand.ExecuteScalar()

        Catch sqlExecption As SqlException

        Finally
            cmdCommand.Dispose()
            If (cnnConnection.State = ConnectionState.Open) Then
                cnnConnection.Close()
            End If
            cnnConnection = Nothing
        End Try
        If (obj Is Nothing) Then
            Return False
        Else
            : Return True
        End If
    End Function
    '�����û�����ѯ��ɫID
    Function GetRoldIDByUserName(ByVal userName As String) As String
        Dim cnnConnection As New SqlConnection(Me.connectionString)
        Dim strResult As String
        'ִ��SQl��������
        Dim cmdCommand As New SqlCommand("SELECT TOP 1 ROLE_ID FROM T_USER WHERE USER_NAME='" + userName + "' ")
        Try
            '�����ݿ�����
            cnnConnection.Open()
            cmdCommand.Connection = cnnConnection
            strResult = CType(cmdCommand.ExecuteScalar(), String)
        Catch sqlExecption As SqlException

        Finally
            cmdCommand.Dispose()
            If (cnnConnection.State = ConnectionState.Open) Then
                cnnConnection.Close()
            End If
            cnnConnection = Nothing
        End Try
        Return strResult

    End Function
    ''�����û�����ѯ�û�ID
    'Function GetUserID(ByVal userName As String) As String
    '    Dim cnnConnection As New SqlConnection(Me.connectionString)
    '    Dim strResult As String
    '    'ִ��SQl��������
    '    Dim cmdCommand As New SqlCommand("SELECT TOP 1 USER_ID FROM T_USER WHERE USER_NAME='" + userName + "' ")
    '    Try
    '        '�����ݿ�����
    '        cnnConnection.Open()
    '        cmdCommand.Connection = cnnConnection
    '        strResult = CType(cmdCommand.ExecuteScalar(), String)
    '    Catch sqlExecption As SqlException

    '    Finally
    '        cmdCommand.Dispose()
    '        If (cnnConnection.State = ConnectionState.Open) Then
    '            cnnConnection.Close()
    '        End If
    '        cnnConnection = Nothing
    '    End Try
    '    Return strResult

    'End Function

    '�����û�ID��ѯ�û�����
    Function GetPasswdByUserName(ByVal UserName As String) As String
        Dim cnnConnection As New SqlConnection(Me.connectionString)
        Dim strResult As String
        'ִ��SQl��������
        Dim cmdCommand As New SqlCommand("SELECT TOP 1 PASSWORD FROM T_USER WHERE USER_NAME = '" + UserName + "' ")
        Try
            '�����ݿ�����
            cnnConnection.Open()
            cmdCommand.Connection = cnnConnection
            strResult = CType(cmdCommand.ExecuteScalar(), String)
        Catch sqlExecption As SqlException

        Finally
            cmdCommand.Dispose()
            If (cnnConnection.State = ConnectionState.Open) Then
                cnnConnection.Close()
            End If
            cnnConnection = Nothing
        End Try
        Return strResult

    End Function

    '�����û�ID�޸��û�����
    Function SetPasswdByUserName(ByVal UserName As String, ByVal Password As String) As Boolean
        Dim cnnConnection As New SqlConnection(Me.connectionString)
        'Dim strResult As String
        'ִ��SQl��������
        Dim cmdCommand As New SqlCommand("UPDATE T_USER SET  PASSWORD = '" + Password + "' WHERE USER_NAME='" + UserName + "' ")
        Try
            '�����ݿ�����
            cnnConnection.Open()
            cmdCommand.Connection = cnnConnection
            cmdCommand.ExecuteNonQuery()
            Return True
        Catch sqlExecption As SqlException
            Return False
        Finally
            cmdCommand.Dispose()
            If (cnnConnection.State = ConnectionState.Open) Then
                cnnConnection.Close()
            End If
            cnnConnection = Nothing
        End Try
    End Function

    '�����û�����ѯ�û���Ϣ
    Function GetUserTable(ByVal userName As String) As DataTable
        Dim cnnConnection As New SqlConnection(Me.connectionString)
        Dim restable As DataTable = New DataTable("USER")
        'ִ��SQl��������
        Dim dasql As New SqlClient.SqlDataAdapter("SELECT TOP 1 * FROM T_USER WHERE USER_NAME='" + userName + "'", cnnConnection)
        Try
            cnnConnection.Open()
            dasql.Fill(restable)
        Catch sqlExecption As SqlException

        Finally
            If (cnnConnection.State = ConnectionState.Open) Then
                cnnConnection.Close()
            End If
            cnnConnection = Nothing
            dasql = Nothing
        End Try
        Return restable

    End Function

    '�����û�ID�޸��û�����
    Function SetInfoByUserName(ByVal UserName As String, ByVal AutoHide As String, ByVal Preview As String) As Boolean
        Dim cnnConnection As New SqlConnection(Me.connectionString)
        'Dim strResult As String
        'ִ��SQl��������
        Dim cmdCommand As New SqlCommand("UPDATE T_USER SET  AUTOHIDE = '" + AutoHide + "',PREVIEW = '" + Preview + "' WHERE USER_NAME='" + UserName + "' ")
        Try
            '�����ݿ�����
            cnnConnection.Open()
            cmdCommand.Connection = cnnConnection
            cmdCommand.ExecuteNonQuery()
            Return True
        Catch sqlExecption As SqlException
            Return False
        Finally
            cmdCommand.Dispose()
            If (cnnConnection.State = ConnectionState.Open) Then
                cnnConnection.Close()
            End If
            cnnConnection = Nothing
        End Try
    End Function

    Public Sub New()
        Me.connectionString = ConfigurationSettings.AppSettings("ConnectionString")
    End Sub

End Class

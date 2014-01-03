Option Explicit On 
Option Strict On

Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration

Public Class CInputSchema
    Private connectionString As String

    '������
    ' �����ݿ��ȡXML����,���ô洢����sp_getSchema
    '�������:
    '  1  group  ���������
    '  2  schema ����ķ�����
    '����ֵ
    '  ����XML�ַ���
    Public Function GetSchemaDetail(ByVal group As String, ByVal schema As String) As String
        '�����ַ���
        Dim cnnConnection As New SqlConnection(Me.connectionString)
        'sql����Ϊ�洢����
        Dim cmdCommand As SqlCommand
        cmdCommand = New SqlCommand("sp_getSchema", cnnConnection)
        cmdCommand.CommandType = CommandType.StoredProcedure
        '����store Procedure ����  group ����
        cmdCommand.Parameters.Add("@I_SCHEMA_ID", SqlDbType.NVarChar)
        cmdCommand.Parameters("@I_SCHEMA_ID").Direction = ParameterDirection.Input
        cmdCommand.Parameters("@I_SCHEMA_ID").Value = group

        '����store Procedure ����  schema ������
        cmdCommand.Parameters.Add("@I_CYCLE_ID", SqlDbType.NVarChar)
        cmdCommand.Parameters("@I_CYCLE_ID").Direction = ParameterDirection.Input
        cmdCommand.Parameters("@I_CYCLE_ID").Value = schema

        Try
            '�����ݿ�����
            cnnConnection.Open()
            'ִ�д洢����,����XML����
            GetSchemaDetail = CType(cmdCommand.ExecuteScalar(), String)
        Catch sqlExecption As SqlException

        Finally
            If cnnConnection.State = ConnectionState.Open Then
                cnnConnection.Close()
            End If
            cnnConnection = Nothing
            cmdCommand = Nothing
        End Try
    End Function

    ' ����:
    '  ����ش���XML����,���ô洢���� sp_insertSchemaXML
    '  1 ������������ʹ��Update�޸�����
    '  2 ���������û��ʹ��insert�������ݵ����ݿ�
    '  3 �������ɹ�������Ϣ���û���ʾ����ɹ�����ʧ��
    '�������:
    '  1  schema_id  ���������
    '  2  schema ����ķ�����
    '  3  Ҫ�����xml����  
    '����ֵ:
    '  1  false �������ʧ��           
    '  2  true  �������ɹ�  

    Public Function SaveSchemaDetail(ByVal schema_id As String, ByVal cycle_id As Integer, ByVal xmlData As String) As Boolean
        Dim bState As Boolean = True
        '�����ַ���
        Dim cnnConnection As New SqlConnection(Me.connectionString)
        'sql����Ϊ�洢����
        Dim cmdCommand As SqlCommand
        cmdCommand = New SqlCommand("sp_insertSchemaXML", cnnConnection)
        cmdCommand.CommandType = CommandType.StoredProcedure
        '����store Procedure ����  group ����
        cmdCommand.Parameters.Add("@I_SCHEMA_ID", SqlDbType.NVarChar)
        cmdCommand.Parameters("@I_SCHEMA_ID").Direction = ParameterDirection.Input
        cmdCommand.Parameters("@I_SCHEMA_ID").Value = schema_id

        '����store Procedure ����  schema ������
        cmdCommand.Parameters.Add("@I_CYCLE_ID", SqlDbType.Int)
        cmdCommand.Parameters("@I_CYCLE_ID").Direction = ParameterDirection.Input
        cmdCommand.Parameters("@I_CYCLE_ID").Value = cycle_id

        '����store Procedure ����  xmlData �ش���XML���ݡ�
        cmdCommand.Parameters.Add("@I_XML", SqlDbType.NText)
        cmdCommand.Parameters("@I_XML").Direction = ParameterDirection.Input
        cmdCommand.Parameters("@I_XML").Value = xmlData

        Try
            '�����ݿ�����
            cnnConnection.Open()
            'ִ�д洢����
            cmdCommand.ExecuteNonQuery()
        Catch sqlExecption As SqlException
            bState = False

        Finally
            If (cnnConnection.State = ConnectionState.Open) Then
                cnnConnection.Close()
            End If
            cnnConnection = Nothing
            cmdCommand = Nothing
        End Try

        Return bState
    End Function


    '������
    ' �����ݿ��ȡmenuTree��Ҷ�ڵ�����,

    '����ֵ
    '  ����������A��B��ͷ�����ݼ�¼
    Public Function GetMenuData() As DataTable
        '�����ַ���
        Dim cnnConnection As New SqlConnection(Me.connectionString)
        'ִ��SQl��������
        Dim oAdapter As SqlDataAdapter = New SqlDataAdapter("SELECT * FROM T_GROUP_MS WHERE I_GROUP_ID LIKE 'B%'OR I_GROUP_ID LIKE 'A%'", cnnConnection)
        Dim dtTable As DataTable = New DataTable("T_GROUP_MS")

        Try
            '�����ݿ�����
            cnnConnection.Open()
            oAdapter.Fill(dtTable)
            GetMenuData = dtTable
        Catch sqlExecption As SqlException

        Finally
            If (cnnConnection.State = ConnectionState.Open) Then
                cnnConnection.Close()
            End If
            cnnConnection = Nothing
            oAdapter.Dispose()
        End Try
    End Function
    '������
    ' �����ݿ��ȡmenuTreeҶ�ڵ�����,

    '����ֵ
    '  ����������A��B��ͷ�����ݼ�¼
    Public Function GetSchema(ByVal node As String) As DataTable
        '�����ַ���
        Dim cnnConnection As New SqlConnection(Me.connectionString)
        'ִ��SQl��������
        Dim oAdapter As SqlDataAdapter = New SqlDataAdapter("select I_SCHEMA_ID,I_SCHEMA_NM from T_SCHEMA_MS  where I_SCHEMA_TP= '" + node + "'", cnnConnection)
        Dim dtTable As DataTable = New DataTable("T_GROUP_MS")

        Try
            '�����ݿ�����
            cnnConnection.Open()
            oAdapter.Fill(dtTable)
            GetSchema = dtTable
        Catch sqlExecption As SqlException

        Finally
            If (cnnConnection.State = ConnectionState.Open) Then
                cnnConnection.Close()
            End If
            cnnConnection = Nothing
            oAdapter.Dispose()
        End Try
    End Function

    Public Sub New()
        Me.connectionString = ConfigurationSettings.AppSettings("ConnectionString")
    End Sub
End Class

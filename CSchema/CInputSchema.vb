Option Explicit On 
Option Strict On

Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration

Public Class CInputSchema
    Private connectionString As String

    '描述：
    ' 从数据库读取XML数据,调用存储过程sp_getSchema
    '输入参数:
    '  1  group  输入的组名
    '  2  schema 输入的方案名
    '返回值
    '  返回XML字符串
    Public Function GetSchemaDetail(ByVal group As String, ByVal schema As String) As String
        '连接字符串
        Dim cnnConnection As New SqlConnection(Me.connectionString)
        'sql命令为存储过程
        Dim cmdCommand As SqlCommand
        cmdCommand = New SqlCommand("sp_getSchema", cnnConnection)
        cmdCommand.CommandType = CommandType.StoredProcedure
        '输入store Procedure 参数  group 组名
        cmdCommand.Parameters.Add("@I_SCHEMA_ID", SqlDbType.NVarChar)
        cmdCommand.Parameters("@I_SCHEMA_ID").Direction = ParameterDirection.Input
        cmdCommand.Parameters("@I_SCHEMA_ID").Value = group

        '输入store Procedure 参数  schema 方案名
        cmdCommand.Parameters.Add("@I_CYCLE_ID", SqlDbType.NVarChar)
        cmdCommand.Parameters("@I_CYCLE_ID").Direction = ParameterDirection.Input
        cmdCommand.Parameters("@I_CYCLE_ID").Value = schema

        Try
            '打开数据库连接
            cnnConnection.Open()
            '执行存储过程,返回XML数据
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

    ' 描述:
    '  保存回传的XML数据,调用存储过程 sp_insertSchemaXML
    '  1 如果数据项存在使用Update修改数据
    '  2 如果数据项没有使用insert增加数据到数据库
    '  3 如果保存成功，发消息给用户表示保存成功还是失败
    '输入参数:
    '  1  schema_id  输入的组名
    '  2  schema 输入的方案名
    '  3  要保存的xml数据  
    '返回值:
    '  1  false 如果保存失败           
    '  2  true  如果保存成功  

    Public Function SaveSchemaDetail(ByVal schema_id As String, ByVal cycle_id As Integer, ByVal xmlData As String) As Boolean
        Dim bState As Boolean = True
        '连接字符串
        Dim cnnConnection As New SqlConnection(Me.connectionString)
        'sql命令为存储过程
        Dim cmdCommand As SqlCommand
        cmdCommand = New SqlCommand("sp_insertSchemaXML", cnnConnection)
        cmdCommand.CommandType = CommandType.StoredProcedure
        '输入store Procedure 参数  group 组名
        cmdCommand.Parameters.Add("@I_SCHEMA_ID", SqlDbType.NVarChar)
        cmdCommand.Parameters("@I_SCHEMA_ID").Direction = ParameterDirection.Input
        cmdCommand.Parameters("@I_SCHEMA_ID").Value = schema_id

        '输入store Procedure 参数  schema 方案名
        cmdCommand.Parameters.Add("@I_CYCLE_ID", SqlDbType.Int)
        cmdCommand.Parameters("@I_CYCLE_ID").Direction = ParameterDirection.Input
        cmdCommand.Parameters("@I_CYCLE_ID").Value = cycle_id

        '输入store Procedure 参数  xmlData 回传的XML数据。
        cmdCommand.Parameters.Add("@I_XML", SqlDbType.NText)
        cmdCommand.Parameters("@I_XML").Direction = ParameterDirection.Input
        cmdCommand.Parameters("@I_XML").Value = xmlData

        Try
            '打开数据库连接
            cnnConnection.Open()
            '执行存储过程
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


    '描述：
    ' 从数据库读取menuTree非叶节点数据,

    '返回值
    '  返回所有以A或B开头的数据记录
    Public Function GetMenuData() As DataTable
        '连接字符串
        Dim cnnConnection As New SqlConnection(Me.connectionString)
        '执行SQl命令添充表
        Dim oAdapter As SqlDataAdapter = New SqlDataAdapter("SELECT * FROM T_GROUP_MS WHERE I_GROUP_ID LIKE 'B%'OR I_GROUP_ID LIKE 'A%'", cnnConnection)
        Dim dtTable As DataTable = New DataTable("T_GROUP_MS")

        Try
            '打开数据库连接
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
    '描述：
    ' 从数据库读取menuTree叶节点数据,

    '返回值
    '  返回所有以A或B开头的数据记录
    Public Function GetSchema(ByVal node As String) As DataTable
        '连接字符串
        Dim cnnConnection As New SqlConnection(Me.connectionString)
        '执行SQl命令填充表
        Dim oAdapter As SqlDataAdapter = New SqlDataAdapter("select I_SCHEMA_ID,I_SCHEMA_NM from T_SCHEMA_MS  where I_SCHEMA_TP= '" + node + "'", cnnConnection)
        Dim dtTable As DataTable = New DataTable("T_GROUP_MS")

        Try
            '打开数据库连接
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

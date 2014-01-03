' 静态模型
Option Strict On
Option Explicit On 

Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Runtime.Serialization


Public Class PubdataAccess
    Implements IDisposable

    Private dsCommand As SqlDataAdapter

    Private selectCommand As SqlCommand
    Private updateCommand As SqlCommand

    Public Sub New()
        MyBase.New()
        dsCommand = New SqlDataAdapter()
        updateCommand = New SqlCommand()

    End Sub

    Public Sub Dispose() Implements IDisposable.Dispose
        Dispose(True)
        GC.SuppressFinalize(True)

    End Sub

    Protected Sub Dispose(ByVal disposing As Boolean)
        If (Not disposing) Then
            Exit Sub
        End If

        If Not dsCommand Is Nothing Then
            If Not dsCommand.SelectCommand Is Nothing Then
                If Not dsCommand.SelectCommand.Connection Is Nothing Then
                    dsCommand.SelectCommand.Connection.Dispose()
                End If
                dsCommand.SelectCommand.Dispose()
            End If
            dsCommand.Dispose()
            dsCommand = Nothing
        End If

        If Not updateCommand Is Nothing Then
            If Not updateCommand.Connection Is Nothing Then
                updateCommand.Connection.Dispose()
            End If
            updateCommand.Dispose()
            updateCommand = Nothing
        End If
    End Sub

    '----------------------------------------------------------------
    ' Function ExecSelect:
    '   执行查询语句.
    ' Returns:
    '   结果集的DataSet
    ' Parameters:
    '   [in]  strSQL: 要执行的SQL语句.
    '----------------------------------------------------------------
    Public Function ExecSelect(ByVal strSQL As String, ByRef data As DataTable) As Integer


        With dsCommand
            '
            If selectCommand Is Nothing Then
                dsCommand.SelectCommand = New SqlCommand()
                dsCommand.SelectCommand.Connection = New SqlConnection(System.Configuration.ConfigurationSettings.AppSettings("PubdataDbConnctionString"))
            End If

            Try
                dsCommand.SelectCommand.CommandText = strSQL
                dsCommand.Fill(data)
                Return 0

            Catch ex As Exception
                Dim objLog As New ApplicationLog()
                objLog.WriteError("SQL语句： " & strSQL & " 执行出错，" & objLog.FormatException(ex))
                Return -100
            Finally     'Dispose resources
                If Not .SelectCommand Is Nothing Then
                    If Not .SelectCommand.Connection Is Nothing Then
                        .SelectCommand.Connection.Dispose()
                    End If
                    .SelectCommand.Dispose()
                End If
            End Try
            '
        End With

    End Function

    '----------------------------------------------------------------
    ' Function ExecUpdate:
    '   执行查询语句.
    ' Returns:
    '   Success:>=0
    '   failure:-100
    ' Parameters:
    '   [in]  strSQL: 要执行的SQL语句.
    '----------------------------------------------------------------
    Public Function ExecUpdate(ByVal strSQL As String) As Integer

        Try
            updateCommand.Connection = New SqlConnection(System.Configuration.ConfigurationSettings.AppSettings("PubdataDbConnctionString"))
            updateCommand.Connection.Open()
            updateCommand.CommandText = strSQL
            Return updateCommand.ExecuteNonQuery()

        Catch ex As Exception       'Catch errors
            Dim objLog As New ApplicationLog()
            objLog.WriteError("SQL语句： " & strSQL & " 执行出错，" & objLog.FormatException(ex))
            Return -100
        Finally     'Dispose resources
            If Not updateCommand.Connection Is Nothing Then
                updateCommand.Connection.Dispose()
            End If
        End Try
        '
    End Function

End Class ' END CLASS DEFINITION dbAccess



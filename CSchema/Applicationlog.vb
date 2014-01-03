'-----------------------------------------------------------------------------
' @CopyRight:
' @Author:
' @CreateDate:
' @ModifyDate:
' @Modifier:
' @Description:
' @Call Description:
'               dim objErrLog=new Applicationlog()
'               objErrlog.WriteError(objErrLog.FormatException(ex))
'
'---------------------------------------------------------------------------
Option Strict On
Option Explicit On 

Imports System.Text
Imports System.IO
Imports System.Diagnostics
Imports Microsoft.VisualBasic

Public Class ApplicationLog

    Public Sub New()

        MyBase.new()

    End Sub

    '----------------------------------------------------------------
    ' Shared Function FormatException:
    '   Write at the Verbose level to the event log and/or tracing file.
    ' Returns:
    '   A nicely format exception string, including message and StackTrace
    '     information.
    ' Parameters:
    '   [in] ex: The Exception object to format.
    '   [in] catchInfo: The string to prepend to the exception information.
    '----------------------------------------------------------------
    Public Shared Function FormatException(ByVal ex As Exception, Optional ByVal catchInfo As String = "") As String
        With New StringBuilder()
            If Len(catchInfo) <> 0 Then .Append(catchInfo).Append(ControlChars.CrLf) 'Chr(13) + Chr(10) 回车/换行符组合。
            FormatException = .Append(ex.Message).Append(ControlChars.CrLf).Append(ex.StackTrace).ToString
        End With
    End Function

    '----------------------------------------------------------------
    ' Shared Sub WriteError:
    '   Write at the Error level to the event log and/or tracing file.
    ' Parameters:
    '   [in] message: The text to write to the log file or event log.
    '----------------------------------------------------------------
    Public Shared Sub WriteError(ByVal message As String)
        'Defer to the helper function to log the message.
        WriteLog(TraceLevel.Error, message)
    End Sub

    '----------------------------------------------------------------
    ' Shared Sub WriteWarning:
    '   Write at the Warning level to the event log and/or tracing file.
    ' Parameters:
    '   [in] message: The text to write to the log file or event log.
    '----------------------------------------------------------------
    Public Shared Sub WriteWarning(ByVal message As String)

        'Defer to the helper function to log the message.
        WriteLog(TraceLevel.Warning, message)
    End Sub

    '----------------------------------------------------------------
    ' Shared Sub WriteInfo:
    '   Write at the Info level to the event log and/or tracing file.
    ' Parameters:
    '   [in] message: The text to write to the log file or event log.
    '----------------------------------------------------------------
    Public Shared Sub WriteInfo(ByVal message As String)

        'Defer to the helper function to log the message.
        WriteLog(TraceLevel.Info, message)
    End Sub

    '----------------------------------------------------------------
    ' Shared Sub WriteTrace:
    '   Write at the Verbose level to the event log and/or tracing file.
    ' Parameters:
    '   [in] message: The text to write to the log file or event log.
    '----------------------------------------------------------------
    Public Shared Sub WriteTrace(ByVal message As String)

        'Defer to the helper function to log the message.
        WriteLog(TraceLevel.Verbose, message)
    End Sub

    '----------------------------------------------------------------
    ' Shared Sub WriteLog:
    '   Determine where a string needs to be written based on the
    '     configuration settings and the error level
    ' Parameters:
    '   [in] level: The severity of the information to be logged.
    '   [in] messageText: The string to be logged.
    '----------------------------------------------------------------
    Private Shared Sub WriteLog(ByVal level As TraceLevel, ByVal messageText As String)

        '
        ' Be very careful by putting a Try/Catch around the entire routine.
        '   We should never throw an exception while logging.
        '
        Dim strlogType As String
        Try
            ' Write the message to the system event log. We only write the message
            '   if the configuration settings say it is severe enough to warrant
            '   an entry in the event log.
            '
            ' Map the trace level to the corresponding event log attribute.
            '   Note that EventLogEntryType = 2 ^ (level - 1), but it is generally not
            '   considered good style to apply arithmetic operations to enum values.

            Select Case level
                Case TraceLevel.Error
                    strlogType = "Error"
                Case TraceLevel.Warning
                    strlogType = "Warning"
                Case TraceLevel.Info
                    strlogType = "Information"
                Case TraceLevel.Verbose
                    strlogType = "SuccessAudit"
            End Select

            Dim logfilename As String

            logfilename = Configuration.ConfigurationSettings.AppSettings("LogFile")

            Dim objWriter As New StreamWriter(File.Open(logfilename, FileMode.Append))
            objWriter.WriteLine(Now & strlogType & ":" & messageText)
            objWriter.Close()
        Catch

            'Ignore any exceptions.
        End Try


    End Sub
End Class

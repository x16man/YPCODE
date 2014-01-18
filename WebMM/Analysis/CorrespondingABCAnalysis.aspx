<%@ Page Language="c#" CodeBehind="CorrespondingABCAnalysis.aspx.cs" AutoEventWireup="True"
    Inherits="WebMM.Analysis.CorrespondingABCAnalysis" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>CorrespondingABCAnalysis</title>
</head>
<body  bottommargin="0" leftmargin="0" topmargin="0" rightmargin="0">
    <form id="Form1" method="post" runat="server">
    <table id="Table1" width="100%">
        <tr height="5px">
            <td>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                <iframe src="CorrespondingABCYearCompare.aspx?Type=0" frameborder="no" width="100%"
                    height="170"></iframe>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                <iframe src="CorrespondingABCYearCompare.aspx?Type=1" frameborder="no" width="100%"
                    height="170"></iframe>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                <iframe src="CorrespondingABCYearCompare.aspx?Type=2" frameborder="no" width="100%"
                    height="170"></iframe>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>

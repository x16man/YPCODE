<%@ Page Language="c#" CodeBehind="CurrentAnalysis.aspx.cs" AutoEventWireup="True"
    Inherits="WebMM.Analysis.CurrentAnalysis" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>CurrentAnalysis</title>
    <link href="../CSS/StyleSheet.css" type="text/css" rel="stylesheet">
</head>
<body  topmargin="0">
    <form id="Form1" method="post" runat="server">
    <table width="100%">
        <tr>
            <td>
                <iframe src="CurrentROS.aspx" frameborder="no" width="400" height="300"></iframe>
            </td>
            <td>
                <iframe src="CurrentWithDraw.aspx" frameborder="no" width="400" height="300"></iframe>
            </td>
        </tr>
        <tr>
            <td>
                <iframe src="CurrentStock.aspx" frameborder="no" width="400" height="300"></iframe>
            </td>
            <td>
                <iframe src="CurrentVendor.aspx" frameborder="no" width="400" height="300"></iframe>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>

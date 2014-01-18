<%@ Page Language="c#" CodeBehind="CorrespondingAnalysis.aspx.cs" AutoEventWireup="True"
    Inherits="WebMM.Analysis.CorrespondingAnalysis" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>CorrespondingAnalysis</title>
</head>
<body  bottommargin="0" leftmargin="0" topmargin="0" rightmargin="0">
    <form id="Form1" method="post" runat="server">
    <font face="ËÎÌו">
        <table id="Table1" style="z-index: 101; left: 8px; position: absolute; top: 8px"
            cellspacing="1" cellpadding="1" width="100%" border="0">
            <tr>
                <td>
                    <iframe src="CorrespondingPeriodYearCompare.aspx?Flag=0" frameborder="no" width="420"
                        height="250"></iframe>
                </td>
                <td>
                    <iframe src="CorrespondingPeriodYearCompare.aspx?Flag=1" frameborder="no" width="420"
                        height="250"></iframe>
                </td>
            </tr>
            <tr>
                <td>
                    <iframe src="CorrespondingPeriodYearCompare.aspx?Flag=2" frameborder="no" width="420"
                        height="250"></iframe>
                </td>
                <td>
                    <iframe src="CorrespondingPeriodYearCompare.aspx?Flag=3" frameborder="no" width="420"
                        height="250"></iframe>
                </td>
            </tr>
        </table>
    </font>
    </form>
</body>
</html>

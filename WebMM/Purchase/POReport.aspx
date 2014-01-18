<%@ Page Language="c#" CodeBehind="POReport.aspx.cs" AutoEventWireup="True" Inherits="MZHMM.WebMM.Purchase.POReport" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>物料系统</title>
</head>
<body bottommargin="0" leftmargin="0" topmargin="0" rightmargin="0">
    <form id="Form1" method="post" runat="server">
    <font face="宋体">
        <mzhview:ReportViewer ID="ReportViewer1" runat="server" Width="100%" Height="500">
        </mzhview:ReportViewer>
    </font>
    </form>
</body>
</html>

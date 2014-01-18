<%@ Page Language="c#" CodeBehind="PPAYDetail.aspx.cs" AutoEventWireup="True" Inherits="MZHMM.WebMM.Purchase.PPAYDetail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>采购收料付款单</title>
    <link href="../CSS/Purchase/PPAYDetail.css" type="text/css" rel="stylesheet">
</head>
<body>
    <form id="Form1" method="post" runat="server">
    <mzhview:ReportViewer ID="ReportViewer1" runat="server" Width="100%" Height="500"
        Parameters="False"></mzhview:ReportViewer>
    </form>
</body>
</html>

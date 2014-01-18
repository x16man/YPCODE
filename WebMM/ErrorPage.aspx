<%@ Page Language="c#" CodeBehind="ErrorPage.aspx.cs" AutoEventWireup="True" Inherits="MZHMM.WebMM.ErrorPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head  runat="server">
    <title>ErrorPage</title>
    <link href="CSS/StyleSheet.css" type="text/css" rel="stylesheet">
</head>
<body>
    <form id="Form1" method="post" runat="server">
    <asp:Label ID="Label1" runat="server" Font-Size="Large"></asp:Label>
    <a href="#" onclick="window.history.go(-1)">·µ»Ø</a>
    </form>
</body>
</html>

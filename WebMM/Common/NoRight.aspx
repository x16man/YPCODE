<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="NoRight.aspx.cs"
    Inherits="MZHMM.WebMM.Common.NoRight" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" Text="你无权操作此页面"></asp:Label>
        <a href="#" onclick="window.history.go(-1)">返回</a>
    </div>
    </form>
</body>
</html>

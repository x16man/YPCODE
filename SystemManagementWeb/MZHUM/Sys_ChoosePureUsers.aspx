<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sys_ChoosePureUsers.aspx.cs" Inherits="SystemManagement.MZHUM.Sys_ChoosePureUsers" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>人员选择</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:Label runat="server" ID="lblInformation" Visible = "false" Text ="没有指定部门信息！" ForeColor ="Red" Font-Bold ="true"></asp:Label>
    <asp:CheckBoxList runat="server" ID="cblUsers" RepeatDirection="Horizontal" 
            RepeatLayout="Flow"></asp:CheckBoxList>
    </div>
    <div style="text-align:right;padding:3px 10px"><asp:Button runat="server" 
            ID="btnYes" Text ="确定" onclick="btnYes_Click" /><input type="button" value ="关闭" onclick ="window.close();" /></div>
    </form>
</body>
</html>

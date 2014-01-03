<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DynamicControlViewState.aspx.cs"
    Inherits="SystemManagement.Test.DynamicControlViewState" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../CSS/Common.css" rel="stylesheet" type="text/css" />
    <link href="../CSS/toolbar.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../JS/PopupWindow.js"></script>
    <script type="text/javascript" src="../JS/jquery-1.2.6.js"></script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
        <mzh:MzhToolbar ID="MzhToolbar1" runat="server" SEModuleID="MM-001" CheckBoxListRepeatColumns="3" OnSEQuery_Click="OnSEQuery_Click">
            <mzh:ToolbarButton ID="tbiAddRoot" runat="server" CausesValidation="True" Cellpadding="0"
                Cellspacing="0" HasIcon="True" IconClass="addRoot" IsShowText="True" ItemId="New"
                LabelClass="labelCell" NakedLabelClass="nakedLabelCell" TableClass="buttonTable"
                Text="新建根"  /> 
            <mzh:ToolbarLabel runat="server" text="开始日期：">
            </mzh:ToolbarLabel>     
            <mzh:ToolbarCalendar runat="server">
            </mzh:ToolbarCalendar>
            <mzh:ToolbarLabel runat="server" text="结束日期：">
            </mzh:ToolbarLabel>     
            <mzh:ToolbarCalendar runat="server">
            </mzh:ToolbarCalendar>
        </mzh:MzhToolbar>
        <asp:Label ID="output" runat="server" Text="结果:"></asp:Label>
    </div>
    </form>
</body>
</html>

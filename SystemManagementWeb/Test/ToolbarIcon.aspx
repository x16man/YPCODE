<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ToolbarIcon.aspx.cs" Inherits="SystemManagement.Test.ToolbarIcon" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    
    <script src="/aspnet_client/Shmzh.Web.UI/jquery-1.2.6.pack.js" type="text/javascript"></script>
    <link href="../CSS/Common.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <mzh:MzhToolbar ID="MzhToolbar1" runat="server">
            <mzh:ToolbarButton ID="tbiReturn" runat="server" CausesValidation="True" Cellpadding="0"
                Cellspacing="0" HasIcon="True" IconClass="return" IsShowText="True" ItemId="return"
                LabelClass="labelCell" NakedLabelClass="nakedLabelCell" TableClass="buttonTable" tooltip="return"
                Text="返回" />
            <mzh:ToolbarButton ID="tbiGo" runat="server" CausesValidation="True" Cellpadding="0"
                Cellspacing="0" HasIcon="True" IconClass="go" IsShowText="True" ItemId="go"
                LabelClass="labelCell" NakedLabelClass="nakedLabelCell" TableClass="buttonTable" tooltip="go"
                Text="Go" />    
            <mzh:ToolbarButton ID="tbiAddRoot" runat="server" CausesValidation="True" Cellpadding="0"
                Cellspacing="0" HasIcon="True" IconClass="addRoot" IsShowText="True" ItemId="New"
                LabelClass="labelCell" NakedLabelClass="nakedLabelCell" TableClass="buttonTable" tooltip="addRoot"
                Text="新建根" />
            <mzh:ToolbarButton ID="tbiAdd" runat="server" CausesValidation="True" Cellpadding="0"
                Cellspacing="0" HasIcon="True" IconClass="add" IsShowText="True" ItemId="New"
                LabelClass="labelCell" NakedLabelClass="nakedLabelCell" TableClass="buttonTable" tooltip="add"
                Text="新建" />
            <mzh:ToolbarButton ID="tbiEdit" runat="server" CausesValidation="True" Cellpadding="0"
                Cellspacing="0" HasIcon="True" IconClass="edit" IsShowText="True" ItemId="New"
                LabelClass="labelCell" NakedLabelClass="nakedLabelCell" TableClass="buttonTable" tooltip="edit"
                Text="编辑" />
            <mzh:ToolbarButton ID="ToolbarButton5" runat="server" AutoPostBack="False" text="提交"
                CausesValidation="True" Cellpadding="0" Cellspacing="0" HasIcon="True" IconClass="present"
                IsShowText="True" ItemId="toggle" LabelClass="labelCell" NakedLabelClass="nakedLabelCell" tooltip="present"
                TableClass="buttonTable" />
            <mzh:ToolbarButton ID="tbiCancel" runat="server" CausesValidation="True" Cellpadding="0"
                Cellspacing="0" HasIcon="True" IconClass="cancel" IsShowText="True" ItemId="New"
                LabelClass="labelCell" NakedLabelClass="nakedLabelCell" TableClass="buttonTable" tooltip="cancel"
                Text="作废" />
            <mzh:ToolbarButton ID="tbiDelete" runat="server" CausesValidation="True" Cellpadding="0"
                Cellspacing="0" HasIcon="True" IconClass="delete" IsShowText="True" ItemId="New" tooltip="delete"
                LabelClass="labelCell" NakedLabelClass="nakedLabelCell" TableClass="buttonTable"
                Text="删除" />
            <mzh:ToolbarButton ID="tbiSave" runat="server" CausesValidation="True" Cellpadding="0"
                Cellspacing="0" HasIcon="True" IconClass="save" IsShowText="True" ItemId="New"
                LabelClass="labelCell" NakedLabelClass="nakedLabelCell" TableClass="buttonTable" tooltip="save"
                Text="保存" />
            <mzh:ToolbarButton ID="tbiView" runat="server" CausesValidation="True" Cellpadding="0"
                Cellspacing="0" HasIcon="True" IconClass="view" IsShowText="True" ItemId="New"
                LabelClass="labelCell" NakedLabelClass="nakedLabelCell" TableClass="buttonTable" tooltip="view"
                Text="查看" />
            <mzh:ToolbarButton ID="tbiQuery" runat="server" CausesValidation="True" Cellpadding="0"
                Cellspacing="0" HasIcon="True" IconClass="query" IsShowText="True" ItemId="New"
                LabelClass="labelCell" NakedLabelClass="nakedLabelCell" TableClass="buttonTable" tooltip = "query"
                Text="查询" />
            <mzh:ToolbarButton ID="tbiAudit" runat="server" CausesValidation="True" Cellpadding="0"
                Cellspacing="0" HasIcon="True" IconClass="audit" IsShowText="True" ItemId="New"
                LabelClass="labelCell" NakedLabelClass="nakedLabelCell" TableClass="buttonTable" tooltip="audit"
                Text="审批" />
            <mzh:ToolbarButton ID="tbiClose" runat="server" CausesValidation="True" Cellpadding="0"
                Cellspacing="0" HasIcon="True" IconClass="close" IsShowText="True" ItemId="New"
                LabelClass="labelCell" NakedLabelClass="nakedLabelCell" TableClass="buttonTable" tooltip="close"
                Text="关闭" />
            <mzh:ToolbarButton ID="tbiPre" runat="server" CausesValidation="True" Cellpadding="0"
                Cellspacing="0" HasIcon="True" IconClass="pre" IsShowText="True" ItemId="New"
                LabelClass="labelCell" NakedLabelClass="nakedLabelCell" TableClass="buttonTable" tooltip = "pre"
                Text="前一" />
            <mzh:ToolbarButton ID="tbiNext" runat="server" CausesValidation="True" Cellpadding="0"
                Cellspacing="0" HasIcon="True" IconClass="next" IsShowText="True" ItemId="New"
                LabelClass="labelCell" NakedLabelClass="nakedLabelCell" TableClass="buttonTable" tooltip = "next"
                Text="下一" />
            <mzh:ToolbarButton ID="tbiKey" runat="server" CausesValidation="True" Cellpadding="0"
                Cellspacing="0" HasIcon="True" IconClass="key" IsShowText="True" ItemId="New"
                LabelClass="labelCell" NakedLabelClass="nakedLabelCell" TableClass="buttonTable" tooltip="key"
                Text="口令" />
            <mzh:ToolbarButton ID="tbiAddUser" runat="server" CausesValidation="True" Cellpadding="0"
                Cellspacing="0" HasIcon="True" IconClass="addUser" IsShowText="True" ItemId="New"
                LabelClass="labelCell" NakedLabelClass="nakedLabelCell" TableClass="buttonTable" tooltip="addUser"
                Text="添加用户" />
            <mzh:ToolbarButton ID="tbiEditUser" runat="server" CausesValidation="True" Cellpadding="0"
                Cellspacing="0" HasIcon="True" IconClass="editUser" IsShowText="True" ItemId="New"
                LabelClass="labelCell" NakedLabelClass="nakedLabelCell" TableClass="buttonTable" tooltip="editUser"
                Text="编辑用户" />
            <mzh:ToolbarButton ID="tbiDeleteUser" runat="server" CausesValidation="True" Cellpadding="0"
                Cellspacing="0" HasIcon="True" IconClass="deleteUser" IsShowText="True" ItemId="New"
                LabelClass="labelCell" NakedLabelClass="nakedLabelCell" TableClass="buttonTable" tooltip="deleteUser"
                Text="删除用户" />
            <mzh:ToolbarButton ID="tbiMove" runat="server" CausesValidation="True" Cellpadding="0"
                Cellspacing="0" HasIcon="True" IconClass="move" IsShowText="True" ItemId="New"
                LabelClass="labelCell" NakedLabelClass="nakedLabelCell" TableClass="buttonTable" tooltip="move"
                Text="转移" />
            <mzh:ToolbarButton ID="tbiConfig" runat="server" CausesValidation="True" Cellpadding="0"
                Cellspacing="0" HasIcon="True" IconClass="config" IsShowText="True" ItemId="New"
                LabelClass="labelCell" NakedLabelClass="nakedLabelCell" TableClass="buttonTable" tooltip="config"
                Text="设置" />
            <mzh:ToolbarButton ID="ToolbarButton2" runat="server" AutoPostBack="True" CausesValidation="True"
                Cellpadding="0" Cellspacing="0" HasIcon="True" text="一级审批" IconClass="audit1"
                IsShowText="True" ItemId="toggle" LabelClass="labelCell" NakedLabelClass="nakedLabelCell" tooltip="audit1"
                TableClass="buttonTable" />
            <mzh:ToolbarButton ID="ToolbarButton3" runat="server" AutoPostBack="False" text="二级审批"
                CausesValidation="True" Cellpadding="0" Cellspacing="0" HasIcon="True" IconClass="audit2"
                IsShowText="True" ItemId="toggle" LabelClass="labelCell" NakedLabelClass="nakedLabelCell" tooltip="audit2"
                TableClass="buttonTable" />
            <mzh:ToolbarButton ID="ToolbarButton4" runat="server" AutoPostBack="False" text="三级审批"
                CausesValidation="True" Cellpadding="0" Cellspacing="0" HasIcon="True" IconClass="audit3"
                IsShowText="True" ItemId="toggle" LabelClass="labelCell" NakedLabelClass="nakedLabelCell" tooltip="audit3"
                TableClass="buttonTable" />
            <mzh:ToolbarButton ID="tbiExpand" runat="server" CausesValidation="True" Cellpadding="0"
                Cellspacing="0" HasIcon="True" IconClass="expand" IsShowText="True" ItemId="New"
                LabelClass="labelCell" NakedLabelClass="nakedLabelCell" TableClass="buttonTable" tooltip="expand"
                Text="展开" />
            <mzh:ToolbarButton ID="tbiCollapse" runat="server" CausesValidation="True" Cellpadding="0"
                Cellspacing="0" HasIcon="True" IconClass="collapse" IsShowText="True" ItemId="New"
                LabelClass="labelCell" NakedLabelClass="nakedLabelCell" TableClass="buttonTable" tooltip="collapse"
                Text="收缩" />
                <mzh:ToolbarButton ID="tbiRed" runat="server" CausesValidation="True" Cellpadding="0"
                Cellspacing="0" HasIcon="True" IconClass="red" IsShowText="True" ItemId="red"
                LabelClass="labelCell" NakedLabelClass="nakedLabelCell" TableClass="buttonTable" tooltip="red"
                Text="红字" />
                <mzh:ToolbarButton ID="tbiUp" runat="server" CausesValidation="True" Cellpadding="0"
                Cellspacing="0" HasIcon="True" IconClass="up" IsShowText="True" ItemId="red"
                LabelClass="labelCell" NakedLabelClass="nakedLabelCell" TableClass="buttonTable" tooltip="up"
                Text="上一" />
                <mzh:ToolbarButton ID="tbiDown" runat="server" CausesValidation="True" Cellpadding="0"
                Cellspacing="0" HasIcon="True" IconClass="down" IsShowText="True" ItemId="red"
                LabelClass="labelCell" NakedLabelClass="nakedLabelCell" TableClass="buttonTable" tooltip="down"
                Text="下一" />
                <mzh:ToolbarButton ID="tbiIn" runat="server" CausesValidation="True" Cellpadding="0"
                Cellspacing="0" HasIcon="True" IconClass="in" IsShowText="True" ItemId="red"
                LabelClass="labelCell" NakedLabelClass="nakedLabelCell" TableClass="buttonTable" tooltip="in"
                Text="收料" />
                <mzh:ToolbarButton ID="tbiOut" runat="server" CausesValidation="True" Cellpadding="0"
                Cellspacing="0" HasIcon="True" IconClass="out" IsShowText="True" ItemId="red"
                LabelClass="labelCell" NakedLabelClass="nakedLabelCell" TableClass="buttonTable" tooltip="out"
                Text="发料" />
                <mzh:ToolbarButton ID="tbiGroup" runat="server" CausesValidation="True" Cellpadding="0"
                Cellspacing="0" HasIcon="True" IconClass="group" IsShowText="True" ItemId="group"
                LabelClass="labelCell" NakedLabelClass="nakedLabelCell" TableClass="buttonTable" tooltip="group"
                Text="组" />
                <mzh:ToolbarButton ID="tbiGroupAdd" runat="server" CausesValidation="True" Cellpadding="0"
                Cellspacing="0" HasIcon="True" IconClass="groupAdd" IsShowText="True" ItemId="groupAdd"
                LabelClass="labelCell" NakedLabelClass="nakedLabelCell" TableClass="buttonTable" tooltip="groupAdd"
                Text="组" />
                <mzh:ToolbarButton ID="tbiGroupEdit" runat="server" CausesValidation="True" Cellpadding="0"
                Cellspacing="0" HasIcon="True" IconClass="groupEdit" IsShowText="True" ItemId="groupEdit"
                LabelClass="labelCell" NakedLabelClass="nakedLabelCell" TableClass="buttonTable" tooltip="groupEdit"
                Text="组" />
                <mzh:ToolbarButton ID="tbiGroupDelete" runat="server" CausesValidation="True" Cellpadding="0"
                Cellspacing="0" HasIcon="True" IconClass="groupDelete" IsShowText="True" ItemId="groupDelete"
                LabelClass="labelCell" NakedLabelClass="nakedLabelCell" TableClass="buttonTable" tooltip="groupDelete"
                Text="组" />
                <mzh:ToolbarButton ID="tbiUser" runat="server" CausesValidation="True" Cellpadding="0"
                Cellspacing="0" HasIcon="True" IconClass="user" IsShowText="True" ItemId="user"
                LabelClass="labelCell" NakedLabelClass="nakedLabelCell" TableClass="buttonTable" tooltip="user"
                Text="用户" />
                <mzh:ToolbarButton ID="tbiUserAdd" runat="server" CausesValidation="True" Cellpadding="0"
                Cellspacing="0" HasIcon="True" IconClass="userAdd" IsShowText="True" ItemId="userAdd"
                LabelClass="labelCell" NakedLabelClass="nakedLabelCell" TableClass="buttonTable" tooltip="userAdd"
                Text="用户" />
                <mzh:ToolbarButton ID="tbiUserEdit" runat="server" CausesValidation="True" Cellpadding="0"
                Cellspacing="0" HasIcon="True" IconClass="userEdit" IsShowText="True" ItemId="userEdit"
                LabelClass="labelCell" NakedLabelClass="nakedLabelCell" TableClass="buttonTable" tooltip="userEdit"
                Text="用户" />
                <mzh:ToolbarButton ID="tbiUserDelete" runat="server" CausesValidation="True" Cellpadding="0"
                Cellspacing="0" HasIcon="True" IconClass="userDelete" IsShowText="True" ItemId="userDelete"
                LabelClass="labelCell" NakedLabelClass="nakedLabelCell" TableClass="buttonTable" tooltip="userDelete"
                Text="用户" />
                <mzh:ToolbarButton ID="tbiFolder" runat="server" CausesValidation="True" Cellpadding="0"
                Cellspacing="0" HasIcon="True" IconClass="folder" IsShowText="True" ItemId="folder"
                LabelClass="labelCell" NakedLabelClass="nakedLabelCell" TableClass="buttonTable" tooltip="folder"
                Text="分类" />
                <mzh:ToolbarButton ID="tbiFolderAdd" runat="server" CausesValidation="True" Cellpadding="0"
                Cellspacing="0" HasIcon="True" IconClass="folderAdd" IsShowText="True" ItemId="folderAdd"
                LabelClass="labelCell" NakedLabelClass="nakedLabelCell" TableClass="buttonTable" tooltip="folderAdd"
                Text="分类" />
                <mzh:ToolbarButton ID="tbiFolderEdit" runat="server" CausesValidation="True" Cellpadding="0"
                Cellspacing="0" HasIcon="True" IconClass="folderEdit" IsShowText="True" ItemId="folderEdit"
                LabelClass="labelCell" NakedLabelClass="nakedLabelCell" TableClass="buttonTable" tooltip="folderEdit"
                Text="分类" />
                <mzh:ToolbarButton ID="tbiFolderDelete" runat="server" CausesValidation="True" Cellpadding="0"
                Cellspacing="0" HasIcon="True" IconClass="folderDelete" IsShowText="True" ItemId="folderDelete"
                LabelClass="labelCell" NakedLabelClass="nakedLabelCell" TableClass="buttonTable" tooltip="folderDelete"
                Text="分类" />
                <mzh:ToolbarButton ID="tbiRefresh" runat="server" CausesValidation="True" Cellpadding="0"
                Cellspacing="0" HasIcon="True" IconClass="refresh" IsShowText="True" ItemId="refresh"
                LabelClass="labelCell" NakedLabelClass="nakedLabelCell" TableClass="buttonTable" tooltip="refresh"
                Text="刷新" />
        </mzh:MzhToolbar>
    </div>
    </form>
</body>
</html>

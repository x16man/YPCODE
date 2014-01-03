<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="History.aspx.cs" Inherits="SystemManagement.Login.History" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>系统访问记录</title>
    <link rel="stylesheet" type="text/css" href="../CSS/common.css" />

    <script src="/aspnet_client/Shmzh.Web.UI/jquery-1.2.6.pack.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server">
    <mzh:MzhTitle ID="MzhTitle1" runat="server" />
    <div id="main">
        <mzh:MzhToolbar ID="MzhToolbar1" runat="server" OnItemPostBack="MzhToolbar1_ItemPostBack">
            <mzh:ToolbarButton ID="ToolbarButton_Pre" runat="server" AutoPostBack="True" CausesValidation="True"
                Cellpadding="0" Cellspacing="0" tooltip="往前一天" HasIcon="True" IconClass="pre"
                IsShowText="False" ItemId="Pre" LabelClass="labelCell" NakedLabelClass="nakedLabelCell"
                TableClass="buttonTable" />
            <mzh:ToolbarButton ID="ToolbarButton_Next" runat="server" AutoPostBack="True" CausesValidation="True"
                Cellpadding="0" Cellspacing="0" tooltip="往后一天" HasIcon="True" IconClass="next"
                IsShowText="False" ItemId="next" LabelClass="labelCell" NakedLabelClass="nakedLabelCell"
                TableClass="buttonTable" />
            <mzh:ToolbarSeparator ID="ToolbarSeparator1" runat="server" CausesValidation="True"
                ItemId="" SeparatorClass="toolbarIconDivider" />
            <mzh:ToolbarLabel ID="ToolbarLabel1" runat="server" CausesValidation="True" Cellpadding="0"
                Cellspacing="0" ItemId="" LabelClass="labelCell" TableClass="labelTable" Text="开始日期：" />
            <mzh:ToolbarCalendar ID="ToolbarCalendar_BeginDate" runat="server" CausesValidation="True"
                Cellpadding="0" Cellspacing="0" ItemId="BeginDate" ReadOnly="False" ShowOnly="False"
                TableClass="labelTable" />
            <mzh:ToolbarLabel ID="ToolbarLabel2" runat="server" CausesValidation="True" Cellpadding="0"
                Cellspacing="0" ItemId="" LabelClass="labelCell" TableClass="labelTable" Text="结束日期：" />
            <mzh:ToolbarCalendar ID="ToolbarCalendar_EndDate" runat="server" CausesValidation="True"
                Cellpadding="0" Cellspacing="0" ItemId="EndDate" ReadOnly="False" ShowOnly="False"
                TableClass="labelTable" />
                <mzh:ToolbarSeparator ID="ToolbarSeparator3" runat="server" CausesValidation="True"
                ItemId="" SeparatorClass="toolbarIconDivider" />
            <mzh:ToolbarButton ID="ToolbarButton_Query" runat="server" AutoPostBack="True" CausesValidation="True"
                Cellpadding="0" Cellspacing="0" HasIcon="True" IconClass="query" IsShowText="True"
                ItemId="query" LabelClass="labelCell" NakedLabelClass="nakedLabelCell" TableClass="buttonTable"
                Text="查询" />
        </mzh:MzhToolbar>
        <div>
            <mzh:MzhDataGrid ID="dg_History" runat="server" name="MzhMultiSelectDataGrid" selecttype="MultiSelect"
                IdCell="0" AutoGenerateColumns="False" AllowPaging="true" HignLightCSS="m-grid-row-over"
                AllowSorting="true" cssclassforpagerbuttonjump="m-grid-pager-button-jump" SelectedCSS="m-grid-row-selected"
                ShowPageSize="true" CssClass="datagrid" cssclassforpagerinputpage="m-grid-pager-input-page"
                MultiPageShowMode="DropListMode" PageSize="20">
                <Columns>
                    <asp:BoundColumn DataField="UserName" SortExpression="UserName" HeaderText="用户名">
                        <HeaderStyle Width="80px" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="Operation" SortExpression="Operation" HeaderText="动作">
                        <HeaderStyle Width="80px" />
                        <ItemStyle CssClass="center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="IpAddress" SortExpression="IpAddress" HeaderText="Ip地址">
                        <HeaderStyle Width="180px" />
                        <ItemStyle CssClass="center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="OpTime" SortExpression="OpTime" HeaderText="时间">
                        <HeaderStyle Width="180px" />
                        <ItemStyle CssClass="center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn></asp:BoundColumn>
                </Columns>
            </mzh:MzhDataGrid>
        </div>
    </div>
    </form>
</body>
</html>

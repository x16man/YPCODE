<%@ Page Language="c#" CodeBehind="SYS_OperationLogList.aspx.cs" AutoEventWireup="True" Inherits="SystemManagement.MZHUM.SYS_OperationLogList" %>



<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>操作日志列表</title>
    <link rel="stylesheet" type="text/css" href="../CSS/common.css" />

    <script src="/aspnet_client/Shmzh.Web.UI/jquery-1.2.6.pack.js" type="text/javascript"></script>
</head>
<body>
    <form id="Form1" method="post" runat="server">
    <mzh:MzhTitle ID="MzhTitle1" runat="server" />
    <div id="main">
        <mzh:MzhToolbar ID="MzhToolbar1" runat="server" OnItemPostBack="MzhToolbar1_ItemPostBack">
            <mzh:ToolbarLabel ID="ToolbarLabel1" runat="server" CausesValidation="True" 
                Cellpadding="0" Cellspacing="0" ItemId="" LabelClass="labelCell" 
                TableClass="labelTable" Text="开始日期：" />
            <mzh:ToolbarCalendar ID="tbiBeginTime" runat="server" CausesValidation="True" 
                Cellpadding="0" Cellspacing="0" ItemId="BeginTime" ReadOnly="False" 
                ShowOnly="False" TableClass="labelTable" />
            <mzh:ToolbarLabel ID="ToolbarLabel2" runat="server" CausesValidation="True" 
                Cellpadding="0" Cellspacing="0" ItemId="" LabelClass="labelCell" 
                TableClass="labelTable" Text="结束日期：" />
            <mzh:ToolbarCalendar ID="tbiEndTime" runat="server" CausesValidation="True" 
                Cellpadding="0" Cellspacing="0" ItemId="EndTime" ReadOnly="False" 
                ShowOnly="False" TableClass="labelTable" />
            <mzh:ToolbarSeparator ID="ToolbarSeparator1" runat="server" 
                CausesValidation="True" ItemId="" SeparatorClass="toolbarIconDivider" />
                
            
            <mzh:ToolbarDropdownList ID="tbiProduct" runat="server" 
                CausesValidation="True" Cellpadding="0" Cellspacing="0" Enabled="True" 
                ItemId="product" SelectedIndex="-1" TableClass="labelTable" />
            <mzh:ToolbarLabel ID="ToolbarLabel3" runat="server" CausesValidation="True" 
                Cellpadding="0" Cellspacing="0" ItemId="" LabelClass="labelCell" Text="操作描述：" 
                TableClass="labelTable" />
            <mzh:ToolbarTextBox ID="tbiOpDesc" runat="server" CausesValidation="True" 
                Cellpadding="0" Cellspacing="0" ItemId="opDesc" ReadOnly="False" toolTip="请输入操作描述内容" 
                TableClass="labelTable" Columns="25" MaxLength="100" />
            <mzh:ToolbarSeparator ID="ToolbarSeparator2" runat="server" 
                CausesValidation="True" ItemId="" SeparatorClass="toolbarIconDivider" />
                <mzh:ToolbarButton ID="tbiQuery" runat="server" AutoPostBack="True" 
                CausesValidation="True" Cellpadding="0" Cellspacing="0" HasIcon="True" 
                IconClass="query" IsShowText="True" ItemId="Query" LabelClass="labelCell" 
                NakedLabelClass="nakedLabelCell" TableClass="buttonTable" Text="查询" />
            
        </mzh:MzhToolbar>
        <mzh:MzhDataGrid ID="dg_OperationLog" runat="server" name="MzhMultiSelectDataGrid"
            selecttype="MultiSelect" IdCell="0" AutoGenerateColumns="False" AllowPaging="True"
            HignLightCSS="m-grid-row-over" cssclassforpagerbuttonjump="m-grid-pager-button-jump"
            SelectedCSS="m-grid-row-selected" CssClass="datagrid" cssclassforpagerinputpage="m-grid-pager-input-page"
            MultiPageShowMode="DropListMode" TotalRecorderCount="0"
            PageSize="20" AllowSorting="True" ShowRecordsCount="True" ShowPageSize="true" 
            >
            <HeaderStyle Wrap="False"></HeaderStyle>
            <Columns>
                <asp:BoundColumn DataField="UserName" SortExpression="UserName" HeaderText="用户名">
                    <HeaderStyle Width="80px"></HeaderStyle>
                    <ItemStyle CssClass="center" />
                </asp:BoundColumn>
                <asp:BoundColumn DataField="OpTime" SortExpression="OpTime" HeaderText="操作时间">
                    <HeaderStyle Width="130px"></HeaderStyle>
                </asp:BoundColumn>
                <asp:BoundColumn DataField="OpDesc" SortExpression="OpDesc" HeaderText="操作描述">
                </asp:BoundColumn>
            </Columns>
            <PagerStyle HorizontalAlign="Right" Mode="NumericPages"></PagerStyle>
        </mzh:MzhDataGrid>
        <div class="hidden">
            <asp:Button ID="btnRefresh" runat="server" Text="refresh" 
                onclick="btnRefresh_Click" />
        </div>
    </div>
    </form>
</body>
</html>

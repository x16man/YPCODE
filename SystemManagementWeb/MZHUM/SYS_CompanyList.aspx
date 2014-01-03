<%@ Page Language="c#" CodeBehind="SYS_CompanyList.aspx.cs" AutoEventWireup="True"
    Inherits="SystemManagement.MZHUM.SYS_CompanyList" %>



<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>产品列表</title>
    <link rel="stylesheet" type="text/css" href="../CSS/common.css" />

    <script src="/aspnet_client/Shmzh.Web.UI/jquery-1.2.6.pack.js" type="text/javascript"></script>

    <script src="../JS/PopupWindow.js" type="text/javascript"></script>

    <script src="../JS/MZHUM/SYS_CompanyList.js" type="text/javascript"></script>

</head>
<body>
    <form id="Form1" method="post" runat="server">
    <mzh:MzhTitle ID="MzhTitle1" runat="server" />
    <div id="main">
        <mzh:MzhToolbar ID="MzhToolbar1" runat="server" OnItemPostBack="MzhToolbar1_ItemPostBack">
            <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable"
                itemid="new" cellspacing="0" nakedlabelclass="nakedLabelCell" isshowtext="True"
                iconclass="add" hasicon="True" text="新建" id="tbiAdd" onclick="addCompanyInfo(this.id)">
            </mzh:toolbarbutton>
            <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable"
                itemid="Edit" cellspacing="0" nakedlabelclass="nakedLabelCell" isshowtext="True"
                iconclass="edit" hasicon="True" text="编辑" id="tbiEdit" onclick="editCompanyInfo(this.id)">
            </mzh:toolbarbutton>
            <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable"
                itemid="delete" cellspacing="0" autopostback="True" nakedlabelclass="nakedLabelCell"
                isshowtext="True" iconclass="delete" hasicon="True" text="删除" id="tbiDelete"
                onclick="if(!confirmDelete()) return;">
            </mzh:toolbarbutton>
        </mzh:MzhToolbar>
        <mzh:MzhDataGrid ID="dg_CompanyInfo" runat="server" name="MzhMultiSelectDataGrid"
            selecttype="MultiSelect" IdCell="0" AutoGenerateColumns="False" AllowPaging="True"
            HignLightCSS="m-grid-row-over" cssclassforpagerbuttonjump="m-grid-pager-button-jump"
            SelectedCSS="m-grid-row-selected" CssClass="datagrid" cssclassforpagerinputpage="m-grid-pager-input-page"
            MultiPageShowMode="DropListMode" TotalRecorderCount="0"
            PageSize="20" AllowSorting="True" ShowRecordsCount="True" ShowPageSize="true" 
            >
            <HeaderStyle Wrap="False"></HeaderStyle>
            <Columns>
                <asp:BoundColumn DataField="CoCode" SortExpression="CoCode" HeaderText="公司编号">
                    <HeaderStyle Width="80px"></HeaderStyle>
                    <ItemStyle CssClass="center" />
                </asp:BoundColumn>
                <asp:BoundColumn DataField="CoName" SortExpression="CoName" HeaderText="公司中文名称">
                    <HeaderStyle Width="200px"></HeaderStyle>
                </asp:BoundColumn>
                <asp:BoundColumn DataField="ParentCoName" SortExpression="ParentCoName" HeaderText="上级公司名称">
                    <HeaderStyle Width="100px"></HeaderStyle>
                    <ItemStyle Width="200px"></ItemStyle>
                </asp:BoundColumn>
                <asp:TemplateColumn SortExpression="IsDefault" HeaderText="状态">
                    <HeaderStyle Wrap="False" Width="60px"></HeaderStyle>
                    <ItemStyle Wrap="False" CssClass="center"></ItemStyle>
                    <ItemTemplate>
                        <asp:Label ID="lblDefault" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.IsDeFault").ToString()=="Y"?"默认":"非默认" %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateColumn>
                <asp:BoundColumn></asp:BoundColumn>
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

<%@ Page Language="c#" CodeBehind="SYS_TemplateList.aspx.cs" AutoEventWireup="True"
    Inherits="SystemManagement.MZHUM.SYS_TemplateList" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>产品列表</title>
    <link rel="stylesheet" type="text/css" href="../CSS/common.css" />

    <script src="/aspnet_client/Shmzh.Web.UI/jquery-1.2.6.pack.js" type="text/javascript"></script>

    <script src="/aspnet_client/Shmzh.Web.UI/PopupWindow.js" type="text/javascript"></script>

    <script src="../JS/MZHUM/SYS_TemplateList.js" type="text/javascript"></script>
</head>
<body>
    <form id="Form1" method="post" runat="server">
    <mzh:MzhTitle ID="MzhTitle1" runat="server" />
    <div id="main">
        <mzh:MzhToolbar ID="MzhToolbar1" runat="server" OnItemPostBack="MzhToolbar1_ItemPostBack">
            <mzh:ToolbarButton Cellpadding="0" LabelClass="labelCell" TableClass="buttonTable"
                ItemId="new" Cellspacing="0" NakedLabelClass="nakedLabelCell" IsShowText="True"
                IconClass="add" HasIcon="True" Text="新建" ID="toolbarItemAdd" onclick="addTemplate(this.id)">
            </mzh:ToolbarButton>
            <mzh:ToolbarButton Cellpadding="0" LabelClass="labelCell" TableClass="buttonTable"
                ItemId="Edit" Cellspacing="0" NakedLabelClass="nakedLabelCell" IsShowText="True"
                IconClass="edit" HasIcon="True" Text="编辑" ID="toolbarItemEdit" onclick="editTemplate(this.id)">
            </mzh:ToolbarButton>
            <mzh:ToolbarButton Cellpadding="0" LabelClass="labelCell" TableClass="buttonTable"
                ItemId="delete" CausesValidation="False" Cellspacing="0" AutoPostBack="True"
                NakedLabelClass="nakedLabelCell" IsShowText="True" IconClass="delete" onclick="if(!confirmDelete()) return;"
                HasIcon="True" Text="删除" ID="toolbarItemDelete">
            </mzh:ToolbarButton>
        </mzh:MzhToolbar>
        <div>
            <mzh:MzhDataGrid ID="dg_Template" runat="server" name="MzhMultiSelectDataGrid" selecttype="MultiSelect"
                IdCell="0" AutoGenerateColumns="False" AllowPaging="true" HignLightCSS="m-grid-row-over"
                cssclassforpagerbuttonjump="m-grid-pager-button-jump" SelectedCSS="m-grid-row-selected"
                ShowPageSize="true" CssClass="datagrid" cssclassforpagerinputpage="m-grid-pager-input-page"
                MultiPageShowMode="DropListMode" PageSize="20">
                <Columns>
                    <asp:BoundColumn DataField ="ID" Visible ="false"></asp:BoundColumn>
                    <asp:BoundColumn DataField="ProductCode" HeaderText="所属产品">
                        <HeaderStyle Width="80px"></HeaderStyle>
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="Code" HeaderText="编号">
                        <HeaderStyle Width="60px"></HeaderStyle>
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="Name" HeaderText="名称">
                        <HeaderStyle Width="150px"></HeaderStyle>
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="Remark" HeaderText="描述">
                        <HeaderStyle></HeaderStyle>
                    </asp:BoundColumn>
                </Columns>
            </mzh:MzhDataGrid>
        </div>
        <div class="hidden">
            <asp:TextBox ID="txtProductCode" runat="server" ></asp:TextBox>
            <asp:Button ID="btnRefresh" runat="server" OnClick="btnRefresh_Click" />
        </div>
    </div>
    </form>
</body>
</html>

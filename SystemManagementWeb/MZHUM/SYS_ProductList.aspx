<%@ Page Language="c#" CodeBehind="SYS_ProductList.aspx.cs" AutoEventWireup="True"
    Inherits="SystemManagement.MZHUM.SYS_ProductList" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>产品列表</title>
    <link rel="stylesheet" type="text/css" href="../CSS/common.css" />

    <script src="../JS/jquery-1.2.6.js" type="text/javascript"></script>

    <script src="../JS/PopupWindow.js" type="text/javascript"></script>

    <script src="../JS/MZHUM/SYS_ProductList.js" type="text/javascript"></script>

    
    
</head>
<body>
    <form id="Form1" method="post" runat="server">
    <mzh:MzhTitle ID="MzhTitle1" runat="server" />
    <div id="main">
        <mzh:MzhToolbar ID="MzhToolbar1" runat="server" OnItemPostBack="MzhToolbar1_ItemPostBack" SEModuleID="1">
            <mzh:ToolbarButton Cellpadding="0" LabelClass="labelCell" TableClass="buttonTable"
                ItemId="new" Cellspacing="0" NakedLabelClass="nakedLabelCell" IsShowText="True"
                IconClass="add" HasIcon="True" Text="新建" ID="toolbarItemAdd" onclick="addProduct(this.id)">
            </mzh:ToolbarButton>
            <mzh:ToolbarButton Cellpadding="0" LabelClass="labelCell" TableClass="buttonTable"
                ItemId="Edit" Cellspacing="0" NakedLabelClass="nakedLabelCell" IsShowText="True"
                IconClass="edit" HasIcon="True" Text="编辑" ID="toolbarItemEdit" onclick="editProduct(this.id)">
            </mzh:ToolbarButton>
            <mzh:ToolbarButton Cellpadding="0" LabelClass="labelCell" TableClass="buttonTable"
                ItemId="delete" CausesValidation="False" Cellspacing="0" AutoPostBack="True"
                NakedLabelClass="nakedLabelCell" IsShowText="True" IconClass="delete" onclick="if(!confirmDelete()) return;"
                HasIcon="True" Text="删除" ID="toolbarItemDelete"> </mzh:ToolbarButton>
            <mzh:toolbarseparator separatorclass="toolbarIconDivider" id="toolbarSeparator1" itemid="toolbarSeparator1"></mzh:toolbarseparator>
            <mzh:ToolbarButton Cellpadding="0" LabelClass="labelCell" TableClass="buttonTable"
                ItemId="register" CausesValidation="False" Cellspacing="0" AutoPostBack="True"
                NakedLabelClass="nakedLabelCell" IsShowText="True" IconClass="key" onclick="registerProduct(this.id)"
                HasIcon="True" Text="注册" ID="toolbarItemRegister">
            </mzh:ToolbarButton>
        </mzh:MzhToolbar>
        <div>
            <mzh:MzhDataGrid ID="dg_Product" runat="server" name="MzhMultiSelectDataGrid" selecttype="MultiSelect"
                IdCell="0" AutoGenerateColumns="False" AllowPaging="true" HignLightCSS="m-grid-row-over" AllowSorting="true"
                cssclassforpagerbuttonjump="m-grid-pager-button-jump" SelectedCSS="m-grid-row-selected"
                ShowPageSize="true" CssClass="datagrid" cssclassforpagerinputpage="m-grid-pager-input-page"
                MultiPageShowMode="DropListMode" PageSize="20">
                <Columns>
                    <asp:BoundColumn DataField="ProductCode" SortExpression="ProductCode" HeaderText="编号">
                        <HeaderStyle Width="45px"></HeaderStyle>
                        <ItemStyle CssClass="center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="ProductName" SortExpression="ProductName" HeaderText="名称">
                        <HeaderStyle Width="150px"></HeaderStyle>
                    </asp:BoundColumn>
                    <asp:TemplateColumn SortExpression="IsValid" HeaderText="状态">
                        <HeaderStyle Width="120px"></HeaderStyle>
                        <ItemStyle CssClass="center"></ItemStyle>
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.IsValid").ToString()=="Y"?"有效":"无效" %>'>
                            </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateColumn>
                    <asp:BoundColumn DataField="Remark" SortExpression="Remark" HeaderText="描述">
                        <HeaderStyle></HeaderStyle>
                    </asp:BoundColumn>
                </Columns>
            </mzh:MzhDataGrid>
        </div>
        <div class="hidden">
            <asp:Button ID="btnRefresh" runat="server" OnClick="btnRefresh_Click" />
        </div>
    </div>
    </form>
</body>
</html>

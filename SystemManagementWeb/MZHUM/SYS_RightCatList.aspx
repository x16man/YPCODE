<%@ Page Language="c#" CodeBehind="SYS_RightCatList.aspx.cs" AutoEventWireup="True"
    Inherits="SystemManagement.MZHUM.SYS_RightCatList" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>产品权限分类</title>
    <link rel="stylesheet" type="text/css" href="../CSS/common.css" />

    <script src="/aspnet_client/Shmzh.Web.UI/jquery-1.2.6.pack.js" type="text/javascript"></script>

    <script src="../JS/PopupWindow.js" type="text/javascript"></script>

    <script src="../JS/MZHUM/SYS_RightCatList.js" type="text/javascript"></script>

</head>
<body>
    <form id="Form1" method="post" runat="server">
    <mzh:MzhTitle ID="MzhTitle1" runat="server" />
    <div id="main">
        <mzh:MzhToolbar ID="MzhToolbar1" runat="server" OnItemPostBack="MzhToolbar1_ItemPostBack">
            <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable"
                itemid="new" cellspacing="0" nakedlabelclass="nakedLabelCell" isshowtext="True"
                iconclass="add" hasicon="True" text="新建" id="toolbarButton6" onclick="addCat(this.id)">
            </mzh:toolbarbutton>
            <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable"
                itemid="Edit" cellspacing="0" nakedlabelclass="nakedLabelCell" isshowtext="True"
                iconclass="edit" hasicon="True" text="编辑" id="toolbarButton7" onclick="editCat(this.id)">
            </mzh:toolbarbutton>
            <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable"
                itemid="delete" cellspacing="0" autopostback="True" nakedlabelclass="nakedLabelCell"
                isshowtext="True" iconclass="delete" hasicon="True" text="删除" id="toolbarButton8"
                onclick="if(!confirmDelete()) return;">
            </mzh:toolbarbutton>
            <mzh:toolbarseparator separatorclass="toolbarIconDivider" id="toolbarSeparator2"
                itemid="toolbarSeparator2">
            </mzh:toolbarseparator>
            <mzh:toolbarlabel cellpadding="0" labelclass="labelCell" cellspacing="0" itemid="toolbarLabel2"
                tableclass="labelTable" text="产品：" id="toolbarLabel2" visible="False">
            </mzh:toolbarlabel>
            <mzh:toolbardropdownlist visible="False" cellpadding="0" cellspacing="0" itemid="ddlProduct"
                internaldropdownlist="" selectedindex="-1" tableclass="labelTable" autopostback="True"
                enabled="True" items="(Collection)" id="toolbarDropdownList1">
            </mzh:toolbardropdownlist>
        </mzh:MzhToolbar>
        <mzh:MzhDataGrid ID="dg_RightCat" runat="server" name="MzhMultiSelectDataGrid" selecttype="SingleSelect"
            IdCell="0" AutoGenerateColumns="False" AllowPaging="True" HignLightCSS="m-grid-row-over" AllowSorting="true"
            cssclassforpagerbuttonjump="m-grid-pager-button-jump" SelectedCSS="m-grid-row-selected"
            CssClass="datagrid" cssclassforpagerinputpage="m-grid-pager-input-page" ShowPageSize="true" 
            MultiPageShowMode="DropListMode" TotalRecorderCount="0" PageSize="20" 
            >
            <HeaderStyle Wrap="False"></HeaderStyle>
            <Columns>
                <asp:BoundColumn HeaderText="编号" DataField="Code" SortExpression="Code">
                    <HeaderStyle Width="80px"></HeaderStyle>
                </asp:BoundColumn>
                <asp:BoundColumn HeaderText="名称" DataField="Name" SortExpression ="Name">
                    <HeaderStyle Width="100px"></HeaderStyle>
                </asp:BoundColumn>
                <asp:TemplateColumn SortExpression="IsValid" HeaderText="状态">
                    <HeaderStyle Wrap="False" Width="40px"></HeaderStyle>
                    <ItemStyle Wrap="False" CssClass="center"></ItemStyle>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.IsValid").ToString()=="Y"?"有效":"无效" %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn HeaderText="产品名称">
                    <HeaderStyle Wrap="False" Width="100px"></HeaderStyle>
                    <ItemStyle Wrap="False" CssClass="center"></ItemStyle>
                    <ItemTemplate>
                        <%=ProductName %>
                    </ItemTemplate>
                </asp:TemplateColumn>
                <asp:BoundColumn HeaderText="描述" DataField="Desc" SortExpression="Desc"></asp:BoundColumn>
            </Columns>
        </mzh:MzhDataGrid>
        <div class="hidden">
            <asp:TextBox ID="txtProductCode" runat="server"></asp:TextBox>
            <asp:Button ID="btnRefresh" runat="server" OnClick="btnRefresh_Click" />
        </div>
    </div>
    </form>
</body>
</html>

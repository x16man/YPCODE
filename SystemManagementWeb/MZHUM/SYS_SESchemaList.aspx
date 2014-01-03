<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SYS_SESchemaList.aspx.cs"
    Inherits="SystemManagement.MZHUM.SYS_SESchemaList" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>查询方案列表</title>
    <link href="../CSS/Common.css" rel="stylesheet" type="text/css" />
    <link href="../CSS/treeStyle.css" rel="Stylesheet" type="text/css" />
    <link href="../CSS/MZHUM/SYS_SESchemaList.css" rel="Stylesheet" type="text/css" />

    <script src="/aspnet_client/Shmzh.Web.UI/jquery-1.2.6.pack.js" type="text/javascript"></script>

    <script src="/aspnet_client/Shmzh.Web.UI/PopupWindow.js" type="text/javascript"></script>

    <script src="../JS/MZHUM/SYS_SESchemaList.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server">
    <mzh:MzhTitle ID="MzhTitle1" runat="server" />
    <table id="main">
        <tr>
            <td id="sidebar">
                <ComponentArt:TreeView ID="tvModule" runat="server" CssClass="TreeView" NodeCssClass="TreeNode"
                    SelectedNodeCssClass="SelectedTreeNode" HoverNodeCssClass="HoverTreeNode" LineImageWidth="19"
                    LineImageHeight="20" DefaultImageWidth="16" DefaultImageHeight="16" NodeLabelPadding="3"
                    ImagesBaseUrl="../Images/treeview_images/" ParentNodeImageUrl="folders.gif" LeafNodeImageUrl="folder.gif"
                    ShowLines="true" LineImagesFolderUrl="../Images/treeview_images/lines/" DragAndDropEnabled="True"
                    AutoPostBackOnNodeMove="True" AutoPostBackOnSelect="True" AutoScroll="False"
                    CausesValidation="False" CollapseNodeOnSelect="False" OnNodeSelected="tvModule_NodeSelected">
                </ComponentArt:TreeView>
            </td>
            <td id="separator">
            </td>
            <td id="content">
                <mzh:MzhToolbar ID="MzhToolbar1" runat="server" OnItemPostBack="MzhToolbar1_ItemPostBack">
                    <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable"
                        itemid="Edit" cellspacing="0" nakedlabelclass="nakedLabelCell" isshowtext="True"
                        iconclass="edit" hasicon="True" text="编辑" id="tbiEdit" onclick="editSESchemaInfo(this.id)">
                    </mzh:toolbarbutton>
                    <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable"
                        itemid="delete" cellspacing="0" autopostback="True" nakedlabelclass="nakedLabelCell"
                        isshowtext="True" iconclass="delete" hasicon="True" text="删除" id="tbiDelete"
                        onclick="if(!confirmDelete()) return;">
                    </mzh:toolbarbutton>
                </mzh:MzhToolbar>
                <mzh:MzhDataGrid ID="dg_SESchemaInfo" runat="server" name="MzhMultiSelectDataGrid"
                    selecttype="SingleSelect" IdCell="0" AutoGenerateColumns="False" AllowPaging="True"
                    HignLightCSS="m-grid-row-over" cssclassforpagerbuttonjump="m-grid-pager-button-jump"
                    SelectedCSS="m-grid-row-selected" CssClass="datagrid" cssclassforpagerinputpage="m-grid-pager-input-page"
                    MultiPageShowMode="DropListMode" TotalRecorderCount="0" PageSize="20" AllowSorting="True"
                    ShowRecordsCount="True" ShowPageSize="True" ShowGridOnEmptyData="False">
                    <HeaderStyle Wrap="False"></HeaderStyle>
                    <Columns>
                        <asp:BoundColumn DataField="Id" SortExpression="Id" HeaderText="Id" Visible="false">
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="SchemaName" SortExpression="SchemaName" HeaderText="方案名称">
                            <HeaderStyle Width="100px"></HeaderStyle>
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="WhereClause" SortExpression="WhereClause" HeaderText="Where语句">
                            <HeaderStyle />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="CreateTime" SortExpression="CreateTime" HeaderText="创建时间">
                            <HeaderStyle Width="80px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Remark" HeaderText="备注"></asp:BoundColumn>
                        <asp:TemplateColumn HeaderText="默认">
                            <HeaderStyle Width="50px" />
                            <ItemStyle CssClass="center" />
                            <ItemTemplate>
                                <asp:CheckBox ID="CheckBox1" runat="server" Enabled="false" Checked='<%# (bool)DataBinder.Eval(Container, "DataItem.IsDefault") %>' />
                            </ItemTemplate>
                        </asp:TemplateColumn>
                    </Columns>
                    <PagerStyle HorizontalAlign="Right" Mode="NumericPages"></PagerStyle>
                </mzh:MzhDataGrid>
            </td>
        </tr>
    </table>
    <div class="hidden">
        <asp:HiddenField ID="hfProductCode" runat="server" />
        <asp:HiddenField ID="hfModuleId" runat="server" />
        <asp:Button ID="btnRefresh" runat="server" Text="refresh" OnClick="btnRefresh_Click" />
    </div>
    </form>
</body>
</html>

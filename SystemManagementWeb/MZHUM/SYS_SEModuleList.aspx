<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SYS_SEModuleList.aspx.cs"
    Inherits="SystemManagement.MZHUM.SYS_SEModuleList" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>查询模块列表</title>
    <link href="../CSS/Common.css" rel="stylesheet" type="text/css" />
    <link href="../CSS/toolbar.css" rel="stylesheet" type="text/css" />
    <link href="../CSS/DataGrid.css" rel="stylesheet" type="text/css" />
    <link href="../CSS/treeStyle.css" rel="Stylesheet" type="text/css" />
    <link href="../CSS/MZHUM/SYS_SEModuleList.css" rel="Stylesheet" type="text/css" />

    <script src="/aspnet_client/Shmzh.Web.UI/jquery-1.2.6.pack.js" type="text/javascript"></script>


    <script src="/aspnet_client/Shmzh.Web.UI/PopupWindow.js"
        type="text/javascript"></script>

    <script src="../JS/MZHUM/SYS_SEModuleList.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server">
    <mzh:MzhTitle ID="MzhTitle1" runat="server" />
    <table id="main">
        <tr>
            <td id="sidebar">
                <mzh:MzhToolbar ID="MzhToolbar_Module" runat="server" OnItemPostBack="MzhToolbar_Module_ItemPostBack">
            <mzh:ToolbarButton runat="server" id="tbiAddModule" hasicon="True" iconClass="add"
                tooltip="添加查询模块" itemid="Add" IsShowText="False" OnClientClick="addSEModuleInfo(this.id);">
            </mzh:ToolbarButton>
            <mzh:ToolbarButton runat="server" id="tbiEditModule" hasicon="True" iconClass="edit"
                tooltip="修改选中查询模块" itemid="Edit" IsShowText="False" OnClientClick="editSEModuleInfo(this.id);">
            </mzh:ToolbarButton>
            <mzh:ToolbarButton runat="server" id="tbiDeleteModule" hasicon="True" tooltip="删除选中查询模块"
                autopostback="True" iconClass="delete" IsShowText="False" itemid="Delete" OnClientClick="if(!confirmDeleteModule()) return;">
            </mzh:ToolbarButton>
        </mzh:MzhToolbar>
        <ComponentArt:TreeView ID="tvModule" runat="server" CssClass="TreeView" NodeCssClass="TreeNode"
            SelectedNodeCssClass="SelectedTreeNode" HoverNodeCssClass="HoverTreeNode" LineImageWidth="19"
            LineImageHeight="20" DefaultImageWidth="16" DefaultImageHeight="16" NodeLabelPadding="3"
            ImagesBaseUrl="../Images/treeview_images/" ParentNodeImageUrl="folders.gif" LeafNodeImageUrl="folder.gif"
            ShowLines="true" LineImagesFolderUrl="../Images/treeview_images/lines/" DragAndDropEnabled="True"
            AutoPostBackOnNodeMove="True" AutoPostBackOnSelect="True" AutoScroll="False"
            CausesValidation="False" CollapseNodeOnSelect="False" OnNodeSelected="tvModule_NodeSelected">
        </ComponentArt:TreeView>
            </td>
            <td id="seperator"></td>
            <td id="content">
                <mzh:MzhToolbar ID="MzhToolbar1" runat="server" OnItemPostBack="MzhToolbar1_ItemPostBack">
                <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable"
                    itemid="new" cellspacing="0" nakedlabelclass="nakedLabelCell" isshowtext="True"
                    iconclass="add" hasicon="True" text="新建" id="tbiAdd" onclick="addSEControlInfo(this.id)">
                </mzh:toolbarbutton>
                <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable"
                    itemid="Edit" cellspacing="0" nakedlabelclass="nakedLabelCell" isshowtext="True"
                    iconclass="edit" hasicon="True" text="编辑" id="tbiEdit" onclick="editSEControlInfo(this.id)">
                </mzh:toolbarbutton>
                <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable"
                    itemid="delete" cellspacing="0" autopostback="True" nakedlabelclass="nakedLabelCell"
                    isshowtext="True" iconclass="delete" hasicon="True" text="删除" id="tbiDelete"
                    onclick="if(!confirmDeleteControl()) return;">
                </mzh:toolbarbutton>
            </mzh:MzhToolbar>
            <mzh:MzhDataGrid ID="dg_SEControlInfo" runat="server" name="MzhMultiSelectDataGrid"
                selecttype="SingleSelect" IdCell="0" AutoGenerateColumns="False" AllowPaging="True"
                HignLightCSS="m-grid-row-over" cssclassforpagerbuttonjump="m-grid-pager-button-jump"
                SelectedCSS="m-grid-row-selected" CssClass="datagrid" cssclassforpagerinputpage="m-grid-pager-input-page"
                MultiPageShowMode="DropListMode" TotalRecorderCount="0" PageSize="20" AllowSorting="True"
                ShowRecordsCount="True" ShowPageSize="True" ShowGridOnEmptyData="False" 
                SORTEXPRESSION="" IsShowTotalRecorderCount="True">
                <HeaderStyle Wrap="False"></HeaderStyle>
                <Columns>
                    <asp:BoundColumn DataField="Id" SortExpression="Id" HeaderText="Id" Visible="false">
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="LabelName" SortExpression="LabelName" HeaderText="标签名称">
                        <HeaderStyle Width="60px"></HeaderStyle>
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="TableName" SortExpression="TableName" HeaderText="表名">
                        <HeaderStyle Width="50px" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="FieldName" SortExpression="FieldName" HeaderText="字段名">
                        <HeaderStyle Width="50px" />
                    </asp:BoundColumn>
                    
                    <asp:TemplateColumn HeaderText="控件类型" SortExpression="ControlTypeId">
                        <HeaderStyle Width="60px" />
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# GetControlTypeName(int.Parse(DataBinder.Eval(Container, "DataItem.ControlTypeId").ToString())) %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateColumn>
                    <asp:TemplateColumn HeaderText="数据类型" SortExpression="DataTypeId">
                        <HeaderStyle Width="60px" />
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# GetDataTypeName(int.Parse(DataBinder.Eval(Container, "DataItem.DataTypeId").ToString())) %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateColumn>
                    
                    <asp:TemplateColumn HeaderText="数据绑定信息">
                        <HeaderStyle Width="320px" />
                        <ItemTemplate>
                        <%# DataBinder.Eval(Container, "DataItem.Assembly") %><br />
                            <%# DataBinder.Eval(Container,"DataItem.ObjType") %><br />
                                <%# DataBinder.Eval(Container, "DataItem.Method") %>
                        </ItemTemplate>
                    </asp:TemplateColumn>
                    
                    
                    
                    <asp:TemplateColumn HeaderText="有效">
                        <HeaderStyle Width="50px" />
                        <ItemStyle CssClass="center" />
                        <ItemTemplate>
                            <asp:CheckBox ID="CheckBox1" runat="server" Enabled="false" Checked='<%# (bool)DataBinder.Eval(Container, "DataItem.IsValid") %>' />
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

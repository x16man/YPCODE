<%@ Page Language="c#" CodeBehind="SYS_RoleRight.aspx.cs" AutoEventWireup="True"
    Inherits="SystemManagement.MZHUM.SYS_RoleRight" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>角色权限</title>
    <link type="text/css" rel="Stylesheet" href="../CSS/common.css" />
    <link rel="Stylesheet" type="text/css" href="../CSS/treeStyle.css" />
    <link rel="Stylesheet" type="text/css" href="../CSS/MZHUM/SYS_RoleRight.css" />

    <script type="text/javascript" src="../JS/jquery-1.8.2.min.js"></script>
    <script type="text/javascript" src="../JS/jquery.blockUI.js"></script>

    <script src="/aspnet_client/Shmzh.Web.UI/PopupWindow.js" type="text/javascript"></script>

    <script src="../JS/MZHUM/SYS_RoleRight.js" type="text/javascript"></script>

</head>
<body>
    <form id="Form1" method="post" runat="server">
    <mzh:MzhTitle ID="MzhTitle1" runat="server" />
    <div class="hidden">
        <input id="txtRoleCode" type="hidden" runat="server" />
        <input id="txtProductCode" type="hidden" runat="server" />
    </div>
    <table id="main">
        <tr>
            <td id="left" valign="top">
                <mzh:MzhToolbar ID="MzhToolbar1" runat="server" OnItemPostBack="MzhToolbar1_ItemPostBack">
                    <mzh:ToolbarButton runat="server" id="tbiAdd" hasicon="True" iconClass="add" tooltip="添加角色"
                        itemid="Add" IsShowText="False" OnClientClick="addRole(this.id);">
                    </mzh:ToolbarButton>
                    <mzh:ToolbarButton runat="server" id="tbiEdit" hasicon="True" iconClass="edit" tooltip="修改选中角色"
                        itemid="Edit" IsShowText="False" OnClientClick="editRole(this.id);">
                    </mzh:ToolbarButton>
                    <mzh:ToolbarButton runat="server" id="tbiDelete" hasicon="True" tooltip="删除选中角色"
                        autopostback="True" iconClass="delete" IsShowText="False" itemid="Delete" OnClientClick="if(!confirmDelete()) return;">
                    </mzh:ToolbarButton>
                </mzh:MzhToolbar>
                <ComponentArt:TreeView ID="tvRole" runat="server" CssClass="TreeView" NodeCssClass="TreeNode"
                    SelectedNodeCssClass="SelectedTreeNode" HoverNodeCssClass="HoverTreeNode" LineImageWidth="19"
                    LineImageHeight="20" DefaultImageWidth="16" DefaultImageHeight="16" NodeLabelPadding="3"
                    ImagesBaseUrl="../Images/treeview_images/" ParentNodeImageUrl="folders.gif" LeafNodeImageUrl="User.png"
                    ShowLines="true" LineImagesFolderUrl="../Images/treeview_images/lines/" DragAndDropEnabled="False"
                    AutoPostBackOnNodeMove="False" AutoPostBackOnSelect="True" AutoScroll="False"
                    CausesValidation="False" CollapseNodeOnSelect="False" OnNodeSelected="tvRole_NodeSelected">
                    <ClientEvents>
                        <NodeSelect EventHandler="tvRole_onNodeSelect" />
                    </ClientEvents>
                </ComponentArt:TreeView>
            </td>
            <td id="seperator"></td>
            <td id="right" valign="top">
                <mzh:MzhToolbar ID="MzhToolbar2" runat="server" OnItemPostBack="MzhToolbar2_ItemPostBack">
                    <mzh:ToolbarCheckBox ID="tbiSelectAll" runat="server" AutoPostBack="True" Cellpadding="0"
                        Cellspacing="0" Checked="False" ItemId="SelectAll" TableClass="labelTable-Right"
                        Text="全部选中" />
                    <mzh:ToolbarCheckBox ID="tbiClearAll" runat="server" AutoPostBack="True" Cellpadding="0"
                        Cellspacing="0" Checked="False" ItemId="ClearAll" TableClass="labelTable-Right"
                        Text="全部取消" />
                    <mzh:ToolbarButton runat="server" ID="tbiSave" IconClass="save" ItemId="Save" autopostback="True"
                        Text="保存" ToolTip="保存角色权限">
                    </mzh:ToolbarButton>
                </mzh:MzhToolbar>
                <div id="rightWrapper">
                    <asp:Repeater ID="CateLogList" runat="server">
                        <ItemTemplate>
                            <div class="rightCategory">
                                <asp:Label ID="PKID" runat="server" Text='<%#DataBinder.Eval(Container, "DataItem.Code")%>'
                                    Visible="False">
                                </asp:Label>
                                <asp:Label ID="CatCnName" runat="server" Text='<%#DataBinder.Eval(Container, "DataItem.Name")%>'
                                    CssClass="">
                                </asp:Label></div>
                            <div class="right">
                                <asp:CheckBoxList ID="CkbList" runat="server" RepeatColumns="5" RepeatDirection="Horizontal">
                                </asp:CheckBoxList>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>

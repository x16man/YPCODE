<%@ Page Language="c#" CodeBehind="SYS_UserRight.aspx.cs" AutoEventWireup="True"
    Inherits="SystemManagement.MZHUM.SYS_UserRight" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>用户权限</title>
    <link type="text/css" rel="Stylesheet" href="../CSS/common.css" />
    <link rel="Stylesheet" type="text/css" href="../CSS/treeStyle.css" />
    <link rel="Stylesheet" type="text/css" href="../CSS/MZHUM/SYS_RoleRight.css" />

    <script type="text/javascript" src="/aspnet_client/Shmzh.Web.UI/jquery-1.2.6.pack.js"></script>

    <script src="/aspnet_client/Shmzh.Web.UI/PopupWindow.js" type="text/javascript"></script>

    <script src="../JS/MZHUM/SYS_RoleRight.js" type="text/javascript"></script>

</head>
<body>
    <form id="Form1" method="post" runat="server">
    <div class="hidden">
        <input id="txtProductCode" type="hidden" runat="server" />
    </div>
    <table id="main">
        <tr>
            <td id="left" valign="top">
                <ComponentArt:TreeView ID="tvUser" runat="server" CssClass="TreeView" NodeCssClass="TreeNode"
                    SelectedNodeCssClass="SelectedTreeNode" HoverNodeCssClass="HoverTreeNode" LineImageWidth="19"
                    LineImageHeight="20" DefaultImageWidth="16" DefaultImageHeight="16" NodeLabelPadding="3"
                    ImagesBaseUrl="../Images/treeview_images/" ParentNodeImageUrl="folders.gif" LeafNodeImageUrl="User.png"
                    ShowLines="true" LineImagesFolderUrl="../Images/treeview_images/lines/" DragAndDropEnabled="False"
                    AutoPostBackOnNodeMove="False" AutoPostBackOnSelect="True" AutoScroll="False"
                    CausesValidation="False" CollapseNodeOnSelect="False" OnNodeSelected="tvUser_NodeSelected">
                </ComponentArt:TreeView>
            </td>
            <td id="seperator"></td>
            <td id="right" valign="top">
                <div id="rightWrapper">
                    <asp:Repeater ID="CateLogList" runat="server" EnableViewState="true">
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

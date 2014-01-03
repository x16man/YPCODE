<%@ Page Language="c#" CodeBehind="SYS_GroupUser.aspx.cs" AutoEventWireup="True"
    Inherits="SystemManagement.MZHUM.SYS_GroupUser" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>�顢�û�ά��</title>
    <link type="text/css" rel="stylesheet" href="../CSS/common.css" />
    <link rel="Stylesheet" type="text/css" href="../CSS/treeStyle.css" />
    <link rel="Stylesheet" type="text/css" href="../CSS/MZHUM/SYS_GroupUser.css" />
    <script type="text/javascript" src="../JS/jquery-1.8.2.min.js"></script>
    <script type="text/javascript" src="../JS/jquery.blockUI.js"></script>
    <script type="text/javascript" src="/aspnet_client/Shmzh.Web.UI/PopupWindow.js" ></script>
    <script type="text/javascript" src="../JS/MZHUM/SYS_GroupUser.js"></script>
    
</head>
<body>
    <form id="Form1" method="post" runat="server">
    <mzh:MzhTitle ID="MzhTitle1" runat="server" />
    <div class="hidden">
        <input id="txtLoginNames" type="hidden" runat="server" />
        <asp:Button ID="btnAddGroupUser" runat="server" Text="Add Group User" 
            onclick="btnAddGroupUser_Click" /><asp:Button ID="btnRefresh" runat="server" Text="Refresh" OnClick="btnRefresh_Click" />
    </div><mzh:MzhToolbar ID="MzhToolbar_Group" runat="server" 
                onitempostback="MzhToolbar_Group_ItemPostBack">
                <mzh:ToolbarButton runat="server" id="tbiRefresh" hasicon="True" iconClass="refresh" tooltip="ˢ��" itemid="refresh" Text="ˢ��"
                    IsShowText="True" autopostback="true"  >
                </mzh:ToolbarButton>
                <mzh:ToolbarButton runat="server" id="tbiAddGroupCat" hasicon="True" iconClass="folderAdd" tooltip="��ӷ���" itemid="AddGroupCat" Text="��ӷ���"
                    IsShowText="True" OnClientClick="addGroupCat(this.id);" >
                </mzh:ToolbarButton>
                <mzh:ToolbarButton runat="server" id="tbiEditGroupCat" hasicon="True" iconClass="folderEdit" tooltip="�޸ķ���" itemid="EditGroupCat" Text="�޸ķ���"
                    IsShowText="True" OnClientClick="editGroupCat(this.id);" >
                </mzh:ToolbarButton>
                <mzh:ToolbarButton runat="server" id="tbiDeleteGroupCat" hasicon="True" iconClass="folderDelete" tooltip="ɾ������" itemid="DeleteGroupCat" Text="ɾ������"
                    IsShowText="True"  autopostback="True" OnClientClick="if(!confirmDeleteGroupCat()) return;">
                </mzh:ToolbarButton>
                <mzh:toolbarseparator separatorclass="toolbarIconDivider" id="toolbarSeparator0" itemid="toolbarSeparator0"></mzh:toolbarseparator>
                <mzh:ToolbarButton runat="server" id="tbiAddGroup" hasicon="True" iconClass="groupAdd" tooltip="�����" itemid="AddGroup" Text="�����"
                    IsShowText="True" OnClientClick="addGroup(this.id);" >
                </mzh:ToolbarButton>
                <mzh:ToolbarButton runat="server" id="tbiEditGroup"  hasicon="True" iconClass="groupEdit" tooltip="�޸�ѡ����" itemid="EditGroup" Text="�޸���"
                    IsShowText="True" OnClientClick="editGroup(this.id);">
                </mzh:ToolbarButton>
                <mzh:ToolbarButton runat="server" id="tbiDeleteGroup"  hasicon="True" tooltip="ɾ��ѡ����" autopostback="True" Text="ɾ����"
                    iconClass="groupDelete" IsShowText="True" itemid="DeleteGroup"
                    OnClientClick="if(!confirmDeleteGroup()) return;">
                </mzh:ToolbarButton>
                <mzh:toolbarseparator separatorclass="toolbarIconDivider" id="toolbarSeparator1" itemid="toolbarSeparator0"></mzh:toolbarseparator>
                <mzh:ToolbarButton id="tbiAddUser" itemid="AddUser" autopostback="false" runat="server" onclientClick="showUserList(this.id);" IconClass="userAdd" Text="������û�">
                </mzh:ToolbarButton>
                <mzh:ToolbarButton id="tbiDeleteUser" itemid="DeleteUser" autopostback="true" runat="server" IconClass="userDelete" Text="�Ƴ����û�" onclick="if(!confirmDeleteGroupUser()) return;">
                </mzh:ToolbarButton>
            </mzh:MzhToolbar>
    <table id="main">
        <tr>
            <td id="left" valign="top">
        <ComponentArt:TreeView ID="tvGroup" runat="server" CssClass="TreeView" NodeCssClass="TreeNode"
            SelectedNodeCssClass="SelectedTreeNode" HoverNodeCssClass="HoverTreeNode" LineImageWidth="19"
            LineImageHeight="20" DefaultImageWidth="16" DefaultImageHeight="16" NodeLabelPadding="3"
            ImagesBaseUrl="../Images/treeview_images/" 
            ParentNodeImageUrl="folders.gif" LeafNodeImageUrl="Group.png"
            ShowLines="true" LineImagesFolderUrl="../Images/treeview_images/lines/" DragAndDropEnabled="True"
            AutoPostBackOnNodeMove="True" AutoPostBackOnSelect="True" AutoScroll="True"
            CausesValidation="False"  
            CollapseNodeOnSelect="False" onnodeselected="tvGroup_NodeSelected" 
                    OnNodeMoved="tvGroup_NodeMoved" DropSiblingEnabled="True">
            <ClientEvents>
                <NodeBeforeMove EventHandler="tvGroup_onNodeBeforeMove" />
                <NodeSelect EventHandler="tvGroup_onNodeSelect" />
            </ClientEvents>
        </ComponentArt:TreeView></td>
            <td id="seperator"></td>
            <td id="right" valign="top">
            <mzh:MzhDataGrid ID="mdg_GroupUserList" runat="server" name="MzhMultiSelectDataGrid"
                    SelectType="MultiSelect" IdCell="0" AutoGenerateColumns="False" AllowPaging="True"
                    AllowSorting="True" MultiPageShowMode="DropListMode" ShowPageSize="True" 
                    PageSize="20" CauseValidationWhenPaging="False" CssClass="datagrid" 
                    HignLightCSS="m-grid-row-over" ShowTotalRecorderCount="True" 
                    SelectedCSS="m-grid-row-selected" ShowGridOnEmptyData="False" 
                    ShowRecordsCount="True" SORTEXPRESSION="">
                    <PagerStyle HorizontalAlign="Right" Mode="NumericPages"></PagerStyle>
                    <HeaderStyle Wrap="False"></HeaderStyle>
                    <Columns>
                        <asp:BoundColumn Visible="False" DataField="LoginName">
                            <HeaderStyle Wrap="False"></HeaderStyle>
                        </asp:BoundColumn>
                        <asp:TemplateColumn>
                            <HeaderStyle Width="30px" />
                            <ItemStyle CssClass="center" />
                            <ItemTemplate>
                                <img src=<%# Eval("UserState").ToString()=="A"?"../Images/user.png":"../Images/user_delete.png"%> ></img>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:BoundColumn DataField="EmpCode" SortExpression="EmpCode" HeaderText="����">
                            <HeaderStyle Wrap="False" Width="60px"></HeaderStyle>
                            <ItemStyle Wrap="False" CssClass="center"></ItemStyle>
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="EmpName" SortExpression="EmpName" HeaderText="����">
                            <HeaderStyle Wrap="False" Width="80px"></HeaderStyle>
                            <ItemStyle Wrap="False" CssClass="center"></ItemStyle>
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="DeptName" SortExpression="DeptName" HeaderText="����">
                            <HeaderStyle Wrap="False" Width="200px"></HeaderStyle>
                            <ItemStyle Wrap="False" CssClass="center"></ItemStyle>
                        </asp:BoundColumn>
                        <asp:BoundColumn></asp:BoundColumn>
                    </Columns>
                </mzh:MzhDataGrid></td>
            </tr></table>
    </form>
</body>
</html>

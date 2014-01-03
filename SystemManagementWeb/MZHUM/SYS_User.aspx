<%@ Page Language="c#" CodeBehind="SYS_User.aspx.cs" AutoEventWireup="True" Inherits="SystemManagement.MZHUM.SYS_User" %>



<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>人员列表</title>
    <link rel="stylesheet" type="text/css" href="../CSS/common.css" />
    <link rel="Stylesheet" type="text/css" href="../CSS/treeStyle.css" />
    <link rel="Stylesheet" type="text/css" href="../CSS/MZHUM/SYS_User.css" />
    
    <script src="../JS/jquery-1.8.2.min.js" type="text/javascript"></script>
    <script src="../JS/jquery.blockUI.js" type="text/javascript"></script>
    <script src="../JS/PopupWindow.js" type="text/javascript"></script>
    <script src="../JS/MZHUM/SYS_User.js" type="text/javascript"></script>
    <script type="text/javascript">
        function checkAll(elm) {
            var chkif = $(elm).attr("checked");
            $('#UserList .checkMe').each(function () {
                $(this).attr("checked", chkif);
            })
        }
        function checkMe(elm) {
            var chkAll = $('#UserList .checkAll').attr("checked");
            var chkMe = $(elm).attr("checked");
            if (chkMe == false)
                $('#UserList .checkAll').attr("checked", false);
            else {
                $('#UserList .checkAll').attr("checked", true);
                $('#UserList .checkMe').each(function () {
                    if ($(this).attr("checked") == false) {
                        $('#UserList .checkAll').attr("checked", false);
                    }
                });
            }
        }
        function batchSetSuperHrid() {
            var superHrid = $('#txtSuperHrid').val();
            $('#UserList .checkMe[@checked]').each(function () {
                var tr = $(this).parents("tr:eq(0)");
                $('.superHrid input[type="hidden"][id$="hfSuperHrid1"]', tr).val(superHrid);
                $('.superHrid span',tr).text(superHrid);
            });
        }
    </script>
</head>
<body>
    <form id="Form1" method="post" runat="server">
    <mzh:MzhTitle ID="MzhTitle1" runat="server" />
<mzh:MzhToolbar ID="MzhToolbar1" runat="server" SEModuleID="FW-001" OnSEQuery_Click="MzhToolbar1_SEQuery_Click"
                onitempostback="MzhToolbar1_ItemPostBack">
                <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable"
                    itemid="Add" cellspacing="0" nakedlabelclass="nakedLabelCell" isshowtext="True"
                    iconclass="addUser" hasicon="True" text="新建" id="tbiAdd" onclick="addUser(this.id)">
                </mzh:toolbarbutton>
                <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable"
                    itemid="Edit" cellspacing="0" nakedlabelclass="nakedLabelCell" isshowtext="True"
                    iconclass="editUser" hasicon="True" text="编辑" id="tbiEdit" onclick="editUser(this.id)">
                </mzh:toolbarbutton>
                <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable"  CausesValidation="False"
                    itemid="Delete" cellspacing="0" autopostback="True" nakedlabelclass="nakedLabelCell" isshowtext="True"
                    iconclass="deleteUser" hasicon="True" text="删除" id="tbiDelete" onclick="if(!confirmDelete()) return;">
                </mzh:toolbarbutton>
                <mzh:toolbarseparator separatorclass="toolbarIconDivider" id="toolbarSeparator0" itemid="toolbarSeparator0"></mzh:toolbarseparator>
                <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable" CausesValidation="False"
                    itemid="EnableDisable" cellspacing="0" autopostback="True" nakedlabelclass="nakedLabelCell"
                    isshowtext="True" iconclass="deleteUser" hasicon="True" text="启用/禁用用户" id="tbiEnable"
                    onclick="if(!confirmEnableDisable()) return;">
                </mzh:toolbarbutton>
                <mzh:toolbarseparator separatorclass="toolbarIconDivider" id="toolbarSeparator1" itemid="toolbarSeparator1"></mzh:toolbarseparator>
                <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable"  CausesValidation="False"
                    itemid="Reset" cellspacing="0" autopostback="True" nakedlabelclass="nakedLabelCell"
                    isshowtext="True" iconclass="key" hasicon="True" text="重置密码" id="tbiReset"
                    onclick="if(!resetClick()) return;">
                </mzh:toolbarbutton>
                <mzh:toolbarseparator separatorclass="toolbarIconDivider" id="toolbarSeparato2" itemid="toolbarSeparator2"></mzh:toolbarseparator>
                <mzh:toolbarcheckbox itemid="IncludeDisable" autopostback="True" cellpadding="0" checked="False"  CausesValidation="False"
                    cellspacing="0" tableclass="labelTable" text="全部" id="tbiIncludeDisable">
                </mzh:toolbarcheckbox>
                <mzh:toolbarcheckbox itemid="IncludeChildDept" autopostback="True" cellpadding="0" checked="False"  CausesValidation="False"
                    cellspacing="0" tableclass="labelTable" text="子部门" id="tbiIncludeChildDept">
                </mzh:toolbarcheckbox>
                <mzh:toolbarseparator separatorclass="toolbarIconDivider" id="toolbarSeparator3" itemid="toolbarSeparator3"></mzh:toolbarseparator>
                <mzh:ToolbarTextBox id="tbiContent"  labelclass="labelCell" tableclass="buttonTable" style="font-weight:bold;" MaxLength="20" columns="20" tooltip="可以输入工号、登录名、姓名进行查找。"
                    itemid="Content">
                </mzh:ToolbarTextBox>
                <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable"  CausesValidation="False"
                    itemid="Go" cellspacing="0" autopostback="True" nakedlabelclass="nakedLabelCell"
                    isshowtext="True" iconclass="query" hasicon="True" text="查询" id="tbiGo">
                </mzh:toolbarbutton>
            </mzh:MzhToolbar>
    <table id="main">
        <tr>
            <td id="sidebar">
        <ComponentArt:TreeView ID="tvDept" runat="server" CssClass="TreeView" NodeCssClass="TreeNode"
            SelectedNodeCssClass="SelectedTreeNode" HoverNodeCssClass="HoverTreeNode" LineImageWidth="19"
            LineImageHeight="20" DefaultImageWidth="16" DefaultImageHeight="16" NodeLabelPadding="3"
            ImagesBaseUrl="../Images/treeview_images/" 
            ParentNodeImageUrl="folders.gif" LeafNodeImageUrl="folder.gif"
            ShowLines="true" LineImagesFolderUrl="../Images/treeview_images/lines/" DragAndDropEnabled="False"
            AutoPostBackOnNodeMove="True" AutoPostBackOnSelect="True" AutoScroll="False"
            CausesValidation="False" OnNodeSelected="tvMenu_NodeSelected"
            CollapseNodeOnSelect="False">
            <ClientEvents>
                <NodeSelect EventHandler="tvDept_onNodeSelect"></NodeSelect>
            </ClientEvents>
        </ComponentArt:TreeView>
    </td>
            <td id="separator">&nbsp;</td>
            <td id="content">
            <div>
                <mzh:MzhDataGrid ID="UserList" runat="server" AllowSorting="True" AllowPaging="True"
                    AutoGenerateColumns="False" selecttype="MultiSelect" ShowPageSize = "True"
                    PageSize="20" IdCell="0" MultiPageShowMode="DropListMode" 
                    CssClass="datagrid" HignLightCSS="m-grid-row-over" 
                    SelectedCSS="m-grid-row-selected" 
                    OnClientDblClick="showUserDetail(this.id);" 
                    CauseValidationWhenPaging="False" ShowTotalRecorderCount="True" 
                    ShowGridOnEmptyData="False" ShowRecordsCount="True" SORTEXPRESSION="" 
                    >
                    <PagerStyle HorizontalAlign="Right" Mode="NumericPages"></PagerStyle>
                    <HeaderStyle Wrap="False"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
                    <Columns>
                        <asp:BoundColumn Visible="False" DataField="PKID" ReadOnly="True">
                        </asp:BoundColumn>
                        <asp:TemplateColumn>
                            <HeaderStyle Width="20px"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            <HeaderTemplate>
                                <input type="checkbox" class="checkAll" onclick="checkAll(this)"/>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <input type="checkbox" class="checkMe" onclick="checkMe(this)" />
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="用户">
                            <HeaderStyle Width="200px"></HeaderStyle>
                            <ItemStyle></ItemStyle>
                            <ItemTemplate>
                                <span><%#Eval("EmpCode") %></span> <span><%# Eval("EmpName")%></span> <span>(<%#Eval("LoginName") %>)</span>
                                <span><%#Eval("Email") %></span>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:BoundColumn DataField="DeptName" SortExpression="DeptName" 
                            HeaderText="部门" ReadOnly="True">
                            <HeaderStyle Width="200px"></HeaderStyle>
                        </asp:BoundColumn>
                        <asp:TemplateColumn HeaderText="主管工号">
                            <HeaderStyle Width="60px"></HeaderStyle>
                            <ItemStyle CssClass="superHrid"></ItemStyle>
                            <ItemTemplate>
                                <asp:HiddenField runat="server" ID="hfSuperHrid" Value ='<%#Eval("SuperHrid") %>'/>
                                <asp:HiddenField runat="server" ID="hfSuperHrid1" Value ='<%#Eval("SuperHrid") %>'/>
                                <asp:Label runat="server" ID="lblSuperHrid" Text='<%#Eval("SuperHrid") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:BoundColumn DataField="DutyName" SortExpression="DutyName" 
                            HeaderText="职位" ReadOnly="True">
                            <HeaderStyle Width="60px"></HeaderStyle>
                            <ItemStyle ></ItemStyle>
                        </asp:BoundColumn>
                        <asp:TemplateColumn SortExpression="UserState" HeaderText="状态">
                            <HeaderStyle Width="70px"></HeaderStyle>
                            <ItemStyle CssClass="center"></ItemStyle>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.UserState").ToString()=="A"?"启用":DataBinder.Eval(Container, "DataItem.UserState").ToString()=="U"?"禁用":"" %>'>
                                </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:BoundColumn ReadOnly="True">
                        <ItemStyle CssClass="center"></ItemStyle>
                        </asp:BoundColumn>
                    </Columns>
                </mzh:MzhDataGrid>
                <div>
                    <label for="">批量设置上级主管工号：</label>
                    <input type="text" id="txtSuperHrid"/>
                    <input type="button" value ="设置" onclick="batchSetSuperHrid()"/><asp:Button 
                        runat="server" ID="btnSave" Text ="保存设置" onclick="btnSave_Click"/>
                </div>
            </div>
            <div class="hidden">
                <asp:TextBox ID="txtDeptCode" runat="server"></asp:TextBox>
                <asp:Button ID="btnRefresh"
                    runat="server" Text="刷新" onclick="btnRefresh_Click" />
            </div>
    </td>
    </tr>
    </table>
    </form>
</body>
</html>

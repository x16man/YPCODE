<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SYS_Menu.aspx.cs" Inherits="SystemManagement.MZHUM.SYS_Menu" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="../CSS/Common.css" />
    <link rel="Stylesheet" type="text/css" href="../CSS/MZHUM/SYS_Menu.css" />
    <link rel="Stylesheet" type="text/css" href="../CSS/treeStyle.css" />
    <link rel="stylesheet" type="text/css" href="../CSS/toolbar.css" />

    <script src="../js/jquery-1.8.2.min.js" type="text/javascript"></script>
    <script src="../JS/jquery.blockUI.js" type="text/javascript"></script>
    <script src="../JS/MZHUM/SYS_Menu.js" type="text/javascript"></script>
    
</head>
<body>
    <form id="form1" runat="server">
    <mzh:MzhTitle ID="MzhTitle1" runat="server" />
    <table id="main">
        <tr><td colspan="3">
        <mzh:MzhToolbar ID="MzhToolbar1" runat="server" Items-Capacity="8" OnItemPostBack="MzhToolbar1_ItemPostBack">
                <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable"
                    CausesValidation="False" itemid="Add" cellspacing="0" nakedlabelclass="nakedLabelCell"
                    isshowtext="True" iconclass="add" hasicon="True" text="新建" id="tbiAdd" AutoPostBack="True">
                </mzh:toolbarbutton>
                <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable"
                    CausesValidation="False" itemid="Edit" cellspacing="0" nakedlabelclass="nakedLabelCell"
                    isshowtext="True" iconclass="edit" hasicon="True" text="编辑" id="tbiEdit" AutoPostBack="True">
                </mzh:toolbarbutton>
                <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable"
                    CausesValidation="False" itemid="Delete" cellspacing="0" AutoPostBack="True"
                    nakedlabelclass="nakedLabelCell" isshowtext="True" iconclass="delete" hasicon="True"
                    text="删除" id="tbiDelete" onclick="if(!confirmDelete()) return;">
                </mzh:toolbarbutton>
                <mzh:ToolbarSeparator ID="ToolbarSeparator1" runat="server" ItemId="" SeparatorClass="toolbarIconDivider" />
                <mzh:ToolbarButton ID="tbiSave" runat="server" Cellpadding="0" Cellspacing="0" HasIcon="True"
                    CausesValidation="True" IconClass="save" IsShowText="True" ItemId="Save" LabelClass="labelCell"
                    NakedLabelClass="nakedLabelCell" TableClass="buttonTable" Text="保存" AutoPostBack="True"
                    Visible="False" />
            </mzh:MzhToolbar>
        </td></tr>
        <tr>
            <td id="left" valign="top">
                <ComponentArt:TreeView ID="tvMenu" runat="server" CssClass="TreeView" NodeCssClass="TreeNode"
                SelectedNodeCssClass="SelectedTreeNode" HoverNodeCssClass="HoverTreeNode" LineImageWidth="19"
                LineImageHeight="20" DefaultImageWidth="16" DefaultImageHeight="16" NodeLabelPadding="3"
                ImagesBaseUrl="../Images/treeview_images/" ParentNodeImageUrl="folders.gif" LeafNodeImageUrl="folder.gif"
                ShowLines="true" LineImagesFolderUrl="../Images/treeview_images/lines/" DragAndDropEnabled="True"   
                AutoPostBackOnNodeMove="True" AutoPostBackOnSelect="True" AutoScroll="True"
                CausesValidation="false" OnNodeSelected="tvMenu_NodeSelected" OnNodeMoved="tvMenu_NodeMoved" DropSiblingEnabled="true"
                CollapseNodeOnSelect="false" ExpandNodeOnSelect="false">
                <ClientEvents>
                    <NodeBeforeMove EventHandler="tvMenu_onNodeBeforeMove" />
                    <NodeSelect EventHandler="tvMenu_onNodeSelect" />
                </ClientEvents>
                </ComponentArt:TreeView>
            </td>
            <td id="seperator"></td>
            <td id="right" valign="top">
                <div id="container">
                    <fieldset>
                        <legend title="菜单信息">菜单信息</legend>
                        <div style="float: right; width: 100%; margin-left: -300px;">
                            <div style="margin-left: 280px;">
                                <label for="txtRemark">
                                    菜单说明：</label>
                                <div>
                                    <asp:TextBox ID="txtRemark" runat="server" Rows="6" TextMode="MultiLine"></asp:TextBox>
                                </div>
                                <label for="">检查对象标识：</label>
                                <div>
                                    <asp:TextBox ID="txtCheckCode" runat="server" TextMode="SingleLine" MaxLength="50"></asp:TextBox>
                                </div>
                                <label for="">检查对象类型：</label>
                                <div>
                                    <asp:TextBox ID="txtObjType" runat="server" TextMode="SingleLine" MaxLength="1"></asp:TextBox>
                                </div>
                                <label for="chkSubMenu">
                                    有子菜单：</label>
                                <div>
                                    <asp:CheckBox ID="chkSubMenu" runat="server"></asp:CheckBox></div>
                                <label for="chkIsEnable">
                                    是否有效：</label>
                                <div>
                                    <asp:CheckBox ID="chkIsEnable" runat="server" Checked="true"></asp:CheckBox></div>
                                <label for="txtImageUrl">图片路径：</label>
                                <div><asp:TextBox ID="txtImageUrl" runat="server" Rows="3" TextMode="MultiLine"></asp:TextBox></div>
                            </div>
                        </div>
                        <div id="basic" style="float: left; position: relative; border-width: 0px 1px 0px 0px;
                            border-color: #D5DFE5; width: 270px; margin-right: 20px;">
                            <label>
                                菜单名称： <span class="required">*</span></label><asp:RequiredFieldValidator ID="rfvName"
                                    runat="server" ControlToValidate="txtName" ErrorMessage="(菜单名称不允许为空！)"></asp:RequiredFieldValidator>
                            <div>
                                <asp:TextBox ID="txtName" runat="server" MaxLength="32"></asp:TextBox></div>
                            <label>
                                页面标题： <span class="required">*</span></label><asp:RequiredFieldValidator ID="rfvTitle"
                                    runat="server" ControlToValidate="txtTitle" ErrorMessage="(菜单标题不允许为空！)"></asp:RequiredFieldValidator>
                            <div>
                                <asp:TextBox ID="txtTitle" runat="server" MaxLength="255"></asp:TextBox></div>
                            <label>
                                权限编码： <span class="required">*</span></label><asp:RequiredFieldValidator ID="rfvRightCode"
                                    runat="server" ControlToValidate="txtRightCode" ErrorMessage="(权限编码不允许为空！)"></asp:RequiredFieldValidator>
                                    <asp:RangeValidator ID="rvRightCode" runat="server" 
                                ControlToValidate="txtRightCode" ErrorMessage="" Display="Dynamic" 
                                MaximumValue="65535" MinimumValue="0" Type="Integer">0~65535</asp:RangeValidator>
                            <div>
                                <asp:TextBox ID="txtRightCode" runat="server" MaxLength="5"></asp:TextBox></div>
                            <label>
                                顺序编号： <span class="required">*</span></label><asp:RequiredFieldValidator ID="rfvOrder"
                                    runat="server" ControlToValidate="txtOrder" ErrorMessage="(顺序号不允许为空！)"></asp:RequiredFieldValidator>
                            <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtOrder"
                                ErrorMessage="(数据范围必须在0～30之间！)" MaximumValue="30" MinimumValue="0" Type="Integer">0～30</asp:RangeValidator>
                            <div>
                                <asp:TextBox ID="txtOrder" runat="server" MaxLength="2">0</asp:TextBox></div>
                            <label>
                                菜单等级： <span class="required">*</span></label><asp:RequiredFieldValidator ID="rfvMenuLevel"
                                    runat="server" ControlToValidate="ddlLevel" ErrorMessage="(菜单等级不允许为空！)"></asp:RequiredFieldValidator>
                            <div>
                                <asp:DropDownList ID="ddlLevel" runat="server">
                                    <asp:ListItem Value="1">一级</asp:ListItem>
                                    <asp:ListItem Value="2">二级</asp:ListItem>
                                    <asp:ListItem Value="3" Selected="True">三级</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <label>
                                菜单类型： <span class="required">*</span></label><asp:RequiredFieldValidator ID="rfvType"
                                    runat="server" ControlToValidate="ddlType" ErrorMessage="(菜单类型不允许为空！)"></asp:RequiredFieldValidator>
                            <div>
                                <asp:DropDownList ID="ddlType" runat="server">
                                </asp:DropDownList>
                            </div>
                            <label>
                                显示方式： <span class="required">*</span></label><asp:RequiredFieldValidator ID="rfvURLType"
                                    runat="server" ErrorMessage="(显示类型不允许为空！)" ControlToValidate="ddlURLType" InitialValue="*"></asp:RequiredFieldValidator>
                            <div>
                                <asp:DropDownList ID="ddlURLType" runat="server">
                                    <asp:ListItem Value="-1">空</asp:ListItem>
                                    <asp:ListItem Value="0">在Frame中显示</asp:ListItem>
                                    <asp:ListItem Value="1">以弹出窗口方式显示</asp:ListItem>
                                    <asp:ListItem Value="2">执行JS脚本</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <label>
                                菜单链接： <span class="required">*</span></label><asp:RequiredFieldValidator
                                    ID="rfvURL" runat="server" ControlToValidate="txtURL" Display="Dynamic" ErrorMessage="(菜单链接不允许为空！没有连接请输入#.)"></asp:RequiredFieldValidator>
                            <div>
                                <asp:TextBox ID="txtURL" runat="server" MaxLength="255" Rows="3" TextMode="MultiLine"
                                    Text="#"></asp:TextBox></div>
                        </div>
                    </fieldset>
                </div>
            </td>
            </tr>
            </table>
            <div class="hidden">
                <asp:TextBox ID="txtParentId" runat="server"></asp:TextBox>
                <asp:TextBox ID="txtId" runat="server"></asp:TextBox>
            </div>
    </form>
    
</body>

</html>

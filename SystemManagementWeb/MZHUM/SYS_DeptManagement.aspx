<%@ Page Language="c#" CodeBehind="SYS_DeptManagement.aspx.cs" AutoEventWireup="True" Inherits="SystemManagement.MZHUM.SYS_DeptManagement" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>部门管理</title>
    <link rel="stylesheet" type="text/css" href="../CSS/common.css" />
    <link rel="Stylesheet" type="text/css" href="../CSS/treeStyle.css" />
    <link rel="Stylesheet" type="text/css" href="../CSS/MZHUM/SYS_DeptManagement.css" />
    
    <script src="../JS/jquery-1.8.2.min.js" type="text/javascript"></script>
    <script src="../JS/jquery.blockUI.js" type="text/javascript"></script>
    <script src="/aspnet_client/Shmzh.Web.UI/PopupWindow.js" type="text/javascript"></script>
    <script src="../JS/MZHUM/SYS_DeptManagement.js" type="text/javascript"></script>
</head>
<body>
<form id="form1" runat="server">
<mzh:MzhTitle ID="MzhTitle1" runat="server" />
    <table id="main">
        <tr>
            <td id="sidebar">
        <ComponentArt:TreeView ID="tvDept" runat="server" CssClass="TreeView" NodeCssClass="TreeNode"
            SelectedNodeCssClass="SelectedTreeNode" HoverNodeCssClass="HoverTreeNode" LineImageWidth="19"
            LineImageHeight="20" DefaultImageWidth="16" DefaultImageHeight="16" NodeLabelPadding="3"
            ImagesBaseUrl="../Images/treeview_images/" 
            ParentNodeImageUrl="folders.gif" LeafNodeImageUrl="folder.gif"
            ShowLines="true" LineImagesFolderUrl="../Images/treeview_images/lines/" DragAndDropEnabled="True"
            AutoPostBackOnNodeMove="True" AutoPostBackOnSelect="True" AutoScroll="False"
            CausesValidation="False" OnNodeSelected="tvDept_NodeSelected" OnNodeMoved="tvDept_NodeMoved"
            CollapseNodeOnSelect="False">
            <ClientEvents>
                <NodeBeforeMove EventHandler="tvDept_onNodeBeforeMove" />
                <NodeSelect EventHandler="tvDept_onNodeSelect" />
            </ClientEvents>
        </ComponentArt:TreeView>
    </td>
    <td id="seperator"></td>
        <td id="content">
            <mzh:MzhToolbar ID="MzhToolbar1" runat="server" Items-Capacity="16" OnItemPostBack="MzhToolbar1_ItemPostBack">
                <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable" CausesValidation="False"
                    itemid="AddRoot" cellspacing="0" nakedlabelclass="nakedLabelCell" isshowtext="True"
                    iconclass="addRoot" hasicon="True" text="新建根部门" id="tbiAddRoot" AutoPostBack="True">
                </mzh:toolbarbutton>
                <mzh:ToolbarSeparator ID="ToolbarSeparator0" runat="server" ItemId="Separator0" SeparatorClass="toolbarIconDivider" Visible="True"/>
                <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable"  CausesValidation="False"
                    itemid="Add" cellspacing="0" nakedlabelclass="nakedLabelCell" isshowtext="True"
                    iconclass="add" hasicon="True" text="新建" id="tbiAdd" AutoPostBack="True">
                </mzh:toolbarbutton>
                <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable"  CausesValidation="False"
                    itemid="Edit" cellspacing="0" nakedlabelclass="nakedLabelCell" isshowtext="True"
                    iconclass="edit" hasicon="True" text="编辑" id="tbiEdit" AutoPostBack="True">
                </mzh:toolbarbutton>
                <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable"  CausesValidation="False"
                    itemid="Delete" cellspacing="0" AutoPostBack="True" nakedlabelclass="nakedLabelCell"
                    isshowtext="True" iconclass="delete" hasicon="True" text="删除" id="tbiDelete"
                    onclick="if(!confirmDelete()) return;">
                </mzh:toolbarbutton>
                <mzh:ToolbarSeparator ID="ToolbarSeparator1" runat="server" ItemId="Separator1" SeparatorClass="toolbarIconDivider" Visible="False"/>
                <mzh:ToolbarButton ID="tbiSave" runat="server" Cellpadding="0" Cellspacing="0" HasIcon="True"  CausesValidation="True"
                    IconClass="save" IsShowText="True" ItemId="Save" LabelClass="labelCell" NakedLabelClass="nakedLabelCell"
                    TableClass="buttonTable" Text="保存" AutoPostBack="True" Visible="False" />
                <mzh:ToolbarSeparator ID="ToolbarSeparator2" runat="server" ItemId="Separator2" SeparatorClass="toolbarIconDivider" />
                <mzh:ToolbarCheckBox runat="server" id="tbiIncludeDelete" ItemId="IncludeDelete" Text="显示已删除部门" AutoPostBack="True"  CausesValidation="False">
                </mzh:ToolbarCheckBox>
            </mzh:MzhToolbar>
            <div class="hidden">
                <asp:TextBox ID="txtParentDept" runat="server"></asp:TextBox>
                <asp:TextBox ID="txtParentDeptName" runat="server"></asp:TextBox>
                <asp:TextBox ID="txtDeptMgr" runat="server" MaxLength="20"></asp:TextBox>
                <asp:TextBox ID="txtDeptLevel" runat="server" MaxLength="20"></asp:TextBox>
            </div>
            <div class="fieldWrapper">
                <fieldset>
                    <legend>部门信息</legend>
                    <div id="rightColumn" >
                        <div class="content">
                            <label for="txtRemark">
                                部门说明：</label>
                            <div>
                                <asp:TextBox ID="txtRemark" runat="server" MaxLength="50" Rows="10" TextMode="MultiLine"></asp:TextBox>
                            </div> 
                            <label for="chkIsValid">
                            是否有效： </label>
                        <div>
                            <asp:CheckBox ID="chkIsValid" runat="server"></asp:CheckBox></div>
                        <label for="chkShowInOthereSys">
                            其他系统中是否显示：</label>
                        <div>
                            <asp:CheckBox ID="chkShowInOtherSys" runat="server"></asp:CheckBox></div>
                        </div>
                    </div>
                    <div id="leftColumn">
                        <label for="txtDeptCode">
                            部门编号： <span class="required">*</span></label><asp:RequiredFieldValidator
                                ID="rfvDeptCode" runat="server" ControlToValidate="txtDeptCode" 
                            ErrorMessage="(部门编号不允许为空！)" Display="Dynamic">部门编号不允许为空！</asp:RequiredFieldValidator>
                        <div>
                            <asp:TextBox ID="txtDeptCode" runat="server" MaxLength="20"></asp:TextBox></div>
                        <label for="txtDeptCnName">
                            部门名称： <span class="required">*</span></label><asp:RequiredFieldValidator
                                ID="rfvDeptCnName" runat="server" ControlToValidate="txtDeptCnName" 
                            ErrorMessage="(部门名称不允许为空！)" Display="Dynamic">部门名称不允许为空！</asp:RequiredFieldValidator>
                        <div>
                            <asp:TextBox ID="txtDeptCnName" runat="server" MaxLength="50"></asp:TextBox></div>
                        <label for="txtDeptEnName">
                            英文名称：</label>
                        <div>
                            <asp:TextBox ID="txtDeptEnName" runat="server" MaxLength="50"></asp:TextBox></div>
                        <label for="txtDeptMgrName">部门主管： </label>
                        <div>
                            <asp:TextBox ID="txtDeptMgrName" runat="server" MaxLength="20"></asp:TextBox><input
                                id="btnUserChooser" type="button" value="..." runat="server"/></div>
                        <label for="ddlType">
                            组织类型：</label><asp:RequiredFieldValidator 
                            ID="rfvType" runat="server" ErrorMessage="组织类型不允许为空！"
                                ControlToValidate="ddlType" InitialValue="*" Display="Dynamic">组织类型不允许为空！</asp:RequiredFieldValidator>
                        <div>
                            <asp:DropDownList ID="ddlType" runat="server">
                            </asp:DropDownList>
                            </div>
                        <label for="txtCostCenter">
                            成本中心：</label>
                        <div>
                            <asp:TextBox ID="txtCostCenter" runat="server" MaxLength="50"></asp:TextBox></div>    
                        <label for="txtSerial">
                            序号：</label>
                        <asp:RangeValidator ID="rvSerial" runat="server" ControlToValidate="txtSerial"
                            ErrorMessage="RangeValidator" Type="Integer" MinimumValue="1" MaximumValue="32767">(1~32767)</asp:RangeValidator>
                        <div>
                            <asp:TextBox ID="txtSerial" runat="server" MaxLength="5">1</asp:TextBox></div>
                    </div>
                </fieldset>
            </div>
        </td>
    </tr>
    </table>
    </form>
</body>
</html>

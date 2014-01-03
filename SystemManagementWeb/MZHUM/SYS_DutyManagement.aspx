<%@ Page Language="c#" CodeBehind="SYS_DutyManagement.aspx.cs" AutoEventWireup="True"
    Inherits="SystemManagement.MZHUM.SYS_DutyManagement" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>职位管理</title>
    <link rel="stylesheet" type="text/css" href="../CSS/common.css" />
    <link rel="Stylesheet" type="text/css" href="../CSS/treeStyle.css" />
    <link rel="Stylesheet" type="text/css" href="../CSS/MZHUM/SYS_DutyManagement.css" />
    

    <script src="../JS/jquery-1.8.2.min.js" type="text/javascript"></script>
    <script src="../JS/jquery.blockUI.js" type="text/javascript"></script>
    <script src="../JS/MZHUM/SYS_DutyManagement.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server">
    <mzh:MzhTitle ID="MzhTitle1" runat="server" />
    <table id="main">
        <tr>
        <td id="sidebar">
        <ComponentArt:TreeView ID="tvDuty" runat="server" CssClass="TreeView" NodeCssClass="TreeNode"
            SelectedNodeCssClass="SelectedTreeNode" HoverNodeCssClass="HoverTreeNode" LineImageWidth="19"
            LineImageHeight="20" DefaultImageWidth="16" DefaultImageHeight="16" NodeLabelPadding="3"
            ImagesBaseUrl="../Images/treeview_images/" ParentNodeImageUrl="folders.gif" LeafNodeImageUrl="folder.gif"
            ShowLines="true" LineImagesFolderUrl="../Images/treeview_images/lines/" DragAndDropEnabled="True"
            AutoPostBackOnNodeMove="True" AutoPostBackOnSelect="True" AutoScroll="False"
            CausesValidation="False" OnNodeSelected="tvDuty_NodeSelected" OnNodeMoved="tvDuty_NodeMoved"
            CollapseNodeOnSelect="False">
            <ClientEvents>
                <NodeBeforeMove EventHandler="tvDuty_onNodeBeforeMove" />
                <NodeSelect EventHandler="tvDuty_onNodeSelect" />
            </ClientEvents>
        </ComponentArt:TreeView>
        </td>
        <td id="seperator"></td>
        <td id="content">
            <mzh:MzhToolbar ID="MzhToolbar1" runat="server" Items-Capacity="16" OnItemPostBack="MzhToolbar1_ItemPostBack">
                <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable" CausesValidation="False"
                    itemid="AddRoot" cellspacing="0" nakedlabelclass="nakedLabelCell" isshowtext="True"
                    iconclass="addRoot" hasicon="True" text="新建一级职位" id="tbiAddRoot" AutoPostBack="True">
                </mzh:toolbarbutton>
                <mzh:ToolbarSeparator ID="ToolbarSeparator0" runat="server" ItemId="Separator0" SeparatorClass="toolbarIconDivider"
                    Visible="True" />
                <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable" CausesValidation="False"
                    itemid="Add" cellspacing="0" nakedlabelclass="nakedLabelCell" isshowtext="True"
                    iconclass="add" hasicon="True" text="新建" id="tbiAdd" AutoPostBack="True">
                </mzh:toolbarbutton>
                <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable" CausesValidation="False"
                    itemid="Edit" cellspacing="0" nakedlabelclass="nakedLabelCell" isshowtext="True"
                    iconclass="edit" hasicon="True" text="编辑" id="tbiEdit" AutoPostBack="True">
                </mzh:toolbarbutton>
                <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable" CausesValidation="False"
                    itemid="Delete" cellspacing="0" AutoPostBack="True" nakedlabelclass="nakedLabelCell" visible="False"
                    isshowtext="True" iconclass="delete" hasicon="True" text="删除" id="tbiDelete"
                    onclick="if(!confirmDelete()) return;">
                </mzh:toolbarbutton>
                <mzh:ToolbarSeparator ID="ToolbarSeparator1" runat="server" ItemId="Separator1" SeparatorClass="toolbarIconDivider"
                    Visible="False" />
                <mzh:ToolbarButton ID="tbiSave" runat="server" Cellpadding="0" Cellspacing="0" HasIcon="True"
                    IconClass="save" IsShowText="True" ItemId="Save" LabelClass="labelCell" NakedLabelClass="nakedLabelCell"
                    TableClass="buttonTable" Text="保存" AutoPostBack="True" Visible="False" />
                <mzh:ToolbarSeparator ID="ToolbarSeparator2" runat="server" ItemId="Separator2" SeparatorClass="toolbarIconDivider" />
                <mzh:ToolbarCheckBox runat="server" id="tbiIncludeDelete" ItemId="IncludeDelete" CausesValidation="False"
                    Text="显示已失效职位" AutoPostBack="True">
                </mzh:ToolbarCheckBox>
            </mzh:MzhToolbar>
            <div class="hidden">
                <asp:TextBox ID="txtParentDutyCode" runat="server"></asp:TextBox>
                <asp:TextBox ID="txtDutyLevel" runat="server" MaxLength="20"></asp:TextBox>
            </div>
            <div id="container">
                <fieldset>
                    <legend>职位信息</legend>
                    <label for="txtDeptCode">
                            职位编号： <span class="required">*</span></label><asp:RequiredFieldValidator
                                ID="rfvDutyCode" runat="server" ControlToValidate="txtDutyCode" ErrorMessage="(职位编号不允许为空！)"></asp:RequiredFieldValidator>
                        <div>
                            <asp:TextBox ID="txtDutyCode" runat="server" MaxLength="20"></asp:TextBox></div>
                        <label for="txtDeptCnName">
                            职位名称： <span class="required">*</span></label><asp:RequiredFieldValidator
                                ID="rfvDeptCnName" runat="server" ControlToValidate="txtDutyCnName" ErrorMessage="(职位名称不允许为空！)"></asp:RequiredFieldValidator>
                        <div>
                            <asp:TextBox ID="txtDutyCnName" runat="server" MaxLength="50"></asp:TextBox></div>
                        <label for="txtDutyEnName">
                            英文名称： </label>
                        <div>
                            <asp:TextBox ID="txtDutyEnName" runat="server" MaxLength="50"></asp:TextBox></div>
                        <label for="chkIsValid">
                            是否有效： <span class="required">*</span></label>
                        <div>
                            <asp:CheckBox ID="chkIsValid" runat="server"></asp:CheckBox></div>
                        <label for="txtRemark">
                            说明： </label>
                        <div>
                            <asp:TextBox ID="txtRemark" runat="server" MaxLength="255" Rows="10" TextMode="MultiLine"></asp:TextBox>
                        </div> 
                </fieldset>
            </div>
        </td>
    </tr>
    </table>
    </form>
</body>
</html>

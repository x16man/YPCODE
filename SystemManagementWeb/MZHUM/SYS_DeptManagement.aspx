<%@ Page Language="c#" CodeBehind="SYS_DeptManagement.aspx.cs" AutoEventWireup="True" Inherits="SystemManagement.MZHUM.SYS_DeptManagement" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>���Ź���</title>
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
                    iconclass="addRoot" hasicon="True" text="�½�������" id="tbiAddRoot" AutoPostBack="True">
                </mzh:toolbarbutton>
                <mzh:ToolbarSeparator ID="ToolbarSeparator0" runat="server" ItemId="Separator0" SeparatorClass="toolbarIconDivider" Visible="True"/>
                <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable"  CausesValidation="False"
                    itemid="Add" cellspacing="0" nakedlabelclass="nakedLabelCell" isshowtext="True"
                    iconclass="add" hasicon="True" text="�½�" id="tbiAdd" AutoPostBack="True">
                </mzh:toolbarbutton>
                <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable"  CausesValidation="False"
                    itemid="Edit" cellspacing="0" nakedlabelclass="nakedLabelCell" isshowtext="True"
                    iconclass="edit" hasicon="True" text="�༭" id="tbiEdit" AutoPostBack="True">
                </mzh:toolbarbutton>
                <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable"  CausesValidation="False"
                    itemid="Delete" cellspacing="0" AutoPostBack="True" nakedlabelclass="nakedLabelCell"
                    isshowtext="True" iconclass="delete" hasicon="True" text="ɾ��" id="tbiDelete"
                    onclick="if(!confirmDelete()) return;">
                </mzh:toolbarbutton>
                <mzh:ToolbarSeparator ID="ToolbarSeparator1" runat="server" ItemId="Separator1" SeparatorClass="toolbarIconDivider" Visible="False"/>
                <mzh:ToolbarButton ID="tbiSave" runat="server" Cellpadding="0" Cellspacing="0" HasIcon="True"  CausesValidation="True"
                    IconClass="save" IsShowText="True" ItemId="Save" LabelClass="labelCell" NakedLabelClass="nakedLabelCell"
                    TableClass="buttonTable" Text="����" AutoPostBack="True" Visible="False" />
                <mzh:ToolbarSeparator ID="ToolbarSeparator2" runat="server" ItemId="Separator2" SeparatorClass="toolbarIconDivider" />
                <mzh:ToolbarCheckBox runat="server" id="tbiIncludeDelete" ItemId="IncludeDelete" Text="��ʾ��ɾ������" AutoPostBack="True"  CausesValidation="False">
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
                    <legend>������Ϣ</legend>
                    <div id="rightColumn" >
                        <div class="content">
                            <label for="txtRemark">
                                ����˵����</label>
                            <div>
                                <asp:TextBox ID="txtRemark" runat="server" MaxLength="50" Rows="10" TextMode="MultiLine"></asp:TextBox>
                            </div> 
                            <label for="chkIsValid">
                            �Ƿ���Ч�� </label>
                        <div>
                            <asp:CheckBox ID="chkIsValid" runat="server"></asp:CheckBox></div>
                        <label for="chkShowInOthereSys">
                            ����ϵͳ���Ƿ���ʾ��</label>
                        <div>
                            <asp:CheckBox ID="chkShowInOtherSys" runat="server"></asp:CheckBox></div>
                        </div>
                    </div>
                    <div id="leftColumn">
                        <label for="txtDeptCode">
                            ���ű�ţ� <span class="required">*</span></label><asp:RequiredFieldValidator
                                ID="rfvDeptCode" runat="server" ControlToValidate="txtDeptCode" 
                            ErrorMessage="(���ű�Ų�����Ϊ�գ�)" Display="Dynamic">���ű�Ų�����Ϊ�գ�</asp:RequiredFieldValidator>
                        <div>
                            <asp:TextBox ID="txtDeptCode" runat="server" MaxLength="20"></asp:TextBox></div>
                        <label for="txtDeptCnName">
                            �������ƣ� <span class="required">*</span></label><asp:RequiredFieldValidator
                                ID="rfvDeptCnName" runat="server" ControlToValidate="txtDeptCnName" 
                            ErrorMessage="(�������Ʋ�����Ϊ�գ�)" Display="Dynamic">�������Ʋ�����Ϊ�գ�</asp:RequiredFieldValidator>
                        <div>
                            <asp:TextBox ID="txtDeptCnName" runat="server" MaxLength="50"></asp:TextBox></div>
                        <label for="txtDeptEnName">
                            Ӣ�����ƣ�</label>
                        <div>
                            <asp:TextBox ID="txtDeptEnName" runat="server" MaxLength="50"></asp:TextBox></div>
                        <label for="txtDeptMgrName">�������ܣ� </label>
                        <div>
                            <asp:TextBox ID="txtDeptMgrName" runat="server" MaxLength="20"></asp:TextBox><input
                                id="btnUserChooser" type="button" value="..." runat="server"/></div>
                        <label for="ddlType">
                            ��֯���ͣ�</label><asp:RequiredFieldValidator 
                            ID="rfvType" runat="server" ErrorMessage="��֯���Ͳ�����Ϊ�գ�"
                                ControlToValidate="ddlType" InitialValue="*" Display="Dynamic">��֯���Ͳ�����Ϊ�գ�</asp:RequiredFieldValidator>
                        <div>
                            <asp:DropDownList ID="ddlType" runat="server">
                            </asp:DropDownList>
                            </div>
                        <label for="txtCostCenter">
                            �ɱ����ģ�</label>
                        <div>
                            <asp:TextBox ID="txtCostCenter" runat="server" MaxLength="50"></asp:TextBox></div>    
                        <label for="txtSerial">
                            ��ţ�</label>
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

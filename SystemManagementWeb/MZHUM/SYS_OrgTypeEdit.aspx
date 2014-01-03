<%@ Page Language="c#" CodeBehind="SYS_OrgTypeEdit.aspx.cs" AutoEventWireup="True"
    Inherits="SystemManagement.MZHUM.SYS_OrgTypeEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>��֯����ά��</title>
    <link rel="stylesheet" type="text/css" href="../CSS/common.css" />
    <link rel="stylesheet" type="text/css" href="../CSS/MZHUM/form1column.css" />

    <script src="/aspnet_client/Shmzh.Web.UI/jquery-1.2.6.pack.js" type="text/javascript"></script>

</head>
<body>
    <form id="Form1" method="post" runat="server">
    <div id="main">
        <mzh:MzhToolbar ID="MzhToolbar1" runat="server" 
            onitempostback="MzhToolbar1_ItemPostBack">
            <mzh:ToolbarButton ID="tbiAdd" runat="server" Cellpadding="0" Cellspacing="0" HasIcon="True" AutoPostback="True" CausesValidation="False"
                IconClass="add" IsShowText="True" ItemId="Add" LabelClass="labelCell" NakedLabelClass="nakedLabelCell"
                Text="�½�" TableClass="buttonTable" />
            <mzh:ToolbarButton ID="tbiSave" runat="server" Cellpadding="0" Cellspacing="0" HasIcon="True" AutoPostback="True"
                IconClass="save" IsShowText="True" ItemId="Save" LabelClass="labelCell" NakedLabelClass="nakedLabelCell"
                Text="����" TableClass="buttonTable" />
            <mzh:ToolbarSeparator ID="ToolbarSeparator1" runat="server" ItemId="" SeparatorClass="toolbarIconDivider" />
            <mzh:ToolbarButton ID="tbiClose" runat="server" Cellpadding="0" Cellspacing="0" HasIcon="True" AutoPostback="True"
                IconClass="close" IsShowText="True" ItemId="Close" LabelClass="labelCell" NakedLabelClass="nakedLabelCell"
                onclick="window.close();" Text="�ر�" TableClass="buttonTable" />
        </mzh:MzhToolbar>
        <div class="fieldWrapper">
            <fieldset>
                <legend>��֯������Ϣ</legend>
                <label for="tb_code">
                    ��ţ�<span class="required">*</span></label>
                <asp:RequiredFieldValidator ID="rfvCode" runat="server" ControlToValidate="tb_code"
                    Display="Dynamic" ErrorMessage="����������">����������</asp:RequiredFieldValidator>
                <asp:RangeValidator ID="rvCode" runat="server" ControlToValidate="tb_code" Display="Dynamic"
                    ErrorMessage="��ű�����1~99999֮�������" MaximumValue="99999" MinimumValue="1" Type="Integer">��ű�����1~99999֮�������</asp:RangeValidator>
                <div>
                    <asp:TextBox ID="tb_code" runat="server" MaxLength="20"></asp:TextBox>
                </div>
                <label for="tb_cnname">
                    �������ƣ�<span class="required">*</span></label>
                <asp:RequiredFieldValidator ID="rfvCnName" runat="server" ControlToValidate="tb_cnname"
                    Display="Dynamic" ErrorMessage="����������������">����������������</asp:RequiredFieldValidator>
                <div>
                    <asp:TextBox ID="tb_cnname" runat="server" MaxLength="50"></asp:TextBox>
                </div>
                <label for="tb_enname">
                    Ӣ�����ƣ�<span class="required">&nbsp;&nbsp;</span></label>
                <div>
                    <asp:TextBox ID="tb_enname" runat="server" MaxLength="50"></asp:TextBox>
                </div>
                <label for="tb_level">
                    �ȼ���<span class="required">*</span></label>
                <asp:RequiredFieldValidator ID="rfvLevel" runat="server" ControlToValidate="tb_level"
                    Display="Dynamic" ErrorMessage="�������뼶��">�������뼶��</asp:RequiredFieldValidator>
                <asp:RangeValidator ID="rvLevel" runat="server" ControlToValidate="tb_level" Display="Dynamic"
                    ErrorMessage="���������1~99֮�������" MaximumValue="99" MinimumValue="1" Type="Integer">���������1~99֮�������</asp:RangeValidator>
                <div>
                    <asp:TextBox ID="tb_level" runat="server">1</asp:TextBox>
                </div>
                <label for="ddlIsValid">
                    �Ƿ���Ч��<span class="required">*</span></label>
                <div>
                    <asp:CheckBox ID="chkIsValid" runat="server" Checked="True" />
                </div>
            </fieldset>
        </div>
     
    </div>
    </form>
</body>
</html>

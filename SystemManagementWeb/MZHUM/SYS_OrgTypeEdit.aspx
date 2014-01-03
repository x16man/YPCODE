<%@ Page Language="c#" CodeBehind="SYS_OrgTypeEdit.aspx.cs" AutoEventWireup="True"
    Inherits="SystemManagement.MZHUM.SYS_OrgTypeEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>组织类型维护</title>
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
                Text="新建" TableClass="buttonTable" />
            <mzh:ToolbarButton ID="tbiSave" runat="server" Cellpadding="0" Cellspacing="0" HasIcon="True" AutoPostback="True"
                IconClass="save" IsShowText="True" ItemId="Save" LabelClass="labelCell" NakedLabelClass="nakedLabelCell"
                Text="保存" TableClass="buttonTable" />
            <mzh:ToolbarSeparator ID="ToolbarSeparator1" runat="server" ItemId="" SeparatorClass="toolbarIconDivider" />
            <mzh:ToolbarButton ID="tbiClose" runat="server" Cellpadding="0" Cellspacing="0" HasIcon="True" AutoPostback="True"
                IconClass="close" IsShowText="True" ItemId="Close" LabelClass="labelCell" NakedLabelClass="nakedLabelCell"
                onclick="window.close();" Text="关闭" TableClass="buttonTable" />
        </mzh:MzhToolbar>
        <div class="fieldWrapper">
            <fieldset>
                <legend>组织类型信息</legend>
                <label for="tb_code">
                    编号：<span class="required">*</span></label>
                <asp:RequiredFieldValidator ID="rfvCode" runat="server" ControlToValidate="tb_code"
                    Display="Dynamic" ErrorMessage="必须输入编号">必须输入编号</asp:RequiredFieldValidator>
                <asp:RangeValidator ID="rvCode" runat="server" ControlToValidate="tb_code" Display="Dynamic"
                    ErrorMessage="编号必须是1~99999之间的数字" MaximumValue="99999" MinimumValue="1" Type="Integer">编号必须是1~99999之间的数字</asp:RangeValidator>
                <div>
                    <asp:TextBox ID="tb_code" runat="server" MaxLength="20"></asp:TextBox>
                </div>
                <label for="tb_cnname">
                    中文名称：<span class="required">*</span></label>
                <asp:RequiredFieldValidator ID="rfvCnName" runat="server" ControlToValidate="tb_cnname"
                    Display="Dynamic" ErrorMessage="必须输入中文名称">必须输入中文名称</asp:RequiredFieldValidator>
                <div>
                    <asp:TextBox ID="tb_cnname" runat="server" MaxLength="50"></asp:TextBox>
                </div>
                <label for="tb_enname">
                    英文名称：<span class="required">&nbsp;&nbsp;</span></label>
                <div>
                    <asp:TextBox ID="tb_enname" runat="server" MaxLength="50"></asp:TextBox>
                </div>
                <label for="tb_level">
                    等级：<span class="required">*</span></label>
                <asp:RequiredFieldValidator ID="rfvLevel" runat="server" ControlToValidate="tb_level"
                    Display="Dynamic" ErrorMessage="必须输入级别">必须输入级别</asp:RequiredFieldValidator>
                <asp:RangeValidator ID="rvLevel" runat="server" ControlToValidate="tb_level" Display="Dynamic"
                    ErrorMessage="级别必须是1~99之间的数字" MaximumValue="99" MinimumValue="1" Type="Integer">级别必须是1~99之间的数字</asp:RangeValidator>
                <div>
                    <asp:TextBox ID="tb_level" runat="server">1</asp:TextBox>
                </div>
                <label for="ddlIsValid">
                    是否有效：<span class="required">*</span></label>
                <div>
                    <asp:CheckBox ID="chkIsValid" runat="server" Checked="True" />
                </div>
            </fieldset>
        </div>
     
    </div>
    </form>
</body>
</html>

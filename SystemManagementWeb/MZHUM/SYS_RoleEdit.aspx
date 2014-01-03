<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SYS_RoleEdit.aspx.cs" Inherits="SystemManagement.MZHUM.SYS_RoleEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>角色信息</title>
    <link href="../CSS/Common.css" rel="stylesheet" type="text/css" />
    <link href="../CSS/MZHUM/form1Column.css" rel="stylesheet" type="text/css" />

    <script src="/aspnet_client/Shmzh.Web.UI/jquery-1.2.6.pack.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server">
    <div id="main">
        <mzh:MzhToolbar ID="MzhToolbar1" runat="server" OnItemPostBack="MzhToolbar1_ItemPostBack">
            <mzh:ToolbarButton ID="tbiSave" runat="server" Cellpadding="0" Cellspacing="0" HasIcon="True"
                AutoPostback="True" IconClass="save" IsShowText="True" ItemId="Save" LabelClass="labelCell"
                NakedLabelClass="nakedLabelCell" Text="保存" TableClass="buttonTable" />
            <mzh:ToolbarSeparator ID="ToolbarSeparator1" runat="server" ItemId="" SeparatorClass="toolbarIconDivider" />
            <mzh:ToolbarButton ID="tbiClose" runat="server" Cellpadding="0" Cellspacing="0" HasIcon="True"
                AutoPostback="True" IconClass="close" IsShowText="True" ItemId="Close" LabelClass="labelCell"
                NakedLabelClass="nakedLabelCell" onclick="window.close();" Text="关闭" TableClass="buttonTable" />
        </mzh:MzhToolbar>
        <div class="fieldWrapper">
            <fieldset>
                <legend>角色信息</legend>
                <label for="txtName">
                    名称：<span class="required">*</span></label>
                <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName"
                    Display="Dynamic" ErrorMessage="必须输入名称">必须输入名称</asp:RequiredFieldValidator>
                <div>
                    <asp:TextBox ID="txtName" runat="server" MaxLength="20"></asp:TextBox>
                </div>
                <label for="chkIsValid">是否有效</label>
                <div>
                    <asp:CheckBox ID="chkIsValid" runat="server" Checked="True" />
                </div>
                <label for="txtSerialNo">序号</label>
                <asp:RangeValidator ID="rvSerialNo" runat="server" Type="Integer" MinimumValue="0" MaximumValue="99" ControlToValidate="txtSerialNo">0～99</asp:RangeValidator>
                <div>
                    <asp:TextBox ID="txtSerialNo" runat="server" MaxLength="2"></asp:TextBox>
                </div>
                <label for="txtRemark">
                    备注：</label>
                <div>
                    <asp:TextBox ID="txtRemark" runat="server" Rows="4" TextMode="MultiLine"></asp:TextBox>
                </div>
                
            </fieldset>
        </div>
    </div>
    </form>
</body>
</html>

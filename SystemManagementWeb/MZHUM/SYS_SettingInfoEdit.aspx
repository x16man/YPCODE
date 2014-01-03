<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SYS_SettingInfoEdit.aspx.cs"
    Inherits="SystemManagement.MZHUM.SYS_SettingInfoEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>开关量</title>
    <link type="text/css" rel="stylesheet" href="../CSS/common.css" />
    <link type="text/css" rel="stylesheet" href="../CSS/MZHUM/form1Column.css" />

    <script src="/aspnet_client/Shmzh.Web.UI/jquery-1.2.6.pack.js" type="text/javascript"></script>

    <script type="text/javascript" src="../JS/PopupWindow.js"></script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
        <mzh:MzhToolbar ID="MzhToolbar1" runat="server"  OnItemPostBack="MzhToolbar1_ItemPostBack">
            <%--<mzh:ToolbarButton ID="tbiAdd" runat="server" Cellpadding="0" Cellspacing="0" HasIcon="True"
                AutoPostback="True" CausesValidation="False" IconClass="add" IsShowText="True"
                ItemId="Add" LabelClass="labelCell" NakedLabelClass="nakedLabelCell" Text="新建"
                TableClass="buttonTable" />--%>
            <mzh:ToolbarButton ID="tbiSave" runat="server" Cellpadding="0" Cellspacing="0" HasIcon="True"
                AutoPostback="True" IconClass="save" IsShowText="True" ItemId="Save" LabelClass="labelCell"
                NakedLabelClass="nakedLabelCell" Text="保存" TableClass="buttonTable" />
            <mzh:ToolbarSeparator ID="ToolbarSeparator1" runat="server" ItemId="" SeparatorClass="toolbarIconDivider" />
            <mzh:ToolbarButton ID="tbiClose" runat="server" Cellpadding="0" Cellspacing="0" HasIcon="True"
                AutoPostback="False" IconClass="close" IsShowText="True" ItemId="Close" LabelClass="labelCell"
                NakedLabelClass="nakedLabelCell" onclick="window.close();" Text="关闭" TableClass="buttonTable" />
        </mzh:MzhToolbar>
        <div class="fieldWrapper">
            <fieldset>
                <legend>配置信息</legend>
                <label for="txtSettingKey">
                    关键字：<span class="required">*</span></label>
                <asp:RequiredFieldValidator ID="rfvSettingKey" runat="server" ControlToValidate="txtSettingKey"
                    Display="Dynamic" ErrorMessage="">必须输入关键字</asp:RequiredFieldValidator>
                <div>
                    <asp:TextBox ID="txtSettingKey" runat="server" MaxLength="20"></asp:TextBox>
                </div>
                <label for="txtValue">
                    值：<span class="required">*</span></label>
                <asp:RequiredFieldValidator ID="refValue" runat="server" ControlToValidate="txtValue"
                    Display="Dynamic" ErrorMessage="">必须输入值</asp:RequiredFieldValidator>
                <div>
                    <asp:TextBox ID="txtValue" runat="server" MaxLength="100"></asp:TextBox>
                </div>
                
                <label for="tb_Remark">
                    描述：</label>
                <div>
                    <asp:TextBox ID="tb_Remark" runat="server" MaxLength="255" Rows="3" TextMode="MultiLine"></asp:TextBox>
                     <asp:RegularExpressionValidator ID="RegularExpressionValidator1" Display="None" ControlToValidate="tb_Remark"
                        runat="server" ValidationExpression="(\w|\W){1,255}" ErrorMessage="描述所填字数不能大于255">
                        </asp:RegularExpressionValidator>
                </div>
                <label for="txtCategory">
                    类别：</label>
                <div>
                    <asp:TextBox ID="txtCategory" runat="server" MaxLength="10"></asp:TextBox>
                </div>
            </fieldset>
        </div>
    </div>
    </form>
</body>
</html>

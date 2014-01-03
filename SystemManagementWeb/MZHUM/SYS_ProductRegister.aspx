<%@ Page language="c#" Codebehind="SYS_ProductRegister.aspx.cs" AutoEventWireup="True" Inherits="SystemManagement.MZHUM.SYS_ProductRegister" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
    <head>
        <title>产品维护</title>
        <link type="text/css" rel="stylesheet" href="../CSS/common.css" />
        <link type="text/css" rel="stylesheet" href="../CSS/MZHUM/form1Column.css" />

        <script src="/aspnet_client/Shmzh.Web.UI/jquery-1.2.6.pack.js" type="text/javascript"></script>

    </head>
    <body>
        <form id="Form1" method="post" runat="server">
            <div>
                <mzh:MzhToolbar ID="MzhToolbar1" runat="server" onitempostback="MzhToolbar1_ItemPostBack">
                    <mzh:ToolbarButton ID="tbiSave" runat="server" Cellpadding="0" Cellspacing="0" HasIcon="True" AutoPostback="True"
                        IconClass="save" IsShowText="True" ItemId="Save" LabelClass="labelCell" NakedLabelClass="nakedLabelCell"
                        Text="保存" TableClass="buttonTable" />
                    <mzh:ToolbarSeparator ID="ToolbarSeparator1" runat="server" ItemId="" SeparatorClass="toolbarIconDivider" />
                    <mzh:ToolbarButton ID="tbiClose" runat="server" Cellpadding="0" Cellspacing="0" HasIcon="True" AutoPostback="False"
                        IconClass="close" IsShowText="True" ItemId="Close" LabelClass="labelCell" NakedLabelClass="nakedLabelCell"
                        onclick="window.close();" Text="关闭" TableClass="buttonTable" />
                </mzh:MzhToolbar>
                <div class="fieldWrapper">
                    <fieldset>
                        <legend>产品信息</legend>
                        <label for="txtProductCode">产品编号:<span class="required">*</span></label>
                        <asp:requiredfieldvalidator id="rfvProductCode" runat="server" controltovalidate="tb_ProductCode" Display="Dynamic"	errormessage="必须输入编号">必须输入编号</asp:requiredfieldvalidator>
                        <asp:RangeValidator ID="rvProductCode" runat="server" ControlToValidate="tb_ProductCode" Display="Dynamic" ErrorMessage="编号必须是1~99之间的数字" MaximumValue="99" MinimumValue="1" Type="Integer">编号必须是1~99之间的数字</asp:RangeValidator>
                        <div>
                            <asp:TextBox ID="tb_ProductCode" runat="server" MaxLength="2"></asp:TextBox>
                        </div>
                        <label for="tb_ProductName">产品名称：<span class="required">*</span></label>
                        <asp:RequiredFieldValidator ID="rfvProductName" runat="server" 
                            ControlToValidate="tb_ProductName" Display="Dynamic" ErrorMessage="必须输入名称">必须输入名称</asp:RequiredFieldValidator>
                        <div>
                            <asp:TextBox ID="tb_ProductName" runat="server" MaxLength="50"></asp:TextBox>
                        </div>
                        <div>
                            <asp:Label runat="server" ID="lblCompanyName"></asp:Label>
                        </div>
                        <label for="tb_License">注册码：</label>
                        <div>
                            <asp:TextBox ID="tb_License" runat="server" MaxLength="4000" Rows="10" 
                                TextMode="MultiLine"></asp:TextBox>
                        </div>
                    </fieldset>
                </div>
                <div class="hidden">
                    <asp:Button ID="Button1" runat="server" Text="Button" />
                </div>
            </div>
        </form>
    </body>
</html>

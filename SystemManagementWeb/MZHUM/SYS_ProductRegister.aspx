<%@ Page language="c#" Codebehind="SYS_ProductRegister.aspx.cs" AutoEventWireup="True" Inherits="SystemManagement.MZHUM.SYS_ProductRegister" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
    <head>
        <title>��Ʒά��</title>
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
                        Text="����" TableClass="buttonTable" />
                    <mzh:ToolbarSeparator ID="ToolbarSeparator1" runat="server" ItemId="" SeparatorClass="toolbarIconDivider" />
                    <mzh:ToolbarButton ID="tbiClose" runat="server" Cellpadding="0" Cellspacing="0" HasIcon="True" AutoPostback="False"
                        IconClass="close" IsShowText="True" ItemId="Close" LabelClass="labelCell" NakedLabelClass="nakedLabelCell"
                        onclick="window.close();" Text="�ر�" TableClass="buttonTable" />
                </mzh:MzhToolbar>
                <div class="fieldWrapper">
                    <fieldset>
                        <legend>��Ʒ��Ϣ</legend>
                        <label for="txtProductCode">��Ʒ���:<span class="required">*</span></label>
                        <asp:requiredfieldvalidator id="rfvProductCode" runat="server" controltovalidate="tb_ProductCode" Display="Dynamic"	errormessage="����������">����������</asp:requiredfieldvalidator>
                        <asp:RangeValidator ID="rvProductCode" runat="server" ControlToValidate="tb_ProductCode" Display="Dynamic" ErrorMessage="��ű�����1~99֮�������" MaximumValue="99" MinimumValue="1" Type="Integer">��ű�����1~99֮�������</asp:RangeValidator>
                        <div>
                            <asp:TextBox ID="tb_ProductCode" runat="server" MaxLength="2"></asp:TextBox>
                        </div>
                        <label for="tb_ProductName">��Ʒ���ƣ�<span class="required">*</span></label>
                        <asp:RequiredFieldValidator ID="rfvProductName" runat="server" 
                            ControlToValidate="tb_ProductName" Display="Dynamic" ErrorMessage="������������">������������</asp:RequiredFieldValidator>
                        <div>
                            <asp:TextBox ID="tb_ProductName" runat="server" MaxLength="50"></asp:TextBox>
                        </div>
                        <div>
                            <asp:Label runat="server" ID="lblCompanyName"></asp:Label>
                        </div>
                        <label for="tb_License">ע���룺</label>
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

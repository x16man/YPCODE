<%@ Page language="c#" Codebehind="SYS_TemplateEdit.aspx.cs" validateRequest="false" AutoEventWireup="True" Inherits="SystemManagement.MZHUM.SYS_TemplateEdit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
	<head>
		<title>ģ��ά��</title>
		<link type="text/css" rel="stylesheet" href="../CSS/common.css" />
        <link type="text/css" rel="Stylesheet" href="../CSS/MZHUM/SYS_TemplateEdit.css" />
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
                        <legend>ģ����Ϣ</legend>
                        <label for="lblCode">ģ����:<span class="required">*</span></label>
                        <asp:requiredfieldvalidator id="rfvCode" runat="server" controltovalidate="txtCode" Display="Dynamic"	errormessage="����������">����������</asp:requiredfieldvalidator>
                        <div>
                            <asp:TextBox ID="txtCode" runat="server" MaxLength="10"></asp:TextBox>
                        </div>
                        <label for="tb_ProductName">ģ�����ƣ�<span class="required">*</span></label>
                        <asp:RequiredFieldValidator ID="rfvName" runat="server" 
                            ControlToValidate="txtName" Display="Dynamic" ErrorMessage="������������">������������</asp:RequiredFieldValidator>
                        <div>
                            <asp:TextBox ID="txtName" runat="server" MaxLength="20"></asp:TextBox>
                        </div>
                        <label for="tb_Remark">ģ��������</label>
                        <div>
                            <asp:TextBox ID="txtRemark" runat="server" MaxLength="255" Rows="3" 
                                TextMode="MultiLine"></asp:TextBox>
                        </div>
                        <label for="ddlIsValid">ģ�����ݣ�<span class="required"></span></label>
                        <div>
                            <asp:TextBox ID="txtContent" runat="server" TextMode="MultiLine" Rows="40"></asp:TextBox>
                        </div>
                        
                    </fieldset>
                </div>
                <div class="hidden">
                </div>
            </div>
		</form>
	</body>
</html>

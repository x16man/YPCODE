<%@ Page language="c#" Codebehind="SYS_RightCodeEdit.aspx.cs" AutoEventWireup="True" Inherits="SystemManagement.MZHUM.SYS_RightCodeEdit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
	<head>
		<title>��ƷȨ��</title>
		<link type="text/css" rel="stylesheet" href="../CSS/common.css" />
        <link type="text/css" rel="stylesheet" href="../CSS/MZHUM/form1column.css" />
        
        <script src="/aspnet_client/Shmzh.Web.UI/jquery-1.2.6.pack.js" type="text/javascript"></script>
	</head>
	<body>
		<form id="Form1" method="post" runat="server">
		    <div>
                <mzh:MzhToolbar ID="MzhToolbar1" runat="server" onitempostback="MzhToolbar1_ItemPostBack">
                    <mzh:ToolbarButton ID="tbiAdd" runat="server" Cellpadding="0" Cellspacing="0" HasIcon="True" AutoPostback="True" CausesValidation="False"
                        IconClass="add" IsShowText="True" ItemId="Add" LabelClass="labelCell" NakedLabelClass="nakedLabelCell"
                        Text="�½�" TableClass="buttonTable" />
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
                        <legend>Ȩ����Ϣ</legend>
                        <label for="txtRightCode">Ȩ�ޱ��:<span class="required">*</span></label>
                        <asp:requiredfieldvalidator id="rfvRightCode" runat="server" errormessage="����������" display="Dynamic" controltovalidate="txtRightCode">����������</asp:requiredfieldvalidator>
						<asp:rangevalidator id="rvRightCode" runat="server" errormessage="��ű�����0~65535֮�������" display="Dynamic" controltovalidate="txtRightCode" type="Integer" minimumvalue="0" maximumvalue="65535">��ű�����0~65535֮�������</asp:rangevalidator>
						<div>
							<asp:textbox id="txtRightCode" runat="server" MaxLength="5"></asp:textbox>
						</div>
						<label for="txtRightName">Ȩ������:<span class="required">*</span></label>
						<asp:requiredfieldvalidator id="rfvRightName" runat="server" errormessage="��������Ȩ������" display="Dynamic" controltovalidate="txtRightName">��������Ȩ������</asp:requiredfieldvalidator>
						<div>
							<asp:textbox id="txtRightName" runat="server" MaxLength="50"></asp:textbox>
						</div>
						<label for="chkIsValid">�Ƿ���Ч:</label>
						<div>
						    <asp:CheckBox ID="chkIsValid" runat="server" Checked="True" />
						</div>
						<label for="txtProductCode">Ȩ�޷���:</label>
						<div>
							<asp:dropdownlist id="ddlCat" runat="server"></asp:dropdownlist>
						</div>
						<label for="txtRemark">Ȩ������:</label>
						<div>
							<asp:textbox id="txtRemark" runat="server" MaxLength="50" Rows="3" TextMode="MultiLine"></asp:textbox>
						</div>
						
                    </fieldset>
                </div>
			</div>
		</form>
	</body>
</html>

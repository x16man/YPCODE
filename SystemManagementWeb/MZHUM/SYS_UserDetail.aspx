<%@ Page language="c#" Codebehind="SYS_UserDetail.aspx.cs" AutoEventWireup="True" Inherits="SystemManagement.MZHUM.SYS_UserDetail" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
	<title>��Ա��Ϣ</title>
    <link href="../CSS/reset.css" rel="stylesheet" type="text/css" />
    <link href="../CSS/base.css" rel="stylesheet" type="text/css" />
</head>
	<body>
		<form id="Form1" method="post" runat="server">
			<table id="Table4" cellpadding="5" border="0" width="100%">
				<tr valign="top">
					<td colspan="3" bgcolor="#acc8f7" style="FONT-WEIGHT: bold; COLOR: #ffffff" height="1">
						<img src="../Images/User.png" align="" alt="�û���ϸ��Ϣ"/>�û���ϸ��Ϣ
					</td>
				</tr>
				<tr valign="top">
					<td rowspan="3" width="33%">&nbsp;</td>
					<td width="33%">������
						<asp:Label id="lb_EmpCnName" runat="server"></asp:Label></td>
					<td width="33%">���ţ�
						<asp:Label id="lb_EmpCode" runat="server"></asp:Label></td>
				</tr>
				<tr valign="top">
					<td>Ӣ������
						<asp:Label id="lb_EmpEnName" runat="server"></asp:Label></td>
					<td>������
						<asp:Label id="lb_IsEmp" runat="server"></asp:Label></td>
				</tr>
				<tr valign="top">
					<td>��½����
						<asp:Label id="lb_LoginName" runat="server"></asp:Label></td>
					<td>״̬��
						<asp:Label id="lb_UserState" runat="server"></asp:Label></td>
				</tr>
				<tr valign="top">
					<td>�칫�绰��
						<asp:Label id="lb_OfficeCall" runat="server"></asp:Label></td>
					<td>���棺
						<asp:Label id="lb_OfficeFax" runat="server"></asp:Label></td>
					<td>�ֻ���
						<asp:Label id="lb_Mobile" runat="server"></asp:Label></td>
				</tr>
				<tr valign="top">
					<td>E-mail��ַ��
						<asp:Label id="lb_Email" runat="server"></asp:Label></td>
					<td>���գ�
						<asp:Label id="lb_Birthday" runat="server"></asp:Label></td>
					<td>�Ա�
						<asp:Label id="lb_Gender" runat="server"></asp:Label></td>
				</tr>
				<tr valign="top">
					<td>&nbsp;</td>
					<td>&nbsp;</td>
					<td>&nbsp;</td>
				</tr>
				<tr valign="top">
					<td>������������
						<asp:Label id="lb_DeptCnName" runat="server"></asp:Label></td>
					<td>����Ӣ������
						<asp:Label id="lb_DeptEnName" runat="server"></asp:Label></td>
					<td>���֤��
						<asp:Label id="lb_IDCard" runat="server"></asp:Label></td>
				</tr>
				<tr valign="top">
					<td>ְλ��������
						<asp:Label id="lb_DutyCnName" runat="server"></asp:Label></td>
					<td>ְλӢ������
						<asp:Label id="lb_DutyEnName" runat="server"></asp:Label></td>
					<td>&nbsp;</td>
				</tr>
			</table>
		</form>
	</body>
</html>

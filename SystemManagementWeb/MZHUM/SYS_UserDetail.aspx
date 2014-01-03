<%@ Page language="c#" Codebehind="SYS_UserDetail.aspx.cs" AutoEventWireup="True" Inherits="SystemManagement.MZHUM.SYS_UserDetail" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
	<title>人员信息</title>
    <link href="../CSS/reset.css" rel="stylesheet" type="text/css" />
    <link href="../CSS/base.css" rel="stylesheet" type="text/css" />
</head>
	<body>
		<form id="Form1" method="post" runat="server">
			<table id="Table4" cellpadding="5" border="0" width="100%">
				<tr valign="top">
					<td colspan="3" bgcolor="#acc8f7" style="FONT-WEIGHT: bold; COLOR: #ffffff" height="1">
						<img src="../Images/User.png" align="" alt="用户详细信息"/>用户详细信息
					</td>
				</tr>
				<tr valign="top">
					<td rowspan="3" width="33%">&nbsp;</td>
					<td width="33%">姓名：
						<asp:Label id="lb_EmpCnName" runat="server"></asp:Label></td>
					<td width="33%">工号：
						<asp:Label id="lb_EmpCode" runat="server"></asp:Label></td>
				</tr>
				<tr valign="top">
					<td>英文名：
						<asp:Label id="lb_EmpEnName" runat="server"></asp:Label></td>
					<td>所属：
						<asp:Label id="lb_IsEmp" runat="server"></asp:Label></td>
				</tr>
				<tr valign="top">
					<td>登陆名：
						<asp:Label id="lb_LoginName" runat="server"></asp:Label></td>
					<td>状态：
						<asp:Label id="lb_UserState" runat="server"></asp:Label></td>
				</tr>
				<tr valign="top">
					<td>办公电话：
						<asp:Label id="lb_OfficeCall" runat="server"></asp:Label></td>
					<td>传真：
						<asp:Label id="lb_OfficeFax" runat="server"></asp:Label></td>
					<td>手机：
						<asp:Label id="lb_Mobile" runat="server"></asp:Label></td>
				</tr>
				<tr valign="top">
					<td>E-mail地址：
						<asp:Label id="lb_Email" runat="server"></asp:Label></td>
					<td>生日：
						<asp:Label id="lb_Birthday" runat="server"></asp:Label></td>
					<td>性别：
						<asp:Label id="lb_Gender" runat="server"></asp:Label></td>
				</tr>
				<tr valign="top">
					<td>&nbsp;</td>
					<td>&nbsp;</td>
					<td>&nbsp;</td>
				</tr>
				<tr valign="top">
					<td>部门中文名：
						<asp:Label id="lb_DeptCnName" runat="server"></asp:Label></td>
					<td>部门英文名：
						<asp:Label id="lb_DeptEnName" runat="server"></asp:Label></td>
					<td>身份证：
						<asp:Label id="lb_IDCard" runat="server"></asp:Label></td>
				</tr>
				<tr valign="top">
					<td>职位中文名：
						<asp:Label id="lb_DutyCnName" runat="server"></asp:Label></td>
					<td>职位英文名：
						<asp:Label id="lb_DutyEnName" runat="server"></asp:Label></td>
					<td>&nbsp;</td>
				</tr>
			</table>
		</form>
	</body>
</html>

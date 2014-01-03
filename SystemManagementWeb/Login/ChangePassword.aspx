<%@ Page language="c#" Codebehind="ChangePassword.aspx.cs" AutoEventWireup="true" Inherits="SystemManagement.MZHUM.ChangePassword" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
	<head>
		<title>Password change</title>
	    <link type="text/css" rel="stylesheet"  href="../CSS/Common.css"/>
	    <link href="../CSS/MZHUM/form1Column.css" rel="stylesheet" type="text/css" />
	    
	</head>
	<body>
		<form id="Form1" method="post" runat="server">
		    <div class="fieldWrapper">
		    <fieldset>
		        <legend>Password change</legend>
		        <label for="">Old Password:</label>
		        <div><asp:TextBox id="tb_oldpass" runat="server" TextMode="Password"></asp:TextBox></div>
		        <label for="">New Password:</label>
		        <asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ControlToValidate="tb_newpass" ErrorMessage="The new password can not be empty!"
							Display="Dynamic">The new password can not be empty!</asp:RequiredFieldValidator>
		        <div><asp:TextBox id="tb_newpass" runat="server" TextMode="Password"></asp:TextBox></div>
		        <label for="">Confirmed Password£º</label>
		        <asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" ControlToValidate="tb_confirm" ErrorMessage="The confirm password can not be empty!"
							Display="Dynamic">The confirm password can not be empty!</asp:RequiredFieldValidator>
						<asp:CompareValidator id="CompareValidator1" runat="server" ErrorMessage="The confirmed password is different with the new password." ControlToValidate="tb_confirm"
							ControlToCompare="tb_newpass" Display="Dynamic">The confirmed password and the new password must be same£¡</asp:CompareValidator>
		        <div><asp:TextBox id="tb_confirm" runat="server" TextMode="Password"></asp:TextBox></div>
		        <div style="margin-top:5px;text-align:right;padding-right:30px;">
		        <asp:Button id="btn_submit" runat="server" Text="Save" onclick="btn_submit_Click"></asp:Button>&nbsp;&nbsp;&nbsp;
				<input id="btn_cancel" type="button" value="Cancel" onclick="window.close()">
				<asp:ValidationSummary id="ValidationSummary1" runat="server" ShowMessageBox="true" ShowSummary="False"></asp:ValidationSummary>
				</div>
				</fieldset>
		    </div>
		</form>
	</body>
</html>

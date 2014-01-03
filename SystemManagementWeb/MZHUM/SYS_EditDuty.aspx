<%@ Page language="c#" Codebehind="SYS_EditDuty.aspx.cs" AutoEventWireup="True" Inherits="SystemManagement.MZHUM.SYS_EditDuty" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SYS_EditDuty</title>
		<LINK href="../Style/PCSTYLES.css" type="text/css" rel="stylesheet">
		<LINK href="../Style/MZHREPOSITORY.css" type="text/css" rel="stylesheet">
		<LINK href="../Style/StyleSheet.css" type="text/css" rel="stylesheet">
		<LINK href="../CSS/Common.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<FONT face="����">
				<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="98%" align="center" border="0">
					<TR>
						<TD style="BORDER-TOP: #003399 1px solid; PADDING-LEFT: 5px; PADDING-BOTTOM: 2px; PADDING-TOP: 2px"><FONT class="bold_text">ְλ��Ϣ
								<asp:TextBox id="tb_GroupIDs" runat="server" Width="0px"></asp:TextBox>
								<asp:TextBox id="tb_GroupNames" runat="server" Width="0px"></asp:TextBox></FONT></TD>
					</TR>
				</TABLE>
			</FONT>
			<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="96%" align="center" border="0">
				<TR>
					<TD style="PADDING-TOP: 5px">
						<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD>
									<TABLE class="TableEmpDetail" id="Table1" cellSpacing="1" cellPadding="1" border="1">
										<TR>
											<TD noWrap>ְλ���ƣ�<span class="required">*</span>&nbsp;&nbsp;&nbsp;
												<asp:textbox id="tb_DutyCnName" runat="server"></asp:textbox>
												<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ControlToValidate="tb_DutyCnName" ErrorMessage="��������ְλ���ƣ�"
													Display="None">*</asp:RequiredFieldValidator></TD>
											<TD noWrap>ְλ��ţ�<span class="required">*</span>
												<asp:textbox id="tb_DutyCode" runat="server"></asp:textbox>
												<asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" ControlToValidate="tb_DutyCode" ErrorMessage="��������ְλ��ţ�"
													Display="None">*</asp:RequiredFieldValidator>
												<asp:RangeValidator id="RangeValidator1" runat="server" ControlToValidate="tb_DutyCode" ErrorMessage="ְλ��ű�����1~99999֮������֣�"
													Type="Integer" MinimumValue="1" MaximumValue="99999" Display="None">X</asp:RangeValidator></TD>
										</TR>
										<TR style="VISIBILITY: hidden; POSITION: absolute">
											<TD colSpan="2">ְλ��Ա��
												<asp:textbox id="tb_UserNames" runat="server" Width="248px" ReadOnly="True"></asp:textbox>&nbsp;
												<INPUT onclick="ShowUserList()" type="button" value="ѡȡ��Ա"><INPUT id="tb_UserIDs" style="WIDTH: 8px; HEIGHT: 18px" type="hidden" size="1" name="Hidden1"
													runat="server"></TD>
										</TR>
										<tr>
											<td noWrap>ְλ��Ӣ�����ƣ�
												<asp:textbox id="txtEnName" runat="server"></asp:textbox>
											</td>
											<td>�Ƿ���Ч��&nbsp;
												<asp:dropdownlist id="dpValid" runat="server">
													<asp:ListItem Value="Y">��Ч</asp:ListItem>
													<asp:ListItem Value="N">��Ч</asp:ListItem>
												</asp:dropdownlist>
											</td>
										<tr>
										</tr>
										<TR>
											<TD colSpan="2">ְλ������<BR>
												<asp:TextBox id="tb_Remark" runat="server" Columns="62" Rows="25" TextMode="MultiLine"></asp:TextBox></TD>
										</TR>
									</TABLE>
								</TD>
								<TD>
									<asp:ValidationSummary id="ValidationSummary1" runat="server"></asp:ValidationSummary></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
			<BR>
			<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="98%" align="center" border="0">
				<TR>
					<TD style="BORDER-TOP: #003399 1px solid; PADDING-LEFT: 180px; PADDING-BOTTOM: 2px; PADDING-TOP: 2px"><FONT class="bold_text">
							<asp:button id="btn_save" runat="server" Text="����ְλ��Ϣ" onclick="btn_save_Click"></asp:button>&nbsp; </FONT>
						<INPUT style="WIDTH: 112px; HEIGHT: 18px" type="reset" size="20" value="��  ��"></FONT></TD>
				</TR>
			</TABLE>
		</form>
		<script>
			function ShowUserList()
			{
				window.open('SYS_ChooseUsers.aspx?ids='+document.all.tb_UserIDs.value,"UserChoose","location=no,directions=no,status=no,menubar=no,width=250,Height=400,left=400,top=100");
			}
		</script>
	</body>
</HTML>

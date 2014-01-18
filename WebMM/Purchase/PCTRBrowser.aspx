<%@ Register TagPrefix="cc1" Namespace="MZHWEB.NET.Controls" Assembly="MZHWEB.NET" %>
<%@ Page language="c#" Codebehind="PCTRBrowser.aspx.cs" AutoEventWireup="false" Inherits="MZHMM.WebMM.Purchase.PCTRBrowser" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>PCTRBrowser(zuofei)</title>
		
		
		
		
		<LINK href="../CSS/StyleSheet.css" type="text/css" rel="stylesheet">
		<script src="../JS/SearchBar.js"></script>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="8" rightMargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="98%" align="center" border="0">
				<TR>
					<TD style="BORDER-RIGHT: #ffcc33 1px solid; BORDER-TOP: #ffcc33 1px solid; BORDER-LEFT: #ffcc33 1px solid; WIDTH: 690px; BORDER-BOTTOM: #ffcc33 1px solid; HEIGHT: 26px; BACKGROUND-COLOR: #ffffcc"
						height="26">&nbsp;&nbsp; <A href="PCTRInput.aspx">�½�</A>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						<A onclick="editItem()" href="#">�༭</A>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <A onclick="copyItem()" href="#">
							����</A>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <A onclick="deleteItems()" href="#">ɾ��</A>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						<A onclick="ShowSearchBar('../Sys/SelectEngine.aspx?ModuleID=107')" href="#">��ѯ</A>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						<asp:button id="btn_delete" runat="server" Text="ɾ��" Width="0px"></asp:button><asp:textbox id="tb_SelectedArray" runat="server" Width="0px"></asp:textbox></TD>
				</TR>
				<TR>
					<TD><cc1:MzhDataGrid id="DataGrid1" runat="server" Width="100%" name="MzhMultiSelectDataGrid" CellPadding="3"
							BorderWidth="1px" CellSpacing="1" BorderColor="#0099CC" AutoGenerateColumns="False" CssClass="datagrid"
							PageSize="20" AllowPaging="True" SelectType="MultiSelect" AllowSorting="True" IdCell="0" SelectedColor="Blue"
							HighLightColor="Gold">
							<PagerStyle HorizontalAlign="Right" Mode="NumericPages"></PagerStyle>
							<AlternatingItemStyle BackColor="#D8F4FF"></AlternatingItemStyle>
							<ItemStyle BackColor="#F2F8FF"></ItemStyle>
							<HeaderStyle BackColor="#99CCFF"></HeaderStyle>
							<Columns>
								<asp:BoundColumn Visible="False" DataField="EntryNo" HeaderText="EntryNo"></asp:BoundColumn>
								<asp:BoundColumn DataField="EntryCode" SortExpression="EntryCode" HeaderText="��ͬ��"></asp:BoundColumn>
								<asp:BoundColumn DataField="EntryName" SortExpression="EntryName" HeaderText="��ͬ����"></asp:BoundColumn>
								<asp:BoundColumn DataField="PrvName" SortExpression="PrvName" HeaderText="��Ӧ������"></asp:BoundColumn>
								<asp:BoundColumn DataField="EntryDate" SortExpression="EntryDate" HeaderText="ǩ������"></asp:BoundColumn>
								<asp:BoundColumn DataField="AuthorName" SortExpression="AuthorName" HeaderText="��д��"></asp:BoundColumn>
								<asp:BoundColumn DataField="AuthorDeptName" SortExpression="AuthorDeptName" HeaderText="��д����"></asp:BoundColumn>
								<asp:BoundColumn DataField="TypeName" SortExpression="TypeName" HeaderText="��ͬ����"></asp:BoundColumn>
								<asp:BoundColumn DataField="TotalMoney" SortExpression="TotalMoney" HeaderText="�ܽ��">
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="PayMoney" SortExpression="PayMoney" HeaderText="�ۼƸ���">
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="LeftMoney" SortExpression="LeftMoney" HeaderText="ʣ�����">
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="CleanDate" SortExpression="CleanDate" HeaderText="��������"></asp:BoundColumn>
							</Columns>
						</cc1:MzhDataGrid></TD>
				</TR>
			</TABLE>
			<SCRIPT language="javascript">
			//�༭
			function editItem()
			{
				if(<%=DataGrid1.ClientID%>_obj.getSelectedID()!=null&&<%=DataGrid1.ClientID%>_obj.getSelectedID()!="")
				{
					if (<%=DataGrid1.ClientID%>_obj.getSelectedID()!=-1)
					{
						document.location="PCTRInput.aspx?Op=Edit&Code="+<%=DataGrid1.ClientID%>_obj.getSelectedID();
					}
				}
			}
						
			//ɾ��
			function deleteItems()
			{
				if(<%=DataGrid1.ClientID%>_obj.getSelectedArray() != null&&<%=DataGrid1.ClientID%>_obj.getSelectedArray()!="")
				{
					if(confirm("ȷ��Ҫɾ��ѡ�������ݣ�"))
					{
						document.forms[0].tb_SelectedArray.value=<%=DataGrid1.ClientID%>_obj.getSelectedArray();
						document.forms[0].btn_delete.click();
					}
				}
			}

			//����
			function copyItem()
			{
				if(<%=DataGrid1.ClientID%>_obj.getSelectedID()!=null&&<%=DataGrid1.ClientID%>_obj.getSelectedID()!="")
				{
					if (<%=DataGrid1.ClientID%>_obj.getSelectedID()!=-1)
					{
						document.location="PCTRInput.aspx?Op=Copy&Code="+<%=DataGrid1.ClientID%>_obj.getSelectedID();
					}
				}
			}
			
			</SCRIPT>
		</form>
	</body>
</HTML>

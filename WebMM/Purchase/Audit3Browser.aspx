
<%@ Page language="c#" Codebehind="Audit3Browser.aspx.cs" AutoEventWireup="True" Inherits="MZHMM.WebMM.Purchase.Audit3Browser" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head  runat="server">
		<title>����ģ�����</title>
		
		<LINK href="../CSS/StyleSheet.css" type="text/css" rel="stylesheet">
		<script src="../JS/SearchBar.js"></script>
		<script src="../JS/MenuShow.js"></script>
</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="8" rightMargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="98%" align="center" border="0">
				<TBODY>
					<TR>
						<TD style="BORDER-RIGHT: #ffcc33 1px solid; BORDER-TOP: #ffcc33 1px solid; BORDER-LEFT: #ffcc33 1px solid; WIDTH: 690px; BORDER-BOTTOM: #ffcc33 1px solid; HEIGHT: 26px; BACKGROUND-COLOR: #ffffcc"
							height="26">&nbsp;&nbsp;
							<div id="Action_FirstAudit" style="DISPLAY: inline; LEFT: 0px; TOP: 0px"><A onclick="FirstAudit()" href="#"><%= Application["strTest"]%></A>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div>
							<div id="Action_SecondAudit" style="DISPLAY: inline; LEFT: 0px; TOP: 0px"><A onclick="SecondAudit()" href="#"><%= Application["strTest1"]%></A>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div>
							<div id="Action_ThirdAudit" style="DISPLAY: inline; LEFT: 0px; TOP: 0px"><A onclick="ThirdAudit()" href="#"><%= Application["strTest2"]%></A>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div>
							<div id="Action_Search" style="DISPLAY: inline; LEFT: 0px; TOP: 0px"><A onclick="ShowSearchBar('../Sys/SelectEngine.aspx?ModuleID=101')" href="#">��ѯ</A>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<uc1:storagedropdownlist id="ddlQrySolution" runat="server"></uc1:storagedropdownlist><asp:button id="btnSelect" runat="server" Text="ȷ��" onclick="btnSelect_Click"></asp:button></div>
							<asp:textbox id="tb_SelectedArray" runat="server" Width="0px"></asp:textbox>
							<asp:button id="btnSearch" runat="server" Width="0px" Text="��ѯ" onclick="btnSearch_Click"></asp:button>
							<asp:textbox id="txtSQL" runat="server" Width="0px"></asp:textbox>
							<asp:button id="btnResetDS" runat="server" Width="0px"></asp:button></TD>
					<tr>
						<td></td>
					</tr>
					<TR>
						<TD><mzh:mzhdatagrid id="DataGrid1" runat="server" Width="100%" HighLightColor="Gold" SelectedColor="Blue"
								IdCell="0" SelectType="MultiSelect" AllowSorting="True" AllowPaging="True" PageSize="20" CssClass="datagrid"
								AutoGenerateColumns="False" BorderColor="#0099CC" CellSpacing="1" BorderWidth="1px" CellPadding="3"
								name="MzhMultiSelectDataGrid">
								<PagerStyle HorizontalAlign="Right" Mode="NumericPages"></PagerStyle>
								<AlternatingItemStyle BackColor="#D8F4FF"></AlternatingItemStyle>
								<ItemStyle BackColor="#F2F8FF"></ItemStyle>
								<HeaderStyle HorizontalAlign="Center" BackColor="#99CCFF"></HeaderStyle>
								<Columns>
									<asp:BoundColumn Visible="False" DataField="PKID" SortExpression="PKID" HeaderText="PKID"></asp:BoundColumn>
									<asp:BoundColumn DataField="EntryCode" SortExpression="EntryCode" HeaderText="���"></asp:BoundColumn>
									<asp:BoundColumn DataField="DocName" SortExpression="DocName" HeaderText="��������"></asp:BoundColumn>
									<asp:BoundColumn DataField="EntryStateName" SortExpression="EntryStateName" HeaderText="״̬"></asp:BoundColumn>
									<asp:BoundColumn DataField="EntryDate" SortExpression="EntryDate" HeaderText="����" DataFormatString="{0:d}">
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="AuthorName" SortExpression="AuthorName" HeaderText="�Ƶ���">
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="AuthorDeptName" SortExpression="AuthorDeptName" HeaderText="����"></asp:BoundColumn>
									<asp:BoundColumn DataField="Assessor1" SortExpression="Assessor1" HeaderText="����"></asp:BoundColumn>
									<asp:BoundColumn DataField="Assessor2" SortExpression="Assessor2" HeaderText="����"></asp:BoundColumn>
									<asp:BoundColumn DataField="Assessor3" SortExpression="Assessor3" HeaderText="����"></asp:BoundColumn>
									<asp:BoundColumn DataField="SubTotal" SortExpression="SubTotal" HeaderText="���">
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
								</Columns>
							</mzh:mzhdatagrid></TD>
					</TR>
					<tr>
						<td></td>
					</tr>
					<tr>
						<td></td>
					</tr>
				</TBODY>
			</TABLE>
			<SCRIPT language="javascript">
			//��ʾȷ����ť
			ShowbtnSelect()
			function ShowbtnSelect()
			{
				if(document.getElementById("ddlQrySolution_thisDDL")==null)
					{
						document.getElementById("btnSelect").style.visibility = "hidden";
					}
	
			}
			//���������ťʱ������ѯ�ַ������������ı���
			function SetSQL(sql)
			{
				document.getElementById("txtSQL").value = sql;
				document.forms[0].btnSearch.click();
			}
			//�����������󣬸���DropDownList������Դ
			function ResetDS()
			{
				document.forms[0].btnResetDS.click();
			}
			//һ������		
			function FirstAudit()
			{
				if(<%=DataGrid1.ClientID%>_obj.getSelectedID()!=null&&<%=DataGrid1.ClientID%>_obj.getSelectedID()!="")
				{
					if (<%=DataGrid1.ClientID%>_obj.getSelectedID()!=-1)
					{
						var PKID;
						var EntryNo;
						var DocCode;
						PKID = <%=DataGrid1.ClientID%>_obj.getSelectedID();
						EntryNo = PKID.split('|')[0];
						DocCode = PKID.split('|')[1];
						//alert(DocCode);
						//alert(EntryNo);
						switch (DocCode)
						{
							case "1":
								alert(DocCode);
								document.location="ROSInput.aspx?Op=FirstAudit&EntryNo="+EntryNo;
								break;
							case "5":
								document.location="PPInput.aspx?Op=FirstAudit&EntryNo="+EntryNo;
								break;
							case "7":
								document.location="PRTVInput.aspx?Op=FirstAudit&EntryNo="+EntryNo;
								break;
							case "16":
								document.location="../Storage/WTOWInput.aspx?Op=FirstAudit&EntryNo="+EntryNo;
								break;
						}
					}
				}
				else
				{
					alert("����ѡ��ĳһ����¼���ٽ���һ��������");
				}
			}
			//��������
			function SecondAudit()
			{
				if(<%=DataGrid1.ClientID%>_obj.getSelectedID()!=null&&<%=DataGrid1.ClientID%>_obj.getSelectedID()!="")
				{
					if (<%=DataGrid1.ClientID%>_obj.getSelectedID()!=-1)
					{
						if (<%=DataGrid1.ClientID%>_obj.getSelectedID()!=-1)
					{
						var PKID;
						var EntryNo;
						var DocCode;
						PKID = <%=DataGrid1.ClientID%>_obj.getSelectedID();
						EntryNo = PKID.split('|')[0];
						DocCode = PKID.split('|')[1];
						switch (DocCode)
						{
							case "1":
								document.location="ROSInput.aspx?Op=SecondAudit&EntryNo="+EntryNo;
								break;
							case "5":
								document.location="PPInput.aspx?Op=SecondAudit&EntryNo="+EntryNo;
								break;
							case "7":
								document.location="PRTVInput.aspx?Op=SecondAudit&EntryNo="+EntryNo;
								break;
							case "16":
								document.location="../Storage/WTOWInput.aspx?Op=SecondAudit&EntryNo="+EntryNo;
								break;
						}
					}
					}
				}
				else
				{
					alert("����ѡ��ĳһ����¼���ٽ��ж���������");
				}
			}
			//��������
			function ThirdAudit()
			{
				if(<%=DataGrid1.ClientID%>_obj.getSelectedID()!=null&&<%=DataGrid1.ClientID%>_obj.getSelectedID()!="")
				{
					if (<%=DataGrid1.ClientID%>_obj.getSelectedID()!=-1)
					{
						if (<%=DataGrid1.ClientID%>_obj.getSelectedID()!=-1)
					{
						var PKID;
						var EntryNo;
						var DocCode;
						PKID = <%=DataGrid1.ClientID%>_obj.getSelectedID();
						EntryNo = PKID.split('|')[0];
						DocCode = PKID.split('|')[1];
						switch (DocCode)
						{
							case "1":
								document.location="ROSInput.aspx?Op=ThirdAudit&EntryNo="+EntryNo;
								break;
							case "5":
								document.location="PPInput.aspx?Op=ThirdAudit&EntryNo="+EntryNo;
								break;
							case "7":
								document.location="PRTVInput.aspx?Op=ThirdAudit&EntryNo="+EntryNo;
								break;
							case "16":
								document.location="../Storage/WTOWInput.aspx?Op=ThirdAudit&EntryNo="+EntryNo;
								break;
						}
					}
					}
				}
				else
				{
					alert("����ѡ��ĳһ����¼���ٽ�������������");
				}
			}
			ShowAction(document.getElementById("Action_FirstAudit"),"true");
			ShowAction(document.getElementById("Action_SecondAudit"),"true");
			ShowAction(document.getElementById("Action_ThirdAudit"),"true");
			ShowAction(document.getElementById("Action_Search"),"true");
			</SCRIPT>
		</form>
	</body>
</HTML>

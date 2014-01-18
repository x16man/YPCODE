<%@ Control Language="c#" AutoEventWireup="True" CodeBehind="POWebControl.ascx.cs"
	Inherits="MZHMM.WebMM.Modules.POWebControl"  %>
<%@ Register TagPrefix="uc1" TagName="StorageDropdownlistview" Src="StorageDropdownlist.ascx" %>
<table id="Table2" cellspacing="1" cellpadding="1" width="100%" border="0">
	<tr>
		<td width="145px" valign="middle">
			<table id="Table1" cellspacing="0" cellpadding="0" width="100%" border="0" align="center">
				<tr>
					<td>
						<asp:TextBox ID="txtItemCode" runat="server" ToolTip="���ϱ��" ></asp:TextBox>
                        <asp:HiddenField runat="server" ID="hfNewCode"/>
					</td>
					<td width="80px" style="text-align:left;">
						<input width="30px" runat="server" onclick="window.open('../Storage/ItemQuery.aspx','���ϲ�ѯ','toolbar = no,location=no,directories=no,status=no,menubar=no,scrollbars=yes,resizable=yes,copyhistory=no,width =640,height = 440,left='+(window.screen.width - 640)/2+',top='+(window.screen.height - 440)/2+'')" id="btnItem" type="button" value="..."  />
						<input width="44px" onclick="openPOS();"
							type="button" value="����" class="Commonbutton"/>
					</td>
				</tr>
			</table>
		</td>
		<td width="130px">
			<asp:TextBox ID="txtItemName" runat="server" ToolTip="��������" ></asp:TextBox>
		</td>
		<td width="130px">
			<asp:TextBox ID="txtItemSpecial" runat="server" ToolTip="����ͺ�" ></asp:TextBox>
		</td>
		<td width="70px">
			<uc1:StorageDropdownlistview ID="ddlUnit" runat="server" Width="70px"></uc1:StorageDropdownlistview>
		</td>
		<td width="90px">
			<asp:TextBox ID="txtItemPrice" runat="server" ToolTip="����" Width="90px"></asp:TextBox>
		</td>
		<td width="90px">
			<asp:TextBox ID="txtReqNum" runat="server" ToolTip="����" width="90px"></asp:TextBox>
		</td>
		<td style="text-align:right;">
			<asp:Button ID="btnAddItem" TabIndex="50" runat="server" Text="����" OnClick="btnAddItem_Click">
			</asp:Button><asp:Button ID="btnDelItem" TabIndex="40" runat="server" Text="ɾ��" OnClick="btnDelItem_Click">
			</asp:Button>
			<asp:Button ID="btnEditItem" TabIndex="40" runat="server" Text="�༭" OnClick="btnEditItem_Click">
			</asp:Button>
		</td>
	</tr>
	<tr>
		<td valign="top" colspan="7" height="140">
			<mzh:MzhDataGrid ID="DGModel_Items1" runat="server" IdCell="0" MultiPageShowMode="DropListMode"
				AllowPaging="false" AllowSorting="false" ShowFooter="false" selecttype="SingleSelect"
				name="MzhMultiSelectDataGrid" AutoGenerateColumns="False" OnItemDataBound="DGModel_Items1_ItemDataBound">
				<Columns>
					<asp:BoundColumn DataField="ItemCode" SortExpression="ItemCode" HeaderText="���ϱ��">
					</asp:BoundColumn>
					<asp:BoundColumn DataField="NewCode" SortExpression="NewCode" HeaderText="�±��">
					</asp:BoundColumn>
                    <asp:BoundColumn DataField="ItemName" SortExpression="ItemName" HeaderText="��������">
						<ItemStyle HorizontalAlign="Left" />
					</asp:BoundColumn>
					<asp:BoundColumn DataField="ItemSpecial" SortExpression="ItemSpecial" HeaderText="����ͺ�">
						<ItemStyle HorizontalAlign="Left" />
					</asp:BoundColumn>
					<asp:BoundColumn DataField="ItemUnitName" SortExpression="ItemUnitName" HeaderText="��λ">
						<ItemStyle CssClass="center" />
					</asp:BoundColumn>
					<asp:BoundColumn DataField="ItemNum" SortExpression="ItemNum" HeaderText="����">
						<ItemStyle CssClass="right" HorizontalAlign="Right" />
					</asp:BoundColumn>
					<asp:BoundColumn DataField="ItemPrice" SortExpression="ItemPrice" HeaderText="���ϵ���">
						<ItemStyle CssClass="right" HorizontalAlign="Right" />
					</asp:BoundColumn>
					<asp:BoundColumn DataField="ItemMoney" SortExpression="ItemMoney" HeaderText="���">
						 <ItemStyle CssClass="right" HorizontalAlign="Right" />
					</asp:BoundColumn>
					<asp:BoundColumn DataField="Proposer" SortExpression="Proposer" HeaderText="������">
						<ItemStyle CssClass="center" />
					</asp:BoundColumn>
					<asp:BoundColumn Visible="false" DataField="ItemLackNum" SortExpression="ItemLackNum"
						HeaderText="ItemLackNum">
						<ItemStyle HorizontalAlign="Right"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn HeaderText="SourceDocCode" Visible="false" DataField="SourceDocCode"></asp:BoundColumn>
					<asp:BoundColumn HeaderText="SourceEntry" Visible="false" DataField="SourceEntry"></asp:BoundColumn>
					<asp:BoundColumn HeaderText="SourceSerialNo" Visible = "false" DataField="SourceSerialNo"></asp:BoundColumn>
					<asp:BoundColumn HeaderText="��;����"></asp:BoundColumn>
				</Columns>
			</mzh:MzhDataGrid>
		</td>
	</tr>
	<tr>
		<td colspan="10" align="left">
			��ע<asp:TextBox ID="txtRemark" runat="server" Width="100%" MaxLength="100"
				TextMode="MultiLine" SkinID="PurposeTable"></asp:TextBox>
		</td>
	</tr>
</table>
<div class="hidden">
	<asp:HiddenField ID="txtPKID" runat="server" />
	<asp:Button ID="btnForItemCode" runat="server" Text="Button" 
		OnClick="btnForItemCode_Click"></asp:Button>
		<asp:Button ID="btnForPOSData" runat="server"  Text="Button" 
		OnClick="btnForPOSData_Click"></asp:Button>
</div>

<script type="text/javascript">
	function openPOS()
	{
		var url = '../Purchase/POSBrowser.aspx?Op=View';
		var prvCode = GetPrvCode();
		if(prvCode!=null && prvCode!='')
			url = url+'&PrvCode='+prvCode;
			
		var title='�ɹ�����������Դ';
		var width=850;
		var height=500;
		var left=(window.screen.width - width)/2;
		var top = (window.screen.height - height)/2;
		var state ='toolbar = no,location=no,directories=no,status=no,menubar=no,scrollbars=yes,resizable=yes,copyhistory=no,width ='+width+',height = '+height+',left='+left+',top='+top+'';
		window.open(url,title,state);
	}
	function setPOSData(id)
	{
		document.getElementById("<%=txtPKID.ClientID%>").value=id;
		document.getElementById("<%=btnForPOSData.ClientID%>").click();
	}
	function setCode(id)
	{
		document.getElementById("<%=txtItemCode.ClientID%>").value=id;
		document.getElementById("<%=btnForItemCode.ClientID%>").click();
	}
	$("#<%=btnEditItem.ClientID%>").click(function(){
		if(<%=DGModel_Items1.ClientID%>_obj.getSelectedID()==null || <%=DGModel_Items1.ClientID%>_obj.getSelectedID()=="")
		{
			alert("����ѡ��ĳһ����¼���ٽ��б༭��");
			return false;
		}
	});
	$("#<%=btnDelItem.ClientID%>").click(function(){
		if(<%=DGModel_Items1.ClientID%>_obj.getSelectedID()!=null && <%=DGModel_Items1.ClientID%>_obj.getSelectedID()!="")
		{
			if(!confirm("���ɾ����?"))
			{
				return false;
			}
		}
		else
		{
			alert("����ѡ��ĳһ����¼���ٽ���ɾ����");
			return false;
		}
	});
</script>

<asp:HiddenField ID="txtItemSerial" runat="server" Value="-1" />

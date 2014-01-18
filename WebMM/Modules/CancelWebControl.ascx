<%@ Control Language="c#" AutoEventWireup="True" CodeBehind="CancelWebControl.ascx.cs"
	Inherits="MZHMM.WebMM.Modules.CancelWebControl"  %>
<%@ Register TagPrefix="uc1" TagName="StorageDropdownlistview" Src="StorageDropdownlist.ascx" %>
<table id="Table2" cellspacing="1" cellpadding="1" width="100%" border="0">
	<tr>
		<td width="120px" valign="middle">
			<table id="Table1" cellspacing="0" cellpadding="0" width="100%" border="0" align="center">
				<tr>
					<td >
						<asp:TextBox ID="txtItemCode"  runat="server" ToolTip="物料编号" width="100%"></asp:TextBox>
					</td>
					<td width="40px" style="text-align:right;">
						<input width="100%" onclick="openPOS();"
							type="button"  value="新增" />
					</td>
				</tr>
			</table>
		</td>
		<td width="0">
			<asp:HiddenField ID="txtPKID" runat="server" />
		</td>
		<td width="130px">
			<asp:TextBox ID="txtItemName" Width="130px" runat="server"  ToolTip="物料名称"></asp:TextBox>
		</td>
		<td width="120px">
			<asp:TextBox ID="txtItemSpecial" Width="120px" runat="server"  ToolTip="规格型号"></asp:TextBox>
		</td>
		<td width="80px">
			<uc1:StorageDropdownlistview  Width="80px" ID="ddlUnit" runat="server"></uc1:StorageDropdownlistview>
		</td>
		<td width="80px">
			<asp:TextBox ID="txtItemPrice" Width="80px" runat="server"  ToolTip="单价"></asp:TextBox>
		</td>
		<td width="80px">
			<asp:TextBox ID="txtReqNum" runat="server" Width="80px"  ToolTip="数量"></asp:TextBox>
		</td>
		<td style="text-align:right;">
			<asp:Button ID="btnAddItem" TabIndex="50" runat="server" Text="更新" 
				onclick="btnAddItem_Click"></asp:Button><asp:Button
				ID="btnDelItem" TabIndex="40" runat="server" Text="删除" 
				onclick="btnDelItem_Click" OnClientClick="delete1()"></asp:Button>
			<asp:Button ID="btnEditItem"
					TabIndex="40" runat="server" Text="编辑" onclick="btnEditItem_Click" OnClientClick="edit()"></asp:Button>
		</td>
	</tr>
	<tr>
		<td valign="top" colspan="8" height="160">
			<mzh:MzhDataGrid ID="DGModel_Items1" runat="server" IdCell="0" MultiPageShowMode="DropListMode"
				AllowPaging="false" AllowSorting="false" ShowFooter="false" selecttype="SingleSelect"
				name="MzhMultiSelectDataGrid" AutoGenerateColumns="False" 
				onitemdatabound="DGModel_Items1_ItemDataBound">
				<Columns>
					<asp:BoundColumn DataField="ItemCode" SortExpression="ItemCode" HeaderText="物料编号">
					</asp:BoundColumn>
					<asp:BoundColumn DataField="ItemName" SortExpression="ItemName" HeaderText="物料名称">
						<ItemStyle HorizontalAlign="Left" />
					</asp:BoundColumn>
					<asp:BoundColumn DataField="ItemSpecial" SortExpression="ItemSpecial" HeaderText="规格型号">
						 <ItemStyle HorizontalAlign="Left" />
					</asp:BoundColumn>
					<asp:BoundColumn Visible="false" DataField="ItemUnit" SortExpression="ItemUnit" HeaderText="计量单位">
					</asp:BoundColumn>
					<asp:BoundColumn DataField="ItemUnitName" SortExpression="ItemUnitName" HeaderText="计量单位">
					</asp:BoundColumn>
				   
					<asp:BoundColumn DataField="ItemPrice" SortExpression="ItemPrice" HeaderText="单价">
						<ItemStyle HorizontalAlign="Right"></ItemStyle>
					</asp:BoundColumn>
					 <asp:BoundColumn DataField="ItemNum" SortExpression="ItemNum" HeaderText="申购数"></asp:BoundColumn>
					<asp:BoundColumn DataField="ItemMoney" SortExpression="ItemMoney" HeaderText="金额">
						<ItemStyle HorizontalAlign="Right"></ItemStyle>
					</asp:BoundColumn>
				</Columns>
			</mzh:MzhDataGrid>
		</td>
	</tr>
	<tr>
		<td colspan="10" align="left">
			撤销原因：<asp:TextBox ID="txtRemark" runat="server" 
				MaxLength="100" TextMode="MultiLine" Rows="3" Width="99%"></asp:TextBox>
		</td>
	</tr>
</table>
 
<div class="hidden">
   <asp:Button ID="btnForItemCode" runat="server" Text="Button" Height="0" 
	OnClick="btnForItemCode_Click">
	</asp:Button><asp:Button ID="btnForPOSData" runat="server"  Text="Button" 
		OnClick="btnForPOSData_Click"></asp:Button>
</div>

<script type="text/javascript">
	function openPOS()
	{
		var url = '../Purchase/POSBrowser.aspx?Op=View';
		//var prvCode = GetPrvCode();
		//if(prvCode!=null && prvCode!='')
		//    url = url+'&PrvCode='+prvCode;
			
		var title='采购订单数据来源';
		var width=900;
		var height=500;
		var left=(window.screen.width - width)/2;
		var top = (window.screen.height - height)/2;
		var state ='toolbar = no,location=no,directories=no,status=no,menubar=no,scrollbars=yes,resizable=yes,copyhistory=no,width ='+width+',height = '+height+',left='+left+',top='+top+'';
		window.open(url,title,state);
	}
	function setCode(id) {
		document.getElementById("<%=txtPKID.ClientID%>").value = id;
		document.getElementById("<%=btnForItemCode.ClientID%>").click();
	}
	
	function delete1(){
		if(<%=DGModel_Items1.ClientID%>_obj.getSelectedID()!=null&&<%=DGModel_Items1.ClientID%>_obj.getSelectedID()!="")
		{
			if(!confirm("真的删除吗?"))
			{
				return false;
			}
		}
		else
		{
			alert("请先选中某一条记录，再进行删除！");
			return false;
		}
	}
	
	function edit()
	{
		if(<%=DGModel_Items1.ClientID%>_obj.getSelectedID()!=null&&<%=DGModel_Items1.ClientID%>_obj.getSelectedID()!="")
		{
			
		}
		else
		{
			alert("请先选中某一条记录，再进行编辑！");
			return false;
		}
	}
	function setPOSData(id)
	{
		document.getElementById("<%=txtPKID.ClientID%>").value=id;
		document.getElementById("<%=btnForPOSData.ClientID%>").click();
	}
</script>

<asp:HiddenField ID="txtItemSerial" runat="server" Value="-1" />

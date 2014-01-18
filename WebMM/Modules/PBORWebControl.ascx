<%@ Control Language="c#" AutoEventWireup="True" CodeBehind="PBORWebControl.ascx.cs"
	Inherits="MZHMM.WebMM.Modules.PBORWebControl" %>
<%@ Register TagPrefix="uc1" TagName="StorageDropdownlistview" Src="StorageDropdownlist.ascx" %>
<table id="Table2" cellspacing="1" cellpadding="1" width="100%" border="0">
	<tr>
		<td valign="middle" width="110px">
			<table id="Table1" cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
				<tr>
					<td>
						<asp:TextBox ID="txtItemCode" ToolTip="���ϱ��"  runat="server"></asp:TextBox>
                        <asp:HiddenField runat="server" ID="hfNewCode"/>
					</td>
					<td width="30px">
						<input <%=IsBorItemLimitString%> onclick="window.open('../Storage/ItemQuery.aspx','���ϲ�ѯ','toolbar = no,location=no,directories=no,status=no,menubar=no,scrollbars=yes,resizable=no,copyhistory=no,width =640,height = 440,left='+(window.screen.width - 640)/2+',top='+(window.screen.height - 440)/2+'')"
							type="button" value="..." class="Commonbutton" />
					</td>
				</tr>
			</table>
		</td>
		<td width="100px">
			<asp:TextBox ID="txtItemName" ToolTip="��������"  runat="server"></asp:TextBox>
		</td>
		<td width="100px">
			<asp:TextBox ID="txtItemSpecial" ToolTip="����ͺ�"  runat="server"></asp:TextBox>
		</td>
		<td width="70px">
			<uc1:StorageDropdownlistview ID="ddlUnit" runat="server"></uc1:StorageDropdownlistview>
		</td>
		<td width="70px">
			<asp:TextBox ID="txtBatchCode" ToolTip="����"  runat="server"></asp:TextBox>
		</td>
		<td width="80px">
			<asp:TextBox ID="txtItemPrice" ToolTip="����"  runat="server"></asp:TextBox>
		</td>
		<td width="80px">
			<asp:TextBox ID="txtReqNum" ToolTip="Ӧ������" runat="server"></asp:TextBox><asp:TextBox
				ID="txtItemNum" ToolTip="ʵ������"  runat="server"></asp:TextBox>
		</td>
		<td width="110px">
			<uc1:StorageDropdownlistview ID="ddlCon" runat="server"></uc1:StorageDropdownlistview>
		</td>
		<td style="text-align:right;">
			<asp:Button ID="btnAddItem" TabIndex="50" runat="server" Text="����" OnClick="btnAddItem_Click">
			</asp:Button>
			<asp:Button ID="btnDelItem" TabIndex="40" runat="server" Text="ɾ��" OnClick="btnDelItem_Click" >
			</asp:Button>
			<asp:Button ID="btnEditItem" TabIndex="40" runat="server" Text="�༭" OnClick="btnEditItem_Click" >
			</asp:Button>
		</td>
	</tr>
	<tr>
		<td valign="top" colspan="9" height="160">
			<mzh:MzhDataGrid ID="DGModel_Items1" runat="server" IdCell="0" MultiPageShowMode="DropListMode"
				AllowPaging="false" AllowSorting="false" ShowFooter="true" selecttype="SingleSelect"
				name="MzhMultiSelectDataGrid" AutoGenerateColumns="False" 
				onitemdatabound="DGModel_Items1_ItemDataBound">
				<Columns>
					<asp:BoundColumn DataField="ItemCode" SortExpression="ItemCode" HeaderText="���ϱ���">
					</asp:BoundColumn>
					<asp:BoundColumn DataField="NewCode" SortExpression="NewCode" HeaderText="�±���">
					</asp:BoundColumn>
                    <asp:BoundColumn DataField="ItemName" SortExpression="ItemName" HeaderText="��������">
						<ItemStyle HorizontalAlign="Left" />
					</asp:BoundColumn>
					<asp:BoundColumn DataField="ItemSpecial" SortExpression="ItemSpecial" HeaderText="����ͺ�">
						 <ItemStyle HorizontalAlign="Left" />
					</asp:BoundColumn>
					<asp:BoundColumn DataField="ItemUnitName" SortExpression="ItemUnitName" HeaderText="��λ">
					</asp:BoundColumn>
					 <asp:BoundColumn DataField="PlanNum" SortExpression="PlanNum" HeaderText="Ӧ����"  DataFormatString="{0:F2}">
					   <ItemStyle HorizontalAlign="Right"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="BatchCode" SortExpression="BatchCode" HeaderText="����" DataFormatString="{0:F2}">
					   
					</asp:BoundColumn>
					<asp:BoundColumn DataField="ItemPrice" SortExpression="ItemPrice" HeaderText="����" FooterText="�ϼƣ�" DataFormatString="{0:F2}">
					   <ItemStyle HorizontalAlign="Right" CssClass="right"></ItemStyle>
						<FooterStyle HorizontalAlign="Right" Font-Bold="true" />
					</asp:BoundColumn>
				   
					<asp:BoundColumn DataField="ItemNum" SortExpression="ItemNum" HeaderText="ʵ����" >
						<FooterStyle Font-Bold="true" HorizontalAlign="Right" />
					</asp:BoundColumn>
					<asp:BoundColumn DataField="ItemMoney" SortExpression="ItemMoney" HeaderText="���" DataFormatString="{0:F2}">
						<ItemStyle HorizontalAlign="Right"></ItemStyle>
						<FooterStyle HorizontalAlign="Right" Font-Bold="true" />
					</asp:BoundColumn>
					<asp:BoundColumn DataField="ItemSum" SortExpression="ItemSum" HeaderText="�ܽ��" DataFormatString="{0:F2}">
						<ItemStyle HorizontalAlign="Right"></ItemStyle>
						 <FooterStyle HorizontalAlign="Right" Font-Bold="true" />
					</asp:BoundColumn>
					<asp:BoundColumn DataField="ConName" HeaderText="��λ">
					</asp:BoundColumn>
					<asp:BoundColumn DataField="SourceEntry" Visible="false"  HeaderText="SourceEntry"></asp:BoundColumn>
					<asp:BoundColumn DataField = "SourceSerialNo" Visible="false" HeaderText="SourceSerialNo"></asp:BoundColumn>
					<asp:BoundColumn HeaderText="��;����"></asp:BoundColumn>
				</Columns>
			</mzh:MzhDataGrid>
		</td>
	</tr>
	<tr>
		<td>
			�������ã�
		</td>
		<td colspan="9" align="left">
			<asp:TextBox ID="txtFee" runat="server" AutoPostBack="true"  SkinID="PurposeDisTable" 
				ontextchanged="txtFee_TextChanged"></asp:TextBox><font face="����">(Ԫ)</font>
		</td>
	</tr>
	<tr>
		<td>
			��ע��
		</td>
		<td colspan="9">
			<asp:TextBox ID="txtRemark" Width="100%" SkinID="PurposeTable" runat="server" TextMode="MultiLine" MaxLength="100"></asp:TextBox>
		</td>
	</tr>
</table>
<div class="hidden">
	<asp:Button ID="btnForItemCode" Width="0px" runat="server" Text="Button" Height="0"
		OnClick="btnForItemCode_Click"></asp:Button>
	<asp:Button ID="bntForEntryNo" runat="server" Width="0px" Text="Button" Height="0"
		OnClick="bntForEntryNo_Click"></asp:Button>
	<asp:HiddenField ID="txtEntryNo" runat="server" />
</div>

<script type="text/javascript">
	$("#<%=txtItemCode.ClientID%>").blur(function(){
		if(this.value!="")
			$("#<%=btnForItemCode.ClientID%>").click();
	});
	
	$("#<%=txtItemCode.ClientID%>").keypress(function(e){
		if(e.keyCode==13)
		{
			$("#<%=btnForItemCode.ClientID%>").click();
			return false;
		}	        
	});
	$("#<%=btnDelItem.ClientID %>").click(function(){
		if(<%=DGModel_Items1.ClientID%>_obj.getSelectedID()!=null&&<%=DGModel_Items1.ClientID%>_obj.getSelectedID()!="")
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
	$("#<%=btnEditItem.ClientID %>").click(function(){
		if(<%=DGModel_Items1.ClientID%>_obj.getSelectedID()!=null&&<%=DGModel_Items1.ClientID%>_obj.getSelectedID()!="")
		{
			
		}
		else
		{
			alert("����ѡ��ĳһ����¼���ٽ��б༭��");
			return false;
		}
	});
	
	function setCode(id)
	{
		document.getElementById("<%=txtItemCode.ClientID%>").value=id;
		document.getElementById("<%=btnForItemCode.ClientID%>").click();
	}
	function setEntry(id)
	{
		document.getElementById("<%=txtEntryNo.ClientID%>").value=id;
		document.getElementById("<%=bntForEntryNo.ClientID%>").click();
	}

	
</script>

<asp:HiddenField ID="txtItemSerial" runat="server" Value="-1" />
<asp:HiddenField ID="txtStoCode" runat="server" />

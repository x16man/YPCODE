<%@ Control Language="c#" AutoEventWireup="True" CodeBehind="PRTVWebControl.ascx.cs"
    Inherits="MZHMM.WebMM.Modules.PRTVWebControl" %>
<%@ Register TagPrefix="uc1" TagName="StorageDropdownlistview" Src="StorageDropdownlist.ascx" %>
<table id="Table2" cellspacing="1" cellpadding="1" width="100%" border="0">
    <tr>
        <td valign="middle" width="110px">
            <table id="Table1" cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
                <tr>
                    <td>
                        <asp:TextBox ID="txtItemCode" runat="server" ></asp:TextBox>
                    </td>
                </tr>
            </table>
        </td>
        <td width="100">
            <asp:TextBox ID="txtItemName" runat="server" ></asp:TextBox>
        </td>
        <td width="150">
            <asp:TextBox ID="txtItemSpecial" runat="server" ></asp:TextBox>
        </td>
        <td width="110">
            <uc1:StorageDropdownlistview ID="ddlUnit" runat="server"></uc1:StorageDropdownlistview>
        </td>
        <td width="60">
            <asp:TextBox ID="txtBatchCode" runat="server" ></asp:TextBox>
        </td>
        <td width="60">
            <asp:TextBox ID="txtItemPrice" runat="server" ></asp:TextBox>
        </td>
        <td width="50">
            <asp:TextBox ID="txtReqNum" runat="server" ></asp:TextBox>
        </td>
        <td width="100">
            <asp:TextBox ID="txtTaxRate" runat="server" ></asp:TextBox>
            <asp:TextBox ID="txtItemNum" runat="server" ></asp:TextBox>
             <uc1:StorageDropdownlistview ID="ddlCon" runat="server" ></uc1:StorageDropdownlistview>
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
        <td valign="top" colspan="10" height="150">
            <mzh:MzhDataGrid ID="DGModel_Items1" runat="server" IdCell="0" MultiPageShowMode="DropListMode"
                AllowPaging="false" AllowSorting="false" ShowFooter="true" selecttype="SingleSelect"
                name="MzhMultiSelectDataGrid" AutoGenerateColumns="False" 
                onitemdatabound="DGModel_Items1_ItemDataBound">
                <Columns>
                    <asp:BoundColumn DataField="ItemCode" SortExpression="ItemCode" HeaderText="���ϱ���">
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="ItemName" SortExpression="ItemName" HeaderText="��������">
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="ItemSpecial" SortExpression="ItemSpecial" HeaderText="����ͺ�">
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="ItemUnitName" SortExpression="ItemUnitName" HeaderText="��λ">
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="BatchCode" SortExpression="BatchCode" HeaderText="����">
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="ItemPrice" SortExpression="ItemPrice" HeaderText="����">
                        <ItemStyle CssClass="right" HorizontalAlign="Right" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="PlanNum" SortExpression="PlanNum" HeaderText="Ӧ����"></asp:BoundColumn>
                    <asp:BoundColumn DataField="ItemNum" SortExpression="ItemNum" HeaderText="ʵ����" FooterText="�ϼƣ�">
                        <ItemStyle HorizontalAlign="Right"></ItemStyle>
                        <FooterStyle Font-Bold="true" HorizontalAlign="Right" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="ItemMoney" SortExpression="ItemMoney" HeaderText="���">
                        <ItemStyle HorizontalAlign="Right"></ItemStyle>
                        <FooterStyle Font-Bold="true" HorizontalAlign="Right" />
                    </asp:BoundColumn>
                    
                </Columns>
            </mzh:MzhDataGrid>
        </td>
    </tr>
    <tr>
        <td colspan="9">��ע <span class="required">*</span>
            <asp:TextBox ID="txtRemark" runat="server" Width="100%" MaxLength="100" TextMode="MultiLine"></asp:TextBox>
        </td>
    </tr>
</table>
<div class="hidden">
 <asp:Button ID="btnForItemCode" runat="server" Width="100px" Text="Button" Height="0"
                OnClick="btnForItemCode_Click"></asp:Button>
                 <asp:HiddenField ID="txtEntryNo" runat="server" />
                  <asp:Button ID="bntForEntryNo" runat="server" Width="100px" Text="Button" Height="0"
                OnClick="bntForEntryNo_Click"></asp:Button>
</div>
           
<script language="javascript" type="text/javascript">
	$('#<%=btnDelItem.ClientID%>').click(function(){
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
	$('#<%=btnEditItem.ClientID%>').click(function(){
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

<asp:HiddenField ID="txtItemSerial" runat="server" />

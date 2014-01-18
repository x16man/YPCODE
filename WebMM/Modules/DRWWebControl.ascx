<%@ Control Language="c#" AutoEventWireup="True" CodeBehind="DRWWebControl.ascx.cs"
    Inherits="MZHMM.WebMM.Modules.DRWWebControl" %>
<%@ Register TagPrefix="uc1" TagName="USWebControlview" Src="USWebControl.ascx" %>
<%@ Register TagPrefix="uc1" TagName="StorageDropdownlistview" Src="StorageDropdownlist.ascx" %>
<table style="width: 100%;">
    <tr>
        <td width="10%"">
            ��;��<span class="required">*</span>
        </td>
        <td width="40%">
            <uc1:USWebControlview ID="USPurpose" runat="server"></uc1:USWebControlview>
        </td>
        <td width="10%">
            �ֿ⣺<span class="required">*</span>
        </td>
        <td width="40%">
            <uc1:StorageDropdownlistview ID="ddlStorage" runat="server" Width="100%"></uc1:StorageDropdownlistview>
        </td>
    </tr>
    <tr>
        <td colspan="4">
            <table width="100%">
                <tr>
                    <td valign="middle" width="120px">
                        <table id="Table1" cellspacing="0" cellpadding="0" width="100%" border="0">
                            <tr>
                                <td>
                                    <asp:TextBox ID="txtItemCode" runat="server" ToolTip="���ϱ��" MaxLength="20"></asp:TextBox>
                                    <asp:HiddenField runat="server" ID="hfNewCode"/>
                                </td>
                                <td width="30px">
                                    <input id="btnWWBrowser" onclick="window.open('../Storage/ItemQuery.aspx','���ϲ�ѯ','toolbar = no,location=no,directories=no,status=no,menubar=no,scrollbars=yes,resizable=no,copyhistory=no,width =640,height = 440,left='+(window.screen.width - 640)/2+',top='+(window.screen.height - 440)/2+'')"
                                        type="button" value="..." class="Commonbutton" name="btnWWBrowser" runat="server"
                                        width="100%" />
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td width="100px">
                        <asp:TextBox ID="txtItemName" runat="server" ToolTip="��������"></asp:TextBox>
                    </td>
                    <td width="100px">
                        <asp:TextBox ID="txtItemSpecial" runat="server" ToolTip="����ͺ�"></asp:TextBox>
                    </td>
                    <td width="70px">
                        <uc1:StorageDropdownlistview ID="ddlUnit" runat="server" Width="100%"></uc1:StorageDropdownlistview>
                    </td>
                    <td width="80px">
                        <asp:TextBox ID="txtItemPrice" runat="server" ToolTip="����"></asp:TextBox>
                    </td>
                    <td width="80px">
                        <asp:TextBox ID="txtReqNum" runat="server" ToolTip="Ӧ������" ></asp:TextBox>
                    </td>
                    <td width="80px">
                        <asp:TextBox ID="txtItemNum" runat="server" ToolTip="ʵ������" ></asp:TextBox>
                    </td>
                    <td align="right">
                        <asp:Button ID="btnAddItem" TabIndex="50" runat="server" Text="����" OnClick="btnAddItem_Click1">
                        </asp:Button><asp:Button ID="btnDelItem" TabIndex="40" runat="server" Text="ɾ��" OnClick="btnDelItem_Click">
                        </asp:Button><asp:Button ID="btnEditItem" TabIndex="40" runat="server" Text="�༭" OnClick="btnEditItem_Click">
                        </asp:Button>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td colspan="4" height="160px" valign="top">
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
                    <asp:BoundColumn DataField="ItemUnitName" SortExpression="ItemUnitName" HeaderText="������λ">
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="StockNum" SortExpression="StockNum" HeaderText="��ǰ�����">
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="PlanNum" SortExpression="PlanNum" HeaderText="������"></asp:BoundColumn>
                    <asp:BoundColumn DataField="ItemNum" SortExpression="ItemNum" HeaderText="ʵ����"></asp:BoundColumn>
                    <asp:BoundColumn DataField="ItemPrice" SortExpression="ItemPrice" HeaderText="����">
                        <ItemStyle HorizontalAlign="Right"></ItemStyle>
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="ItemMoney" SortExpression="ItemMoney" HeaderText="�ܼ�">
                        <ItemStyle HorizontalAlign="Right"></ItemStyle>
                    </asp:BoundColumn>
                </Columns>
            </mzh:MzhDataGrid>
        </td>
    </tr>
    <tr>
        <td colspan="4">
            ��ע��<asp:TextBox ID="txtRemark" runat="server" SkinID="PurposeDisTable" MaxLength="100"
                TextMode="MultiLine" Style="width: 100%"></asp:TextBox>
        </td>
    </tr>
</table>
<div class="hidden">
    <asp:HiddenField ID="txtPKIDs" runat="server" />
    <asp:Button ID="btnForPKID" runat="server" Text="Button" Height="0" OnClick="btnForPKID_Click">
    </asp:Button>
    <asp:Button ID="btnForItemCode" runat="server" Text="Button" Height="0" OnClick="btnForItemCode_Click">
    </asp:Button>
    <asp:HiddenField ID="txtItemSerial" runat="server" Value="-1" />
    <asp:HiddenField ID="txtStoCode" runat="server" />
</div>

<script language="javascript" type="text/javascript">
    $('#<%=txtItemCode.ClientID%>').blur(function(){
        if(document.getElementById("<%=txtItemCode.ClientID%>").value!="")
		{
			document.getElementById("<%=btnForItemCode.ClientID%>").click();
		}
    });
	$('#<%=btnForItemCode.ClientID%>').keypress(function(){
	    if(event.keyCode==13)
		{
			document.getElementById("<%=btnForItemCode.ClientID%>").click();
			return false;
		}
	});
	
	function setCode(id)
	{
		document.getElementById("<%=txtItemCode.ClientID%>").value=id;
		document.getElementById("<%=btnForItemCode.ClientID%>").click();
	}
	//���ݴ����Դ���ݺ����������ݡ�
	function SetEntry(id)
	{
		document.getElementById("<%=txtPKIDs.ClientID%>").value=id;
		document.getElementById("<%=btnForPKID.ClientID%>").click();
	}
	
	//�༭��
	$('#<%= btnEditItem.ClientID%>').click(function(){
	    if(<%=DGModel_Items1.ClientID%>_obj.getSelectedID()!=null&&<%=DGModel_Items1.ClientID%>_obj.getSelectedID()!="")
	    {
		    
		}
		else
		{
			alert("����ѡ��ĳһ����¼���ٽ��б༭��");
			return false;
		}
	});
	
	//ɾ����
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
	
	
</script>


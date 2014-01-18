<%@ Control Language="c#" AutoEventWireup="True" CodeBehind="WTOWWebControl.ascx.cs"
    Inherits="MZHMM.WebMM.Modules.WTOWWebControl" %>
<%@ Register TagPrefix="uc1" TagName="StorageDropdownlistview" Src="StorageDropdownlist.ascx" %>
<table id="Table2" cellspacing="1" cellpadding="1" width="100%" border="0">
    <tr>
        <td valign="middle" width="150">
            <table id="Table1" cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
                <tr>
                    <td>
                        <asp:TextBox ID="txtItemCode" runat="server" ToolTip="���ϱ��"></asp:TextBox>
                    </td>
                    <td width="30px">
                        <input id="btnWWBrowser" onclick="window.open('../Storage/ItemQuery.aspx','���ϲ�ѯ','toolbar = no,location=no,directories=no,status=no,menubar=no,scrollbars=yes,resizable=no,copyhistory=no,width =640,height = 440,left='+(window.screen.width - 640)/2+',top='+(window.screen.height - 440)/2+'')"
                            type="button" value="..." name="btnWWBrowser" class="Commonbutton" runat="server" width="100%" />
                    </td>
                </tr>
            </table>
        </td>
        <td width="100px">
            <asp:TextBox ID="txtItemName" runat="server"  ToolTip="��������"></asp:TextBox>
        </td>
        <td width="100px">
            <asp:TextBox ID="txtItemSpecial" runat="server"  ToolTip="����ͺ�"></asp:TextBox>
        </td>
        <td width="70px">
            <uc1:StorageDropdownlistview ID="ddlUnit" runat="server"></uc1:StorageDropdownlistview>
        </td>
        <td width="60px">
            <asp:TextBox ID="txtItemPrice" runat="server" ToolTip="����"></asp:TextBox>
        </td>
        <td width="50px">
            <asp:TextBox ID="txtReqNum" runat="server" ToolTip="Ӧ������"></asp:TextBox>
        </td>
        <td width="130px">
            <asp:TextBox ID="txtItemNum" runat="server" ToolTip="ʵ������"></asp:TextBox>
        </td>
        <td style="text-align:right;">
            <asp:Button ID="btnAddItem" TabIndex="50" runat="server" Text="����" 
                onclick="btnAddItem_Click"></asp:Button><asp:Button
                ID="btnDelItem" TabIndex="40" runat="server" Text="ɾ��" 
                onclick="btnDelItem_Click" OnClientClick="funclick()"></asp:Button>
            <asp:Button ID="btnEditItem"
                    TabIndex="40" runat="server" Text="�༭" onclick="btnEditItem_Click"></asp:Button>
        </td>
    </tr>
    <tr>
        <td valign="top" colspan="8" height="140">
            <mzh:MzhDataGrid ID="DGModel_Items1" runat="server" IdCell="0" MultiPageShowMode="DropListMode"
                AllowPaging="false" AllowSorting="false" ShowFooter="false" selecttype="SingleSelect"
                name="MzhMultiSelectDataGrid" AutoGenerateColumns="False" 
                onitemdatabound="DGModel_Items1_ItemDataBound">
                <Columns>
                    <asp:BoundColumn DataField="ItemCode" SortExpression="ItemCode" HeaderText="���ϱ��">
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
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="ItemMoney" SortExpression="ItemMoney" HeaderText="�ܼ�">
                        <ItemStyle HorizontalAlign="Right"></ItemStyle>
                    </asp:BoundColumn>
                </Columns>
            </mzh:MzhDataGrid>
        </td>
    </tr>
    <tr>
        <td colspan="10">
            ��ע
                <asp:TextBox ID="txtRemark" runat="server" Width="100%" SkinID="PurposeDisTable" TextMode="MultiLine" MaxLength="100"></asp:TextBox>
        </td>
    </tr>
</table>

                
<div class="hidden">
    <asp:Button ID="btnForItemCode" runat="server" Text="Button" 
    Height="0" onclick="btnForItemCode_Click1"></asp:Button>
                <asp:HiddenField ID="txtPKIDs" runat="server" />
                <asp:Button
                    ID="btnForPKID" runat="server" Width="0px" Text="Button" Height="0"></asp:Button>
                
          
</div>

<script language="javascript" type="text/javascript">
    $('#<%=txtItemCode.ClientID%>').blur(function(){
        if(document.getElementById("<%=txtItemCode.ClientID%>").value!="")
	    {
		    document.getElementById("<%=btnForItemCode.ClientID%>").click();
	    }
    });
    $('#<%=txtItemCode.ClientID%>').keypress(function(event){
        if(event.keyCode==13)
		{
			document.getElementById("<%=btnForItemCode.ClientID%>").click();
			return false;
		}
    });
		
    function setCode(id) {
        document.getElementById("<%=txtItemCode.ClientID%>").value = id;
        document.getElementById("<%=btnForItemCode.ClientID%>").click();
    }
    //���ݴ����Դ���ݺ����������ݡ�
    function SetEntry(id) {
        document.getElementById("<%=txtPKIDs.ClientID%>").value = id;
        document.getElementById("<%=btnForPKID.ClientID%>").click();
    }
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
</script>

<asp:HiddenField ID="txtItemSerial" runat="server" Value="-1" />
<asp:HiddenField ID="txtStoCode" runat="server" />

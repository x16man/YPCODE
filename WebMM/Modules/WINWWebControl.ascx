<%@ Control Language="c#" AutoEventWireup="True" CodeBehind="WINWWebControl.ascx.cs"
    Inherits="MZHMM.WebMM.Modules.WINWWebControl" %>
<%@ Register TagPrefix="uc1" TagName="StorageDropdownlistview" Src="StorageDropdownlist.ascx" %>
<table id="Table2" cellspacing="0" cellpadding="0" width="100%" border="0" bordercolor="#acc8f7">
    <tr style="border-right: #acc8f7 1px solid; border-top: #acc8f7 1px solid; border-left: #acc8f7 1px solid;
        border-bottom: #acc8f7 1px solid">
        <td valign="middle" width="120px">
            <table id="Table1" cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
                <tr>
                    <td>
                        <asp:TextBox ID="txtItemCode" ToolTip="���ϱ��"  runat="server"></asp:TextBox>
                    </td>
                    <td width="30px">
                        <input id="btnWWBrowser" onclick="window.open('../Storage/ItemQuery.aspx','���ϲ�ѯ','toolbar = no,location=no,directories=no,status=no,menubar=no,scrollbars=yes,resizable=no,copyhistory=no,width =640,height = 440,left='+(window.screen.width - 640)/2+',top='+(window.screen.height - 440)/2+'')"
                            type="button" value="..." name="btnWWBrowser" class="Commonbutton" runat="server" width="100%" />
                    </td>
                </tr>
            </table>
        </td>
        <td width="150px">
            <asp:TextBox ID="txtItemName" ToolTip="��������"  runat="server"></asp:TextBox>
        </td>
        <td width="150px">
            <asp:TextBox ID="txtItemSpecial" ToolTip="����ͺ�"  runat="server"></asp:TextBox>
        </td>
        <td width="70px">
            <uc1:StorageDropdownlistview ID="ddlUnit" runat="server"></uc1:StorageDropdownlistview>
        </td>
        <td width="60px">
            <asp:TextBox ID="txtItemPrice" ToolTip="����"  runat="server"></asp:TextBox>
        </td>
        <td width="50px">
            <asp:TextBox ID="txtReqNum" ToolTip="Ӧ������"  runat="server"></asp:TextBox>
        </td>
        <td width="130px">
            <asp:TextBox ID="txtItemNum" ToolTip="ʵ������"  runat="server"></asp:TextBox>
        </td>
        <td>
        </td>
        <td style="text-align:right;">
            <asp:Button ID="btnAddItem" TabIndex="0" runat="server" Text="����" OnClick="btnAddItem_Click">
            </asp:Button><asp:Button ID="btnDelItem" TabIndex="0" runat="server" Text="ɾ��" OnClick="btnDelItem_Click">
            </asp:Button><asp:Button ID="btnEditItem" TabIndex="0" runat="server" Text="�༭" OnClick="btnEdit_Click">
            </asp:Button>
        </td>
    </tr>
    <tr>
        <td valign="top" colspan="9">
            
            <mzh:MzhDataGrid ID="DGModel_Items1" runat="server" IdCell="0" MultiPageShowMode="DropListMode"
                AllowPaging="false" AllowSorting="false" ShowFooter="false" selecttype="SingleSelect"
                name="MzhMultiSelectDataGrid" AutoGenerateColumns="False" 
                onitemdatabound="DGModel_Items1_ItemDataBound">
                <Columns>
                    <asp:BoundColumn  DataField="ItemCode" SortExpression="ItemCode" HeaderText="���ϱ��">
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="ItemName" SortExpression="ItemName" HeaderText="��������">
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="ItemSpecial" SortExpression="ItemSpecial" HeaderText="����ͺ�">
                         <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="ItemUnitName" SortExpression="ItemUnitName" HeaderText="������λ"
                        >
                       
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="PlanNum" SortExpression="PlanNum" HeaderText="Ӧ����">
                      
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="ItemNum" SortExpression="ItemNum" HeaderText="ʵ����">
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="ItemPrice" SortExpression="ItemPrice" HeaderText="����">
                        <ItemStyle HorizontalAlign="Right"></ItemStyle>
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="ItemFee" SortExpression="ItemFee" HeaderText="����">
                        <ItemStyle HorizontalAlign="Right"></ItemStyle>
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="ItemSum" SortExpression="ItemSum" HeaderText="�ܼ�">
                        <ItemStyle HorizontalAlign="Right"></ItemStyle>
                    </asp:BoundColumn>
                </Columns>
            </mzh:MzhDataGrid>
        </td>
    </tr>
    <tr>
        <td>
        </td>
        <td>
        </td>
        <td>
        </td>
        <td>
        </td>
        <td>
        </td>
        <td>
        </td>
        <td>
        </td>
        <td align="right">
            ���ã�
        </td>
        <td>
            <asp:TextBox ID="txtTotalFee" runat="server" MaxLength="100" 
                TextMode="SingleLine" AutoPostBack="True" OnTextChanged="txtTotalFee_TextChanged"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td width="40">
            ���ģ�
        </td>
        <td width="80">
            <asp:TextBox ID="txtPSerialNo" ToolTip="PNo."  runat="server"
                ReadOnly="False"></asp:TextBox>
        </td>
        <td width="80">
            <asp:TextBox ID="txtResCode" ToolTip="���ϱ��"  runat="server"
                ReadOnly="True"></asp:TextBox>
        </td>
        <td width="120">
            <asp:TextBox ID="txtResName" ToolTip="��������" runat="server"
                ReadOnly="True"></asp:TextBox>
        </td>
        <td width="120">
            <asp:TextBox ID="txtResSpecial" ToolTip="����ͺ�"  runat="server"
                ReadOnly="True"></asp:TextBox>
        </td>
        <td width="150">
            <uc1:StorageDropdownlistview ID="ddlResUnit" runat="server"></uc1:StorageDropdownlistview>
        </td>
        <td width="80">
            <asp:TextBox ID="txtResPrice" ToolTip="����" runat="server" ReadOnly="True"></asp:TextBox>
        </td>
        <td width="80">
            <asp:TextBox ID="txtResNum" ToolTip="��������" runat="server"></asp:TextBox>
        </td>
        <td style="text-align:right;">
            <asp:Button ID="btnResUpdate" TabIndex="50" runat="server" Text="����" OnClick="btnResUpdate_Click">
            </asp:Button><asp:Button ID="btnresDelete" TabIndex="40" runat="server" Text="ɾ��"
                OnClick="btnresDelete_Click"></asp:Button><asp:Button ID="btnResEdit" TabIndex="40"
                    runat="server" Text="�༭" OnClick="btnResEdit_Click"></asp:Button>
        </td>
    </tr>
    <tr>
        <td valign="top" colspan="9">
            <mzh:MzhDataGrid ID="DGModel_WRES1" runat="server" name="MzhMultiSelectDataGrid"
                AutoGenerateColumns="False" SelectType="SingleSelect" IdCell="0" 
                ShowFooter="True" onitemdatabound="DGModel_WRES1_ItemDataBound">
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
                <Columns>
                    <asp:BoundColumn DataField="PSerialNo" HeaderText="PNo.">
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="ResCode" HeaderText="���">
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="ResName" HeaderText="����">
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="ResSpecial" HeaderText="����ͺ�">
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="ResUnitName" HeaderText="��λ">
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="ResPrice" HeaderText="����"  DataFormatString="{0:0.###}">
                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="ResNum" HeaderText="����" DataFormatString="{0:0.###}">
                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="ResMoney" HeaderText="���"  DataFormatString="{0:0.###}">
                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
                    </asp:BoundColumn>
                </Columns>
            </mzh:MzhDataGrid>
        </td>
    </tr>
    <tr>
        <td colspan="10">��ע��
            <asp:TextBox ID="txtRemark" Width="100%" SkinID="PurposeTable" runat="server" MaxLength="100" TextMode="MultiLine"></asp:TextBox>
        </td>
    </tr>
</table>
<div class="hidden">
    <asp:Button ID="btnForItemCode" Width="0px" runat="server" Text="Button" Height="0"
        OnClick="btnForItemCode_Click"></asp:Button><asp:TextBox ID="txtPKIDs" Width="0px"
            runat="server"></asp:TextBox><asp:Button ID="btnForPKID" Width="0px" runat="server"
                Text="Button" Height="0" OnClick="btnForPKID_Click"></asp:Button>
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
    $('#<%=btnresDelete.ClientID%>').click(function(){
        if(<%=DGModel_WRES1.ClientID%>_obj.getSelectedID()!=null&&<%=DGModel_WRES1.ClientID%>_obj.getSelectedID()!="")
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
    $('#<%=btnResEdit.ClientID%>').click(function(){
        if(<%=DGModel_WRES1.ClientID%>_obj.getSelectedID()!=null&&<%=DGModel_WRES1.ClientID%>_obj.getSelectedID()!="")
	    {
		    // alert(<%=DGModel_WRES1.ClientID%>_obj.getSelectedID());
		     //return false;
		}
		else
		{
			alert("����ѡ��ĳһ����¼���ٽ��б༭��");
			return false;
		}
    });
</script>

<asp:HiddenField ID="txtItemSerial" runat="server" Value="-1" />
<asp:HiddenField ID="txtResSerial" runat="server" Value="-1" />

<%@ Control Language="c#" AutoEventWireup="True" CodeBehind="WTOWWebControl.ascx.cs"
    Inherits="MZHMM.WebMM.Modules.WTOWWebControl" %>
<%@ Register TagPrefix="uc1" TagName="StorageDropdownlistview" Src="StorageDropdownlist.ascx" %>
<table id="Table2" cellspacing="1" cellpadding="1" width="100%" border="0">
    <tr>
        <td valign="middle" width="150">
            <table id="Table1" cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
                <tr>
                    <td>
                        <asp:TextBox ID="txtItemCode" runat="server" ToolTip="物料编号"></asp:TextBox>
                    </td>
                    <td width="30px">
                        <input id="btnWWBrowser" onclick="window.open('../Storage/ItemQuery.aspx','物料查询','toolbar = no,location=no,directories=no,status=no,menubar=no,scrollbars=yes,resizable=no,copyhistory=no,width =640,height = 440,left='+(window.screen.width - 640)/2+',top='+(window.screen.height - 440)/2+'')"
                            type="button" value="..." name="btnWWBrowser" class="Commonbutton" runat="server" width="100%" />
                    </td>
                </tr>
            </table>
        </td>
        <td width="100px">
            <asp:TextBox ID="txtItemName" runat="server"  ToolTip="物料名称"></asp:TextBox>
        </td>
        <td width="100px">
            <asp:TextBox ID="txtItemSpecial" runat="server"  ToolTip="规格型号"></asp:TextBox>
        </td>
        <td width="70px">
            <uc1:StorageDropdownlistview ID="ddlUnit" runat="server"></uc1:StorageDropdownlistview>
        </td>
        <td width="60px">
            <asp:TextBox ID="txtItemPrice" runat="server" ToolTip="单价"></asp:TextBox>
        </td>
        <td width="50px">
            <asp:TextBox ID="txtReqNum" runat="server" ToolTip="应发数量"></asp:TextBox>
        </td>
        <td width="130px">
            <asp:TextBox ID="txtItemNum" runat="server" ToolTip="实发数量"></asp:TextBox>
        </td>
        <td style="text-align:right;">
            <asp:Button ID="btnAddItem" TabIndex="50" runat="server" Text="新增" 
                onclick="btnAddItem_Click"></asp:Button><asp:Button
                ID="btnDelItem" TabIndex="40" runat="server" Text="删除" 
                onclick="btnDelItem_Click" OnClientClick="funclick()"></asp:Button>
            <asp:Button ID="btnEditItem"
                    TabIndex="40" runat="server" Text="编辑" onclick="btnEditItem_Click"></asp:Button>
        </td>
    </tr>
    <tr>
        <td valign="top" colspan="8" height="140">
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
                    <asp:BoundColumn DataField="ItemUnitName" SortExpression="ItemUnitName" HeaderText="计量单位">
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="StockNum" SortExpression="StockNum" HeaderText="当前库存数">
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="PlanNum" SortExpression="PlanNum" HeaderText="请领数"></asp:BoundColumn>
                    <asp:BoundColumn DataField="ItemNum" SortExpression="ItemNum" HeaderText="实发数"></asp:BoundColumn>
                    <asp:BoundColumn DataField="ItemPrice" SortExpression="ItemPrice" HeaderText="单价">
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="ItemMoney" SortExpression="ItemMoney" HeaderText="总价">
                        <ItemStyle HorizontalAlign="Right"></ItemStyle>
                    </asp:BoundColumn>
                </Columns>
            </mzh:MzhDataGrid>
        </td>
    </tr>
    <tr>
        <td colspan="10">
            备注
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
    //根据传入的源单据号来生成内容。
    function SetEntry(id) {
        document.getElementById("<%=txtPKIDs.ClientID%>").value = id;
        document.getElementById("<%=btnForPKID.ClientID%>").click();
    }
    $('#<%=btnDelItem.ClientID%>').click(function(){
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
    });
	$('#<%=btnEditItem.ClientID%>').click(function(){
	    if(<%=DGModel_Items1.ClientID%>_obj.getSelectedID()!=null&&<%=DGModel_Items1.ClientID%>_obj.getSelectedID()!="")
	    {
		    
		}
		else
		{
			alert("请先选中某一条记录，再进行编辑！");
			return false;
		}
	});
</script>

<asp:HiddenField ID="txtItemSerial" runat="server" Value="-1" />
<asp:HiddenField ID="txtStoCode" runat="server" />

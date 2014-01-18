<%@ Control Language="c#" AutoEventWireup="True" CodeBehind="RTSWebControl.ascx.cs"
    Inherits="MZHMM.WebMM.Modules.RTSWebControl"%>
<table id="Table2" cellspacing="1" cellpadding="1" width="100%" border="0">
    <tr>
        <td width="150" valign="middle">
            <asp:TextBox ID="txtItemCode" Width="100%" runat="server" ToolTip="物料编号" ReadOnly="True"></asp:TextBox>
        </td>
        <td width="150">
            <asp:TextBox ID="txtItemName" runat="server" Width="100%" ToolTip="物料名称" ReadOnly="True"></asp:TextBox>
        </td>
        <td width="150">
            <asp:TextBox ID="txtItemSpecial" runat="server" Width="100%" ToolTip="规格型号" ReadOnly="True"></asp:TextBox>
        </td>
        <td width="50">
            <uc1:StorageDropdownlist ID="ddlUnit" runat="server"></uc1:StorageDropdownlist>
        </td>
        <td width="60">
            <asp:TextBox ID="txtItemPrice" runat="server" Width="100%" ToolTip="单价"></asp:TextBox>
        </td>
        <td width="50">
            <asp:TextBox ID="txtReqNum" runat="server" Width="100%" ToolTip="应退数量"></asp:TextBox>
        </td>
        <td width="91" style="width: 91px">
            <font face="宋体">
                <asp:TextBox ID="txtItemNum" runat="server" ToolTip="实退数量"></asp:TextBox></font>
        </td>
        <td width="30">
            <font face="宋体">
                <uc1:StorageDropdownlist ID="ddlCon" runat="server"></uc1:StorageDropdownlist>
            </font>
        </td>
        <td>
            <asp:Button ID="btnAddItem" TabIndex="50" runat="server" Text="新增" OnClick="btnAddItem_Click">
            </asp:Button><asp:Button ID="btnDelItem" TabIndex="40" runat="server" Text="删除" OnClick="btnDelItem_Click">
            </asp:Button><asp:Button ID="btnEditItem" TabIndex="40" runat="server" Text="编辑"
                OnClick="btnEdit_Click"></asp:Button>
        </td>
    </tr>
    <tr>
        <td valign="top" colspan="9" height="160">
            <mzh:MzhDataGrid ID="DGModel_Items1" runat="server" IdCell="0" MultiPageShowMode="DropListMode"
                AllowPaging="false" AllowSorting="false" ShowFooter="false" selecttype="SingleSelect"
                name="MzhMultiSelectDataGrid" AutoGenerateColumns="False" 
                onitemdatabound="DGModel_Items1_ItemDataBound">
                <Columns>
                    <asp:BoundColumn DataField="SerialNo" SortExpression="SerialNo" HeaderText="#" Visible="false">
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="ItemCode" SortExpression="ItemCode" HeaderText="物料编号">
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="ItemName" SortExpression="ItemName" HeaderText="物料名称">
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="ItemSpecial" SortExpression="ItemSpecial" HeaderText="规格型号">
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="ItemUnitName" SortExpression="ItemUnitName" HeaderText="计量单位"
                        >
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="PlanNum" SortExpression="PlanNum" HeaderText="请领数">
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="ItemNum" SortExpression="ItemNum" HeaderText="实发数">
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="ItemPrice" SortExpression="ItemPrice" HeaderText="单价">
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="ItemMoney" SortExpression="ItemMoney" HeaderText="总价">
                        <ItemStyle HorizontalAlign="Right"></ItemStyle>
                    </asp:BoundColumn>
                    <asp:BoundColumn  DataField="ConName" SortExpression="ConName" HeaderText="架位">
                        <ItemStyle HorizontalAlign="Right"></ItemStyle>
                    </asp:BoundColumn>
                </Columns>
            </mzh:MzhDataGrid>
        </td>
    </tr>
    <tr>
        <td colspan="10">
            <font face="宋体">备注
                <asp:TextBox ID="txtRemark" runat="server" Width="100%" TextMode="MultiLine" MaxLength="100"></asp:TextBox></font>
        </td>
    </tr>
</table>
<div class="hidden">
    <asp:Button ID="btnForItemCode" runat="server" Width="0px" Text="Button" Height="0"
        OnClick="btnForItemCode_Click"></asp:Button>
</div>

<script language="javascript" type="text/javascript">

	function document.all.<%=txtItemCode.ClientID%>.onblur()
	{
		if (document.getElementById("<%=txtItemCode.ClientID%>").value!="")
		{
			document.getElementById("<%=btnForItemCode.ClientID%>").click();
		}
	}
	function document.all.<%=txtItemCode.ClientID%>.onkeypress()
	{
		if(event.keyCode==13)
		{
			document.getElementById("<%=btnForItemCode.ClientID%>").click();
			return false;
		}		
	}
	
	function document.all.<%=btnEditItem.ClientID%>.onclick()
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
	
	function document.all.<%=btnDelItem.ClientID%>.onclick()
	{
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

<iframe frameborder="0" id="CalFrame" marginheight="0" marginwidth="0" scrolling="no"
    src="../Images/calendar/calendar.htm" style="display: none; z-index: 100; width: 148px;
    position: absolute; height: 194px"></iframe>
<input id="txtItemSerial" type="hidden" value="-1" name="Hidden1" runat="server">
<asp:TextBox ID="txtEntryNo" runat="server" Width="0px"></asp:TextBox>
<asp:Button ID="bntForEntryNo" runat="server" Text="Button" Width="0px" OnClick="bntForEntryNo_Click">
</asp:Button>

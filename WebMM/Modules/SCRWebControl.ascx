<%@ Control Language="c#" AutoEventWireup="True" CodeBehind="SCRWebControl.ascx.cs"
    Inherits="MZHMM.WebMM.Modules.SCRWebControl" %>
<%@ Register TagPrefix="uc1" TagName="StorageDropdownlistview" Src="StorageDropdownlist.ascx" %>
<table id="Table2" cellspacing="1" cellpadding="1" width="100%" border="0">
    <tr>
        <td valign="middle" width="150">
            <table id="Table1" cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
                <tr>
                    <td width="80%" >
                        <asp:TextBox ID="txtItemCode" ToolTip="物料编号" runat="server" SkinID="PurposeTable"></asp:TextBox>
                    </td>
                    <td width="20%" align="left">
                        <input onclick="window.open('../Storage/ItemQuery.aspx','物料查询','toolbar = no,location=no,directories=no,status=no,menubar=no,scrollbars=no,resizable=no,copyhistory=no,width =640,height = 440,left='+(window.screen.width - 640)/2+',top='+(window.screen.height - 440)/2+'')"
                            type="button" value="..." width="100%" class="Commonbutton" />
                    </td>
                </tr>
            </table>
        </td>
        <td width="100">
            <asp:TextBox ID="txtItemName" ToolTip="物料名称" runat="server"  SkinID="PurposeTable"></asp:TextBox>
        </td>
        <td width="100">
            <asp:TextBox ID="txtItemSpecial" ToolTip="规格型号" runat="server" SkinID="PurposeTable"></asp:TextBox>
        </td>
        <td width="90">
            <uc1:StorageDropdownlistview ID="ddlUnit" runat="server"></uc1:StorageDropdownlistview>
        </td>
        <td width="60">
            <asp:TextBox ID="txtItemPrice" ToolTip="单价" runat="server" SkinID="PurposeTable"></asp:TextBox>
        </td>
        <td width="50">
            <asp:TextBox ID="txtPlanNum" ToolTip="应废数量" runat="server" SkinID="PurposeTable"></asp:TextBox>
        </td>
        <td width="50">
            <asp:TextBox ID="txtItemNum" ToolTip="实废数量" runat="server" SkinID="PurposeTable" Enabled="false" ></asp:TextBox>
        </td>
        <td width="150">
            <asp:Button ID="btnAddItem" TabIndex="50" runat="server" Text="新增" OnClick="btnAddItem_Click">
            </asp:Button><asp:Button ID="btnDelItem" TabIndex="40" runat="server" Text="删除" OnClick="btnDelItem_Click">
            </asp:Button>
            <asp:Button ID="btnEditItem" TabIndex="40" runat="server" Text="编辑" OnClick="btnEditItem_Click">
            </asp:Button>
        </td>
    </tr>
    <tr>
        <td valign="top" colspan="8" height="130">
            <mzh:MzhDataGrid ID="DGModel_Items1" runat="server" IdCell="0" MultiPageShowMode="DropListMode"
                AllowPaging="false" AllowSorting="false" ShowFooter="false" selecttype="SingleSelect"
                name="MzhMultiSelectDataGrid" AutoGenerateColumns="False" 
                onitemdatabound="DGModel_Items1_ItemDataBound">
                <Columns>
                    <asp:BoundColumn DataField="ItemCode" SortExpression="ItemCode" HeaderText="物料编号">
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="ItemName" SortExpression="ItemName" HeaderText="物料描述">
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="ItemSpecial" SortExpression="ItemSpecial" HeaderText="规格型号">
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="ItemUnit" Visible="false" SortExpression="ItemUnit" HeaderText="ItemUnit"
                       >
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="ItemUnitName" SortExpression="ItemUnitName" HeaderText="单位名称">
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="ItemPrice" SortExpression="ItemPrice" HeaderText="单价">
                        <ItemStyle HorizontalAlign="Right"></ItemStyle>
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="PlanNum" SortExpression="PlanNum" HeaderText="应废数量">
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="ItemNum" SortExpression="ItemNum" HeaderText="实废数量" >
                        <ItemStyle HorizontalAlign="Right"></ItemStyle>
                    </asp:BoundColumn>
                     <asp:BoundColumn DataField="ItemMoney" SortExpression="ItemMoney" HeaderText="报废金额">
                        <ItemStyle HorizontalAlign="Right"></ItemStyle>
                    </asp:BoundColumn>
                </Columns>
            </mzh:MzhDataGrid>
        </td>
    </tr>
    <tr>
        <td colspan="10" style="word-wrap:break-word;word-break:break-all;">
            <font face="宋体">备注
                <asp:TextBox ID="txtRemark" runat="server"  SkinID="PurposeDisTable" MaxLength="100" TextMode="MultiLine"></asp:TextBox></font>
        </td>
    </tr>
</table>
<div class="hidden">
<asp:Button ID="btnForItemCode" runat="server" Text="Button" Height="0" OnClick="btnForItemCode_Click">
</asp:Button>
</div>



<script language="javascript" type="text/javascript">
	function document.all.<%=txtItemCode.ClientID%>.onblur()
	{
		if(document.getElementById("<%=txtItemCode.ClientID%>").value!="")
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
	
	function setCode(id)
	{
		document.getElementById("<%=txtItemCode.ClientID%>").value=id;
		document.getElementById("<%=btnForItemCode.ClientID%>").click();
	}
	
	
</script>

<asp:HiddenField ID="txtItemSerial" Value="-1" runat="server" />

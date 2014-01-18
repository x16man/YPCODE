<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Default.Master" AutoEventWireup="true" CodeBehind="InventoryProfitInput.aspx.cs" Inherits="WebMM.Storage.InventoryProfitInput" %>
<%@ MasterType VirtualPath="~/Master/Default.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<title>领料单</title>
<link rel="stylesheet" type="text/css" href="../CSS/Storage/InventoryProfitInput.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="AjaxHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BodyHolder" runat="server">
    <table class="myTable myTableToolbar" id="Table1" cellspacing="1" >
        <tr>
            <td colspan="4">
                <uc1:DocWebControl ID="doc1" runat="server"></uc1:DocWebControl>
            </td>
        </tr>
        <tr>
            <td width="100px">
                仓库：<span class="required">*</span>
            </td>
            <td colspan="3">
                <asp:DropDownList runat="server" ID="ddlStorage" Width="100%" 
                    AutoPostBack="True" onselectedindexchanged="ddlStorage_SelectedIndexChanged"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td colspan="4" class="myItemControl">
                <table id="Table3" cellspacing="1" cellpadding="1" width="100%" border="0">
                    <tr id="editRowHeader" runat="server" class="myTrSubmitLine">
                        <td>物料编号</td>
                        <td>物料名称</td>
                        <td>规格型号</td>
                        <td>单位</td>
                        <td>单价</td>
                        <td>账面数量</td>
                        <td>盘点数量</td>
                        <td>盘盈数量</td>
                        <td>架位</td>
                        <td align="right">操作</td>
                    </tr>

                    <tr id="editRow" runat="server" class="myTrSubmitLine">
        <td valign="middle" width="110px">
            <table id="Table2" cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
                <tr>
                    <td>
                        <asp:TextBox ID="txtItemCode" ToolTip="物料编号"  runat="server"></asp:TextBox>
                    </td>
                    <td width="30px">
                        <input onclick="window.open('../Storage/ItemQuery.aspx','物料查询','toolbar = no,location=no,directories=no,status=no,menubar=no,scrollbars=yes,resizable=no,copyhistory=no,width =640,height = 440,left='+(window.screen.width - 640)/2+',top='+(window.screen.height - 440)/2+'')"
                            type="button" value="..." class="Commonbutton" />
                    </td>
                </tr>
            </table>
        </td>
        <td width="100px">
            <asp:TextBox ID="txtItemName" ToolTip="物料名称"  runat="server"></asp:TextBox>
        </td>
        <td width="100px">
            <asp:TextBox ID="txtItemSpecial" ToolTip="规格型号"  runat="server"></asp:TextBox>
        </td>
        <td width="70px">
            <uc1:StorageDropdownlist ID="ddlUnit" runat="server"></uc1:StorageDropdownlist>
        </td>
        <td width="80px">
            <asp:TextBox ID="txtItemPrice" ToolTip="单价"  runat="server"></asp:TextBox>
        </td>
        <td width="80px">
            <asp:TextBox ID="txtCarryingAmount" ToolTip="账面数量"  runat="server"></asp:TextBox>
        </td>
        <td width="80px">
            <asp:TextBox ID="txtInventoryAmount" ToolTip="盘点数量"  runat="server"></asp:TextBox>
        </td>
        <td width="80px">
            <asp:TextBox ID="txtItemNum" ToolTip="盘盈数量"  runat="server"></asp:TextBox>
        </td>
        <td width="110px">
            <asp:DropDownList runat="server" ID="ddlCon"></asp:DropDownList>
        </td>
        <td style="text-align:right;">
            <asp:Button ID="btnAddItem" TabIndex="50" runat="server" Text="新增" OnClick="btnAddItem_Click">
            </asp:Button>
            <asp:Button ID="btnDelItem" TabIndex="40" runat="server" Text="删除" OnClick="btnDelItem_Click" >
            </asp:Button>
            <asp:Button ID="btnEditItem" TabIndex="40" runat="server" Text="编辑" OnClick="btnEditItem_Click" >
            </asp:Button>
        </td>
    </tr>
                    <tr>
        <td valign="top" colspan="10" height="160">
            <mzh:MzhDataGrid ID="DGModel_Items1" runat="server" IdCell="0" MultiPageShowMode="DropListMode"
                AllowPaging="false" AllowSorting="false" ShowFooter="true" selecttype="SingleSelect"
                name="MzhMultiSelectDataGrid" AutoGenerateColumns="False" onitemdatabound="DGModel_Items1_ItemDataBound" 
                >
                <Columns>
                    <asp:BoundColumn DataField="SerialNo" SortExpression="SerialNo" Visible = "false"></asp:BoundColumn>
                    <asp:BoundColumn DataField="ItemCode" SortExpression="ItemCode" HeaderText="物料编码">
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="ItemName" SortExpression="ItemName" HeaderText="物料名称">
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="ItemSpec" SortExpression="ItemSpec" HeaderText="规格型号">
                         <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="ItemUnitName" SortExpression="ItemUnitName" HeaderText="单位">
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="ItemPrice" SortExpression="ItemPrice" HeaderText="单价" FooterText="合计：" DataFormatString="{0:F2}">
                       <ItemStyle HorizontalAlign="Right" CssClass="right"></ItemStyle>
                        <FooterStyle HorizontalAlign="Right" Font-Bold="true" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="CarryingAmount" SortExpression="CarryingAmount" HeaderText="账面数量">
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="InventoryAmount" SortExpression="InventoryAmount" HeaderText="盘点数量">
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="ItemNum" SortExpression="ItemNum" HeaderText="盘盈数量" >
                        <ItemStyle HorizontalAlign="Right" />
                        <FooterStyle Font-Bold="true" HorizontalAlign="Right" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="ItemMoney" SortExpression="ItemMoney" HeaderText="金额" DataFormatString="{0:F2}">
                        <ItemStyle HorizontalAlign="Right"></ItemStyle>
                        <FooterStyle HorizontalAlign="Right" Font-Bold="true" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="ConName" HeaderText="架位">
                    </asp:BoundColumn>
                </Columns>
            </mzh:MzhDataGrid>
        </td>
    </tr>
                </table>
            </td>
        </tr>
        <tr>
        <td>备注：</td>
        <td colspan="3"><asp:TextBox ID="txtRemark" Width="100%" SkinID="PurposeTable" runat="server" TextMode="MultiLine" MaxLength="100"></asp:TextBox></td>
        </tr>
        <tr>
            <td colspan="4">
                <uc1:DocAuditWebControl ID="DocAuditWebControl1" runat="server"></uc1:DocAuditWebControl>
            </td>
        </tr>
        <tr>
            <td class="td_Label">
                制单部门：
            </td>
            <td class="td_Content" align="left">
                <asp:Label runat="server" ID="lblAuthorDeptName"></asp:Label>
            </td>
            <td class="td_Label">
                制单人：
            </td>
            <td class="td_Content" align="left">
                <asp:Label runat="server" ID="lblAuthorName"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                收料人：
            </td>
            <td align="left">
                <asp:TextBox runat="server" ID="txtAcceptName"></asp:TextBox>
            </td>
            <td>
                收料日期：
            </td>
            <td align="left">
                <asp:TextBox ID="txtAcceptDate" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr class="myTrSubmitLine">
            <td align="center" colspan="4" class="td_Submit">
                <asp:Button ID="btnRefuse" runat="server" Text="拒绝" OnClick="btnRefuse_Click"></asp:Button>
                <asp:Button ID="btnSave" runat="server" Text="保存" OnClick="btnSave_Click"></asp:Button>
                <asp:Button ID="btnPresent" runat="server" Text="马上提交" OnClick="btnPresent_Click">
                </asp:Button>
                <asp:Button ID="btnCancel" runat="server" Text="取消" CausesValidation="False" OnClick="btnCancel_Click">
                </asp:Button>
            </td>
        </tr>
     </table>
     <div class="hidden">
    <asp:Button ID="btnForItemCode" Width="0px" runat="server" Text="Button" Height="0"
        OnClick="btnForItemCode_Click"></asp:Button>
    <asp:HiddenField ID="txtEntryNo" runat="server" />
    <asp:HiddenField ID="txtItemSerial" runat="server" Value="-1" />
    <asp:HiddenField ID="txtStoCode" runat="server" />
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
	$("#<%=btnEditItem.ClientID %>").click(function(){
	    if(<%=DGModel_Items1.ClientID%>_obj.getSelectedID()!=null&&<%=DGModel_Items1.ClientID%>_obj.getSelectedID()!="")
	    {
		    
		}
		else
		{
			alert("请先选中某一条记录，再进行编辑！");
			return false;
		}
	});
	
	function setCode(id)
	{
		document.getElementById("<%=txtItemCode.ClientID%>").value=id;
		document.getElementById("<%=btnForItemCode.ClientID%>").click();
	}
</script>
</asp:Content>

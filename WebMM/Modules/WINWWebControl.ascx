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
                        <asp:TextBox ID="txtItemCode" ToolTip="物料编号"  runat="server"></asp:TextBox>
                    </td>
                    <td width="30px">
                        <input id="btnWWBrowser" onclick="window.open('../Storage/ItemQuery.aspx','物料查询','toolbar = no,location=no,directories=no,status=no,menubar=no,scrollbars=yes,resizable=no,copyhistory=no,width =640,height = 440,left='+(window.screen.width - 640)/2+',top='+(window.screen.height - 440)/2+'')"
                            type="button" value="..." name="btnWWBrowser" class="Commonbutton" runat="server" width="100%" />
                    </td>
                </tr>
            </table>
        </td>
        <td width="150px">
            <asp:TextBox ID="txtItemName" ToolTip="物料名称"  runat="server"></asp:TextBox>
        </td>
        <td width="150px">
            <asp:TextBox ID="txtItemSpecial" ToolTip="规格型号"  runat="server"></asp:TextBox>
        </td>
        <td width="70px">
            <uc1:StorageDropdownlistview ID="ddlUnit" runat="server"></uc1:StorageDropdownlistview>
        </td>
        <td width="60px">
            <asp:TextBox ID="txtItemPrice" ToolTip="单价"  runat="server"></asp:TextBox>
        </td>
        <td width="50px">
            <asp:TextBox ID="txtReqNum" ToolTip="应收数量"  runat="server"></asp:TextBox>
        </td>
        <td width="130px">
            <asp:TextBox ID="txtItemNum" ToolTip="实收数量"  runat="server"></asp:TextBox>
        </td>
        <td>
        </td>
        <td style="text-align:right;">
            <asp:Button ID="btnAddItem" TabIndex="0" runat="server" Text="新增" OnClick="btnAddItem_Click">
            </asp:Button><asp:Button ID="btnDelItem" TabIndex="0" runat="server" Text="删除" OnClick="btnDelItem_Click">
            </asp:Button><asp:Button ID="btnEditItem" TabIndex="0" runat="server" Text="编辑" OnClick="btnEdit_Click">
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
                    <asp:BoundColumn  DataField="ItemCode" SortExpression="ItemCode" HeaderText="物料编号">
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="ItemName" SortExpression="ItemName" HeaderText="物料名称">
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="ItemSpecial" SortExpression="ItemSpecial" HeaderText="规格型号">
                         <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="ItemUnitName" SortExpression="ItemUnitName" HeaderText="计量单位"
                        >
                       
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="PlanNum" SortExpression="PlanNum" HeaderText="应收数">
                      
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="ItemNum" SortExpression="ItemNum" HeaderText="实收数">
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="ItemPrice" SortExpression="ItemPrice" HeaderText="单价">
                        <ItemStyle HorizontalAlign="Right"></ItemStyle>
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="ItemFee" SortExpression="ItemFee" HeaderText="费用">
                        <ItemStyle HorizontalAlign="Right"></ItemStyle>
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="ItemSum" SortExpression="ItemSum" HeaderText="总价">
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
            费用：
        </td>
        <td>
            <asp:TextBox ID="txtTotalFee" runat="server" MaxLength="100" 
                TextMode="SingleLine" AutoPostBack="True" OnTextChanged="txtTotalFee_TextChanged"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td width="40">
            消耗：
        </td>
        <td width="80">
            <asp:TextBox ID="txtPSerialNo" ToolTip="PNo."  runat="server"
                ReadOnly="False"></asp:TextBox>
        </td>
        <td width="80">
            <asp:TextBox ID="txtResCode" ToolTip="物料编号"  runat="server"
                ReadOnly="True"></asp:TextBox>
        </td>
        <td width="120">
            <asp:TextBox ID="txtResName" ToolTip="物料名称" runat="server"
                ReadOnly="True"></asp:TextBox>
        </td>
        <td width="120">
            <asp:TextBox ID="txtResSpecial" ToolTip="规格型号"  runat="server"
                ReadOnly="True"></asp:TextBox>
        </td>
        <td width="150">
            <uc1:StorageDropdownlistview ID="ddlResUnit" runat="server"></uc1:StorageDropdownlistview>
        </td>
        <td width="80">
            <asp:TextBox ID="txtResPrice" ToolTip="单价" runat="server" ReadOnly="True"></asp:TextBox>
        </td>
        <td width="80">
            <asp:TextBox ID="txtResNum" ToolTip="消耗数量" runat="server"></asp:TextBox>
        </td>
        <td style="text-align:right;">
            <asp:Button ID="btnResUpdate" TabIndex="50" runat="server" Text="更新" OnClick="btnResUpdate_Click">
            </asp:Button><asp:Button ID="btnresDelete" TabIndex="40" runat="server" Text="删除"
                OnClick="btnresDelete_Click"></asp:Button><asp:Button ID="btnResEdit" TabIndex="40"
                    runat="server" Text="编辑" OnClick="btnResEdit_Click"></asp:Button>
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
                    <asp:BoundColumn DataField="ResCode" HeaderText="编号">
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="ResName" HeaderText="名称">
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="ResSpecial" HeaderText="规格型号">
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="ResUnitName" HeaderText="单位">
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="ResPrice" HeaderText="单价"  DataFormatString="{0:0.###}">
                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="ResNum" HeaderText="数量" DataFormatString="{0:0.###}">
                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="ResMoney" HeaderText="金额"  DataFormatString="{0:0.###}">
                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
                    </asp:BoundColumn>
                </Columns>
            </mzh:MzhDataGrid>
        </td>
    </tr>
    <tr>
        <td colspan="10">备注：
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
    $('#<%=btnresDelete.ClientID%>').click(function(){
        if(<%=DGModel_WRES1.ClientID%>_obj.getSelectedID()!=null&&<%=DGModel_WRES1.ClientID%>_obj.getSelectedID()!="")
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
    $('#<%=btnResEdit.ClientID%>').click(function(){
        if(<%=DGModel_WRES1.ClientID%>_obj.getSelectedID()!=null&&<%=DGModel_WRES1.ClientID%>_obj.getSelectedID()!="")
	    {
		    // alert(<%=DGModel_WRES1.ClientID%>_obj.getSelectedID());
		     //return false;
		}
		else
		{
			alert("请先选中某一条记录，再进行编辑！");
			return false;
		}
    });
</script>

<asp:HiddenField ID="txtItemSerial" runat="server" Value="-1" />
<asp:HiddenField ID="txtResSerial" runat="server" Value="-1" />

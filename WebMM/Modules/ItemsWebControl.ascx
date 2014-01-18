<%@ Control Language="c#" AutoEventWireup="True" CodeBehind="ItemsWebControl.ascx.cs"
    Inherits="MZHMM.WebMM.Modules.ItemsWebControl"  %>
<%@ Register TagPrefix="uc1" TagName="StorageDropdownlistview" Src="StorageDropdownlist.ascx" %>
<table id="Table2" cellspacing="1" cellpadding="1" width="100%" border="0">
    <tr>
        <td valign="middle" width="120px">
            <table id="Table1" cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
                <tr>
                    <td>
                        <asp:TextBox ID="txtItemCode" ToolTip="物料编号" runat="server" ></asp:TextBox>
                        <asp:HiddenField runat="server" ID="hfNewCode"/>
                    </td>
                    <td width="30px">
                        <input style="width:100%;" class="Commonbutton" onclick="window.open('../Storage/ItemQuery.aspx?DocCode=<%=DocCode%>','物料查询','toolbar = no,location=no,directories=no,status=no,menubar=no,scrollbars=yes,resizable=yes,copyhistory=no,width =640,height = 440,left='+(window.screen.width - 640)/2+',top='+(window.screen.height - 440)/2+'')"
                            type="button" value="..."  />
                    </td>
                </tr>
            </table>
        </td>
        <td width="120px">
            <asp:TextBox ID="txtItemName" ToolTip="物料名称" runat="server" width="120px"></asp:TextBox>
        </td>
        <td width="100px">
            <asp:TextBox ID="txtItemSpecial" ToolTip="规格型号" runat="server" width="100px"></asp:TextBox>
        </td>
        <td width="70px">
            <uc1:StorageDropdownlistview ID="ddlUnit" runat="server" Width="70px"></uc1:StorageDropdownlistview>
        </td>
        <td width="80px">
            <asp:TextBox ID="txtItemPrice" ToolTip="单价" runat="server" Width="80px" ></asp:TextBox>
        </td>
        <td width="80px">
            <asp:TextBox ID="txtReqNum" ToolTip="数量" runat="server" width="80px"></asp:TextBox>
        </td>
        <td width="93px">
            <mzh:ToolbarCalendar ID="txtReqDate" ToolTip="要求日期" runat="server"  ReadOnly="true"
                Width="100%" />
        </td>
        <td style="text-align:right;">
            <asp:Button ID="btnAddItem" TabIndex="50" runat="server" Text="新增" OnClick="btnAddItem_Click">
            </asp:Button><asp:Button ID="btnDelItem" TabIndex="40" runat="server" Text="删除" OnClick="btnDelItem_Click">
            </asp:Button><asp:Button ID="btnEditItem" TabIndex="40" runat="server" Text="编辑" OnClick="btnEditItem_Click">
            </asp:Button>
        </td>
    </tr>
    <tr>
        <td valign="top" colspan="8" height="160px">
            <mzh:MzhDataGrid ID="DGModel_Items1" runat="server" IdCell="0" MultiPageShowMode="DropListMode"
                selecttype="SingleSelect" ShowFooter="false" AllowPaging="false" AllowSorting="false"
                 name="MzhMultiSelectDataGrid" AutoGenerateColumns="False" 
                onitemdatabound="DGModel_Items1_ItemDataBound">
                <Columns>
                    
                    <asp:BoundColumn DataField="ItemCode" SortExpression="ItemCode" HeaderText="物料编号">
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="NewCode" SortExpression="NewCode" HeaderText="新编号">
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="ItemName" SortExpression="ItemName" HeaderText="物料名称">
                        <ItemStyle HorizontalAlign ="Left" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="ItemSpecial" SortExpression="ItemSpecial" HeaderText="规格型号">
                        <ItemStyle HorizontalAlign ="Left" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="ItemUnit" Visible="false" SortExpression="ItemUnit" HeaderText="单位">
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="ItemUnitName" SortExpression="ItemUnitName" HeaderText="单位名称">
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="ItemPrice" SortExpression="ItemPrice" HeaderText="单价">
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundColumn>
                     <asp:BoundColumn  DataField="ItemNum" SortExpression="ItemPrice" HeaderText="申购数量">
                      <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundColumn>
                    <asp:BoundColumn Visible="false" DataField="ItemMoney" SortExpression="ItemMoney" HeaderText="ItemMoney">
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="ReqDate" SortExpression="ReqDate" HeaderText="需求日期"
                        DataFormatString="{0:d}">
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:BoundColumn>
                </Columns>
            </mzh:MzhDataGrid>
        </td>
    </tr>
    <tr>
        <td colspan="10" align="left" valign="top">
            备注
                <asp:TextBox ID="txtRemark" runat="server" SkinID="PurposeTable" MaxLength="100"
                    TextMode="MultiLine">
                </asp:TextBox>
        </td>
    </tr>
</table>
<div class="hidden">
    <asp:Button ID="btnForItemCode" runat="server" Width="0px" Text="Button" Height="0"
        OnClick="btnForItemCode_Click"></asp:Button>
</div>

<script language="javascript" type="text/javascript">
    $("#<%=txtItemCode.ClientID%>").blur(function(){
        if(document.getElementById("<%=txtItemCode.ClientID%>").value!=""){
			document.getElementById("<%=btnForItemCode.ClientID%>").click();
		}
    });
    $("#<%=txtItemCode.ClientID%>").keypress(function(e){
        if(e.keyCode==13)
		{
			document.getElementById("<%=btnForItemCode.ClientID%>").click();
			return false;
		}
    });
	
    function setCode(id) {

        document.getElementById("<%=txtItemCode.ClientID%>").value = id;
        document.getElementById("<%=btnForItemCode.ClientID%>").click();
    }

    $("#<%=btnDelItem.ClientID%>").click(function(){
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
    $("#<%=btnEditItem.ClientID%>").click(function(){
        if(<%=DGModel_Items1.ClientID%>_obj.getSelectedID()==null||<%=DGModel_Items1.ClientID%>_obj.getSelectedID()=="")
	    {
		    alert("请先选中某一条记录，再进行编辑！");
			return false;
		}
    });
</script>

<asp:HiddenField ID="txtItemSerial" runat="server" Value="-1" />
<asp:HiddenField ID="txtDocCode" runat="server" />

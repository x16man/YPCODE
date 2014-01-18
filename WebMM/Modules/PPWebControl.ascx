<%@ Control Language="c#" AutoEventWireup="True" CodeBehind="PPWebControl.ascx.cs"
    Inherits="MZHMM.WebMM.Modules.PPWebControl" %>

<%@ Register TagPrefix="uc1" TagName="StorageDropdownlistview" Src="StorageDropdownlist.ascx" %>
<%@ Register TagPrefix="uc1" TagName="USWebControlview" Src="USWebControl.ascx" %>
<table id="Table2" cellspacing="1" cellpadding="1" width="100%" border="0">
    <tbody>
        <tr>
            <td width="90px">
                <uc1:StorageDropdownlistview ID="ddlReqDept" runat="server" Width="100%"></uc1:StorageDropdownlistview>
            </td>
            <td valign="middle" width="90px">
                <table id="Table1" cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
                    <tr>
                        <td width="60px">
                            <asp:TextBox ID="txtItemCode" runat="server" ToolTip="物料编号"></asp:TextBox>
                            <asp:HiddenField runat="server" ID="hfNewCode"/>
                        </td>
                        <td width="30px">
                            <input class="Commonbutton" onclick="window.open('../Storage/ItemQuery.aspx','物料查询','toolbar = no,location=no,directories=no,status=no,menubar=no,scrollbars=yes,resizable=no,copyhistory=no,width =640,height = 440,left='+(window.screen.width - 640)/2+',top='+(window.screen.height - 440)/2+'')"
                                type="button" value="..." style="width:100%" />
                        </td>
                    </tr>
                </table>
            </td>
            <td width="80px">
                <asp:TextBox ID="txtItemName" runat="server" ToolTip="物料名称" Width="100%"></asp:TextBox>
            </td>
            <td width="80px">
                <asp:TextBox ID="txtItemSpecial" runat="server"  ToolTip="规格型号" Width="100%"></asp:TextBox>
            </td>
            <td width="60px">
                <uc1:StorageDropdownlistview ID="ddlUnit" runat="server" Width="100%"></uc1:StorageDropdownlistview>
            </td>
            <td width="60px">
                <asp:TextBox ID="txtItemPrice" runat="server" ToolTip="单价" Width="100%"></asp:TextBox>
            </td>
            <td width="60px">
                <asp:TextBox ID="txtReqNum" runat="server" ToolTip="数量" Width="100%"></asp:TextBox>
            </td>
            <td width="120px">
                <uc1:USWebControlview ID="ddlPurpose" runat="server" Width="100%"></uc1:USWebControlview>
            </td>
            <td width="80px">
                <mzh:ToolbarCalendar ID="txtReqDate" ReadOnly="true" runat="server" Width="100%" />
            </td>
            <td width="100px">
                <asp:TextBox ID="txtRemark" runat="server" Width="100%"></asp:TextBox>
            </td>
            <td style="text-align:right;">
                <asp:Button ID="btnAddItem" TabIndex="50" runat="server" Text="新增" OnClick="btnAddItem_Click">
                </asp:Button><asp:Button ID="btnDelItem" TabIndex="40" runat="server" Text="删除" OnClick="btnDelItem_Click">
                </asp:Button><asp:Button ID="btnEditItem" TabIndex="40" runat="server" Text="编辑" OnClick="btnEditItem_Click">
                </asp:Button>
            </td>
        </tr>
        <tr>
            <td valign="top" colspan="11" height="160">
                <mzh:MzhDataGrid ID="DGModel_Items1" ShowFooter="true" runat="server" IdCell="0"
                    MultiPageShowMode="DropListMode" selecttype="SingleSelect" name="MzhMultiSelectDataGrid"
                    AllowPaging="false" AllowSorting="false" AutoGenerateColumns="False" OnItemDataBound="DGModel_Items1_ItemDataBound">
                    <Columns>
                        <asp:BoundColumn Visible="False" DataField="ItemCode" SortExpression="ItemCode" HeaderText="ItemCode">
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="ReqDeptName" SortExpression="ReqDeptName" HeaderText="申请部门名称">
                            <HeaderStyle Width="12%" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="ItemCode" SortExpression="ItemCode" HeaderText="物料编码">
                            <HeaderStyle Width="8%" />
                        </asp:BoundColumn>
                        <asp:BoundColumn Visible="False" DataField="NewCode" SortExpression="NewCode" HeaderText="新编号">
                            <HeaderStyle Width="8%" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="ItemName" SortExpression="ItemName" HeaderText="物料名称">
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="ItemSpecial" SortExpression="ItemSpecial" HeaderText="规格型号">
                             <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="ItemUnit" SortExpression="ItemUnit" Visible="false" HeaderText="单位">
                            <HeaderStyle Width="5%" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="ItemUnitName" SortExpression="ItemUnitName" HeaderText="单位">
                            <HeaderStyle Width="8%" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="ItemPrice" SortExpression="ItemPrice" HeaderText="单价">
                            <ItemStyle CssClass="right" HorizontalAlign="Right" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="ItemNum" SortExpression="ItemNum" HeaderText="数量" FooterText="合计：" DataFormatString="{0:n3}">
                            <ItemStyle HorizontalAlign="Right"></ItemStyle>
                            <FooterStyle HorizontalAlign="Right"   />
                            <HeaderStyle Width="8%" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="ItemMoney" SortExpression="ItemMoney" HeaderText="金额" DataFormatString="{0:n3}">
                            <ItemStyle HorizontalAlign="Right"></ItemStyle>
                            <FooterStyle HorizontalAlign="Right" Font-Bold="true" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="ReqReason" SortExpression="ReqReason" HeaderText="用途">
                           <HeaderStyle Width="8%" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="ReqDate" SortExpression="ReqDate" HeaderText="需求日期" DataFormatString="{0:yyyy-MM-dd}">
                            <HeaderStyle Width="8%" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Proposer" SortExpression="Proposer" HeaderText="申请人">
                            <HeaderStyle Width="8%" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Remark" SortExpression="Remark" HeaderText="备注">
                            <HeaderStyle Width="5%" />
                        </asp:BoundColumn>
                    </Columns>
                </mzh:MzhDataGrid>
                <mzh:MzhDataGrid ID="MzhDataGrid1" ShowFooter="true" runat="server" IdCell="0" Visible ="false"
                    MultiPageShowMode="DropListMode" selecttype="SingleSelect" name="MzhMultiSelectDataGrid"
                    AllowPaging="false" AllowSorting="false" AutoGenerateColumns="False" OnItemDataBound="DGModel_Items1_ItemDataBound">
                    <Columns>
                        <asp:BoundColumn Visible="False" DataField="ItemCode" SortExpression="ItemCode" HeaderText="ItemCode">
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="ReqDeptName" SortExpression="ReqDeptName" HeaderText="申请部门名称">
                            <HeaderStyle Width="12%" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="ItemCode" SortExpression="ItemCode" HeaderText="物料编码">
                            <HeaderStyle Width="10%" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="ItemName" SortExpression="ItemName" HeaderText="物料名称">
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="ItemSpecial" SortExpression="ItemSpecial" HeaderText="规格型号">
                             <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="ItemUnit" SortExpression="ItemUnit" Visible="false" HeaderText="单位">
                            <HeaderStyle Width="5%" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="ItemUnitName" SortExpression="ItemUnitName" HeaderText="单位">
                            <HeaderStyle Width="8%" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="ItemPrice" SortExpression="ItemPrice" HeaderText="单价">
                            <ItemStyle CssClass="right" HorizontalAlign="Right" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="ItemNum" SortExpression="ItemNum" HeaderText="数量" FooterText="合计：" DataFormatString="{0:n3}">
                            <ItemStyle HorizontalAlign="Right"></ItemStyle>
                            <FooterStyle HorizontalAlign="Right"   />
                            <HeaderStyle Width="8%" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="ItemMoney" SortExpression="ItemMoney" HeaderText="金额" DataFormatString="{0:n3}">
                            <ItemStyle HorizontalAlign="Right"></ItemStyle>
                            <FooterStyle HorizontalAlign="Right" Font-Bold="true" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="ReqReason" SortExpression="ReqReason" HeaderText="用途">
                           <HeaderStyle Width="8%" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="ReqDate" SortExpression="ReqDate" HeaderText="需求日期" DataFormatString="{0:yyyy-MM-dd}">
                            <HeaderStyle Width="8%" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Proposer" SortExpression="Proposer" HeaderText="申请人">
                            <HeaderStyle Width="8%" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Remark" SortExpression="Remark" HeaderText="备注">
                            <HeaderStyle Width="5%" />
                        </asp:BoundColumn>
                    </Columns>
                </mzh:MzhDataGrid>
                <h3 id="titleGXGZ" runat="server" visible ="false" class="mzhTitle">更新改造项目相关</h3>
                <mzh:MzhDataGrid ID="MzhDataGrid2" ShowFooter="true" runat="server" IdCell="0" Visible = "false"
                    MultiPageShowMode="DropListMode" selecttype="SingleSelect" name="MzhMultiSelectDataGrid"
                    AllowPaging="false" AllowSorting="false" AutoGenerateColumns="False" OnItemDataBound="DGModel_Items1_ItemDataBound">
                    <Columns>
                        <asp:BoundColumn Visible="False" DataField="ItemCode" SortExpression="ItemCode" HeaderText="ItemCode">
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="ReqDeptName" SortExpression="ReqDeptName" HeaderText="申请部门名称">
                            <HeaderStyle Width="12%" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="ItemCode" SortExpression="ItemCode" HeaderText="物料编码">
                            <HeaderStyle Width="10%" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="ItemName" SortExpression="ItemName" HeaderText="物料名称">
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="ItemSpecial" SortExpression="ItemSpecial" HeaderText="规格型号">
                             <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="ItemUnit" SortExpression="ItemUnit" Visible="false" HeaderText="单位">
                            <HeaderStyle Width="5%" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="ItemUnitName" SortExpression="ItemUnitName" HeaderText="单位">
                            <HeaderStyle Width="8%" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="ItemPrice" SortExpression="ItemPrice" HeaderText="单价">
                            <ItemStyle CssClass="right" HorizontalAlign="Right" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="ItemNum" SortExpression="ItemNum" HeaderText="数量" FooterText="合计：" DataFormatString="{0:n3}">
                            <ItemStyle HorizontalAlign="Right"></ItemStyle>
                            <FooterStyle HorizontalAlign="Right"   />
                            <HeaderStyle Width="8%" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="ItemMoney" SortExpression="ItemMoney" HeaderText="金额" DataFormatString="{0:n3}">
                            <ItemStyle HorizontalAlign="Right"></ItemStyle>
                            <FooterStyle HorizontalAlign="Right" Font-Bold="true" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="ReqReason" SortExpression="ReqReason" HeaderText="用途">
                           <HeaderStyle Width="8%" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="ReqDate" SortExpression="ReqDate" HeaderText="需求日期" DataFormatString="{0:yyyy-MM-dd}">
                            <HeaderStyle Width="8%" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Proposer" SortExpression="Proposer" HeaderText="申请人">
                            <HeaderStyle Width="8%" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Remark" SortExpression="Remark" HeaderText="备注">
                            <HeaderStyle Width="5%" />
                        </asp:BoundColumn>
                    </Columns>
                </mzh:MzhDataGrid>
            </td>
        </tr>
    </tbody>
</table>
<div class="hidden">
    <asp:Button ID="btnForItemCode" runat="server" Width="0px" Text="Button" Height="0"
        OnClick="btnForItemCode_Click"></asp:Button>
</div>
<asp:HiddenField ID="txtItemSerial" runat="server" Value="-1" />

<script language="javascript" type="text/javascript">
    $("#<%=txtItemCode.ClientID%>").blur(function(){
        if($("#<%=txtItemCode.ClientID%>").value!="")
            $("#<%=btnForItemCode.ClientID%>").click();
    });
    $("#<%=txtItemCode.ClientID%>").keypress(function(e){
        if(e.which=='13'){
            $("#<%=btnForItemCode.ClientID%>").click();
            return false;
        }
    });
	$("#<%=btnEditItem.ClientID%>").click(function(){
        if(<%=DGModel_Items1.ClientID%>_obj.getSelectedID()==null||<%=DGModel_Items1.ClientID%>_obj.getSelectedID()==""){
			alert("请先选中某一条记录，再进行编辑！");
			return false;
		}
    });
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
	
	function setCode(id)
	{
		document.getElementById("<%=txtItemCode.ClientID%>").value=id;
		document.getElementById("<%=btnForItemCode.ClientID%>").click();
	}
</script>


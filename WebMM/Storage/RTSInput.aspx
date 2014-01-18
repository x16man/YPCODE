<%@ Page Language="c#" CodeBehind="RTSInput.aspx.cs" AutoEventWireup="True" MasterPageFile="~/Master/Default.Master"
    Inherits="MZHMM.WebMM.Storage.RTSInput" %>

<%@ MasterType VirtualPath="~/Master/Default.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>生产退料单输入</title>
    <meta content="生产退料单" name="keywords" />
    <link rel="stylesheet" type="text/css" href="../CSS/Storage/RTSInput.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="AjaxHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BodyHolder" runat="server">
    <table class="myTable" id="Table1" cellspacing="0" cellpadding="0" width="98%" align="center"
        border="0">
        <tbody>
            <tr class="myTrDualLine">
                <td colspan="4">
                    <uc1:DocWebControl ID="doc1" runat="server"></uc1:DocWebControl>
                </td>
            </tr>
            <tr class="myTrDualLine">
                <td>
                    部门：
                </td>
                <td align="left">
                    <table width="100%">
                        <tr>
                            <td style="width: 80%">
                                <uc1:StorageDropdownlist ID="ddlDept" runat="server"></uc1:StorageDropdownlist>
                            </td>
                            <td style="width: 20%">
                                <input id="Button1" class="Commonbutton" type="button" value="选择"   style="<% = RTSStyle %>" onclick="window.open('WDRWSourceBrowser.aspx?Op=View&amp;DeptCode='+GetCode(),'领料单查询','toolbar = no,location=no,directories=no,status=no,menubar=no,scrollbars=yes,resizable=yes,copyhistory=no,width =640,height = 440,left='+(window.screen.width - 640)/2+',top='+(window.screen.height - 440)/2+'')"
                                     />
                            </td>
                        </tr>
                    </table>
                </td>
                <td width="20%">
                    仓库：
                </td>
                <td style="width: 211px" width="211">
                    <uc1:StorageDropdownlist ID="ddlStorage" runat="server"></uc1:StorageDropdownlist>
                </td>
            </tr>
            <tr class="myTrDualLine">
                <td>
                    申请理由及用途：
                </td>
                <td>
                    <uc1:USWebControl ID="ddlPurpose" runat="server"></uc1:USWebControl>
                </td>
                <td>
                    验收结果：
                </td>
                <td>
                    <uc1:StorageDropdownlist ID="ddlCheckResult" runat="server"></uc1:StorageDropdownlist>
                </td>
            </tr>
            <tr class="myTrDualLine">
                <td colspan="4">
                    <table width="100%">
                        <tr>
                            <td style="width: 75px">
                                <asp:TextBox ID="txtItemCode" runat="server" ToolTip="物料编号" SkinID="PurposeTable"></asp:TextBox>
                            </td>
                            <td style="width: 80px">
                                <asp:TextBox ID="txtItemName" runat="server" ToolTip="物料名称" SkinID="PurposeTable"></asp:TextBox>
                            </td>
                            <td style="width: 80px">
                                <asp:TextBox ID="txtItemSpecial" runat="server" ToolTip="规格型号" SkinID="PurposeTable"></asp:TextBox>
                            </td>
                            <td style="width: 50px">
                                <asp:TextBox ID="txtItemUnit" runat="server" ToolTip="单位" SkinID="PurposeTable"></asp:TextBox>
                            </td>
                            <td style="width: 80px">
                                <asp:TextBox ID="txtItemPrice" runat="server" ToolTip="单价" SkinID="PurposeTable"></asp:TextBox>
                            </td>
                            <td style="width: 80px">
                                <asp:TextBox ID="txtPlanNum" runat="server" ToolTip="应退数量" SkinID="PurposeTable"></asp:TextBox>
                            </td>
                            <td style="width: 80px">
                                <asp:TextBox ID="txtItemNum" CssClass="txtItemNum input" ToolTip="实退数量, 由收料人填写" runat="server"></asp:TextBox>
                            </td>
                            <td style="width: 80px">
                                <asp:TextBox ID="txtItemMoney" runat="server" ToolTip="金额" SkinID="PurposeTable"></asp:TextBox>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlCon" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td nowrap>
                                <asp:Button ID="btnUpdate" runat="server" Text="更新" OnClick="btnUpdate_Click"></asp:Button>
                                <asp:Button ID="btnDelete" runat="server" Text="删除" OnClick="btnDelete_Click"></asp:Button>
                                <asp:Button ID="btnEdit" runat="server" Text="修改" OnClick="btnEdit_Click"></asp:Button>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="10" style="width: 100%">
                                <mzh:MzhDataGrid ID="MzhDataGrid1" runat="server" AutoGenerateColumns="False" IdCell="0"
                                    selecttype="SingleSelect" MultiPageShowMode="DropListMode" 
                                    name="MzhMultiSelectDataGrid" onitemdatabound="MzhDataGrid1_ItemDataBound">
                                    <Columns>
                                        <asp:BoundColumn Visible="False" DataField="SerialNo" HeaderText="序号"></asp:BoundColumn>
                                        <asp:BoundColumn DataField="ItemCode" HeaderText="编号">
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="ItemName" HeaderText="名称">
                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="ItemSpecial" HeaderText="规格型号">
                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="ItemUnitName" HeaderText="单位">
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="ItemPrice" HeaderText="单价">
                                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="PlanNum" HeaderText="应退数量">
                                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="ItemNum" HeaderText="实退数量">
                                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="ItemMoney" HeaderText="金额">
                                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="ConName" HeaderText="架位">
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                                        </asp:BoundColumn>
                                    </Columns>
                                </mzh:MzhDataGrid>
                            </td>
                        </tr>
                        <tr style="height:20">
                            <td colspan="10" align="left">
                                备注：
                            </td>
                        </tr>
                        <tr>
                            <td colspan="10">
                                <asp:TextBox ID="txtRemark" runat="server"  SkinID="PurposeTable" TextMode="MultiLine" Rows="2"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr class="myTrDualLine">
                <td colspan="4">
                    <font face="宋体"></font><font face="宋体"></font><font face="宋体">
                        <uc1:DocAuditWebControl ID="DocAuditWebControl1" runat="server"></uc1:DocAuditWebControl>
                    </font>
                </td>
            </tr>
            <tr class="myTrDualLine">
                <td style="height: 24px" colspan="1">
                    <font face="宋体">制单人：</font>
                </td>
                <td style="width: 211px; height: 24px">
                    <asp:TextBox ID="TextBox1" SkinID="PurposeTable" ReadOnly="true" runat="server"></asp:TextBox>
                </td>
                <td style="height: 24px">
                    <font face="宋体">申请人：</font>
                </td>
                <td style="height: 24px">
                    <asp:TextBox ID="txtProposer"   runat="server" SkinID="PurposeTable"></asp:TextBox>
                </td>
            </tr>
            <tr class="myTrDualLine">
                <td>
                    <font face="宋体">收料人</font>
                </td>
                <td style="width: 211px">
                    <asp:TextBox ID="txtReceiver" runat="server" SkinID="PurposeTable" ReadOnly="True"></asp:TextBox>
                </td>
                <td>
                    <font face="宋体">收料日期</font>
                </td>
                <td>
                    <asp:TextBox ID="TextBox2" runat="server" ReadOnly="True" SkinID="PurposeTable"></asp:TextBox>
                </td>
            </tr>
            <tr >
                <td align="center" colspan="4">
                    <asp:Button ID="btnSave" runat="server" Text="保存" OnClick="btnSave_Click"></asp:Button>&nbsp;
                    <asp:Button ID="btnPresent" runat="server" Text="马上提交" OnClick="btnPresent_Click">
                    </asp:Button>&nbsp;<asp:Button ID="btnCancel" runat="server" Text="取消" OnClick="btnCancel_Click">
                    </asp:Button>
                </td>
            </tr>
        </tbody>
    </table>
    
    <asp:HiddenField ID="txtWDRWEntryNo" runat="server" />
    <div class="hidden">
        <asp:Button ID="btnMainInfo" runat="server" OnClick="btnMainInfo_Click" />
    </div>

    <script language="javascript" type="text/javascript">
            
            function document.all.<%=btnEdit.ClientID%>.onclick()
	        {
	            if(<%=MzhDataGrid1.ClientID%>_obj.getSelectedID()!=null&&<%=MzhDataGrid1.ClientID%>_obj.getSelectedID()!="")
	            {
        		    
		        }
		        else
		        {
			        alert("请先选中某一条记录，再进行编辑！");
			        return false;
		        }
	        }
        	
	        function document.all.<%=btnDelete.ClientID%>.onclick()
	        {
	            if(<%=MzhDataGrid1.ClientID%>_obj.getSelectedID()!=null&&<%=MzhDataGrid1.ClientID%>_obj.getSelectedID()!="")
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
	
			function GetCode()
			{
				return document.getElementById("<%=ddlDept.thisDDL.ClientID%>").value;
			}
			function OpenWDRWSource()
			{
				var left = (window.screen.width - 640)/2;
				var top = (window.screen.height - 440)/2;
				window.open("WDRWSourceBrowser.aspx?Op=View&DeptCode="+GetCode()+",'领料单查询','toolbar = no,location=no,directories=no,status=no,menubar=no,scrollbars=yes,resizable=yes,copyhistory=no,width =640,height = 440,left="+left+",top="+top);
			}
			function setMainInfo(id)	
			{
				document.getElementById("<%=txtWDRWEntryNo.ClientID%>").value=id;
				document.getElementById("<%=btnMainInfo.ClientID%>").click();	
			}
			
		
    </script>

</asp:Content>

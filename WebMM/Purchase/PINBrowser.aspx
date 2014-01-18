<%@ Page Language="c#" CodeBehind="PINBrowser.aspx.cs" MasterPageFile="~/Master/Default.Master"
    AutoEventWireup="True" Title="收料" Inherits="MZHMM.WebMM.Purchase.PINBrowser"   %>

<%@ MasterType VirtualPath="~/Master/Default.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>收料</title>
    <link href="../CSS/ManageCommon.css" type="text/css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="AjaxHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BodyHolder" runat="server">
    <table class="managertable">
        <tr>
            <td>
                <mzh:MzhToolbar ID="MzhToolbar1" runat="server" SEModuleID="MM-015" SkinID="ABC"
                  OnSEQuery_Click="MzhToolbar1_OnSEQuery_Click"   CheckBoxListRepeatColumns="5">
                    <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable"
                        itemid="new" cellspacing="0" nakedlabelclass="nakedLabelCell" isshowtext="True"
                        iconclass="in" hasicon="True" text="收料" id="toolbarButtonBOR" onclick="In(this.id)">
                    </mzh:toolbarbutton>
                </mzh:MzhToolbar>
                <asp:HiddenField ID="tb_SelectedArray" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <mzh:MzhDataGrid ID="DataGrid1" runat="server" name="MzhMultiSelectDataGrid" AutoGenerateColumns="False"
                    CssClass="datagrid" PageSize="16" AllowPaging="True" MultiPageShowMode="DropListMode"
                    SelectType="SingleSelect" ShowPageSize="true" AllowSorting="True" 
                    IdCell="0" onitemdatabound="DataGrid1_ItemDataBound">
                    <Columns>
                        <asp:BoundColumn Visible="False" DataField="PKID" HeaderText="PKID"></asp:BoundColumn>
                        <asp:BoundColumn DataField="EntryCode" SortExpression="EntryCode" HeaderText="单据编号">
                            <ItemStyle Width="70px"  />
                       </asp:BoundColumn>
                        <asp:BoundColumn DataField="DocName"  SortExpression="DocName" HeaderText="单据类型">
                            <ItemStyle Width="100px"  />
                            <FooterStyle Width="5%" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="EntryStateName" Visible="true" SortExpression="EntryStateName" HeaderText="状态">
                             
                             <FooterStyle Width="5%" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="EntryDate" SortExpression="EntryDate" HeaderText="创建日期"
                            DataFormatString="{0:yyyy-MM-dd}">
                            <ItemStyle HorizontalAlign="Center"  Width="80px" ></ItemStyle>
                             <FooterStyle Width="5%" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="PrvCode" Visible="false" SortExpression="PrvCode" HeaderText="供应商编号">
                             
                             <FooterStyle Width="5%" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="PrvName" SortExpression="PrvName" HeaderText="供应商名称">
                              <ItemStyle CssClass="left" HorizontalAlign="Left" />
                             <FooterStyle Width="5%" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="ItemSummary"  SortExpression="ItemSummary" HeaderText="物料摘要">
                             <ItemStyle CssClass="left" HorizontalAlign="Left" />
                             <FooterStyle Width="5%" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="StoName" SortExpression="StoName" HeaderText="接收仓库">
                             <ItemStyle Width="10%" />
                             <FooterStyle Width="5%" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="BuyerName" SortExpression="BuyerName" HeaderText="采购员">
                            <ItemStyle Width="80px"  />
                             <FooterStyle Width="6%" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="AcceptDate" Visible="false" SortExpression="AcceptDate" HeaderText="收料日期"
                            DataFormatString="{0:yyyy-MM-dd}">
                            
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                             <FooterStyle Width="6%" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="SubTotal" SortExpression="SubTotal" HeaderText="总金额">
                            <ItemStyle HorizontalAlign="Right" Width="80px"></ItemStyle>
                             <FooterStyle Width="6%" />
                        </asp:BoundColumn>
                    </Columns>
                </mzh:MzhDataGrid>
            </td>
        </tr>
    </table>

    <script language="javascript" type="text/javascript">
		//收料。
		function In(elmId)
		{
			if(<%=DataGrid1.ClientID%>_obj.getSelectedID()!=null&&<%=DataGrid1.ClientID%>_obj.getSelectedID()!="")
			{
				var ID;
				var DocCode;
				var EntryNo;
				if (<%=DataGrid1.ClientID%>_obj.getSelectedID() != null)
				{
					ID = <%=DataGrid1.ClientID%>_obj.getSelectedID();
					EntryNo = ID.substring(0,ID.indexOf('|'));
					DocCode = ID.substring(ID.indexOf('|')+1);
						
					if (DocCode == "6")
					{
						document.location="PBORInput.aspx?Op=In&EntryNo="+EntryNo;
					}
					else if (DocCode == "7")
					{
						document.location="PRTVInput.aspx?Op=In&EntryNo="+EntryNo;
					}
					else if (DocCode == "8")
					{
						document.location="../Storage/RTSInput.aspx?Op=In&EntryNo="+EntryNo;
					}
					else if (DocCode == "17")
					{
						document.location="../Storage/WINWInput.aspx?Op=In&EntryNo="+EntryNo;
					}
                    else if (DocCode == "19")
                    {
                        var popupWindow = new PopupWindow();
                        popupWindow.setSize(900, 600);
                        popupWindow.setUrl("../Storage/InventoryProfitInput.aspx?OP=In&EntryNo=" + EntryNo);
                        popupWindow.showPopup(elmId, false);
                    }
				}
			}
			else
			{
				alert("请先选中某一条记录，再进行操作！");
			}					
		}
        function refresh(){
            document.loaction = document.location;
        }
    </script>

</asp:Content>

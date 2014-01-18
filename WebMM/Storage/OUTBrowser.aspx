<%@ Page Language="c#" CodeBehind="OUTBrowser.aspx.cs"  Title="发料" MasterPageFile="~/Master/Default.Master"
    AutoEventWireup="True" Inherits="MZHMM.WebMM.Storage.OUTBrowser"  %>

<%@ MasterType VirtualPath="~/Master/Default.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>发料</title>
    <meta name="keywords" content="领料单" />
    <link href="../CSS/ManageCommon.css" type="text/css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="AjaxHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BodyHolder" runat="server">
    <table class="managertable">
        <tr>
            <td class="td_toolbar">
                <mzh:MzhToolbar ID="MzhToolbar1" runat="server" SEModuleID="MM-016" SkinID="ABC"
                  OnSEQuery_Click="MzhToolbar1_OnSEQuery_Click"   CheckBoxListRepeatColumns="5" >
                    <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable"
                        itemid="new" cellspacing="0" nakedlabelclass="nakedLabelCell" isshowtext="True"
                        iconclass="out" hasicon="True" text="发料" id="toolbarButtonOut" onclick="Draw()">
                    </mzh:toolbarbutton>
                </mzh:MzhToolbar>
                <asp:HiddenField ID="tb_SelectedArray" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <mzh:MzhDataGrid ID="DataGrid1" runat="server" AllowPaging="True" PageSize="16" name="MzhMultiSelectDataGrid"
                    MultiPageShowMode="DropListMode" AutoGenerateColumns="False" 
                    SelectType="SingleSelect"  ShowPageSize="true"
                    AllowSorting="True" IdCell="0" onitemdatabound="DataGrid1_ItemDataBound">
                    <Columns>
                        <asp:BoundColumn Visible="False" DataField="PKID" HeaderText="PKID"></asp:BoundColumn>
                        <asp:BoundColumn DataField="DocName" SortExpression="DocName" HeaderText="单据类型">
                            <HeaderStyle Width="80px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="EntryCode" SortExpression="EntryCode" HeaderText="单据编号">
                            <ItemStyle Width="80px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="EntryStateName" SortExpression="EntryStateName" HeaderText="状态">
                             <ItemStyle Width="50px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="ItemSummary" SortExpression="ItemSummary" HeaderText="物料摘要">
                             <ItemStyle Width="80px" CssClass="left" HorizontalAlign="Left" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="EntryDate" SortExpression="EntryDate" HeaderText="申请日期"
                            DataFormatString="{0:yyyy-MM-dd}">
                            <ItemStyle HorizontalAlign="Center" Width="80px"></ItemStyle>
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="AuthorName" SortExpression="AuthorName" HeaderText="填写人">
                            <ItemStyle HorizontalAlign="Center" Width="80px"></ItemStyle>
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="AuthorDeptName" SortExpression="AuthorDeptName" HeaderText="填写部门">
                            <ItemStyle Width="100px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="ReqReason" SortExpression="ReqReason" HeaderText="申请理由">
                            <ItemStyle CssClass="left" HorizontalAlign="Left" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="SubTotal" SortExpression="SubTotal" HeaderText="总金额">
                             <ItemStyle HorizontalAlign="Right" Width="80px"></ItemStyle>
                        </asp:BoundColumn>
                    </Columns>
                </mzh:MzhDataGrid>
            </td>
        </tr>
    </table>

    <script language="javascript" type="text/javascript">
			
			//发料。
			function Draw()
			{
				var ID;
				var EntryNo;
				var DocCode;
				if (<%=DataGrid1.ClientID%>_obj.getSelectedID() != null)
				{
					ID = <%=DataGrid1.ClientID%>_obj.getSelectedID();
					EntryNo = ID.substring(0,ID.indexOf('|'));
					DocCode = ID.substring(ID.indexOf('|')+1);
					if (DocCode == 4)//领料单 。
					{
						document.location="DRWInput.aspx?Op=Out&EntryNo="+EntryNo;
					}
					else if (DocCode == 8)//生产退料单。
					{
						document.location="RTSInput.aspx?Op=Out&EntryNo="+EntryNo;
					}
					else if (DocCode == 10)//转库单。
					{
						document.location="TRFInput.aspx?Op=Out&EntryNo="+EntryNo;
					}
					else if (DocCode == 11)//报废单。					
					{
						document.location="SCRInput.aspx?Op=Discard&EntryNo="+EntryNo;
					}
					else if (DocCode == 7)//退货单。					
					{
						document.location="../Purchase/PRTVInput.aspx?Op=In&EntryNo="+EntryNo;
					}
                    else if(DocCode == 20)//盘亏单
                    {
                        document.location="InventoryShortageInput.aspx?OP=Out&EntryNo="+EntryNo;
                    }
				}
				else
				{
					alert("请先选中某一条记录，再进行操作！");
				}					
			}
    </script>

</asp:Content>

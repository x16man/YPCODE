<%@ Page Language="c#" CodeBehind="PINBrowser.aspx.cs" MasterPageFile="~/Master/Default.Master"
    AutoEventWireup="True" Title="����" Inherits="MZHMM.WebMM.Purchase.PINBrowser"   %>

<%@ MasterType VirtualPath="~/Master/Default.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>����</title>
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
                        iconclass="in" hasicon="True" text="����" id="toolbarButtonBOR" onclick="In(this.id)">
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
                        <asp:BoundColumn DataField="EntryCode" SortExpression="EntryCode" HeaderText="���ݱ��">
                            <ItemStyle Width="70px"  />
                       </asp:BoundColumn>
                        <asp:BoundColumn DataField="DocName"  SortExpression="DocName" HeaderText="��������">
                            <ItemStyle Width="100px"  />
                            <FooterStyle Width="5%" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="EntryStateName" Visible="true" SortExpression="EntryStateName" HeaderText="״̬">
                             
                             <FooterStyle Width="5%" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="EntryDate" SortExpression="EntryDate" HeaderText="��������"
                            DataFormatString="{0:yyyy-MM-dd}">
                            <ItemStyle HorizontalAlign="Center"  Width="80px" ></ItemStyle>
                             <FooterStyle Width="5%" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="PrvCode" Visible="false" SortExpression="PrvCode" HeaderText="��Ӧ�̱��">
                             
                             <FooterStyle Width="5%" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="PrvName" SortExpression="PrvName" HeaderText="��Ӧ������">
                              <ItemStyle CssClass="left" HorizontalAlign="Left" />
                             <FooterStyle Width="5%" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="ItemSummary"  SortExpression="ItemSummary" HeaderText="����ժҪ">
                             <ItemStyle CssClass="left" HorizontalAlign="Left" />
                             <FooterStyle Width="5%" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="StoName" SortExpression="StoName" HeaderText="���ղֿ�">
                             <ItemStyle Width="10%" />
                             <FooterStyle Width="5%" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="BuyerName" SortExpression="BuyerName" HeaderText="�ɹ�Ա">
                            <ItemStyle Width="80px"  />
                             <FooterStyle Width="6%" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="AcceptDate" Visible="false" SortExpression="AcceptDate" HeaderText="��������"
                            DataFormatString="{0:yyyy-MM-dd}">
                            
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                             <FooterStyle Width="6%" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="SubTotal" SortExpression="SubTotal" HeaderText="�ܽ��">
                            <ItemStyle HorizontalAlign="Right" Width="80px"></ItemStyle>
                             <FooterStyle Width="6%" />
                        </asp:BoundColumn>
                    </Columns>
                </mzh:MzhDataGrid>
            </td>
        </tr>
    </table>

    <script language="javascript" type="text/javascript">
		//���ϡ�
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
				alert("����ѡ��ĳһ����¼���ٽ��в�����");
			}					
		}
        function refresh(){
            document.loaction = document.location;
        }
    </script>

</asp:Content>

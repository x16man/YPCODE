<%@ Page Language="c#" CodeBehind="PCBRSource.aspx.cs" MasterPageFile="~/Master/Default.Master"
    AutoEventWireup="True" Inherits="MZHMM.WebMM.Purchase.PCBRSource" %>

<%@ MasterType VirtualPath="~/Master/Default.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>���ϵ����</title>
    <link href="../CSS/ManageCommon.css" type="text/css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="AjaxHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BodyHolder" runat="server">
    <table class="managertable">
        <tr style="height:30px">
            <td  align="left">
                <mzh:MzhToolbar ID="MzhToolbar1" runat="server">
                  <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable"
                        itemid="Edit" cellspacing="0" nakedlabelclass="nakedLabelCell" isshowtext="True"
                        iconclass="present" hasicon="True" text="ѡȡ" id="toolbarButtonFirstAudit" onclick="SetCode()">
                    </mzh:toolbarbutton>
                 </mzh:MzhToolbar>
               
                <a onclick="SubmitItem()" href="#"></a><a onclick="editItem()" href="#"></a><a onclick="deleteItems()"
                    href="#"></a><a onclick="CancelItem()" href="#"></a><a onclick="FirstAudit()" href="#">
                    </a><a onclick="SecondAudit()" href="#"></a><a onclick="ThirdAudit()" href="#">
                </a>
                <div class="hidden">
                    <asp:HiddenField ID="tb_SelectedArray" runat="server" />
                    <asp:Button ID="btn_delete" runat="server" Text="ɾ��" OnClick="btn_delete_Click">
                    </asp:Button>
                    <asp:Button ID="btn_cancel" runat="server" Text="����" OnClick="btn_cancel_Click">
                    </asp:Button>
                    <asp:Button ID="btn_Submit" runat="server" Text="�ύ" OnClick="btn_Submit_Click">
                    </asp:Button>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <mzh:MzhDataGrid ID="DataGrid1" runat="server" AllowPaging="True" PageSize="16" AutoGenerateColumns="False"
                    name="MzhMultiSelectDataGrid" SelectType="SingleSelect" MultiPageShowMode="DropListMode"
                    IdCell="0">
                    <Columns>
                        <asp:BoundColumn DataField="PKID" Visible="false" HeaderText="EntryNo"></asp:BoundColumn>
                        <asp:BoundColumn DataField="EntryCode" HeaderText="���ݱ��"></asp:BoundColumn>
                        <asp:BoundColumn DataField="EntryDate" HeaderText="��������" DataFormatString="{0:yyyy-MM-dd}">
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="PrvCode" HeaderText="��Ӧ�̱��"></asp:BoundColumn>
                        <asp:BoundColumn DataField="PrvName" HeaderText="��Ӧ������"></asp:BoundColumn>
                        <asp:BoundColumn DataField="BuyerName" HeaderText="�ɹ�Ա"></asp:BoundColumn>
                        <asp:BoundColumn DataField="AcceptDate" HeaderText="��������" DataFormatString="{0:yyyy-MM-dd}">
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="SubTotal" HeaderText="�ܽ��">
                            <ItemStyle HorizontalAlign="Right"></ItemStyle>
                        </asp:BoundColumn>
                         <asp:BoundColumn DataField="StoName" Visible="false"></asp:BoundColumn>
                    </Columns>
                </mzh:MzhDataGrid>
            </td>
        </tr>
    </table>

    <script language="javascript" type="text/javascript">
		
			function SetCode()
			{
				if(<%=DataGrid1.ClientID%>_obj.getSelectedArray()!=null && <%=DataGrid1.ClientID%>_obj.getSelectedArray()!="")
				{
					window.opener.setEntry(<%=DataGrid1.ClientID%>_obj.getSelectedArray());
					window.close();
				}
			}
    </script>

</asp:Content>

<%@ Page Language="c#" CodeBehind="WRES_SRCBrowser.aspx.cs" AutoEventWireup="True"
    MasterPageFile="~/Master/Default.Master" Inherits="MZHMM.WebMM.Storage.WRES_SRCBrowser" %>

<%@ MasterType VirtualPath="~/Master/Default.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>ί��ӹ����뵥ѡ��</title>
    <meta name="keywords" content="ί��ӹ����ϵ�" />
    <link href="../CSS/ManageCommon.css" type="text/css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="AjaxHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BodyHolder" runat="server">
    <table class="managertable">
        <tr >
            <td style="border-right: #ffcc33 1px solid; border-top: #ffcc33 1px solid; border-left: #ffcc33 1px solid;
                border-bottom: #ffcc33 1px solid; height: 26px; background-color: #ffffcc" height="26" align='left'>
                <mzh:MzhToolbar ID="MzhToolbar1" runat="server">
                  <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable"
                        itemid="Edit" cellspacing="0" nakedlabelclass="nakedLabelCell" isshowtext="True"
                        iconclass="present" hasicon="True" text="ѡ��" id="toolbarButtonFirstAudit" onclick="newItem()">
                    </mzh:toolbarbutton>
                 </mzh:MzhToolbar>
                 
                
                <asp:HiddenField ID="tb_SelectedArray" runat="server" />
                <div class="hidden">
                     <asp:Button ID="btn_Submit" runat="server" Text="�ύ" Width="0px"></asp:Button>
                </div>
               
            </td>
        </tr>
        <tr>
            <td>
                <mzh:MzhDataGrid ID="DataGrid1" runat="server" AllowPaging="True" PageSize="20" MultiPageShowMode="DropListMode"
                    name="MzhMultiSelectDataGrid" AutoGenerateColumns="False" SelectType="MultiSelect"
                    AllowSorting="True" IdCell="0">
                    <Columns>
                        <asp:BoundColumn Visible="False" DataField="EntryNo" HeaderText="EntryNo"></asp:BoundColumn>
                        <asp:BoundColumn DataField="EntryCode" SortExpression="EntryCode" HeaderText="���">
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="ReqReason" SortExpression="ReqReason" HeaderText="��������">
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="EntryDate" SortExpression="EntryDate" HeaderText="����"
                            DataFormatString="{0:d}">
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="AuthorDeptName" SortExpression="AuthorDeptName" HeaderText="��д����">
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="SubTotal" SortExpression="SubTotal" HeaderText="�ܽ��">
                            <ItemStyle HorizontalAlign="Right"></ItemStyle>
                        </asp:BoundColumn>
                    </Columns>
                </mzh:MzhDataGrid>
            </td>
        </tr>
    </table>

    <script language="javascript" type="text/javascript">
        //����
        function newItem() {
            window.opener.SetEntry(<%=DataGrid1.ClientID%>_obj.getSelectedArray());
            window.close();
        }
    </script>

</asp:Content>

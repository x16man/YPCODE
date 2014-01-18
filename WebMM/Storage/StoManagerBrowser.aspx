<%@ Page Language="c#" CodeBehind="StoManagerBrowser.aspx.cs" Title="�ֿ����Ա" MasterPageFile="~/Master/Default.Master"
    AutoEventWireup="True" Inherits="MZHMM.WebMM.Storage.StoManagerBrowser" %>

<%@ MasterType VirtualPath="~/Master/Default.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>�ֿ����Ա</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="AjaxHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BodyHolder" runat="server">
    <table id="Table1" cellspacing="0" class="table_toolbar" width="100%">
        <tr>
            <td class="td_toolbar">
                <mzh:MzhToolbar ID="MzhToolbar1" runat="server">
                    <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable"
                        itemid="new" cellspacing="0" nakedlabelclass="nakedLabelCell" isshowtext="True"
                        iconclass="add" hasicon="True" text="�½�" id="toolbarButtonadd" onclick="addItem()">
                    </mzh:toolbarbutton>
                    <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable"
                        itemid="Edit" cellspacing="0" nakedlabelclass="nakedLabelCell" isshowtext="True"
                        iconclass="edit" hasicon="True" text="�༭" id="toolbarButtonedit" onclick="editItem()">
                    </mzh:toolbarbutton>
                    <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable"
                        itemid="Edit" cellspacing="0" nakedlabelclass="nakedLabelCell" isshowtext="True"
                        iconclass="delete" hasicon="True" text="ɾ��" id="toolbarButtondelete" onclick="deleteItems()">
                    </mzh:toolbarbutton>
                </mzh:MzhToolbar>
            </td>
        </tr>
        <tr>
            <td>
                <mzh:MzhDataGrid ID="DataGrid1" name="MzhMultiSelectDataGrid" runat="server" IdCell="0"
                    AllowSorting="True" SelectType="SingleSelect" MultiPageShowMode="DropListMode" ShowPageSize="true"
                    AllowPaging="true" AutoGenerateColumns="False" PageSize="<%$ AppSettings:pageSize %>"
                    OnSortCommand="DataGrid1_SortCommand">
                    <Columns>
                        <asp:BoundColumn Visible="False" DataField="PKID" HeaderText="PKID"></asp:BoundColumn>
                        <asp:BoundColumn DataField="StoCode" HeaderText="�ֿ���"></asp:BoundColumn>
                        <asp:BoundColumn DataField="StoName" HeaderText="�ֿ�����"></asp:BoundColumn>
                        <asp:BoundColumn DataField="UserCode" HeaderText="����Ա���"></asp:BoundColumn>
                        <asp:BoundColumn DataField="UserName" HeaderText="����Ա����"></asp:BoundColumn>
                        <asp:BoundColumn DataField="DeptCode" HeaderText="�������ű��"></asp:BoundColumn>
                        <asp:BoundColumn DataField="DeptName" HeaderText="������������"></asp:BoundColumn>
                    </Columns>
                </mzh:MzhDataGrid>
            </td>
        </tr>
    </table>
    <asp:HiddenField ID="txtStoCode" runat="server" />
    <asp:HiddenField ID="tb_SelectedArray" runat="server" />
    <div class="hidden">
        <asp:Button ID="btn_delete" runat="server" Text="ɾ��" OnClick="btn_delete_Click">
        </asp:Button>
        <asp:Button ID="btn_refresh" runat="server" Text="ˢ��"></asp:Button>
    </div>

    <script language="javascript" type="text/javascript">
        
        //�½�
        function addItem() {
            document.location = "StoManagerInput.aspx?StoCode=" + document.getElementById("<%=txtStoCode.ClientID%>").value;
        }
        //�༭
        function editItem() {
            if (<%=DataGrid1.ClientID%>_obj.getSelectedID() != null && <%=DataGrid1.ClientID%>_obj.getSelectedID() != "") {
                if (<%=DataGrid1.ClientID%>_obj.getSelectedID() != -1) {
                    document.location = "StoManagerInput.aspx?Op=Edit&Code=" + <%=DataGrid1.ClientID%>_obj.getSelectedID();
                }
            }
            else {
                alert("����ѡ��ĳһ����¼���ٽ��б༭��");
            }
        }

        //ɾ��
        function deleteItems() {
            if (<%=DataGrid1.ClientID%>_obj.getSelectedArray() != null && <%=DataGrid1.ClientID%>_obj.getSelectedArray() != "") {
                if (confirm("ȷ��Ҫɾ��ѡ�������ݣ�")) {
                    document.getElementById("<%=tb_SelectedArray.ClientID%>").value = <%=DataGrid1.ClientID%>_obj.getSelectedArray();
                    document.getElementById("<%=btn_delete.ClientID%>").click();
                }
            }
            else {
                alert("����ѡ�м�¼���ٽ���ɾ����");
            }
        }

        //����
        function copyItem() {
            if (<%=DataGrid1.ClientID%>_obj.getSelectedID() != null && <%=DataGrid1.ClientID%>_obj.getSelectedID() != "") {
                if (getSelectedID() != -1) {
                    document.location = "StoManagerInput.aspx?Op=Copy&Code=" + <%=DataGrid1.ClientID%>_obj.getSelectedID();
                }
            }
            else {
                alert("����ѡ��ĳһ����¼���ٽ��и��ƣ�");
            }
        }
    </script>

</asp:Content>

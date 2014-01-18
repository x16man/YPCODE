<%@ Page Language="c#" CodeBehind="CategroyBrowser.aspx.cs" Title="���Ϸ���" MasterPageFile="~/Master/Default.Master"
    AutoEventWireup="True" Inherits="MZHMM.WebMM.Storage.CategroyBrowser" %>

<%@ MasterType VirtualPath="~/Master/Default.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>���Ϸ���</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="AjaxHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BodyHolder" runat="server">
    <table id="Table1" cellspacing="0" width="100%">
        <tr>
            <td>
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
                        iconclass="icon" hasicon="True" text="����" id="toolbarButtoncopy" onclick="copyItem()">
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
                <mzh:MzhDataGrid ID="DataGrid1" name="MzhMultiSelectDataGrid" runat="server" PageSize="<%$ AppSettings:pageSize %>"
                     IdCell="0" AllowSorting="true" ShowPageSize="true"
                    SelectType="SingleSelect" MultiPageShowMode="DropListMode" 
                     AllowPaging="true"  AutoGenerateColumns="False"
                    OnItemDataBound="DataGrid1_ItemDataBound" OnPageIndexChanged="DataGrid1_PageIndexChanged"
                    OnSortCommand="DataGrid1_SortCommand">
                    <Columns>
                        <asp:BoundColumn Visible="False" DataField="Code" HeaderText="Code"></asp:BoundColumn>
                        <asp:BoundColumn DataField="Code" HeaderText="������"></asp:BoundColumn>
                        <asp:BoundColumn DataField="Description" HeaderText="��������"></asp:BoundColumn>
                        <asp:BoundColumn DataField="StorageAcc" HeaderText="����Ŀ"></asp:BoundColumn>
                        <asp:BoundColumn DataField="TransferAcc" HeaderText="ת�ʿ�Ŀ"></asp:BoundColumn>
                        <asp:BoundColumn DataField="ReturnAcc" HeaderText="�˻���Ŀ"></asp:BoundColumn>
                        <asp:BoundColumn DataField="Serial" HeaderText="��ʾ����"></asp:BoundColumn>
                    </Columns>
                </mzh:MzhDataGrid>
            </td>
        </tr>
    </table>
    <div class="hidden">
        <asp:Button ID="btn_delete" runat="server" Text="ɾ��" OnClick="btn_delete_Click">
        </asp:Button>
        <asp:HiddenField ID="tb_SelectedArray" runat="server" />
        <asp:Button ID="btn_refresh" runat="server" Text="ˢ��"></asp:Button>
    </div>

    <script language="javascript" type="text/javascript">
            //�½�
			function addItem()
			{
			    
			        document.location="CategroyInput.aspx";	
			    				
			}

        //�༭
        function editItem() {
            if (<%=DataGrid1.ClientID%>_obj.getSelectedID() != null && <%=DataGrid1.ClientID%>_obj.getSelectedID() != "") {
                if (<%=DataGrid1.ClientID%>_obj.getSelectedID() != -1) {
                    document.location = "CategroyInput.aspx?Op=Edit&Code=" + <%=DataGrid1.ClientID%>_obj.getSelectedID();
                }
                else
                {
                    alert("�÷���Ϊϵͳ�����޷�������б༭������");
                }
            }
            else {
                alert("����ѡ��ĳһ����¼���ٽ��б༭��");
            }
        }

        //ɾ��
        function deleteItems() {
            if (<%=DataGrid1.ClientID%>_obj.getSelectedArray() != null && <%=DataGrid1.ClientID%>_obj.getSelectedArray() != "") {
                if (<%=DataGrid1.ClientID%>_obj.getSelectedID() != -1) {
                    if (confirm("ȷ��Ҫɾ��ѡ�������ݣ�")) {
                        document.getElementById("<%=tb_SelectedArray.ClientID%>").value = <%=DataGrid1.ClientID%>_obj.getSelectedArray();
                        document.getElementById("<%=btn_delete.ClientID%>").click();
                    }
                }
                else
                {
                    alert("�÷���Ϊϵͳ�����޷��������ɾ��������");
                }
            }
            else {
                alert("����ѡ�м�¼���ٽ���ɾ����");
            }
        }

        //����
        function copyItem() {
            if (<%=DataGrid1.ClientID%>_obj.getSelectedID() != null && <%=DataGrid1.ClientID%>_obj.getSelectedID() != "") {
                if (<%=DataGrid1.ClientID%>_obj.getSelectedID() != -1) {
                    document.location = "CategroyInput.aspx?Op=Copy&Code=" + <%=DataGrid1.ClientID%>_obj.getSelectedID();
                }
                else {
                    alert("�÷���Ϊϵͳ�����޷�������и��Ʋ�����");
                }
            }
            else {
                alert("����ѡ��ĳһ����¼���ٽ��и��ƣ�");
            }
        }
    </script>

</asp:Content>

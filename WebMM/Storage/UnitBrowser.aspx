<%@ Page Language="c#" CodeBehind="UnitBrowser.aspx.cs" Title="������λ" MasterPageFile="~/Master/Default.Master"
    AutoEventWireup="True" Inherits="MZHMM.WebMM.Storage.UnitBrowser" %>

<%@ MasterType VirtualPath="~/Master/Default.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>������λ</title>
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
                <mzh:MzhDataGrid ID="DataGrid1" name="MzhMultiSelectDataGrid" runat="server" HighLightColor="Gold"
                    IdCell="0" AllowSorting="True" SelectType="SingleSelect" MultiPageShowMode="DropListMode"
                    CellPadding="3" BorderWidth="1px" CellSpacing="1" AllowPaging="true"   ShowPageSize="true"
                    AutoGenerateColumns="False" PageSize="<%$ AppSettings:pageSize %>" OnPageIndexChanged="DataGrid1_PageIndexChanged"
                    OnSortCommand="DataGrid1_SortCommand">
                    <Columns>
                        <asp:BoundColumn Visible="False" DataField="Code" HeaderText="Code"></asp:BoundColumn>
                        <asp:BoundColumn DataField="Code" HeaderText="��λ���"></asp:BoundColumn>
                        <asp:BoundColumn DataField="Description" HeaderText="��λ����"></asp:BoundColumn>
                        <asp:BoundColumn DataField="Abbreviate" HeaderText="��д"></asp:BoundColumn>
                        <asp:BoundColumn DataField="Equivalence" HeaderText="��ֵ(��С��λ)" DataFormatString="{0:0.######}">
                            <ItemStyle HorizontalAlign="Right"></ItemStyle>
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Conversion" HeaderText="����(China)" DataFormatString="{0:0.######}">
                            <ItemStyle HorizontalAlign="Right"></ItemStyle>
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="ConUnit" HeaderText="���㵥λ"></asp:BoundColumn>
                        <asp:BoundColumn DataField="UnitType" HeaderText="����"></asp:BoundColumn>
                    </Columns>
                </mzh:MzhDataGrid>
            </td>
        </tr>
    </table>
    <asp:HiddenField ID="tb_SelectedArray" runat="server" />
    <div class="hidden">
        <asp:Button ID="btn_delete" runat="server" Text="ɾ��" OnClick="btn_delete_Click">
        </asp:Button>
        <asp:Button ID="btn_refresh" runat="server" Text="ˢ��"></asp:Button>
    </div>

    <script language="javascript" type="text/javascript">

        //�½�
        function addItem() {

            document.location = "UnitInput.aspx";

        }
    
        //�༭
        function editItem() {
            if (<%=DataGrid1.ClientID%>_obj.getSelectedID() != null && <%=DataGrid1.ClientID%>_obj.getSelectedID() != "") {
                if (<%=DataGrid1.ClientID%>_obj.getSelectedID() != -1) {
                    document.location = "UnitInput.aspx?Op=Edit&Code=" + <%=DataGrid1.ClientID%>_obj.getSelectedID();
                }
                else {
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
                else {
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
                    document.location = "UnitInput.aspx?Op=Copy&Code=" + <%=DataGrid1.ClientID%>_obj.getSelectedID();
                }else {
                    alert("�÷���Ϊϵͳ�����޷�������и��Ʋ�����");
                }
            }
            else {
                alert("����ѡ��ĳһ����¼���ٽ��и��ƣ�");
            }
        }
    </script>

</asp:Content>

<%@ Page Language="c#" CodeBehind="StoManagerBrowser.aspx.cs" Title="仓库管理员" MasterPageFile="~/Master/Default.Master"
    AutoEventWireup="True" Inherits="MZHMM.WebMM.Storage.StoManagerBrowser" %>

<%@ MasterType VirtualPath="~/Master/Default.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>仓库管理员</title>
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
                        iconclass="add" hasicon="True" text="新建" id="toolbarButtonadd" onclick="addItem()">
                    </mzh:toolbarbutton>
                    <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable"
                        itemid="Edit" cellspacing="0" nakedlabelclass="nakedLabelCell" isshowtext="True"
                        iconclass="edit" hasicon="True" text="编辑" id="toolbarButtonedit" onclick="editItem()">
                    </mzh:toolbarbutton>
                    <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable"
                        itemid="Edit" cellspacing="0" nakedlabelclass="nakedLabelCell" isshowtext="True"
                        iconclass="delete" hasicon="True" text="删除" id="toolbarButtondelete" onclick="deleteItems()">
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
                        <asp:BoundColumn DataField="StoCode" HeaderText="仓库编号"></asp:BoundColumn>
                        <asp:BoundColumn DataField="StoName" HeaderText="仓库描述"></asp:BoundColumn>
                        <asp:BoundColumn DataField="UserCode" HeaderText="管理员编号"></asp:BoundColumn>
                        <asp:BoundColumn DataField="UserName" HeaderText="管理员名称"></asp:BoundColumn>
                        <asp:BoundColumn DataField="DeptCode" HeaderText="所属部门编号"></asp:BoundColumn>
                        <asp:BoundColumn DataField="DeptName" HeaderText="所属部门名称"></asp:BoundColumn>
                    </Columns>
                </mzh:MzhDataGrid>
            </td>
        </tr>
    </table>
    <asp:HiddenField ID="txtStoCode" runat="server" />
    <asp:HiddenField ID="tb_SelectedArray" runat="server" />
    <div class="hidden">
        <asp:Button ID="btn_delete" runat="server" Text="删除" OnClick="btn_delete_Click">
        </asp:Button>
        <asp:Button ID="btn_refresh" runat="server" Text="刷新"></asp:Button>
    </div>

    <script language="javascript" type="text/javascript">
        
        //新建
        function addItem() {
            document.location = "StoManagerInput.aspx?StoCode=" + document.getElementById("<%=txtStoCode.ClientID%>").value;
        }
        //编辑
        function editItem() {
            if (<%=DataGrid1.ClientID%>_obj.getSelectedID() != null && <%=DataGrid1.ClientID%>_obj.getSelectedID() != "") {
                if (<%=DataGrid1.ClientID%>_obj.getSelectedID() != -1) {
                    document.location = "StoManagerInput.aspx?Op=Edit&Code=" + <%=DataGrid1.ClientID%>_obj.getSelectedID();
                }
            }
            else {
                alert("请先选中某一条记录，再进行编辑！");
            }
        }

        //删除
        function deleteItems() {
            if (<%=DataGrid1.ClientID%>_obj.getSelectedArray() != null && <%=DataGrid1.ClientID%>_obj.getSelectedArray() != "") {
                if (confirm("确认要删除选定的内容？")) {
                    document.getElementById("<%=tb_SelectedArray.ClientID%>").value = <%=DataGrid1.ClientID%>_obj.getSelectedArray();
                    document.getElementById("<%=btn_delete.ClientID%>").click();
                }
            }
            else {
                alert("请先选中记录，再进行删除！");
            }
        }

        //复制
        function copyItem() {
            if (<%=DataGrid1.ClientID%>_obj.getSelectedID() != null && <%=DataGrid1.ClientID%>_obj.getSelectedID() != "") {
                if (getSelectedID() != -1) {
                    document.location = "StoManagerInput.aspx?Op=Copy&Code=" + <%=DataGrid1.ClientID%>_obj.getSelectedID();
                }
            }
            else {
                alert("请先选中某一条记录，再进行复制！");
            }
        }
    </script>

</asp:Content>

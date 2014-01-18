<%@ Page Language="c#" CodeBehind="StoConBrowser.aspx.cs" Title="仓库架位信息列表" AutoEventWireup="True"
    MasterPageFile="~/Master/Default.Master" Inherits="MZHMM.WebMM.Storage.StoConBrowser" %>

<%@ MasterType VirtualPath="~/Master/Default.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>仓库架位信息列表</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="AjaxHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BodyHolder" runat="server">
    <table id="Table1" cellspacing="0" cellpadding="0" width="98%" align="center" border="0">
        <tr>
            <td>
                <mzh:MzhToolbar ID="MzhToolbar1" runat="server">
                    <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable"
                        itemid="new" cellspacing="0" nakedlabelclass="nakedLabelCell" isshowtext="True"
                        iconclass="add" hasicon="True" text="新建架位" id="toolbarButtonadd" onclick="addItem()">
                    </mzh:toolbarbutton>
                    <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable"
                        itemid="Edit" cellspacing="0" nakedlabelclass="nakedLabelCell" isshowtext="True"
                        iconclass="edit" hasicon="True" text="编辑" id="toolbarButtonedit" onclick="editItem()">
                    </mzh:toolbarbutton>
                    <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable"
                        itemid="Edit" cellspacing="0" nakedlabelclass="nakedLabelCell" isshowtext="True"
                        iconclass="icon" hasicon="True" text="复制" id="toolbarButtoncopy" onclick="copyItem()">
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
                    AllowSorting="True" SelectType="SingleSelect" MultiPageShowMode="DropListMode" ShowPageSize = "true"
                    AllowPaging="true" AutoGenerateColumns="False" PageSize="<%$ AppSettings:pageSize %>"
                    >
                    <Columns>
                        <asp:BoundColumn Visible="False" DataField="Code" HeaderText="Code"></asp:BoundColumn>
                        <asp:BoundColumn DataField="Description" HeaderText="架位名称"></asp:BoundColumn>
                        <asp:BoundColumn DataField="StoCode" HeaderText="所属仓库编号"></asp:BoundColumn>
                        <asp:BoundColumn DataField="Area" HeaderText="面积"></asp:BoundColumn>
                    </Columns>
                </mzh:MzhDataGrid>
            </td>
        </tr>
    </table>
    <div class="hidden">
        <asp:Button ID="btn_delete" runat="server" Text="删除" Width="0px" OnClick="btn_delete_Click">
        </asp:Button><asp:TextBox ID="tb_SelectedArray" runat="server" Width="0px"></asp:TextBox><asp:Button
            ID="btn_refresh" runat="server" Text="刷新" Width="0px"></asp:Button>
    </div>

    <script language="javascript" type="text/javascript">

        //新建
        function addItem() {

            document.location = "StoConInput.aspx?StoCode=<%= Master.StoCode%>";

        }

        //编辑
        function editItem() {
            if (<%=DataGrid1.ClientID%>_obj.getSelectedID() != null && <%=DataGrid1.ClientID%>_obj.getSelectedID() != "") {
                if (<%=DataGrid1.ClientID%>_obj.getSelectedID() != -1) {
                    document.location = "StoConInput.aspx?Op=Edit&Code=" + <%=DataGrid1.ClientID%>_obj.getSelectedID() + "&StoCode=<%=Master.StoCode%>";
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
                if (<%=DataGrid1.ClientID%>_obj.getSelectedID() != -1) {
                    document.location = "StoConInput.aspx?Op=Copy&Code=" + <%=DataGrid1.ClientID%>_obj.getSelectedID() + "&StoCode=<%=Master.StoCode%>";
                }
            }
            else {
                alert("请先选中某一条记录，再进行复制！");
            }
        }
    </script>

</asp:Content>

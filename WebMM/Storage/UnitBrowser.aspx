<%@ Page Language="c#" CodeBehind="UnitBrowser.aspx.cs" Title="度量单位" MasterPageFile="~/Master/Default.Master"
    AutoEventWireup="True" Inherits="MZHMM.WebMM.Storage.UnitBrowser" %>

<%@ MasterType VirtualPath="~/Master/Default.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>度量单位</title>
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
                        iconclass="add" hasicon="True" text="新建" id="toolbarButtonadd" onclick="addItem()">
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
                <mzh:MzhDataGrid ID="DataGrid1" name="MzhMultiSelectDataGrid" runat="server" HighLightColor="Gold"
                    IdCell="0" AllowSorting="True" SelectType="SingleSelect" MultiPageShowMode="DropListMode"
                    CellPadding="3" BorderWidth="1px" CellSpacing="1" AllowPaging="true"   ShowPageSize="true"
                    AutoGenerateColumns="False" PageSize="<%$ AppSettings:pageSize %>" OnPageIndexChanged="DataGrid1_PageIndexChanged"
                    OnSortCommand="DataGrid1_SortCommand">
                    <Columns>
                        <asp:BoundColumn Visible="False" DataField="Code" HeaderText="Code"></asp:BoundColumn>
                        <asp:BoundColumn DataField="Code" HeaderText="单位编号"></asp:BoundColumn>
                        <asp:BoundColumn DataField="Description" HeaderText="单位名称"></asp:BoundColumn>
                        <asp:BoundColumn DataField="Abbreviate" HeaderText="缩写"></asp:BoundColumn>
                        <asp:BoundColumn DataField="Equivalence" HeaderText="等值(最小单位)" DataFormatString="{0:0.######}">
                            <ItemStyle HorizontalAlign="Right"></ItemStyle>
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Conversion" HeaderText="换算(China)" DataFormatString="{0:0.######}">
                            <ItemStyle HorizontalAlign="Right"></ItemStyle>
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="ConUnit" HeaderText="换算单位"></asp:BoundColumn>
                        <asp:BoundColumn DataField="UnitType" HeaderText="类型"></asp:BoundColumn>
                    </Columns>
                </mzh:MzhDataGrid>
            </td>
        </tr>
    </table>
    <asp:HiddenField ID="tb_SelectedArray" runat="server" />
    <div class="hidden">
        <asp:Button ID="btn_delete" runat="server" Text="删除" OnClick="btn_delete_Click">
        </asp:Button>
        <asp:Button ID="btn_refresh" runat="server" Text="刷新"></asp:Button>
    </div>

    <script language="javascript" type="text/javascript">

        //新建
        function addItem() {

            document.location = "UnitInput.aspx";

        }
    
        //编辑
        function editItem() {
            if (<%=DataGrid1.ClientID%>_obj.getSelectedID() != null && <%=DataGrid1.ClientID%>_obj.getSelectedID() != "") {
                if (<%=DataGrid1.ClientID%>_obj.getSelectedID() != -1) {
                    document.location = "UnitInput.aspx?Op=Edit&Code=" + <%=DataGrid1.ClientID%>_obj.getSelectedID();
                }
                else {
                    alert("该分类为系统分类无法对其进行编辑操作！");
                }
            }
            else {
                alert("请先选中某一条记录，再进行编辑！");
            }
        }

        //删除
        function deleteItems() {
            if (<%=DataGrid1.ClientID%>_obj.getSelectedArray() != null && <%=DataGrid1.ClientID%>_obj.getSelectedArray() != "") {
                if (<%=DataGrid1.ClientID%>_obj.getSelectedID() != -1) {
                    if (confirm("确认要删除选定的内容？")) {
                        document.getElementById("<%=tb_SelectedArray.ClientID%>").value = <%=DataGrid1.ClientID%>_obj.getSelectedArray();
                        document.getElementById("<%=btn_delete.ClientID%>").click();
                    }
                }
                else {
                    alert("该分类为系统分类无法对其进行删除操作！");
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
                    document.location = "UnitInput.aspx?Op=Copy&Code=" + <%=DataGrid1.ClientID%>_obj.getSelectedID();
                }else {
                    alert("该分类为系统分类无法对其进行复制操作！");
                }
            }
            else {
                alert("请先选中某一条记录，再进行复制！");
            }
        }
    </script>

</asp:Content>

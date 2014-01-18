<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InventoryList.aspx.cs" Inherits="WebMM.Storage.InventoryList" %>
<html>
<head runat="server">
    <title>库存盘点</title>
    <link href="../CSS/Common.css" type="text/css" rel="stylesheet" />
    <link href="../CSS/toolbar.css" type="text/css" rel="stylesheet" />
    <link href="../CSS/DataGrid.css" type="text/css" rel="stylesheet" />
    <script src="/aspnet_client/Shmzh.Web.UI/jquery-1.2.6.pack.js" type="text/javascript"></script>
    <script src="/aspnet_client/Shmzh.Web.UI/PopupWindow.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <mzh:mzhtoolbar ID="MzhToolbar1" runat="server"
            CheckBoxListRepeatColumns="5" onitempostback="MzhToolbar1_ItemPostBack"  >
                <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable"
                    itemid="new" cellspacing="0" nakedlabelclass="nakedLabelCell" isshowtext="True"
                    iconclass="add" hasicon="True" text="新建" id="toolbarButtonadd" onclick="newItem(this.id)">
                </mzh:toolbarbutton>
                <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable"
                    itemid="Edit" cellspacing="0" nakedlabelclass="nakedLabelCell" isshowtext="True"
                    iconclass="edit" hasicon="True" text="编辑" id="toolbarButtonedit" onclick="editItem(this.id)">
                </mzh:toolbarbutton>
                <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable"
                    itemid="Delete" cellspacing="0" nakedlabelclass="nakedLabelCell" isshowtext="True" AutoPostBack="True"
                    iconclass="delete" hasicon="True" text="删除" id="toolbarButtondelete" onclick="if(!confirmDelete()) return;">
                </mzh:toolbarbutton>
                <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable"
                    itemid="Profit" cellspacing="0" nakedlabelclass="nakedLabelCell" isshowtext="True" AutoPostBack="False"
                    iconclass="delete" hasicon="False" text="生成盘盈单" id="toolbarButtonProfit" onclick="profitItem(this.id)">
                </mzh:toolbarbutton>
                <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable"
                    itemid="Shortage" cellspacing="0" nakedlabelclass="nakedLabelCell" isshowtext="True" AutoPostBack="False"
                    iconclass="delete" hasicon="False" text="生成盘亏单" id="toolbarButtonShortage" onclick="shortageItem(this.id)">
                </mzh:toolbarbutton>
            </mzh:mzhtoolbar>
        <mzh:mzhdatagrid ID="DataGrid1" runat="server" AllowPaging="True" 
                    PageSize="<%$ AppSettings:pageSize %>" name="MzhMultiSelectDataGrid"
                    AutoGenerateColumns="False" selecttype="SingleSelect" ShowPageSize="True"  
                    AllowSorting="True" IdCell="0"
                    MultiPageShowMode="DropListMode" CauseValidationWhenPaging="False" 
            CssClass="datagrid" HignLightCSS="m-grid-row-over" 
            IsShowTotalRecorderCount="True" SelectedCSS="m-grid-row-selected" 
            onitemdatabound="DataGrid1_ItemDataBound" 
            ShowGridOnEmptyData="False" ShowRecordsCount="True" SORTEXPRESSION="" 
                     >
                    <Columns>
                        <asp:BoundColumn Visible="False" DataField="Id" HeaderText="Id"></asp:BoundColumn>
                        <asp:BoundColumn DataField="Name" SortExpression="Name" HeaderText="名称">
                            <HeaderStyle Width="70px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="StoName" SortExpression="StoName" HeaderText="仓库">
                            <HeaderStyle Width="70px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Date" SortExpression="Date" HeaderText="日期"
                            DataFormatString="{0:yyyy-MM-dd HH:mm}">
                             <HeaderStyle Width="80px" />
                            <ItemStyle HorizontalAlign="Center" ></ItemStyle>
                        </asp:BoundColumn>
                        <asp:TemplateColumn HeaderText="填写人">
                            <EditItemTemplate>
                                <asp:TextBox runat="server" 
                                    Text='<%# this.GetAuthorName(int.Parse(DataBinder.Eval(Container, "DataItem.UserId").ToString())) %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label runat="server" 
                                    Text='<%# this.GetAuthorName(int.Parse(DataBinder.Eval(Container, "DataItem.UserId").ToString())) %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:BoundColumn DataField="Remark" SortExpression="Remark" HeaderText="备注">
                             <HeaderStyle Width="80px" />
                        </asp:BoundColumn>
                    </Columns>
                </mzh:mzhdatagrid>
    </div>
    <div class="hidden"><asp:Button runat="server" ID="btnRefresh" 
            onclick="btnRefresh_Click" /></div>
    </form>
    <script type="text/javascript">
        var popupWindow = new PopupWindow();
        popupWindow.setSize(1024, 768);
        function newItem(elmId) {
            popupWindow.setUrl("Inventory.aspx");
            popupWindow.showPopup(elmId, false);
            return false;
        }
        function editItem(elmId) {
            if (DataGrid1_obj.getSelectedArray() != null && DataGrid1_obj.getSelectedArray() != "") {
                popupWindow.setUrl("InventoryDetail.aspx?Id=" + DataGrid1_obj.getSelectedID());
                popupWindow.showPopup(elmId, false);
                return false;
            }
            else {
                alert("请先选择记录，然后再编辑！");
            }
        }
        function shortageItem(elmId) {
            if (DataGrid1_obj.getSelectedArray() != null && DataGrid1_obj.getSelectedArray() != "") {
                popupWindow.setUrl("InventoryShortageInput.aspx?OP=New&InventoryId=" + DataGrid1_obj.getSelectedID());
                popupWindow.showPopup(elmId, false);
                return false;
            }
            else {
                alert("请先选择记录，然后再编辑！");
            }
        }
        function profitItem(elmId) {
            if (DataGrid1_obj.getSelectedArray() != null && DataGrid1_obj.getSelectedArray() != "") {
                popupWindow.setUrl("InventoryProfitInput.aspx?OP=New&InventoryId=" + DataGrid1_obj.getSelectedID());
                popupWindow.showPopup(elmId, false);
                return false;
            }
            else {
                alert("请先选择记录，然后再生成盘盈单！");
            }
        }
        function confirmDelete() {
            if (DataGrid1_obj.getSelectedArray() != null && DataGrid1_obj.getSelectedArray() != "") {
                return confirm("确认要删除选定的内容？")
            }
            else {
                alert("请先选中记录，再进行删除！");
                return false;
            }
        }
        function refresh() {
            document.getElementById("<%=this.btnRefresh.ClientID %>").click();
        }
    </script>
</body>
</html>

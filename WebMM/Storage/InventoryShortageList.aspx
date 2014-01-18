<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InventoryShortageList.aspx.cs" Inherits="WebMM.Storage.InventoryShortageList" %>
<%@ Import Namespace="System.ComponentModel" %>
<html>
<head runat="server">
    <title>盘盈表</title>
    <link href="../CSS/Common.css" type="text/css" rel="stylesheet" />
    <link href="../CSS/toolbar.css" type="text/css" rel="stylesheet" />
    <link href="../CSS/DataGrid.css" type="text/css" rel="stylesheet" />
    <script src="/aspnet_client/Shmzh.Web.UI/jquery-1.2.6.pack.js" type="text/javascript"></script>
    <script src="/aspnet_client/Shmzh.Web.UI/PopupWindow.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <mzh:MzhToolbar ID="MzhToolbar1" runat="server"
            CheckBoxListRepeatColumns="5" onitempostback="MzhToolbar1_ItemPostBack"  >
                <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable"
                    itemid="New" cellspacing="0" nakedlabelclass="nakedLabelCell" isshowtext="True"
                    iconclass="add" hasicon="True" text="新建" id="toolbarButtonadd" onclick="newItem(this.id)">
                </mzh:toolbarbutton>
                <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable"
                    itemid="Present" cellspacing="0" nakedlabelclass="nakedLabelCell" isshowtext="True" AutoPostBack="True"
                    iconclass="present" hasicon="True" text="提交" id="toolbarButtonPresent" onclick="presentItem()">
                </mzh:toolbarbutton>
                <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable"
                    itemid="Edit" cellspacing="0" nakedlabelclass="nakedLabelCell" isshowtext="True"
                    iconclass="edit" hasicon="True" text="编辑" id="toolbarButtonedit" onclick="editItem(this.id)">
                </mzh:toolbarbutton>
                <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable"
                    itemid="Cancel" cellspacing="0" nakedlabelclass="nakedLabelCell" isshowtext="True" AutoPostBack="True"
                    iconclass="cancel" hasicon="True" text="作废" id="toolbarButtoncancel" onclick="if(!confirmCancel()) return;">
                </mzh:toolbarbutton>
                <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable" AutoPostBack="True"
                    itemid="Delete" cellspacing="0" nakedlabelclass="nakedLabelCell" isshowtext="True"
                    iconclass="delete" hasicon="True" text="删除" id="toolbarButtondelete" onclick="if(!confirmDelete()) return;">
                </mzh:toolbarbutton>
                <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable"
            itemid="Edit" cellspacing="0" nakedlabelclass="nakedLabelCell" isshowtext="True" 
            iconclass="audit1" hasicon="True" text="一级审批" id="toolbarButtonFirstAudit" onclick="firstAuditItem(this.id)">
        </mzh:toolbarbutton>
        <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable"
            itemid="Edit" cellspacing="0" nakedlabelclass="nakedLabelCell" isshowtext="True" 
            iconclass="audit2" hasicon="True" text="二级审批" id="toolbarButtonSecondAudit" onclick="secondAuditItem(this.id)">
        </mzh:toolbarbutton>
        <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable"
            itemid="Edit" cellspacing="0" nakedlabelclass="nakedLabelCell" isshowtext="True" 
            iconclass="audit3" hasicon="True" text="三级审批" id="toolbarButtonThirdAudit" onclick="thirdAuditItem(this.id)">
        </mzh:toolbarbutton>
        <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable"
            itemid="Receive" cellspacing="0" nakedlabelclass="nakedLabelCell" isshowtext="True" 
            iconclass="out" hasicon="True" text="发料" id="toolbarButtonDraw" onclick="drawItem(this.id)">
        </mzh:toolbarbutton>
        <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable"
            itemid="Red" cellspacing="0" nakedlabelclass="nakedLabelCell" isshowtext="True" 
            iconclass="red" hasicon="True" text="红字" id="toolbarButtonRed" onclick="redItem(this.id)">
        </mzh:toolbarbutton>
            </mzh:MzhToolbar>
        <mzh:MzhDataGrid ID="DataGrid1" runat="server" AllowPaging="True" 
                    PageSize="<%$ AppSettings:pageSize %>" name="MzhMultiSelectDataGrid"
                    AutoGenerateColumns="False" selecttype="SingleSelect" ShowPageSize="True"  
                    AllowSorting="True" IdCell="0"
                    MultiPageShowMode="DropListMode" CauseValidationWhenPaging="False" 
            CssClass="datagrid" HignLightCSS="m-grid-row-over" 
            IsShowTotalRecorderCount="True" SelectedCSS="m-grid-row-selected" 
            ShowGridOnEmptyData="False" ShowRecordsCount="True" SORTEXPRESSION="" onitemdatabound="DataGrid1_ItemDataBound"  
                     >
                    <Columns>
                        <asp:BoundColumn Visible="true" DataField="EntryNo" HeaderText="#" SortExpression="EntryNo">
                            <HeaderStyle Width="40px" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="DocName" HeaderText="单据名称">
                            <HeaderStyle Width="100px" />
                        </asp:BoundColumn>
                        <asp:TemplateColumn HeaderText="状态" SortExpression="EntryState">
                            <HeaderStyle Width="80px" />
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label runat="server" 
                                    Text='<%# this.GetEntryStateName(DataBinder.Eval(Container, "DataItem.EntryState").ToString()) %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:BoundColumn DataField="StoName" SortExpression="StoName" HeaderText="仓库">
                            <HeaderStyle Width="70px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="SubTotal" SortExpression="SubTotal" HeaderText="金额">
                            <HeaderStyle Width="100px" />
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="EntryDate" SortExpression="EntryDate" HeaderText="日期"
                            DataFormatString="{0:yyyy-MM-dd}">
                             <HeaderStyle Width="80px" />
                            <ItemStyle HorizontalAlign="Center" ></ItemStyle>
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="AuthorName" SortExpression="AuthorName" HeaderText="制单人">
                            <HeaderStyle Width="80px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Remark" SortExpression="Remark" HeaderText="备注">
                             <HeaderStyle Width="150px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn></asp:BoundColumn>
                    </Columns>
                </mzh:MzhDataGrid>
    </div>
    <div class="hidden"><asp:Button runat="server" ID="btnRefresh" 
            onclick="btnRefresh_Click" /></div>
    </form>
    <script type="text/javascript">
        var popupWindow = new PopupWindow();
        popupWindow.setSize(900, 600);
        function newItem(elmId) {
            popupWindow.setUrl("InventoryShortageInput.aspx?OP=New");
            popupWindow.showPopup(elmId, false);
            return false;
        }
        function presentItem(elmId) {
            if (DataGrid1_obj.getSelectedArray() != null && DataGrid1_obj.getSelectedArray() != "") {
                return confirm("确认要提交选定的内容？")
            }
            else {
                alert("请先选中记录，再进行提交！");
                return false;
            }
        }

        function editItem(elmId) {
            if (DataGrid1_obj.getSelectedArray() != null && DataGrid1_obj.getSelectedArray() != "") {
                popupWindow.setUrl("InventoryShortageInput.aspx?OP=Edit&EntryNo=" + DataGrid1_obj.getSelectedID());
                popupWindow.showPopup(elmId, false);
                return false;
            }
            else {
                alert("请先选择记录，然后再编辑！");
            }
        }
        function firstAuditItem(elmId) {
            if (DataGrid1_obj.getSelectedArray() != null && DataGrid1_obj.getSelectedArray() != "") {
                popupWindow.setUrl("InventoryShortageInput.aspx?OP=FirstAudit&EntryNo=" + DataGrid1_obj.getSelectedID());
                popupWindow.showPopup(elmId, false);
                return false;
            }
            else {
                alert("请先选择记录，然后再审批！");
            }
        }
        function secondAuditItem(elmId) {
            if (DataGrid1_obj.getSelectedArray() != null && DataGrid1_obj.getSelectedArray() != "") {
                popupWindow.setUrl("InventoryShortageInput.aspx?OP=SecondAudit&EntryNo=" + DataGrid1_obj.getSelectedID());
                popupWindow.showPopup(elmId, false);
                return false;
            }
            else {
                alert("请先选择记录，然后再审批！");
            }
        }
        function thirdAuditItem(elmId) {
            if (DataGrid1_obj.getSelectedArray() != null && DataGrid1_obj.getSelectedArray() != "") {
                popupWindow.setUrl("InventoryShortageInput.aspx?OP=ThirdAudit&EntryNo=" + DataGrid1_obj.getSelectedID());
                popupWindow.showPopup(elmId, false);
                return false;
            }
            else {
                alert("请先选择记录，然后再审批！");
            }
        }
        function drawItem(elmId) {
            if (DataGrid1_obj.getSelectedArray() != null && DataGrid1_obj.getSelectedArray() != "") {
                popupWindow.setUrl("InventoryShortageInput.aspx?OP=Out&EntryNo=" + DataGrid1_obj.getSelectedID());
                popupWindow.showPopup(elmId, false);
                return false;
            }
            else {
                alert("请先选择记录，然后再收料！");
            }
        }
        function redItem(elmId) {
            if (DataGrid1_obj.getSelectedArray() != null && DataGrid1_obj.getSelectedArray() != "") {
                popupWindow.setUrl("InventoryShortageInput.aspx?OP=Red&EntryNo=" + DataGrid1_obj.getSelectedID());
                popupWindow.showPopup(elmId, false);
                return false;
            }
            else {
                alert("请先选择记录，然后再冲红字！");
            }
        }
        function confirmCancel() {
            if (DataGrid1_obj.getSelectedArray() != null && DataGrid1_obj.getSelectedArray() != "") {
                return confirm("确认要作废选定的内容？")
            }
            else {
                alert("请先选中记录，再进行作废！");
                return false;
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

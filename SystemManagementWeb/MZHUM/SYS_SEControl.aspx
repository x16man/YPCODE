<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SYS_SEControl.aspx.cs"
    Inherits="SystemManagement.MZHUM.SYS_SEControl" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>查询模块控件</title>
    <link href="../CSS/Common.css" rel="stylesheet" type="text/css" />

    <script src="/aspnet_client/Shmzh.Web.UI/jquery-1.2.6.pack.js" type="text/javascript"></script>

    <script src="../JS/PopupWindow.js" type="text/javascript"></script>

    <script src="../JS/MZHUM/SYS_SEControlList.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server">
    <div id="main">
        <mzh:MzhToolbar ID="MzhToolbar1" runat="server" OnItemPostBack="MzhToolbar1_ItemPostBack">
            <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable"
                itemid="new" cellspacing="0" nakedlabelclass="nakedLabelCell" isshowtext="True"
                iconclass="add" hasicon="True" text="新建" id="tbiAdd" onclick="add(this.id)">
            </mzh:toolbarbutton>
            <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable"
                itemid="Edit" cellspacing="0" nakedlabelclass="nakedLabelCell" isshowtext="True"
                iconclass="edit" hasicon="True" text="编辑" id="tbiEdit" onclick="edit(this.id)">
            </mzh:toolbarbutton>
            <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable"
                itemid="delete" cellspacing="0" autopostback="True" nakedlabelclass="nakedLabelCell"
                isshowtext="True" iconclass="delete" hasicon="True" text="删除" id="tbiDelete"
                onclick="if(!confirmDelete()) return;">
            </mzh:toolbarbutton>
        </mzh:MzhToolbar>
        <mzh:MzhDataGrid ID="dg_SEControlInfo" runat="server" name="MzhMultiSelectDataGrid"
            selecttype="SingleSelect" IdCell="0" AutoGenerateColumns="False" AllowPaging="True"
            HignLightCSS="m-grid-row-over" cssclassforpagerbuttonjump="m-grid-pager-button-jump"
            SelectedCSS="m-grid-row-selected" CssClass="datagrid" cssclassforpagerinputpage="m-grid-pager-input-page"
            MultiPageShowMode="DropListMode" TotalRecorderCount="0" PageSize="20" AllowSorting="True"
            ShowRecordsCount="True" ShowPageSize="true">
            <HeaderStyle Wrap="False"></HeaderStyle>
            <Columns>
                <asp:BoundColumn DataField="Id" SortExpression="Id" HeaderText="Id" Visible="false">
                    <HeaderStyle></HeaderStyle>
                    <ItemStyle />
                </asp:BoundColumn>
                <asp:BoundColumn DataField="LabelName" SortExpression="LabelName" HeaderText="标签名称">
                    <HeaderStyle Width="100px"></HeaderStyle>
                </asp:BoundColumn>
                <asp:BoundColumn DataField="ControlTypeId" SortExpression="ControlTypeId" HeaderText="控件类型">
                    <HeaderStyle Width="80px"/>
                </asp:BoundColumn>
                <asp:BoundColumn DataField="DataTypeId" SortExpression="DataTypeId" HeaderText="数据类型">
                    <HeaderStyle Width="80px"/>
                </asp:BoundColumn>
                <asp:BoundColumn DataField="TableName" SortExpression="TableName" HeaderText="表名">
                    <HeaderStyle Width="80px" />
                </asp:BoundColumn>
                <asp:BoundColumn DataField="FieldName" SortExpression="FieldName" HeaderText="字段名">
                    <HeaderStyle Width="80px" />
                </asp:BoundColumn>
                <asp:BoundColumn DataField="IsValid" SortExpression="IsValid" HeaderText="是否有效">
                    <HeaderStyle Width="80px" />
                </asp:BoundColumn>
                <asp:BoundColumn
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                <asp:BoundColumn DataField="Remark" SortExpression="Remark" HeaderText="描述">
                    <HeaderStyle></HeaderStyle>
                    <ItemStyle></ItemStyle>
                </asp:BoundColumn>
            </Columns>
            <PagerStyle HorizontalAlign="Right" Mode="NumericPages"></PagerStyle>
        </mzh:MzhDataGrid>
        <div class="hidden">
            <asp:HiddenField ID="hfModuleId" runat="server" />
            <asp:Button ID="btnRefresh" runat="server" Text="refresh" OnClick="btnRefresh_Click" />
        </div>
    </div>
    </form>
</body>
</html>

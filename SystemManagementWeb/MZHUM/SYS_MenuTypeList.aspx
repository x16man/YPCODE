<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SYS_MenuTypeList.aspx.cs"
    Inherits="SystemManagement.MZHUM.SYS_MenuTypeList" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>菜单类型</title>
    <link rel="stylesheet" type="text/css" href="../CSS/common.css" />

    <script src="/aspnet_client/Shmzh.Web.UI/jquery-1.2.6.pack.js" type="text/javascript"></script>

    <script src="../JS/PopupWindow.js" type="text/javascript"></script>

    <script src="../JS/MZHUM/SYS_MenuTypeList.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server">
    <mzh:MzhTitle ID="MzhTitle1" runat="server" />
    <div id="main">
        <mzh:MzhToolbar ID="MzhToolbar1" runat="server" OnItemPostBack="MzhToolbar1_ItemPostBack">
            <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable"
                itemid="new" cellspacing="0" nakedlabelclass="nakedLabelCell" isshowtext="True"
                iconclass="add" hasicon="True" text="新建" id="tbiAdd" onclick="addMenuTypeInfo(this.id)">
            </mzh:toolbarbutton>
            <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable"
                itemid="Edit" cellspacing="0" nakedlabelclass="nakedLabelCell" isshowtext="True"
                iconclass="edit" hasicon="True" text="编辑" id="tbiEdit" onclick="editMenuTypeInfo(this.id)">
            </mzh:toolbarbutton>
            <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable"
                itemid="delete" cellspacing="0" autopostback="True" nakedlabelclass="nakedLabelCell"
                isshowtext="True" iconclass="delete" hasicon="True" text="删除" id="tbiDelete"
                onclick="if(!confirmDelete()) return;">
            </mzh:toolbarbutton>
        </mzh:MzhToolbar>
        <mzh:MzhDataGrid ID="dg_MenuTypeInfo" runat="server" name="MzhMultiSelectDataGrid"
            selecttype="MultiSelect" IdCell="0" AutoGenerateColumns="False" AllowPaging="True"
            HignLightCSS="m-grid-row-over" cssclassforpagerbuttonjump="m-grid-pager-button-jump"
            SelectedCSS="m-grid-row-selected" CssClass="datagrid" cssclassforpagerinputpage="m-grid-pager-input-page"
            MultiPageShowMode="DropListMode" TotalRecorderCount="0" PageSize="20" AllowSorting="True"
            ShowRecordsCount="True" ShowPageSize="true">
            <HeaderStyle Wrap="False"></HeaderStyle>
            <Columns>
                <asp:BoundColumn DataField="ID" SortExpression="ID" HeaderText="菜单类型ID">
                    <HeaderStyle Width="80px"></HeaderStyle>
                    <ItemStyle CssClass="center" />
                </asp:BoundColumn>
                <asp:BoundColumn DataField="Name" SortExpression="Name" HeaderText="菜单类型名称">
                    <HeaderStyle Width="200px"></HeaderStyle>
                </asp:BoundColumn>
                <asp:TemplateColumn SortExpression="IsUsedByFrameWork" HeaderText="是否框架使用">
                    <HeaderStyle Wrap="False" Width="100px"></HeaderStyle>
                    <ItemStyle Wrap="False" CssClass="center"></ItemStyle>
                    <ItemTemplate>
                        <%# (bool)DataBinder.Eval(Container, "DataItem.IsUsedByFrameWork")?"是":"否" %>
                    </ItemTemplate>
                </asp:TemplateColumn>
                <asp:BoundColumn DataField="Remark" SortExpression="Remark" HeaderText="描述">
                    <HeaderStyle Wrap="false" />
                    <ItemStyle />
                </asp:BoundColumn>
            </Columns>
            <PagerStyle HorizontalAlign="Right" Mode="NumericPages"></PagerStyle>
        </mzh:MzhDataGrid>
        <div class="hidden">
            <asp:Button ID="btnRefresh" runat="server" Text="refresh" OnClick="btnRefresh_Click" />
        </div>
    </div>
    </form>
</body>
</html>

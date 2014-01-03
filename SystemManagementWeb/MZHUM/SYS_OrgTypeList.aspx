<%@ Page Language="c#" CodeBehind="SYS_OrgTypeList.aspx.cs" AutoEventWireup="True"
    Inherits="SystemManagement.MZHUM.SYS_OrgTypeList" %>



<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>组织类型列表</title>
    <link rel="stylesheet" type="text/css" href="../CSS/common.css" />

    <script src="/aspnet_client/Shmzh.Web.UI/jquery-1.2.6.pack.js" type="text/javascript"></script>

    <script src="../JS/PopupWindow.js" type="text/javascript"></script>

    <script src="../JS/MZHUM/SYS_OrgTypeList.js" type="text/javascript"></script>

</head>
<body>
    <form id="Form1" method="post" runat="server">
    <mzh:MzhTitle ID="MzhTitle1" runat="server" />
    <div id="main">
        <mzh:MzhToolbar ID="MzhToolbar1" runat="server" OnItemPostBack="MzhToolbar1_ItemPostBack">
            <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable"
                itemid="new" cellspacing="0" nakedlabelclass="nakedLabelCell" isshowtext="True"
                iconclass="add" hasicon="True" text="新建" id="tbiAdd" onclick="addOrgType(this.id)">
            </mzh:toolbarbutton>
            <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable"
                itemid="Edit" cellspacing="0" nakedlabelclass="nakedLabelCell" isshowtext="True"
                iconclass="edit" hasicon="True" text="编辑" id="tbiEdit" onclick="editOrgType(this.id)">
            </mzh:toolbarbutton>
            <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable"
                itemid="delete" cellspacing="0" autopostback="True" nakedlabelclass="nakedLabelCell"
                isshowtext="True" iconclass="delete" hasicon="True" text="删除" id="tbiDelete"
                onclick="if(!confirmDelete()) return;">
            </mzh:toolbarbutton>
        </mzh:MzhToolbar>
        <mzh:MzhDataGrid ID="dg_OrgType" runat="server" CssClass="datagrid" HignLightCSS="m-grid-row-over"
            IdCell="0" MultiPageShowMode="DropListMode" name="MzhMultiSelectDataGrid" SelectedCSS="m-grid-row-selected"
            TotalRecorderCount="0" AutoGenerateColumns="False" ShowPageSize="true" AllowSorting=true AllowPaging="true" ShowRecordsCount="true"
            SelectType="SingleSelect">
            <Columns>
                <asp:BoundColumn DataField="Code" HeaderText="编号" SortExpression="Code" ItemStyle-CssClass="center">
                    <ItemStyle Width="35px"></ItemStyle>
                </asp:BoundColumn>
                <asp:BoundColumn DataField="CnName" HeaderText="中文名称" SortExpression="CnName">
                    <ItemStyle Width="100px"></ItemStyle>
                </asp:BoundColumn>
                <asp:BoundColumn DataField="EnName" HeaderText="英文名称" SortExpression="EnName">
                    <ItemStyle Width="100px"></ItemStyle>
                </asp:BoundColumn>
                <asp:BoundColumn DataField="Level" HeaderText="等级" ItemStyle-CssClass="center" SortExpression="Level">
                    <ItemStyle Width="50px"></ItemStyle>
                </asp:BoundColumn>
                <asp:TemplateColumn SortExpression="IsValid" HeaderText="是否有效">
                    <HeaderStyle Wrap="False" HorizontalAlign="Center" VerticalAlign="Middle" Width="60px">
                    </HeaderStyle>
                    <ItemStyle Wrap="False" CssClass="center"></ItemStyle>
                    <ItemTemplate>
                        <asp:Label ID="lblIsValid" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.IsValid").ToString()=="Y"?"是":"否" %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateColumn>
                <asp:BoundColumn></asp:BoundColumn>
            </Columns>
        </mzh:MzhDataGrid>
    </div>
    <div class="hidden">
        <asp:Button ID="btnRefresh" runat="server" Text="Refresh" OnClick="btnRefresh_Click" />
    </div>
    </form>
</body>
</html>

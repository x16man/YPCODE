<%@ Register TagPrefix="mzh" Namespace="Shmzh.Web.UI.Controls" Assembly="Shmzh.Web.UI" %>

<%@ Page Language="c#" CodeBehind="SYS_RightCodeList.aspx.cs" AutoEventWireup="True"
    Inherits="SystemManagement.MZHUM.SYS_RightCodeList" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>权限列表</title>
    <link rel="stylesheet" type="text/css" href="../CSS/common.css" />

    <script src="/aspnet_client/Shmzh.Web.UI/jquery-1.2.6.pack.js" type="text/javascript"></script>

    <script src="../JS/PopupWindow.js" type="text/javascript"></script>

    <script src="../JS/MZHUM/SYS_RightCodeList.js" type="text/javascript"></script>

</head>
<body>
    <form id="Form1" method="post" runat="server">
    <mzh:MzhTitle ID="MzhTitle1" runat="server" />
    <div id="main">
        <mzh:MzhToolbar ID="MzhToolbar1" runat="server" 
            onitempostback="MzhToolbar1_ItemPostBack">
            <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable"
                itemid="Add" cellspacing="0" nakedlabelclass="nakedLabelCell" isshowtext="True"
                iconclass="add" hasicon="True" text="新建" id="tbiAdd" onclick="AddRightCode(this.id)">
            </mzh:toolbarbutton>
            <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable"
                itemid="Edit" cellspacing="0" nakedlabelclass="nakedLabelCell" isshowtext="True"
                iconclass="edit" hasicon="True" text="编辑" id="tbiEdit" onclick="editRightCode(this.id)">
            </mzh:toolbarbutton>
            <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable"
                itemid="Delete" cellspacing="0" autopostback="True" nakedlabelclass="nakedLabelCell"
                isshowtext="True" iconclass="delete" hasicon="True" text="删除" id="tbiDelete"
                onclick="if(!confirmDelete()) return;">
            </mzh:toolbarbutton>
            <mzh:toolbarseparator separatorclass="toolbarIconDivider" id="toolbarSeparator2"
                itemid="toolbarSeparator2">
            </mzh:toolbarseparator>
            <mzh:toolbarlabel cellpadding="0" labelclass="labelCell" cellspacing="0" itemid="toolbarLabel2"
                tableclass="labelTable" text="分组：" id="toolbarLabel2">
            </mzh:toolbarlabel>
            <mzh:toolbardropdownlist visible="True" cellpadding="0" cellspacing="0" itemid="RightCat"
                internaldropdownlist="" selectedindex="0" tableclass="labelTable" autopostback="True"
                enabled="True" items="(Collection)" id="tbiRightCat" SelectedValue="a">
            </mzh:toolbardropdownlist>
            <mzh:ToolbarCheckBox ID="tbiDisabled" runat="server" AutoPostBack="True" 
                CausesValidation="True" Cellpadding="0" Cellspacing="0" Checked="False" 
                ItemId="IncludeDisabled" TableClass="labelTable" Text="包括无效" />
        </mzh:MzhToolbar>
        <mzh:MzhDataGrid ID="dg_RightCode" runat="server" name="MzhMultiSelectDataGrid" selecttype="SingleSelect"
            IdCell="0" AutoGenerateColumns="False" AllowPaging="True" PageSize="20" ShowRecordsCount="True"
            MultiPageShowMode="DropListMode" ShowPageSize="True" 
            AllowSorting="True" 
            >
            <PagerStyle HorizontalAlign="Right" Mode="NumericPages"></PagerStyle>
            <HeaderStyle Wrap="False" HorizontalAlign="Center" BackColor="#ACC8F7"></HeaderStyle>
            <Columns>
                <asp:BoundColumn DataField="RightCode" SortExpression="RightCode" HeaderText="编号">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="40px" CssClass="center">
                    </ItemStyle>
                </asp:BoundColumn>
                <asp:BoundColumn DataField="RightName" SortExpression="RightName" HeaderText="名称">
                    <ItemStyle Width="150px"></ItemStyle>
                </asp:BoundColumn>
                <asp:TemplateColumn SortExpression="IsValid" HeaderText="状态">
                    <HeaderStyle Wrap="False" HorizontalAlign="Center" VerticalAlign="Middle" Width="40px">
                    </HeaderStyle>
                    <ItemStyle Wrap="False" CssClass="center"></ItemStyle>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.IsValid").ToString()=="Y"?"有效":"无效" %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn SortExpression="RightCatCode" HeaderText="分组">
                    <HeaderStyle Wrap="False" VerticalAlign="Middle" Width="140px"></HeaderStyle>
                    <ItemStyle Wrap="False"></ItemStyle>
                    <ItemTemplate>
                        <asp:Label ID="lblCat" runat="server" Text='<%# GetRightCatName(DataBinder.Eval(Container, "DataItem.RightCatCode").ToString()) %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn HeaderText="所属产品">
                    <HeaderStyle Wrap="False" HorizontalAlign="Center" VerticalAlign="Middle" Width="100px">
                    </HeaderStyle>
                    <ItemStyle Wrap="False" CssClass="center"></ItemStyle>
                    <ItemTemplate>
                        <%= ProductName %>
                    </ItemTemplate>
                </asp:TemplateColumn>
                <asp:BoundColumn DataField="Remark" SortExpression="Remark" HeaderText="描述">
                </asp:BoundColumn>
            </Columns>
        </mzh:MzhDataGrid>
        <div class="hidden">
            <asp:TextBox ID="txtProductCode" runat="server"></asp:TextBox>
            <asp:Button ID="btnRefresh" runat="server" onclick="btnRefresh_Click" />
        </div>
    </div>
    </form>
</body>
</html>

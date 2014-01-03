<%@ Page Language="c#" CodeBehind="SYS_UserRole.aspx.cs" AutoEventWireup="True" Inherits="SystemManagement.MZHUM.SYS_UserRole" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>�û���ɫ�б�</title>
    <link rel="stylesheet" type="text/css" href="../CSS/common.css" />

    <script type="text/javascript" src="/aspnet_client/Shmzh.Web.UI/jquery-1.2.6.pack.js"></script>
    <script type="text/javascript" src="/aspnet_client/Shmzh.Web.UI/PopupWindow.js"></script>
    <script type="text/javascript" src="../JS/MZHUM/SYS_UserRole.js"></script>
</head>
<body>
    <form id="Form1" method="post" runat="server">
    <mzh:MzhTitle ID="MzhTitle1" runat="server" />
    <div id="main">
        <mzh:MzhToolbar ID="MzhToolbar1" runat="server" OnItemPostBack="MzhToolbar1_ItemPostBack1">
            <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable"
                itemid="Add" cellspacing="0" nakedlabelclass="nakedLabelCell" isshowtext="True"
                iconclass="addUser" hasicon="True" text="�½�" id="tbiAddUser" onclick="addUser(this.id)">
            </mzh:toolbarbutton>
            <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable"
                itemid="Edit" cellspacing="0" nakedlabelclass="nakedLabelCell" isshowtext="True"
                iconclass="editUser" hasicon="True" text="�༭" id="tbiEditUser" onclick="editUser(this.id)">
            </mzh:toolbarbutton>
            <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable"
                itemid="Delete" cellspacing="0" autopostback="True" nakedlabelclass="nakedLabelCell"
                isshowtext="True" iconclass="deleteUser" hasicon="True" text="ɾ��" id="tbiDeleteUser"
                onclick="if(!confirmDelete()) return;">
            </mzh:toolbarbutton>
            <mzh:toolbarseparator separatorclass="toolbarIconDivider" id="toolbarSeparator2"
                itemid="toolbarSeparator2">
            </mzh:toolbarseparator>
            <mzh:toolbarlabel cellpadding="0" labelclass="labelCell" cellspacing="0" itemid="toolbarLabel2"
                tableclass="labelTable" text="��ɫ��" id="toolbarLabel2">
            </mzh:toolbarlabel>
            <mzh:toolbardropdownlist visible="True" cellpadding="0" cellspacing="0" itemid="Role"
                internaldropdownlist="" selectedindex="-1" tableclass="labelTable" autopostback="True"
                enabled="True" items="(Collection)" id="tbiRole">
            </mzh:toolbardropdownlist>
            <mzh:toolbarseparator separatorclass="toolbarIconDivider" id="toolbarSeparator1"
                itemid="toolbarSeparator1">
            </mzh:toolbarseparator>
            <mzh:ToolbarTextBox id="tbiContent" labelclass="labelCell" tableclass="buttonTable"
                itemid="Content" columns="20" tooltip="���������û������������������в�ѯ">
            </mzh:ToolbarTextBox>
            <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable"
                itemid="Query" cellspacing="0" autopostback="True" nakedlabelclass="nakedLabelCell"
                isshowtext="True" iconclass="query" hasicon="true" text="��ѯ" id="tbiQuery">
            </mzh:toolbarbutton>
        </mzh:MzhToolbar>
        
        <mzh:MzhDataGrid ID="MzhDataGrid1" runat="server" CssClass="datagrid" AutoGenerateColumns="False"
            IdCell="0" SelectType="SingleSelect" name="MzhMultiSelectDataGrid" AllowPaging="True"
            MultiPageShowMode="DropListMode" PageSize="19" HignLightCSS="m-grid-row-over"
            SelectedCSS="m-grid-row-selected" TotalRecorderCount="0" ShowPageSize="true"
            OnPageIndexChanged="MzhDataGrid1_PageIndexChanged" OnPageSizeChanged="MzhDataGrid1_PageSizeChanged">
            <Columns>
                <asp:BoundColumn Visible="False" DataField="Code"></asp:BoundColumn>
                <asp:TemplateColumn HeaderText="��/�û�">
                    <ItemStyle Width="250px" />
                    <ItemTemplate>
                    <img alt="" src='<%# DataBinder.Eval(Container, "DataItem.UserType")=="Emp"?"../Images/USER.png":"../Images/GROUP.png" %>'/>
                    <%#DataBinder.Eval(Container,"DataItem.Name") %>
                    </ItemTemplate>
                </asp:TemplateColumn>
                <asp:BoundColumn DataField="RoleNameList" HeaderText="��ɫ"></asp:BoundColumn>
                
            </Columns>
        </mzh:MzhDataGrid>
        <div class="hidden">
            <input id="tb_ProductCode" type="hidden" runat="server" />
            <asp:Button ID="btnRefresh" runat="server" onclick="btnRefresh_Click" />
        </div>
    </div>
    </form>
</body>
</html>

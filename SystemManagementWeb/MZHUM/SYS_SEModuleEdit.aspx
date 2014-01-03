<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SYS_SEModuleEdit.aspx.cs" Inherits="SystemManagement.MZHUM.SYS_SEModuleEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>查询模块编辑</title>
    <link href="../CSS/Common.css" rel="stylesheet" type="text/css" />
    <link href="../CSS/MZHUM/form1Column.css" rel="stylesheet" type="text/css" />
    <script src="/aspnet_client/Shmzh.Web.UI/jquery-1.2.6.pack.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="main">
        <mzh:MzhToolbar ID="MzhToolbar1" runat="server" OnItemPostBack="MzhToolbar1_ItemPostBack">
            <mzh:ToolbarButton ID="tbiSave" runat="server" Cellpadding="0" Cellspacing="0" HasIcon="True"
                AutoPostback="True" IconClass="save" IsShowText="True" ItemId="Save" LabelClass="labelCell"
                NakedLabelClass="nakedLabelCell" Text="保存" TableClass="buttonTable" />
            <mzh:ToolbarSeparator ID="ToolbarSeparator1" runat="server" ItemId="" SeparatorClass="toolbarIconDivider" />
            <mzh:ToolbarButton ID="tbiClose" runat="server" Cellpadding="0" Cellspacing="0" HasIcon="True"
                AutoPostback="True" IconClass="close" IsShowText="True" ItemId="Close" LabelClass="labelCell"
                NakedLabelClass="nakedLabelCell" onclick="window.close();" Text="关闭" TableClass="buttonTable" />
        </mzh:MzhToolbar>
        <div class="fieldWrapper">
            <fieldset>
                <legend>查询模块信息</legend>
                <label for="txtId">
                    查询模块ID：<span class="required">*</span></label>
                <asp:RequiredFieldValidator ID="rfvId" runat="server" ControlToValidate="txtId"
                    Display="Dynamic" ErrorMessage="">必须输入查询模块Id</asp:RequiredFieldValidator>
                <div>
                    <asp:TextBox ID="txtId" runat="server" MaxLength="10"></asp:TextBox>
                </div>
                <label for="txtName">查询模块名称：<span class="required">*</span></label>
                <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName"
                    Display="Dynamic" ErrorMessage="">必须输入查询模块名称</asp:RequiredFieldValidator>
                <div>
                <asp:TextBox ID="txtName" runat=server MaxLength="20"></asp:TextBox>
                </div>
                <label for="txtSQL">查询语句：<span class="required">*</span></label>
                <asp:RequiredFieldValidator ID="rfvSQL" runat=server ControlToValidate="txtSQl" Display=Dynamic ErrorMessage="">必须输入SQL字符串。</asp:RequiredFieldValidator>
                <div>
                <asp:TextBox ID="txtSQL" runat="server" TextMode="MultiLine" Rows="10" MaxLength="3700"></asp:TextBox>
                </div>
                
                <label for="txtWhere">连接字符：<span class="required">*</span></label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtWhere" Display=Dynamic ErrorMessage="">必须输入连接字符：Where、And、Or。</asp:RequiredFieldValidator>
                <div>
                <asp:TextBox ID="txtWhere" runat="server" MaxLength="20"></asp:TextBox>
                </div>
                
                <label for="txtRemark">
                    备注：</label>
                <div>
                    <asp:TextBox ID="txtRemark" runat="server" Rows="4" MaxLength="255" TextMode="MultiLine"></asp:TextBox>
                </div>
                
            </fieldset>
        </div>
    </div>
    </form>
</body>
</html>

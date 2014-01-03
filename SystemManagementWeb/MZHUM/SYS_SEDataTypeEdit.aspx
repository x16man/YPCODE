<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SYS_SEDataTypeEdit.aspx.cs" Inherits="SystemManagement.MZHUM.SYS_SEDataTypeEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>查询引擎数据类型编辑</title>
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
                <legend>数据类型信息</legend>
                <label for="txtId">
                    数据类型ID：<span class="required">*</span></label>
                <asp:RequiredFieldValidator ID="rfvId" runat="server" ControlToValidate="txtId"
                    Display="Dynamic" ErrorMessage="">必须输入数据类型Id</asp:RequiredFieldValidator>
                     <asp:RangeValidator ID="rvProductCode" runat="server" ControlToValidate="txtId" Display="Dynamic" ErrorMessage="编号必须是1~99之间的数字" MaximumValue="99"
                      MinimumValue="1" Type="Integer">编号必须是1~99之间的数字</asp:RangeValidator>
                <div>
                    <asp:TextBox ID="txtId" runat="server" MaxLength="10"></asp:TextBox>
                </div>
                <label for="txtName">数据类型名称：<span class="required">*</span></label>
                <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName"
                    Display="Dynamic" ErrorMessage="">必须输入数据类型名称</asp:RequiredFieldValidator>
                <div>
                <asp:TextBox ID="txtName" runat=server MaxLength="20"></asp:TextBox>
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

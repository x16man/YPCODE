﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SYS_MenuTypeEdit.aspx.cs" Inherits="SystemManagement.MZHUM.SYS_MenuTypeEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>菜单类型</title>
    <link rel="stylesheet" type="text/css" href="../CSS/common.css" />
    <link href="../CSS/MZHUM/form1column.css" rel="stylesheet" type="text/css" />

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
                AutoPostback="False" IconClass="close" IsShowText="True" ItemId="Close" LabelClass="labelCell"
                NakedLabelClass="nakedLabelCell" onclick="window.close();" Text="关闭" TableClass="buttonTable" />
        </mzh:MzhToolbar>
        <div class="fieldWrapper">
            <fieldset>
                <legend>菜单类型信息</legend>
                <label for="txtId">ID：<span class="required">*</span></label>
                <asp:RequiredFieldValidator ID="rfvId" runat=server ControlToValidate="txtId" Display="Dynamic" ErrorMessage="">必须输入ID(0~999)</asp:RequiredFieldValidator>
                <asp:RangeValidator ID="rvId" runat=server ControlToValidate="txtId" Display="Dynamic" ErrorMessage="" Type=Integer MinimumValue="0" MaximumValue="999">（0~999）</asp:RangeValidator>
                <div>
                    <asp:TextBox ID="txtId" runat=server MaxLength="3"></asp:TextBox>
                </div>
                <label for="txtName">
                    名称：<span class="required">*</span></label>
                <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName"
                    Display="Dynamic" ErrorMessage="必须输入名称">必须输入名称</asp:RequiredFieldValidator>
                <div>
                    <asp:TextBox ID="txtName" runat="server" MaxLength="20"></asp:TextBox>
                </div>
                <label for="chkIsUsedByFrameWork">是否框架使用：</label>
                <div>
                    <asp:CheckBox ID="chkIsUsedByFrameWork" runat=server Checked=false />
                </div>
                <label for="txtRemark">
                    备注：</label>
                <div>
                    <asp:TextBox ID="txtRemark" runat="server" Rows="4" TextMode="MultiLine"></asp:TextBox>
                </div>
                
            </fieldset>
        </div>
    </div>
    </form>
</body>
</html>
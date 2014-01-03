<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SYS_SEControlEdit.aspx.cs"
    Inherits="SystemManagement.MZHUM.SYS_SEControlEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>查询模块控件维护</title>
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
                <legend>查询模块控件信息</legend>
                <label for="txtLabelName">
                    标签名称：<span class="required">*</span></label>
                <asp:RequiredFieldValidator ID="rfvLabelName" runat="server" ControlToValidate="txtLabelName"
                    Display="Dynamic" ErrorMessage="">必须输入标签名称</asp:RequiredFieldValidator>
                <div>
                    <asp:TextBox ID="txtLabelName" runat="server" MaxLength="20"></asp:TextBox>
                </div>
                <label for="ddlControlType">
                    控件类型：<span class="required">*</span></label>
                <div>
                    <asp:DropDownList ID="ddlControlType" runat="server">
                    </asp:DropDownList>
                </div>
                <label for="ddlDataType">
                    数据类型：<span class="required">*</span></label>
                <div>
                    <asp:DropDownList ID="ddlDataType" runat="server">
                    </asp:DropDownList>
                </div>
                
                <label for="txtTableName">
                    表、视图名称：<span class="required">*</span></label>
                <asp:RequiredFieldValidator ID="rfvTableName" runat="server" ControlToValidate="txtTableName"
                    Display="Dynamic" ErrorMessage="">必须输入表、视图名</asp:RequiredFieldValidator>
                <div>
                    <asp:TextBox ID="txtTableName" runat="server" MaxLength="50"></asp:TextBox>
                </div>
                
                <label for="txtFieldName">
                    字段名称：<span class="required">*</span></label>
                <asp:RequiredFieldValidator ID="rfvFieldName" runat="server" ControlToValidate="txtFieldName"
                    Display="Dynamic" ErrorMessage="">必须输入字段名</asp:RequiredFieldValidator>
                <div>
                    <asp:TextBox ID="txtFieldName" runat="server" MaxLength="50"></asp:TextBox>
                </div>
                
                <label for="txtOperator">
                    运算符：<span class="required">*</span></label>
                <asp:RequiredFieldValidator ID="rfvOperator" runat="server" ControlToValidate="txtOperator"
                    Display="Dynamic" ErrorMessage="">必须输入运算符</asp:RequiredFieldValidator>
                 <div>
                    <asp:TextBox ID="txtOperator" runat="server" MaxLength="20"></asp:TextBox>
                </div>
                
                <label for="chkIsValid">
                    是否有效：<span class="required">*</span></label>
                <div>
                    <asp:CheckBox ID="chkIsValid" runat="server" Checked="true"></asp:CheckBox>
                </div>
                <label for="txtSerialNo">
                    序号：<span class="required">*</span></label>
                <asp:RequiredFieldValidator ID="rfvSerialNo" runat="server" ControlToValidate="txtSerialNo"
                    Display="Dynamic" ErrorMessage="">必须输入序号</asp:RequiredFieldValidator>
                <asp:RangeValidator ID="rvSerialNo" runat="server" ControlToValidate="txtSerialNo"
                    Display="Dynamic" ErrorMessage="" Type="Integer" MinimumValue="0" MaximumValue="99">0~99</asp:RangeValidator>
                <div>
                    <asp:TextBox ID="txtSerialNo" runat="server"></asp:TextBox>
                </div>
                <label for="txtRemark">
                    备注：</label>
                <div>
                    <asp:TextBox ID="txtRemark" runat="server" Rows="4" TextMode="MultiLine" MaxLength="255"></asp:TextBox>
                </div>
                <label for="txtAssembly">
                    装配集：</label>
                <div>
                    <asp:TextBox ID="txtAssembly" runat="server" MaxLength="255">
                    </asp:TextBox>
                </div>
                <label for="txtObjType">
                    类名称：</label>
                <div>
                    <asp:TextBox ID="txtObjType" runat="server" MaxLength="255">
                    </asp:TextBox>
                </div>
                <label for="txtMethod">
                    方法名：</label>
                <div>
                    <asp:TextBox ID="txtMethod" runat="server" MaxLength="255">
                    </asp:TextBox>
                </div>
                <label for="txtDataTextField">
                    显示绑定字段：</label>
                <div>
                    <asp:TextBox ID="txtDataTextField" runat="server" MaxLength="20">
                    </asp:TextBox>
                </div>
                <label for="txtDataValueField">
                    值绑定字段：</label>
                <div>
                    <asp:TextBox ID="txtDataValueField" runat="server" MaxLength="20">
                    </asp:TextBox>
                </div>
            </fieldset>
        </div>
    </div>
    </form>
</body>
</html>

<%@ Page Language="c#" CodeBehind="SYS_CompanyEdit.aspx.cs" AutoEventWireup="True"
    Inherits="SystemManagement.MZHUM.SYS_CompanyEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>企业信息维护</title>
    <link rel="stylesheet" type="text/css" href="../CSS/common.css" />
    <link href="../CSS/MZHUM/form2column.css" rel="stylesheet" type="text/css" />

    <script src="/aspnet_client/Shmzh.Web.UI/jquery-1.2.6.pack.js" type="text/javascript"></script>

</head>
<body>
    <form id="Form1" method="post" runat="server">
    <div>
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
                <legend>企业信息</legend>
                <div class="leftColumn">
                    <label for="txtCoCode">公司编号：<span class="required">*</span></label>
                    <asp:RequiredFieldValidator ID="RFVCoCode" runat="server" ErrorMessage="公司编号必须输入"
                        Display="Dynamic" ControlToValidate="txtCoCode">公司编号必须输入</asp:RequiredFieldValidator>
                    <div>
                        <asp:TextBox ID="txtCoCode" runat="server" MaxLength="20"></asp:TextBox>
                    </div>
                    <label for="txtCoCnName">
                        公司中文名称：<span class="required">*</span></label>
                    <asp:RequiredFieldValidator ID="Requiredfieldvalidator1" runat="server" ErrorMessage="公司中文名称必须输入"
                        Display="Dynamic" ControlToValidate="txtCoCnName">公司中文名称必须输入</asp:RequiredFieldValidator>
                    <div>
                        <asp:TextBox ID="txtCoCnName" runat="server" MaxLength="50"></asp:TextBox>
                    </div>
                    <label for="txtCoEnName">
                        公司英文名称：</label>
                    <div>
                        <asp:TextBox ID="txtCoEnName" runat="server" MaxLength="50"></asp:TextBox>
                    </div>
                    <label for="txtShortName">
                        公司简称：</label>
                    <div>
                        <asp:TextBox ID="txtShortName" runat="server" MaxLength="50"></asp:TextBox>
                    </div>
                    <label for="dpParentCompany">
                        上级公司：</label>
                    <div>
                        <asp:DropDownList ID="dpParentCompany" runat="server">
                        </asp:DropDownList>
                    </div>
                    <label for="txtArtificialPerson">
                        公司法人：</label>
                    <div>
                        <asp:TextBox ID="txtArtificialPerson" runat="server" MaxLength="50"></asp:TextBox>
                    </div>
                    <label for="txtMgr">
                        公司负责人：</label>
                    <div>
                        <asp:TextBox ID="txtMgr" runat="server" MaxLength="50"></asp:TextBox>
                    </div>
                    <label for="dpValid">
                        是否有效：</label>
                    <div>
                        <asp:CheckBox ID="chkIsValid" runat="server" Checked="true"/>
                    </div>
                </div>
                <div class="rightColumn">
                    <div class="content">
                        <label for="txtArea">
                            公司所在区域：</label>
                        <div>
                            <asp:TextBox ID="txtArea" runat="server" MaxLength="50"></asp:TextBox>
                        </div>
                        <label for="txtAddress">
                            企业地址：</label>
                        <div>
                            <asp:TextBox ID="txtAddress" runat="server" MaxLength="50"></asp:TextBox>
                        </div>
                        <label for="txtBussinessLicense">
                            营业执照：</label>
                        <div>
                            <asp:TextBox ID="txtBussinessLicense" runat="server" MaxLength="50"></asp:TextBox>
                        </div>
                        <label for="txtBussinessRange">
                            经营范围：</label>
                        <div>
                            <asp:TextBox ID="txtBussinessRange" runat="server" MaxLength="50" Rows="3" TextMode="MultiLine"></asp:TextBox>
                        </div>
                        <label for="txtRemark">
                            公司描述：</label>
                        <div>
                            <asp:TextBox ID="txtRemark" runat="server" MaxLength="50" TextMode="MultiLine" Rows="5"></asp:TextBox>
                        </div>
                        <label for="dpDefault">
                            是否默认：</label>
                        <div>
                            <asp:CheckBox ID="chkIsDefault" runat="server" Checked="false"/>
                        </div>
                    </div>
                </div>
            </fieldset>
        </div>
    </div>
    </form>
</body>
</html>

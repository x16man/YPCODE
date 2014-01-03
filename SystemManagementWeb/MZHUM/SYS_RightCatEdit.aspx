<%@ Page language="c#" Codebehind="SYS_RightCatEdit.aspx.cs" AutoEventWireup="True" Inherits="SystemManagement.MZHUM.SYS_RightCatEdit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
	<head>
		<title>权限分组</title>
		<link rel="stylesheet" type="text/css" href="../CSS/common.css" />
        <link rel="stylesheet" type="text/css" href="../CSS/MZHUM/form1column.css" />
        
        <script src="/aspnet_client/Shmzh.Web.UI/jquery-1.2.6.pack.js" type="text/javascript"></script>
	</head>
	<body>
		<form id="Form1" method="post" runat="server" >
		    <div>
                <mzh:MzhToolbar ID="MzhToolbar1" runat="server" onitempostback="MzhToolbar1_ItemPostBack">
                    <mzh:ToolbarButton ID="tbiAdd" runat="server" Cellpadding="0" Cellspacing="0" HasIcon="True" AutoPostback="True"
                        IconClass="add" IsShowText="True" ItemId="Add" LabelClass="labelCell" NakedLabelClass="nakedLabelCell" CausesValidation="False"
                        Text="新建" TableClass="buttonTable" />
                    <mzh:ToolbarButton ID="tbiSave" runat="server" Cellpadding="0" Cellspacing="0" HasIcon="True" AutoPostback="True"
                        IconClass="save" IsShowText="True" ItemId="Save" LabelClass="labelCell" NakedLabelClass="nakedLabelCell"
                        Text="保存" TableClass="buttonTable" />
                    <mzh:ToolbarSeparator ID="ToolbarSeparator1" runat="server" ItemId="" SeparatorClass="toolbarIconDivider" />
                    <mzh:ToolbarButton ID="tbiClose" runat="server" Cellpadding="0" Cellspacing="0" HasIcon="True" AutoPostback="False"
                        IconClass="close" IsShowText="True" ItemId="Close" LabelClass="labelCell" NakedLabelClass="nakedLabelCell"
                        onclick="window.close();" Text="关闭" TableClass="buttonTable" />
                </mzh:MzhToolbar>
                <div class="fieldWrapper">
                    <fieldset>
                        <legend>权限分组信息</legend>
                        <label for="txtRightCatCode" >编号:<span class="required">*</span></label>
                        <asp:requiredfieldvalidator id="rfvRightCatCode" runat="server" errormessage="" display="dynamic" controltovalidate="txtRightCatCode">必须输入编号</asp:requiredfieldvalidator>
						<asp:rangevalidator id="rvRightCatCode" runat="server" errormessage="" display="dynamic" controltovalidate="txtRightCatCode"  minimumvalue="0000000000" maximumvalue="9999999999">编号必须是0000000000~9999999999之间的数字</asp:rangevalidator>
                        <div>
							<asp:textbox id="txtRightCatCode" runat="server" MaxLength="10"></asp:textbox>
						</div>
						<label for="txtRightCatName" >名称:<span class="required">*</span></label>
						<asp:requiredfieldvalidator id="rfvRightCatName" runat="server" errormessage="必须输入分类名称" display="dynamic" controltovalidate="txtRightCatName">必须输入分组名称</asp:requiredfieldvalidator>
						<div>
							<asp:textbox id="txtRightCatName" runat="server" MaxLength="20"></asp:textbox>
						</div>
						<label for="chkIsValid">是否有效:</label>
						<div>
						    <asp:CheckBox ID="chkIsValid" runat="server" Checked="True" />
						</div>
						<label for="txtRemark">描述:<span class="required"></span></label>
						<div>
							<asp:textbox id="txtRemark" runat="server"  Rows="3" TextMode="MultiLine" MaxLength="50"></asp:textbox>
						</div>
                    </fieldset>
                </div>
            </div>
		</form>
	</body>
</html>

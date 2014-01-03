<%@ Page language="c#" Codebehind="SYS_UserRoleEdit.aspx.cs" AutoEventWireup="True" Inherits="SystemManagement.MZHUM.SYS_UserRoleEdit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
	<head>
		<title>用户角色维护</title>
		<link rel="stylesheet" type="text/css" href="../CSS/reset.css" />
		<link rel="Stylesheet" type="text/css" href="../CSS/toolbar.css" />
        <link rel="Stylesheet" type="text/css" href="../CSS/MZHUM/SYS_UserRoleEdit.css" />
        <script type="text/javascript" src="/aspnet_client/Shmzh.Web.UI/jquery-1.2.6.pack.js"></script>
		<script type="text/javascript" src="../JS/MZHUM/SYS_UserRoleEdit.js"></script>
	</head>
	<body>
		<form id="Form1" method="post" runat="server">
		    <div>
		        <mzh:mzhtoolbar id="MzhToolbar1" runat="server" 
                    onitempostback="MzhToolbar1_ItemPostBack">
		            <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable" itemid="Add"
						cellspacing="0" nakedlabelclass="nakedLabelCell" isshowtext="True" iconclass="add"
						hasicon="True" text="新建" id="tbiAdd" onclick="ShowUserList(this.id)"></mzh:toolbarbutton>
		            <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable" itemid="Save"
						cellspacing="0" autopostback="True" nakedlabelclass="nakedLabelCell" isshowtext="True" iconclass="save"
						hasicon="True" text="保存" id="tbiSave"></mzh:toolbarbutton>
					<mzh:toolbarseparator separatorclass="toolbarIconDivider" id="toolbarSeparator2" itemid="toolbarSeparator2"></mzh:toolbarseparator>
					<mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable" itemid="Close"
						cellspacing="0" nakedlabelclass="nakedLabelCell" isshowtext="True" iconclass="close"
						hasicon="True" text="关闭" id="tbiClose" onclick="window.close();"></mzh:toolbarbutton>
				</mzh:mzhtoolbar>
				<div class="hidden">
				    <input id="tb_UserIDs" type="hidden" runat="server"/>
					<input id="tb_UserNames" type="hidden" runat="server"/>
					<input id="tb_GroupIDs"  type="hidden" runat="server"/>
					<input id="tb_GroupNames" type="hidden" runat="server"/>
				    <asp:Button id="btn_selectUser" runat="server" Text="Button" onclick="btn_selectUser_Click"></asp:Button>
				</div>
				<div>
				    <div id="sidebar">
				        <asp:datagrid id="Emps" runat="server" Width="100%" ShowHeader="False" AutoGenerateColumns="False">
						    <Columns>
							    <asp:BoundColumn Visible="False" DataField="Code"></asp:BoundColumn>
							    <asp:TemplateColumn>
								    <HeaderStyle ></HeaderStyle>
								    <ItemStyle Width="16px"/>
								    <ItemTemplate>
									    <img alt="" src='<%# DataBinder.Eval(Container, "DataItem.UserType")=="Emp"?"../Images/USER.png":"../Images/GROUP.png" %>'/>
								    </ItemTemplate>
							    </asp:TemplateColumn>
							    <asp:BoundColumn DataField="Name">
								    <ItemStyle Wrap="False"></ItemStyle>
							    </asp:BoundColumn>
						    </Columns>
					    </asp:datagrid>
					</div>
				    <div id="main">
				        <div class="content">
				            <span><strong>角色</strong></span>
				            <asp:checkboxlist id="cblRoles" runat="server" RepeatColumns="2"></asp:checkboxlist>
				        </div>
				    </div>
				</div>
		    </div>
		</form>
		<script type="text/javascript">
			
		</script>
	</body>
</html>

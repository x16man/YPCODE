<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Default.Master" AutoEventWireup="true"
    CodeBehind="Grant.aspx.cs" Inherits="MZHMM.WebMM.SYS.Grant" %>

<%@ MasterType VirtualPath="~/Master/Default.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>SYS_RoleRight</title>
    <link href="../CSS/SYS/Grant.css" type="text/css" rel="stylesheet" />

    <script language="javascript" src="../JS/ExpandTable.js" type="text/javascript"></script>

    <script type="text/javascript">

        var popupWindow = new PopupWindow();
        var userFlag; /*全局*/

        function ShowUserList(elmId, flag) {
            userFlag = flag;
            popupWindow.setUrl('<%= Master.UserQueryPath %>');
            popupWindow.setSize(250, 400);
            popupWindow.showPopup(elmId, false);
        }

        function setUserInfo(loginName, empCode, empName, deptCode, deptName) {
        
            document.getElementById("<%= tb_rolename.ClientID%>").value = empName;
            document.getElementById("<%=tbRoleCode.ClientID%>").value = loginName;
            document.getElementById("<%= tb_UserIDs.ClientID %>").value = empCode;
            document.getElementById("<%= txtDeptName .ClientID %>").value = deptName;
        }

        function setEmpCode(userId) {
            document.getElementById("<%=tbRoleCode.ClientID%>").value = userId;
        }

        function setEmpCnName(userName) {
            document.getElementById("<%=tb_rolename.ClientID%>").value = userName;
        }
	
    </script>
    <style type="text/css">
     body
     {
         font-family: Arial,Helvetica,Sans-Serif,simsun;
         font-size: 12px;
         font-style: normal;
         margin: 0px !important;
         padding: 0px !important;
     }
    </style>
   

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="AjaxHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BodyHolder" runat="server">
    <table id="Table3" class="table_toolbar">
        <tr>
            <td class="td_RoleTitle bold_text" style="border-top:0px">
                <div class="Div_Title">
                    <img id="rolerights_img" class="Img_style" onclick="flexTable(this,document.getElementById('rolerights'),document.getElementById('<%=rolerights_flexvalue.ClientID%>'))"
                        alt="" src="../PICS/minus.gif" />
                    已授权用户列表
                </div>
            </td>
        </tr>
        <tr id="rolerights">
            <td class="td_rolerights" align="left">
                <table id="Table1" class="table_ItemList">
                    <tr>
                        <td>
                            <mzh:MzhDataGrid ID="MzhDataGrid1" runat="server" Width="100%" AutoGenerateColumns="False"
                                IsShowTotalRecorderCount="false" TotalRecorderCount="0" ShowFooter="false" IdCell="0"
                                selecttype="SingleSelect" name="MzhMultiSelectDataGrid">
                                <Columns>
                                    <asp:BoundColumn Visible="False" DataField="ID" HeaderText="PKID">
                                        <ItemStyle HorizontalAlign="Center" />
                                       
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="EmbracerDept" HeaderText="部门">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <HeaderStyle Width="10%" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="EmbracerName" HeaderText="姓名">
                                        <ItemStyle HorizontalAlign="Center" />
                                         <HeaderStyle Width="10%" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="Embracer" HeaderText="用户名">
                                        <HeaderStyle Width="10%" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="CreateTime" HeaderText="授权时间" DataFormatString="{0: HH:mm}">
                                        <ItemStyle HorizontalAlign="Center" />
                                         <HeaderStyle Width="10%" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="EffectTime" HeaderText="生效日期" DataFormatString="{0:yyyy-MM-dd}">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <HeaderStyle Width="10%" />
                                    </asp:BoundColumn>
                                    <asp:TemplateColumn HeaderText="登录后取回">
                                         <HeaderStyle Width="10%" />
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:CheckBox ID="CheckBox1" runat="server" Checked='<%# Eval("LoginIsValid") %>'>
                                            </asp:CheckBox>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:BoundColumn DataField="Reason" HeaderText="授权原因">
                                       
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                </Columns>
                            </mzh:MzhDataGrid>
                        </td>
                    </tr>
                    <tr>
                        <td class="td_RoleEdit">
                            <asp:Button ID="CancelGrant" runat="server" Text="取消授权" OnClick="CancelGrant_Click">
                            </asp:Button>
                            <asp:Button ID="Edit" runat="server" Text="编辑" OnClick="Edit_Click"></asp:Button>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <div class="Hidden">
        <asp:HiddenField ID="rolerights_flexvalue" runat="server" />
        <asp:HiddenField ID="txtPKID" runat="server" />
        <asp:HiddenField ID="addrole_flexvalue" runat="server" />
        <asp:HiddenField ID="tb_RoleCode" runat="server" />
        <asp:HiddenField ID="tb_UserIDs" runat="server" />
        <asp:HiddenField ID="tb_UserNames" runat="server" />
        <asp:HiddenField ID="tb_GroupIDs" runat="server" />
    </div>
    <asp:Panel ID="Panel1" runat="server">
        <table id="Table4" class="table_toolbar" width="100%" border="2">
            <tr>
                <td class="td_RoleTitle bold_text">
                    <div class="Div_Title">
                        <img id="addrole_img" onclick="flexTable(this,document.getElementById('addrole'),document.getElementById('<%=addrole_flexvalue.ClientID%>'))"
                         class="Img_style" src="../PICS/minus.gif" alt="" />
                        添加授权
                    </div>
                </td>
            </tr>
            <tr id="addrole">
                <td>
                    <table id="Table5" class="table_Role" width="100%" border="2" width="100%">
                        <tr style="height: 25">
                            <td style="width: 20%">
                                接受者用户名：
                            </td>
                            <td style="width: 80%" align="left">
                                <asp:TextBox ID="tbRoleCode" runat="server"></asp:TextBox>
                                <asp:HiddenField ID="txtDeptName" runat="server" />
                                <input id="btn_SelectUser" onclick="ShowUserList(this.id,1)" type="button" value="添加用户" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 20%">
                                接受者姓名：
                            </td>
                            <td style="width: 80%" align="left">
                                <asp:TextBox ID="tb_rolename" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 20%">
                                授权生效日期：
                            </td>
                            <td style="width: 80%" align="left">
                                <mzh:ToolbarCalendar ID="txtRoleDate" runat="server" ReadOnly="true" ToolTip="授权生效日期" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 20%">
                                授权原因：
                            </td>
                            <td style="width: 80%" align="left" style="word-wrap:break-word;word-break:break-all;">
                                <asp:TextBox ID="txtReason" runat="server" CssClass="input_RoleReason textarea" Rows="2"
                                    TextMode="MultiLine"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" Display="Dynamic" ControlToValidate="txtReason"
                        runat="server" ValidationExpression="(\w|\W){1,255}" ErrorMessage="授权原因所填字数不能大于255">
                    </asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 20%">
                                自动取回：
                            </td>
                            <td style="width: 80%" align="left">
                                <asp:CheckBox ID="CheckBox1" runat="server" Checked="True" />
                                下次登录自动取回
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Button ID="AddGrant" runat="server" Height="24px" OnClick="AddGrant_Click" Text="提交" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </asp:Panel>

    <script type="text/javascript">
    
    function document.all.<%=CancelGrant.ClientID%>.onclick()
	{
	    if(<%=MzhDataGrid1.ClientID%>_obj.getSelectedID()!=null&&<%=MzhDataGrid1.ClientID%>_obj.getSelectedID()!="")
	    {
		    
		}
		else
		{
			alert("请先选中某一条记录，再进行编辑！");
			return false;
		}
	}
	
	function document.all.<%=Edit.ClientID%>.onclick()
	{
	    if(<%=MzhDataGrid1.ClientID%>_obj.getSelectedID()!=null&&<%=MzhDataGrid1.ClientID%>_obj.getSelectedID()!="")
	    {
		    
		}
		else
		{
			alert("请先选中某一条记录，再进行编辑！");
			return false;
		}
	}
    </script>
   

</asp:Content>

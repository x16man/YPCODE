<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Default.Master" AutoEventWireup="true"
    CodeBehind="SolutionManage.aspx.cs" Inherits="MZHMM.WebMM.SYS.SolutionManage" %>

<%@ MasterType VirtualPath="~/Master/Default.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>SolutionManage</title>
    <link href="../CSS/SYS/SolutionManage.css" type="text/css" rel="stylesheet" />

    <script type="text/javascript">
		function DeleteConfirm()
		{
			if(<%=MzhDataGrid1.ClientID%>_obj.getSelectedID()!=null && <%=MzhDataGrid1.ClientID%>_obj.getSelectedID()!="")
			{
				return confirm('确实要删除此方案吗？');
			}
			else
			{
				alert("请选中一行记录再进行操作");
				return false;
			}
		}
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="AjaxHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BodyHolder" runat="server">
    <h3>查询管理</h3>
    <table id="Table1" class="table_toolbar" cellspacing="0" width="100%">
        <tr>
            <td>
                <mzh:MzhToolbar ID="MzhToolbar1" runat="server" OnItemPostBack="MzhToolbar1_ItemPostBack">
                    <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable"
                        autopostback="True" itemid="Delete" cellspacing="0" nakedlabelclass="nakedLabelCell"
                        isshowtext="True" iconclass="delete" hasicon="True" text="删除" id="toolbarButtondelete"
                        onclick="DeleteConfirm()">
                    </mzh:toolbarbutton>
                    <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable"
                        autopostback="True" itemid="SetDefault" cellspacing="0" nakedlabelclass="nakedLabelCell"
                        isshowtext="True" iconclass="edit" hasicon="True" text="设为默认方案" id="toolbarButtonSetDefault">
                    </mzh:toolbarbutton>
                    <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable"
                        autopostback="True" itemid="CancelDefault" cellspacing="0" nakedlabelclass="nakedLabelCell"
                        isshowtext="True" iconclass="edit" hasicon="True" text="取消默认方案" id="toolbarButtonCancelDefault">
                    </mzh:toolbarbutton>
                     <mzh:toolbarseparator separatorclass="toolbarIconDivider" id="toolbarSeparator2"
                        itemid="toolbarSeparator1">
                    </mzh:toolbarseparator>
                    <mzh:ToolbarLabel cellpadding="0" labelclass="labelCell" cellspacing="0" itemid="toolbarLabel2"
                        tableclass="labelTable" text="功能模块：" id="toolbarLabel3">
                    </mzh:ToolbarLabel>
                     <mzh:ToolbarDropdownList visible="True" cellpadding="0" cellspacing="0" itemid="ddlModule"
                        internaldropdownlist="" selectedindex="-1" tableclass="labelTable" autopostback="True"
                        enabled="True" items="(Collection)" id="ddlModule">
                    </mzh:ToolbarDropdownList>
                </mzh:MzhToolbar>
            </td>
        </tr>
        <tr>
            <td>
                <mzh:MzhDataGrid ID="MzhDataGrid1" runat="server" Width="100%" AutoGenerateColumns="False"
                    IsShowTotalRecorderCount="false" TotalRecorderCount="0" ShowFooter="True" IdCell="0"
                    selecttype="SingleSelect" name="MzhMultiSelectDataGrid" AllowSorting="True" OnPageSizeChanged="MzhDataGrid1_PageSizeChanged"
                    OnSortCommand="MzhDataGrid1_SortCommand">
                    <Columns>
                        <asp:BoundColumn Visible="False" DataField="SolutionID" HeaderText="SolutionID">
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="SolutionName" SortExpression="SolutionName" HeaderText="方案名称">
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="CreatTime" SortExpression="CreatTime" HeaderText="创建时间"
                            DataFormatString="{0:yyyy-MM-dd}"></asp:BoundColumn>
                        <asp:BoundColumn DataField="DefaultFlag" SortExpression="DefaultFlag" HeaderText="DefaultFlag">
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Description" SortExpression="Description" HeaderText="描述">
                        </asp:BoundColumn>
                    </Columns>
                </mzh:MzhDataGrid>
            </td>
        </tr>
    </table>
    <div class="hidden">
        <asp:Button ID="Button1" runat="server" />
    </div>
</asp:Content>

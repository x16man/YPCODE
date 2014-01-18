<%@ Page Language="c#" CodeBehind="WDRWSourceBrowser.aspx.cs" Title="领料单数据选择" MasterPageFile="~/Master/Default.Master"
    AutoEventWireup="True" Inherits="MZHMM.WebMM.Purchase.WDRWSourceBrowser" %>

<%@ MasterType VirtualPath="~/Master/Default.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>领料单数据选择</title>
    <meta content="物料需求单" name="keywords" />
    <link href="../CSS/ManageCommon.css" type="text/css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="AjaxHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BodyHolder" runat="server">
    <table class="managertable">
        <tr style="height: 20%">
            <td align="left">
                <mzh:MzhToolbar ID="MzhToolbar1" runat="server">
                    <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable"
                        itemid="Edit" cellspacing="0" nakedlabelclass="nakedLabelCell" isshowtext="True"
                        iconclass="present" hasicon="True" text="添加" id="toolbarButtonFirstAudit" onclick="insertItem()">
                    </mzh:toolbarbutton>
                </mzh:MzhToolbar>
            </td>
        </tr>
        <tr>
            <td style="height: 10">
            </td>
        </tr>
        <tr>
            <td>
                <mzh:MzhDataGrid ID="DataGrid1" runat="server" name="MzhMultiSelectDataGrid" AutoGenerateColumns="False"
                    PageSize="12" AllowPaging="True" selecttype="MultiSelect" AllowSorting="True"
                    IdCell="0" MultiPageShowMode="DropListMode" 
                    onitemdatabound="DataGrid1_ItemDataBound">
                    <Columns>
                        <asp:BoundColumn Visible="False" DataField="EntryNo" HeaderText="EntryNo"></asp:BoundColumn>
                        <asp:BoundColumn DataField="EntryNo" SortExpression="EntryNo" HeaderText="领料单编号">
                            <HeaderStyle Width="80px"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="ReqDeptName" SortExpression="ReqDeptName" HeaderText="部门">
                            <HeaderStyle Width="100px"></HeaderStyle>
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="ReqReason" SortExpression="ReqReason" HeaderText="用途">
                            <HeaderStyle Width="180px"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="ItemSummary" SortExpression="ItemSummary" HeaderText="物料摘要">
                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="DrawDate" SortExpression="DrawDate" HeaderText="领料日期"
                            DataFormatString="{0:yyyy-MM-dd}">
                            <HeaderStyle Width="120px"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundColumn>
                    </Columns>
                </mzh:MzhDataGrid>
            </td>
        </tr>
    </table>

    <script language="javascript" type="text/javascript">
			
			//添加
			function insertItem()
			{
				//window.opener.setEntry(getSelectedArray());//setEntry函数，在PBORWebcontrol.ascx文件中。
				window.opener.setMainInfo(<%=DataGrid1.ClientID%>_obj.getSelectedArray());
				window.close();
			}
    </script>

</asp:Content>

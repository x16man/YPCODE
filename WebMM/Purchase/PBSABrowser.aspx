<%@ Page Language="c#" CodeBehind="PBSABrowser.aspx.cs" MasterPageFile="~/Master/Default.Master" 
    AutoEventWireup="True" Inherits="MZHMM.WebMM.Purchase.PBSABrowser" %>

<%@ MasterType VirtualPath="~/Master/Default.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>采购收料单数据来源浏览</title>
    <link href="../CSS/StyleSheet.css" type="text/css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="AjaxHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BodyHolder" runat="server">
    <table id="Table1" cellspacing="0" cellpadding="0" width="98%" align="center" border="0">
        <tr>
            <td style="border-right: #ffcc33 1px solid; border-top: #ffcc33 1px solid; border-left: #ffcc33 1px solid;
                border-bottom: #ffcc33 1px solid; height: 26px; background-color: #ffffcc">
                &nbsp;&nbsp; &nbsp;&nbsp;&nbsp;订单数据选择&nbsp;&nbsp;
            </td>
        </tr>
        <tr>
            <td style="border-right: #ffcc33 1px solid; border-top: #ffcc33 1px solid; border-left: #ffcc33 1px solid;
                border-bottom: #ffcc33 1px solid; height: 26px; background-color: #ffffcc" height="26" align="left">
                <mzh:MzhToolbar ID="MzhToolbar1" runat="server">
                  <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable"
                        itemid="Edit" cellspacing="0" nakedlabelclass="nakedLabelCell" isshowtext="True"
                        iconclass="present" hasicon="True" text="添加" id="toolbarButtonFirstAudit" onclick="insertItem()">
                    </mzh:toolbarbutton>
                 </mzh:MzhToolbar>
                
            </td>
        </tr>
        <tr>
            <td>
                <mzh:MzhDataGrid ID="DataGrid1" runat="server" name="MzhMultiSelectDataGrid" AutoGenerateColumns="False"
                    PageSize="20" AllowPaging="True" SelectType="MultiSelect" AllowSorting="True" MultiPageShowMode="DropListMode"
                    IdCell="0" ShowPageSize="true">
                    <Columns>
                        <asp:BoundColumn Visible="False" DataField="PKID" HeaderText="PKID"></asp:BoundColumn>
                        <asp:BoundColumn DataField="EntryCode" SortExpression="EntryCode" HeaderText="订单编号">
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="PrvCode" SortExpression="PrvCode" HeaderText="供应商编号">
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="PrvName" SortExpression="PrvName" HeaderText="供应商名称">
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="BuyerCode" SortExpression="BuyerCode" HeaderText="采购员编号">
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="BuyerName" SortExpression="BuyerName" HeaderText="采购员名称">
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="SubTotal" SortExpression="SubTotal" HeaderText="总金额">
                            <ItemStyle HorizontalAlign="Right"></ItemStyle>
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="ENTRYDATE" SortExpression="ENTRYDATE" HeaderText="日期"
                            DataFormatString="{0:yyyy-MM-dd}">
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
				window.opener.setEntry(<%=DataGrid1.ClientID%>_obj.getSelectedArray());//setEntry函数，在PBORWebcontrol.ascx文件中。
				window.close();
			}
			

    </script>

</asp:Content>

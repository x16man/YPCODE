<%@ Page Language="c#" CodeBehind="PBSADetail.aspx.cs" AutoEventWireup="True" MasterPageFile="~/Master/Default.Master"
    Inherits="MZHMM.WebMM.Purchase.PBSADetail" %>

<%@ MasterType VirtualPath="~/Master/Default.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>有效订单明细内容</title>
    <meta content="物料需求单" name="keywords">
    <link href="../CSS/StyleSheet.css" type="text/css" rel="stylesheet">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="AjaxHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BodyHolder" runat="server">
    <table id="Table1" cellspacing="0" cellpadding="0" width="98%" align="center" border="0">
        <tr>
            <td>
                <mzh:MzhDataGrid ID="DataGrid1" runat="server" name="MzhMultiSelectDataGrid" AutoGenerateColumns="False"
                    PageSize="20" AllowPaging="True" onitemdatabound="DataGrid1_ItemDataBound">
                    <Columns>
                        <asp:BoundColumn DataField="ItemCode" HeaderText="物料编号"></asp:BoundColumn>
                        <asp:BoundColumn DataField="ItemName" HeaderText="物料名称"></asp:BoundColumn>
                        <asp:BoundColumn DataField="ItemSpecial" HeaderText="规格型号"></asp:BoundColumn>
                        <asp:BoundColumn DataField="ItemUnitName" HeaderText="单位"></asp:BoundColumn>
                        <asp:BoundColumn DataField="ItemPrice" HeaderText="物料单价">
                            <ItemStyle HorizontalAlign="Right"></ItemStyle>
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="ItemNum" HeaderText="欠交数量">
                            <ItemStyle HorizontalAlign="Right"></ItemStyle>
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="ItemMoney" HeaderText="金额">
                            <ItemStyle HorizontalAlign="Right"></ItemStyle>
                        </asp:BoundColumn>
                    </Columns>
                    <PagerStyle HorizontalAlign="Right" Mode="NumericPages"></PagerStyle>
                </mzh:MzhDataGrid>
            </td>
        </tr>
    </table>
</asp:Content>

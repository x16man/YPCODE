<%@ Page Language="c#" CodeBehind="PBSADetail.aspx.cs" AutoEventWireup="True" MasterPageFile="~/Master/Default.Master"
    Inherits="MZHMM.WebMM.Purchase.PBSADetail" %>

<%@ MasterType VirtualPath="~/Master/Default.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>��Ч������ϸ����</title>
    <meta content="��������" name="keywords">
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
                        <asp:BoundColumn DataField="ItemCode" HeaderText="���ϱ��"></asp:BoundColumn>
                        <asp:BoundColumn DataField="ItemName" HeaderText="��������"></asp:BoundColumn>
                        <asp:BoundColumn DataField="ItemSpecial" HeaderText="����ͺ�"></asp:BoundColumn>
                        <asp:BoundColumn DataField="ItemUnitName" HeaderText="��λ"></asp:BoundColumn>
                        <asp:BoundColumn DataField="ItemPrice" HeaderText="���ϵ���">
                            <ItemStyle HorizontalAlign="Right"></ItemStyle>
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="ItemNum" HeaderText="Ƿ������">
                            <ItemStyle HorizontalAlign="Right"></ItemStyle>
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="ItemMoney" HeaderText="���">
                            <ItemStyle HorizontalAlign="Right"></ItemStyle>
                        </asp:BoundColumn>
                    </Columns>
                    <PagerStyle HorizontalAlign="Right" Mode="NumericPages"></PagerStyle>
                </mzh:MzhDataGrid>
            </td>
        </tr>
    </table>
</asp:Content>

<%@ Page Language="c#" CodeBehind="ProjectItem.aspx.cs" MasterPageFile="~/Master/Default.Master"
    AutoEventWireup="True" Inherits="MZHMM.WebMM.Storage.ProjectItem" %>

<%@ MasterType VirtualPath="~/Master/Default.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>
        <%=ProjectName%></title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="AjaxHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BodyHolder" runat="server">
    <div>
        <mzh:MzhDataGrid ID="DataGrid1" runat="server" Width="100%" HighLightColor="Gold"
            SelectedColor="Blue" IdCell="0" AllowSorting="True" SelectType="MultiSelect"
            CellPadding="3" BorderWidth="1px" CellSpacing="1" BorderColor="#0099CC" AutoGenerateColumns="False"
            CssClass="datagrid" PageSize="20" name="MzhMultiSelectDataGrid" 
            ShowFooter="True" onitemdatabound="DataGrid1_ItemDataBound">
            <Columns>
                <asp:BoundColumn DataField="ItemCode" SortExpression="ItemCode" HeaderText="物料编号">
                    <ItemStyle CssClass="center"></ItemStyle>
                </asp:BoundColumn>
                <asp:BoundColumn DataField="ItemName" SortExpression="ItemName" HeaderText="物料名称">
                    <ItemStyle CssClass="left" VerticalAlign="Middle"></ItemStyle>
                </asp:BoundColumn>
                <asp:BoundColumn DataField="ItemSpec" SortExpression="ItemSpec" HeaderText="规格型号">
                    <ItemStyle CssClass="left" VerticalAlign="Middle"></ItemStyle>
                </asp:BoundColumn>
                <asp:BoundColumn DataField="ItemUnitName" SortExpression="ItemUnitName" HeaderText="单位">
                    <ItemStyle CssClass="right" VerticalAlign="Middle"></ItemStyle>
                </asp:BoundColumn>
                <asp:BoundColumn DataField="ItemPrice" SortExpression="ItemPrice" HeaderText="单价">
                    <ItemStyle CssClass="right" VerticalAlign="Middle"></ItemStyle>
                </asp:BoundColumn>
                <asp:BoundColumn DataField="ItemNum" SortExpression="ItemNum" HeaderText="数量" FooterText="总计：">
                    <ItemStyle CssClass="right" VerticalAlign="Middle"></ItemStyle>
                    <FooterStyle CssClass="right"></FooterStyle>
                </asp:BoundColumn>
                <asp:BoundColumn DataField="ItemMoney" SortExpression="ItemMoney" HeaderText="金额">
                    <ItemStyle CssClass="right" VerticalAlign="Middle"></ItemStyle>
                    <FooterStyle CssClass="right" />
                </asp:BoundColumn>
            </Columns>
        </mzh:MzhDataGrid></div>
</asp:Content>

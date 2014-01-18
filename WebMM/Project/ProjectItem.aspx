<%@ Page Language="c#" CodeBehind="ProjectItem.aspx.cs" AutoEventWireup="True" Inherits="MZHMM.WebMM.Project.ProjectItem" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>项目材料浏览</title>
    <meta name="keywords" content="领料单">
    <link href="../CSS/StyleSheet.css" type="text/css" rel="stylesheet">

    <script src="../JS/SearchBar.js"></script>

    <script src="../JS/MenuShow.js"></script>

</head>
<body bottommargin="0" leftmargin="0" topmargin="0" rightmargin="0">
    <form id="Form1" method="post" runat="server">
    <table id="Table1" cellspacing="0" cellpadding="0" width="98%" align="center" border="0">
        <tr>
            <td>
                <mzh:MzhDataGrid ID="DataGrid1" runat="server" Width="100%" AllowPaging="True" PageSize="20"
                    CssClass="datagrid" BorderColor="#0099CC" CellSpacing="1" 
                    BorderWidth="1px" CellPadding="3"
                    name="MzhMultiSelectDataGrid" AutoGenerateColumns="False" SelectType="MultiSelect"
                    AllowSorting="True" IdCell="0" SelectedColor="Blue" HighLightColor="Gold" 
                    ShowFooter="True" onitemdatabound="DataGrid1_ItemDataBound">
                    <PagerStyle HorizontalAlign="Right" Mode="NumericPages"></PagerStyle>
                    <AlternatingItemStyle BackColor="#D8F4FF"></AlternatingItemStyle>
                    <ItemStyle BackColor="#F2F8FF"></ItemStyle>
                    <HeaderStyle HorizontalAlign="Center" BackColor="#99CCFF"></HeaderStyle>
                    <Columns>
                        <asp:BoundColumn Visible="False" DataField="ItemCode" HeaderText="ItemCode"></asp:BoundColumn>
                        <asp:BoundColumn DataField="ItemCode" SortExpression="ItemCode" HeaderText="物料编号"
                            FooterText="合计：">
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                            <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle"></FooterStyle>
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="ItemName" SortExpression="ItemName" HeaderText="物料名称">
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="ItemSpec" SortExpression="ItemSpec" HeaderText="规格型号">
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="ItemUnitName" SortExpression="ItemUnitName" HeaderText="单位">
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="ItemPrice" SortExpression="ItemPrice" HeaderText="单价"
                            DataFormatString="{0:n3}">
                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="ItemNum" SortExpression="ItemNum" HeaderText="数量" DataFormatString="{0:n2}">
                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="ItemMoney" SortExpression="ItemMoney" HeaderText="金额"
                            DataFormatString="{0:n2}">
                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
                            <FooterStyle HorizontalAlign="Right" VerticalAlign="Middle"></FooterStyle>
                        </asp:BoundColumn>
                    </Columns>
                </mzh:MzhDataGrid>
            </td>
        </tr>
        <tr>
            <td>
            </td>
        </tr>
    </table>
    s
    </form>
</body>
</html>

<%@ Page Language="c#" CodeBehind="ItemStockBrowser.aspx.cs" AutoEventWireup="True"
    Inherits="MZHMM.WebMM.Storage.ItemStockBrowser" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>物料库存浏览</title>
    <meta name="keywords" content="物料库存" />
    <link href="../CSS/StyleSheet.css" type="text/css" rel="stylesheet" />

    <script src="../JS/SearchBar.js"></script>

    <script src="../JS/MenuShow.js"></script>

</head>
<body >
    <form id="Form1" method="post" runat="server">
    <font face="宋体"></font>
    <table id="Table1" cellspacing="0" cellpadding="0" width="98%" align="center" border="0">
        <tr>
            <td style="border-right: #ffcc33 1px solid; border-top: #ffcc33 1px solid; border-left: #ffcc33 1px solid;
                border-bottom: #ffcc33 1px solid; height: 26px; background-color: #ffffcc" height="26">
                &nbsp;&nbsp;
                <tr>
                    <td>
                        <mzh:MzhDataGrid ID="DataGrid1" runat="server" Width="100%" AllowPaging="True" PageSize="20"
                            CssClass="datagrid" BorderColor="#0099CC" CellSpacing="1" BorderWidth="1px" CellPadding="3"
                            name="MzhMultiSelectDataGrid" AutoGenerateColumns="False" SelectType="MultiSelect"
                            AllowSorting="True" IdCell="0" SelectedColor="Blue" HighLightColor="Gold">
                            <PagerStyle HorizontalAlign="Right" Mode="NumericPages"></PagerStyle>
                            <AlternatingItemStyle BackColor="#D8F4FF"></AlternatingItemStyle>
                            <ItemStyle BackColor="#F2F8FF"></ItemStyle>
                            <HeaderStyle HorizontalAlign="Center" BackColor="#99CCFF"></HeaderStyle>
                            <Columns>
                                <asp:BoundColumn Visible="False" DataField="EntryNo" HeaderText="EntryNo"></asp:BoundColumn>
                                <asp:BoundColumn DataField="EntryCode" SortExpression="EntryCode" HeaderText="单据编号">
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="EntryStateName" SortExpression="EntryStateName" HeaderText="状态">
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="EntryDate" SortExpression="EntryDate" HeaderText="申请日期"
                                    DataFormatString="{0:d}">
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="AuthorName" SortExpression="AuthorName" HeaderText="填写人">
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="AuthorDeptName" SortExpression="AuthorDeptName" HeaderText="填写部门">
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="ReqReason" SortExpression="ReqReason" HeaderText="申请理由">
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="SubTotal" SortExpression="SubTotal" HeaderText="总金额">
                                    <ItemStyle HorizontalAlign="Right"></ItemStyle>
                                </asp:BoundColumn>
                            </Columns>
                        </mzh:MzhDataGrid>
                    </td>
                </tr>
                </td>
                </tr>
    </table>
    </form>
</body>
</html>

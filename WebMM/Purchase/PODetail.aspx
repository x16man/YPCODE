<%@ Page Language="c#" CodeBehind="PODetail.aspx.cs" MasterPageFile="~/Master/Default.Master"
    AutoEventWireup="True" Inherits="MZHMM.WebMM.Purchase.PODetail" %>

<%@ MasterType VirtualPath="~/Master/Default.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>采购订单明细</title>
    <link href="../CSS/Purchase/PODetail.css" type="text/css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="AjaxHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BodyHolder" runat="server">
    <table id="Table2" cellspacing="0" class="myTableToolbar" width="100%">
        <tr>
            <td align="left">
                <uc1:DocWebControl ID="DocWebControl1" runat="server"></uc1:DocWebControl>
                <a href="POReport.aspx?EntryNo=<%= Master.EntryNo %>">打印</a>
                <asp:LinkButton ID="LinkPrint" runat="server" Visible="false" OnClick="LinkPrint_Click">打印</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td>
                <table id="Table4" cellspacing="0" class="table_Item printTb">
                    <tr>
                        <td colspan="2" height="160px" valign="top">
                            <mzh:MzhDataGrid ID="DGModel_Items1" runat="server" IdCell="0" MultiPageShowMode="DropListMode"
                                selecttype="SingleSelect" ShowFooter="true" AllowPaging="false" AllowSorting="false"
                                PageSize="<%$ AppSettings:pageDetailSize %>" name="MzhMultiSelectDataGrid" AutoGenerateColumns="False"
                                OnItemDataBound="DGModel_Items1_ItemDataBound">
                                <Columns>
                                    
                                    <asp:BoundColumn DataField="ItemCode" SortExpression="ItemCode" HeaderText="物料编号">
                                        <ItemStyle Width="8%" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="NewCode" SortExpression="NewCode" HeaderText="新编号">
                                        <ItemStyle Width="8%" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="ItemName" SortExpression="ItemName" HeaderText="物料名称">
                                        <ItemStyle Width="15%" HorizontalAlign="Left" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="ItemSpecial" SortExpression="ItemSpecial" HeaderText="规格型号">
                                        <ItemStyle Width="9%" HorizontalAlign="Left" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="ItemUnit" Visible="false" SortExpression="ItemUnit" HeaderText="单位">
                                        <ItemStyle Width="10%" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="ItemUnitName" SortExpression="ItemUnitName" HeaderText="单位">
                                        <ItemStyle Width="10%" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="ItemNum" SortExpression="ItemNum" HeaderText="数量">
                                        <ItemStyle Width="10%" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="ItemPrice" SortExpression="ItemPrice" FooterText="合计："
                                        HeaderText="单价">
                                        <ItemStyle HorizontalAlign="Right" Width="10%" />
                                        <FooterStyle Font-Bold="true" HorizontalAlign="Right" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="ItemMoney" SortExpression="ItemMoney" DataFormatString="{0:n4}"
                                        HeaderText="金额">
                                        <HeaderStyle Width="10%" />
                                        <ItemStyle HorizontalAlign="Right" />
                                        <FooterStyle HorizontalAlign="Right" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="Proposer" SortExpression="Proposer" HeaderText="需求人">
                                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="ItemLackNum" HeaderText="ItemLackNum" Visible="false">
                                    </asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="EntryNo" Visible="false" DataField="EntryNo"></asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="SerialNo" Visible="false" DataField="SerialNo"></asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="用途代码"></asp:BoundColumn>
                                </Columns>
                            </mzh:MzhDataGrid>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            供应商：
                            <asp:Label ID="lblPrvName" runat="server"></asp:Label>
                        </td>
                        <td align="left">
                            供应商电话：
                            <asp:Label ID="lblTel" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            供应商地址：
                            <asp:Label ID="lblAdd" runat="server"></asp:Label>
                        </td>
                        <td align="left">
                            税务登记号：
                            <asp:Label ID="lblTaxNo" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            营业执照号：
                            <asp:Label ID="lblLicence" runat="server"></asp:Label>
                        </td>
                        <td align="left">
                            传真：
                            <asp:Label ID="lblFax" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            开户银行：
                            <asp:Label ID="lblBank" runat="server"></asp:Label>
                        </td>
                        <td align="left">
                            开户帐号：
                            <asp:Label ID="lblAccount" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="left">
                            备注：<asp:Label ID="lblRemark" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <table id="Table3" cellspacing="0" class="table_Footer">
                    <tr>
                        <td>
                            制单部门：<asp:Label ID="lblAuthorDept" runat="server"></asp:Label>
                        </td>
                        <td>
                            制单人：<asp:Label ID="lblAuthorName" runat="server"></asp:Label>
                        </td>
                        <td>
                            采购员：<asp:Label ID="lblBuyer" runat="server"></asp:Label>
                        </td>
                        <td>总经办：
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>

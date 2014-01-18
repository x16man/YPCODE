<%@ Page Language="c#" CodeBehind="PBORDetail.aspx.cs" MasterPageFile="~/Master/Default.Master"
    AutoEventWireup="True" Inherits="MZHMM.WebMM.Purchase.PBORDetail" %>

<%@ MasterType VirtualPath="~/Master/Default.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>物料系统</title>
    <link href="../CSS/ManageCommon.css" type="text/css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="AjaxHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BodyHolder" runat="server">
    <table class="managertable">
        <tr>
            <td>
                <uc1:DocWebControl ID="doc1" runat="server"></uc1:DocWebControl>
            </td>
        </tr>
        <tr>
            <td>
                <table class="managertable">
                    <tr>
                        <td>
                            供应单位：
                            <asp:Label ID="lblProvider" runat="server"></asp:Label>
                        </td>
                        <td>
                            仓库：
                            <asp:Label ID="lblStock" runat="server"></asp:Label>
                        </td>
                        <td>
                            发票号：
                            <asp:Label ID="lblInvoice" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            合同编号：
                            <asp:Label ID="lblJFKM" runat="server"></asp:Label>
                        </td>
                        <td>
                            结算方式：
                            <asp:Label ID="lblPayStyle" runat="server"></asp:Label>
                        </td>
                        <td>
                            验收情况：
                            <asp:Label ID="lblChkResult" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <mzh:MzhDataGrid ID="DGModel_Items1" runat="server" IdCell="0" MultiPageShowMode="DropListMode"
                                selecttype="SingleSelect" ShowFooter="true" AllowPaging="false" AllowSorting="false"
                                PageSize="<%$ AppSettings:pageDetailSize %>" name="MzhMultiSelectDataGrid" AutoGenerateColumns="False"
                                OnItemDataBound="DGModel_Items1_ItemDataBound">
                                <Columns>
                                    <asp:BoundColumn DataField="ItemCode" SortExpression="ItemCode" HeaderText="物料编号">
                                        <HeaderStyle Width="10%" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="NewCode" SortExpression="NewCode" HeaderText="新编号">
                                        <HeaderStyle Width="10%" />
                                    </asp:BoundColumn>

                                    <asp:BoundColumn DataField="ItemName" SortExpression="ItemName" HeaderText="物料名称">
                                        <HeaderStyle Width="10%" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="ItemSpecial" SortExpression="ItemSpecial" HeaderText="规格型号">
                                        <HeaderStyle Width="10%" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="ItemUnit" Visible="false" SortExpression="ItemUnit" HeaderText="单位">
                                        <HeaderStyle Width="5%" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="ItemUnitName" SortExpression="ItemUnitName" HeaderText="单位名称">
                                        <HeaderStyle Width="7%" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="BatchCode" SortExpression="BatchCode" HeaderText="批号">
                                        <HeaderStyle Width="5%" />
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="PlanNum1" SortExpression="PlanNum1" HeaderText="应收数量">
                                        <HeaderStyle Width="10%" />
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="ItemNum1" SortExpression="ItemNum1" HeaderText="实收数量">
                                        <HeaderStyle Width="10%" />
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="ItemPrice" SortExpression="ItemPrice" HeaderText="单价"
                                        FooterText="合计：">
                                        <HeaderStyle Width="10%" />
                                        <ItemStyle HorizontalAlign="Right" />
                                        <FooterStyle HorizontalAlign="Right" Font-Bold="true" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="ItemMoney" SortExpression="ItemMoney" HeaderText="金额">
                                        <HeaderStyle Width="10%" />
                                        <FooterStyle HorizontalAlign="Right" />
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="ItemSum" SortExpression="ItemSum" HeaderText="总金额">
                                        <HeaderStyle Width="10%" />
                                        <FooterStyle HorizontalAlign="Right" />
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="EntryNo" Visible="false" HeaderText="EntryNo">
                                    </asp:BoundColumn>
                                     <asp:BoundColumn DataField="SerialNo" Visible="false" HeaderText="SerialNo">
                                    </asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="用途代码">
                                        <HeaderStyle Width="8%" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                </Columns>
                            </mzh:MzhDataGrid>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            费用：
                            <asp:Label ID="lblUsedFor" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <uc1:DocAuditWebControl ID="DocAuditWebControl1" runat="server"></uc1:DocAuditWebControl>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="tdPaddingT5">
                <table class="managertable">
                    <tr>
                        <td>
                            制单部门：
                            <asp:Label ID="lblAuthorDept" runat="server"></asp:Label>
                        </td>
                        <td>
                            制单人：
                            <asp:Label ID="lblAuthor" runat="server"></asp:Label>
                        </td>
                        <td>
                            采购员：
                            <asp:Label ID="lblBuyer" runat="server"></asp:Label>
                        </td>
                        <td>
                            收料人：
                            <asp:Label ID="lblAccept" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>

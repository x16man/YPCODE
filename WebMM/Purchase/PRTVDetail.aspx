<%@ Page Language="c#" CodeBehind="PRTVDetail.aspx.cs" MasterPageFile="~/Master/Default.Master"
    AutoEventWireup="True" Inherits="MZHMM.WebMM.Purchase.PRTVDetail" %>

<%@ MasterType VirtualPath="~/Master/Default.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>物料系统 </title>
    <link href="../CSS/Purchase/PRTVDetail.css" type="text/css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="AjaxHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BodyHolder" runat="server">
    <table id="Table5" cellspacing="0" class="table_toolbar">
        <tr>
            <td>
                <uc1:DocWebControl ID="doc1" runat="server"></uc1:DocWebControl>
            </td>
        </tr>
        <tr>
            <td>
                <table id="Table4" cellspacing="0" class="table_Item printTb">
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
                            借方科目：
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
                        <td>
                            币种：
                            <asp:Label ID="lblCurrency" runat="server"></asp:Label>
                        </td>
                        <td colspan="2">
                            原采购收料单：
                            <asp:HyperLink ID="HyperLink1" runat="server" Target="_blank">HyperLink</asp:HyperLink>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <mzh:MzhDataGrid ID="DGModel_Items1" runat="server" IdCell="0" MultiPageShowMode="DropListMode"
                                selecttype="SingleSelect" ShowFooter="true" AllowPaging="false" AllowSorting="false" PageSize="<%$ AppSettings:pageDetailSize %>"
                                name="MzhMultiSelectDataGrid" AutoGenerateColumns="False" OnItemDataBound="DGModel_Items1_ItemDataBound">
                                <Columns>
                                    <asp:BoundColumn DataField="ItemCode" SortExpression="ItemCode" HeaderText="物料编号">
                                        <ItemStyle Width="11%" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="ItemName" SortExpression="ItemName" HeaderText="物料名称">
                                        <ItemStyle Width="15%" HorizontalAlign="Left" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="ItemSpecial" SortExpression="ItemSpecial" HeaderText="规格型号">
                                        <ItemStyle Width="13%" HorizontalAlign="Left" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="ItemUnit" Visible="false" SortExpression="ItemUnit" HeaderText="单位">
                                        <ItemStyle Width="10%" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="ItemUnitName" SortExpression="ItemUnitName" HeaderText="单位">
                                        <ItemStyle Width="10%" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="BatchCode" SortExpression="ItemUnitName" HeaderText="批号">
                                        <ItemStyle Width="10%" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="ItemPrice" SortExpression="ItemPrice" HeaderText="单价" >
                                        <ItemStyle HorizontalAlign="Right" Width="10%" />
                                        <FooterStyle Font-Bold="true" HorizontalAlign="Right" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="PlanNum1" SortExpression="PlanNum1" HeaderText="应退数量">
                                        <ItemStyle Width="10%" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="ItemNum1" SortExpression="ItemNum1" HeaderText="实退数量" FooterText="合计：">
                                        <ItemStyle Width="10%" HorizontalAlign="Right" />
                                        <FooterStyle HorizontalAlign="Right" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="ItemMoney" SortExpression="ItemMoney" DataFormatString="{0:n3}"
                                        HeaderText="金额">
                                        <HeaderStyle Width="12%" />
                                        <ItemStyle HorizontalAlign="Right" />
                                        <FooterStyle HorizontalAlign="Right" />
                                    </asp:BoundColumn>
                                </Columns>
                            </mzh:MzhDataGrid>
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
            <td>
                <table id="Table3" cellspacing="0" class="table_Footer">
                    <tr>
                        <td>
                            制单部门：
                            <asp:Label ID="lblAuthorDept" runat="server"></asp:Label>
                        </td>
                        <td>
                            制单人：<asp:Label ID="lblAuthor" runat="server"></asp:Label>
                        </td>
                        <td>
                            采购员：
                            <asp:Label ID="lblBuyer" runat="server"></asp:Label>
                        </td>
                        <td>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <uc1:StorageDropdownlist ID="ddlPayStyle" runat="server"></uc1:StorageDropdownlist>
    <uc1:StorageDropdownlist ID="ddlCurrency" runat="server"></uc1:StorageDropdownlist>

    <script language="javascript" type="text/javascript">
				i = document.getElementById("<%=ddlPayStyle.thisDDL.ClientID%>").selectedIndex;
				<%=lblPayStyle.ClientID%>.innerText = document.getElementById("<%=ddlPayStyle.thisDDL.ClientID%>")[i].text;
				j= document.getElementById("<%=ddlCurrency.thisDDL.ClientID%>").selectedIndex;
				<%=lblCurrency.ClientID%>.innerText = document.getElementById("<%=ddlCurrency.thisDDL.ClientID%>")[j].text;
    </script>

</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Default.Master" AutoEventWireup="true"
    CodeBehind="PBORUpdateInvoice.aspx.cs" Inherits="WebMM.Purchase.PBORUpdateInvoice" %>

<%@ MasterType VirtualPath="~/Master/Default.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>收料单--修改发票号</title>
    <link href="../CSS/ManageCommon.css" type="text/css" rel="stylesheet" />
    <link href="../CSS/Purchase/PBORDetail.css" type="text/css" rel="stylesheet" />
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
                        <td colspan="3">
                            <table width="100%">
                                <tr>
                                    <td style="width: 50%">
                                        供应单位：
                                        <asp:Label ID="lblProvider" runat="server"></asp:Label>
                                    </td>
                                    <td style="width: 50%">
                                        仓库：
                                        <asp:Label ID="lblStock" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            发票号：
                            <asp:TextBox ID="txtInvoice" runat="server" SkinID="PurposeDisTable"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 33%">
                            合同编号：
                            <asp:Label ID="lblJFKM" runat="server"></asp:Label>
                        </td>
                        <td style="width: 33%">
                            结算方式：
                            <asp:Label ID="lblPayStyle" runat="server"></asp:Label>
                        </td>
                        <td style="width: 33%">
                            验收情况：
                            <asp:Label ID="lblChkResult" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <mzh:MzhDataGrid ID="DGModel_Items1" runat="server" IdCell="0" MultiPageShowMode="DropListMode"
                                AllowPaging="false" AllowSorting="false" ShowFooter="true" selecttype="SingleSelect"
                                name="MzhMultiSelectDataGrid" AutoGenerateColumns="False" OnItemDataBound="DGModel_Items1_ItemDataBound">
                                <Columns>
                                    <asp:BoundColumn DataField="ItemCode" SortExpression="ItemCode" HeaderText="物料编码">
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="ItemName" SortExpression="ItemName" HeaderText="物料名称">
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="ItemSpecial" SortExpression="ItemSpecial" HeaderText="规格型号">
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="ItemUnitName" SortExpression="ItemUnitName" HeaderText="单位">
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="BatchCode" SortExpression="BatchCode" HeaderText="单价">
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="PlanNum" SortExpression="PlanNum" HeaderText="应收数" DataFormatString="{0:c}">
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="ItemNum" SortExpression="ItemNum" HeaderText="实收数" FooterText="合计："
                                        DataFormatString="{0:c}">
                                        <FooterStyle Font-Bold="true" HorizontalAlign="Right" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="ItemMoney" SortExpression="ItemMoney" HeaderText="金额"
                                        DataFormatString="{0:c}">
                                        <ItemStyle HorizontalAlign="Right"></ItemStyle>
                                        <FooterStyle HorizontalAlign="Right" Font-Bold="true" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="ItemSum" SortExpression="ItemSum" HeaderText="总金额" DataFormatString="{0:c}">
                                        <ItemStyle HorizontalAlign="Right"></ItemStyle>
                                        <FooterStyle HorizontalAlign="Right" Font-Bold="true" />
                                    </asp:BoundColumn>
                                </Columns>
                            </mzh:MzhDataGrid>
                        </td>
                    </tr>
                    <tr style="height: 20px">
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
        <tr>
            <td colspan="3" align="center">
                <asp:Button ID="btnSave" runat="server" Text="修改发票" OnClick="btnSave_Click" />&nbsp;&nbsp;&nbsp
                <asp:Button ID="btnClose" runat="server" Text="关闭" OnClientClick="window.close()" />
            </td>
        </tr>
    </table>
</asp:Content>

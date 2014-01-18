<%@ Page Language="c#" CodeBehind="PBORDetail.aspx.cs" MasterPageFile="~/Master/Default.Master"
    AutoEventWireup="True" Inherits="MZHMM.WebMM.Purchase.PBORDetail" %>

<%@ MasterType VirtualPath="~/Master/Default.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>����ϵͳ</title>
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
                            ��Ӧ��λ��
                            <asp:Label ID="lblProvider" runat="server"></asp:Label>
                        </td>
                        <td>
                            �ֿ⣺
                            <asp:Label ID="lblStock" runat="server"></asp:Label>
                        </td>
                        <td>
                            ��Ʊ�ţ�
                            <asp:Label ID="lblInvoice" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            ��ͬ��ţ�
                            <asp:Label ID="lblJFKM" runat="server"></asp:Label>
                        </td>
                        <td>
                            ���㷽ʽ��
                            <asp:Label ID="lblPayStyle" runat="server"></asp:Label>
                        </td>
                        <td>
                            ���������
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
                                    <asp:BoundColumn DataField="ItemCode" SortExpression="ItemCode" HeaderText="���ϱ��">
                                        <HeaderStyle Width="10%" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="NewCode" SortExpression="NewCode" HeaderText="�±��">
                                        <HeaderStyle Width="10%" />
                                    </asp:BoundColumn>

                                    <asp:BoundColumn DataField="ItemName" SortExpression="ItemName" HeaderText="��������">
                                        <HeaderStyle Width="10%" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="ItemSpecial" SortExpression="ItemSpecial" HeaderText="����ͺ�">
                                        <HeaderStyle Width="10%" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="ItemUnit" Visible="false" SortExpression="ItemUnit" HeaderText="��λ">
                                        <HeaderStyle Width="5%" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="ItemUnitName" SortExpression="ItemUnitName" HeaderText="��λ����">
                                        <HeaderStyle Width="7%" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="BatchCode" SortExpression="BatchCode" HeaderText="����">
                                        <HeaderStyle Width="5%" />
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="PlanNum1" SortExpression="PlanNum1" HeaderText="Ӧ������">
                                        <HeaderStyle Width="10%" />
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="ItemNum1" SortExpression="ItemNum1" HeaderText="ʵ������">
                                        <HeaderStyle Width="10%" />
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="ItemPrice" SortExpression="ItemPrice" HeaderText="����"
                                        FooterText="�ϼƣ�">
                                        <HeaderStyle Width="10%" />
                                        <ItemStyle HorizontalAlign="Right" />
                                        <FooterStyle HorizontalAlign="Right" Font-Bold="true" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="ItemMoney" SortExpression="ItemMoney" HeaderText="���">
                                        <HeaderStyle Width="10%" />
                                        <FooterStyle HorizontalAlign="Right" />
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="ItemSum" SortExpression="ItemSum" HeaderText="�ܽ��">
                                        <HeaderStyle Width="10%" />
                                        <FooterStyle HorizontalAlign="Right" />
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="EntryNo" Visible="false" HeaderText="EntryNo">
                                    </asp:BoundColumn>
                                     <asp:BoundColumn DataField="SerialNo" Visible="false" HeaderText="SerialNo">
                                    </asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="��;����">
                                        <HeaderStyle Width="8%" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                </Columns>
                            </mzh:MzhDataGrid>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            ���ã�
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
                            �Ƶ����ţ�
                            <asp:Label ID="lblAuthorDept" runat="server"></asp:Label>
                        </td>
                        <td>
                            �Ƶ��ˣ�
                            <asp:Label ID="lblAuthor" runat="server"></asp:Label>
                        </td>
                        <td>
                            �ɹ�Ա��
                            <asp:Label ID="lblBuyer" runat="server"></asp:Label>
                        </td>
                        <td>
                            �����ˣ�
                            <asp:Label ID="lblAccept" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>

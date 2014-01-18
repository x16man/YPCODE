<%@ Page Language="c#" CodeBehind="PODetail.aspx.cs" MasterPageFile="~/Master/Default.Master"
    AutoEventWireup="True" Inherits="MZHMM.WebMM.Purchase.PODetail" %>

<%@ MasterType VirtualPath="~/Master/Default.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>�ɹ�������ϸ</title>
    <link href="../CSS/Purchase/PODetail.css" type="text/css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="AjaxHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BodyHolder" runat="server">
    <table id="Table2" cellspacing="0" class="myTableToolbar" width="100%">
        <tr>
            <td align="left">
                <uc1:DocWebControl ID="DocWebControl1" runat="server"></uc1:DocWebControl>
                <a href="POReport.aspx?EntryNo=<%= Master.EntryNo %>">��ӡ</a>
                <asp:LinkButton ID="LinkPrint" runat="server" Visible="false" OnClick="LinkPrint_Click">��ӡ</asp:LinkButton>
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
                                    
                                    <asp:BoundColumn DataField="ItemCode" SortExpression="ItemCode" HeaderText="���ϱ��">
                                        <ItemStyle Width="8%" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="NewCode" SortExpression="NewCode" HeaderText="�±��">
                                        <ItemStyle Width="8%" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="ItemName" SortExpression="ItemName" HeaderText="��������">
                                        <ItemStyle Width="15%" HorizontalAlign="Left" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="ItemSpecial" SortExpression="ItemSpecial" HeaderText="����ͺ�">
                                        <ItemStyle Width="9%" HorizontalAlign="Left" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="ItemUnit" Visible="false" SortExpression="ItemUnit" HeaderText="��λ">
                                        <ItemStyle Width="10%" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="ItemUnitName" SortExpression="ItemUnitName" HeaderText="��λ">
                                        <ItemStyle Width="10%" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="ItemNum" SortExpression="ItemNum" HeaderText="����">
                                        <ItemStyle Width="10%" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="ItemPrice" SortExpression="ItemPrice" FooterText="�ϼƣ�"
                                        HeaderText="����">
                                        <ItemStyle HorizontalAlign="Right" Width="10%" />
                                        <FooterStyle Font-Bold="true" HorizontalAlign="Right" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="ItemMoney" SortExpression="ItemMoney" DataFormatString="{0:n4}"
                                        HeaderText="���">
                                        <HeaderStyle Width="10%" />
                                        <ItemStyle HorizontalAlign="Right" />
                                        <FooterStyle HorizontalAlign="Right" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="Proposer" SortExpression="Proposer" HeaderText="������">
                                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="ItemLackNum" HeaderText="ItemLackNum" Visible="false">
                                    </asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="EntryNo" Visible="false" DataField="EntryNo"></asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="SerialNo" Visible="false" DataField="SerialNo"></asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="��;����"></asp:BoundColumn>
                                </Columns>
                            </mzh:MzhDataGrid>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            ��Ӧ�̣�
                            <asp:Label ID="lblPrvName" runat="server"></asp:Label>
                        </td>
                        <td align="left">
                            ��Ӧ�̵绰��
                            <asp:Label ID="lblTel" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            ��Ӧ�̵�ַ��
                            <asp:Label ID="lblAdd" runat="server"></asp:Label>
                        </td>
                        <td align="left">
                            ˰��ǼǺţ�
                            <asp:Label ID="lblTaxNo" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            Ӫҵִ�պţ�
                            <asp:Label ID="lblLicence" runat="server"></asp:Label>
                        </td>
                        <td align="left">
                            ���棺
                            <asp:Label ID="lblFax" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            �������У�
                            <asp:Label ID="lblBank" runat="server"></asp:Label>
                        </td>
                        <td align="left">
                            �����ʺţ�
                            <asp:Label ID="lblAccount" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="left">
                            ��ע��<asp:Label ID="lblRemark" runat="server"></asp:Label>
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
                            �Ƶ����ţ�<asp:Label ID="lblAuthorDept" runat="server"></asp:Label>
                        </td>
                        <td>
                            �Ƶ��ˣ�<asp:Label ID="lblAuthorName" runat="server"></asp:Label>
                        </td>
                        <td>
                            �ɹ�Ա��<asp:Label ID="lblBuyer" runat="server"></asp:Label>
                        </td>
                        <td>�ܾ��죺
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>

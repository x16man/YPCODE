<%@ Page Language="c#" CodeBehind="ROSDetail.aspx.cs" MasterPageFile="~/Master/Default.Master"
    AutoEventWireup="True" Inherits="MZHMM.WebMM.Purchase.ROSDetail" %>

<%@ MasterType VirtualPath="~/Master/Default.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>�깺����ϸ��Ϣ</title>
    <link href="../CSS/Purchase/ROSDetail.css" type="text/css" rel="stylesheet">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="AjaxHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BodyHolder" runat="server">
    <table id="Table2" cellspacing="0" class="table_toolbar" style="width: 100%">
        <tr>
            <td >
                <uc1:DocWebControl ID="DocWebControl1" runat="server"></uc1:DocWebControl>
            </td>
        </tr>
        <tr>
            <td>
                <table id="Table4" cellspacing="0" class="table_Item printTb" style="width: 100%">
                    <tr style="height:80">
                        <td  style="height:80" align="left">
                            ��;���뼰��;����:
                            <asp:Label ID="lblReason" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <mzh:MzhDataGrid ID="DGModel_Items1" runat="server" IdCell="0" MultiPageShowMode="DropListMode"
                                selecttype="SingleSelect" ShowFooter="true" AllowPaging="false" AllowSorting="false" PageSize="<%$ AppSettings:pageDetailSize %>"
                                name="MzhMultiSelectDataGrid" AutoGenerateColumns="False" 
                                onitemdatabound="DGModel_Items1_ItemDataBound">
                                <Columns>
                                    
                                    <asp:BoundColumn DataField="ItemCode" SortExpression="ItemCode" HeaderText="���ϱ��">
                                        <HeaderStyle Width="8%" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="NewCode" SortExpression="NewCode" HeaderText="�±��">
                                        <HeaderStyle Width="8%" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="ItemName" SortExpression="ItemName" HeaderText="��������">
                                        <HeaderStyle Width="15%"  />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="ItemSpecial" SortExpression="ItemSpecial" HeaderText="����ͺ�">
                                        <HeaderStyle Width="9%"  />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="ItemUnit" Visible="false" SortExpression="ItemUnit" HeaderText="��λ">
                                        <HeaderStyle Width="10%" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="ItemUnitName" SortExpression="ItemUnitName" HeaderText="��λ����">
                                        <HeaderStyle Width="10%" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="ItemPrice" SortExpression="ItemPrice" HeaderText="����">
                                        <HeaderStyle Width="10%" />
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="ItemNum" SortExpression="ItemNum" HeaderText="�깺����" FooterText="�ϼƣ�">
                                        <ItemStyle HorizontalAlign="Right" />
                                         <FooterStyle Font-Bold="true" HorizontalAlign="Right" />
                                        <HeaderStyle Width="10%" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn  DataField="ItemMoney" SortExpression="ItemMoney" DataFormatString="{0:n2}"
                                        HeaderText="���"><HeaderStyle Width="10%" />
                                       <ItemStyle HorizontalAlign="Right" />
                                       <FooterStyle HorizontalAlign="Right" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="ReqDate" SortExpression="ReqDate" HeaderText="��������" DataFormatString="{0:d}">
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        <HeaderStyle Width="10%" />
                                        <FooterStyle   />
                                    </asp:BoundColumn>
                                </Columns>
                            </mzh:MzhDataGrid>
                        </td>
                    </tr>
                    <tr style="height:80">
                        <td  style="height:80" align="left">
                            ��ע:
                            <asp:Label ID="lblRemark" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
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
                            �Ƶ����ţ�
                            <asp:Label ID="lblAuthorDept" runat="server"></asp:Label>
                        </td>
                        <td>
                            �Ƶ��ˣ�
                            <asp:Label ID="lblAuthorName" runat="server">Label</asp:Label>
                        </td>
                        <td>
                            ���벿�ţ�
                            <asp:Label ID="lblReqDept" runat="server"></asp:Label>
                        </td>
                        <td>
                            �����ˣ�
                            <asp:Label ID="lblProposer" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>

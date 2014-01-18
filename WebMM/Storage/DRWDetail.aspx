<%@ Page Language="c#" CodeBehind="DRWDetail.aspx.cs" MasterPageFile="~/Master/Default.Master" AutoEventWireup="True" Inherits="MZHMM.WebMM.Storage.DRWDetail" %>

<%@ MasterType VirtualPath="~/Master/Default.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>���ϵ���ϸ</title>
    <link href="../CSS/Storage/DRWDetail.css" type="text/css" rel="stylesheet">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="AjaxHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BodyHolder" runat="server">
    <table id="Table2" cellspacing="0" class="table_toolbar" width="100%">
        <tr>
            <td>
                <uc1:DocWebControl id="DocWebControl1" runat="server">
                </uc1:DocWebControl>
            </td>
        </tr>
        <tr>
            <td>
                <table class="table_Item printTb" id="Table4" cellspacing="0">
                    <tr>
                        <td align="left">
                            ��;���뼰��;������<asp:Label ID="lblReason" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <mzh:MzhDataGrid ID="DGModel_Items1" runat="server" IdCell="0" MultiPageShowMode="DropListMode"
                                selecttype="SingleSelect" ShowFooter="true" AllowPaging="false" AllowSorting="false"
                                name="MzhMultiSelectDataGrid" AutoGenerateColumns="False" PageSize="<%$ AppSettings:pageDetailSize %>"
                                onitemdatabound="DGModel_Items1_ItemDataBound">
                                <Columns>
                                    <asp:BoundColumn DataField="ItemCode" SortExpression="ItemCode" HeaderText="���ϱ��">
                                        <ItemStyle Width="10%" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="NewCode" SortExpression="NewCode" HeaderText="�±��">
                                        <ItemStyle Width="10%" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="ItemName" SortExpression="ItemName" HeaderText="��������">
                                        <ItemStyle Width="15%" HorizontalAlign="Left" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="ItemSpecial" SortExpression="ItemSpecial" HeaderText="����ͺ�">
                                        <ItemStyle Width="9%" HorizontalAlign="Left" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="ItemUnit" Visible="false" SortExpression="ItemUnit" HeaderText="��λ">
                                        <ItemStyle Width="8%" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="ItemUnitName" SortExpression="ItemUnitName" HeaderText="��λ">
                                        <ItemStyle Width="10%" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="StockNum" SortExpression="StockNum" HeaderText="�����" >
                                        <ItemStyle Width="10%" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="PlanNum" SortExpression="PlanNum" HeaderText="��������" >
                                        <ItemStyle Width="10%" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="ItemNum" SortExpression="ItemNum" HeaderText="ʵ������" >
                                        <ItemStyle Width="10%" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="ItemPrice" SortExpression="ItemPrice" HeaderText="����" FooterText="�ϼ�:">
                                        <ItemStyle HorizontalAlign="Right" Width="10%" />
                                        <FooterStyle Font-Bold="true" HorizontalAlign="Right" />
                                    </asp:BoundColumn>
                                   <asp:BoundColumn  DataField="ItemMoney" SortExpression="ItemMoney" DataFormatString="{0:n3}"
                                        HeaderText="���">
                                       <ItemStyle HorizontalAlign="Right"  Width="10%"/>
                                       <FooterStyle HorizontalAlign="Right" />
                                    </asp:BoundColumn>
                                    
                                </Columns>
                            </mzh:MzhDataGrid>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            ��ע��<asp:Label ID="lblRemark" runat="server"></asp:Label>
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
                    <tr>
                        <td>
                            �ֿ����ƣ�<asp:Label ID="lbStoName" runat="server"></asp:Label>
                        </td>
                        <td>
                            �����ˣ�
                            <asp:Label ID="lbStoManager" runat="server"></asp:Label>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>

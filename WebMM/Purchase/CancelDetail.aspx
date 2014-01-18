<%@ Page Language="c#" CodeBehind="CancelDetail.aspx.cs" MasterPageFile="~/Master/Default.Master"
    AutoEventWireup="True" Inherits="MZHMM.WebMM.Purchase.CancelDetail" %>

<%@ MasterType VirtualPath="~/Master/Default.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>�ɹ�������</title>
    <link href="../CSS/Purchase/CancelDetail.css" type="text/css" rel="stylesheet">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="AjaxHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BodyHolder" runat="server">
    <table id="Table2" cellspacing="0" class="table_toolbar">
        <tr>
            <td>
                <uc1:DocWebControl ID="DocWebControl1" runat="server"></uc1:DocWebControl>
            </td>
        </tr>
        <tr>
            <td>
                <table cellspacing="0" class="table_Item printTb">
                    <tr>
                        <td>
                           
                            <mzh:MzhDataGrid ID="DGModel_Items1" runat="server" IdCell="0" MultiPageShowMode="DropListMode"
                                selecttype="SingleSelect"  AllowPaging="false" AllowSorting="false" PageSize="<%$ AppSettings:pageDetailSize %>"
                                name="MzhMultiSelectDataGrid" AutoGenerateColumns="False"  ShowFooter="false"
                                onitemdatabound="DGModel_Items1_ItemDataBound">
                                <Columns>
                                    <asp:BoundColumn DataField="ItemCode" SortExpression="ItemCode" HeaderText="���ϱ��">
                                        <ItemStyle Width="10%" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="ItemName" SortExpression="ItemName" HeaderText="��������">
                                        <ItemStyle Width="20%" HorizontalAlign="Left" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="ItemSpecial" SortExpression="ItemSpecial" HeaderText="����ͺ�">
                                        <ItemStyle Width="10%" HorizontalAlign="Left" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="ItemUnit" Visible="false" SortExpression="ItemUnit" HeaderText="��λ">
                                        <ItemStyle Width="10%" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="ItemUnitName" SortExpression="ItemUnitName" HeaderText="��λ">
                                        <ItemStyle Width="10%" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="ItemPrice" SortExpression="ItemPrice" HeaderText="����">
                                        <ItemStyle HorizontalAlign="Right" Width="10%" />
                                        <FooterStyle Font-Bold="true" HorizontalAlign="Right" />
                                    </asp:BoundColumn>
                                     <asp:BoundColumn DataField="ItemNum" SortExpression="ItemNum" HeaderText="��������" >
                                        <ItemStyle Width="10%" />
                                    </asp:BoundColumn>
                                    
                                   
                                    <asp:BoundColumn  DataField="ItemMoney" SortExpression="ItemMoney" DataFormatString="{0:n4}"
                                        HeaderText="���"><HeaderStyle Width="10%" />
                                       <ItemStyle HorizontalAlign="Right" />
                                       <FooterStyle HorizontalAlign="Right" />
                                    </asp:BoundColumn>
                                    
                                </Columns>
                            </mzh:MzhDataGrid>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            ��ע:<asp:Label ID="lblRemark" runat="server"></asp:Label>
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

<%@ Page Language="c#" CodeBehind="RTSDetail.aspx.cs" MasterPageFile="~/Master/Default.Master" AutoEventWireup="True" Inherits="MZHMM.WebMM.Storage.RTSDetail" %>

<%@ MasterType VirtualPath="~/Master/Default.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>����ϵͳ</title>
    <link href="../CSS/Storage/RTSDetail.css" type="text/css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="AjaxHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BodyHolder" runat="server">
    <table id="Table1" cellspacing="1" class="table_toolbar">
        <tr>
            <td colspan="4">
                <uc1:DocWebControl id="DocWebControl1" runat="server">
                </uc1:DocWebControl>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <table id="Table4" cellspacing="0" class="table_Item printTb" width="100%">
                    <tr>
                        <td class="td_label" align="left">
                            ��;���뼰��;����
                        </td>
                        <td class="td_Content" align="left">
                            <asp:Label ID="lblReason" runat="server" CssClass="lbl_Reason"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                         
                              <mzh:MzhDataGrid ID="DGModel_Items1" runat="server" IdCell="0" MultiPageShowMode="DropListMode"
                                selecttype="SingleSelect" ShowFooter="true" AllowPaging="false" AllowSorting="false"
                                name="MzhMultiSelectDataGrid" AutoGenerateColumns="False"  PageSize="<%$ AppSettings:pageDetailSize %>"
                                onitemdatabound="DGModel_Items1_ItemDataBound">
                                <Columns>
                                    <asp:BoundColumn DataField="ItemCode" SortExpression="ItemCode" HeaderText="���ϱ��">
                                        <ItemStyle Width="12%" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="ItemName" SortExpression="ItemName" HeaderText="��������">
                                        <ItemStyle Width="18%" HorizontalAlign="Left" />
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
                                   
                                    <asp:BoundColumn DataField="PlanNum" SortExpression="PlanNum" HeaderText="Ӧ������" >
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
                                        HeaderText="���"><HeaderStyle Width="10%" />
                                       <ItemStyle HorizontalAlign="Right" />
                                       <FooterStyle HorizontalAlign="Right" />
                                    </asp:BoundColumn>
                                    
                                </Columns>
                            </mzh:MzhDataGrid>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            ��ע
                        </td>
                        <td align="left">
                            <asp:Label ID="lblRemark" runat="server" CssClass="lbl_Remark"></asp:Label>
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
            <td class="table_toolbar_td">
                ���벿�ţ�
            </td>
            <td class="table_toolbar_td">
                <asp:Label ID="lblReqDept" runat="server" CssClass="lbl_ReqDept"></asp:Label>
            </td>
            <td class="table_toolbar_td">
                �����ˣ�
            </td>
            <td class="table_toolbar_td">
                <asp:Label ID="lblProposer" runat="server" CssClass="lbl_Proposer"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                �Ƶ����ţ�
            </td>
            <td>
                <asp:Label ID="lblAuthorDept" runat="server"></asp:Label>
            </td>
            <td>
                �Ƶ��ˣ�
            </td>
            <td>
                <asp:Label ID="lblAuthorName" runat="server">Label</asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                �ֿ����ƣ�
            </td>
            <td>
                <asp:Label ID="lbStoName" runat="server"></asp:Label>
            </td>
            <td>
                �ֿ����Ա��
            </td>
            <td>
                <asp:Label ID="lbStoManager" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td rowspan="1">
                ���ս����
            </td>
            <td>
                <asp:Label ID="lblChkResult" runat="server"></asp:Label>
            </td>
            <td>
                �����ˣ�
            </td>
            <td>
                <asp:Label ID="lblChkMan" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
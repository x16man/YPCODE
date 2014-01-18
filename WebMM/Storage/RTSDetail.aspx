<%@ Page Language="c#" CodeBehind="RTSDetail.aspx.cs" MasterPageFile="~/Master/Default.Master" AutoEventWireup="True" Inherits="MZHMM.WebMM.Storage.RTSDetail" %>

<%@ MasterType VirtualPath="~/Master/Default.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>物料系统</title>
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
                            用途代码及用途描述
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
                                    <asp:BoundColumn DataField="ItemCode" SortExpression="ItemCode" HeaderText="物料编号">
                                        <ItemStyle Width="12%" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="ItemName" SortExpression="ItemName" HeaderText="物料名称">
                                        <ItemStyle Width="18%" HorizontalAlign="Left" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="ItemSpecial" SortExpression="ItemSpecial" HeaderText="规格型号">
                                        <ItemStyle Width="10%" HorizontalAlign="Left" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="ItemUnit" Visible="false" SortExpression="ItemUnit" HeaderText="单位">
                                        <ItemStyle Width="10%" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="ItemUnitName" SortExpression="ItemUnitName" HeaderText="单位">
                                        <ItemStyle Width="10%" />
                                    </asp:BoundColumn>
                                   
                                    <asp:BoundColumn DataField="PlanNum" SortExpression="PlanNum" HeaderText="应退数量" >
                                        <ItemStyle Width="10%" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="ItemNum" SortExpression="ItemNum" HeaderText="实退数量" >
                                        <ItemStyle Width="10%" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="ItemPrice" SortExpression="ItemPrice" HeaderText="单价" FooterText="合计:">
                                        <ItemStyle HorizontalAlign="Right" Width="10%" />
                                        <FooterStyle Font-Bold="true" HorizontalAlign="Right" />
                                    </asp:BoundColumn>
                                   <asp:BoundColumn  DataField="ItemMoney" SortExpression="ItemMoney" DataFormatString="{0:n3}"
                                        HeaderText="金额"><HeaderStyle Width="10%" />
                                       <ItemStyle HorizontalAlign="Right" />
                                       <FooterStyle HorizontalAlign="Right" />
                                    </asp:BoundColumn>
                                    
                                </Columns>
                            </mzh:MzhDataGrid>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            备注
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
                申请部门：
            </td>
            <td class="table_toolbar_td">
                <asp:Label ID="lblReqDept" runat="server" CssClass="lbl_ReqDept"></asp:Label>
            </td>
            <td class="table_toolbar_td">
                申请人：
            </td>
            <td class="table_toolbar_td">
                <asp:Label ID="lblProposer" runat="server" CssClass="lbl_Proposer"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                制单部门：
            </td>
            <td>
                <asp:Label ID="lblAuthorDept" runat="server"></asp:Label>
            </td>
            <td>
                制单人：
            </td>
            <td>
                <asp:Label ID="lblAuthorName" runat="server">Label</asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                仓库名称：
            </td>
            <td>
                <asp:Label ID="lbStoName" runat="server"></asp:Label>
            </td>
            <td>
                仓库管理员：
            </td>
            <td>
                <asp:Label ID="lbStoManager" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td rowspan="1">
                验收结果：
            </td>
            <td>
                <asp:Label ID="lblChkResult" runat="server"></asp:Label>
            </td>
            <td>
                验收人：
            </td>
            <td>
                <asp:Label ID="lblChkMan" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
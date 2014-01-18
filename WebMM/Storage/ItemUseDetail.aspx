<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Default.Master" AutoEventWireup="true"
    CodeBehind="ItemUseDetail.aspx.cs" Inherits="WebMM.Storage.ItemUseDetail" %>

<%@ MasterType VirtualPath="~/Master/Default.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../CSS/ManageCommon.css" type="text/css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="AjaxHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BodyHolder" runat="server">
    <table  cellspacing="1" cellpadding="3" width="100%" border="1" style="word-break: break-all">
        <tr>
            <td colspan="2">
                <table   cellspacing="1" cellpadding="3" width="100%" border="1" style="word-break: break-all">
                    <tr>
                        <td id="WebPanel1_header" class="WebPanel1hdrxpnd" align="left">
                            <img id="WebPanel1_header_img" height="0" width="0" style="float: right;" src="../images/igpnl_up.gif"
                                expandedurl="/ig_common/images/igpnl_up.gif" collapsedurl="/ig_common/images/igpnl_dwn.gif" />
                            物料使用情况
                        </td>
                    </tr>
                </table>
                <table   cellspacing="1" cellpadding="3" width="100%" border="1" style="word-break: break-all">
                    <tr>
                        <td rowspan="3">
                        </td>
                        <td>
                            物料编号：
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtItemCode1" runat="server" CssClass="input_txtItemCode1 input"></asp:TextBox>
                        </td>
                        <td>
                            物料名称：
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtItemName1" runat="server" CssClass="input_txtItemName1 input"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width:20%">
                            规格型号：
                        </td>
                        <td style="width:30%" align="left">
                            <asp:TextBox ID="txtItemSpec1" runat="server" CssClass="input_txtItemSpec1 input"></asp:TextBox>
                        </td>
                        <td style="width:20%">
                            单位：
                        </td>
                        <td style="width:30%" align="left">
                            <asp:TextBox ID="txtItemUnit1" runat="server" CssClass="input_txtItemUnit1 input"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            仓库：
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtStoName1" runat="server" CssClass="input_txtStoName1 input"></asp:TextBox>
                        </td>
                        <td>
                            架位：
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtConName1" runat="server" CssClass="input_txtConName1 input"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="width:600">
                <mzh:MzhDataGrid ID="MzhDataGrid1" runat="server"  HighLightColor="Gold"
                    SelectedColor="Blue" AutoGenerateColumns="False" IdCell="0" SelectType="SingleSelect"
                    name="MzhMultiSelectDataGrid" class="datagrid" Width="600" >
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
                    <Columns>
                        <asp:BoundColumn DataField="Classify" HeaderText="用途分类">
                            <ItemStyle HorizontalAlign="center" VerticalAlign="Middle"></ItemStyle>
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="ReqReason" HeaderText="用途">
                            <ItemStyle HorizontalAlign="left" VerticalAlign="Middle"></ItemStyle>
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="ItemNum" HeaderText="数量">
                            <ItemStyle HorizontalAlign="right" VerticalAlign="Middle"></ItemStyle>
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="ItemMoney" HeaderText="金额">
                            <ItemStyle HorizontalAlign="right" VerticalAlign="Middle"></ItemStyle>
                        </asp:BoundColumn>
                    </Columns>
                </mzh:MzhDataGrid>
            </td>
        </tr>
        <tr>
            <td class="td_Submit" colspan="2">
                <asp:Button ID="btnClose" runat="server" Text="关闭"  OnClientClick="window.close();" />
            </td>
        </tr>
    </table>
</asp:Content>

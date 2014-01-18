<%@ Control Language="c#" AutoEventWireup="True" CodeBehind="WUCFeedbackPurchase.ascx.cs"
    Inherits="WebMM.Modules.WUCFeedbackPurchase" %>
<asp:Repeater ID="rptPurchase" runat="server">
    <ItemTemplate>
                <div class="ReqReason" onclick="$('#rptPurchase<%# DataBinder.Eval(Container.DataItem, "ReqReasonCode")%>').toggle();">
                    用途：<%# DataBinder.Eval(Container.DataItem, "ReqReason")%></div>
                <div id='rptPurchase<%# DataBinder.Eval(Container.DataItem, "ReqReasonCode")%>' class="PurchaseDetailDiv">
                    <asp:Repeater ID="rptDetail" runat="server" DataSource='<%# GetChildDataByReqReasonCode(Eval("ReqReasonCode").ToString()) %>'>
                        <HeaderTemplate>
                            <table class="datagrid">
                                <tr class="m-grid-hd-row">
                                    <th width="60px">
                                        编号
                                    </th>
                                    <th>
                                        名称
                                    </th>
                                    <th style="width:60px;">
                                        数量
                                    </th>
                                </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td><%# DataBinder.Eval(Container.DataItem, "ItemCode")%>
                                </td>
                                <td><%# DataBinder.Eval(Container.DataItem, "ItemName")%>
                                </td>
                                <td style="text-align:right;"><%# DataBinder.Eval(Container.DataItem, "ItemNum")%>
                                </td>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            </table></FooterTemplate>
                    </asp:Repeater>
                </div>
    </ItemTemplate>
</asp:Repeater>

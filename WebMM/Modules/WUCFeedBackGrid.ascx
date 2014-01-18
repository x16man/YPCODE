<%@ Control Language="c#" AutoEventWireup="True" CodeBehind="WUCFeedBackGrid.ascx.cs"
    Inherits="WebMM.Modules.WUCFeedBackGrid" %>
<div id="rptDraw">
    <asp:Repeater ID="rptDraw" runat="server">
        <ItemTemplate>
            <div class="ReqReason" onclick="$('#rptDraw<%# DataBinder.Eval(Container.DataItem, "ReqReasonCode")%>').toggle();">
                用途：<%# DataBinder.Eval(Container.DataItem, "ReqReason")%></div>
            <div id='rptDraw<%# DataBinder.Eval(Container.DataItem, "ReqReasonCode")%>' class="PurchaseDetailDiv">
                <asp:Repeater ID="rptDetail" runat="server" DataSource='<%# GetChildDataByReqReasonCode(Eval("ReqReasonCode").ToString()) %>'>
                    <HeaderTemplate>
                        <table class="datagrid">
                            <tr class="m-grid-hd-row">
                                <th width="20px">
                                </th>
                                <th width="60px">
                                    编号
                                </th>
                                <th>
                                    名称
                                </th>
                                <th style="width: 60px;">
                                    数量
                                </th>
                            </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td style="text-align:center">
                                <input class="CheckBoxDrawDetail" value='<%# DataBinder.Eval(Container.DataItem, "PKID")%>'
                                    type="checkbox" />
                            </td>
                            <td>
                                <%# DataBinder.Eval(Container.DataItem, "ItemCode")%>
                            </td>
                            <td>
                                <%# DataBinder.Eval(Container.DataItem, "ItemName")%>
                            </td>
                            <td style="text-align: right;">
                                <%# DataBinder.Eval(Container.DataItem, "ItemNum")%>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </table></FooterTemplate>
                </asp:Repeater>
            </div>
        </ItemTemplate>
    </asp:Repeater>
    <div style="border-style: solid; border-width: 1px 0 0; border-color: #EEEEEE; text-align: center;">
        <a href="javascript:void(0);" onclick="popupDraw();" title="请选择相同用途下的物料来生成领料单。" style="margin: auto;
            border: solid 1px #eeeeee; margin-top: 3px; position: relative; display: block;
            width: 80px; height: 22px; line-height: 22px;">生成领料单</a>
    </div>
</div>

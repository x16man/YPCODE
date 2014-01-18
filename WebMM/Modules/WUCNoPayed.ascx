<%@ Control Language="c#" AutoEventWireup="True" CodeBehind="WUCNoPayed.ascx.cs"
    Inherits="WebMM.Modules.WUCNoPayed" %>
    <asp:Repeater ID="rptNOPayedDraw" runat="server" 
    >
    <ItemTemplate>
                <div class="ReqReason" onclick="$('#rptNOPayedDraw<%# DataBinder.Eval(Container.DataItem, "buyercode")%>').toggle();">
                    采购员：<%# DataBinder.Eval(Container.DataItem, "BuyerName")%></div>
                <div id='rptNOPayedDraw<%# DataBinder.Eval(Container.DataItem, "buyercode")%>' class="PurchaseDetailDiv">
                    <asp:Repeater ID="rptDetail" runat="server" DataSource='<%# GetChildDataByBuyerCode(Eval("buyercode").ToString()) %>'
                    onitemdatabound="rptDetail_ItemDataBound" OnItemCreated = "rptDetail_ItemCreated"
                    >
                        <HeaderTemplate>
                            <table class="datagrid" cellspacing="1" cellpadding="3" rules="all" name="MzhMultiSelectDataGrid" CSSClassForPagerButtonJump="m-grid-pager-button-jump" HighLightColor="Gold" CSSClassForPagerInputPage="m-grid-pager-input-page" SelectedColor="Blue" border="1" id="_ctl0_BodyHolder_DGModel_Items1" style="border-width:1px solid #ccc;">
                                <tr class="m-grid-hd-row">
                                    <th >
                                        供应商名称
                                    </th>
                                    <th width="80px">
                                        发票号
                                    </th>
                                </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr class="m-grid-row" style='<%# itemstly %>'>
                                <td><%# DataBinder.Eval(Container.DataItem, "PrvName")%>
                                </td>
                                <td><%# DataBinder.Eval(Container.DataItem, "InvoiceNo")%>
                                </td>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                                <tr>
                                <td>&nbsp;
                                </td>
                                <td>&nbsp;
                                </td>
                            </tr>
                            </table></FooterTemplate>
                    </asp:Repeater>
                </div>
    </ItemTemplate>
</asp:Repeater>

<mzh:MzhDataGrid ID="dgNoPayed" runat="server" AutoGenerateColumns="False" 
    IdCell="0"  MultiPageShowMode="None"
    OnItemDataBound="dgNoPayed_ItemDataBound" SelectedCSS="m-grid-row-selected" ShowGridOnEmptyData="False"
    ShowPageSize="False" ShowRecordsCount="False" SORTEXPRESSION="">
    <Columns>
        <asp:BoundColumn DataField="PrvCode" HeaderText="供应商编号" ReadOnly="True" Visible="False">
        </asp:BoundColumn>
        <asp:BoundColumn DataField="PrvName" HeaderText="供应商名称" ReadOnly="True">
            <HeaderStyle Width="150px" />
        </asp:BoundColumn>
        <asp:BoundColumn DataField="SubTotal" HeaderText="金额" ReadOnly="True" Visible="False">
        </asp:BoundColumn>
        <asp:BoundColumn DataField="Flag" HeaderText="标记" ReadOnly="True" Visible="False">
        </asp:BoundColumn>
        <asp:BoundColumn DataField="InvoiceNo" HeaderText="发票号" ReadOnly="True">
            <HeaderStyle Width="100px" />
        </asp:BoundColumn>
        <asp:BoundColumn DataField="BuyerName" HeaderText="采购员" ReadOnly="True">
            <HeaderStyle Width="50px" />
        </asp:BoundColumn>
    </Columns>
</mzh:MzhDataGrid>
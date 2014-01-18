<%@ Control Language="c#" AutoEventWireup="True" CodeBehind="WUCNoPayed.ascx.cs"
    Inherits="WebMM.Modules.WUCNoPayed" %>
    <asp:Repeater ID="rptNOPayedDraw" runat="server" 
    >
    <ItemTemplate>
                <div class="ReqReason" onclick="$('#rptNOPayedDraw<%# DataBinder.Eval(Container.DataItem, "buyercode")%>').toggle();">
                    �ɹ�Ա��<%# DataBinder.Eval(Container.DataItem, "BuyerName")%></div>
                <div id='rptNOPayedDraw<%# DataBinder.Eval(Container.DataItem, "buyercode")%>' class="PurchaseDetailDiv">
                    <asp:Repeater ID="rptDetail" runat="server" DataSource='<%# GetChildDataByBuyerCode(Eval("buyercode").ToString()) %>'
                    onitemdatabound="rptDetail_ItemDataBound" OnItemCreated = "rptDetail_ItemCreated"
                    >
                        <HeaderTemplate>
                            <table class="datagrid" cellspacing="1" cellpadding="3" rules="all" name="MzhMultiSelectDataGrid" CSSClassForPagerButtonJump="m-grid-pager-button-jump" HighLightColor="Gold" CSSClassForPagerInputPage="m-grid-pager-input-page" SelectedColor="Blue" border="1" id="_ctl0_BodyHolder_DGModel_Items1" style="border-width:1px solid #ccc;">
                                <tr class="m-grid-hd-row">
                                    <th >
                                        ��Ӧ������
                                    </th>
                                    <th width="80px">
                                        ��Ʊ��
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
        <asp:BoundColumn DataField="PrvCode" HeaderText="��Ӧ�̱��" ReadOnly="True" Visible="False">
        </asp:BoundColumn>
        <asp:BoundColumn DataField="PrvName" HeaderText="��Ӧ������" ReadOnly="True">
            <HeaderStyle Width="150px" />
        </asp:BoundColumn>
        <asp:BoundColumn DataField="SubTotal" HeaderText="���" ReadOnly="True" Visible="False">
        </asp:BoundColumn>
        <asp:BoundColumn DataField="Flag" HeaderText="���" ReadOnly="True" Visible="False">
        </asp:BoundColumn>
        <asp:BoundColumn DataField="InvoiceNo" HeaderText="��Ʊ��" ReadOnly="True">
            <HeaderStyle Width="100px" />
        </asp:BoundColumn>
        <asp:BoundColumn DataField="BuyerName" HeaderText="�ɹ�Ա" ReadOnly="True">
            <HeaderStyle Width="50px" />
        </asp:BoundColumn>
    </Columns>
</mzh:MzhDataGrid>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WUCToolTip.ascx.cs"
    Inherits="WebMM.Modules.WUCToolTip" %>
<asp:Repeater ID="rptToolTipROS" runat="server">
    <HeaderTemplate>
        <table class="datagrid" cellspacing="1" cellpadding="3" rules="all" name="MzhMultiSelectDataGrid" CSSClassForPagerButtonJump="m-grid-pager-button-jump" HighLightColor="Gold" CSSClassForPagerInputPage="m-grid-pager-input-page" SelectedColor="Blue" border="1" id="_ctl0_BodyHolder_DGModel_Items1" style="border-width:1px solid #ccc;">
            <tr class="m-grid-hd-row">
                <td style="white-space:nowrap;width: 60px;">
                    物料编号
                </td>
                <td style="white-space:nowrap;">
                    物料名称
                </td>
                <td style="width: 60px;">
                    规格型号
                </td>
                <td style="white-space:nowrap;">
                    单位名称
                </td>
                <td style="white-space:nowrap;">
                    单价
                </td>
                <td style="white-space:nowrap;">
                    数量
                </td>
                <td style="white-space:nowrap;">
                    金额
                </td>
                <td style="white-space:nowrap;">
                    需求日期
                </td>
            </tr>
    </HeaderTemplate>
    <ItemTemplate>
        <tr class="m-grid-row">
            <td style="white-space:nowrap;width: 60px;">
                <%# Eval("ItemCode")%>
            </td>
            <td>
                <%# Eval("ItemName")%>
            </td>
            <td>
                <%# Eval("ItemSpecial")%>
            </td>
            <td>
                <%# Eval("ItemUnitName")%>
            </td>
            <td align="right">
                <%# Eval("ItemPrice")%>
            </td>
            <td align="right">
                <%# Eval("ItemNum")%>
            </td>
            <td align="right">
                <%# Eval("ItemMoney")%>
            </td>
            <td align="center">
                <%# Eval("ReqDate")%>
            </td>
        </tr>
    </ItemTemplate>
    <FooterTemplate>
        </table>
    </FooterTemplate>
</asp:Repeater>
<asp:Repeater ID="rptToolTipMRP" runat="server">
    <HeaderTemplate>
        <table class="datagrid" cellspacing="1" cellpadding="3" rules="all" name="MzhMultiSelectDataGrid" CSSClassForPagerButtonJump="m-grid-pager-button-jump" HighLightColor="Gold" CSSClassForPagerInputPage="m-grid-pager-input-page" SelectedColor="Blue" border="1" id="_ctl0_BodyHolder_DGModel_Items1" style="border-width:1px solid #ccc;">
            <tr class="m-grid-hd-row">
                <td style="white-space:nowrap;width: 60px;">
                    物料编号
                </td>
                <td style="white-space:nowrap;">
                    物料名称
                </td>
                <td style="width: 60px;">
                    规格型号
                </td>
                <td style="white-space:nowrap;">
                    单位名称
                </td>
                <td style="white-space:nowrap;">
                    单价
                </td>
                <td style="white-space:nowrap;">
                    数量
                </td>
                <td style="white-space:nowrap;">
                    金额
                </td>
                <td style="white-space:nowrap;">
                    需求日期
                </td>
            </tr>
    </HeaderTemplate>
    <ItemTemplate>
        <tr class="m-grid-row">
            <td style="white-space:nowrap;width: 60px;">
                <%# Eval("ItemCode")%>
            </td>
            <td>
                <%# Eval("ItemName")%>
            </td>
            <td>
                <%# Eval("ItemSpecial")%>
            </td>
            <td>
                <%# Eval("ItemUnitName")%>
            </td>
            <td align="right">
                <%# Eval("ItemPrice")%>
            </td>
            <td align="right">
                <%# Eval("ItemNum")%>
            </td>
            <td align="right">
                <%# Eval("ItemMoney")%>
            </td>
            <td align="center">
                <%# Eval("ReqDate")%>
            </td>
        </tr>
    </ItemTemplate>
    <FooterTemplate>
        </table>
    </FooterTemplate>
</asp:Repeater>
<asp:Repeater ID="rptToolTipPO" runat="server">
    <HeaderTemplate>
        <table class="datagrid" cellspacing="1" cellpadding="3" rules="all" name="MzhMultiSelectDataGrid" CSSClassForPagerButtonJump="m-grid-pager-button-jump" HighLightColor="Gold" CSSClassForPagerInputPage="m-grid-pager-input-page" SelectedColor="Blue" border="1" id="_ctl0_BodyHolder_DGModel_Items1" style="border-width:1px solid #ccc;">
            <tr class="m-grid-hd-row">
                <td style="white-space:nowrap;width: 60px;">
                    物料编号
                </td>
                <td style="white-space:nowrap;">
                    物料名称
                </td>
                <td style="width: 60px;">
                    规格型号
                </td>
                <td style="white-space:nowrap;">
                    单位名称
                </td>
                <td style="white-space:nowrap;">
                    单价
                </td>
                <td style="white-space:nowrap;">
                    数量
                </td>
                <td style="white-space:nowrap;">
                    金额
                </td>
            </tr>
    </HeaderTemplate>
    <ItemTemplate>
        <tr class="m-grid-row">
            <td style="white-space:nowrap;width: 60px;">
                <%# Eval("ItemCode")%>
            </td>
            <td>
                <%# Eval("ItemName")%>
            </td>
            <td>
                <%# Eval("ItemSpecial")%>
            </td>
            <td>
                <%# Eval("ItemUnitName")%>
            </td>
            <td align="right">
                <%# Eval("ItemPrice")%>
            </td>
            <td align="right">
                <%# Eval("ItemNum")%>
            </td>
            <td align="right">
                <%# Eval("ItemMoney")%>
            </td>
        </tr>
    </ItemTemplate>
    <FooterTemplate>
        </table>
    </FooterTemplate>
</asp:Repeater>
<asp:Repeater ID="rptToolTipDRW" runat="server">
    <HeaderTemplate>
        <table class="datagrid" cellspacing="1" cellpadding="3" rules="all" name="MzhMultiSelectDataGrid" CSSClassForPagerButtonJump="m-grid-pager-button-jump" HighLightColor="Gold" CSSClassForPagerInputPage="m-grid-pager-input-page" SelectedColor="Blue" border="1" id="_ctl0_BodyHolder_DGModel_Items1" style="border-width:1px solid #ccc;">
            <tr class="m-grid-hd-row">
                <td style="white-space:nowrap;width: 60px;">
                    物料编号
                </td>
                <td style="white-space:nowrap;">
                    物料名称
                </td>
                <td style="width: 60px;">
                    规格型号
                </td>
                <td style="white-space:nowrap;">
                    单位名称
                </td>
                <td style="white-space:nowrap;">
                    单价
                </td>
                <td style="white-space:nowrap;">
                    数量
                </td>
                <td style="white-space:nowrap;">
                    金额
                </td>
  
            </tr>
    </HeaderTemplate>
    <ItemTemplate>
        <tr class="m-grid-row">
            <td style="white-space:nowrap;width: 60px;">
                <%# Eval("ItemCode")%>
            </td>
            <td>
                <%# Eval("ItemName")%>
            </td>
            <td>
                <%# Eval("ItemSpecial")%>
            </td>
            <td>
                <%# Eval("ItemUnitName")%>
            </td>
            <td align="right">
                <%# Eval("ItemPrice")%>
            </td>
            <td align="right">
                <%# Eval("ItemNum")%>
            </td>
            <td align="right">
                <%# Eval("ItemMoney")%>
            </td>

        </tr>
    </ItemTemplate>
    <FooterTemplate>
        </table>
    </FooterTemplate>
</asp:Repeater>
<asp:Repeater ID="rptToolTipPP" runat="server">
    <HeaderTemplate>
        <table class="datagrid" cellspacing="1" cellpadding="3" rules="all" name="MzhMultiSelectDataGrid" CSSClassForPagerButtonJump="m-grid-pager-button-jump" HighLightColor="Gold" CSSClassForPagerInputPage="m-grid-pager-input-page" SelectedColor="Blue" border="1" id="_ctl0_BodyHolder_DGModel_Items1" style="border-width:1px solid #ccc;">
            <tr class="m-grid-hd-row">
                <td style="white-space:nowrap;width: 60px;">
                    物料编号
                </td>
                <td style="white-space:nowrap;">
                    物料名称
                </td>
                <td style="width: 60px;">
                    规格型号
                </td>
                <td style="white-space:nowrap;">
                    单位名称
                </td>
                <td style="white-space:nowrap;">
                    单价
                </td>
                <td style="white-space:nowrap;">
                    数量
                </td>
                <td style="white-space:nowrap;">
                    金额
                </td>
                <td style="white-space:nowrap;">
                    需求日期
                </td>
            </tr>
    </HeaderTemplate>
    <ItemTemplate>
        <tr class="m-grid-row">
            <td style="white-space:nowrap;width: 60px;">
                <%# Eval("ItemCode")%>
            </td>
            <td>
                <%# Eval("ItemName")%>
            </td>
            <td>
                <%# Eval("ItemSpecial")%>
            </td>
            <td>
                <%# Eval("ItemUnitName")%>
            </td>
            <td align="right">
                <%# Eval("ItemPrice")%>
            </td>
            <td align="right">
                <%# Eval("ItemNum")%>
            </td>
            <td align="right">
                <%# Eval("ItemMoney")%>
            </td>
            <td align="center">
                <%# Eval("ReqDate")%>
            </td>
        </tr>
    </ItemTemplate>
    <FooterTemplate>
        </table>
    </FooterTemplate>
</asp:Repeater>
<asp:Repeater ID="rptToolTipBOR" runat="server">
    <HeaderTemplate>
        <table class="datagrid" cellspacing="1" cellpadding="3" rules="all" name="MzhMultiSelectDataGrid" CSSClassForPagerButtonJump="m-grid-pager-button-jump" HighLightColor="Gold" CSSClassForPagerInputPage="m-grid-pager-input-page" SelectedColor="Blue" border="1" id="_ctl0_BodyHolder_DGModel_Items1" style="border-width:1px solid #ccc;">
            <tr class="m-grid-hd-row">
                <td style="white-space:nowrap;width: 60px;">
                    物料编号
                </td>
                <td style="white-space:nowrap;">
                    物料名称
                </td>
                <td style="width: 60px;">
                    规格型号
                </td>
                <td style="white-space:nowrap;">
                    单位名称
                </td>
                <td style="white-space:nowrap;">
                    单价
                </td>
                <td style="white-space:nowrap;">
                    数量
                </td>
                <td style="white-space:nowrap;">
                    金额
                </td>

            </tr>
    </HeaderTemplate>
    <ItemTemplate>
        <tr class="m-grid-row">
            <td style="white-space:nowrap;width: 60px;">
                <%# Eval("ItemCode")%>
            </td>
            <td>
                <%# Eval("ItemName")%>
            </td>
            <td>
                <%# Eval("ItemSpecial")%>
            </td>
            <td>
                <%# Eval("ItemUnitName")%>
            </td>
            <td align="right">
                <%# Eval("ItemPrice")%>
            </td>
            <td align="right">
                <%# Eval("ItemNum")%>
            </td>
            <td align="right">
                <%# Eval("ItemMoney")%>
            </td>

        </tr>
    </ItemTemplate>
    <FooterTemplate>
        </table>
    </FooterTemplate>
</asp:Repeater>
<asp:Repeater ID="rptToolTipRTV" runat="server">
    <HeaderTemplate>
        <table class="datagrid" cellspacing="1" cellpadding="3" rules="all" name="MzhMultiSelectDataGrid" CSSClassForPagerButtonJump="m-grid-pager-button-jump" HighLightColor="Gold" CSSClassForPagerInputPage="m-grid-pager-input-page" SelectedColor="Blue" border="1" id="_ctl0_BodyHolder_DGModel_Items1" style="border-width:1px solid #ccc;">
            <tr class="m-grid-hd-row">
                <td style="white-space:nowrap;width: 60px;">
                    物料编号
                </td>
                <td style="white-space:nowrap;">
                    物料名称
                </td>
                <td style="width: 60px;">
                    规格型号
                </td>
                <td style="white-space:nowrap;">
                    单位名称
                </td>
                <td style="white-space:nowrap;">
                    单价
                </td>
                <td style="white-space:nowrap;">
                    数量
                </td>
                <td style="white-space:nowrap;">
                    金额
                </td>

            </tr>
    </HeaderTemplate>
    <ItemTemplate>
        <tr class="m-grid-row">
            <td style="white-space:nowrap;width: 60px;">
                <%# Eval("ItemCode")%>
            </td>
            <td>
                <%# Eval("ItemName")%>
            </td>
            <td>
                <%# Eval("ItemSpecial")%>
            </td>
            <td>
                <%# Eval("ItemUnitName")%>
            </td>
            <td align="right">
                <%# Eval("ItemPrice")%>
            </td>
            <td align="right">
                <%# Eval("ItemNum")%>
            </td>
            <td align="right">
                <%# Eval("ItemMoney")%>
            </td>

        </tr>
    </ItemTemplate>
    <FooterTemplate>
        </table>
    </FooterTemplate>
</asp:Repeater>
<asp:Repeater ID="rptToolTipRTS" runat="server">
    <HeaderTemplate>
        <table class="datagrid" cellspacing="1" cellpadding="3" rules="all" name="MzhMultiSelectDataGrid" CSSClassForPagerButtonJump="m-grid-pager-button-jump" HighLightColor="Gold" CSSClassForPagerInputPage="m-grid-pager-input-page" SelectedColor="Blue" border="1" id="_ctl0_BodyHolder_DGModel_Items1" style="border-width:1px solid #ccc;">
            <tr class="m-grid-hd-row">
                <td style="white-space:nowrap;width: 60px;">
                    物料编号
                </td>
                <td style="white-space:nowrap;">
                    物料名称
                </td>
                <td style="width: 60px;">
                    规格型号
                </td>
                <td style="white-space:nowrap;">
                    单位名称
                </td>
                <td style="white-space:nowrap;">
                    单价
                </td>
                <td style="white-space:nowrap;">
                    数量
                </td>
                <td style="white-space:nowrap;">
                    金额
                </td>

            </tr>
    </HeaderTemplate>
    <ItemTemplate>
        <tr class="m-grid-row">
            <td style="white-space:nowrap;width: 60px;">
                <%# Eval("ItemCode")%>
            </td>
            <td>
                <%# Eval("ItemName")%>
            </td>
            <td>
                <%# Eval("ItemSpecial")%>
            </td>
            <td>
                <%# Eval("ItemUnitName")%>
            </td>
            <td align="right">
                <%# Eval("ItemPrice")%>
            </td>
            <td align="right">
                <%# Eval("PlanNum")%>
            </td>
            <td align="right">
                <%# Eval("ItemMoney")%>
            </td>

        </tr>
    </ItemTemplate>
    <FooterTemplate>
        </table>
    </FooterTemplate>
</asp:Repeater>
<asp:Repeater ID="rptToolTipCBR" runat="server">
    <HeaderTemplate>
        <table class="datagrid" cellspacing="1" cellpadding="3" rules="all" name="MzhMultiSelectDataGrid" CSSClassForPagerButtonJump="m-grid-pager-button-jump" HighLightColor="Gold" CSSClassForPagerInputPage="m-grid-pager-input-page" SelectedColor="Blue" border="1" id="_ctl0_BodyHolder_DGModel_Items1" style="border-width:1px solid #ccc;">
            <tr class="m-grid-hd-row">
                <td style="white-space:nowrap;width: 60px;">
                    物料编号
                </td>
                <td style="white-space:nowrap;">
                    物料名称
                </td>
                <td style="width: 60px;">
                    规格型号
                </td>
                <td style="white-space:nowrap;">
                    单位名称
                </td>
                <td style="white-space:nowrap;">
                    单价
                </td>
                <td style="white-space:nowrap;">
                    数量
                </td>
                <td style="white-space:nowrap;">
                    金额
                </td>
                <td style="white-space:nowrap;">
                    需求日期
                </td>
            </tr>
    </HeaderTemplate>
    <ItemTemplate>
        <tr class="m-grid-row">
            <td style="white-space:nowrap;width: 60px;">
                <%# Eval("ItemCode")%>
            </td>
            <td>
                <%# Eval("ItemName")%>
            </td>
            <td>
                <%# Eval("ItemSpecial")%>
            </td>
            <td>
                <%# Eval("ItemUnitName")%>
            </td>
            <td align="right">
                <%# Eval("ItemPrice")%>
            </td>
            <td align="right">
                <%# Eval("ItemNum")%>
            </td>
            <td align="right">
                <%# Eval("ItemMoney")%>
            </td>
            <td align="center">
                <%# Eval("ReqDate")%>
            </td>
        </tr>
    </ItemTemplate>
    <FooterTemplate>
        </table>
    </FooterTemplate>
</asp:Repeater>
<asp:Repeater ID="rptToolTipTRF" runat="server">
    <HeaderTemplate>
        <table class="datagrid" cellspacing="1" cellpadding="3" rules="all" name="MzhMultiSelectDataGrid" CSSClassForPagerButtonJump="m-grid-pager-button-jump" HighLightColor="Gold" CSSClassForPagerInputPage="m-grid-pager-input-page" SelectedColor="Blue" border="1" id="_ctl0_BodyHolder_DGModel_Items1" style="border-width:1px solid #ccc;">
            <tr class="m-grid-hd-row">
                <td style="white-space:nowrap;width: 60px;">
                    物料编号
                </td>
                <td style="white-space:nowrap;">
                    物料名称
                </td>
                <td style="width: 60px;">
                    规格型号
                </td>
                <td style="white-space:nowrap;">
                    单位名称
                </td>
                <td style="white-space:nowrap;">
                    单价
                </td>
                <td style="white-space:nowrap;">
                    数量
                </td>
                <td style="white-space:nowrap;">
                    金额
                </td>
                <td style="white-space:nowrap;">
                    需求日期
                </td>
            </tr>
    </HeaderTemplate>
    <ItemTemplate>
        <tr class="m-grid-row">
            <td style="white-space:nowrap;width: 60px;">
                <%# Eval("ItemCode")%>
            </td>
            <td>
                <%# Eval("ItemName")%>
            </td>
            <td>
                <%# Eval("ItemSpecial")%>
            </td>
            <td>
                <%# Eval("ItemUnitName")%>
            </td>
            <td align="right">
                <%# Eval("ItemPrice")%>
            </td>
            <td align="right">
                <%# Eval("ItemNum")%>
            </td>
            <td align="right">
                <%# Eval("ItemMoney")%>
            </td>
            <td align="center">
                <%# Eval("ReqDate")%>
            </td>
        </tr>
    </ItemTemplate>
    <FooterTemplate>
        </table>
    </FooterTemplate>
</asp:Repeater>
<asp:Repeater ID="rptToolTipSCR" runat="server">
    <HeaderTemplate>
        <table class="datagrid" cellspacing="1" cellpadding="3" rules="all" name="MzhMultiSelectDataGrid" CSSClassForPagerButtonJump="m-grid-pager-button-jump" HighLightColor="Gold" CSSClassForPagerInputPage="m-grid-pager-input-page" SelectedColor="Blue" border="1" id="_ctl0_BodyHolder_DGModel_Items1" style="border-width:1px solid #ccc;">
            <tr class="m-grid-hd-row">
                <td style="white-space:nowrap;width: 60px;">
                    物料编号
                </td>
                <td style="white-space:nowrap;">
                    物料名称
                </td>
                <td style="width: 60px;">
                    规格型号
                </td>
                <td style="white-space:nowrap;">
                    单位名称
                </td>
                <td style="white-space:nowrap;">
                    单价
                </td>
                <td style="white-space:nowrap;">
                    数量
                </td>
                <td style="white-space:nowrap;">
                    金额
                </td>
                <td style="white-space:nowrap;">
                    需求日期
                </td>
            </tr>
    </HeaderTemplate>
    <ItemTemplate>
        <tr class="m-grid-row">
            <td style="white-space:nowrap;width: 60px;">
                <%# Eval("ItemCode")%>
            </td>
            <td>
                <%# Eval("ItemName")%>
            </td>
            <td>
                <%# Eval("ItemSpecial")%>
            </td>
            <td>
                <%# Eval("ItemUnitName")%>
            </td>
            <td align="right">
                <%# Eval("ItemPrice")%>
            </td>
            <td align="right">
                <%# Eval("ItemNum")%>
            </td>
            <td align="right">
                <%# Eval("ItemMoney")%>
            </td>
            <td align="center">
                <%# Eval("ReqDate")%>
            </td>
        </tr>
    </ItemTemplate>
    <FooterTemplate>
        </table>
    </FooterTemplate>
</asp:Repeater>
<asp:Repeater ID="rptToolTipADJ" runat="server">
    <HeaderTemplate>
        <table class="datagrid" cellspacing="1" cellpadding="3" rules="all" name="MzhMultiSelectDataGrid" CSSClassForPagerButtonJump="m-grid-pager-button-jump" HighLightColor="Gold" CSSClassForPagerInputPage="m-grid-pager-input-page" SelectedColor="Blue" border="1" id="_ctl0_BodyHolder_DGModel_Items1" style="border-width:1px solid #ccc;">
            <tr class="m-grid-hd-row">
                <td style="white-space:nowrap;width: 60px;">
                    物料编号
                </td>
                <td style="white-space:nowrap;">
                    物料名称
                </td>
                <td style="width: 60px;">
                    规格型号
                </td>
                <td style="white-space:nowrap;">
                    单位名称
                </td>
                <td style="white-space:nowrap;">
                    单价
                </td>
                <td style="white-space:nowrap;">
                    数量
                </td>
                <td style="white-space:nowrap;">
                    金额
                </td>
                <td style="white-space:nowrap;">
                    需求日期
                </td>
            </tr>
    </HeaderTemplate>
    <ItemTemplate>
        <tr class="m-grid-row">
            <td style="white-space:nowrap;width: 60px;">
                <%# Eval("ItemCode")%>
            </td>
            <td>
                <%# Eval("ItemName")%>
            </td>
            <td>
                <%# Eval("ItemSpecial")%>
            </td>
            <td>
                <%# Eval("ItemUnitName")%>
            </td>
            <td align="right">
                <%# Eval("ItemPrice")%>
            </td>
            <td align="right">
                <%# Eval("ItemNum")%>
            </td>
            <td align="right">
                <%# Eval("ItemMoney")%>
            </td>
            <td align="center">
                <%# Eval("ReqDate")%>
            </td>
        </tr>
    </ItemTemplate>
    <FooterTemplate>
        </table>
    </FooterTemplate>
</asp:Repeater>
<asp:Repeater ID="rptToolTipBRB" runat="server">
    <HeaderTemplate>
        <table class="datagrid" cellspacing="1" cellpadding="3" rules="all" name="MzhMultiSelectDataGrid" CSSClassForPagerButtonJump="m-grid-pager-button-jump" HighLightColor="Gold" CSSClassForPagerInputPage="m-grid-pager-input-page" SelectedColor="Blue" border="1" id="_ctl0_BodyHolder_DGModel_Items1" style="border-width:1px solid #ccc;">
            <tr class="m-grid-hd-row">
                <td style="white-space:nowrap;width: 60px;">
                    物料编号
                </td>
                <td style="white-space:nowrap;">
                    物料名称
                </td>
                <td style="width: 60px;">
                    规格型号
                </td>
                <td style="white-space:nowrap;">
                    单位名称
                </td>
                <td style="white-space:nowrap;">
                    单价
                </td>
                <td style="white-space:nowrap;">
                    数量
                </td>
                <td style="white-space:nowrap;">
                    金额
                </td>
                <td style="white-space:nowrap;">
                    需求日期
                </td>
            </tr>
    </HeaderTemplate>
    <ItemTemplate>
        <tr class="m-grid-row">
            <td style="white-space:nowrap;width: 60px;">
                <%# Eval("ItemCode")%>
            </td>
            <td>
                <%# Eval("ItemName")%>
            </td>
            <td>
                <%# Eval("ItemSpecial")%>
            </td>
            <td>
                <%# Eval("ItemUnitName")%>
            </td>
            <td align="right">
                <%# Eval("ItemPrice")%>
            </td>
            <td align="right">
                <%# Eval("ItemNum")%>
            </td>
            <td align="right">
                <%# Eval("ItemMoney")%>
            </td>
            <td align="center">
                <%# Eval("ReqDate")%>
            </td>
        </tr>
    </ItemTemplate>
    <FooterTemplate>
        </table>
    </FooterTemplate>
</asp:Repeater>
<asp:Repeater ID="rptToolTipPAY" runat="server">
    <HeaderTemplate>
        <table class="datagrid" cellspacing="1" cellpadding="3" rules="all" name="MzhMultiSelectDataGrid" CSSClassForPagerButtonJump="m-grid-pager-button-jump" HighLightColor="Gold" CSSClassForPagerInputPage="m-grid-pager-input-page" SelectedColor="Blue" border="1" id="_ctl0_BodyHolder_DGModel_Items1" style="border-width:1px solid #ccc;">
            <tr class="m-grid-hd-row">
                <td style="white-space:nowrap;width: 60px;">
                    物料编号
                </td>
                <td style="white-space:nowrap;">
                    物料名称
                </td>
                <td style="width: 60px;">
                    规格型号
                </td>
                <td style="white-space:nowrap;">
                    单位名称
                </td>
                <td style="white-space:nowrap;">
                    单价
                </td>
                <td style="white-space:nowrap;">
                    数量
                </td>
                <td style="white-space:nowrap;">
                    金额
                </td>

            </tr>
    </HeaderTemplate>
    <ItemTemplate>
        <tr class="m-grid-row">
            <td style="white-space:nowrap;width: 60px;">
                <%# Eval("ItemCode")%>
            </td>
            <td>
                <%# Eval("ItemName")%>
            </td>
            <td>
                <%# Eval("ItemSpecial")%>
            </td>
            <td>
                <%# Eval("ItemUnitName")%>
            </td>
            <td align="right">
                <%# Eval("ItemPrice")%>
            </td>
            <td align="right">
                <%# Eval("ItemNum")%>
            </td>
            <td align="right">
                <%# Eval("ItemMoney")%>
            </td>

        </tr>
    </ItemTemplate>
    <FooterTemplate>
        </table>
    </FooterTemplate>
</asp:Repeater>
<asp:Repeater ID="rptToolTipWTOW" runat="server">
    <HeaderTemplate>
        <table class="datagrid" cellspacing="1" cellpadding="3" rules="all" name="MzhMultiSelectDataGrid" CSSClassForPagerButtonJump="m-grid-pager-button-jump" HighLightColor="Gold" CSSClassForPagerInputPage="m-grid-pager-input-page" SelectedColor="Blue" border="1" id="_ctl0_BodyHolder_DGModel_Items1" style="border-width:1px solid #ccc;">
            <tr class="m-grid-hd-row">
                <td style="white-space:nowrap;width: 60px;">
                    物料编号
                </td>
                <td style="white-space:nowrap;">
                    物料名称
                </td>
                <td style="width: 60px;">
                    规格型号
                </td>
                <td style="white-space:nowrap;">
                    单位名称
                </td>
                <td style="white-space:nowrap;">
                    单价
                </td>
                <td style="white-space:nowrap;">
                    数量
                </td>
                <td style="white-space:nowrap;">
                    金额
                </td>

            </tr>
    </HeaderTemplate>
    <ItemTemplate>
        <tr class="m-grid-row">
            <td style="white-space:nowrap;width: 60px;">
                <%# Eval("ItemCode")%>
            </td>
            <td>
                <%# Eval("ItemName")%>
            </td>
            <td>
                <%# Eval("ItemSpecial")%>
            </td>
            <td>
                <%# Eval("ItemUnitName")%>
            </td>
            <td align="right">
                <%# Eval("ItemPrice")%>
            </td>
            <td align="right">
                <%# Eval("PlanNum")%>
            </td>
            <td align="right">
                <%# Eval("ItemMoney")%>
            </td>

        </tr>
    </ItemTemplate>
    <FooterTemplate>
        </table>
    </FooterTemplate>
</asp:Repeater>
<asp:Repeater ID="rptToolTipWINW" runat="server">
    <HeaderTemplate>
        <table class="datagrid" cellspacing="1" cellpadding="3" rules="all" name="MzhMultiSelectDataGrid" CSSClassForPagerButtonJump="m-grid-pager-button-jump" HighLightColor="Gold" CSSClassForPagerInputPage="m-grid-pager-input-page" SelectedColor="Blue" border="1" id="_ctl0_BodyHolder_DGModel_Items1" style="border-width:1px solid #ccc;">
            <tr class="m-grid-hd-row">
                <td style="white-space:nowrap;width: 60px;">
                    物料编号
                </td>
                <td style="white-space:nowrap;">
                    物料名称
                </td>
                <td style="width: 60px;">
                    规格型号
                </td>
                <td style="white-space:nowrap;">
                    单位名称
                </td>
                <td style="white-space:nowrap;">
                    单价
                </td>
                <td style="white-space:nowrap;">
                    数量
                </td>
                <td style="white-space:nowrap;">
                    金额
                </td>

            </tr>
    </HeaderTemplate>
    <ItemTemplate>
        <tr class="m-grid-row">
            <td style="white-space:nowrap;width: 60px;">
                <%# Eval("ItemCode")%>
            </td>
            <td>
                <%# Eval("ItemName")%>
            </td>
            <td>
                <%# Eval("ItemSpecial")%>
            </td>
            <td>
                <%# Eval("ItemUnitName")%>
            </td>
            <td align="right">
                <%# Eval("ItemPrice")%>
            </td>
            <td align="right">
                <%# Eval("PlanNum")%>
            </td>
            <td align="right">
                <%# Eval("ItemMoney")%>
            </td>

        </tr>
    </ItemTemplate>
    <FooterTemplate>
        </table>
    </FooterTemplate>
</asp:Repeater>
<asp:Repeater ID="rptToolTipCANCEL" runat="server">
    <HeaderTemplate>
        <table class="datagrid" cellspacing="1" cellpadding="3" rules="all" name="MzhMultiSelectDataGrid" CSSClassForPagerButtonJump="m-grid-pager-button-jump" HighLightColor="Gold" CSSClassForPagerInputPage="m-grid-pager-input-page" SelectedColor="Blue" border="1" id="_ctl0_BodyHolder_DGModel_Items1" style="border-width:1px solid #ccc;">
            <tr class="m-grid-hd-row">
                <td style="white-space:nowrap;width: 60px;">
                    物料编号
                </td>
                <td style="white-space:nowrap;">
                    物料名称
                </td>
                <td style="width: 60px;">
                    规格型号
                </td>
                <td style="white-space:nowrap;">
                    单位名称
                </td>
                <td style="white-space:nowrap;">
                    单价
                </td>
                <td style="white-space:nowrap;">
                    撤销数量
                </td>
                <td style="white-space:nowrap;">
                    金额
                </td>

            </tr>
    </HeaderTemplate>
    <ItemTemplate>
        <tr class="m-grid-row">
            <td style="white-space:nowrap;width: 60px;">
                <%# Eval("ItemCode")%>
            </td>
            <td>
                <%# Eval("ItemName")%>
            </td>
            <td>
                <%# Eval("ItemSpecial")%>
            </td>
            <td>
                <%# Eval("ItemUnitName")%>
            </td>
            <td align="right">
                <%# Eval("ItemPrice")%>
            </td>
            <td align="right">
                <%# Eval("ItemNum")%>
            </td>
            <td align="right">
                <%# Eval("ItemMoney")%>
            </td>

        </tr>
    </ItemTemplate>
    <FooterTemplate>
        </table>
    </FooterTemplate>
</asp:Repeater>
<asp:Repeater ID="rptToolTipInventoryProfit" runat="server">
    <HeaderTemplate>
        <table class="datagrid" cellspacing="1" cellpadding="3" rules="all" name="MzhMultiSelectDataGrid" CSSClassForPagerButtonJump="m-grid-pager-button-jump" HighLightColor="Gold" CSSClassForPagerInputPage="m-grid-pager-input-page" SelectedColor="Blue" border="1" id="_ctl0_BodyHolder_DGModel_Items1" style="border-width:1px solid #ccc;">
            <tr class="m-grid-hd-row">
                <td style="white-space:nowrap;width: 60px;">
                    物料编号
                </td>
                <td style="white-space:nowrap;">
                    物料名称
                </td>
                <td style="width: 60px;">
                    规格型号
                </td>
                <td style="white-space:nowrap;">
                    单位名称
                </td>
                <td style="white-space:nowrap;">
                    单价
                </td>
                <td style="white-space:nowrap;">
                    数量
                </td>
                <td style="white-space:nowrap;">
                    金额
                </td>
  
            </tr>
    </HeaderTemplate>
    <ItemTemplate>
        <tr class="m-grid-row">
            <td style="white-space:nowrap;width: 60px;">
                <%# Eval("ItemCode")%>
            </td>
            <td>
                <%# Eval("ItemName")%>
            </td>
            <td>
                <%# Eval("ItemSpec")%>
            </td>
            <td>
                <%# Eval("ItemUnitName")%>
            </td>
            <td align="right">
                <%# Eval("ItemPrice")%>
            </td>
            <td align="right">
                <%# Eval("ItemNum")%>
            </td>
            <td align="right">
                <%# Eval("ItemMoney")%>
            </td>

        </tr>
    </ItemTemplate>
    <FooterTemplate>
        </table>
    </FooterTemplate>
</asp:Repeater>
<asp:Repeater ID="rptToolTipInventoryShortage" runat="server">
    <HeaderTemplate>
        <table class="datagrid" cellspacing="1" cellpadding="3" rules="all" name="MzhMultiSelectDataGrid" CSSClassForPagerButtonJump="m-grid-pager-button-jump" HighLightColor="Gold" CSSClassForPagerInputPage="m-grid-pager-input-page" SelectedColor="Blue" border="1" id="_ctl0_BodyHolder_DGModel_Items1" style="border-width:1px solid #ccc;">
            <tr class="m-grid-hd-row">
                <td style="white-space:nowrap;width: 60px;">
                    物料编号
                </td>
                <td style="white-space:nowrap;">
                    物料名称
                </td>
                <td style="width: 60px;">
                    规格型号
                </td>
                <td style="white-space:nowrap;">
                    单位名称
                </td>
                <td style="white-space:nowrap;">
                    单价
                </td>
                <td style="white-space:nowrap;">
                    数量
                </td>
                <td style="white-space:nowrap;">
                    金额
                </td>
  
            </tr>
    </HeaderTemplate>
    <ItemTemplate>
        <tr class="m-grid-row">
            <td style="white-space:nowrap;width: 60px;">
                <%# Eval("ItemCode")%>
            </td>
            <td>
                <%# Eval("ItemName")%>
            </td>
            <td>
                <%# Eval("ItemSpec")%>
            </td>
            <td>
                <%# Eval("ItemUnitName")%>
            </td>
            <td align="right">
                <%# Eval("ItemPrice")%>
            </td>
            <td align="right">
                <%# Eval("ItemNum")%>
            </td>
            <td align="right">
                <%# Eval("ItemMoney")%>
            </td>
        </tr>
    </ItemTemplate>
    <FooterTemplate>
        </table>
    </FooterTemplate>
</asp:Repeater>
<%@ Control Language="c#" AutoEventWireup="True" CodeBehind="WUC_DocStat.ascx.cs"
    Inherits="MZHMM.WebMM.Analysis.WUC_DocStat" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<font face="宋体">
    <table id="Table1" border="1" width="100%">
        <tr>
            <td style="border-right: #93bee2 1px solid; border-top: #93bee2 1px solid; border-left: #93bee2 1px solid;
                border-bottom: #93bee2 1px solid" valign="middle" align="center" bgcolor="#a0c6e5">
                <asp:Label ID="lblTitle" Width="100%" runat="server" Font-Names="楷体_GB2312" Font-Bold="True"
                    Font-Size="Medium">Label</asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <table width="100%" >
                    <tr>
                        <td style="width:15%">
                            开始日期：
                        </td>
                        <td style="width:30%">
                            <mzh:ToolbarCalendar ID="wdcStartDate" ReadOnly="true" runat="server" />
                        </td>
                        <td style="width:15%">
                            结束日期：
                        </td>
                        <td style="width:30%">
                            <mzh:ToolbarCalendar ID="wdcEndDate" ReadOnly="true" runat="server" />
                        </td>
                        <td align="left" style="width:10%">
                            <asp:Button ID="btnQuery" runat="server" Text="确定" onclick="btnQuery_Click"></asp:Button>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <igtbl:UltraWebGrid ID="UltraWebGrid1" runat="server" ImageDirectory="/ig_common/Images/" ondatabinding="UltraWebGrid1_DataBinding">
                    <DisplayLayout AllowDeleteDefault="Yes" AllowSortingDefault="OnClient" RowHeightDefault="20px"
                        Version="3.00" SelectTypeRowDefault="Extended" ViewType="OutlookGroupBy" AllowColumnMovingDefault="OnServer"
                        HeaderClickActionDefault="SortMulti" BorderCollapseDefault="Separate" AllowColSizingDefault="Free"
                        RowSelectorsDefault="No" Name="xctl0xUltraWebGrid1" AllowUpdateDefault="Yes">
                        <AddNewBox Hidden="False">
                            <Style BorderWidth="1px" BorderColor="InactiveCaption" BorderStyle="Solid" BackColor="Window">
                                <BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails></Style>
                        </AddNewBox>
                        <Pager>
                            <Style BorderWidth="1px" BorderStyle="Solid" BackColor="LightGray">
                                <BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails></Style>
                        </Pager>
                        <HeaderStyleDefault BorderStyle="Solid" HorizontalAlign="Left" BackColor="LightGray">
                            <BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White">
                            </BorderDetails>
                        </HeaderStyleDefault>
                        <GroupByRowStyleDefault BorderColor="Window" BackColor="Control">
                        </GroupByRowStyleDefault>
                        <FrameStyle BorderWidth="1px" Font-Size="8.25pt" Font-Names="Microsoft Sans Serif"
                            BorderColor="InactiveCaption" BorderStyle="Solid" BackColor="Window">
                        </FrameStyle>
                        <FooterStyleDefault BorderWidth="1px" BorderStyle="Solid" BackColor="LightGray">
                            <BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White">
                            </BorderDetails>
                        </FooterStyleDefault>
                        <GroupByBox>
                            <Style BorderColor="Window" BackColor="ActiveBorder">
                                </Style>
                        </GroupByBox>
                        <EditCellStyleDefault BorderWidth="0px" BorderStyle="None">
                        </EditCellStyleDefault>
                        <RowStyleDefault BorderWidth="1px" BorderColor="Silver" BorderStyle="Solid" BackColor="Window">
                            <Padding Left="3px"></Padding>
                            <BorderDetails WidthLeft="0px" WidthTop="0px"></BorderDetails>
                        </RowStyleDefault>
                    </DisplayLayout>
                    <Bands>
                        <igtbl:UltraGridBand>
                        </igtbl:UltraGridBand>
                    </Bands>
                </igtbl:UltraWebGrid>
            </td>
        </tr>
    </table>
</font>
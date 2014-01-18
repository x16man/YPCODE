<%@ Page Language="c#" CodeBehind="USECompare.aspx.cs" AutoEventWireup="True" Inherits="WebMM.Analysis.USECompare" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>USECompare</title>
    <link href="../CSS/StyleSheet.css" type="text/css" rel="stylesheet">
</head>
<body  bottommargin="0" leftmargin="0" topmargin="0" rightmargin="0">
    <form id="Form1" method="post" runat="server">
    <table id="Table1" width="100%" class="noDoubleBorderTable" cellspacing="1" cellpadding="1"
        border="1">
        <tr>
            <td colspan="2" class="noDoubleBorderTable_TD">
                <igmisc:WebPanel id="WebPanel1" runat="server" Width="100%" BackColor="#E0DED2">
                    <header text="用途分类同期比较" textalignment="Left">
								<ExpandedAppearance>
									<Style Height="20px" Font-Bold="True" ForeColor="White" BackgroundImage="igpnl_office2k3_drk.png">
									    <Padding Left="5px"></Padding></Style>
								</ExpandedAppearance>
							</header>
                    <template>
								<br>用途分类的同期比较
								<br>
								<br>您可以点击柱状图上面的柱子进入查看每月的同期比较。
								<br>也可以点击坐标轴上面的文字，进入查看子类别的发生情况。
								<br>同时你也可以点击右方的列表中项，查看具体某一用途分类，项目或物料的发生情况。
							</template>
                </igmisc:WebPanel>
            </td>
        </tr>
        <tr>
            <td class="noDoubleBorderTable_TD">
                <font face="宋体">
                    <dcwc:Chart ID="Chart1" runat="server" Width="608px" BackColor="#DAE5F4" BackGradientType="TopBottom"
                        Palette="SemiTransparent" BorderLineColor="26, 59, 105" BorderLineStyle="Solid">
                        <Legends>
                            <dcwc:Legend LegendStyle="Row" BorderColor="Transparent" Docking="Bottom" Name="Default"
                                BackColor="Transparent">
                            </dcwc:Legend>
                        </Legends>
                        <Series>
                            <dcwc:Series XValueType="Double" Name="Series1" BorderColor="120, 50, 50, 50" YValueType="Double">
                            </dcwc:Series>
                            <dcwc:Series XValueType="Double" Name="Series2" BorderColor="120, 50, 50, 50" YValueType="Double">
                            </dcwc:Series>
                        </Series>
                        <ChartAreas>
                            <dcwc:ChartArea Name="Default" BorderColor="DimGray" BackColor="Transparent">
                                <AxisY2 LineColor="DimGray">
                                </AxisY2>
                                <AxisX2 LineColor="DimGray">
                                </AxisX2>
                                <Area3DStyle Enable3D="True"></Area3DStyle>
                                <AxisY LineColor="DimGray">
                                    <MajorGrid LineStyle="Dot" LineColor="DimGray"></MajorGrid>
                                    <MajorTickMark LineColor="DimGray" Enabled="False"></MajorTickMark>
                                </AxisY>
                                <AxisX TitleAlignment="Far" LineColor="DimGray" Interlaced="True">
                                    <MajorGrid LineStyle="Dot" LineColor="DimGray"></MajorGrid>
                                    <MajorTickMark LineColor="DimGray" Enabled="False"></MajorTickMark>
                                </AxisX>
                            </dcwc:ChartArea>
                        </ChartAreas>
                        <BorderSkin FrameBackColor="LightSkyBlue" FrameBackGradientEndColor="DodgerBlue">
                        </BorderSkin>
                    </dcwc:Chart>
                </font>
            </td>
            <td rowspan="3" width="200" class="noDoubleBorderTable_TD" valign="top">
                <table width="100%">
                    <tr>
                        <td>
                            <font face="宋体">开始年份：
                                <asp:DropDownList ID="ddlStartYear" runat="server">
                                    <asp:ListItem Value="2005">2005</asp:ListItem>
                                    <asp:ListItem Value="2006">2006</asp:ListItem>
                                    <asp:ListItem Value="2007">2007</asp:ListItem>
                                    <asp:ListItem Value="2008">2008</asp:ListItem>
                                    <asp:ListItem Value="2009">2009</asp:ListItem>
                                    <asp:ListItem Value="2010">2010</asp:ListItem>
                                    <asp:ListItem Value="2011">2011</asp:ListItem>
                                    <asp:ListItem Value="2012">2012</asp:ListItem>
                                    <asp:ListItem Value="2013">2013</asp:ListItem>
                                    <asp:ListItem Value="2014">2014</asp:ListItem>
                                    <asp:ListItem Value="2015">2015</asp:ListItem>
                                </asp:DropDownList>
                            </font>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <font face="宋体">结束年份：
                                <asp:DropDownList ID="ddlEndYear" runat="server">
                                    <asp:ListItem Value="2005">2005</asp:ListItem>
                                    <asp:ListItem Value="2006">2006</asp:ListItem>
                                    <asp:ListItem Value="2007">2007</asp:ListItem>
                                    <asp:ListItem Value="2008">2008</asp:ListItem>
                                    <asp:ListItem Value="2009">2009</asp:ListItem>
                                    <asp:ListItem Value="2010">2010</asp:ListItem>
                                    <asp:ListItem Value="2011">2011</asp:ListItem>
                                    <asp:ListItem Value="2012">2012</asp:ListItem>
                                    <asp:ListItem Value="2013">2013</asp:ListItem>
                                    <asp:ListItem Value="2014">2014</asp:ListItem>
                                    <asp:ListItem Value="2015">2015</asp:ListItem>
                                </asp:DropDownList>
                            </font>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <asp:ListBox ID="ListBoxClass" runat="server" Width="100%" AutoPostBack="True" Rows="12" onselectedindexchanged="ListBoxClass_SelectedIndexChanged">
                            </asp:ListBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <asp:Button ID="btnQuery" runat="server" Text="Q.查询" onclick="ListBoxClass_SelectedIndexChanged"></asp:Button>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="noDoubleBorderTable_TD">
                单位：万元
            </td>
        </tr>
        <tr>
            <td class="noDoubleBorderTable_TD">
                <igtbl:UltraWebGrid id="UltraWebGrid1" runat="server" ImageDirectory="/ig_common/Images/" ondatabinding="UltraWebGrid1_DataBinding">
                    <displaylayout allowdeletedefault="Yes" allowsortingdefault="OnClient" rowheightdefault="20px"
                        version="4.00" selecttyperowdefault="Extended" viewtype="OutlookGroupBy" allowcolumnmovingdefault="OnServer"
                        headerclickactiondefault="SortMulti" bordercollapsedefault="Separate" allowcolsizingdefault="Free"
                        rowselectorsdefault="No" name="UltraWebGrid1" allowupdatedefault="Yes">
								<AddNewBox Hidden="False">
									<Style BorderWidth="1px" BorderColor="InactiveCaption" BorderStyle="Solid" BackColor="Window">
									    <BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails></Style>
								</AddNewBox>
								<Pager>
									<Style BorderWidth="1px" BorderStyle="Solid" BackColor="LightGray">
									    <BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails></Style>
								</Pager>
								<HeaderStyleDefault BorderStyle="Solid" HorizontalAlign="Left" BackColor="LightGray">
									<BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
								</HeaderStyleDefault>
								<GroupByRowStyleDefault BorderColor="Window" BackColor="Control"></GroupByRowStyleDefault>
								<FrameStyle BorderWidth="1px" Font-Size="8.25pt" Font-Names="Microsoft Sans Serif" BorderColor="InactiveCaption"
									BorderStyle="Solid" BackColor="Window"></FrameStyle>
								<FooterStyleDefault BorderWidth="1px" BorderStyle="Solid" BackColor="LightGray">
									<BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
								</FooterStyleDefault>
								<GroupByBox>
									<Style BorderColor="Window" BackColor="ActiveBorder">
									    </Style>
								</GroupByBox>
								<EditCellStyleDefault BorderWidth="0px" BorderStyle="None"></EditCellStyleDefault>
								<RowStyleDefault BorderWidth="1px" BorderColor="Silver" BorderStyle="Solid" BackColor="Window">
									<Padding Left="3px"></Padding>
									<BorderDetails WidthLeft="0px" WidthTop="0px"></BorderDetails>
								</RowStyleDefault>
							</displaylayout>
                    <bands>
								<igtbl:UltraGridBand></igtbl:UltraGridBand>
							</bands>
                </igtbl:UltraWebGrid>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>

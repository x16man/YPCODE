<%@ Page Language="c#" CodeBehind="CorrespondingPeriodMonthCompare.aspx.cs" AutoEventWireup="True"
    Inherits="WebMM.Analysis.CorrespondingPeriodMonthCompare" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>CorrespondingPeriodMonthCompare</title>
    <link href="../CSS/StyleSheet.css" type="text/css" rel="stylesheet">
</head>
<body bottommargin="0" leftmargin="0" topmargin="0" rightmargin="0" >
    <form id="Form1" method="post" runat="server">
    <table class="noDoubleBorderTable" width="100%">
        <tr>
            <td colspan="2">
                <igmisc:webpanel id="WebPanel1" runat="server" Height="72px" Width="100%" BackColor="#E0DED2">
                    <header text="库存同期比较" textalignment="Left">
								<ExpandedAppearance>
									<Style Height="20px" Font-Size="9pt" Font-Names="宋体" Font-Bold="True" ForeColor="White"
										BackgroundImage="igpnl_office2k3_drk.png">
									    <Padding Left="5px"></Padding></Style>
								</ExpandedAppearance>
							</header>
                    <template>
								<br>同期比较说明：
								<br>&nbsp;&nbsp;您可以选择右侧的仓库或者物料分类列表，进行某一个仓库或者分类的同期比较。
								<br>同时，您也可以设置比较的年份区间和月份区间。
								<br>例如：
								<br>如果您选择了2005到2007年，1月到6月，就表示只比较2005年到2007年的1月到6月的比较情况。
							</template>
                </igmisc:webpanel>
            </td>
        </tr>
        <tr>
            <td style="height: 259px" valign="top" align="left">
                <table class="noDoubleBorderTable" id="Table1" cellspacing="1" cellpadding="1" border="1">
                    <tr>
                        <td>
                            <dcwc:Chart ID="Chart1" runat="server" Height="328px" Width="496px" BackColor="#DAE5F4"
                                BackGradientType="DiagonalLeft" Palette="SemiTransparent" BorderLineColor="26, 59, 105"
                                BorderLineStyle="Solid">
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
                                        <AxisY TitleAlignment="Far" LineColor="DimGray" Title="金额(万元)">
                                            <MajorGrid LineStyle="Dot" LineColor="DimGray"></MajorGrid>
                                            <MajorTickMark LineColor="DimGray" Enabled="False"></MajorTickMark>
                                        </AxisY>
                                        <AxisX TitleAlignment="Far" LineColor="DimGray" Maximum="12" Interlaced="True" Minimum="1"
                                            Title="月份">
                                            <MajorGrid LineStyle="Dot" LineColor="DimGray"></MajorGrid>
                                            <MajorTickMark LineColor="DimGray" Enabled="False"></MajorTickMark>
                                        </AxisX>
                                    </dcwc:ChartArea>
                                </ChartAreas>
                                <Titles>
                                    <dcwc:Title Font="Microsoft Sans Serif, 10.5pt, style=Bold" Text="仓库同期月份比较" Color="26, 59, 105">
                                    </dcwc:Title>
                                </Titles>
                                <BorderSkin FrameBackColor="LightSkyBlue" FrameBackGradientEndColor="DodgerBlue">
                                </BorderSkin>
                            </dcwc:Chart>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <igtbl:ultrawebgrid id="UltraWebGrid1" runat="server" ondatabinding="UltraWebGrid1_DataBinding">
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
                            </igtbl:ultrawebgrid>
                        </td>
                    </tr>
                </table>
            </td>
            <td valign="top" align="right" width="200" rowspan="2">
                <table class="noDoubleBorderTable" width="100%">
                    <tr>
                        <td class="noDoubleBorderTable" nowrap>
                            开始年份：
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
                        </td>
                        <td class="noDoubleBorderTable" nowrap>
                            结束年份：<asp:DropDownList ID="ddlEndYear" runat="server">
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
                        </td>
                    </tr>
                    <tr>
                        <td class="noDoubleBorderTable" nowrap>
                            开始月份：
                            <asp:DropDownList ID="ddlStartMonth" runat="server">
                                <asp:ListItem Value="1">1</asp:ListItem>
                                <asp:ListItem Value="2">2</asp:ListItem>
                                <asp:ListItem Value="3">3</asp:ListItem>
                                <asp:ListItem Value="4">4</asp:ListItem>
                                <asp:ListItem Value="5">5</asp:ListItem>
                                <asp:ListItem Value="6">6</asp:ListItem>
                                <asp:ListItem Value="7">7</asp:ListItem>
                                <asp:ListItem Value="8">8</asp:ListItem>
                                <asp:ListItem Value="9">9</asp:ListItem>
                                <asp:ListItem Value="10">10</asp:ListItem>
                                <asp:ListItem Value="11">11</asp:ListItem>
                                <asp:ListItem Value="12">12</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td class="noDoubleBorderTable" nowrap>
                            结束月份：<asp:DropDownList ID="ddlEndMonth" runat="server">
                                <asp:ListItem Value="1">1</asp:ListItem>
                                <asp:ListItem Value="2">2</asp:ListItem>
                                <asp:ListItem Value="3">3</asp:ListItem>
                                <asp:ListItem Value="4">4</asp:ListItem>
                                <asp:ListItem Value="5">5</asp:ListItem>
                                <asp:ListItem Value="6">6</asp:ListItem>
                                <asp:ListItem Value="7">7</asp:ListItem>
                                <asp:ListItem Value="8">8</asp:ListItem>
                                <asp:ListItem Value="9">9</asp:ListItem>
                                <asp:ListItem Value="10">10</asp:ListItem>
                                <asp:ListItem Value="11">11</asp:ListItem>
                                <asp:ListItem Value="12">12</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="noDoubleBorderTable_TD" style="height: 26px" nowrap>
                            仓库：
                        </td>
                        <td class="noDoubleBorderTable_TD" style="height: 26px" align="center">
                            <asp:Button ID="btnStorageQuery" runat="server" Text="Q. 查询" onclick="btnQuery_Click"></asp:Button>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:ListBox ID="ListBoxStorage" runat="server" Width="100%" AutoPostBack="True"
                                Rows="10" onselectedindexchanged="btnQuery_Click"></asp:ListBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="noDoubleBorderTable_TD" style="height: 27px">
                            分类：
                        </td>
                        <td class="noDoubleBorderTable_TD" style="height: 27px" align="center">
                            <asp:Button ID="btnCategoryQuery" runat="server" Text="Q. 查询" onclick="btnCategoryQuery_Click"></asp:Button>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:ListBox ID="ListBoxCategory" runat="server" Width="100%" AutoPostBack="True"
                                Rows="15" onselectedindexchanged="btnCategoryQuery_Click"></asp:ListBox>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td valign="top" align="left">
            </td>
        </tr>
    </table>
    </form>
</body>
</html>

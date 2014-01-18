<%@ Page Language="c#" CodeBehind="StockAnalysis.aspx.cs" AutoEventWireup="True"
    Inherits="MZHMM.WebMM.Analysis.StockAnalysis" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>库存统计</title>
    <link href="../CSS/StyleSheet.css" type="text/css" rel="stylesheet">
    <style type="text/css">
    .hidden
    {
	    display:none;
	    visibility:hidden;
	 }
        </style>
</head>
<body  topmargin="2">
    <form id="Form1" method="post" runat="server">
    <font face="宋体">
        <table id="Table1" width="100%" border="0">
            <tr>
                <td>
                    <igmisc:webpanel id="WebPanel1" runat="server" Width="100%" Font-Names="宋体" Font-Size="X-Small">
                        <panelstyle customrules="FILTER:progid:DXImageTransform.Microsoft.Gradient(StartColorStr=#7FEBE8D7, EndColorStr=#7FCFCCBB, GradientType=1) progid:DXImageTransform.Microsoft.Gradient(StartColorStr=#7FCFCCBB, EndColorStr=#7FEBE8D7, GradientType=0);">
									<BorderDetails WidthLeft="1px" StyleBottom="Solid" ColorBottom="Gray" ColorRight="Gray" WidthRight="1px"
										StyleRight="Solid" WidthBottom="1px" StyleLeft="Solid" ColorLeft="224, 224, 224"></BorderDetails>
								</panelstyle>
                        <header text="&amp;nbsp;&amp;nbsp;&amp;nbsp;呈现层次" textalignment="Left">
									<HoverAppearance>
										<Style ForeColor="Blue">
										    </Style>
									</HoverAppearance>
									<ExpandedAppearance>
										<Style Font-Size="9pt" Font-Names="Times New Roman" Font-Bold="True" ForeColor="Honeydew"
											BackgroundImage="igpnl_office2k3_drk.png">
										    <BorderDetails ColorTop="LightGray" WidthLeft="1px" WidthTop="1px" ColorRight="Gray" WidthRight="1px" StyleTop="Solid" StyleRight="Solid" StyleLeft="Solid" ColorLeft="LightGray"></BorderDetails></Style>
									</ExpandedAppearance>
								</header>
                        <autopostback expandedstatechanging="False" expandedstatechanged="False"></autopostback>
                        <template>
									<table width="100%" border="1" bordercolor="black">
										<tr>
											<td width="400">
												<table width="100%">
													<tr>
														<td colspan="2">库存数据的呈现可以有六种组合方式。</td>
													</tr>
													<tr>
														<td><IMG src="../Images/bullet_orange.gif">&nbsp;&nbsp;<a href="#" onclick="HrefClick('ABC,StoName,CatName')">ABC&nbsp;--&gt; 
																仓库 --〉账册类别</a></td>
														<td><IMG src="../Images/bullet_orange.gif">&nbsp;&nbsp;<a href="#" onclick="HrefClick('ABC,CatName,StoName')">ABC 
																--〉账册类别 --〉仓库</a></td>
													</tr>
													<tr>
														<td><IMG src="../Images/bullet_orange.gif">&nbsp;&nbsp;<a href="#" onclick="HrefClick('StoName,ABC,CatName')">仓库 
																--〉ABC --〉账册类别</a></td>
														<td><IMG src="../Images/bullet_orange.gif">&nbsp;&nbsp;<a href="#" onclick="HrefClick('StoName,CatName,ABC')">仓库 
																--〉账册类别 --〉ABC</a></td>
													</tr>
													<tr>
														<td><IMG src="../Images/bullet_orange.gif">&nbsp;&nbsp;<a href="#" onclick="HrefClick('CatName,ABC,StoName')">账册类别 
																--〉ABC --&gt; 仓库</a></td>
														<td><IMG src="../Images/bullet_orange.gif">&nbsp;&nbsp;<a href="#" onclick="HrefClick('CatName,StoName,ABC')">账册类别 
																--〉仓库 --&gt; ABC</a></td>
													</tr>
													<tr><td colspan=2>说明：有关物料的ABC分类规则，单价>=1000元为A类，1000>单价>=100元为B类，100>单价的为C类。</td></tr>
												</table>
											</td>
											<td>
												<table>
													<tr>
														<td><IMG src="../Images/language.gif">&nbsp;&nbsp;您可以通过点击左侧的连接来进行你所想要的方式来进行数据的呈现</td>
													</tr>
													<tr>
														<td>您也可以通过拖动表格的列标题栏，来达到你所想要呈现的格式</td>
													</tr>
													<tr>
														<td>提醒： 在通过拖动列方式进行分层显示时，层数越多，显示的速度会越慢。 所以在没必要的情况尽量少用。</td>
													</tr>
												</table>
											</td>
										</tr>
									</table>
								</template>
                    </igmisc:webpanel>
                    <table id="Table2" bordercolor="black" width="100%" border="1">
                        <tr>
                            <td valign="top">
                                <igtbl:ultrawebgrid id="UltraWebGrid1" runat="server" ImageDirectory="/ig_common/Images/" ondatabinding="UltraWebGrid1_DataBinding">
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
                            <td valign="top" width="300">
                                <dcwc:Chart ID="Chart1" runat="server" Height="550px" BackColor="LightSteelBlue"
                                    Palette="Pastel" BorderLineColor="LightSlateGray" ImageType="Png">
                                    <Legends>
                                        <dcwc:Legend AutoFitText="False" BorderColor="Gray" DockToChartArea="Default" Docking="Bottom"
                                            DockInsideChartArea="False" Name="Default" BackColor="Lavender" Font="Microsoft Sans Serif, 9pt"
                                            Alignment="Far" ShadowOffset="2">
                                        </dcwc:Legend>
                                    </Legends>
                                    <Series>
                                        <dcwc:Series ShowLabelAsValue="True" XValueType="Double" ChartType="Pie" CustomAttributes="LabelStyle=Inside"
                                            Name="Default" BorderColor="64, 64, 64" ShadowOffset="2" YValueType="Double">
                                        </dcwc:Series>
                                    </Series>
                                    <ChartAreas>
                                        <dcwc:ChartArea Name="Default" BorderColor="Transparent" BorderStyle="Solid" BackColor="Transparent">
                                            <AxisY2 LineColor="120, 64, 64, 64">
                                            </AxisY2>
                                            <AxisX2 LineColor="120, 64, 64, 64">
                                            </AxisX2>
                                            <Area3DStyle Enable3D="True"></Area3DStyle>
                                            <Position Y="13.8646317" Height="57.99878" Width="87.7290955" X="5.508361"></Position>
                                            <AxisY LineColor="120, 64, 64, 64">
                                                <MajorGrid LineStyle="Dash" LineColor="LightSteelBlue"></MajorGrid>
                                            </AxisY>
                                            <AxisX LineColor="120, 64, 64, 64">
                                                <MajorGrid LineStyle="Dash" LineColor="LightSteelBlue"></MajorGrid>
                                            </AxisX>
                                        </dcwc:ChartArea>
                                    </ChartAreas>
                                    <Titles>
                                        <dcwc:Title Font="Microsoft Sans Serif, 14.25pt, style=Bold" Text="库存分布情况图">
                                        </dcwc:Title>
                                    </Titles>
                                    <BorderSkin FrameBackColor="SteelBlue" FrameBackGradientEndColor="LightBlue" SkinStyle="Emboss">
                                    </BorderSkin>
                                </dcwc:Chart>
                            </td>
                        </tr>
                    </table>
                    <div class="hidden">
                    <asp:Button ID="btnHref" runat="server" Width="0" Text="Button" onclick="btnHref_Click"></asp:Button><asp:TextBox
                        ID="txtOrderString" runat="server" Width="0"></asp:TextBox><asp:TextBox ID="txtGroupString"
                            runat="server" Width="0px"></asp:TextBox></div>
                </td>
            </tr>
        </table>
        <p>
            &nbsp;</p>
    </font>

    <script language="javascript">
        function HrefClick(OrderString) {
            document.getElementById("txtOrderString").value = OrderString;
            document.forms[0].btnHref.click();
        }
    </script>

    </form>
</body>
</html>

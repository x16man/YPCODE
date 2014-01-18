<%@ Page Language="c#" CodeBehind="VendorAnalysis.aspx.cs" AutoEventWireup="True"
    Inherits="WebMM.Analysis.VendorAnalysis" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>供应商分析</title>
    	<style type="text/css">
        .hidden
        {
	        display:none;
	        visibility:hidden;
	    }
    </style>
    <link href="../CSS/StyleSheet.css" type="text/css" rel="stylesheet" />
   
    <link href="../CSS/toolbar.css" type="text/css" rel="stylesheet" />
</head>
<body background="../Images/background_blue.gif"  topmargin="2">
    <form id="Form1" method="post" runat="server">
    <font face="宋体">
        <table id="Table1" cellspacing="1" cellpadding="1" width="100%">
            <tr>
                <td valign="top" style="height: 53px">
                    <igmisc:webpanel id="WebPanel1" runat="server" Width="100%" BackColor="#E0DED2">
                        <header text="&amp;nbsp;&amp;nbsp;供应商统计" textalignment="Left">
									<ExpandedAppearance>
										<Style Font-Size="X-Small" Font-Bold="True" ForeColor="White" BackgroundImage="igpnl_office2k3_drk.png">
										    </Style>
									</ExpandedAppearance>
								</header>
                        <template>
									<TABLE borderColor="black" width="100%" border="1">
										<TR>
											<TD>
												<TABLE width="100%">
													<TR>
														<TD colSpan="2">您可以通过点击以上的连接来进行你所想要的方式来进行数据的呈现。</TD>
													</TR>
													<TR>
														<TD colSpan="2">您也可以通过拖动表格的列标题栏，来达到你所想要呈现的格式。</TD>
													</TR>
													<TR>
														<TD colSpan="2">提醒： 在通过拖动列方式进行分层显示时，层数越多，显示的速度会越慢。 所以在没必要的情况尽量少用。</TD>
													</TR>
												</TABLE>
											</TD>
											<TD vAlign="top">
												<TABLE>
													<TR>
														<TD colSpan="2">设定时间范围：</TD>
													</TR>
													<TR>
														<TD>开始日期：</TD>
														<TD>
														     <mzh:ToolbarCalendar ID="WebDateChooser_StartDate" ReadOnly="true" runat="server" />
															</TD>
													</TR>
													<TR>
														<TD style="HEIGHT: 28px">结束日期：</TD>
														<TD style="HEIGHT: 28px">
														    <mzh:ToolbarCalendar ID="WebDateChooser_EndDate" ReadOnly="true" runat="server" />
														</TD>
													</TR>
													<TR>
														<TD align="center" colSpan="2">&nbsp;<INPUT id="btnYes" onclick="QueryClick()" type="button" value="确定"></TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
									</TABLE>
								</template>
                    </igmisc:webpanel>
                    <table width="100%" border="1" bordercolor="black">
                        <tr>
                            <td valign="top">
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
                            <td width="300" valign="top" align="right">
                                <dcwc:Chart ID="Chart1" runat="server" BackColor="LightSteelBlue" Palette="Pastel"
                                    BorderLineColor="LightSlateGray" Width="450px" Height="500px">
                                    <Legends>
                                        <dcwc:Legend AutoFitText="False" BorderColor="Gray" Name="Default" BackColor="Lavender"
                                            Font="Microsoft Sans Serif, 9pt" ShadowOffset="2">
                                        </dcwc:Legend>
                                    </Legends>
                                    <Series>
                                        <dcwc:Series XValueType="Double" ChartType="Pie" Name="Default" BorderColor="64, 64, 64"
                                            ShadowOffset="2" YValueType="Double">
                                        </dcwc:Series>
                                    </Series>
                                    <ChartAreas>
                                        <dcwc:ChartArea Name="Default" BorderColor="Transparent" BorderStyle="Solid" BackColor="Transparent">
                                            <AxisY2 LineColor="120, 64, 64, 64">
                                            </AxisY2>
                                            <AxisX2 LineColor="120, 64, 64, 64">
                                            </AxisX2>
                                            <Area3DStyle Enable3D="True"></Area3DStyle>
                                            <AxisY LineColor="120, 64, 64, 64">
                                                <MajorGrid LineStyle="Dash" LineColor="LightSteelBlue"></MajorGrid>
                                            </AxisY>
                                            <AxisX LineColor="120, 64, 64, 64">
                                                <MajorGrid LineStyle="Dash" LineColor="LightSteelBlue"></MajorGrid>
                                            </AxisX>
                                        </dcwc:ChartArea>
                                    </ChartAreas>
                                    <Titles>
                                        <dcwc:Title Font="楷体_GB2312, 14.25pt, style=Bold" Text="供应商统计">
                                        </dcwc:Title>
                                    </Titles>
                                    <BorderSkin FrameBackColor="SteelBlue" FrameBackGradientEndColor="LightBlue" SkinStyle="Emboss">
                                    </BorderSkin>
                                </dcwc:Chart>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td align="center">
                    
                    <input id="btnClose" type="button" value="关闭" onclick="window.close();">
                    <div class="hidden">
                    <asp:TextBox
                        ID="txtGroupString" runat="server" Width="0px"></asp:TextBox><asp:TextBox ID="txtOrderString"
                            runat="server" Width="0px"></asp:TextBox><asp:Button ID="btnQuery" runat="server"
                                Width="0px" Text="查询" onclick="btnQuery_Click"></asp:Button><asp:Button ID="btnHREF" runat="server" Width="0px"
                                    Text="HREF"></asp:Button></div>
                </td>
            </tr>
        </table>
    </font>

    <script language="javascript">
			function HrefClick(OrderString)
			{
				document.getElementById("txtOrderString").value = OrderString;
				document.forms[0].btnHREF.click();
			}
			function QueryClick()
			{
				document.forms[0].btnQuery.click();
			}
    </script>

    </form>
</body>
</html>

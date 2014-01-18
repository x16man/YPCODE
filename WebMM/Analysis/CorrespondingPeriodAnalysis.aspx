<%@ Page Language="c#" CodeBehind="CorrespondingPeriodAnalysis.aspx.cs" AutoEventWireup="false"
    Inherits="MZHMM.WebMM.Analysis.CorrespondingPeriodAnalysis" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>CorrespondingPeriodAnalysis</title>
    <link href="../CSS/CommonCSS.css" type="text/css" rel="stylesheet">
    <link href="../CSS/StyleSheet.css" type="text/css" rel="stylesheet">
</head>
<body  bottommargin="0" leftmargin="0" topmargin="0" rightmargin="0">
    <form id="Form1" method="post" runat="server">
    <table bordercolor="black" width="100%" border="0">
        <tr>
            <td>
                <igmisc:webpanel id="WebPanel1" runat="server" Height="104px" Width="100%" BackColor="#E0DED2">
                    <header text="同期比较条件设定" textalignment="Left">
								<ExpandedAppearance>
									<Style Font-Size="X-Small" Font-Bold="True" ForeColor="White" BackgroundImage="igpnl_office2k3_drk.png">
									    <
									    Padding Bottom="5px" Left="5px" Top="5px" > </
									    Padding ></Style>
								</ExpandedAppearance>
							</header>
                    <template>
								<TABLE width="100%" border="0">
									<TR>
										<TD vAlign="top"><BR>
											操作说明：
											<BR>
											你可以设定进行几年的同期比较，也可以设定多少个月的的同期比较。
											<BR>
											可以进行每月存货的同期比较，也可以进行每月收发的同期比较。
											<BR>
											针对的方面可以是仓库、物料分类、以及ABC分类。
										</TD>
										<TD width="200px">
											<TABLE border="1">
												<TR>
													<TD noWrap>开始年份：
														<asp:DropDownList id="ddlStartYear" runat="server">
															<asp:ListItem Value="2005" Selected="True">2005</asp:ListItem>
															<asp:ListItem Value="2006">2006</asp:ListItem>
															<asp:ListItem Value="2007">2007</asp:ListItem>
															<asp:ListItem Value="2008">2008</asp:ListItem>
														</asp:DropDownList></TD>
													<TD noWrap>结束年份：
														<asp:DropDownList id="ddlEndYear" runat="server">
															<asp:ListItem Value="2006">2006</asp:ListItem>
															<asp:ListItem Value="2007">2007</asp:ListItem>
															<asp:ListItem Value="2008">2008</asp:ListItem>
															<asp:ListItem Value="2009">2009</asp:ListItem>
															<asp:ListItem Value="2010">2010</asp:ListItem>
														</asp:DropDownList></TD>
												</TR>
												<TR>
													<TD noWrap>开始月份：
														<asp:DropDownList id="ddlStartMonth" runat="server">
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
														</asp:DropDownList></TD>
													<TD noWrap>结束月份：
														<asp:DropDownList id="ddlEndMonth" runat="server">
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
															<asp:ListItem Value="12" Selected="True">12</asp:ListItem>
														</asp:DropDownList></TD>
												</TR>
												<TR>
													<TD noWrap>针对对象：
														<asp:DropDownList id="ddlSpecificItem" runat="server">
															<asp:ListItem Value="0">仓库</asp:ListItem>
															<asp:ListItem Value="1">分类</asp:ListItem>
															<asp:ListItem Value="2">ABC</asp:ListItem>
														</asp:DropDownList></TD>
													<TD noWrap>比较对象：
														<asp:DropDownList id="ddlCompareType" runat="server">
															<asp:ListItem Value="0">存货</asp:ListItem>
															<asp:ListItem Value="1">收发</asp:ListItem>
														</asp:DropDownList></TD>
												</TR>
												<TR>
													<TD style="HEIGHT: 13px">年月切换：
														<asp:DropDownList id="ddlPivot" runat="server">
															<asp:ListItem Value="0">年份</asp:ListItem>
															<asp:ListItem Value="1" Selected="True">月份</asp:ListItem>
														</asp:DropDownList></TD>
													<TD style="HEIGHT: 13px" align="center"><INPUT onclick="QueryClick()" type="button" value="Q. 查询">
													</TD>
												</TR>
											</TABLE>
										</TD>
									</TR>
								</TABLE>
							</template>
                </igmisc:webpanel>
            </td>
        </tr>
        <tr>
            <td>
                <igtbl:ultrawebgrid id="UltraWebGrid1" runat="server">
                    <displaylayout allowdeletedefault="Yes" allowsortingdefault="OnClient" rowheightdefault="20px"
                        version="4.00" selecttyperowdefault="Extended" viewtype="OutlookGroupBy" allowcolumnmovingdefault="OnServer"
                        headerclickactiondefault="SortMulti" bordercollapsedefault="Separate" allowcolsizingdefault="Free"
                        rowselectorsdefault="No" name="UltraWebGrid1" allowupdatedefault="Yes">
								<AddNewBox Hidden="False">
									<Style BorderWidth="1px" BorderColor="InactiveCaption" BorderStyle="Solid" BackColor="Window">
									    <
									    BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White" > </
									    BorderDetails ></Style>
								</AddNewBox>
								<Pager>
									<Style BorderWidth="1px" BorderStyle="Solid" BackColor="LightGray">
									    <
									    BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White" > </
									    BorderDetails ></Style>
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

    <script language="javascript">
			function QueryClick()
			{
				document.forms[0].Button1.click();
			}
    </script>

    <asp:Button ID="Button1" Style="z-index: 101; left: 376px; position: absolute; top: 472px"
        runat="server" Text="Button" Width="0px"></asp:Button>
    </form>
</body>
</html>

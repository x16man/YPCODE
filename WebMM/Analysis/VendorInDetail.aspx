<%@ Page Language="c#" CodeBehind="VendorInDetail.aspx.cs" AutoEventWireup="True"
    Inherits="WebMM.Analysis.VendorInDetail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>供应商供货详细情况</title>
    <link href="../CSS/StyleSheet.css" type="text/css" rel="stylesheet">
</head>
<body >
    <form id="Form1" method="post" runat="server">
    <table>
        <tr>
            <td>
                <table width="100%">
                    <tr>
                        <td>
                            <table height="100%" width="100%">
                                <tr>
                                    <td style="height: 56px" background="../Images/Header.jpg">
                                        <font face="宋体" color="#1b59a0" size="5"><strong>&nbsp;供应商供货详细情况</strong></font>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table width="100%">
                                            <tr>
                                                <td>
                                                    <font face="宋体">时间段：</font>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblStartDate" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    至
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblEndDate" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td valign="top">
                            <igmisc:webpanel id="WebPanel1" runat="server" Width="100%">
                                <panelstyle borderwidth="1px" bordercolor="#002D96" borderstyle="Solid">
											<Padding Bottom="1px" Left="1px" Top="1px" Right="1px"></Padding>
											<BorderDetails WidthTop="0px"></BorderDetails>
										</panelstyle>
                                <header text="供应商属性" textalignment="Right">
											<ExpandedAppearance>
												<Style BorderWidth="1px" Font-Size="10pt" Font-Names="Times New Roman" Font-Bold="True"
													BorderColor="#002D96" BorderStyle="Solid" ForeColor="White" BackgroundImage="igpnl_office2k3_drk.png">
												    <Padding Bottom="4px" Left="4px" Top="4px" Right="4px"></Padding></Style>
											</ExpandedAppearance>
											<ExpansionIndicator Height="0px" Width="0px"></ExpansionIndicator>
										</header>
                                <template>
											<TABLE class="OnePixelTable" height="100%" cellSpacing="0" cellPadding="0" width="100%"
												border="0">
												<TR>
													<TD width="100">&nbsp;&nbsp;编&nbsp;&nbsp;&nbsp;&nbsp;号：</TD>
													<TD>
														<asp:label id="lblPrvCode" runat="server">&nbsp;</asp:label></TD>
												</TR>
												<TR>
													<TD>&nbsp;&nbsp;名&nbsp;&nbsp;&nbsp;&nbsp;称：</TD>
													<TD>
														<asp:label id="lblPrvName" runat="server">&nbsp;</asp:label></TD>
												</TR>
												<TR>
													<TD>&nbsp;&nbsp;总&nbsp;&nbsp;金额：</TD>
													<TD>
														<asp:label id="lblItemMoney" runat="server">&nbsp;</asp:label></TD>
												</TR>
											</TABLE>
										</template>
                            </igmisc:webpanel>
                        </td>
                    </tr>
                </table>
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
        <tr>
            <td align="center">
                <font face="宋体">
                    <input id="btnClose" onclick="window.close();" type="button" value="关闭"></font>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>

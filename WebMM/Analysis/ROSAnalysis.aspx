<%@ Page language="c#" Codebehind="ROSAnalysis.aspx.cs" AutoEventWireup="True" Inherits="WebMM.Analysis.ROSAnalysis" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head  runat="server">
    <title>申购分布统计 </title>
	
		<style type="text/css">
        .hidden
        {
	        display:none;
	        visibility:hidden;
	    }
    </style>
    <link href="../CSS/StyleSheet.css" type="text/css" rel="stylesheet" />
   
    <link href="../CSS/toolbar.css" type="text/css" rel="stylesheet" />
		
		
		
	</HEAD>
	<body background="../Images/background_blue.gif"  topMargin="2">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%">
				<TR>
					<TD valign="top" style="HEIGHT: 53px"><igmisc:webpanel id="WebPanel1" runat="server" Width="100%" BackColor="#E0DED2">
							<Header Text="&amp;nbsp;&amp;nbsp;申购统计" TextAlignment="Left">
								<ExpandedAppearance>
									<Style Font-Size="X-Small" Font-Bold="True" ForeColor="White" BackgroundImage="igpnl_office2k3_drk.png">
									</Style>
								</ExpandedAppearance>
							</Header>
							<Template>
								<TABLE borderColor="black" width="100%" border="1">
									<TR>
										<TD>
											<TABLE width="100%">
												<TR>
													<TD colSpan="2">申购数据的呈现可以有6种组合：</TD>
												</TR>
												<TR>
													<TD><IMG src="../Images/bullet_orange.gif"> <A onclick="HrefClick('Classify,AuthorDeptName,ReqReason')" href="#">
															用途分类-&gt;部门-&gt;用途</A></TD>
													<TD><IMG src="../Images/bullet_orange.gif"> <A onclick="HrefClick('Classify,ReqReason,AuthorDeptName')" href="#">
															用途分类-&gt;用途-&gt;部门</A></TD>
												</TR>
												<TR>
													<TD><IMG src="../Images/bullet_orange.gif"> <A onclick="HrefClick('ReqReason,Classify,AuthorDeptName')" href="#">
															用途-&gt;用途分类-&gt;部门</A></TD>
													<TD><IMG src="../Images/bullet_orange.gif"> <A onclick="HrefClick('ReqReason,AuthorDeptName,Classify')" href="#">
															用途-&gt;部门-&gt;用途分类</A></TD>
												</TR>
												<TR>
													<TD><IMG src="../Images/bullet_orange.gif"> <A onclick="HrefClick('AuthorDeptName,Classify,ReqReason')" href="#">
															部门-&gt;用途分类-&gt;用途</A></TD>
													<TD><IMG src="../Images/bullet_orange.gif"> <A onclick="HrefClick('AuthorDeptName,ReqReason,Classify')" href="#">
															部门-&gt;用途-&gt;用途分类</A></TD>
												</TR>
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
											<TABLE >
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
													<TD>结束日期：</TD>
													<TD>
													     <mzh:ToolbarCalendar ID="WebDateChooser_EndDate" ReadOnly="true" runat="server" />
														</TD>
												</TR>
												<TR>
													<TD>审批结果：</TD>
													<TD>
														<asp:DropDownList id="ddlFlag" runat="server">
															<asp:ListItem Value="1">审批通过</asp:ListItem>
															<asp:ListItem Value="-1">审批不通过</asp:ListItem>
															<asp:ListItem Value="0">待审批</asp:ListItem>
															<asp:ListItem Value="100">全部</asp:ListItem>
														</asp:DropDownList></TD>
												</TR>
												<TR>
													<TD align="center" colSpan="2">&nbsp;<INPUT id="btnYes" onclick="QueryClick()" type="button" value="确定"></TD>
												</TR>
											</TABLE>
										</TD>
									</TR>
								</TABLE>
							</Template>
						</igmisc:webpanel>
						<table width="100%" border="1" bordercolor="black">
							<tr>
								<TD vAlign="top"><igtbl:ultrawebgrid id="UltraWebGrid1" runat="server" ondatabinding="UltraWebGrid1_DataBinding">
										<DisplayLayout AllowDeleteDefault="Yes" AllowSortingDefault="OnClient" RowHeightDefault="20px"
											Version="4.00" SelectTypeRowDefault="Extended" ViewType="OutlookGroupBy" AllowColumnMovingDefault="OnServer"
											HeaderClickActionDefault="SortMulti" BorderCollapseDefault="Separate" AllowColSizingDefault="Free"
											RowSelectorsDefault="No" Name="UltraWebGrid1" AllowUpdateDefault="Yes">
											<AddNewBox Hidden="False">
												<Style BorderWidth="1px" BorderColor="InactiveCaption" BorderStyle="Solid" BackColor="Window">

<BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White">
</BorderDetails>

												</Style>
											</AddNewBox>
											<Pager>
												<Style BorderWidth="1px" BorderStyle="Solid" BackColor="LightGray">

<BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White">
</BorderDetails>

												</Style>
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
										</DisplayLayout>
										<Bands>
											<igtbl:UltraGridBand></igtbl:UltraGridBand>
										</Bands>
									</igtbl:ultrawebgrid></TD>
								<TD width="300" vAlign="top" align="right"><DCWC:CHART id="Chart1" runat="server" BackColor="LightSteelBlue" Palette="Pastel" BorderLineColor="LightSlateGray"
										Height="500px">
										<Legends>
											<dcwc:Legend BorderColor="Gray" Name="Default" BackColor="Lavender" ShadowOffset="2"></dcwc:Legend>
										</Legends>
										<Series>
											<dcwc:Series XValueType="Double" ChartType="Pie" Name="Default" BorderColor="64, 64, 64" ShadowOffset="2"
												YValueType="Double"></dcwc:Series>
										</Series>
										<ChartAreas>
											<dcwc:ChartArea Name="Default" BorderColor="Transparent" BorderStyle="Solid" BackColor="Transparent">
												<AxisY2 LineColor="120, 64, 64, 64"></AxisY2>
												<AxisX2 LineColor="120, 64, 64, 64"></AxisX2>
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
											<dcwc:Title Font="楷体_GB2312, 14.25pt, style=Bold" Text="申购统计分析"></dcwc:Title>
										</Titles>
										<BorderSkin FrameBackColor="SteelBlue" FrameBackGradientEndColor="LightBlue" SkinStyle="Emboss"></BorderSkin>
									</DCWC:CHART></TD>
							</tr>
						</table>
					</TD>
				</TR>
				<TR>
					<TD align="center">
					<div class="hidden">
					<asp:textbox id="txtGroupString" runat="server" Width="0px"></asp:textbox>
					<asp:textbox id="txtOrderString" runat="server" Width="0px"></asp:textbox>
					<asp:button id="btnQuery" runat="server" Width="0px" Text="查询" onclick="btnQuery_Click"></asp:button>
					<asp:button id="btnHREF" runat="server" Width="0px" Text="HREF" onclick="btnHREF_Click"></asp:button>
					</div>
					</TD>
				</TR>
			</TABLE>
			<SCRIPT language="javascript">
			function HrefClick(OrderString)
			{
				document.getElementById("txtOrderString").value = OrderString;
				document.forms[0].btnHREF.click();
			}
			function QueryClick()
			{
				document.forms[0].btnQuery.click();
			}
			</SCRIPT>
		</form>
	</body>
</HTML>

<%@ Page language="c#" Codebehind="ROSAnalysis.aspx.cs" AutoEventWireup="True" Inherits="WebMM.Analysis.ROSAnalysis" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head  runat="server">
    <title>�깺�ֲ�ͳ�� </title>
	
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
							<Header Text="&amp;nbsp;&amp;nbsp;�깺ͳ��" TextAlignment="Left">
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
													<TD colSpan="2">�깺���ݵĳ��ֿ�����6����ϣ�</TD>
												</TR>
												<TR>
													<TD><IMG src="../Images/bullet_orange.gif"> <A onclick="HrefClick('Classify,AuthorDeptName,ReqReason')" href="#">
															��;����-&gt;����-&gt;��;</A></TD>
													<TD><IMG src="../Images/bullet_orange.gif"> <A onclick="HrefClick('Classify,ReqReason,AuthorDeptName')" href="#">
															��;����-&gt;��;-&gt;����</A></TD>
												</TR>
												<TR>
													<TD><IMG src="../Images/bullet_orange.gif"> <A onclick="HrefClick('ReqReason,Classify,AuthorDeptName')" href="#">
															��;-&gt;��;����-&gt;����</A></TD>
													<TD><IMG src="../Images/bullet_orange.gif"> <A onclick="HrefClick('ReqReason,AuthorDeptName,Classify')" href="#">
															��;-&gt;����-&gt;��;����</A></TD>
												</TR>
												<TR>
													<TD><IMG src="../Images/bullet_orange.gif"> <A onclick="HrefClick('AuthorDeptName,Classify,ReqReason')" href="#">
															����-&gt;��;����-&gt;��;</A></TD>
													<TD><IMG src="../Images/bullet_orange.gif"> <A onclick="HrefClick('AuthorDeptName,ReqReason,Classify')" href="#">
															����-&gt;��;-&gt;��;����</A></TD>
												</TR>
												<TR>
													<TD colSpan="2">������ͨ��������ϵ�����������������Ҫ�ķ�ʽ���������ݵĳ��֡�</TD>
												</TR>
												<TR>
													<TD colSpan="2">��Ҳ����ͨ���϶������б����������ﵽ������Ҫ���ֵĸ�ʽ��</TD>
												</TR>
												<TR>
													<TD colSpan="2">���ѣ� ��ͨ���϶��з�ʽ���зֲ���ʾʱ������Խ�࣬��ʾ���ٶȻ�Խ���� ������û��Ҫ������������á�</TD>
												</TR>
											</TABLE>
										</TD>
										<TD vAlign="top">
											<TABLE >
												<TR>
													<TD colSpan="2">�趨ʱ�䷶Χ��</TD>
												</TR>
												<TR>
													<TD>��ʼ���ڣ�</TD>
													<TD>
													    <mzh:ToolbarCalendar ID="WebDateChooser_StartDate" ReadOnly="true" runat="server" />
														</TD>
												</TR>
												<TR>
													<TD>�������ڣ�</TD>
													<TD>
													     <mzh:ToolbarCalendar ID="WebDateChooser_EndDate" ReadOnly="true" runat="server" />
														</TD>
												</TR>
												<TR>
													<TD>���������</TD>
													<TD>
														<asp:DropDownList id="ddlFlag" runat="server">
															<asp:ListItem Value="1">����ͨ��</asp:ListItem>
															<asp:ListItem Value="-1">������ͨ��</asp:ListItem>
															<asp:ListItem Value="0">������</asp:ListItem>
															<asp:ListItem Value="100">ȫ��</asp:ListItem>
														</asp:DropDownList></TD>
												</TR>
												<TR>
													<TD align="center" colSpan="2">&nbsp;<INPUT id="btnYes" onclick="QueryClick()" type="button" value="ȷ��"></TD>
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
											<dcwc:Title Font="����_GB2312, 14.25pt, style=Bold" Text="�깺ͳ�Ʒ���"></dcwc:Title>
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
					<asp:button id="btnQuery" runat="server" Width="0px" Text="��ѯ" onclick="btnQuery_Click"></asp:button>
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

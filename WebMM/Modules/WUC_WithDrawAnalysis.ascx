<%@ Control Language="c#" AutoEventWireup="True" Codebehind="WUC_WithDrawAnalysis.ascx.cs" Inherits="WebMM.Modules.WUC_WithDrawAnalysis" %>
<%@ Register TagPrefix="igsch" Namespace="Infragistics.WebUI.WebSchedule" Assembly="Infragistics.WebUI.WebDateChooser.v5.3, Version=5.3.20053.50, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%" border="1">
	<TR>
		<TD>
			<table height="100%" width="100%">
				<tr>
					<td><FONT face="宋体">用途分类-&gt;部门</FONT></td>
				</tr>
				<tr>
					<td><FONT face="宋体">部门-&gt;用途分类</FONT></td>
				</tr>
				<tr>
					<td></td>
				</tr>
			</table>
		</TD>
		<TD>
			<table height="100%" width="100%">
				<tr>
					<td><FONT face="宋体">开始日期：</FONT></td>
					<td><igsch:webdatechooser id="dateStartDate" runat="server" Text="Null">
							<CalendarLayout FooterFormat="Today: {0:d}" TitleFormat="Month" MaxDate="" ShowYearDropDown="False"
								PrevMonthImageUrl="ig_cal_blueP0.gif" ShowMonthDropDown="False" NextMonthImageUrl="ig_cal_blueN0.gif">
								<DayStyle BorderWidth="1px" BorderColor="SteelBlue" BorderStyle="Solid" BackgroundImage="ig_cal_blue3.gif"></DayStyle>
								<FooterStyle Height="16pt" Font-Size="8pt" ForeColor="#505080" BackgroundImage="ig_cal_blue2.gif"></FooterStyle>
								<SelectedDayStyle ForeColor="White" BackgroundImage="ig_cal_blue2.gif"></SelectedDayStyle>
								<OtherMonthDayStyle ForeColor="SlateGray"></OtherMonthDayStyle>
								<NextPrevStyle BackgroundImage="ig_cal_blue1.gif"></NextPrevStyle>
								<CalendarStyle BorderWidth="1px" Font-Size="9pt" Font-Names="Verdana" BorderColor="SteelBlue" BorderStyle="Solid"
									BackColor="#CCDDFF"></CalendarStyle>
								<TodayDayStyle BackgroundImage="ig_cal_blue1.gif"></TodayDayStyle>
								<DayHeaderStyle Height="1pt" Font-Size="8pt" Font-Bold="True" ForeColor="#606090" BackgroundImage="ig_cal_blue2.gif"></DayHeaderStyle>
								<TitleStyle Height="18pt" Font-Size="10pt" Font-Bold="True" ForeColor="#505080" BackgroundImage="ig_cal_blue1.gif"
									BackColor="#CCDDFF"></TitleStyle>
							</CalendarLayout>
						</igsch:webdatechooser></td>
				</tr>
				<tr>
					<td><FONT face="宋体">结束日期：</FONT></td>
					<td>
						<igsch:WebDateChooser id="dateEndDate" runat="server" Text="Null">
							<CalendarLayout FooterFormat="Today: {0:d}" TitleFormat="Month" MaxDate="" ShowYearDropDown="False"
								PrevMonthImageUrl="ig_cal_blueP0.gif" ShowMonthDropDown="False" NextMonthImageUrl="ig_cal_blueN0.gif">
								<DayStyle BorderWidth="1px" BorderColor="SteelBlue" BorderStyle="Solid" BackgroundImage="ig_cal_blue3.gif"></DayStyle>
								<FooterStyle Height="16pt" Font-Size="8pt" ForeColor="#505080" BackgroundImage="ig_cal_blue2.gif"></FooterStyle>
								<SelectedDayStyle ForeColor="White" BackgroundImage="ig_cal_blue2.gif"></SelectedDayStyle>
								<OtherMonthDayStyle ForeColor="SlateGray"></OtherMonthDayStyle>
								<NextPrevStyle BackgroundImage="ig_cal_blue1.gif"></NextPrevStyle>
								<CalendarStyle BorderWidth="1px" Font-Size="9pt" Font-Names="Verdana" BorderColor="SteelBlue" BorderStyle="Solid"
									BackColor="#CCDDFF"></CalendarStyle>
								<TodayDayStyle BackgroundImage="ig_cal_blue1.gif"></TodayDayStyle>
								<DayHeaderStyle Height="1pt" Font-Size="8pt" Font-Bold="True" ForeColor="#606090" BackgroundImage="ig_cal_blue2.gif"></DayHeaderStyle>
								<TitleStyle Height="18pt" Font-Size="10pt" Font-Bold="True" ForeColor="#505080" BackgroundImage="ig_cal_blue1.gif"
									BackColor="#CCDDFF"></TitleStyle>
							</CalendarLayout>
						</igsch:WebDateChooser></td>
				</tr>
				<tr>
					<td></td>
					<td><INPUT id="btnYes" type="button" onclick="document.forms[0].btnQuery.click();" value="确定"></td>
				</tr>
			</table>
		</TD>
	</TR>
</TABLE>

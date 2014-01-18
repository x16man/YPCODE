<%@ Register TagPrefix="igsch" Namespace="Infragistics.WebUI.WebSchedule" Assembly="Infragistics.WebUI.WebDateChooser.v5.3, Version=5.3.20053.50, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
<%@ Page language="c#" Codebehind="test.aspx.cs" AutoEventWireup="false" Inherits="WebMM.test" %>
<%@ Register TagPrefix="uc1" TagName="WUC_Feedback" Src="Modules/WUC_Feedback.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>test</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<SCRIPT type="text/javascript"><!--
		/*
		function SetWeekName()
		{
			var chooser = igdrp_getComboById("<%=WebCalendar1.ClientID%>");
			if(chooser == null)
			return;
			var calendar = chooser.Calendar;
			var DayNameTR = document.getElementById(calendar.ID+"_514");
			alert(DayNameTR.innerHTML);
			
			DayNameTR.innerHTML = DayNameTR.innerHTML.replace("星期","");
			alert(DayNameTR.innerHTML);
			
			alert(DayNameTR.cells.length);
			
			for(var i=0;i < 7;i++)
			{
				var td = tr.cells[i];
				alert(td.innerTEXT);
				td.innerTEXT = td.innerTEXT.replace("星期","");
				alert(td.innerTEXT);
			}
		}
		*/
		function SetWeekName()
		{
			var tr=document.getElementById("WebCalendar1_514");    
			for(var i=0;i<tr.cells.length;i++)
			{
			var td = tr.cells[i];
			td.innerHTML = td.innerHTML.replace("星期","");
			}
		        
		}
--></SCRIPT>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<FONT face="宋体">
				<igsch:WebDateChooser id="WebDateChooser1" style="Z-INDEX: 101; LEFT: 48px; POSITION: absolute; TOP: 48px"
					runat="server">
					<ClientSideEvents InitializeDateChooser="SetWeekName"></ClientSideEvents>
					<CalendarLayout FooterFormat="Today: {0:d}" MaxDate=""></CalendarLayout>
				</igsch:WebDateChooser>
				<igsch:WebCalendar id="WebCalendar1" style="Z-INDEX: 102; LEFT: 224px; POSITION: absolute; TOP: 72px"
					runat="server" Width="231px">
					<ClientSideEvents InitializeCalendar="SetWeekName"></ClientSideEvents>
					<Layout FooterFormat="Today: {0:d}">
						<CalendarStyle Width="231px"></CalendarStyle>
					</Layout>
				</igsch:WebCalendar></FONT>
		</form>
	</body>
</HTML>

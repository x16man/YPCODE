<%@ Control Language="c#" AutoEventWireup="True" Codebehind="WUC_YCLStock_Panel.ascx.cs" Inherits="WebMM.Modules.WUC_YCLStock_Panel" %>
<%@ Register TagPrefix="igmisc" Namespace="Infragistics.WebUI.Misc" Assembly="Infragistics.WebUI.Misc.v5.3, Version=5.3.20053.50, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
<%@ Register TagPrefix="uc1" TagName="WUC_YCLStock" Src="WUC_YCLStock.ascx" %>
<igmisc:WebPanel id="WebPanel1" runat="server">
	<PanelStyle BorderWidth="1px" BorderColor="#002D96" BorderStyle="Solid">
		<Padding Bottom="1px" Left="1px" Top="1px" Right="1px"></Padding>
		<BorderDetails WidthTop="0px"></BorderDetails>
	</PanelStyle>
	<Header Text="ԭ���Ͽ��" TextAlignment="Left">
		<ExpandedAppearance>
			<Style BorderWidth="1px" Font-Size="10pt" Font-Names="Times New Roman" Font-Bold="True"
				BorderColor="#002D96" BorderStyle="Solid" ForeColor="White" BackgroundImage="igpnl_office2k3_drk.png">
				<Padding Bottom="4px" Left="4px" Top="4px" Right="4px"></Padding>
			</Style>
		</ExpandedAppearance>
		<ExpansionIndicator Height="0px" Width="0px"></ExpansionIndicator>
	</Header>
	<Template>
		<uc1:WUC_YCLStock id="WUC_YCLStock1" runat="server"></uc1:WUC_YCLStock>
	</Template>
</igmisc:WebPanel>

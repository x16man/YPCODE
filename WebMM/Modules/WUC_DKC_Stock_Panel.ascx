<%@ Control Language="c#" AutoEventWireup="True" Codebehind="WUC_DKC_Stock_Panel.ascx.cs" Inherits="WebMM.Modules.WUC_DKC_Stock_Panel" %>
<%@ Register TagPrefix="igmisc" Namespace="Infragistics.WebUI.Misc" Assembly="Infragistics.WebUI.Misc.v5.3, Version=5.3.20053.50, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
<%@ Register TagPrefix="uc1" TagName="WUC_DKCStock" Src="WUC_DKCStock.ascx" %>
<igmisc:WebPanel id="WebPanel1" runat="server">
	<PanelStyle BorderWidth="1px" BorderColor="#002D96" BorderStyle="Solid">
		<Padding Bottom="1px" Left="1px" Top="1px" Right="1px"></Padding>
		<BorderDetails WidthTop="0px"></BorderDetails>
	</PanelStyle>
	<Header Text="�Ϳ�汨��" TextAlignment="Left">
		<ExpandedAppearance>
			<Style BorderWidth="1px" Font-Size="10pt" Font-Names="Times New Roman" Font-Bold="True"
				BorderColor="#002D96" BorderStyle="Solid" ForeColor="White" BackgroundImage="igpnl_office2k3_drk.png">
				<Padding Bottom="4px" Left="4px" Top="4px" Right="4px"></Padding>
			</Style>
		</ExpandedAppearance>
		<ExpansionIndicator Height="0px" Width="0px"></ExpansionIndicator>
	</Header>
	<Template>
			<uc1:WUC_DKCStock id="WUC_DKCStock1" runat="server"></uc1:WUC_DKCStock>
	</Template>
</igmisc:WebPanel>
<%@ Control Language="c#" AutoEventWireup="True" Codebehind="WUC_DKCStock.ascx.cs" Inherits="WebMM.Modules.WUC_DKCStock" %>
<%@ Register TagPrefix="igmisc" Namespace="Infragistics.WebUI.Misc" Assembly="Infragistics.WebUI.Misc.v5.3, Version=5.3.20053.50, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
<%@ Register TagPrefix="igtbl" Namespace="Infragistics.WebUI.UltraWebGrid" Assembly="Infragistics.WebUI.UltraWebGrid.v5.3, Version=5.3.20053.50, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
<meta name="vs_showGrid" content="False">
		<igtbl:UltraWebGrid id="UG_DKC" runat="server" ondatabinding="UG_DKC_DataBinding">
			<DisplayLayout AllowDeleteDefault="Yes" AllowSortingDefault="OnClient" RowHeightDefault="20px"
				Version="4.00" SelectTypeRowDefault="Extended" ViewType="OutlookGroupBy" AllowColumnMovingDefault="OnServer"
				HeaderClickActionDefault="SortMulti" BorderCollapseDefault="Separate" AllowColSizingDefault="Free"
				RowSelectorsDefault="No" Name="xctl0xUGxYCL" AllowUpdateDefault="Yes">
				<AddNewBox Hidden="False">
					<Style BorderWidth="1px" BorderColor="InactiveCaption" BorderStyle="Solid" BackColor="Window">
						<BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
					</Style>
				</AddNewBox>
				<Pager>
					<Style BorderWidth="1px" BorderStyle="Solid" BackColor="LightGray">
						<BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
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
	</igtbl:UltraWebGrid>

<%@ Control Language="c#" AutoEventWireup="True" CodeBehind="WUC_YCLGroup.ascx.cs"
    Inherits="WebMM.Storage.WUC_YCLGroup" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<table id="Table1" width="100%">
    <tr>
        <td valign="top">
            <igtbl:UltraWebGrid id="UG_YCLGroup" runat="server" ondatabinding="UG_YCLGroup_DataBinding">
                <displaylayout allowdeletedefault="Yes" allowsortingdefault="OnClient" rowheightdefault="20px"
                    version="4.00" selecttyperowdefault="Extended" viewtype="OutlookGroupBy" allowcolumnmovingdefault="OnServer"
                    headerclickactiondefault="SortMulti" bordercollapsedefault="Separate" allowcolsizingdefault="Free"
                    rowselectorsdefault="No" name="xctl0xUltraWebGrid1" allowupdatedefault="Yes">
					<AddNewBox Hidden="False">
						<Style BorderWidth="1px" BorderColor="InactiveCaption" BorderStyle="Solid" BackColor="Window">
						    
						</Style>
					</AddNewBox>
					<Pager>
						<Style BorderWidth="1px" BorderStyle="Solid" BackColor="LightGray">
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
				</displaylayout>
                <bands>
					<igtbl:UltraGridBand></igtbl:UltraGridBand>
				</bands>
            </igtbl:UltraWebGrid>
        </td>
        <td valign="top">
            <table id="Table2">
                <tr>
                    <td>
                        开始日期：
                    </td>
                    <td>
                        <igsch:WebDateChooser id="ddlStartDate" runat="server">
                            <calendarlayout footerformat="Today: {0:d}" maxdate=""></calendarlayout>
                        </igsch:WebDateChooser>
                    </td>
                </tr>
                <tr>
                    <td>
                        结束日期：
                    </td>
                    <td>
                        <igsch:WebDateChooser id="ddlEndDate" runat="server">
                            <calendarlayout footerformat="Today: {0:d}" maxdate=""></calendarlayout>
                        </igsch:WebDateChooser>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        <input type="button" value="确定" onclick="QueryClick()"/>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>

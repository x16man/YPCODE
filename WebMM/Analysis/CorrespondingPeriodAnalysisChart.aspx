<%@ Page Language="c#" CodeBehind="CorrespondingPeriodAnalysisChart.aspx.cs" AutoEventWireup="false"
    Inherits="WebMM.Analysis.CorrespondingPeriodAnalysisChart" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>CorrespondingPeriodAnalysisChart</title>
</head>
<body bottommargin="0" leftmargin="0" topmargin="0" rightmargin="0">
    <form id="Form1" method="post" runat="server">
    <table width="100%">
        <tr>
            <td>
                <dcwc:Chart ID="Chart1" runat="server" Width="800px" Palette="Pastel">
                    <Legends>
                        <dcwc:Legend Name="Default">
                        </dcwc:Legend>
                    </Legends>
                    <Series>
                        <dcwc:Series ShowLabelAsValue="True" XValueType="Double" CustomAttributes="PointWidth=0.4"
                            Name="Default" BorderColor="64, 64, 64" ShadowOffset="1" YValueType="Double">
                        </dcwc:Series>
                        <dcwc:Series ShowLabelAsValue="True" XValueType="Double" CustomAttributes="PointWidth=0.4"
                            Name="Series2" BorderColor="64, 64, 64" ShadowOffset="1" YValueType="Double">
                        </dcwc:Series>
                    </Series>
                    <ChartAreas>
                        <dcwc:ChartArea Name="Default">
                            <AxisY TitleFont="Microsoft Sans Serif, 8.25pt" TitleAlignment="Far" Title="金额">
                            </AxisY>
                            <AxisX TitleAlignment="Far" Title="月份">
                            </AxisX>
                        </dcwc:ChartArea>
                    </ChartAreas>
                    <Titles>
                        <dcwc:Title Font="楷体_GB2312, 14.25pt, style=Bold" Text="同期比较图">
                        </dcwc:Title>
                    </Titles>
                </dcwc:Chart>
            </td>
        </tr>
        <tr>
            <td style="padding-left: 50px">
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
    </form>
</body>
</html>

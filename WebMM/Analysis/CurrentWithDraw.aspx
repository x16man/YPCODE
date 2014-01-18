<%@ Page Language="c#" CodeBehind="CurrentWithDraw.aspx.cs" AutoEventWireup="True"
    Inherits="MZHMM.WebMM.Analysis.CurrentWithDraw" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>CurrentWithDraw</title>
</head>
<body  bottommargin="0" leftmargin="0" topmargin="0" rightmargin="0">
    <form id="Form1" method="post" runat="server">
    <dcwc:Chart ID="Chart1" Style="z-index: 101; left: 0px; position: absolute; top: 0px"
        runat="server" Palette="SemiTransparent" ImageType="Png" Width="400px" BorderLineColor="26, 59, 105"
        BackColor="#DAE5F4" BorderLineStyle="Solid" BorderLineWidth="2" BackGradientType="TopBottom">
        <Legends>
            <dcwc:Legend BorderColor="Transparent" DockToChartArea="Default" Docking="Bottom"
                DockInsideChartArea="False" Name="Default" BackColor="Transparent" Alignment="Center">
            </dcwc:Legend>
        </Legends>
        <Series>
            <dcwc:Series ShowLabelAsValue="True" XValueType="String" ChartType="Pie" CustomAttributes="LabelStyle=Outside"
                Name="Default" BorderColor="120, 50, 50, 50" YValueType="Double">
            </dcwc:Series>
        </Series>
        <ChartAreas>
            <dcwc:ChartArea Name="Default" BorderColor="Transparent" BorderStyle="Solid" BackColor="Transparent">
                <AxisY2 LineColor="DimGray">
                </AxisY2>
                <AxisX2 LineColor="DimGray">
                </AxisX2>
                <Area3DStyle Enable3D="True"></Area3DStyle>
                <AxisY LineColor="DimGray">
                    <MajorGrid LineStyle="Dot" LineColor="DimGray"></MajorGrid>
                    <MajorTickMark LineColor="DimGray" Enabled="False"></MajorTickMark>
                </AxisY>
                <AxisX LineColor="DimGray">
                    <MajorGrid LineStyle="Dot" LineColor="DimGray"></MajorGrid>
                    <MajorTickMark LineColor="DimGray" Enabled="False"></MajorTickMark>
                </AxisX>
            </dcwc:ChartArea>
        </ChartAreas>
        <Titles>
            <dcwc:Title Font="楷体_GB2312, 14.25pt, style=Bold" Text="当月发料统计">
            </dcwc:Title>
        </Titles>
        <BorderSkin FrameBackColor="LightSkyBlue" FrameBackGradientEndColor="DodgerBlue"
            SkinStyle="Emboss"></BorderSkin>
    </dcwc:Chart>
    </form>
</body>
</html>

<%@ Page Language="c#" CodeBehind="CorrespondingPeriodYearCompare.aspx.cs" AutoEventWireup="True"
    Inherits="MZHMM.WebMM.Analysis.CorrespondingPeriodYearCompare" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>CurrentROS</title>
</head>
<body bottommargin="0" leftmargin="0" topmargin="0" >
    <form id="Form1" method="post" runat="server">
    <dcwc:Chart ID="Chart1" Style="z-index: 101; left: 0px; position: absolute; top: 0px"
        runat="server" Height="250px" Palette="SemiTransparent" Width="420px" BorderLineColor="26, 59, 105"
        BackColor="#DAE5F4" BackGradientType="TopBottom" BorderLineStyle="Solid" BorderLineWidth="2">
        <Legends>
            <dcwc:Legend LegendStyle="Row" BorderColor="Transparent" Docking="Bottom" Name="Default"
                BackColor="Transparent">
            </dcwc:Legend>
        </Legends>
        <Series>
            <dcwc:Series ShowLabelAsValue="True" XValueType="String" Name="Default" BorderColor="120, 50, 50, 50"
                LabelFormat="C" YValueType="Double">
                <SmartLabels Enabled="True"></SmartLabels>
            </dcwc:Series>
        </Series>
        <ChartAreas>
            <dcwc:ChartArea Name="Default" BorderColor="DimGray" BackColor="Transparent">
                <AxisY2 LineColor="DimGray">
                </AxisY2>
                <AxisX2 LineColor="DimGray">
                </AxisX2>
                <Area3DStyle Enable3D="True" Light="Realistic"></Area3DStyle>
                <AxisY TitleAlignment="Far" LineColor="DimGray" Title="金额(万元)">
                    <MajorGrid LineStyle="Dot" LineColor="DimGray"></MajorGrid>
                    <MajorTickMark LineColor="DimGray" Enabled="False"></MajorTickMark>
                </AxisY>
                <AxisX TitleFont="Microsoft Sans Serif, 12pt" TitleAlignment="Far" LineColor="DimGray"
                    Interlaced="True">
                    <MajorGrid LineStyle="Dot" LineColor="DimGray"></MajorGrid>
                    <MajorTickMark LineColor="DimGray" Enabled="False"></MajorTickMark>
                </AxisX>
            </dcwc:ChartArea>
        </ChartAreas>
        <Titles>
            <dcwc:Title Font="Microsoft Sans Serif, 10.5pt, style=Bold" Text="库存同期比较" Color="26, 59, 105">
            </dcwc:Title>
        </Titles>
        <BorderSkin FrameBackColor="LightSkyBlue" FrameBackGradientEndColor="DodgerBlue"
            SkinStyle="Emboss" FrameBorderStyle="Solid"></BorderSkin>
    </dcwc:Chart>
    </form>
</body>
</html>

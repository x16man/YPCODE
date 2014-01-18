<%@ Page Language="c#" CodeBehind="CorrespondingABCYearCompare.aspx.cs" AutoEventWireup="True"
    Inherits="WebMM.Analysis.CorrespondingABCYearCompare" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>CorrespondingABCYearCompare</title>
    <link href="../CSS/StyleSheet.css" type="text/css" rel="stylesheet">
</head>
<body bottommargin="0" leftmargin="0" topmargin="0" rightmargin="0" >
    <form id="Form1" method="post" runat="server">
    <dcwc:Chart ID="Chart1" runat="server" Height="165px" BorderLineWidth="2" BorderLineStyle="Solid"
        Width="400px" BackColor="#DAE5F4" BorderLineColor="26, 59, 105" Palette="SemiTransparent"
        BackGradientType="TopBottom">
        <Legends>
            <dcwc:Legend BorderColor="Transparent" Name="Default" BackColor="Transparent">
            </dcwc:Legend>
        </Legends>
        <Series>
            <dcwc:Series XValueType="Double" Name="Series1" BorderColor="120, 50, 50, 50" YValueType="Double">
            </dcwc:Series>
            <dcwc:Series XValueType="Double" Name="Series2" BorderColor="120, 50, 50, 50" YValueType="Double">
            </dcwc:Series>
        </Series>
        <ChartAreas>
            <dcwc:ChartArea Name="Default" BorderColor="DimGray" BorderStyle="Solid" BackColor="120, 173, 216, 230">
                <AxisY2 LineColor="DimGray">
                </AxisY2>
                <AxisX2 LineColor="DimGray">
                </AxisX2>
                <Area3DStyle Enable3D="True"></Area3DStyle>
                <AxisY TitleAlignment="Far" LineColor="DimGray" Title="金额(万元)">
                    <MajorGrid LineStyle="Dot" LineColor="DimGray"></MajorGrid>
                    <MajorTickMark LineColor="DimGray" Enabled="False"></MajorTickMark>
                </AxisY>
                <AxisX LineColor="DimGray" Interlaced="True">
                    <MajorGrid LineStyle="Dot" LineColor="DimGray"></MajorGrid>
                    <MajorTickMark LineColor="DimGray" Enabled="False"></MajorTickMark>
                </AxisX>
            </dcwc:ChartArea>
        </ChartAreas>
        <Titles>
            <dcwc:Title Font="Microsoft Sans Serif, 12pt, style=Bold" Text="ABC分类库存的年度比较" Color="26, 59, 105">
            </dcwc:Title>
        </Titles>
        <BorderSkin FrameBackColor="LightSkyBlue" FrameBackGradientEndColor="DodgerBlue"
            SkinStyle="Emboss"></BorderSkin>
    </dcwc:Chart>
    </TABLE>
    </form>
</body>
</html>

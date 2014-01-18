<%@ Page Language="c#" CodeBehind="CurrentStock.aspx.cs" AutoEventWireup="True"
    Inherits="WebMM.Analysis.CurrentStock" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>CurrentStock</title>
</head>
<body  bottommargin="0" leftmargin="0" topmargin="0" rightmargin="0">
    <form id="Form1" method="post" runat="server">
    <dcwc:Chart ID="Chart_CurrentStock" Style="z-index: 101; left: 0px; position: absolute;
        top: 0px" runat="server" Palette="SemiTransparent" Width="400px" BorderLineColor="26, 59, 105"
        BackColor="#DAE5F4" BorderLineStyle="Solid" BorderLineWidth="2" BackGradientType="TopBottom">
        <Legends>
            <dcwc:Legend BorderColor="Gray" Docking="Bottom" DockInsideChartArea="False" Name="Default"
                BackColor="Lavender" Alignment="Center" ShadowOffset="2">
            </dcwc:Legend>
        </Legends>
        <Series>
            <dcwc:Series ShowLabelAsValue="True" XValueType="String" ChartType="Pie" CustomAttributes="LabelStyle=Outside"
                Name="Default" BorderColor="64, 64, 64" ShadowOffset="2" YValueType="Double">
            </dcwc:Series>
        </Series>
        <ChartAreas>
            <dcwc:ChartArea Name="Default" BorderColor="Transparent" BorderStyle="Solid" BackColor="Transparent">
                <AxisY2 LineColor="120, 64, 64, 64">
                </AxisY2>
                <AxisX2 LineColor="120, 64, 64, 64">
                </AxisX2>
                <Area3DStyle Enable3D="True"></Area3DStyle>
                <AxisY LineColor="120, 64, 64, 64">
                    <MajorGrid LineStyle="Dash" LineColor="LightSteelBlue"></MajorGrid>
                </AxisY>
                <AxisX LineColor="120, 64, 64, 64">
                    <MajorGrid LineStyle="Dash" LineColor="LightSteelBlue"></MajorGrid>
                </AxisX>
            </dcwc:ChartArea>
        </ChartAreas>
        <Titles>
            <dcwc:Title Font="Microsoft Sans Serif, 14.25pt, style=Bold" Text="¿â´æ·Ö²¼Í¼">
            </dcwc:Title>
        </Titles>
        <BorderSkin FrameBackColor="SteelBlue" FrameBackGradientEndColor="LightBlue" SkinStyle="Emboss">
        </BorderSkin>
    </dcwc:Chart>
    </form>
</body>
</html>

<%@ Page Language="c#" CodeBehind="CurrentROS.aspx.cs" AutoEventWireup="True" Inherits="MZHMM.WebMM.Analysis.CurrentROS" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>CurrentROS</title>
</head>
<body  bottommargin="0" leftmargin="0" topmargin="0">
    <form id="Form1" method="post" runat="server">
    <font face="宋体">
        <dcwc:Chart ID="Chart1" Style="z-index: 101; left: 0px; position: absolute; top: 0px"
            runat="server" Palette="SemiTransparent" Width="400px" BorderLineColor="26, 59, 105"
            BackColor="#DAE5F4" BackGradientType="TopBottom" BorderLineStyle="Solid" BorderLineWidth="2">
            <Legends>
                <dcwc:Legend BorderColor="Gray" Docking="Bottom" Name="Default" BackColor="Lavender"
                    Alignment="Center" ShadowOffset="2">
                </dcwc:Legend>
            </Legends>
            <Series>
                <dcwc:Series ShowLabelAsValue="True" XValueType="String" ChartType="Pie" CustomAttributes="LabelStyle=Outside, RadarDrawingStyle=Area"
                    Name="Default" BorderColor="64, 64, 64" ShadowOffset="2" YValueType="Double">
                </dcwc:Series>
            </Series>
            <ChartAreas>
                <dcwc:ChartArea Name="Default" BorderColor="Transparent" BorderStyle="Solid" BackColor="Transparent">
                    <AxisY2 LineColor="120, 64, 64, 64">
                    </AxisY2>
                    <AxisX2 LineColor="120, 64, 64, 64">
                    </AxisX2>
                    <Area3DStyle Enable3D="True" Light="Realistic"></Area3DStyle>
                    <AxisY LineColor="120, 64, 64, 64">
                        <MajorGrid LineStyle="Dash" LineColor="LightSteelBlue"></MajorGrid>
                    </AxisY>
                    <AxisX LineColor="120, 64, 64, 64">
                        <MajorGrid LineStyle="Dash" LineColor="LightSteelBlue"></MajorGrid>
                    </AxisX>
                </dcwc:ChartArea>
            </ChartAreas>
            <Titles>
                <dcwc:Title Font="Microsoft Sans Serif, 14.25pt, style=Bold" Text="本月采购申请汇总">
                </dcwc:Title>
            </Titles>
            <BorderSkin FrameBackColor="SteelBlue" FrameBackGradientEndColor="LightBlue" SkinStyle="Emboss">
            </BorderSkin>
        </dcwc:Chart>
    </font>
    </form>
</body>
</html>

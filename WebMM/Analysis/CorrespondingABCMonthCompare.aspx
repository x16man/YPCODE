<%@ Page Language="c#" CodeBehind="CorrespondingABCMonthCompare.aspx.cs" AutoEventWireup="True"
    Inherits="WebMM.Analysis.CorrespondingABCMonthCompare" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>CorrespondingABCMonthCompare</title>
    <link href="../CSS/StyleSheet.css" type="text/css" rel="stylesheet" />
</head>
<body>
    <form id="Form1" method="post" runat="server">
    <font face="宋体">
        <dcwc:Chart ID="Chart1" Style="z-index: 101; left: 8px; position: absolute; top: 64px"
            runat="server" Width="464px" BorderLineWidth="2" BorderLineStyle="Solid" BackColor="#DAE5F4"
            BorderLineColor="26, 59, 105" Palette="SemiTransparent" BackGradientType="TopBottom">
            <Legends>
                <dcwc:Legend LegendStyle="Row" BorderColor="Transparent" Docking="Bottom" Name="Default"
                    BackColor="Transparent">
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
                    <AxisY TitleAlignment="Far" LineColor="DimGray" Title="金额">
                        <MajorGrid LineStyle="Dot" LineColor="DimGray"></MajorGrid>
                        <MajorTickMark LineColor="DimGray"></MajorTickMark>
                    </AxisY>
                    <AxisX TitleAlignment="Far" LineColor="DimGray" Maximum="12" Minimum="1" Title="月份">
                        <MajorGrid LineStyle="Dot" LineColor="DimGray"></MajorGrid>
                        <MajorTickMark LineColor="DimGray"></MajorTickMark>
                    </AxisX>
                </dcwc:ChartArea>
            </ChartAreas>
            <Titles>
                <dcwc:Title Font="Microsoft Sans Serif, 12pt, style=Bold" Text="ABC分类库存的每月比较" Color="26, 59, 105">
                </dcwc:Title>
            </Titles>
            <BorderSkin FrameBackColor="LightSkyBlue" FrameBackGradientEndColor="DodgerBlue"
                SkinStyle="Emboss"></BorderSkin>
        </dcwc:Chart>
    </font>
    <table id="Table1" style="z-index: 110; left: 16px; width: 448px; border-bottom: black thin inset;
        position: absolute; top: 8px; height: 48px" cellspacing="1" cellpadding="1" width="448"
        border="0">
        <tr>
            <td style="width: 54px">
                <font face="宋体">年份：</font>
            </td>
            <td style="width: 65px">
                <font face="宋体">
                    <asp:DropDownList ID="ddlStartYear" runat="server" Width="64px">
                        <asp:ListItem Value="2005">2005</asp:ListItem>
                        <asp:ListItem Value="2006">2006</asp:ListItem>
                        <asp:ListItem Value="2007">2007</asp:ListItem>
                        <asp:ListItem Value="2008">2008</asp:ListItem>
                        <asp:ListItem Value="2009">2009</asp:ListItem>
                        <asp:ListItem Value="2010">2010</asp:ListItem>
                        <asp:ListItem Value="2011">2011</asp:ListItem>
                        <asp:ListItem Value="2012">2012</asp:ListItem>
                        <asp:ListItem Value="2013">2013</asp:ListItem>
                        <asp:ListItem Value="2014">2014</asp:ListItem>
                        <asp:ListItem Value="2015">2015</asp:ListItem>
                    </asp:DropDownList>
                </font>
            </td>
            <td style="width: 9px">
                －
            </td>
            <td style="width: 83px">
                <font face="宋体">
                    <asp:DropDownList ID="ddlEndYear" runat="server" Width="64px">
                        <asp:ListItem Value="2005">2005</asp:ListItem>
                        <asp:ListItem Value="2006">2006</asp:ListItem>
                        <asp:ListItem Value="2007">2007</asp:ListItem>
                        <asp:ListItem Value="2008">2008</asp:ListItem>
                        <asp:ListItem Value="2009">2009</asp:ListItem>
                        <asp:ListItem Value="2010">2010</asp:ListItem>
                        <asp:ListItem Value="2011">2011</asp:ListItem>
                        <asp:ListItem Value="2012">2012</asp:ListItem>
                        <asp:ListItem Value="2013">2013</asp:ListItem>
                        <asp:ListItem Value="2014">2014</asp:ListItem>
                        <asp:ListItem Value="2015">2015</asp:ListItem>
                    </asp:DropDownList>
                </font>
            </td>
            <td style="width: 58px">
                <font face="宋体">月份：</font>
            </td>
            <td style="width: 46px">
                <font face="宋体">
                    <asp:DropDownList ID="ddlStartMonth" runat="server" Width="50px">
                        <asp:ListItem Value="1">1</asp:ListItem>
                        <asp:ListItem Value="2">2</asp:ListItem>
                        <asp:ListItem Value="3">3</asp:ListItem>
                        <asp:ListItem Value="4">4</asp:ListItem>
                        <asp:ListItem Value="5">5</asp:ListItem>
                        <asp:ListItem Value="6">6</asp:ListItem>
                        <asp:ListItem Value="7">7</asp:ListItem>
                        <asp:ListItem Value="8">8</asp:ListItem>
                        <asp:ListItem Value="9">9</asp:ListItem>
                        <asp:ListItem Value="10">10</asp:ListItem>
                        <asp:ListItem Value="11">11</asp:ListItem>
                        <asp:ListItem Value="12">12</asp:ListItem>
                    </asp:DropDownList>
                </font>
            </td>
            <td>
                －
            </td>
            <td style="width: 58px">
                <asp:DropDownList ID="ddlEndMonth" runat="server" Width="50px">
                    <asp:ListItem Value="1">1</asp:ListItem>
                    <asp:ListItem Value="2">2</asp:ListItem>
                    <asp:ListItem Value="3">3</asp:ListItem>
                    <asp:ListItem Value="4">4</asp:ListItem>
                    <asp:ListItem Value="5">5</asp:ListItem>
                    <asp:ListItem Value="6">6</asp:ListItem>
                    <asp:ListItem Value="7">7</asp:ListItem>
                    <asp:ListItem Value="8">8</asp:ListItem>
                    <asp:ListItem Value="9">9</asp:ListItem>
                    <asp:ListItem Value="10">10</asp:ListItem>
                    <asp:ListItem Value="11">11</asp:ListItem>
                    <asp:ListItem Value="12">12</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <font face="宋体">
                    <asp:Button ID="btnQuery" runat="server" Text="确定"></asp:Button></font>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>

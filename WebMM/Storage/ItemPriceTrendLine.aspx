<%@ Page Language="c#" CodeBehind="ItemPriceTrendLine.aspx.cs" AutoEventWireup="True"
    MasterPageFile="~/Master/Default.Master" Inherits="MZHMM.WebMM.Storage.ItemPriceTrendLine" %>

<%@ MasterType VirtualPath="~/Master/Default.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>ItemPriceTrendLine</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="AjaxHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BodyHolder" runat="server">
    <table class="managertable">
        <tr>
            <td class="td_Chart" colspan="5">
                <dcwc:Chart ID="Chart1" runat="server" Palette="Pastel" BorderLineColor="LightSlateGray"
                    BackColor="LightSteelBlue" Width="550px">
                    <Legends>
                        <dcwc:Legend LegendStyle="Row" Enabled="False" BorderColor="Gray" DockToChartArea="Default"
                            Docking="Bottom" Name="Default" BackColor="Lavender" Alignment="Center" ShadowOffset="2">
                        </dcwc:Legend>
                    </Legends>
                    <Series>
                        <dcwc:Series ShowLabelAsValue="True" MarkerBorderColor="RosyBrown" MarkerSize="8"
                            XValueType="String" ChartType="Spline" MarkerStyle="Circle" Name="Default" BorderColor="64, 64, 64"
                            ShadowOffset="1" YValueType="Double">
                        </dcwc:Series>
                        <dcwc:Series ChartType="Line" Name="Average">
                        </dcwc:Series>
                    </Series>
                    <ChartAreas>
                        <dcwc:ChartArea Name="Default" BorderColor="" ShadowOffset="2" BackColor="Lavender">
                            <AxisY TitleAlignment="Far" LabelsAutoFit="False">
                                <LabelStyle Format="N2"></LabelStyle>
                                <MajorGrid LineStyle="Dash" LineColor="LightSteelBlue"></MajorGrid>
                            </AxisY>
                            <AxisX Margin="False" TitleAlignment="Far" LabelsAutoFit="False">
                                <LabelStyle FontAngle="90"></LabelStyle>
                                <MajorGrid LineStyle="Dash" LineColor="LightSteelBlue"></MajorGrid>
                            </AxisX>
                        </dcwc:ChartArea>
                    </ChartAreas>
                    <Titles>
                        <dcwc:Title Font="Microsoft Sans Serif, 14.25pt, style=Bold" Text="价格走势图">
                        </dcwc:Title>
                    </Titles>
                    <BorderSkin FrameBackColor="SteelBlue" FrameBackGradientEndColor="LightBlue" SkinStyle="Emboss">
                    </BorderSkin>
                </dcwc:Chart>
            </td>
        </tr>
        <tr>
            <td>
                开始日期：
            </td>
            <td>
                <mzh:ToolbarCalendar ID="txtStartDate" ReadOnly="true" runat="server" />
            </td>
            <td>
                结束日期：
            </td>
            <td>
                <mzh:ToolbarCalendar ID="txtEndDate" ReadOnly="true" runat="server" />
            </td>
            <td>
                <asp:Button ID="btnYes" runat="server" Text="确定" OnClick="btnYes_Click"></asp:Button>
            </td>
        </tr>
        <tr>
            <td colspan="5">
                <mzh:MzhDataGrid ID="MzhDataGrid1" runat="server" name="MzhMultiSelectDataGrid" SelectType="SingleSelect"
                    IdCell="0" AutoGenerateColumns="False" 
                    >
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
                    <Columns>
                        <asp:BoundColumn DataField="PrvName" HeaderText="供应商">
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Date" HeaderText="日期">
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="AveragePrice" HeaderText="前期价格">
                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="ItemPrice" HeaderText="价格">
                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
                        </asp:BoundColumn>
                    </Columns>
                </mzh:MzhDataGrid>
            </td>
        </tr>
    </table>
</asp:Content>

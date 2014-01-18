<%@ Page Language="c#" CodeBehind="YJ.aspx.cs" MasterPageFile="~/Master/Default.Master"
    AutoEventWireup="True" Inherits="WebMM.Storage.YJ" %>

<%@ MasterType VirtualPath="~/Master/Default.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>YJ</title>
    <link href="../CSS/ManageCommon.css" type="text/css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="AjaxHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BodyHolder" runat="server">
    <table cellspacing="5" class="managertable">
        <tr class="managertr">
            <td align="left">
                <asp:Label ID="Label1" CssClass="label_selectDate" runat="server">请指定需要月结的年月：</asp:Label>
            </td>
        </tr>
        <tr >
            <td>
            </td>
        </tr>
        <tr class="managertr">
            <td align="left">
                <asp:Label ID="Label2" CssClass="label_selectYear" runat="server">年份：</asp:Label>
                <asp:DropDownList ID="ddlYear" CssClass="select_ddlYear" runat="server">
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
            </td>
        </tr>
        <tr class="managertr">
            <td align="left">
                <asp:Label ID="Label3" CssClass="label_selectMonth" runat="server">月份：</asp:Label>
                <asp:DropDownList ID="ddlMonth" CssClass="select_ddlMonth" runat="server">
                    <asp:ListItem Value="1">01</asp:ListItem>
                    <asp:ListItem Value="2">02</asp:ListItem>
                    <asp:ListItem Value="3">03</asp:ListItem>
                    <asp:ListItem Value="4">04</asp:ListItem>
                    <asp:ListItem Value="5">05</asp:ListItem>
                    <asp:ListItem Value="6">06</asp:ListItem>
                    <asp:ListItem Value="7">07</asp:ListItem>
                    <asp:ListItem Value="8">08</asp:ListItem>
                    <asp:ListItem Value="9">09</asp:ListItem>
                    <asp:ListItem Value="10">10</asp:ListItem>
                    <asp:ListItem Value="11">11</asp:ListItem>
                    <asp:ListItem Value="12">12</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr class="managertr">
            <td align="left">
                <asp:Button ID="btnYJ" runat="server" Text="月结"  OnClick="btnYJ_Click"></asp:Button>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblReturn" CssClass="label_Return" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>

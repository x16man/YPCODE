<%@ Page Language="c#" CodeBehind="YJBaocun.aspx.cs" AutoEventWireup="True" MasterPageFile="~/Master/Default.Master"
    Inherits="WebMM.Storage.YJBaocun" %>

<%@ MasterType VirtualPath="~/Master/Default.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>YJBaocun</title>
    <link href="../CSS/ManageCommon.css" type="text/css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="AjaxHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BodyHolder" runat="server">
    <table cellspacing="5" class="managertable">
        <tr class="managertr">
            <td align="left">
                <asp:Label ID="Label2"  runat="server">请指定需要归结的年月：</asp:Label>
            </td>
        </tr>
        <tr>
            <td>
            </td>
        </tr>
        <tr class="managertr">
            <td align="left">
                请选择年份:<asp:DropDownList ID="drplYear" runat="server" Width="72px">
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
                请选择月份:<asp:DropDownList ID="drpMonth" runat="server" Width="56px" Height="24px">
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
            <asp:Button ID="AddYj" runat="server" Width="100px" Height="22px" Text="完 全 保 存" OnClick="AddYj_Click">
                    </asp:Button>
                    &nbsp;&nbsp;
               <asp:Button ID="AddYj_Km1NoNull" runat="server" Width="100px" Height="22px" 
                    Text="增 量 保 存" onclick="AddYj_Km1NoNull_Click" >
                    </asp:Button>
                    
                    
                    
            </td>
        </tr>
    </table>
    <asp:Label ID="Label1" Style="z-index: 102; left: 16px; position: absolute; top: 72px"
        runat="server" Width="488px"></asp:Label>
</asp:Content>

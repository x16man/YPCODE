<%@ Page Language="c#" CodeBehind="ConChooser.aspx.cs" MasterPageFile="~/Master/Default.Master"
    AutoEventWireup="True" Inherits="MZHMM.WebMM.Storage.ConChooser" %>

<%@ MasterType VirtualPath="~/Master/Default.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>���ϼ�λѡ��</title>
    <link href="../CSS/StyleSheet.css" type="text/css" rel="stylesheet"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="AjaxHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BodyHolder" runat="server">
    <table id="Table1" cellspacing="0" cellpadding="0" width="98%" align="center" border="0">
        <tr>
            <td style="border-right: #ffcc33 1px solid; border-top: #ffcc33 1px solid; border-left: #ffcc33 1px solid;
                border-bottom: #ffcc33 1px solid; background-color: #ffffcc" height="25">
                &nbsp;�ֿⷢ�ϼ�λѡ��
            </td>
        </tr>
        <tr>
            <td>
                <u><font color="#0000ff">
                    <uc1:ConChooserWebControl ID="UCStockChoice" runat="server"></uc1:ConChooserWebControl>
                </font></u>
            </td>
        </tr>
        <tr>
            <td style="border-right: #ffcc33 1px solid; border-top: #ffcc33 1px solid; border-left: #ffcc33 1px solid;
                border-bottom: #ffcc33 1px solid; background-color: #ffffcc" height="25">
                <p align="center">
                    &nbsp;
                    <asp:HiddenField ID="Textbox1" runat="server" />
                    <asp:Button ID="btnYes" runat="server" Text="ȷ��" OnClick="btnYes_Click"></asp:Button>
                    &nbsp;&nbsp;&nbsp;<asp:Button ID="btnCancel" runat="server" Text="ȡ��" OnClick="btnCancel_Click">
                    </asp:Button></p>
            </td>
        </tr>
    </table>
    
    
</asp:Content>

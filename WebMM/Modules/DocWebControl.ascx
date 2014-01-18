<%@ Control Language="c#" AutoEventWireup="True" CodeBehind="DocWebControl.ascx.cs"
    Inherits="MZHMM.WebMM.Modules.DocWebControl" %>
<%@ Register TagPrefix="uc1" TagName="StorageDropdownlistview" Src="StorageDropdownlist.ascx" %>
<table id="Table1" cellspacing="0" cellpadding="0" width="100%" border="0">
    <tr>
        <td valign="top" align="center" width="220px" rowspan="2">
            <img alt="" src="../Images/ypwater.gif" />
        </td>
        <td valign="middle" align="center">
            <p align="center" >
                <asp:Label ID="lblTitle" runat="server" Font-Names="楷体_GB2312" Font-Size="Large"
                    Font-Bold="True"></asp:Label></p>
        </td>
        <td width="220px">
            <p align="right">
                <asp:Label ID="lblDocNo" runat="server"></asp:Label></p>
        </td>
    </tr>
    <tr>
        <td align="center">
            <asp:Label ID="lblDate" runat="server"></asp:Label>
            <table width="200px">
                <tr>
                    <td style="width: 35%" align="right">
                        <uc1:StorageDropdownlistview ID="ddlYear" runat="server" Visible="False"></uc1:StorageDropdownlistview>
                    </td>
                    <td style="width: 15%" align="left">
                        <asp:Label ID="lblYear" runat="server" Visible="False">年</asp:Label>
                    </td>
                    <td style="width: 35%" align="right">
                        <uc1:StorageDropdownlistview ID="ddlMonth" runat="server" Visible="False"></uc1:StorageDropdownlistview>
                    </td>
                    <td style="width: 15%" align="left">
                        <asp:Label ID="lblMonth" runat="server" Visible="False">月</asp:Label>
                    </td>
                </tr>
            </table>
        </td>
        <td>
            <p align="right">
                <asp:Label ID="Label1" runat="server">单据编号:</asp:Label><asp:Label ID="lblEntryCode"
                    runat="server"></asp:Label></p>
        </td>
    </tr>
</table>
<asp:HiddenField ID="txtDocCode" runat="server" />
<asp:HiddenField ID="txtEntryNo" runat="server" />

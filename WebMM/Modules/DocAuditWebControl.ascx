<%@ Control Language="c#" AutoEventWireup="True" CodeBehind="DocAuditWebControl.ascx.cs"
    Inherits="MZHMM.WebMM.Modules.DocAuditWebControl" %>


<table id="Table1" cellspacing="0" cellpadding="0" width="100%" border="0">
    <tr>
        <td width="10%" >
            <asp:Label ID="lblAuditName1" runat="server"></asp:Label>
        </td>
        <td width="10%">
            <asp:Label ID="lblAuditor1" runat="server"></asp:Label>
        </td>
        <td width="10%">
            <asp:RadioButtonList ID="rblAudit1" runat="server" Enabled="False" RepeatDirection="Horizontal">
                <asp:ListItem Value="Y">通过</asp:ListItem>
                <asp:ListItem Value="N">不通过</asp:ListItem>
            </asp:RadioButtonList>
        </td>
        <td width="10%">
            <asp:Label ID="lblAuditSuggest1" runat="server">意见：</asp:Label>
        </td>
        <td width="">
            <asp:TextBox ID="txtAuditSuggest1" runat="server" Enabled="False"></asp:TextBox>
        </td>
        <td width="10%" style="text-align:center;">
            <asp:Label ID="lblAuditDate1" runat="server">日期：</asp:Label>
        </td>
        <td width="10%">
            <asp:TextBox ID="txtAuditDate1" runat="server" ReadOnly="True"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="lblAuditName4" runat="server"></asp:Label>
        </td>
        <td>
            <asp:Label ID="lblAuditor4" runat="server"></asp:Label>
        </td>
        <td>
            <asp:RadioButtonList ID="rblAudit4" runat="server" Enabled="False" RepeatDirection="Horizontal">
                <asp:ListItem Value="Y">通过</asp:ListItem>
                <asp:ListItem Value="N">不通过</asp:ListItem>
            </asp:RadioButtonList>
        </td>
        <td>
            <asp:Label ID="lblAuditSuggest4" runat="server">意见：</asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtAuditSuggest4" runat="server" Enabled="False"  
                ></asp:TextBox>
        </td>
        <td style="text-align:center;">
            <asp:Label ID="lblAuditDate4" runat="server">日期：</asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtAuditDate4" runat="server"  ReadOnly="True"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="width:10%">
            <asp:Label ID="lblAuditName2" runat="server"></asp:Label>
        </td>
        <td style="width:10%">
            <asp:Label ID="lblAuditor2" runat="server"></asp:Label>
        </td>
        <td style="width:20%">
            <asp:RadioButtonList ID="rblAudit2" runat="server" Enabled="False" RepeatDirection="Horizontal">
                <asp:ListItem Value="Y">通过</asp:ListItem>
                <asp:ListItem Value="N">不通过</asp:ListItem>
            </asp:RadioButtonList>
        </td>
        <td style="width:10%">
            <asp:Label ID="lblAuditSuggest2" runat="server">意见：</asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtAuditSuggest2" runat="server" Enabled="False"  
                ></asp:TextBox>
        </td>
        <td style="width:10%;text-align:center;">
            <asp:Label ID="lblAuditDate2" runat="server">日期：</asp:Label>
        </td>
        <td style="width:20%">
            <asp:TextBox ID="txtAuditDate2" runat="server" ReadOnly="True"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="lblAuditName3" runat="server"></asp:Label>
        </td>
        <td>
            <asp:Label ID="lblAuditor3" runat="server"></asp:Label>
        </td>
        <td>
            <asp:RadioButtonList ID="rblAudit3" runat="server" Enabled="False" RepeatDirection="Horizontal">
                <asp:ListItem Value="Y">通过</asp:ListItem>
                <asp:ListItem Value="N">不通过</asp:ListItem>
            </asp:RadioButtonList>
        </td>
        <td>
            <asp:Label ID="lblAuditSuggest3" runat="server">意见：</asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtAuditSuggest3" runat="server" Enabled="False"  
                ></asp:TextBox>
        </td>
        <td style="text-align:center;">
            <asp:Label ID="lblAuditDate3" runat="server">日期：</asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtAuditDate3" runat="server"  ReadOnly="True"></asp:TextBox>
        </td>
    </tr>
    
</table>

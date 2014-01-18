<%@ Control Language="c#" AutoEventWireup="True" CodeBehind="BRBWebControl.ascx.cs"
    Inherits="MZHMM.WebMM.Modules.BRBWebControl" %>
<table id="Table2" cellspacing="1" cellpadding="1" width="100%" border="0">
    <tr>
        <td width="14%" valign="middle">
            <asp:TextBox ID="txtShipNo" ToolTip="船名" runat="server" Width="100%"></asp:TextBox>
        </td>
        <td width="14%">
            <asp:TextBox ID="txtStartTime" runat="server" Width="100%" ToolTip="开工时间"></asp:TextBox>
        </td>
        <td width="14%">
            <asp:TextBox ID="txtEndTime" runat="server" Width="100%" ToolTip="完工时间"></asp:TextBox>
        </td>
        <td width="14%">
            <asp:TextBox ID="txtImportTime" ToolTip="进港时间" runat="server" Width="100%"></asp:TextBox>
        </td>
        <td width="14%">
            <asp:TextBox ID="txtExportTime" runat="server" Width="100%" ToolTip="出港时间"></asp:TextBox>
        </td>
        <td width="14%">
            <asp:TextBox ID="txtStartVolumn" runat="server" Width="100%" ToolTip="抽驳前液位"></asp:TextBox>
        </td>
        <td width="14%">
            <asp:TextBox ID="txtEndVolumn" ToolTip="抽驳后液位" runat="server" Width="100%"></asp:TextBox>
        </td>
        <td>
            <asp:Button ID="btnAddItem" TabIndex="50" runat="server" Text="新增" OnClick="btnAddItem_Click">
            </asp:Button><asp:Button ID="btnDelItem" TabIndex="40" runat="server" OnClientClick="if(!confirm('真的删除吗?')){return false;}"
                Text="删除" OnClick="btnDelItem_Click"></asp:Button><asp:Button ID="btnEditItem" TabIndex="40"
                    runat="server" Text="编辑" OnClick="btnEdit_Click"></asp:Button>
        </td>
    </tr>
    <tr>
        <td valign="top" colspan="8" height="160">
            <uc1:DGModel_Items ID="DGModel_Items1" runat="server"></uc1:DGModel_Items>
        </td>
    </tr>
</table>
<div class="hidden">
    <input id="txtItemSerial" type="hidden" value="-1" name="Hidden1" runat="server">
    <asp:TextBox ID="txtConCode" Width="0px" runat="server"></asp:TextBox>
    <asp:Button ID="btnForItemCode" runat="server" Width="0px" Text="Button" Height="0"
        OnClick="btnForItemCode_Click"></asp:Button>
</div>

<%@ Control Language="c#" AutoEventWireup="True" CodeBehind="BRBWebControl.ascx.cs"
    Inherits="MZHMM.WebMM.Modules.BRBWebControl" %>
<table id="Table2" cellspacing="1" cellpadding="1" width="100%" border="0">
    <tr>
        <td width="14%" valign="middle">
            <asp:TextBox ID="txtShipNo" ToolTip="����" runat="server" Width="100%"></asp:TextBox>
        </td>
        <td width="14%">
            <asp:TextBox ID="txtStartTime" runat="server" Width="100%" ToolTip="����ʱ��"></asp:TextBox>
        </td>
        <td width="14%">
            <asp:TextBox ID="txtEndTime" runat="server" Width="100%" ToolTip="�깤ʱ��"></asp:TextBox>
        </td>
        <td width="14%">
            <asp:TextBox ID="txtImportTime" ToolTip="����ʱ��" runat="server" Width="100%"></asp:TextBox>
        </td>
        <td width="14%">
            <asp:TextBox ID="txtExportTime" runat="server" Width="100%" ToolTip="����ʱ��"></asp:TextBox>
        </td>
        <td width="14%">
            <asp:TextBox ID="txtStartVolumn" runat="server" Width="100%" ToolTip="�鲵ǰҺλ"></asp:TextBox>
        </td>
        <td width="14%">
            <asp:TextBox ID="txtEndVolumn" ToolTip="�鲵��Һλ" runat="server" Width="100%"></asp:TextBox>
        </td>
        <td>
            <asp:Button ID="btnAddItem" TabIndex="50" runat="server" Text="����" OnClick="btnAddItem_Click">
            </asp:Button><asp:Button ID="btnDelItem" TabIndex="40" runat="server" OnClientClick="if(!confirm('���ɾ����?')){return false;}"
                Text="ɾ��" OnClick="btnDelItem_Click"></asp:Button><asp:Button ID="btnEditItem" TabIndex="40"
                    runat="server" Text="�༭" OnClick="btnEdit_Click"></asp:Button>
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

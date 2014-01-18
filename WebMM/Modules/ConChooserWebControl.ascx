<%@ Control Language="c#" AutoEventWireup="True" CodeBehind="ConChooserWebControl.ascx.cs"
    Inherits="MZHMM.WebMM.Modules.ConChooserWebControl" %>
<table id="Table2" cellspacing="1" cellpadding="1" width="100%" border="0">
    <tr>
        <td width="100">
            <asp:TextBox ID="txtItemCode" runat="server"  SkinID="PurposeTable" ReadOnly="True"></asp:TextBox>
        </td>
        <td width="120">
            <asp:TextBox ID="txtItemName" runat="server" SkinID="PurposeTable" ReadOnly="True"></asp:TextBox>
        </td>
        <td width="120">
            <asp:TextBox ID="txtItemSpecial" runat="server" SkinID="PurposeTable" ReadOnly="True"></asp:TextBox>
        </td>
        <td width="50">
            <asp:TextBox ID="txtUnit" runat="server" SkinID="PurposeTable" ReadOnly="True"></asp:TextBox>
        </td>
        <td width="60">
            <asp:TextBox ID="txtStockNum" runat="server" SkinID="PurposeTable" ReadOnly="True"></asp:TextBox>
        </td>
        <td width="50">
            <asp:TextBox ID="txtItemNum" runat="server" SkinID="PurposeTable"></asp:TextBox>
        </td>
        <td width="80">
            <asp:TextBox ID="txtCon" runat="server" SkinID="PurposeTable" ReadOnly="True"></asp:TextBox>
        </td>
        <td width="70">
            <asp:TextBox ID="txtAcceptDate" runat="server" SkinID="PurposeTable" ReadOnly="True"></asp:TextBox>
        </td>
        <td>
            <asp:Button ID="btnAddItem" TabIndex="50" runat="server" Text="����" Enabled="False"
                OnClick="btnAddItem_Click"></asp:Button>
            <asp:Button ID="btnEditItem" TabIndex="40" runat="server" Text="�༭" OnClick="btnEdit_Click">
            </asp:Button>
        </td>
    </tr>
    <tr>
        <td valign="top" colspan="9" height="160">
            <mzh:MzhDataGrid ID="DGModel_Items1" runat="server" IdCell="0" MultiPageShowMode="DropListMode"
                AllowPaging="false" AllowSorting="false" ShowFooter="false" selecttype="SingleSelect"
                name="MzhMultiSelectDataGrid" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundColumn DataField="PKID" SortExpression="PKID" Visible="false"></asp:BoundColumn>
                    <asp:BoundColumn DataField="EntryNo" SortExpression="EntryNo" HeaderText="���ݺ�"></asp:BoundColumn>
                    <asp:BoundColumn DataField="DocName" SortExpression="DocName" HeaderText="��������"></asp:BoundColumn>
                    <asp:BoundColumn DataField="PrvName" SortExpression="PrvName" HeaderText = "��Ӧ��"></asp:BoundColumn>
                    <asp:BoundColumn DataField="ItemCode" SortExpression="ItemCode" HeaderText="���ϱ��">
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="ItemName" SortExpression="ItemName" HeaderText="��������">
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="ItemSpecial" SortExpression="ItemSpecial" HeaderText="����ͺ�">
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="ItemUnitName" SortExpression="ItemUnitName" HeaderText="������λ">
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="StockNum" SortExpression="StockNum" HeaderText="�����">
                        
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="ItemNum" SortExpression="ItemNum" HeaderText="ʵ����"></asp:BoundColumn>
                    <asp:BoundColumn DataField="ConName" SortExpression="ConName" HeaderText="��λ"></asp:BoundColumn>
                    <asp:BoundColumn DataField="AcceptDate" SortExpression="AcceptDate" HeaderText="��������">
                    </asp:BoundColumn>
                </Columns>
            </mzh:MzhDataGrid>
        </td>
    </tr>
</table>

<div class="hidden"><asp:HiddenField ID="txtPKIDs" runat="server" />
<asp:Button ID="btnForItemCode" runat="server" Text="Button"  CssClass="hidden"></asp:Button>
<asp:Button ID="btnForPKID" runat="server" Text="Button"  CssClass="hidden"></asp:Button><asp:HiddenField ID="txtItemSerial" runat="server" Value="-1" />
</div>


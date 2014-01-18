<%@ Page Language="c#" CodeBehind="CategroyDetails.aspx.cs" Title="���Ϸ�����ϸ��Ϣ" AutoEventWireup="True"
    MasterPageFile="~/Master/Default.Master" Inherits="MZHMM.WebMM.Storage.CategroyDetails" %>

<%@ MasterType VirtualPath="~/Master/Default.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>���Ϸ�����ϸ��Ϣ</title>
    <link href="../CSS/ManageCommon.css" type="text/css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="AjaxHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BodyHolder" runat="server">
    <table class="managertable" border="1">
        <tr class="managertr">
            <td class="titletd">
                ������
            </td>
            <td class="contenttd">
                <asp:Label ID="txtCode" runat="server" ToolTip="������(1-32767),�����ظ�"></asp:Label>
            </td>
            <td class="titletd">
                ��ʾ˳��
            </td>
            <td class="contenttd">
                <asp:Label ID="txtSerial" runat="server" ToolTip="��ʾ˳��(1-32767)"></asp:Label>
            </td>
        </tr>
        <tr class="managertr">
            <td>
                ��������
            </td>
            <td colspan="3" align="left">
                <asp:Label ID="txtDescription" runat="server" ToolTip="�������������"></asp:Label>
            </td>
        </tr>
        <tr class="managertr">
            <td>
                ����Ŀ
            </td>
            <td colspan="3" align="left">
                <asp:Label ID="txtStorageAcc" runat="server"></asp:Label>
            </td>
        </tr>
        <tr class="managertr">
            <td>
                ת�ʿ�Ŀ
            </td>
            <td colspan="3" align="left">
                <asp:Label ID="txtTransferAcc" runat="server"></asp:Label>
            </td>
        </tr>
        <tr class="managertr">
            <td>
                �˻���Ŀ
            </td>
            <td colspan="3" align="left">
                <asp:Label ID="txtReturnAcc" runat="server"></asp:Label>
            </td>
        </tr>
        <tr class="managertr">
            <td>
                ��ע
            </td>
            <td colspan="3" align="left">
                <asp:Label ID="txtRemark" runat="server" ></asp:Label>
            </td>
        </tr>
        <tr class="managertr">
            <td colspan="4">
                <asp:Button ID="btnClose" runat="server" Text="�ر�" OnClientClick="window.close();" />
            </td>
        </tr>
        <tr class="managertr">
            <td colspan="4">
            </td>
        </tr>
    </table>
</asp:Content>

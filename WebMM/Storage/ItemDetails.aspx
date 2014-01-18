<%@ Page Language="c#" CodeBehind="ItemDetails.aspx.cs" Title="������Ϣ" MasterPageFile="~/Master/Default.Master"
    AutoEventWireup="True" Inherits="MZHMM.WebMM.ItemDetails" %>

<%@ MasterType VirtualPath="~/Master/Default.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../CSS/ManageCommon.css" type="text/css" rel="stylesheet" />
    <title>������Ϣ</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="AjaxHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BodyHolder" runat="server">
    <table class="managertable" border="1" >
        <tr class="managertr">
            <td  class="titletd">
                ���ϱ��
            </td>
            <td class="contenttd">
                <asp:TextBox ID="txtCode" runat="server" CssClass="input_txtCode input" MaxLength="20"
                    ReadOnly="True"></asp:TextBox>
            </td>
            <td  class="titletd">
                �±��
            </td>
            <td class="contenttd">
                <asp:TextBox ID="txtNewCode" runat="server" CssClass="input_txtCode input" MaxLength="20"
                    ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
        <tr class="managertr">
            <td class="titletd">
                ���Ϸ���
            </td>
            <td class="contenttd">
                <asp:TextBox ID="txtCategory" runat="server" CssClass="input_txtCategory input" ReadOnly="True"></asp:TextBox>
            </td>
            <td >
                ��������
            </td>
            <td align="left">
                <asp:TextBox ID="txtCnName" runat="server" CssClass="input_txtCnName input" ToolTip="��������������"
                    MaxLength="50" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
        <tr class="managertr">
            <td >
                Ӣ������
            </td>
            <td align="left">
                <asp:TextBox ID="txtEnName" runat="server" CssClass="input_txtEnName input" MaxLength="50"
                    ReadOnly="True"></asp:TextBox>
            </td>
            <td >
                ����״̬
            </td>
            <td align="left">
                <asp:TextBox ID="txtItemState" runat="server" CssClass="input_txtItemState input" ReadOnly="true"
                   ></asp:TextBox>
                    <uc1:StorageDropdownlist ID="ddlItemState" Visible="false" runat="server"></uc1:StorageDropdownlist>
            </td>
        </tr>
        <tr class="managertr">
            <td>
                ����ͺ�
            </td>
            <td align="left">
                <asp:TextBox ID="txtSpecial" runat="server" CssClass="input_txtSpecial input" MaxLength="30"
                    ReadOnly="True"></asp:TextBox>
            </td>
            <td>
                ������λ
            </td>
            <td align="left">
                <asp:TextBox ID="txtUnit" runat="server" CssClass="input_txtUnit input" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
        <tr class="managertr">
            <td>
                �ƹ�����
            </td>
            <td align="left">
                <asp:TextBox ID="txtPurMak" runat="server" CssClass="input_txtPurMak input" ReadOnly="True"></asp:TextBox>
                <uc1:StorageDropdownlist ID="ddlPurMak" Visible="false" runat="server"></uc1:StorageDropdownlist>
            </td>
            <td>
                ���Ÿ���
            </td>
            <td align="left">
                <asp:TextBox ID="txtIsBatch" runat="server" CssClass="input_txtIsBatch input" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
        <tr class="managertr">
            <td>
                �Ƿ����
            </td>
            <td align="left">
                <asp:TextBox ID="txtIsCheck" runat="server" CssClass="input_txtIsCheck input" ReadOnly="True"></asp:TextBox>
            </td>
            <td>
                ���鱨��
            </td>
            <td align="left">
                <asp:TextBox ID="txtCheckReport" runat="server" CssClass="input_txtCheckReport input"
                    ReadOnly="True"></asp:TextBox>
                    <uc1:StorageDropdownlist ID="ddlCheckReport" Visible="false" runat="server"></uc1:StorageDropdownlist>
            </td>
        </tr>
        <tr class="managertr">
            <td>
                ABC����
            </td>
            <td align="left">
                <asp:TextBox ID="txtABC" runat="server" CssClass="input_txtABC input"></asp:TextBox>
                <uc1:StorageDropdownlist ID="ddlABC" runat="server" Visible="false"></uc1:StorageDropdownlist>
            </td>
            <td>
                �ɱ��۸�
            </td>
            <td align="left">
                <asp:TextBox ID="txtCstPrice" runat="server" CssClass="input_txtCstPrice input" MaxLength="10"></asp:TextBox>
            </td>
        </tr>
        <tr class="managertr">
            <td>
                �����۸�
            </td>
            <td align="left">
                <asp:TextBox ID="txtEvPrice" runat="server" CssClass="input_txtEvPrice input" MaxLength="10"
                    ReadOnly="True"></asp:TextBox>
            </td>
            <td>
                ���ʷ�ʽ
            </td>
            <td align="left">
                <asp:TextBox ID="txtAccount" runat="server" CssClass="input_txtAccount input" ReadOnly="True"></asp:TextBox>
                <uc1:StorageDropdownlist ID="ddlAccount" runat="server" Visible="false"></uc1:StorageDropdownlist>
            </td>
        </tr>
        <tr class="managertr">
            <td>
                ��ߴ���
            </td>
            <td align="left">
                <asp:TextBox ID="txtUppNum" runat="server" CssClass="input_txtUppNum input" MaxLength="10"
                    ReadOnly="True"></asp:TextBox>
            </td>
            <td>
                ��ʹ���
            </td>
            <td align="left">
                <asp:TextBox ID="txtLowNum" runat="server" CssClass="input_txtLowNum input" MaxLength="10"
                    ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
        <tr class="managertr">
            <td>
                ��ȫ����
            </td>
            <td align="left">
                <asp:TextBox ID="txtSafNum" runat="server" CssClass="input_txtSafNum input" MaxLength="10"
                    ReadOnly="True"></asp:TextBox>
            </td>
            <td>
                ������
            </td>
            <td align="left">
                <asp:TextBox ID="txtOrdNum" runat="server" CssClass="input_txtOrdNum input" MaxLength="10"
                    ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
        <tr class="managertr">
            <td>
                ��������
            </td>
            <td align="left">
                <asp:TextBox ID="txtBatch" runat="server" CssClass="input_txtBatch input" MaxLength="10"
                    ReadOnly="True"></asp:TextBox>
            </td>
            <td>
                ���湩Ӧ��
            </td>
            <td align="left">
                <asp:TextBox ID="txtProvider" runat="server" CssClass="input_txtProvider  input"
                    ReadOnly="True"></asp:TextBox>
                    <uc1:StorageDropdownlist ID="ddlProvider" Visible="false"  runat="server"></uc1:StorageDropdownlist>
            </td>
        </tr>
        <tr class="managertr">
            <td>
                ȱʡ��Ųֿ�
            </td>
            <td align="left">
                <asp:TextBox ID="txtStorage" runat="server" CssClass="input_txtStorag input" ReadOnly="True"></asp:TextBox>
            </td>
            <td>
                ȱʡ��ż�λ
            </td>
            <td align="left">
                <asp:TextBox ID="txtCon" runat="server" CssClass="input_txtCon input" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="4" align="center">
                <asp:Button ID="btnClose" Text="�ر�" runat="server" OnClientClick="window.close(); " />
            </td>
        </tr>
    </table>
</asp:Content>

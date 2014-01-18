<%@ Page Language="c#" CodeBehind="UnitInput.aspx.cs" Title="������λά��" MasterPageFile="~/Master/Default.Master"
    AutoEventWireup="True" Inherits="MZHMM.WebMM.Storage.UnitInput" %>

<%@ MasterType VirtualPath="~/Master/Default.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>������λά��</title>
    <link href="../CSS/ManageCommon.css" type="text/css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="AjaxHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BodyHolder" runat="server">
    <table class="managertable" border="1">
        <tr>
            <td colspan="4">
                <mzh:MzhToolbar ID="MzhToolbar1" runat="server" OnItemPostBack="MzhToolbar1_ItemPostBack">
                    <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable"
                        itemid="Edit" cellspacing="0" nakedlabelclass="nakedLabelCell" isshowtext="True"
                        iconclass="add" hasicon="True" text="����" id="toolbarButtonAdd" autopostback="True">
                    </mzh:toolbarbutton>
                    <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable"
                        itemid="Edit" cellspacing="0" nakedlabelclass="nakedLabelCell" isshowtext="True"
                        iconclass="edit" hasicon="True" text="����" id="toolbarButtonedit" autopostback="True">
                    </mzh:toolbarbutton>
                    <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable"
                        itemid="Edit" cellspacing="0" nakedlabelclass="nakedLabelCell" isshowtext="True"
                        iconclass="pre" hasicon="True" text="ȡ��" id="toolbarButtoncancel" onclick="document.location = 'UnitBrowser.aspx'">
                    </mzh:toolbarbutton>
                </mzh:MzhToolbar>
            </td>
        </tr>
        <tr class="managertr">
            <td class="titletd">
                <span class="required">*</span>��λ���
            </td>
            <td class="contenttd">
                <asp:TextBox ID="txtCode" runat="server" ToolTip="��λ���(1-32767),�����ظ�"></asp:TextBox><asp:RequiredFieldValidator
                    ID="RFVCode" runat="server" Display="Dynamic" ControlToValidate="txtCode" ErrorMessage="��λ��ű�������">��λ��ű�������</asp:RequiredFieldValidator><asp:RangeValidator
                        ID="RVCode" runat="server" Display="Dynamic" ControlToValidate="txtCode" ErrorMessage="���ַ�ΧΪ(1-32767)"
                        MinimumValue="1" MaximumValue="32767" Type="Integer">���ַ�ΧΪ(1-32767)</asp:RangeValidator>
            </td>
            <td class="titletd">
                <span class="required">*</span>��λ��д
            </td>
            <td class="contenttd">
                <asp:TextBox ID="txtAbbreviate" runat="server" ToolTip="��λ��д" MaxLength="5"></asp:TextBox><asp:RequiredFieldValidator
                    ID="RFVAbb" runat="server" Display="Dynamic" ControlToValidate="txtAbbreviate"
                    ErrorMessage="��λ��д��������">��λ��д��������</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr class="managertr">
            <td>
                <span class="required">*</span>��λ����
            </td>
            <td colspan="3" align="left">
                <asp:TextBox ID="txtDescription" runat="server" ToolTip="�����뵥λ����" MaxLength="10"></asp:TextBox><asp:RequiredFieldValidator
                    ID="RFVDes" runat="server" Display="Dynamic" ControlToValidate="txtDescription"
                    ErrorMessage="��λ���Ʊ�������">��λ���Ʊ�������</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr class="managertr">
            <td>
                ��λ��ֵ
            </td>
            <td colspan="3" align="left">
                <asp:TextBox ID="txtEquivalence" runat="server" MaxLength="20"></asp:TextBox><asp:RangeValidator
                    ID="RangeValidator1" runat="server" Display="Dynamic" ControlToValidate="txtEquivalence"
                    ErrorMessage="����Ϊ������" Type="Double" MaximumValue="9999999999999"
                    MinimumValue="-999999999999">����Ϊ-9999999999999��9999999999999������</asp:RangeValidator>
            </td>
        </tr>
        <tr class="managertr">
            <td>
                ����(�й�)
            </td>
            <td colspan="3" align="left">
                <asp:TextBox ID="txtConversion" runat="server" MaxLength="10"></asp:TextBox><asp:RangeValidator
                    ID="RangeValidator2" runat="server" Display="Dynamic" ControlToValidate="txtConversion"
                    ErrorMessage="����Ϊ������" Type="Double" MaximumValue="9999999999999999999999999999999999"
                    MinimumValue="-99999999999999999999999999999">����Ϊ������</asp:RangeValidator>
            </td>
        </tr>
        <tr class="managertr">
            <td>
                ���㵥λ
            </td>
            <td colspan="3" align="left">
                <asp:TextBox ID="txtConUnit" runat="server" MaxLength="20"></asp:TextBox>
            </td>
        </tr>
        <tr class="managertr">
            <td>
                ��λ����
            </td>
            <td colspan="3" align="left">
                <asp:DropDownList ID="DropDownList1" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr class="managertr">
            <td colspan="4">
            </td>
        </tr>
    </table>
    <div class="hidden">
        <asp:Button ID="refresh" runat="server" Text="Button"></asp:Button>
    </div>
</asp:Content>

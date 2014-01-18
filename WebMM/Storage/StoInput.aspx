<%@ Page Language="c#" CodeBehind="StoInput.aspx.cs" Title="�ֿ�ά��" MasterPageFile="~/Master/Default.Master"
    AutoEventWireup="True" Inherits="MZHMM.WebMM.Storage.StoInput" %>

<%@ MasterType VirtualPath="~/Master/Default.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>�ֿ�ά��</title>
    <link href="../CSS/ManageCommon.css" type="text/css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="AjaxHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BodyHolder" runat="server">
    <table border="1" class="managertable">
        <tr>
            <td colspan="2">
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
                        iconclass="pre" hasicon="True" text="ȡ��" id="toolbarButtoncancel" onclick="document.location = 'StoBrowser.aspx'">
                    </mzh:toolbarbutton>
                </mzh:MzhToolbar>
            </td>
        </tr>
        <tr class="managertr">
            <td class="titletd">
                <span class="required">*</span>�ֿ���
            </td>
            <td style="width: 80%" align="left">
                <asp:TextBox ID="txtCode" runat="server" MaxLength="2" ToolTip="�ֿ���(���2λ),�����ظ���"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RFVCode" runat="server" ErrorMessage="�ֿ��ű�������" ControlToValidate="txtCode"
                    Display="Dynamic">�ֿ��ű�������</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr class="managertr">
            <td>
               <span class="required">*</span> �ֿ�����
            </td>
            <td align="left">
                <asp:TextBox ID="txtDescription" runat="server" MaxLength="20" ToolTip="������ֿ�����"></asp:TextBox>
                <asp:HiddenField ID="OldDesc" runat="server" />
                <asp:RequiredFieldValidator ID="RFVDes" runat="server" ErrorMessage="�ֿ����Ʊ�������" ControlToValidate="txtDescription"
                    Display="Dynamic">�ֿ����Ʊ�������</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr class="managertr">
            <td>
                ����Ŀ
            </td>
            <td align="left">
                <asp:TextBox ID="txtStorageAcc" runat="server" MaxLength="20"></asp:TextBox>
            </td>
        </tr>
        <tr class="managertr">
            <td>
                ת�ʿ�Ŀ
            </td>
            <td align="left">
                <asp:TextBox ID="txtTransferAcc" runat="server" MaxLength="20"></asp:TextBox>
            </td>
        </tr>
        <tr class="managertr">
            <td>
                �˻���Ŀ
            </td>
            <td align="left">
                <asp:TextBox ID="txtReturnAcc" runat="server" MaxLength="20"></asp:TextBox>
            </td>
        </tr>
        <tr class="managertr">
            <td>
                ��ַ
            </td>
            <td align="left">
                <asp:TextBox ID="txtAddress" runat="server" MaxLength="50"></asp:TextBox>
            </td>
        </tr>
        <tr class="managertr">
            <td>
                ��ϵ��
            </td>
            <td align="left">
                <asp:TextBox ID="txtRelation" runat="server" MaxLength="20"></asp:TextBox>
            </td>
        </tr>
    </table>
    <div class="hidden">
        <asp:Button ID="refresh" runat="server" Text="Button"></asp:Button>
    </div>
</asp:Content>

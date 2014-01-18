<%@ Page Language="c#" CodeBehind="CategroyInput.aspx.cs" Title="���Ϸ���ά��" AutoEventWireup="True"
    MasterPageFile="~/Master/Default.Master" Inherits="MZHMM.WebMM.Storage.CategroyInput" %>

<%@ MasterType VirtualPath="~/Master/Default.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 <link href="../CSS/ManageCommon.css" type="text/css" rel="stylesheet" />
    <title>���Ϸ���ά��</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="AjaxHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BodyHolder" runat="server">
    <table class="managertable" border="1">
        <tr class="managertr">
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
                        iconclass="pre" hasicon="True" text="ȡ��" id="toolbarButtoncancel" onclick="document.location = 'CategroyBrowser.aspx'">
                    </mzh:toolbarbutton>
                </mzh:MzhToolbar>
            </td>
        </tr>
        <tr class="managertr">
            <td  class="titletd">
                <span class="required">*</span>������
            </td>
            <td class="contenttd">
                <asp:TextBox ID="txtCode" runat="server" ToolTip="������(1-99),�����ظ�" MaxLength="2"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RFVCode" runat="server" ErrorMessage="�����ű�������" ControlToValidate="txtCode"
                    Display="Dynamic">�����ű�������</asp:RequiredFieldValidator>
                <asp:RangeValidator ID="RVCode" runat="server" ErrorMessage="���ַ�ΧΪ(1-99)" Type="Integer"
                    ControlToValidate="txtCode" MaximumValue="32767" MinimumValue="1" Display="Dynamic">�ַ�ΧΪ(1-32767)</asp:RangeValidator>
            </td>
            <td class="titletd">
                <span class="required">*</span>��ʾ˳��
            </td>
            <td class="contenttd">
                <asp:TextBox ID="txtSerial" runat="server" ToolTip="��ʾ˳��(1-32767)"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RFVSerial" runat="server" ErrorMessage="��ʾ˳���������"
                    ControlToValidate="txtSerial" Display="Dynamic">��ʾ˳���������</asp:RequiredFieldValidator><asp:RangeValidator
                        ID="RVSerial" runat="server" ErrorMessage="���ַ�ΧΪ(1-32767)" Type="Integer" ControlToValidate="txtSerial"
                        MaximumValue="32767" MinimumValue="1" Display="Dynamic">���ַ�ΧΪ(1-32767)</asp:RangeValidator>
            </td>
        </tr>
        <tr class="managertr">
            <td>
                <span class="required">*</span>��������
            </td>
            <td colspan="3" align="left">
                <asp:TextBox ID="txtDescription" runat="server" MaxLength="30" ToolTip="�������������"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RFVDes" runat="server" ErrorMessage="�������Ʊ�������" ControlToValidate="txtDescription"
                    Display="Dynamic">�������Ʊ�������</asp:RequiredFieldValidator>
                  
            </td>
        </tr>
        <tr class="managertr">
            <td>
                ����Ŀ
            </td>
            <td colspan="3" align="left">
                <asp:TextBox ID="txtStorageAcc" runat="server" MaxLength="20"></asp:TextBox>
            </td>
        </tr>
        <tr class="managertr">
            <td>
                ת�ʿ�Ŀ
            </td>
            <td colspan="3" align="left">
                <asp:TextBox ID="txtTransferAcc" runat="server" MaxLength="20"></asp:TextBox>
            </td>
        </tr>
        <tr class="managertr">
            <td>
                �˻���Ŀ
            </td>
            <td colspan="3" align="left">
                <asp:TextBox ID="txtReturnAcc" runat="server" MaxLength="20"></asp:TextBox>
            </td>
        </tr>
        <tr class="managertr">
            <td>
                ��ע
            </td>
            <td colspan="3" align="left">
                <asp:TextBox ID="txtRemark" runat="server" TextMode="MultiLine" Rows="5" MaxLength="25"></asp:TextBox>
                  <asp:RegularExpressionValidator ID="RegularExpressionValidator1" Display="Dynamic" ControlToValidate="txtRemark"
                        runat="server" ValidationExpression="(\w|\W){1,25}" ErrorMessage="���������������ܴ���25" >
                        </asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr class="managertr">
            <td class="td_SubmitLine" colspan="4">
            </td>
        </tr>
    </table>
    <div class="hidden">
        <asp:Button ID="refresh" runat="server" Text="Button"></asp:Button>
       
        <asp:Button ID="btnCancel" runat="server" Text="ȡ��" CausesValidation="False" CssClass="button"
            onmouseover="this.className='buttonMouseOver'" onmouseout="this.className='button'"
            OnClick="btnCancel_Click"></asp:Button>
    </div>
</asp:Content>

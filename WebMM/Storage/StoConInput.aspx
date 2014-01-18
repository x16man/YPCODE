<%@ Page Language="c#" CodeBehind="StoConInput.aspx.cs" Title="�ֿ��λά��" AutoEventWireup="True" MasterPageFile="~/Master/Default.Master"
    Inherits="MZHMM.WebMM.Storage.StoConInput" %>

<%@ MasterType VirtualPath="~/Master/Default.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>�ֿ��λά��</title>
    <script language="javascript">
        function CancelGo() {
            
            var url = "StoConBrowser.aspx?StoCode=" + <%= StoCode%>;
          
            document.location =url;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="AjaxHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BodyHolder" runat="server">
    <table cellspacing="1" cellpadding="3" width="100%" border="1" style="word-break: break-all">
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
                        iconclass="pre" hasicon="True" text="ȡ��" id="toolbarButtoncancel" onclick="CancelGo()">
                    </mzh:toolbarbutton>
                </mzh:MzhToolbar>
            </td>
        </tr>
        <tr style="height: 25px">
            <td style="width: 20%">
                ��λ����<span class="required">*</span>
            </td>
            <td style="width: 30%" align="left">
                <asp:TextBox ID="txtDescription" runat="server" ToolTip="������ֿ��λ����" MaxLength="20"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RFVDes" runat="server" Display="Dynamic" ControlToValidate="txtDescription"
                    ErrorMessage="�ֿ��λ������������">�ֿ��λ��λ���Ʊ�������</asp:RequiredFieldValidator>
                <asp:HiddenField ID="txtCode" runat="server" />
            </td>
        </tr>
        <tr style="height: 25px">
            <td>
                �����ֿ���
            </td>
            <td align="left">
                <asp:TextBox ID="txtStoCode" runat="server" MaxLength="10" Enabled="False"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RFVStoCode" runat="server" Display="Dynamic" ControlToValidate="txtDescription"
                    ErrorMessage="�����ֿ��������">�����ֿ��������</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr style="height: 25px">
            <td>
                �ֿ����
            </td>
            <td align="left">
                <asp:TextBox ID="txtStoArea" runat="server" MaxLength="10"></asp:TextBox>
                <asp:RangeValidator ID="RangeValidator1" runat="server" Display="Dynamic" ControlToValidate="txtStoArea"
                    ErrorMessage="��λ���Ҫ��������" MinimumValue="0" MaximumValue="1000000000" Type="Double">��λ���Ҫ����0��1000000000֮������</asp:RangeValidator>
            </td>
        </tr>
        <tr style="height: 25px">
            <td class="td_Submit" colspan="4">
            </td>
        </tr>
    </table>
    <div class="hidden">
        <asp:Button ID="refresh" runat="server" Text="Button"></asp:Button>
        <asp:Button ID="btnSubmit" runat="server" Text="�ύ"></asp:Button>
        <asp:Button ID="btnCancel" runat="server" Text="ȡ��" CausesValidation="False" 
             OnClick="btnCancel_Click"></asp:Button>
    </div>
</asp:Content>

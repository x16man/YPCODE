<%@ Page Language="c#" CodeBehind="ItemInput.aspx.cs" Title="������Ϣά��" MasterPageFile="~/Master/Default.Master"
    AutoEventWireup="True" Inherits="MZHMM.WebMM.Storage.ItemInput" %>

<%@ MasterType VirtualPath="~/Master/Default.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>������Ϣά��</title>
    <link href="../CSS/ManageCommon.css" type="text/css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="AjaxHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BodyHolder" runat="server">
    <table class="managertable" border="1">
        <tr>
            <td colspan="4">
                <mzh:MzhToolbar ID="MzhToolbar1" runat="server" 
                    onitempostback="MzhToolbar1_ItemPostBack">
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
                        iconclass="pre" hasicon="True" text="ȡ��" id="toolbarButtoncancel" onclick="document.location = 'ItemBrowser.aspx'">
                    </mzh:toolbarbutton>
                </mzh:MzhToolbar>
            </td>
        </tr>
        <tr  class="managertr">
            <td class="titletd">
                <span class="required">*</span>���ϱ�ţ�
            </td>
            <td  class="contenttd">
                <asp:TextBox ID="txtCode" runat="server" MaxLength="20" style="width:50%"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RFVCode" runat="server" ErrorMessage="���ϱ�ű�������" ControlToValidate="txtCode"
                    Display="Dynamic">���ϱ�ű�������</asp:RequiredFieldValidator>
                <asp:Button ID="Button1" runat="server" Text="�Ƽ����" CausesValidation="False" 
                  
                    OnClick="Button1_Click"></asp:Button>
            </td>
            <td class="titletd">
                �±�ţ�
            </td>
            <td  class="contenttd">
                <asp:TextBox ID="txtNewCode" runat="server" MaxLength="50" style="width:50%"></asp:TextBox>
            </td>
        </tr>
        <tr  class="managertr">
            <td class="titletd">
                <span class="required">*</span>���Ϸ��ࣺ
            </td>
            <td class="contenttd">
                <uc1:StorageDropdownlist ID="ddlCategory" runat="server"></uc1:StorageDropdownlist>
            </td>
            <td>
                <span class="required">*</span>�������ƣ�
            </td>
            <td  align="left">
                <asp:TextBox ID="txtCnName" runat="server" MaxLength="30" ToolTip="��������������"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="�������Ʊ�������"
                    ControlToValidate="txtCnName">�������Ʊ�������</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr class="managertr">
            <td>
                Ӣ�����ƣ�
            </td>
            <td align="left">
                <asp:TextBox ID="txtEnName" runat="server" MaxLength="30"></asp:TextBox>
            </td>
            <td>
                ����״̬��
            </td>
            <td align="left">
                <uc1:StorageDropdownlist ID="ddlItemState" runat="server"></uc1:StorageDropdownlist>
            </td>
        </tr>
        <tr class="managertr">
            <td>
                ����ͺţ�
            </td>
            <td align="left">
                <asp:TextBox ID="txtSpecial" runat="server" MaxLength="30"></asp:TextBox>
            </td>
            <td>
                <span class="required">*</span>������λ��
            </td>
            <td align="left">
                <uc1:StorageDropdownlist ID="ddlUnit" runat="server"></uc1:StorageDropdownlist>
            </td>
        </tr>
        <tr class="managertr">
            <td>
                �ƹ����ԣ�
            </td>
            <td align="left">
                <uc1:StorageDropdownlist ID="ddlPurMak" runat="server"></uc1:StorageDropdownlist>
            </td>
            <td>
                ���Ÿ��٣�
            </td>
            <td align="left">
                <asp:RadioButtonList ID="rblBatch" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Value="Y">��</asp:ListItem>
                    <asp:ListItem Value="N" Selected="True">��</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr class="managertr">
            <td>
                �Ƿ���飺
            </td>
            <td align="left">
                <asp:RadioButtonList ID="rblCheck" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Value="Y" Selected="True">��</asp:ListItem>
                    <asp:ListItem Value="N">��</asp:ListItem>
                </asp:RadioButtonList>
            </td>
            <td>
                ���鱨�棺
            </td>
            <td align="left">
                <uc1:StorageDropdownlist ID="ddlCheckReport" runat="server"></uc1:StorageDropdownlist>
            </td>
        </tr>
        <tr class="managertr">
            <td>
                ABC���ࣺ
            </td>
            <td align="left">
                <uc1:StorageDropdownlist ID="ddlABC" runat="server"></uc1:StorageDropdownlist>
            </td>
            <td>
                �ɱ��۸�
            </td>
            <td align="left">
                <asp:TextBox ID="txtCstPrice" runat="server" MaxLength="10" ReadOnly="True"></asp:TextBox>
                <asp:RangeValidator ID="RangeValidator1" Display="Dynamic" runat="server" ErrorMessage="��������ӦΪ������"
                    ControlToValidate="txtCstPrice" MinimumValue="-99999999999999999" MaximumValue="9999999999999999999999999"
                    Type="Double">��������ӦΪ������</asp:RangeValidator>
            </td>
        </tr>
        <tr class="managertr">
            <td>
                �����۸�
            </td>
            <td align="left">
                <asp:TextBox ID="txtEvPrice" runat="server" MaxLength="10"></asp:TextBox><asp:RangeValidator
                    ID="RangeValidator2" runat="server" Display="Dynamic" ErrorMessage="��������ӦΪ������" ControlToValidate="txtEvPrice"
                    MinimumValue="-9999999999999999999999" MaximumValue="99999999999999999999999"
                    Type="Double">��������ӦΪ������</asp:RangeValidator>
            </td>
            <td>
                ���ʷ�ʽ��
            </td>
            <td align="left">
                <uc1:StorageDropdownlist ID="ddlAccount" runat="server"></uc1:StorageDropdownlist>
            </td>
        </tr>
        <tr class="managertr">
            <td>
                ��ߴ�����
            </td>
            <td align="left">
                <asp:TextBox ID="txtUppNum" runat="server" MaxLength="10"></asp:TextBox><asp:RangeValidator Display="Dynamic"
                    ID="RangeValidator3" runat="server" ErrorMessage="��������ӦΪ������" ControlToValidate="txtUppNum"
                    MinimumValue="-99999999999999999" MaximumValue="9999999999999999999999" Type="Double">��������ӦΪ������</asp:RangeValidator>
            </td>
            <td>
                ��ʹ�����
            </td>
            <td align="left">
                <asp:TextBox ID="txtLowNum" runat="server" MaxLength="10"></asp:TextBox><asp:RangeValidator
                    ID="RangeValidator7" runat="server" Display="Dynamic" ErrorMessage="��������ӦΪ������" ControlToValidate="txtLowNum"
                    MinimumValue="-999999999999999999999" MaximumValue="9999999999999999999999" Type="Double">��������ӦΪ������</asp:RangeValidator>
            </td>
        </tr>
        <tr class="managertr">
            <td>
                ��ȫ������
            </td>
            <td align="left">
                <asp:TextBox ID="txtSafNum" CssClass="input" runat="server" MaxLength="10"></asp:TextBox><asp:RangeValidator
                    ID="RangeValidator4" runat="server" Display="Dynamic" ErrorMessage="��������ӦΪ������" ControlToValidate="txtSafNum"
                    MinimumValue="-99999999999999999" MaximumValue="99999999999999999999999" Type="Double">��������ӦΪ������</asp:RangeValidator>
            </td>
            <td>
                �����㣺
            </td>
            <td align="left">
                <asp:TextBox ID="txtOrdNum" runat="server" MaxLength="10"></asp:TextBox><asp:RangeValidator
                    ID="RangeValidator6" runat="server" Display="Dynamic" ErrorMessage="��������ӦΪ������" ControlToValidate="txtOrdNum"
                    MinimumValue="-9999999999999999" MaximumValue="999999999999999999999999" Type="Double">��������ӦΪ������</asp:RangeValidator>
            </td>
        </tr>
        <tr class="managertr">
            <td>
                ����������
            </td>
            <td align="left"  valign="bottom">
                <asp:TextBox ID="txtBatch" runat="server" MaxLength="10"></asp:TextBox><asp:RangeValidator
                    ID="RangeValidator5" runat="server" Display="Dynamic" ErrorMessage="��������ӦΪ������" ControlToValidate="txtBatch"
                    MinimumValue="-99999999999999999" MaximumValue="9999999999999999999999" Type="Double">��������ӦΪ������</asp:RangeValidator>
            </td>
            <td >
                ���湩Ӧ�̣�
            </td>
            <td align="left">
                <uc1:StorageDropdownlist ID="ddlProvider" runat="server"></uc1:StorageDropdownlist>
            </td>
        </tr>
        <tr class="managertr">
            <td>
                <span class="required">*</span>��Ųֿ⣺
            </td>
            <td align="left">
                <uc1:StorageDropdownlist ID="ddlStorage" runat="server"  AutoPostBack="true"></uc1:StorageDropdownlist>
            </td>
            <td>
                ��ż�λ��
            </td>
            <td align="left">
                <uc1:StorageDropdownlist ID="ddlCon" runat="server"></uc1:StorageDropdownlist>
            </td>
        </tr>
        <tr>
            <td colspan="4" style="height: 10px">
                &nbsp;
            </td>
        </tr>
    </table>
    <div class="hidden">
        <asp:Button ID="refresh" runat="server" Text="Button"></asp:Button>
    </div>
</asp:Content>

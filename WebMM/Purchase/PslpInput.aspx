<%@ Page Language="c#" CodeBehind="PslpInput.aspx.cs" Title="�ɹ�Աά��" AutoEventWireup="True" MasterPageFile="~/Master/Default.Master"
    Inherits="MZHMM.WebMM.Purchase.PslpInput" %>

<%@ MasterType VirtualPath="~/Master/Default.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>�ɹ�Աά��</title>
    <link href="../CSS/ManageCommon.css" type="text/css" rel="stylesheet" />

    <script type="text/javascript">
        var popupWindow = new PopupWindow();
        var userFlag; /*ȫ��*/

        function OpenPerson() {
            //  alert('<%= Master.UserQueryPath %>');
            popupWindow.setUrl('<%= Master.UserQueryPath %>');
            popupWindow.setSize(250, 400);
            popupWindow.showPopup('UserPerson', false);
        }

        function setUserInfo(loginName, empCode, empName, deptCode, deptName) {

            document.getElementById("<%= txtDescription.ClientID%>").value = empName;
            document.getElementById("<%=txtCode.ClientID%>").value = empCode;
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="AjaxHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BodyHolder" runat="server">
    <mzh:MzhToolbar ID="MzhToolbar1" runat="server" OnItemPostBack="MzhToolbar1_ItemPostBack">
        <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable"
            itemid="Add" cellspacing="0" nakedlabelclass="nakedLabelCell" isshowtext="True"
            iconclass="add" hasicon="True" text="����" id="toolbarButtonAdd" autopostback="True">
        </mzh:toolbarbutton>
        <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable"
            itemid="Edit" cellspacing="0" nakedlabelclass="nakedLabelCell" isshowtext="True"
            iconclass="pre" hasicon="True" text="ȡ��" id="toolbarButtoncancel" onclick="document.location = 'PslpBrowser.aspx'">
        </mzh:toolbarbutton>
    </mzh:MzhToolbar>
    <table border="1" class="managertable">
        <tr class="managertr">
            <td class="titletd">
                <span class="required">*</span>�ɹ�Ա����
            </td>
            <td align="left" style="width: 250">
                &nbsp;&nbsp;
                <table>
                    <tr>
                        <td>
                            <asp:TextBox ID="txtCode" runat="server" ToolTip="�ɹ�Ա����(���5λ),�����ظ���" MaxLength="5"
                                Width="80px"></asp:TextBox>
                        </td>
                        <td>
                            &nbsp;&nbsp;
                            <input type="button" id="UserPerson" value="ѡ����Ա" onclick="OpenPerson()" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                             <asp:RequiredFieldValidator ID="RFVCode" runat="server" ErrorMessage="�ɹ�Ա�����������"
                    ControlToValidate="txtCode" Display="Dynamic">�ɹ�Ա�����������</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                </table>
           
            </td>
        </tr>
        <tr class="managertr">
            <td class="titletd">
                <span class="required">*</span>�ɹ�Ա����
            </td>
            <td style="width: 80%" align="left">
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="txtDescription" runat="server" ToolTip="������ɹ�Ա����" MaxLength="30"
                    Width="80px"></asp:TextBox>
                <br />
                <asp:RequiredFieldValidator ID="RFVDescription" runat="server" ErrorMessage="�ɹ�Ա������������"
                    ControlToValidate="txtDescription" Display="Dynamic">�ɹ�Ա������������</asp:RequiredFieldValidator>
            </td>
        </tr>
    </table>
</asp:Content>

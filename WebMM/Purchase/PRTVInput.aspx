<%@ Page Language="c#" CodeBehind="PRTVInput.aspx.cs" MasterPageFile="~/Master/Default.Master"
    AutoEventWireup="True" Inherits="MZHMM.WebMM.Purchase.PRTVInput" %>

<%@ MasterType VirtualPath="~/Master/Default.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>�ɹ��˻���</title>
    <link rel="stylesheet" type="text/css" href="../CSS/Purchase/PRTVInput.css" />

    <script language="JavaScript" type="text/javascript">
        var testpopup4 = new PopupWindow();
        testpopup4.setSize(580, 400);
        testpopup4.autoHide();
        testpopup4.setUrl('<%= Master.CrmQueryPath %>');
        function setPPRNInfo(s) {
            var ss;
            ss = s.split("|");
            document.getElementById("<%=txtVendorCode.ClientID%>").value = ss[0]; //��Ӧ�̱��
            document.getElementById("<%=txtVendor.ClientID%>").value = ss[1]; //��Ӧ������
        }

        function aVendorSearch(el) {
            testpopup4.showPopup(el, false);
            return false;
        }

        function PRTVInput_btnSelectProvider() {
            window.open('PCBRSource.aspx?PrvCode=' + GetCode(), '�ɹ����ϵ���ѯ', 'toolbar = no,location=no,directories=no,status=no,menubar=no,scrollbars=yes,resizable=yes,copyhistory=no,width =640,height = 440,left=' + (window.screen.width - 640) / 2 + ',top=' + (window.screen.height - 440) / 2 + '');
        }

       
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="AjaxHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BodyHolder" runat="server">
    <table class="myTable myTableToolbar" id="Table2" cellspacing="1"  >
        <tr>
            <td colspan="6">
                <uc1:DocWebControl ID="doc1" runat="server"></uc1:DocWebControl>
            </td>
        </tr>
        <tr>
            <td width="10%">
                ��Ӧ��λ��<span class="required">*</span>
            </td>
            <td width="24%">
                <table style="width: 100%">
                    <tr>
                        <td>
                            <asp:TextBox ID="txtVendor" runat="server" MaxLength="30"></asp:TextBox>
                        </td>
                        <td style="width: 65px">
                            <input runat="server" type="button" value="..." id="Image1" onclick="aVendorSearch(this.id);"/>
                            <input id="btnSelectProvider" onclick="PRTVInput_btnSelectProvider();" type="button"
                                value="ѡ��" name="Button1" runat="server"  />
                        </td>
                    </tr>
                </table>
            </td>
            <td width="10%">
                �ֿ⣺<span class="required">*</span>
            </td>
            <td width="23%">
                <uc1:StorageDropdownlist ID="ddlStock" runat="server" Width="100%"></uc1:StorageDropdownlist>
            </td>
            <td width="10%">
                ��Ʊ�ţ�<span class="required">*</span>
            </td>
            <td width="23%">
                <asp:TextBox ID="txtInvoice"  runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr >
            <td>
                �跽��Ŀ��
            </td>
            <td>
                <asp:TextBox ID="txtJFKM"  runat="server"></asp:TextBox>
            </td>
            <td>
                ���㷽ʽ��
            </td>
            <td>
                <uc1:StorageDropdownlist ID="ddlPayStyle" runat="server" Width="100%"></uc1:StorageDropdownlist>
            </td>
            <td>
                ���������
            </td>
            <td>
                <uc1:StorageDropdownlist ID="ddlCheckResult" runat="server" Width="100%"></uc1:StorageDropdownlist>
            </td>
        </tr>
        <tr >
            <td colspan="6" class="myItemControl">
                <uc1:PRTVWebControl ID="item1" runat="server"></uc1:PRTVWebControl>
            </td>
        </tr>
        <tr >
            <td colspan="6">
                <uc1:DocAuditWebControl ID="DocAuditWebControl1" runat="server"></uc1:DocAuditWebControl>
            </td>
        </tr>
        <tr >
            <td>
                �Ƶ��ˣ�
            </td>
            <td>
                <asp:Label ID="lblAuthor" runat="server"></asp:Label>
            </td>
            <td>
                �ɹ�Ա��<span class="required">*</span>
            </td>
            <td>
                <uc1:StorageDropdownlist ID="ddlBuyer" runat="server" Width="100%"></uc1:StorageDropdownlist>
                 
            </td>
            <td>
                �ֹܣ�
            </td>
            <td>
                <asp:TextBox ID="txtStoManager" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr >
            <td>
                ԭ�ɹ����ϵ���
            </td>
            <td colspan="5">
                <asp:HyperLink ID="HyperLink1" runat="server" Target="_blank">��</asp:HyperLink>
            </td>
        </tr>
        <tr>
            <td colspan="6" class="td_Submit">
                <asp:Button ID="btnSave" runat="server" Text="����" OnClick="btnSave_Click"></asp:Button>
                <asp:Button ID="btnCancel" runat="server" Text="ȡ��" OnClick="btnCancel_Click"></asp:Button>
            </td>
        </tr>
    </table>
    
    <asp:HiddenField ID="StaticInput" runat="server" />
    <asp:HiddenField ID="txtVendorCode" runat="server" />
    <asp:HiddenField ID="txtPKID" runat="server" />
    <div class="hidden">
        <uc1:StorageDropdownlist ID="ddlCurrency" runat="server"></uc1:StorageDropdownlist>
        <asp:Button ID="btnForPKID" runat="server" Text="Button" OnClick="btnForPKID_Click">
        </asp:Button>
    </div>

    <script language="javascript" type="text/javascript">
        function GetCode() {
            return document.getElementById("<%=txtVendorCode.ClientID%>").value;
        }
        function setEntry(id) {
            document.getElementById("<%=txtPKID.ClientID%>").value = id;
            document.getElementById("<%=btnForPKID.ClientID%>").click();
        }
    </script>

</asp:Content>

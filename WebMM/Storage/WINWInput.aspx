<%@ Page Language="c#" CodeBehind="WINWInput.aspx.cs" MasterPageFile="~/Master/Default.Master"
    AutoEventWireup="True" Inherits="MZHMM.WebMM.Storage.WINWInput" %>

<%@ MasterType VirtualPath="~/Master/Default.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>ί��ӹ����ϵ�</title>
    <meta content="ί��ӹ����ϵ�" name="keywords" />
    <link rel="stylesheet" type="text/css" href="../CSS/Storage/WINWInput.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="AjaxHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BodyHolder" runat="server">
    <table class="myTable myTableToolbar" id="Table1" cellspacing="1" >
        <tr class="myTrDualLine">
            <td colspan="6">
                <uc1:DocWebControl ID="doc1" runat="server"></uc1:DocWebControl>
            </td>
        </tr>
        <tr class="myTrDualLine">
            <td width="10%">
                ��Ӧ�̣�<span class="required">*</span>
            </td>
            <td width="24%">
                <table width="100%">
                    <tr>
                        <td>
                            <asp:TextBox ID="txtVendor1"  runat="server"></asp:TextBox>
                        </td>
                        <td width="30px">
                            <input runat="server" type="button" value="..." id="Image1" onclick="javascript:aSearch(this.id);"/>
                        </td>
                    </tr>
                </table>
            </td>
            <td width="10%">
                �ֿ⣺<span class="required">*</span>
            </td>
            <td width="23%">
                <uc1:StorageDropdownlist ID="ddlStorage" runat="server" Width="100%"></uc1:StorageDropdownlist>
                
            </td>
            <td width="10%">
                ��Ʊ�ţ�<span class="required">*</span>
            </td>
            <td width="23%">
                <asp:TextBox ID="txtInvoiceNo" runat="server" TextMode="SingleLine"></asp:TextBox>
            </td>
        </tr>
        <tr class="myTrDualLine">
            <td>
                ��ͬ��ţ�
            </td>
            <td>
                <asp:TextBox ID="txtContractCode" runat="server"></asp:TextBox>
            </td>
            <td>
                ���ʽ��
            </td>
            <td>
                <uc1:StorageDropdownlist ID="ddlPayStyle" runat="server" Width="100%"></uc1:StorageDropdownlist>
            </td>
            <td>
                ���������
            </td>
            <td >
                <uc1:StorageDropdownlist ID="ddlChkResult" runat="server" Width="100%"></uc1:StorageDropdownlist>
            </td>
        </tr>
        <tr >
            <td colspan="6" class="myItemControl">
                <uc1:WINWWebControl ID="WINWItem" runat="server"></uc1:WINWWebControl>
            </td>
        </tr>
        <tr >
            <td colspan="6">
                <uc1:DocAuditWebControl ID="DocAuditWebControl1" runat="server"></uc1:DocAuditWebControl>
            </td>
        </tr>
        <tr >
            <td>
                �Ƶ���
            </td>
            <td>
                <asp:Label ID="lblAuthorName" runat="server"></asp:Label>
            </td>
            <td>
                �ɹ���<span class="required">*</span>
            </td>
            <td  class="td_Content"  align="left">
                <uc1:StorageDropdownlist ID="ddlBuyer" runat="server" Width="100%"></uc1:StorageDropdownlist>
            </td>
            <td>
                ���ϣ�
            </td>
            <td>
                <asp:Label ID="lblStoManager" runat="server"></asp:Label>
            </td>
        </tr>
        <tr class="myTrSubmitLine">
            <td class="td_Submit" colspan="6">
                <input id="btnAddFrom" class="Commonbutton" type="button" value="�ɵ������" style="<% = WinStyle %>" onclick="window.open('WRES_SRCBrowser.aspx?Op=View','������ѯ','toolbar = no,location=no,directories=no,status=no,menubar=no,scrollbars=no,resizable=no,copyhistory=no,width =640,height = 440,left='+(window.screen.width - 640)/2+',top='+(window.screen.height - 440)/2+'')" />&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnSave" runat="server" Text="����" OnClick="btnSave_Click"></asp:Button>
                <asp:Button ID="btnPresent" runat="server" Text="�����ύ" OnClick="btnPresent_Click">
                </asp:Button>
                <asp:Button ID="btnCancel" runat="server" Text="ȡ��" CausesValidation="False" OnClick="btnCancel_Click">
                </asp:Button>
            </td>
        </tr>
    </table>
    <asp:HiddenField ID="StaticInput_Items" runat="server" />
    <asp:HiddenField ID="StaticInput_Wres" runat="server" />
    <asp:HiddenField ID="txtVendorCode" runat="server" />
    <asp:HiddenField ID="txtParentEntryNo" runat="server" />
    <div class="hidden">
    </div>

    <script language="JavaScript" type="text/javascript">
        var testpopup5 = new PopupWindow();
        testpopup5.setSize(580, 400);
        testpopup5.autoHide();
        testpopup5.setUrl('<%= Master.CrmQueryPath %>');

        function setPPRNInfo(s) {
            var ss;
            ss = s.split("|");
            document.getElementById("<%=txtVendorCode.ClientID%>").value = ss[0]; //��Ӧ�̱��
            document.getElementById("<%=txtVendor1.ClientID%>").value = ss[1]; //��Ӧ������	
        }

        function GetCode() {
            return document.getElementById("<%=txtVendorCode.ClientID%>").value;
        }

        function insertItem() {
            window.opener.setEntry(getSelectedArray()); //setEntry��������PBORWebcontrol.ascx�ļ��С�
            window.close();
        }

        function aSearch(el) {
            testpopup5.showPopup(el, false);
            return false;
        }
    </script>

</asp:Content>

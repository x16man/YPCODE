<%@ Page Language="c#" CodeBehind="WINWInput.aspx.cs" MasterPageFile="~/Master/Default.Master"
    AutoEventWireup="True" Inherits="MZHMM.WebMM.Storage.WINWInput" %>

<%@ MasterType VirtualPath="~/Master/Default.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>委外加工收料单</title>
    <meta content="委外加工收料单" name="keywords" />
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
                供应商：<span class="required">*</span>
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
                仓库：<span class="required">*</span>
            </td>
            <td width="23%">
                <uc1:StorageDropdownlist ID="ddlStorage" runat="server" Width="100%"></uc1:StorageDropdownlist>
                
            </td>
            <td width="10%">
                发票号：<span class="required">*</span>
            </td>
            <td width="23%">
                <asp:TextBox ID="txtInvoiceNo" runat="server" TextMode="SingleLine"></asp:TextBox>
            </td>
        </tr>
        <tr class="myTrDualLine">
            <td>
                合同编号：
            </td>
            <td>
                <asp:TextBox ID="txtContractCode" runat="server"></asp:TextBox>
            </td>
            <td>
                付款方式：
            </td>
            <td>
                <uc1:StorageDropdownlist ID="ddlPayStyle" runat="server" Width="100%"></uc1:StorageDropdownlist>
            </td>
            <td>
                验收情况：
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
                制单：
            </td>
            <td>
                <asp:Label ID="lblAuthorName" runat="server"></asp:Label>
            </td>
            <td>
                采购：<span class="required">*</span>
            </td>
            <td  class="td_Content"  align="left">
                <uc1:StorageDropdownlist ID="ddlBuyer" runat="server" Width="100%"></uc1:StorageDropdownlist>
            </td>
            <td>
                收料：
            </td>
            <td>
                <asp:Label ID="lblStoManager" runat="server"></asp:Label>
            </td>
        </tr>
        <tr class="myTrSubmitLine">
            <td class="td_Submit" colspan="6">
                <input id="btnAddFrom" class="Commonbutton" type="button" value="由单据添加" style="<% = WinStyle %>" onclick="window.open('WRES_SRCBrowser.aspx?Op=View','订单查询','toolbar = no,location=no,directories=no,status=no,menubar=no,scrollbars=no,resizable=no,copyhistory=no,width =640,height = 440,left='+(window.screen.width - 640)/2+',top='+(window.screen.height - 440)/2+'')" />&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnSave" runat="server" Text="保存" OnClick="btnSave_Click"></asp:Button>
                <asp:Button ID="btnPresent" runat="server" Text="马上提交" OnClick="btnPresent_Click">
                </asp:Button>
                <asp:Button ID="btnCancel" runat="server" Text="取消" CausesValidation="False" OnClick="btnCancel_Click">
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
            document.getElementById("<%=txtVendorCode.ClientID%>").value = ss[0]; //供应商编号
            document.getElementById("<%=txtVendor1.ClientID%>").value = ss[1]; //供应商名称	
        }

        function GetCode() {
            return document.getElementById("<%=txtVendorCode.ClientID%>").value;
        }

        function insertItem() {
            window.opener.setEntry(getSelectedArray()); //setEntry函数，在PBORWebcontrol.ascx文件中。
            window.close();
        }

        function aSearch(el) {
            testpopup5.showPopup(el, false);
            return false;
        }
    </script>

</asp:Content>

<%@ Reference Page="POSBrowser.aspx" %>

<%@ Page Language="c#" CodeBehind="POInput.aspx.cs" MasterPageFile="~/Master/Default.Master"
    AutoEventWireup="True" Inherits="MZHMM.WebMM.Purchase.POInput" %>

<%@ MasterType VirtualPath="~/Master/Default.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>采购订单</title>
    <meta content="采购订单" name="keywords" />
    <link rel="stylesheet" type="text/css" href="../CSS/Purchase/POInput.css" />

    <script language="JavaScript" type="text/javascript">
        var testpopup4 = new PopupWindow();
        testpopup4.setSize(580, 400);
        testpopup4.autoHide();
        testpopup4.setUrl('<%= Master.CrmQueryPath %>');

        function setPPRNInfo(s) {
            var ss;
            ss = s.split("|");
            document.getElementById("<%=txtVendorCode.ClientID%>").value = ss[0]; //供应商编号
            document.getElementById("<%=txtVendor.ClientID%>").value = ss[1]; //供应商名称
            document.getElementById("<%=txtBank.ClientID%>").value = ss[2]; //开户银行
            document.getElementById("<%=txtAccount.ClientID%>").value = ss[3]; //账号
            document.getElementById("<%=txtAdd.ClientID%>").value = ss[4]; //地址
            document.getElementById("<%=txtZip.ClientID%>").value = ss[5]; //邮编
            document.getElementById("<%=txtTel.ClientID%>").value = ss[6]; //电话
            document.getElementById("<%=txtFax.ClientID%>").value = ss[7]; //传真
        }
        function aVendorSearch(el) {
            testpopup4.showPopup(el, false);
            return false;
        }
        // Get the Vendor's Code.
        function GetPrvCode() {
            return document.getElementById("<%=txtVendorCode.ClientID%>").value;
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="AjaxHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BodyHolder" runat="server">
    <table id="Table2" cellspacing="1" class="myTableToolbar myTable">
        <tr>
            <td colspan="4">
                <uc1:DocWebControl ID="doc1" runat="server"></uc1:DocWebControl>
            </td>
        </tr>
        <tr>
            <td class="td_Label">
                供货商：<span class="required">*</span>
            </td>
            <td class="td_Content" align="left">
                <table width="100%">
                    <tr>
                        <td>
                            <asp:TextBox ID="txtVendor" runat="server" MaxLength="30" ></asp:TextBox>
                        </td>
                        <td width="20px">
                            <input width="100%" onclick="aVendorSearch(this.id);"
                            type="button" value="..." class="Commonbutton" runat="server" id="Image1"/>
                            
                        </td>
                    </tr>
                </table>
            </td>
            <td class="td_Label">
                地址：
            </td>
            <td class="td_Content">
                <asp:TextBox ID="txtAdd"  runat="server" ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                付款方式：
            </td>
            <td align="left">
                <uc1:StorageDropdownlist ID="ddlPayStyle" runat="server" Width="100%"></uc1:StorageDropdownlist>
            </td>
            <td>
                帐号：
            </td>
            <td>
                <asp:TextBox ID="txtAccount"  runat="server" ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                联系电话：
            </td>
            <td>
                <asp:TextBox ID="txtTel"  runat="server" ></asp:TextBox>
            </td>
            <td>
                采购员：<span class="required">*</span>
            </td>
            <td align="left">
                <uc1:StorageDropdownlist ID="ddlStoManager" runat="server" Width="100%"></uc1:StorageDropdownlist>
            </td>
        </tr>
        <tr>
            <td colspan="4" class="myItemControl">
                <uc1:POWebControl ID="item1" runat="server"></uc1:POWebControl>
            </td>
        </tr>
        <tr class="hidden">
            <td>
                付款条款：
            </td>
            <td colspan="3">
                <asp:TextBox ID="TxtPayment" runat="server" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                购方编号：
            </td>
            <td>
                <asp:Label ID="lblPscCode" runat="server"></asp:Label>
            </td>
            <td>
                购方名称：
            </td>
            <td>
                <asp:Label ID="lblPscName" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <uc1:DocAuditWebControl ID="DocAuditWebControl1" runat="server"></uc1:DocAuditWebControl>
            </td>
        </tr>
        <tr class="myTrSubmitLine">
            <td colspan="4" class="td_Submit">
                <asp:Button ID="btnSave" runat="server" Text="保存" OnClick="btnSave_Click"></asp:Button>
                <asp:Button ID="btnPresent" runat="server" Text="马上指派" OnClick="btnPresent_Click">
                </asp:Button>
                <asp:Button ID="btnCancel" runat="server" Text="取消" OnClick="btnCancel_Click"></asp:Button>
            </td>
        </tr>
    </table>
    
    <div class="hidden">
    <asp:HiddenField ID="StaticInput" runat="server" />
    <asp:HiddenField ID="txtVendorCode" runat="server" />
    <asp:HiddenField ID="txtCurrency" runat="server" />
    <asp:HiddenField ID="txtFax" runat="server" />
    <asp:HiddenField ID="txtZip" runat="server" />
    <asp:HiddenField ID="txtBank" runat="server" />
    <asp:HiddenField ID="txtTaxNo" runat="server" />
    </div>
</asp:Content>

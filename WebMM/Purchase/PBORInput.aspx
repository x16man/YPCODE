<%@ Page Language="c#" CodeBehind="PBORInput.aspx.cs" MasterPageFile="~/Master/Default.Master"
    AutoEventWireup="True" Inherits="MZHMM.WebMM.Purchase.PBORInput" %>

<%@ MasterType VirtualPath="~/Master/Default.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>PBORInput</title>
    <link rel="stylesheet" type="text/css" href="../CSS/Purchase/PBORInput.css" />

    <script type="text/javascript" src="../JS/Common.js"></script>

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
        }

       
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="AjaxHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BodyHolder" runat="server">
    <table id="Table2" class="myTable myTableToolbar" cellspacing="1" cellpadding="1">
        <tr>
            <td colspan="6" >
                <uc1:DocWebControl ID="doc1" runat="server"></uc1:DocWebControl>
            </td>
        </tr>
        <tr class="myTrDualLine">
            <td width="10%">
                供应单位：<span class="required">*</span>
            </td>
            <td width="24%">
                <table style="width: 100%">
                    <tr>
                        <td>
                            <asp:TextBox ID="txtVendor" runat="server" MaxLength="30"></asp:TextBox>
                        </td>
                        <td align="Left" style="width: 30px">
                            <input runat="server" type="button" style="width:100%" class="Commonbutton" value="..." id="Image1" name="Image1" onclick="testpopup4.showPopup(this.id,false);return false;"/>
                        </td>
                        <td style="width:35px"><input id="btnProvicerCom" onclick="window.open('PBSABrowser.aspx?Op=View&amp;PrvCode='+GetCode(),'订单查询','toolbar = no,location=no,directories=no,status=no,menubar=no,scrollbars=yes,resizable=yes,copyhistory=no,width =640,height = 440,left='+(window.screen.width - 640)/2+',top='+(window.screen.height - 440)/2+'')"
                                type="button" value="订单" name="btnProvicerCom" runat="server" width="100%" class="Commonbutton"/></td>
                    </tr>
                </table>
            </td>
            <td width="10%">
                仓库：<span class="required">*</span>
            </td>
            <td width="23%">
                <uc1:StorageDropdownlist ID="ddlStock" runat="server" Width="100%"></uc1:StorageDropdownlist>
            </td>
            <td width="10%">
                发票号：
            </td>
            <td width="23%">
                <asp:TextBox ID="txtInvoice" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td >
                合同编号：
            </td>
            <td>
                <asp:TextBox ID="txtContractCode" runat="server"></asp:TextBox>
            </td>
            <td>
                结算方式：
            </td>
            <td>
                <uc1:StorageDropdownlist ID="ddlPayStyle" runat="server" Width="100%"></uc1:StorageDropdownlist>
            </td>
            <td>
                验收情况：
            </td>
            <td>
                <uc1:StorageDropdownlist ID="ddlCheckResult" runat="server" Width="100%"></uc1:StorageDropdownlist>
            </td>
        </tr>
        <tr>
            <td colspan="6">
                <uc1:PBORWebControl ID="item1" runat="server"></uc1:PBORWebControl>
            </td>
        </tr>
        <tr class="hidden">
            <td align="left" colspan="2">
                上列物资用于：
            </td>
            <td colspan="2">
                <asp:TextBox ID="txtUsedFor" runat="server"></asp:TextBox>
            </td>
            <td>
                币种：
            </td>
            <td>
                <uc1:StorageDropdownlist ID="ddlCurrency" runat="server" Width="100%"></uc1:StorageDropdownlist>
            </td>
        </tr>
        <tr class="myTrDualLine">
            <td colspan="6">
                <uc1:DocAuditWebControl ID="DocAuditWebControl1" runat="server"></uc1:DocAuditWebControl>
            </td>
        </tr>
        <tr>
            <td>
                制单人：
            </td>
            <td>
                <asp:Label ID="lblAuthor" runat="server"></asp:Label>
            </td>
            <td>
                采购员：<span class="required">*</span>
            </td>
            <td>
                <uc1:StorageDropdownlist ID="ddlBuyer" runat="server"></uc1:StorageDropdownlist>
                
            </td>
            <td>
                收料人：
            </td>
            <td>
                <asp:Label ID="lblAccept" runat="server"></asp:Label>
            </td>
        </tr>
        <tr class="myTrSubmitLine">
            <td colspan="6" class="td_Submit">
                <asp:Button ID="btnSave" runat="server" Text="保存" OnClick="btnSave_Click">
                </asp:Button><asp:Button ID="btnPresent" runat="server" Text="马上提交" onclick="btnPresent_Click">
                </asp:Button><asp:Button ID="btnReject" runat="server" Text="拒绝" OnClick="btnReject_Click">
                </asp:Button><asp:Button ID="btnCancel" runat="server" Text="取消" OnClick="btnCancel_Click"></asp:Button>
            </td>
        </tr>
    </table>
    
    <div class="hidden">
        <asp:HiddenField ID="StaticInput" runat="server" />
        <asp:HiddenField ID="txtJFKM" runat="server" />
        <asp:HiddenField ID="txtVendorCode" runat="server" />
        <asp:HiddenField ID="txtParentEntryNo" runat="server" />
        <asp:HiddenField ID="txtIsRepeated" runat="server" />
        <asp:Button ID="btnDoRepeat" runat="server" Text="保存" OnClick="btnDoRepeat_Click">
        </asp:Button>
    </div>

    <script language="javascript" type="text/javascript">
        function GetCode() {
            return document.getElementById("<%=txtVendorCode.ClientID%>").value;
        }
        function ConfirmContinue() {
            if (document.getElementById("<%=txtIsRepeated.ClientID%>").value != "") {
                if (window.confirm(document.getElementById("<%=txtIsRepeated.ClientID%>").value)) {
                    document.getElementById("<%=btnDoRepeat.ClientID%>").click();
                }
                document.getElementById("<%=txtIsRepeated.ClientID%>").value = "";
            }
        }
    </script>

    <script  type="text/javascript">
        ConfirmContinue();
    </script>

</asp:Content>

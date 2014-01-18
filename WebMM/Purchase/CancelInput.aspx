<%@ Page Language="c#" CodeBehind="CancelInput.aspx.cs" MasterPageFile="~/Master/Default.Master"
    AutoEventWireup="True" Inherits="MZHMM.WebMM.Purchase.CancelInput" %>

<%@ Reference Page="POSBrowser.aspx" %>
<%@ MasterType VirtualPath="~/Master/Default.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>采购撤销单</title>
    <link rel="stylesheet" type="text/css" href="../CSS/Purchase/CancelInput.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="AjaxHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BodyHolder" runat="server">
    <table class="myTable myTableToolbar" id="Table2" cellspacing="1" >
        <tr class="myTrDualLine">
            <td colspan="4">
                <uc1:DocWebControl ID="doc1" runat="server"></uc1:DocWebControl>
            </td>
        </tr>
        <tr class="myTrDualLine">
            <td colspan="1" style="width:10%">
                申请人：
            </td>
            <td colspan="1" style="width:40%">
                <asp:TextBox ID="txtAuthorName" runat="server"  MaxLength="30" Width="99%"></asp:TextBox>
            </td>
            <td style="width:10%">
                申请部门：
            </td>
            <td style="width:40%">
                <asp:TextBox ID="txtAuthorDeptName" runat="server"  ReadOnly="True" Width="99%"></asp:TextBox>
            </td>
        </tr>
        <tr class="myTrDualLine">
            <td colspan="4" class="myItemControl">
                <uc1:CancelWebControl ID="item1" runat="server"></uc1:CancelWebControl>
            </td>
        </tr>
        <tr class="myTrDualLine">
            <td colspan="4">
                <uc1:DocAuditWebControl ID="DocAuditWebControl1" runat="server"></uc1:DocAuditWebControl>
            </td>
        </tr>
        <tr>
            <td  colspan="4" style="text-align:center">
                <asp:Button ID="btnSave" runat="server" Text="保存" OnClick="btnSave_Click"></asp:Button>
                <asp:Button ID="btnPresent" runat="server" Text="马上指派" OnClick="btnPresent_Click">
                </asp:Button>
                <asp:Button ID="btnCancel" runat="server" Text="取消" OnClick="btnCancel_Click"></asp:Button>
            </td>
        </tr>
    </table>
    
    <div class="hidden">
        <asp:HiddenField ID="StaticInput" runat="server" />
        <asp:HiddenField ID="tb_UserIDs" runat="server" />
        <asp:HiddenField ID="tb_UserNames" runat="server" />
        <asp:HiddenField ID="tb_GroupIDs" runat="server" />
        <asp:HiddenField ID="tbRoleCode" runat="server" />
        <asp:HiddenField ID="txtCurrency" runat="server" />
        <asp:HiddenField ID="txtFax" runat="server" />
        <asp:HiddenField ID="txtZip" runat="server" />
        <asp:HiddenField ID="txtBank" runat="server" />
        <asp:HiddenField ID="txtTaxNo" runat="server" />
    </div>

    <script type="text/javascript" >
        function ShowUserList() {
            window.open('/WebMM/SYS/SYS_ChooseUser.aspx?ids=' + document.getElementById("tb_UserIDs").value + '&Groupids=' + document.getElementById("tb_GroupIDs").value, "UserChoose", "location=no,directions=no,status=no,menubar=no,width=250,Height=400,left=400,top=100");
        }
       
    </script>

</asp:Content>

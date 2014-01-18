<%@ Page Language="c#" CodeBehind="PPInput.aspx.cs" MasterPageFile="~/Master/Default.Master"
    AutoEventWireup="True" Inherits="MZHMM.WebMM.Purchase.PPInput" %>

<%@ MasterType VirtualPath="~/Master/Default.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>采购计划编制</title>
    <meta content="采购计划" name="keywords" />
    <link rel="stylesheet" type="text/css" href="../CSS/Purchase/PPInput.css" />
    <script type="text/javascript" src="../JS/Common.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="AjaxHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BodyHolder" runat="server">
    <table class="myTable myTableToolbar" id="Table2" cellspacing="1" cellpadding="1">
        <tr>
            <td colspan="4">
                <uc1:DocWebControl ID="doc1" runat="server"></uc1:DocWebControl>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <uc1:PPWebControl ID="item1" runat="server"></uc1:PPWebControl>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <uc1:DocAuditWebControl ID="DocAuditWebControl1" runat="server"></uc1:DocAuditWebControl>
            </td>
        </tr>
        <tr>
            <td  style="width:20%">
                编制部门：
            </td>
            <td style="width:30%">
                <uc1:StorageDropdownlist ID="ddlDept" runat="server"></uc1:StorageDropdownlist>
            </td>
            <td style="width:20%">
                编制人：
            </td>
            <td style="width:30%">
                <asp:TextBox ID="txtAuthor" runat="server" CssClass="undline"></asp:TextBox>
            </td>
        </tr>
        <tr class="myTrSubmitLine">
            <td align="center" colspan="4">
                <asp:Button ID="btnSave" runat="server" Text="保存" onclick="btnSave_Click"></asp:Button>&nbsp;
                <asp:Button ID="btnPresent" runat="server" Text="马上提交" 
                    onclick="btnPresent_Click"></asp:Button>&nbsp;<asp:Button
                    ID="btnCancel" runat="server" Text="取消" onclick="btnCancel_Click"></asp:Button>
            </td>
        </tr>
    </table>
    
</asp:Content>

<%@ Page Language="c#" CodeBehind="MRPInput.aspx.cs" MasterPageFile="~/Master/Default.Master"
    AutoEventWireup="True" Inherits="MZHMM.WebMM.Purchase.MRPInput" %>

<%@ MasterType VirtualPath="~/Master/Default.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>MRPInput</title>
    <meta content="物料需求单" name="keywords" />
    <link rel="stylesheet" type="text/css" href="../CSS/Purchase/MRPInput.css" />

    <script type="text/javascript" src="../JS/Common.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="AjaxHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BodyHolder" runat="server">
    <table class="myTable myTableToolbar" id="Table2" cellspacing="1" cellpadding="1" width="100%">
        <tr class="myTrDualLine">
            <td colspan="4">
                <uc1:DocWebControl ID="doc1" runat="server"></uc1:DocWebControl>
            </td>
        </tr>
        <tr>
            <td width="20%">
                申请理由及用途：<span class="required">*</span>
            </td>
            <td width="80%" colspan="3">
                <uc1:USWebControl ID="ddlPurpose" runat="server"></uc1:USWebControl>
            </td>
        </tr>
        <tr>
            <td colspan="4">
               <uc1:ItemsWebControl ID="item1" runat="server"></uc1:ItemsWebControl>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                    <uc1:DocAuditWebControl ID="DocAuditWebControl1" runat="server"></uc1:DocAuditWebControl>
            </td>
        </tr>
        <tr>
            <td colspan="1" style="width:20%">申请部门:</td>
            <td style="width:30%">
                <uc1:StorageDropdownlist ID="ddlDept" runat="server"></uc1:StorageDropdownlist>
            </td>
            <td style="width:20%">申请人:</td>
            <td style="width:30%">
                <asp:TextBox ID="txtProposer" runat="server" CssClass="undline"></asp:TextBox>
            </td>
        </tr>
        <tr class="myTrSubmitLine">
            <td align="center" colspan="4">
                <asp:Button ID="btnSave" runat="server" Text="保存" onclick="btnSave_Click">
                </asp:Button>&nbsp;<asp:Button ID="btnPresent" runat="server" Text="马上提交" 
                    onclick="btnPresent_Click">
                    </asp:Button>&nbsp;<asp:Button ID="btnCancel" runat="server" Text="取消" onclick="btnCancel_Click"></asp:Button>
            </td>
        </tr>
    </table>
    
</asp:Content>

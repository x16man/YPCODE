<%@ Page Language="c#" CodeBehind="SCRInput.aspx.cs" MasterPageFile="~/Master/Default.Master"
    AutoEventWireup="True" Inherits="MZHMM.WebMM.Storage.SCRInput" %>

<%@ MasterType VirtualPath="~/Master/Default.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>SCRInput</title>
    <link rel="stylesheet" type="text/css" href="../CSS/Storage/SCRInput.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="AjaxHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BodyHolder" runat="server">
    <table class="myTable myTableToolbar" id="Table2" cellspacing="1" border="0">
        <tr class="myTrDualLine">
            <td colspan="4">
                <uc1:DocWebControl ID="doc1" runat="server"></uc1:DocWebControl>
            </td>
        </tr>
        <tr class="myTrDualLine">
            <td>
                仓库
            </td>
            <td colspan="3" align="left">
                <uc1:StorageDropdownlist ID="ddlStorage" runat="server"></uc1:StorageDropdownlist>
                <span class="required">*</span>
            </td>
           
        </tr>
        <tr class="hidden">
            <td>
                申请理由及用途
            </td>
            <td colspan="3">
                <uc1:USWebControl ID="ddlPurpose" runat="server"></uc1:USWebControl>
            </td>
           
        </tr>
        <tr class="myTrDualLine">
            <td colspan="4" class="myItemControl">
                <uc1:SCRWebControl ID="item1" runat="server"></uc1:SCRWebControl>
            </td>
        </tr>
        <tr class="myTrDualLine">
            <td colspan="4">
                <uc1:DocAuditWebControl ID="DocAuditWebControl1" runat="server"></uc1:DocAuditWebControl>
            </td>
        </tr>
        <tr class="myTrDualLine">
            <td class="td_Label">
                申请部门：
            </td>
            <td class="td_Content">
                <uc1:StorageDropdownlist ID="ddlDept" runat="server"></uc1:StorageDropdownlist>
                <span class="required">*</span>
            </td>
            <td class="td_Label">
                申请人：
            </td>
            <td class="td_Content">
                <asp:TextBox ID="txtProposer" runat="server" CssClass="txtProposer input"></asp:TextBox>
                <span class="required">*</span>
            </td>
        </tr>
        <tr>
            <td class="td_Submit" colspan="4">
                <asp:Button ID="btnSave" AccessKey="S" runat="server" ToolTip="保存单据，但是不会提交审批" Text="保存"
                    OnClick="btnSave_Click"></asp:Button>
                <asp:Button ID="btnPresent" AccessKey="P" runat="server" ToolTip="保存并且提交" Text="马上提交"
                    OnClick="btnPresent_Click"></asp:Button>
                <asp:Button ID="btnCancel" runat="server" ToolTip="返回到浏览页面" Text="取消" CssClass="button"
                     OnClick="btnCancel_Click"></asp:Button>
            </td>
        </tr>
    </table>
    <asp:HiddenField ID="StaticInput" runat="server" />
    
</asp:Content>

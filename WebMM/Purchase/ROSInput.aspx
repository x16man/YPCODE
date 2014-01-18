<%@ Page Language="c#" CodeBehind="ROSInput.aspx.cs" MasterPageFile="~/Master/Default.Master"
    AutoEventWireup="True" Inherits="MZHMM.WebMM.Purchase.ROSInput" %>

<%@ MasterType VirtualPath="~/Master/Default.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>�����깺��</title>
    <script type="text/javascript" src="../JS/Common.js"></script>
    <script type="text/javascript" src="../JS/Purchase/ROSInput.js"></script>
    <link href="../CSS/Purchase/ROSInput.css" type="text/css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="AjaxHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BodyHolder" runat="server">
    <table id="Table2" class="myTableToolbar myTable" cellspacing="1" cellpadding="1" >
        <tr>
            <td colspan="4">
                <uc1:DocWebControl ID="doc1" runat="server"></uc1:DocWebControl>
            </td>
        </tr>
        <tr >
            <td width="15%">
                �������ɼ���;:<span class="required">*</span>
            </td>
            <td colspan="3" >
                <uc1:USWebControl ID="ddlPurpose" runat="server" ></uc1:USWebControl>
            </td>
            
        </tr>
        <tr >
            <td colspan="4">
                <uc1:ItemsWebControl ID="item1" runat="server"></uc1:ItemsWebControl>
            </td>
        </tr>
        <tr >
            <td colspan="4">
                <uc1:DocAuditWebControl ID="DocAuditWebControl1" runat="server"></uc1:DocAuditWebControl>
            </td>
        </tr>
        <tr >
            <td style="width: 10%">
                ���벿�ţ�
            </td>
            <td style="width: 40%">
                <uc1:StorageDropdownlist ID="ddlDept" runat="server"></uc1:StorageDropdownlist>
            </td>
            <td style="width: 10%">
                �����ˣ�
            </td>
            <td style="width: 40%">
                <asp:TextBox ID="txtProposer" runat="server" CssClass="undline"></asp:TextBox>
            </td>
        </tr>
        <tr class="myTrSubmitLine">
            <td colspan="4" class="td_Submit">
                <asp:Button ID="btnSave" runat="server" Text="����" AccessKey="S" 
                    ToolTip="���浥�ݣ����ǲ����ύ����" onclick="btnSave_Click">
                </asp:Button><asp:Button ID="btnPresent" runat="server" Text="�����ύ" AccessKey="P" 
                    ToolTip="���沢���ύ" onclick="btnPresent_Click">
                </asp:Button><asp:Button ID="btn2MRP" runat="server" Text="ת���¶ȼƻ�����" OnClick="btn2MRP_Click" Visible="false" /><asp:Button ID="btnCancel" runat="server" Text="ȡ��"
                    ToolTip="���ص����ҳ��" onclick="btnCancel_Click"></asp:Button>
            </td>
        </tr>
    </table>
</asp:Content>

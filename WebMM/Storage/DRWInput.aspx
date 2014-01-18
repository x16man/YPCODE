<%@ Page Language="c#" CodeBehind="DRWInput.aspx.cs" MasterPageFile="~/Master/Default.Master"
    AutoEventWireup="True" Inherits="MZHMM.WebMM.Storage.DRWInput" %>

<%@ MasterType VirtualPath="~/Master/Default.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>���ϵ�</title>
    <meta content="���ϵ�" name="keywords" />
    <link rel="stylesheet" type="text/css" href="../CSS/Storage/DRWInput.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="AjaxHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BodyHolder" runat="server">
    <table class="myTable myTableToolbar" id="Table1" cellspacing="1" cellpadding="1">
        <tr>
            <td colspan="4">
                <uc1:DocWebControl ID="doc1" runat="server"></uc1:DocWebControl>
            </td>
        </tr>
        <tr class="hidden">
            <td>
                ��;��<span class="required">*</span>
            </td>
            <td>
                <uc1:USWebControl ID="ddlPurpose" Visible="false" runat="server"></uc1:USWebControl>
            </td>
            <td>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td colspan="4" class="myItemControl">
                <uc1:DRWWebControl ID="item1" runat="server"></uc1:DRWWebControl>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <uc1:DocAuditWebControl ID="DocAuditWebControl1" runat="server"></uc1:DocAuditWebControl>
            </td>
        </tr>
        <tr>
            <td class="td_Label">
                ���ò��ţ�<span class="required">*</span>
            </td>
            <td class="td_Content" align="left">
                <uc1:StorageDropdownlist ID="ddlDept" runat="server" Width="100%"></uc1:StorageDropdownlist>
                    
            </td>
            <td class="td_Label">
                �����ˣ�<span class="required">*</span>
            </td>
            <td class="td_Content" align="left">
                <uc1:StorageDropdownlist ID="ddlProposer" runat="server" Width="100%"></uc1:StorageDropdownlist>
                    
            </td>
        </tr>
        <tr>
            <td>
                �����ˣ�
            </td>
            <td align="left">
                <asp:TextBox ID="TextBox1" CssClass="TextBox1 input" runat="server"></asp:TextBox>
            </td>
            <td>
                �������ڣ�
            </td>
            <td align="left">
                <asp:TextBox ID="TextBox2" CssClass="TextBox2 input" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr class="myTrSubmitLine">
            <td align="center" colspan="4" class="td_Submit">
                <input id="btnAddByDoc" onclick="window.open('../Storage/DRWSListBrowser.aspx?DeptCode='+GetDeptCode(),'���ϵ�������Դ','toolbar = no,location=no,directories=no,status=no,menubar=no,scrollbars=yes,resizable=no,copyhistory=no,width =640,height = 440,left='+(window.screen.width - 640)/2+',top='+(window.screen.height - 440)/2+'')"
                    type="button" value="�ɵ�������" name="btnAddByDoc" class="Commonbutton" runat="server">
                <asp:Button ID="btnRefuse" runat="server" Text="�ܾ�" OnClick="btnRefuse_Click"></asp:Button>
                <asp:Button ID="btnSave" runat="server" Text="����" OnClick="btnSave_Click"></asp:Button>
                <asp:Button ID="btnPresent" runat="server" Text="�����ύ" OnClick="btnPresent_Click">
                </asp:Button>
                <asp:Button ID="btnCancel" runat="server" Text="ȡ��" CausesValidation="False" OnClick="btnCancel_Click">
                </asp:Button>
                <asp:Button ID="btnToRos" Visible="false" runat="server" Text="�����빺��" OnClick="btnToRos_Click"></asp:Button>
            </td>
        </tr>
    </table>
    
    <div class="hidden">
        <asp:HiddenField ID="StaticInput" runat="server" OnValueChanged="StaticInput_ValueChanged" />
        <asp:HiddenField ID="txtParentEntryNo" runat="server" />
    </div>

    <script language="javascript" type="text/javascript">
			function GetDeptCode()
			{
				return "<%=Session["USERDEPTCODE"]%>";
			}
			function SetPurpose(ID)
			{
				
			}
    </script>

</asp:Content>

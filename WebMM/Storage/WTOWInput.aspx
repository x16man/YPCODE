<%@ Page Language="c#" CodeBehind="WTOWInput.aspx.cs" MasterPageFile="~/Master/Default.Master"
    AutoEventWireup="True" Inherits="MZHMM.WebMM.Storage.WTOWInput" %>

<%@ MasterType VirtualPath="~/Master/Default.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>���ϵ�</title>
    <meta content="���ϵ�" name="keywords" />
    <link rel="stylesheet" type="text/css" href="../CSS/Storage/WTOWInput.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="AjaxHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BodyHolder" runat="server">
    <table class="myTable myTableToolbar" id="Table1" cellspacing="1"  width="100%">
        <tr>
            <td colspan="4">
                <uc1:DocWebControl ID="doc1" runat="server"></uc1:DocWebControl>
            </td>
        </tr>
        <tr >
            <td class="td_Label">
                �������ɼ���;��<span class="required">*</span>
            </td>
            <td class="td_Content">
                <uc1:USWebControl ID="ddlPurpose" runat="server"></uc1:USWebControl>
            </td>
            <td class="td_label">
                Ҫ��������ڣ� <span class="required">*</span>
            </td>
            <td class="td_Content">
                <mzh:ToolbarCalendar ID="txtReqDate" ToolTip="Ҫ������"  ReadOnly="true"
                    runat="server" />
            </td>
        </tr>
        <tr >
            <td>
                �ӹ����ݣ�<span class="required">*</span>
            </td>
            <td colspan="3" align="left" style="word-wrap: break-word; word-break: break-all;">
                <asp:TextBox ID="txtProcessContent" CssClass="txtProcessContent textarea" 
                    runat="server" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr >
            <td style="width: 20%">
                ����
            </td>
            <td colspan="3">
                <table class="Table_Attachment" style="width: 100%" border="0">
                    <tr>
                        <td tyle="width:50%">
                            <table width="100%">
                                <tr>
                                    <td style="width: 20%">
                                        ͼֽ����
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtDrawingCount"  runat="server"></asp:TextBox>
                                        <asp:RangeValidator ID="RangeValidator1" Display="Dynamic" runat="server" ErrorMessage="��������ӦΪ������"
                                            ControlToValidate="txtDrawingCount" MinimumValue="0" MaximumValue="999"
                                            Type="Integer">��������ӦΪ������</asp:RangeValidator>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td tyle="width:50%">
                            <table width="100%">
                                <tr>
                                    <td style="width: 20%">
                                        ��������
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtProspectusCount" runat="server"></asp:TextBox>
                                          <asp:RangeValidator ID="RangeValidator2" Display="Dynamic" runat="server" ErrorMessage="��������ӦΪ������"
                                            ControlToValidate="txtProspectusCount"  MinimumValue="0" MaximumValue="999"
                                            Type="Integer">��������ӦΪ������</asp:RangeValidator>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr >
            <td colspan="4" class="myItemControl">
                <uc1:WTOWWebControl ID="item1" runat="server"></uc1:WTOWWebControl>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <uc1:DocAuditWebControl ID="DocAuditWebControl1" runat="server"></uc1:DocAuditWebControl>
            </td>
        </tr>
        <tr >
            <td>
                ���ò��ţ� <span class="required">*</span>
            </td>
            <td>
                <uc1:StorageDropdownlist ID="ddlDept" runat="server" Width="100%"></uc1:StorageDropdownlist>
            </td>
            <td>
                �����ˣ� <span class="required">*</span>
            </td>
            <td>
                <uc1:StorageDropdownlist ID="ddlProposer" runat="server" Width="100%"></uc1:StorageDropdownlist>
            </td>
        </tr>
        <tr >
            <td>
                �����ˣ�
            </td>
            <td>
                <asp:TextBox ID="TextBox1" CssClass="TextBox1 input" runat="server"></asp:TextBox>
            </td>
            <td>
                �������ڣ�
            </td>
            <td>
                <asp:TextBox ID="TextBox2" CssClass="TextBox2 input" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr class="myTrSubmitLine">
            <td class="td_Submit" colspan="4">
                <asp:Button ID="btnRefuse" runat="server" Text="�ܾ�" OnClick="btnRefuse_Click"></asp:Button>
                <asp:Button ID="btnSave" runat="server" Text="����" OnClick="btnSave_Click"></asp:Button>
                <asp:Button ID="btnPresent" runat="server" Text="�����ύ" OnClick="btnPresent_Click">
                </asp:Button>
                <asp:Button ID="btnCancel" runat="server" Text="ȡ��" CausesValidation="False" OnClick="btnCancel_Click">
                </asp:Button>
            </td>
        </tr>
    </table>
    
    <asp:HiddenField ID="txtParentEntryNo" runat="server" />
    <asp:HiddenField ID="StaticInput" runat="server" />
    <div class="hidden">
    </div>

    <script language="javascript" type="text/javascript">
				function GetDeptCode()
				{
					return "<%=Session["USERDEPTCODE"]%>";
				}
				
    </script>

</asp:Content>

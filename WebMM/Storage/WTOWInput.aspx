<%@ Page Language="c#" CodeBehind="WTOWInput.aspx.cs" MasterPageFile="~/Master/Default.Master"
    AutoEventWireup="True" Inherits="MZHMM.WebMM.Storage.WTOWInput" %>

<%@ MasterType VirtualPath="~/Master/Default.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>领料单</title>
    <meta content="领料单" name="keywords" />
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
                申请理由及用途：<span class="required">*</span>
            </td>
            <td class="td_Content">
                <uc1:USWebControl ID="ddlPurpose" runat="server"></uc1:USWebControl>
            </td>
            <td class="td_label">
                要求完成日期： <span class="required">*</span>
            </td>
            <td class="td_Content">
                <mzh:ToolbarCalendar ID="txtReqDate" ToolTip="要求日期"  ReadOnly="true"
                    runat="server" />
            </td>
        </tr>
        <tr >
            <td>
                加工内容：<span class="required">*</span>
            </td>
            <td colspan="3" align="left" style="word-wrap: break-word; word-break: break-all;">
                <asp:TextBox ID="txtProcessContent" CssClass="txtProcessContent textarea" 
                    runat="server" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr >
            <td style="width: 20%">
                附件
            </td>
            <td colspan="3">
                <table class="Table_Attachment" style="width: 100%" border="0">
                    <tr>
                        <td tyle="width:50%">
                            <table width="100%">
                                <tr>
                                    <td style="width: 20%">
                                        图纸数：
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtDrawingCount"  runat="server"></asp:TextBox>
                                        <asp:RangeValidator ID="RangeValidator1" Display="Dynamic" runat="server" ErrorMessage="输入类型应为数字型"
                                            ControlToValidate="txtDrawingCount" MinimumValue="0" MaximumValue="999"
                                            Type="Integer">输入类型应为数字型</asp:RangeValidator>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td tyle="width:50%">
                            <table width="100%">
                                <tr>
                                    <td style="width: 20%">
                                        样张数：
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtProspectusCount" runat="server"></asp:TextBox>
                                          <asp:RangeValidator ID="RangeValidator2" Display="Dynamic" runat="server" ErrorMessage="输入类型应为数字型"
                                            ControlToValidate="txtProspectusCount"  MinimumValue="0" MaximumValue="999"
                                            Type="Integer">输入类型应为数字型</asp:RangeValidator>
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
                领用部门： <span class="required">*</span>
            </td>
            <td>
                <uc1:StorageDropdownlist ID="ddlDept" runat="server" Width="100%"></uc1:StorageDropdownlist>
            </td>
            <td>
                领用人： <span class="required">*</span>
            </td>
            <td>
                <uc1:StorageDropdownlist ID="ddlProposer" runat="server" Width="100%"></uc1:StorageDropdownlist>
            </td>
        </tr>
        <tr >
            <td>
                发料人：
            </td>
            <td>
                <asp:TextBox ID="TextBox1" CssClass="TextBox1 input" runat="server"></asp:TextBox>
            </td>
            <td>
                发料日期：
            </td>
            <td>
                <asp:TextBox ID="TextBox2" CssClass="TextBox2 input" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr class="myTrSubmitLine">
            <td class="td_Submit" colspan="4">
                <asp:Button ID="btnRefuse" runat="server" Text="拒绝" OnClick="btnRefuse_Click"></asp:Button>
                <asp:Button ID="btnSave" runat="server" Text="保存" OnClick="btnSave_Click"></asp:Button>
                <asp:Button ID="btnPresent" runat="server" Text="马上提交" OnClick="btnPresent_Click">
                </asp:Button>
                <asp:Button ID="btnCancel" runat="server" Text="取消" CausesValidation="False" OnClick="btnCancel_Click">
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

<%@ Page Language="c#" CodeBehind="UnitInput.aspx.cs" Title="度量单位维护" MasterPageFile="~/Master/Default.Master"
    AutoEventWireup="True" Inherits="MZHMM.WebMM.Storage.UnitInput" %>

<%@ MasterType VirtualPath="~/Master/Default.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>度量单位维护</title>
    <link href="../CSS/ManageCommon.css" type="text/css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="AjaxHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BodyHolder" runat="server">
    <table class="managertable" border="1">
        <tr>
            <td colspan="4">
                <mzh:MzhToolbar ID="MzhToolbar1" runat="server" OnItemPostBack="MzhToolbar1_ItemPostBack">
                    <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable"
                        itemid="Edit" cellspacing="0" nakedlabelclass="nakedLabelCell" isshowtext="True"
                        iconclass="add" hasicon="True" text="保存" id="toolbarButtonAdd" autopostback="True">
                    </mzh:toolbarbutton>
                    <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable"
                        itemid="Edit" cellspacing="0" nakedlabelclass="nakedLabelCell" isshowtext="True"
                        iconclass="edit" hasicon="True" text="保存" id="toolbarButtonedit" autopostback="True">
                    </mzh:toolbarbutton>
                    <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable"
                        itemid="Edit" cellspacing="0" nakedlabelclass="nakedLabelCell" isshowtext="True"
                        iconclass="pre" hasicon="True" text="取消" id="toolbarButtoncancel" onclick="document.location = 'UnitBrowser.aspx'">
                    </mzh:toolbarbutton>
                </mzh:MzhToolbar>
            </td>
        </tr>
        <tr class="managertr">
            <td class="titletd">
                <span class="required">*</span>单位编号
            </td>
            <td class="contenttd">
                <asp:TextBox ID="txtCode" runat="server" ToolTip="单位编号(1-32767),不能重复"></asp:TextBox><asp:RequiredFieldValidator
                    ID="RFVCode" runat="server" Display="Dynamic" ControlToValidate="txtCode" ErrorMessage="单位编号必须输入">单位编号必须输入</asp:RequiredFieldValidator><asp:RangeValidator
                        ID="RVCode" runat="server" Display="Dynamic" ControlToValidate="txtCode" ErrorMessage="数字范围为(1-32767)"
                        MinimumValue="1" MaximumValue="32767" Type="Integer">数字范围为(1-32767)</asp:RangeValidator>
            </td>
            <td class="titletd">
                <span class="required">*</span>单位缩写
            </td>
            <td class="contenttd">
                <asp:TextBox ID="txtAbbreviate" runat="server" ToolTip="单位缩写" MaxLength="5"></asp:TextBox><asp:RequiredFieldValidator
                    ID="RFVAbb" runat="server" Display="Dynamic" ControlToValidate="txtAbbreviate"
                    ErrorMessage="单位缩写必须输入">单位缩写必须输入</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr class="managertr">
            <td>
                <span class="required">*</span>单位名称
            </td>
            <td colspan="3" align="left">
                <asp:TextBox ID="txtDescription" runat="server" ToolTip="请输入单位名称" MaxLength="10"></asp:TextBox><asp:RequiredFieldValidator
                    ID="RFVDes" runat="server" Display="Dynamic" ControlToValidate="txtDescription"
                    ErrorMessage="单位名称必须输入">单位名称必须输入</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr class="managertr">
            <td>
                单位等值
            </td>
            <td colspan="3" align="left">
                <asp:TextBox ID="txtEquivalence" runat="server" MaxLength="20"></asp:TextBox><asp:RangeValidator
                    ID="RangeValidator1" runat="server" Display="Dynamic" ControlToValidate="txtEquivalence"
                    ErrorMessage="输入为数字型" Type="Double" MaximumValue="9999999999999"
                    MinimumValue="-999999999999">输入为-9999999999999到9999999999999数字型</asp:RangeValidator>
            </td>
        </tr>
        <tr class="managertr">
            <td>
                换算(中国)
            </td>
            <td colspan="3" align="left">
                <asp:TextBox ID="txtConversion" runat="server" MaxLength="10"></asp:TextBox><asp:RangeValidator
                    ID="RangeValidator2" runat="server" Display="Dynamic" ControlToValidate="txtConversion"
                    ErrorMessage="输入为数字型" Type="Double" MaximumValue="9999999999999999999999999999999999"
                    MinimumValue="-99999999999999999999999999999">输入为数字型</asp:RangeValidator>
            </td>
        </tr>
        <tr class="managertr">
            <td>
                换算单位
            </td>
            <td colspan="3" align="left">
                <asp:TextBox ID="txtConUnit" runat="server" MaxLength="20"></asp:TextBox>
            </td>
        </tr>
        <tr class="managertr">
            <td>
                单位类型
            </td>
            <td colspan="3" align="left">
                <asp:DropDownList ID="DropDownList1" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr class="managertr">
            <td colspan="4">
            </td>
        </tr>
    </table>
    <div class="hidden">
        <asp:Button ID="refresh" runat="server" Text="Button"></asp:Button>
    </div>
</asp:Content>

<%@ Page Language="c#" CodeBehind="PurposeInput.aspx.cs" Title="用途维护" MasterPageFile="~/Master/Default.Master"
    AutoEventWireup="True" Inherits="MZHMM.WebMM.Storage.PurposeInput" %>

<%@ MasterType VirtualPath="~/Master/Default.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>用途维护</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="AjaxHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BodyHolder" runat="server">
    <table cellspacing="1" cellpadding="3" width="100%" border="1" style="word-break: break-all">
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
                        iconclass="pre" hasicon="True" text="取消" id="toolbarButtoncancel" onclick="document.location = 'PurposeBrowser.aspx'">
                    </mzh:toolbarbutton>
                </mzh:MzhToolbar>
            </td>
        </tr>
        <tr style="height: 25px">
            <td style="width: 20%">
                <span class="required">*</span>用途代码
            </td>
            <td style="width: 30%" align="left">
                <asp:TextBox ID="txtCode" runat="server" ToolTip="用途代码(最多15位),不能重复。" MaxLength="15"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RFVCode" runat="server" ErrorMessage="用途代码必须输入" ControlToValidate="txtCode"
                    Display="Dynamic">用途代码必须输入</asp:RequiredFieldValidator>
                <asp:HiddenField ID="txtOldCode" runat="server" />
            </td>
            <td style="width: 20%">
                所属分类
            </td>
            <td style="width: 30%" align="left">
                <asp:DropDownList ID="dllUsingClassify" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr style="height: 25px">
            <td>
                工程编号
            </td>
            <td align="left">
                <asp:TextBox ID="txtProjectCode" runat="server" MaxLength="20" ToolTip="请输入工程编号"></asp:TextBox>
            </td>
            <td>
                年份
            </td>
            <td align="left">
                <asp:TextBox ID="txtthisYear" runat="server" ToolTip="请输入当前年份"></asp:TextBox>
            </td>
        </tr>
        <tr style="height: 25px">
            <td>
                <span class="required">*</span>用途描述
            </td>
            <td colspan="3" align="left">
                <asp:TextBox ID="txtDescription" runat="server" MaxLength="30" ToolTip="请输入用途描述"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RFVDes" runat="server" ErrorMessage="用途描述必须输入" ControlToValidate="txtDescription"
                    Display="Dynamic">用途描述必须输入</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr style="height: 25px">
            <td>
                目标科目
            </td>
            <td colspan="3" align="left">
                <asp:TextBox ID="txtTargetAcc" runat="server" MaxLength="20"></asp:TextBox>
            </td>
        </tr>
        <tr style="height: 25px">
            <td>
                是否有效
            </td>
            <td colspan="3" align="left">
                <asp:CheckBox ID="chkEnable" runat="server"></asp:CheckBox>
            </td>
        </tr>
        <tr style="height: 25px">
            <td>
                是否申请用
            </td>
            <td colspan="3" align="left">
                <asp:CheckBox ID="chkFlag" runat="server"></asp:CheckBox>
            </td>
        </tr>
        <tr style="height: 25px">
            <td colspan="3">
            </td>
        </tr>
    </table>
    <div class="hidden">
        <asp:Button ID="refresh" runat="server" Text="Button"></asp:Button>
        <asp:Button ID="btnSubmit" runat="server" Text="提交" CssClass="button" onmouseover="this.className='buttonMouseOver'"
            onmouseout="this.className='button'" OnClick="btnSubmit_Click"></asp:Button>
        <asp:Button ID="btnCancel" runat="server" Text="取消" CausesValidation="False" CssClass="button"
            onmouseover="this.className='buttonMouseOver'" onmouseout="this.className='button'"
            OnClick="btnCancel_Click"></asp:Button>
    </div>
</asp:Content>

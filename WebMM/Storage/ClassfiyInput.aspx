<%@ Page Language="c#" CodeBehind="ClassfiyInput.aspx.cs" Title="用途分类维护" AutoEventWireup="True"
    MasterPageFile="~/Master/Default.Master" Inherits="MZHMM.WebMM.Storage.ClassfiyInput" %>

<%@ MasterType VirtualPath="~/Master/Default.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>用途分类录入</title>
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
                        iconclass="pre" hasicon="True" text="取消" id="toolbarButtoncancel" onclick="document.location = 'ClassifyBrowser.aspx'">
                    </mzh:toolbarbutton>
                </mzh:MzhToolbar>
            </td>
        </tr>
        <tr style="height: 25px">
            <td style="width: 20%">
                用途分类代码
            </td>
            <td style="width: 30%" align="left">
                <asp:TextBox ID="txtCode" runat="server" ToolTip="用途分类代码(最多15位),不能重复。" MaxLength="15"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RFVCode" runat="server" ErrorMessage="用途分类代码必须输入"
                    ControlToValidate="txtCode" Display="Dynamic">用途分类代码必须输入</asp:RequiredFieldValidator>
                <asp:HiddenField ID="txtOldCode" runat="server" />
            </td>
            <td style="width: 20%">
                所属分类
            </td>
            <td style="width: 30%" align="left">
                <asp:DropDownList ID="dllParentClassify" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr style="height: 25px">
            <td>
                用途分类描述
            </td>
            <td colspan="3" align="left">
                <asp:TextBox ID="txtDescription" runat="server" MaxLength="30" ToolTip="请输入用途分类描述"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RFVDes" runat="server" ErrorMessage="用途描述必须输入" ControlToValidate="txtDescription"
                    Display="Dynamic">用途描述必须输入</asp:RequiredFieldValidator>
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
    </table>
    <div class="hidden">
        <asp:Button ID="refresh" runat="server" Text="Button"></asp:Button>
        <asp:Button ID="btnSubmit" runat="server" Text="提交"></asp:Button>
        <asp:Button ID="btnCancel" runat="server" Text="取消" CausesValidation="False"></asp:Button>
    </div>
</asp:Content>

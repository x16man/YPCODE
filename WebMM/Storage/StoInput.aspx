<%@ Page Language="c#" CodeBehind="StoInput.aspx.cs" Title="仓库维护" MasterPageFile="~/Master/Default.Master"
    AutoEventWireup="True" Inherits="MZHMM.WebMM.Storage.StoInput" %>

<%@ MasterType VirtualPath="~/Master/Default.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>仓库维护</title>
    <link href="../CSS/ManageCommon.css" type="text/css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="AjaxHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BodyHolder" runat="server">
    <table border="1" class="managertable">
        <tr>
            <td colspan="2">
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
                        iconclass="pre" hasicon="True" text="取消" id="toolbarButtoncancel" onclick="document.location = 'StoBrowser.aspx'">
                    </mzh:toolbarbutton>
                </mzh:MzhToolbar>
            </td>
        </tr>
        <tr class="managertr">
            <td class="titletd">
                <span class="required">*</span>仓库编号
            </td>
            <td style="width: 80%" align="left">
                <asp:TextBox ID="txtCode" runat="server" MaxLength="2" ToolTip="仓库编号(最多2位),不能重复。"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RFVCode" runat="server" ErrorMessage="仓库编号必须输入" ControlToValidate="txtCode"
                    Display="Dynamic">仓库编号必须输入</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr class="managertr">
            <td>
               <span class="required">*</span> 仓库名称
            </td>
            <td align="left">
                <asp:TextBox ID="txtDescription" runat="server" MaxLength="20" ToolTip="请输入仓库名称"></asp:TextBox>
                <asp:HiddenField ID="OldDesc" runat="server" />
                <asp:RequiredFieldValidator ID="RFVDes" runat="server" ErrorMessage="仓库名称必须输入" ControlToValidate="txtDescription"
                    Display="Dynamic">仓库名称必须输入</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr class="managertr">
            <td>
                库存科目
            </td>
            <td align="left">
                <asp:TextBox ID="txtStorageAcc" runat="server" MaxLength="20"></asp:TextBox>
            </td>
        </tr>
        <tr class="managertr">
            <td>
                转帐科目
            </td>
            <td align="left">
                <asp:TextBox ID="txtTransferAcc" runat="server" MaxLength="20"></asp:TextBox>
            </td>
        </tr>
        <tr class="managertr">
            <td>
                退货科目
            </td>
            <td align="left">
                <asp:TextBox ID="txtReturnAcc" runat="server" MaxLength="20"></asp:TextBox>
            </td>
        </tr>
        <tr class="managertr">
            <td>
                地址
            </td>
            <td align="left">
                <asp:TextBox ID="txtAddress" runat="server" MaxLength="50"></asp:TextBox>
            </td>
        </tr>
        <tr class="managertr">
            <td>
                联系人
            </td>
            <td align="left">
                <asp:TextBox ID="txtRelation" runat="server" MaxLength="20"></asp:TextBox>
            </td>
        </tr>
    </table>
    <div class="hidden">
        <asp:Button ID="refresh" runat="server" Text="Button"></asp:Button>
    </div>
</asp:Content>

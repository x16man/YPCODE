<%@ Page Language="c#" CodeBehind="CategroyInput.aspx.cs" Title="物料分类维护" AutoEventWireup="True"
    MasterPageFile="~/Master/Default.Master" Inherits="MZHMM.WebMM.Storage.CategroyInput" %>

<%@ MasterType VirtualPath="~/Master/Default.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 <link href="../CSS/ManageCommon.css" type="text/css" rel="stylesheet" />
    <title>物料分类维护</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="AjaxHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BodyHolder" runat="server">
    <table class="managertable" border="1">
        <tr class="managertr">
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
                        iconclass="pre" hasicon="True" text="取消" id="toolbarButtoncancel" onclick="document.location = 'CategroyBrowser.aspx'">
                    </mzh:toolbarbutton>
                </mzh:MzhToolbar>
            </td>
        </tr>
        <tr class="managertr">
            <td  class="titletd">
                <span class="required">*</span>分类编号
            </td>
            <td class="contenttd">
                <asp:TextBox ID="txtCode" runat="server" ToolTip="分类编号(1-99),不能重复" MaxLength="2"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RFVCode" runat="server" ErrorMessage="分类编号必须输入" ControlToValidate="txtCode"
                    Display="Dynamic">分类编号必须输入</asp:RequiredFieldValidator>
                <asp:RangeValidator ID="RVCode" runat="server" ErrorMessage="数字范围为(1-99)" Type="Integer"
                    ControlToValidate="txtCode" MaximumValue="32767" MinimumValue="1" Display="Dynamic">字范围为(1-32767)</asp:RangeValidator>
            </td>
            <td class="titletd">
                <span class="required">*</span>显示顺序
            </td>
            <td class="contenttd">
                <asp:TextBox ID="txtSerial" runat="server" ToolTip="显示顺序(1-32767)"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RFVSerial" runat="server" ErrorMessage="显示顺序必须输入"
                    ControlToValidate="txtSerial" Display="Dynamic">显示顺序必须输入</asp:RequiredFieldValidator><asp:RangeValidator
                        ID="RVSerial" runat="server" ErrorMessage="数字范围为(1-32767)" Type="Integer" ControlToValidate="txtSerial"
                        MaximumValue="32767" MinimumValue="1" Display="Dynamic">数字范围为(1-32767)</asp:RangeValidator>
            </td>
        </tr>
        <tr class="managertr">
            <td>
                <span class="required">*</span>分类名称
            </td>
            <td colspan="3" align="left">
                <asp:TextBox ID="txtDescription" runat="server" MaxLength="30" ToolTip="请输入分类描述"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RFVDes" runat="server" ErrorMessage="分类名称必须输入" ControlToValidate="txtDescription"
                    Display="Dynamic">分类名称必须输入</asp:RequiredFieldValidator>
                  
            </td>
        </tr>
        <tr class="managertr">
            <td>
                库存科目
            </td>
            <td colspan="3" align="left">
                <asp:TextBox ID="txtStorageAcc" runat="server" MaxLength="20"></asp:TextBox>
            </td>
        </tr>
        <tr class="managertr">
            <td>
                转帐科目
            </td>
            <td colspan="3" align="left">
                <asp:TextBox ID="txtTransferAcc" runat="server" MaxLength="20"></asp:TextBox>
            </td>
        </tr>
        <tr class="managertr">
            <td>
                退货科目
            </td>
            <td colspan="3" align="left">
                <asp:TextBox ID="txtReturnAcc" runat="server" MaxLength="20"></asp:TextBox>
            </td>
        </tr>
        <tr class="managertr">
            <td>
                备注
            </td>
            <td colspan="3" align="left">
                <asp:TextBox ID="txtRemark" runat="server" TextMode="MultiLine" Rows="5" MaxLength="25"></asp:TextBox>
                  <asp:RegularExpressionValidator ID="RegularExpressionValidator1" Display="Dynamic" ControlToValidate="txtRemark"
                        runat="server" ValidationExpression="(\w|\W){1,25}" ErrorMessage="描述所填字数不能大于25" >
                        </asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr class="managertr">
            <td class="td_SubmitLine" colspan="4">
            </td>
        </tr>
    </table>
    <div class="hidden">
        <asp:Button ID="refresh" runat="server" Text="Button"></asp:Button>
       
        <asp:Button ID="btnCancel" runat="server" Text="取消" CausesValidation="False" CssClass="button"
            onmouseover="this.className='buttonMouseOver'" onmouseout="this.className='button'"
            OnClick="btnCancel_Click"></asp:Button>
    </div>
</asp:Content>

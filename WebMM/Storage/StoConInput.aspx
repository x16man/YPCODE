<%@ Page Language="c#" CodeBehind="StoConInput.aspx.cs" Title="仓库架位维护" AutoEventWireup="True" MasterPageFile="~/Master/Default.Master"
    Inherits="MZHMM.WebMM.Storage.StoConInput" %>

<%@ MasterType VirtualPath="~/Master/Default.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>仓库架位维护</title>
    <script language="javascript">
        function CancelGo() {
            
            var url = "StoConBrowser.aspx?StoCode=" + <%= StoCode%>;
          
            document.location =url;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="AjaxHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BodyHolder" runat="server">
    <table cellspacing="1" cellpadding="3" width="100%" border="1" style="word-break: break-all">
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
                        iconclass="pre" hasicon="True" text="取消" id="toolbarButtoncancel" onclick="CancelGo()">
                    </mzh:toolbarbutton>
                </mzh:MzhToolbar>
            </td>
        </tr>
        <tr style="height: 25px">
            <td style="width: 20%">
                架位名称<span class="required">*</span>
            </td>
            <td style="width: 30%" align="left">
                <asp:TextBox ID="txtDescription" runat="server" ToolTip="请输入仓库架位名称" MaxLength="20"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RFVDes" runat="server" Display="Dynamic" ControlToValidate="txtDescription"
                    ErrorMessage="仓库架位描述必须输入">仓库架位架位名称必须输入</asp:RequiredFieldValidator>
                <asp:HiddenField ID="txtCode" runat="server" />
            </td>
        </tr>
        <tr style="height: 25px">
            <td>
                所属仓库编号
            </td>
            <td align="left">
                <asp:TextBox ID="txtStoCode" runat="server" MaxLength="10" Enabled="False"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RFVStoCode" runat="server" Display="Dynamic" ControlToValidate="txtDescription"
                    ErrorMessage="所属仓库必须输入">所属仓库必须输入</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr style="height: 25px">
            <td>
                仓库面积
            </td>
            <td align="left">
                <asp:TextBox ID="txtStoArea" runat="server" MaxLength="10"></asp:TextBox>
                <asp:RangeValidator ID="RangeValidator1" runat="server" Display="Dynamic" ControlToValidate="txtStoArea"
                    ErrorMessage="架位面积要输入数字" MinimumValue="0" MaximumValue="1000000000" Type="Double">架位面积要输入0到1000000000之间数字</asp:RangeValidator>
            </td>
        </tr>
        <tr style="height: 25px">
            <td class="td_Submit" colspan="4">
            </td>
        </tr>
    </table>
    <div class="hidden">
        <asp:Button ID="refresh" runat="server" Text="Button"></asp:Button>
        <asp:Button ID="btnSubmit" runat="server" Text="提交"></asp:Button>
        <asp:Button ID="btnCancel" runat="server" Text="取消" CausesValidation="False" 
             OnClick="btnCancel_Click"></asp:Button>
    </div>
</asp:Content>

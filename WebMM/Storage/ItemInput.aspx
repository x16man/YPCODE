<%@ Page Language="c#" CodeBehind="ItemInput.aspx.cs" Title="物料信息维护" MasterPageFile="~/Master/Default.Master"
    AutoEventWireup="True" Inherits="MZHMM.WebMM.Storage.ItemInput" %>

<%@ MasterType VirtualPath="~/Master/Default.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>物料信息维护</title>
    <link href="../CSS/ManageCommon.css" type="text/css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="AjaxHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BodyHolder" runat="server">
    <table class="managertable" border="1">
        <tr>
            <td colspan="4">
                <mzh:MzhToolbar ID="MzhToolbar1" runat="server" 
                    onitempostback="MzhToolbar1_ItemPostBack">
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
                        iconclass="pre" hasicon="True" text="取消" id="toolbarButtoncancel" onclick="document.location = 'ItemBrowser.aspx'">
                    </mzh:toolbarbutton>
                </mzh:MzhToolbar>
            </td>
        </tr>
        <tr  class="managertr">
            <td class="titletd">
                <span class="required">*</span>物料编号：
            </td>
            <td  class="contenttd">
                <asp:TextBox ID="txtCode" runat="server" MaxLength="20" style="width:50%"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RFVCode" runat="server" ErrorMessage="物料编号必须输入" ControlToValidate="txtCode"
                    Display="Dynamic">物料编号必须输入</asp:RequiredFieldValidator>
                <asp:Button ID="Button1" runat="server" Text="推荐编号" CausesValidation="False" 
                  
                    OnClick="Button1_Click"></asp:Button>
            </td>
            <td class="titletd">
                新编号：
            </td>
            <td  class="contenttd">
                <asp:TextBox ID="txtNewCode" runat="server" MaxLength="50" style="width:50%"></asp:TextBox>
            </td>
        </tr>
        <tr  class="managertr">
            <td class="titletd">
                <span class="required">*</span>物料分类：
            </td>
            <td class="contenttd">
                <uc1:StorageDropdownlist ID="ddlCategory" runat="server"></uc1:StorageDropdownlist>
            </td>
            <td>
                <span class="required">*</span>中文名称：
            </td>
            <td  align="left">
                <asp:TextBox ID="txtCnName" runat="server" MaxLength="30" ToolTip="请输入物料描述"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="物料名称必须输入"
                    ControlToValidate="txtCnName">物料名称必须输入</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr class="managertr">
            <td>
                英文名称：
            </td>
            <td align="left">
                <asp:TextBox ID="txtEnName" runat="server" MaxLength="30"></asp:TextBox>
            </td>
            <td>
                物料状态：
            </td>
            <td align="left">
                <uc1:StorageDropdownlist ID="ddlItemState" runat="server"></uc1:StorageDropdownlist>
            </td>
        </tr>
        <tr class="managertr">
            <td>
                规格型号：
            </td>
            <td align="left">
                <asp:TextBox ID="txtSpecial" runat="server" MaxLength="30"></asp:TextBox>
            </td>
            <td>
                <span class="required">*</span>计量单位：
            </td>
            <td align="left">
                <uc1:StorageDropdownlist ID="ddlUnit" runat="server"></uc1:StorageDropdownlist>
            </td>
        </tr>
        <tr class="managertr">
            <td>
                制购属性：
            </td>
            <td align="left">
                <uc1:StorageDropdownlist ID="ddlPurMak" runat="server"></uc1:StorageDropdownlist>
            </td>
            <td>
                批号跟踪：
            </td>
            <td align="left">
                <asp:RadioButtonList ID="rblBatch" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Value="Y">是</asp:ListItem>
                    <asp:ListItem Value="N" Selected="True">否</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr class="managertr">
            <td>
                是否检验：
            </td>
            <td align="left">
                <asp:RadioButtonList ID="rblCheck" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Value="Y" Selected="True">是</asp:ListItem>
                    <asp:ListItem Value="N">否</asp:ListItem>
                </asp:RadioButtonList>
            </td>
            <td>
                检验报告：
            </td>
            <td align="left">
                <uc1:StorageDropdownlist ID="ddlCheckReport" runat="server"></uc1:StorageDropdownlist>
            </td>
        </tr>
        <tr class="managertr">
            <td>
                ABC分类：
            </td>
            <td align="left">
                <uc1:StorageDropdownlist ID="ddlABC" runat="server"></uc1:StorageDropdownlist>
            </td>
            <td>
                成本价格：
            </td>
            <td align="left">
                <asp:TextBox ID="txtCstPrice" runat="server" MaxLength="10" ReadOnly="True"></asp:TextBox>
                <asp:RangeValidator ID="RangeValidator1" Display="Dynamic" runat="server" ErrorMessage="输入类型应为数字型"
                    ControlToValidate="txtCstPrice" MinimumValue="-99999999999999999" MaximumValue="9999999999999999999999999"
                    Type="Double">输入类型应为数字型</asp:RangeValidator>
            </td>
        </tr>
        <tr class="managertr">
            <td>
                评估价格：
            </td>
            <td align="left">
                <asp:TextBox ID="txtEvPrice" runat="server" MaxLength="10"></asp:TextBox><asp:RangeValidator
                    ID="RangeValidator2" runat="server" Display="Dynamic" ErrorMessage="输入类型应为数字型" ControlToValidate="txtEvPrice"
                    MinimumValue="-9999999999999999999999" MaximumValue="99999999999999999999999"
                    Type="Double">输入类型应为数字型</asp:RangeValidator>
            </td>
            <td>
                总帐方式：
            </td>
            <td align="left">
                <uc1:StorageDropdownlist ID="ddlAccount" runat="server"></uc1:StorageDropdownlist>
            </td>
        </tr>
        <tr class="managertr">
            <td>
                最高存量：
            </td>
            <td align="left">
                <asp:TextBox ID="txtUppNum" runat="server" MaxLength="10"></asp:TextBox><asp:RangeValidator Display="Dynamic"
                    ID="RangeValidator3" runat="server" ErrorMessage="输入类型应为数字型" ControlToValidate="txtUppNum"
                    MinimumValue="-99999999999999999" MaximumValue="9999999999999999999999" Type="Double">输入类型应为数字型</asp:RangeValidator>
            </td>
            <td>
                最低存量：
            </td>
            <td align="left">
                <asp:TextBox ID="txtLowNum" runat="server" MaxLength="10"></asp:TextBox><asp:RangeValidator
                    ID="RangeValidator7" runat="server" Display="Dynamic" ErrorMessage="输入类型应为数字型" ControlToValidate="txtLowNum"
                    MinimumValue="-999999999999999999999" MaximumValue="9999999999999999999999" Type="Double">输入类型应为数字型</asp:RangeValidator>
            </td>
        </tr>
        <tr class="managertr">
            <td>
                安全存量：
            </td>
            <td align="left">
                <asp:TextBox ID="txtSafNum" CssClass="input" runat="server" MaxLength="10"></asp:TextBox><asp:RangeValidator
                    ID="RangeValidator4" runat="server" Display="Dynamic" ErrorMessage="输入类型应为数字型" ControlToValidate="txtSafNum"
                    MinimumValue="-99999999999999999" MaximumValue="99999999999999999999999" Type="Double">输入类型应为数字型</asp:RangeValidator>
            </td>
            <td>
                订货点：
            </td>
            <td align="left">
                <asp:TextBox ID="txtOrdNum" runat="server" MaxLength="10"></asp:TextBox><asp:RangeValidator
                    ID="RangeValidator6" runat="server" Display="Dynamic" ErrorMessage="输入类型应为数字型" ControlToValidate="txtOrdNum"
                    MinimumValue="-9999999999999999" MaximumValue="999999999999999999999999" Type="Double">输入类型应为数字型</asp:RangeValidator>
            </td>
        </tr>
        <tr class="managertr">
            <td>
                订货批量：
            </td>
            <td align="left"  valign="bottom">
                <asp:TextBox ID="txtBatch" runat="server" MaxLength="10"></asp:TextBox><asp:RangeValidator
                    ID="RangeValidator5" runat="server" Display="Dynamic" ErrorMessage="输入类型应为数字型" ControlToValidate="txtBatch"
                    MinimumValue="-99999999999999999" MaximumValue="9999999999999999999999" Type="Double">输入类型应为数字型</asp:RangeValidator>
            </td>
            <td >
                常规供应商：
            </td>
            <td align="left">
                <uc1:StorageDropdownlist ID="ddlProvider" runat="server"></uc1:StorageDropdownlist>
            </td>
        </tr>
        <tr class="managertr">
            <td>
                <span class="required">*</span>存放仓库：
            </td>
            <td align="left">
                <uc1:StorageDropdownlist ID="ddlStorage" runat="server"  AutoPostBack="true"></uc1:StorageDropdownlist>
            </td>
            <td>
                存放架位：
            </td>
            <td align="left">
                <uc1:StorageDropdownlist ID="ddlCon" runat="server"></uc1:StorageDropdownlist>
            </td>
        </tr>
        <tr>
            <td colspan="4" style="height: 10px">
                &nbsp;
            </td>
        </tr>
    </table>
    <div class="hidden">
        <asp:Button ID="refresh" runat="server" Text="Button"></asp:Button>
    </div>
</asp:Content>

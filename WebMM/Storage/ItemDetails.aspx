<%@ Page Language="c#" CodeBehind="ItemDetails.aspx.cs" Title="物料信息" MasterPageFile="~/Master/Default.Master"
    AutoEventWireup="True" Inherits="MZHMM.WebMM.ItemDetails" %>

<%@ MasterType VirtualPath="~/Master/Default.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../CSS/ManageCommon.css" type="text/css" rel="stylesheet" />
    <title>物料信息</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="AjaxHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BodyHolder" runat="server">
    <table class="managertable" border="1" >
        <tr class="managertr">
            <td  class="titletd">
                物料编号
            </td>
            <td class="contenttd">
                <asp:TextBox ID="txtCode" runat="server" CssClass="input_txtCode input" MaxLength="20"
                    ReadOnly="True"></asp:TextBox>
            </td>
            <td  class="titletd">
                新编号
            </td>
            <td class="contenttd">
                <asp:TextBox ID="txtNewCode" runat="server" CssClass="input_txtCode input" MaxLength="20"
                    ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
        <tr class="managertr">
            <td class="titletd">
                物料分类
            </td>
            <td class="contenttd">
                <asp:TextBox ID="txtCategory" runat="server" CssClass="input_txtCategory input" ReadOnly="True"></asp:TextBox>
            </td>
            <td >
                中文名称
            </td>
            <td align="left">
                <asp:TextBox ID="txtCnName" runat="server" CssClass="input_txtCnName input" ToolTip="请输入物料描述"
                    MaxLength="50" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
        <tr class="managertr">
            <td >
                英文名称
            </td>
            <td align="left">
                <asp:TextBox ID="txtEnName" runat="server" CssClass="input_txtEnName input" MaxLength="50"
                    ReadOnly="True"></asp:TextBox>
            </td>
            <td >
                物料状态
            </td>
            <td align="left">
                <asp:TextBox ID="txtItemState" runat="server" CssClass="input_txtItemState input" ReadOnly="true"
                   ></asp:TextBox>
                    <uc1:StorageDropdownlist ID="ddlItemState" Visible="false" runat="server"></uc1:StorageDropdownlist>
            </td>
        </tr>
        <tr class="managertr">
            <td>
                规格型号
            </td>
            <td align="left">
                <asp:TextBox ID="txtSpecial" runat="server" CssClass="input_txtSpecial input" MaxLength="30"
                    ReadOnly="True"></asp:TextBox>
            </td>
            <td>
                度量单位
            </td>
            <td align="left">
                <asp:TextBox ID="txtUnit" runat="server" CssClass="input_txtUnit input" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
        <tr class="managertr">
            <td>
                制购属性
            </td>
            <td align="left">
                <asp:TextBox ID="txtPurMak" runat="server" CssClass="input_txtPurMak input" ReadOnly="True"></asp:TextBox>
                <uc1:StorageDropdownlist ID="ddlPurMak" Visible="false" runat="server"></uc1:StorageDropdownlist>
            </td>
            <td>
                批号跟踪
            </td>
            <td align="left">
                <asp:TextBox ID="txtIsBatch" runat="server" CssClass="input_txtIsBatch input" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
        <tr class="managertr">
            <td>
                是否检验
            </td>
            <td align="left">
                <asp:TextBox ID="txtIsCheck" runat="server" CssClass="input_txtIsCheck input" ReadOnly="True"></asp:TextBox>
            </td>
            <td>
                检验报告
            </td>
            <td align="left">
                <asp:TextBox ID="txtCheckReport" runat="server" CssClass="input_txtCheckReport input"
                    ReadOnly="True"></asp:TextBox>
                    <uc1:StorageDropdownlist ID="ddlCheckReport" Visible="false" runat="server"></uc1:StorageDropdownlist>
            </td>
        </tr>
        <tr class="managertr">
            <td>
                ABC分类
            </td>
            <td align="left">
                <asp:TextBox ID="txtABC" runat="server" CssClass="input_txtABC input"></asp:TextBox>
                <uc1:StorageDropdownlist ID="ddlABC" runat="server" Visible="false"></uc1:StorageDropdownlist>
            </td>
            <td>
                成本价格
            </td>
            <td align="left">
                <asp:TextBox ID="txtCstPrice" runat="server" CssClass="input_txtCstPrice input" MaxLength="10"></asp:TextBox>
            </td>
        </tr>
        <tr class="managertr">
            <td>
                评估价格
            </td>
            <td align="left">
                <asp:TextBox ID="txtEvPrice" runat="server" CssClass="input_txtEvPrice input" MaxLength="10"
                    ReadOnly="True"></asp:TextBox>
            </td>
            <td>
                总帐方式
            </td>
            <td align="left">
                <asp:TextBox ID="txtAccount" runat="server" CssClass="input_txtAccount input" ReadOnly="True"></asp:TextBox>
                <uc1:StorageDropdownlist ID="ddlAccount" runat="server" Visible="false"></uc1:StorageDropdownlist>
            </td>
        </tr>
        <tr class="managertr">
            <td>
                最高存量
            </td>
            <td align="left">
                <asp:TextBox ID="txtUppNum" runat="server" CssClass="input_txtUppNum input" MaxLength="10"
                    ReadOnly="True"></asp:TextBox>
            </td>
            <td>
                最低存量
            </td>
            <td align="left">
                <asp:TextBox ID="txtLowNum" runat="server" CssClass="input_txtLowNum input" MaxLength="10"
                    ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
        <tr class="managertr">
            <td>
                安全存量
            </td>
            <td align="left">
                <asp:TextBox ID="txtSafNum" runat="server" CssClass="input_txtSafNum input" MaxLength="10"
                    ReadOnly="True"></asp:TextBox>
            </td>
            <td>
                订货点
            </td>
            <td align="left">
                <asp:TextBox ID="txtOrdNum" runat="server" CssClass="input_txtOrdNum input" MaxLength="10"
                    ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
        <tr class="managertr">
            <td>
                订货批量
            </td>
            <td align="left">
                <asp:TextBox ID="txtBatch" runat="server" CssClass="input_txtBatch input" MaxLength="10"
                    ReadOnly="True"></asp:TextBox>
            </td>
            <td>
                常规供应商
            </td>
            <td align="left">
                <asp:TextBox ID="txtProvider" runat="server" CssClass="input_txtProvider  input"
                    ReadOnly="True"></asp:TextBox>
                    <uc1:StorageDropdownlist ID="ddlProvider" Visible="false"  runat="server"></uc1:StorageDropdownlist>
            </td>
        </tr>
        <tr class="managertr">
            <td>
                缺省存放仓库
            </td>
            <td align="left">
                <asp:TextBox ID="txtStorage" runat="server" CssClass="input_txtStorag input" ReadOnly="True"></asp:TextBox>
            </td>
            <td>
                缺省存放架位
            </td>
            <td align="left">
                <asp:TextBox ID="txtCon" runat="server" CssClass="input_txtCon input" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="4" align="center">
                <asp:Button ID="btnClose" Text="关闭" runat="server" OnClientClick="window.close(); " />
            </td>
        </tr>
    </table>
</asp:Content>

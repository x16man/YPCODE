<%@ Page Language="c#" CodeBehind="CategroyDetails.aspx.cs" Title="物料分类详细信息" AutoEventWireup="True"
    MasterPageFile="~/Master/Default.Master" Inherits="MZHMM.WebMM.Storage.CategroyDetails" %>

<%@ MasterType VirtualPath="~/Master/Default.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>物料分类详细信息</title>
    <link href="../CSS/ManageCommon.css" type="text/css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="AjaxHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BodyHolder" runat="server">
    <table class="managertable" border="1">
        <tr class="managertr">
            <td class="titletd">
                分类编号
            </td>
            <td class="contenttd">
                <asp:Label ID="txtCode" runat="server" ToolTip="分类编号(1-32767),不能重复"></asp:Label>
            </td>
            <td class="titletd">
                显示顺序
            </td>
            <td class="contenttd">
                <asp:Label ID="txtSerial" runat="server" ToolTip="显示顺序(1-32767)"></asp:Label>
            </td>
        </tr>
        <tr class="managertr">
            <td>
                分类名称
            </td>
            <td colspan="3" align="left">
                <asp:Label ID="txtDescription" runat="server" ToolTip="请输入分类描述"></asp:Label>
            </td>
        </tr>
        <tr class="managertr">
            <td>
                库存科目
            </td>
            <td colspan="3" align="left">
                <asp:Label ID="txtStorageAcc" runat="server"></asp:Label>
            </td>
        </tr>
        <tr class="managertr">
            <td>
                转帐科目
            </td>
            <td colspan="3" align="left">
                <asp:Label ID="txtTransferAcc" runat="server"></asp:Label>
            </td>
        </tr>
        <tr class="managertr">
            <td>
                退货科目
            </td>
            <td colspan="3" align="left">
                <asp:Label ID="txtReturnAcc" runat="server"></asp:Label>
            </td>
        </tr>
        <tr class="managertr">
            <td>
                备注
            </td>
            <td colspan="3" align="left">
                <asp:Label ID="txtRemark" runat="server" ></asp:Label>
            </td>
        </tr>
        <tr class="managertr">
            <td colspan="4">
                <asp:Button ID="btnClose" runat="server" Text="关闭" OnClientClick="window.close();" />
            </td>
        </tr>
        <tr class="managertr">
            <td colspan="4">
            </td>
        </tr>
    </table>
</asp:Content>

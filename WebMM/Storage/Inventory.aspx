<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inventory.aspx.cs" Inherits="WebMM.Storage.Inventory" %>
<html>
<head runat="server">
    <title></title>
    <link href="../CSS/Common.css" type="text/css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table>
            <tr>
                <td width="10%">名称：<span class="required">*</span>
                </td>
                <td><asp:TextBox runat="server" ID="txtName" Width="100%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>仓库：<span class="required">*</span>
                </td>
                <td><asp:DropDownList runat="server" ID="ddlSto" Width="100%" >
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>备注：
                </td>
                <td><asp:TextBox runat="server" ID="txtRemark" TextMode="MultiLine" Width="100%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <tr><td colspan="2" style="text-align:center"><asp:Button runat="server" ID="btnSave" Text="保存" 
                    onclick="btnSave_Click" /><input type="button" value="取消" onclick="window.close();"/></td></tr>
        </table>
    </div>
    </form>
</body>
</html>

<%@ Page Language="c#" CodeBehind="PslpInput.aspx.cs" Title="采购员维护" AutoEventWireup="True" MasterPageFile="~/Master/Default.Master"
    Inherits="MZHMM.WebMM.Purchase.PslpInput" %>

<%@ MasterType VirtualPath="~/Master/Default.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>采购员维护</title>
    <link href="../CSS/ManageCommon.css" type="text/css" rel="stylesheet" />

    <script type="text/javascript">
        var popupWindow = new PopupWindow();
        var userFlag; /*全局*/

        function OpenPerson() {
            //  alert('<%= Master.UserQueryPath %>');
            popupWindow.setUrl('<%= Master.UserQueryPath %>');
            popupWindow.setSize(250, 400);
            popupWindow.showPopup('UserPerson', false);
        }

        function setUserInfo(loginName, empCode, empName, deptCode, deptName) {

            document.getElementById("<%= txtDescription.ClientID%>").value = empName;
            document.getElementById("<%=txtCode.ClientID%>").value = empCode;
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="AjaxHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BodyHolder" runat="server">
    <mzh:MzhToolbar ID="MzhToolbar1" runat="server" OnItemPostBack="MzhToolbar1_ItemPostBack">
        <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable"
            itemid="Add" cellspacing="0" nakedlabelclass="nakedLabelCell" isshowtext="True"
            iconclass="add" hasicon="True" text="保存" id="toolbarButtonAdd" autopostback="True">
        </mzh:toolbarbutton>
        <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable"
            itemid="Edit" cellspacing="0" nakedlabelclass="nakedLabelCell" isshowtext="True"
            iconclass="pre" hasicon="True" text="取消" id="toolbarButtoncancel" onclick="document.location = 'PslpBrowser.aspx'">
        </mzh:toolbarbutton>
    </mzh:MzhToolbar>
    <table border="1" class="managertable">
        <tr class="managertr">
            <td class="titletd">
                <span class="required">*</span>采购员代码
            </td>
            <td align="left" style="width: 250">
                &nbsp;&nbsp;
                <table>
                    <tr>
                        <td>
                            <asp:TextBox ID="txtCode" runat="server" ToolTip="采购员代码(最多5位),不能重复。" MaxLength="5"
                                Width="80px"></asp:TextBox>
                        </td>
                        <td>
                            &nbsp;&nbsp;
                            <input type="button" id="UserPerson" value="选择人员" onclick="OpenPerson()" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                             <asp:RequiredFieldValidator ID="RFVCode" runat="server" ErrorMessage="采购员代码必须输入"
                    ControlToValidate="txtCode" Display="Dynamic">采购员代码必须输入</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                </table>
           
            </td>
        </tr>
        <tr class="managertr">
            <td class="titletd">
                <span class="required">*</span>采购员姓名
            </td>
            <td style="width: 80%" align="left">
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="txtDescription" runat="server" ToolTip="请输入采购员姓名" MaxLength="30"
                    Width="80px"></asp:TextBox>
                <br />
                <asp:RequiredFieldValidator ID="RFVDescription" runat="server" ErrorMessage="采购员姓名必须输入"
                    ControlToValidate="txtDescription" Display="Dynamic">采购员姓名必须输入</asp:RequiredFieldValidator>
            </td>
        </tr>
    </table>
</asp:Content>

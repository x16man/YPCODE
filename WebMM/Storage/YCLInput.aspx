<%@ Page Language="c#" CodeBehind="YCLInput.aspx.cs" MasterPageFile="~/Master/Default.Master" AutoEventWireup="True" Inherits="MZHMM.WebMM.Storage.YCLInput" %>

<%@ MasterType VirtualPath="~/Master/Default.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>物料分类录入</title>
    <link href="../CSS/Storage/YCLInput.css" type="text/css" rel="stylesheet" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="AjaxHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BodyHolder" runat="server">
    <table id="Table1" cellspacing="1" class="table_toolbar myTable"  width="100%">
        <tr class="myTrTitle">
            <td colspan="2">
                录入原材料收发记录
                <div class="hidden">
                    <asp:Button ID="refresh" runat="server" Text="Button"></asp:Button>
                </div>
            </td>
            <td>
                日期：
            </td>
            <td>
   
                     <mzh:ToolbarCalendar ID="txtDate" ReadOnly="true" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
            </td>
            <td>
            </td>
            <td>
            </td>
        </tr>
        <tr class="myTrSingularLine">
            <td align="left">
                物料名称:
            </td>
            <td colspan="3" align="left">
                <asp:DropDownList ID="DropDownList1" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr class="myTrDualLine">
            <td class="td_label" align="left">
                收入体积 
            </td>
            <td class="td_content" align="left">
                <asp:TextBox ID="txtInVolumn1" CssClass="input_txtInVolumn1 input" runat="server"
                    MaxLength="30"></asp:TextBox>
                    <asp:RangeValidator ID="RangeValidator2" Display="Dynamic" runat="server" ErrorMessage="收入体积应为0到9999999数字"
                                            ControlToValidate="txtInVolumn1"  MinimumValue="0" MaximumValue="9999999"
                                            Type="Double">收入体积应为0到9999999数字</asp:RangeValidator>
            </td>
            <td class="td_label" align="left">
                收入数量
            </td>
            <td class="td_content" align="left">
                <asp:TextBox ID="txtInNum1" CssClass="input_txtInNum1 input" runat="server" MaxLength="20"></asp:TextBox>
                <asp:RangeValidator ID="RangeValidator1" Display="Dynamic" runat="server" ErrorMessage="收入数量应为0到9999999数字"
                                            ControlToValidate="txtInNum1"  MinimumValue="0" MaximumValue="9999999"
                                            Type="Double">收入体积应为0到9999999数字</asp:RangeValidator>
            </td>
        </tr>
        <tr class="myTrDualLine">
            <td align="left">
                发出体积
            </td>
            <td align="left">
                <asp:TextBox ID="txtOutVolumn1" CssClass="input_txtOutVolumn1 input" runat="server"
                    MaxLength="20"></asp:TextBox>
                    <asp:RangeValidator ID="RangeValidator3" Display="Dynamic" runat="server" ErrorMessage="发出体积应为0到9999999数字"
                                            ControlToValidate="txtOutVolumn1"  MinimumValue="0" MaximumValue="9999999"
                                            Type="Double">发出体积应为0到9999999数字</asp:RangeValidator>
            </td>
            <td align="left">
                发出数量
            </td>
            <td align="left">
                <asp:TextBox ID="txtOutNum1" CssClass="input_txtOutNum1 input" runat="server" MaxLength="20"></asp:TextBox>
                <asp:RangeValidator ID="RangeValidator4" Display="Dynamic" runat="server" ErrorMessage="发出数量应为0到9999999数字"
                                            ControlToValidate="txtOutNum1"  MinimumValue="0" MaximumValue="9999999"
                                            Type="Double">发出数量应为0到9999999数字</asp:RangeValidator>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
            </td>
            <td>
            </td>
            <td>
            </td>
        </tr>
        <tr class="myTrSingularLine" >
            <td align="left">
                物料名称:
            </td>
            <td colspan="3" align="left">
                <asp:DropDownList ID="DropDownList2" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr class="myTrDualLine">
            <td align="left">
                收入体积
            </td>
            <td align="left">
                <asp:TextBox ID="txtInVolumn2" CssClass="input_txtInVolumn2 input" runat="server"
                    MaxLength="30"></asp:TextBox>
                    <asp:RangeValidator ID="RangeValidator5" Display="Dynamic" runat="server" ErrorMessage="收入体积应为0到9999999数字"
                                            ControlToValidate="txtInVolumn2"  MinimumValue="0" MaximumValue="9999999"
                                            Type="Double">收入体积应为0到9999999数字</asp:RangeValidator>
            </td>
            <td align="left">
                收入数量
            </td>
            <td align="left">
                <asp:TextBox ID="txtInNum2" CssClass="input_txtInNum2 input" runat="server" MaxLength="20"></asp:TextBox>
                <asp:RangeValidator ID="RangeValidator6" Display="Dynamic" runat="server" ErrorMessage="收入数量应为0到9999999数字"
                                            ControlToValidate="txtInNum2"  MinimumValue="0" MaximumValue="9999999"
                                            Type="Double">收入数量应为0到9999999数字</asp:RangeValidator>
            </td>
        </tr>
        <tr class="myTrDualLine">
            <td align="left">
                发出体积
            </td>
            <td align="left">
                <asp:TextBox ID="txtOutVolumn2" CssClass="input_txtOutVolumn2 input" runat="server"
                    MaxLength="20"></asp:TextBox>
                    <asp:RangeValidator ID="RangeValidator7" Display="Dynamic" runat="server" ErrorMessage="发出体积应为0到9999999数字"
                                            ControlToValidate="txtOutVolumn2"  MinimumValue="0" MaximumValue="9999999"
                                            Type="Double">发出体积应为0到9999999数字</asp:RangeValidator>
            </td>
            <td align="left">
                发出数量
            </td>
            <td align="left">
                <asp:TextBox ID="txtOutNum2" CssClass="input_txtOutNum2 input" runat="server" MaxLength="20"></asp:TextBox>
                <asp:RangeValidator ID="RangeValidator8" Display="Dynamic" runat="server" ErrorMessage="发出数量应为0到9999999数字"
                                            ControlToValidate="txtOutNum2"  MinimumValue="0" MaximumValue="9999999"
                                            Type="Double">发出数量应为0到9999999数字</asp:RangeValidator>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
            </td>
            <td>
            </td>
            <td>
            </td>
        </tr>
        <tr class="myTrSingularLine">
            <td align="left">
                物料名称:
            </td>
            <td colspan="3" align="left">
                <asp:DropDownList ID="DropDownList3" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr class="myTrDualLine">
            <td align="left">
                收入体积
            </td>
            <td align="left">
                <asp:TextBox ID="txtInVolumn3" CssClass="input_txtInVolumn3 input" runat="server"
                    MaxLength="30"></asp:TextBox>
                    <asp:RangeValidator ID="RangeValidator9" Display="Dynamic" runat="server" ErrorMessage="收入体积应为0到9999999数字"
                                            ControlToValidate="txtInVolumn3"  MinimumValue="0" MaximumValue="9999999"
                                            Type="Double">收入体积应为0到9999999数字</asp:RangeValidator>
            </td>
            <td align="left">
                收入数量
            </td>
            <td align="left">
                <asp:TextBox ID="txtInNum3" CssClass="input_txtInNum3 input" runat="server" MaxLength="20"></asp:TextBox>
                <asp:RangeValidator ID="RangeValidator10" Display="Dynamic" runat="server" ErrorMessage="收入数量应为0到9999999数字"
                                            ControlToValidate="txtInNum3"  MinimumValue="0" MaximumValue="9999999"
                                            Type="Double">收入数量应为0到9999999数字</asp:RangeValidator>
            </td>
        </tr>
        <tr class="myTrDualLine">
            <td align="left">
                发出体积
            </td>
            <td align="left">
                <asp:TextBox ID="txtOutVolumn3" CssClass="input_txtOutVolumn3 input" runat="server"
                    MaxLength="20"></asp:TextBox>
                    <asp:RangeValidator ID="RangeValidator11" Display="Dynamic" runat="server" ErrorMessage="发出体积应为0到9999999数字"
                                            ControlToValidate="txtOutVolumn3"  MinimumValue="0" MaximumValue="9999999"
                                            Type="Double">发出体积应为0到9999999数字</asp:RangeValidator>
            </td>
            <td align="left">
                发出数量
            </td>
            <td align="left">
                <asp:TextBox ID="txtOutNum3" CssClass="input_txtOutNum3 input" runat="server" MaxLength="20"></asp:TextBox>
                <asp:RangeValidator ID="RangeValidator12" Display="Dynamic" runat="server" ErrorMessage="发出数量应为0到9999999数字"
                                            ControlToValidate="txtOutNum3"  MinimumValue="0" MaximumValue="9999999"
                                            Type="Double">发出数量应为0到9999999数字</asp:RangeValidator>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
            </td>
            <td>
            </td>
            <td>
            </td>
        </tr>
        <tr class="myTrSingularLine">
            <td align="left">
                物料名称:
            </td>
            <td colspan="3" align="left">
                <asp:DropDownList ID="DropDownList4" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr class="myTrDualLine">
            <td align="left">
                收入体积
            </td>
            <td align="left">
                <asp:TextBox ID="txtInVolumn4" CssClass="input_txtInVolumn4 input" runat="server"
                    MaxLength="30"></asp:TextBox>
                    <asp:RangeValidator ID="RangeValidator13" Display="Dynamic" runat="server" ErrorMessage="收入体积应为0到9999999数字"
                                            ControlToValidate="txtInVolumn4"  MinimumValue="0" MaximumValue="9999999"
                                            Type="Double">收入体积应为0到9999999数字</asp:RangeValidator>
            </td>
            <td align="left">
                收入数量
            </td>
            <td align="left">
                <asp:TextBox ID="txtInNum4" CssClass="input_txtInNum4 input" runat="server" MaxLength="20"></asp:TextBox>
                <asp:RangeValidator ID="RangeValidator14" Display="Dynamic" runat="server" ErrorMessage="收入数量应为0到9999999数字"
                                            ControlToValidate="txtInNum4"  MinimumValue="0" MaximumValue="9999999"
                                            Type="Double">收入数量应为0到9999999数字</asp:RangeValidator>
            </td>
        </tr>
        <tr class="myTrDualLine">
            <td align="left">
                发出体积
            </td>
            <td align="left">
                <asp:TextBox ID="txtOutVolumn4" CssClass="input_txtOutVolumn4 input" runat="server"
                    MaxLength="20"></asp:TextBox>
                    <asp:RangeValidator ID="RangeValidator15" Display="Dynamic" runat="server" ErrorMessage="发出体积应为0到9999999数字"
                                            ControlToValidate="txtOutVolumn4"  MinimumValue="0" MaximumValue="9999999"
                                            Type="Double">发出体积应为0到9999999数字</asp:RangeValidator>
            </td>
            <td align="left">
                发出数量
            </td>
            <td align="left">
                <asp:TextBox ID="txtOutNum4" CssClass="input_txtOutNum4 input" runat="server" MaxLength="20"></asp:TextBox>
                <asp:RangeValidator ID="RangeValidator16" Display="Dynamic" runat="server" ErrorMessage="发出数量应为0到9999999数字"
                                            ControlToValidate="txtOutNum4"  MinimumValue="0" MaximumValue="9999999"
                                            Type="Double">发出数量应为0到9999999数字</asp:RangeValidator>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
            </td>
            <td>
            </td>
            <td>
            </td>
        </tr>
        <tr class="myTrSingularLine">
            <td align="left">
                物料名称:
            </td>
            <td colspan="3" align="left">
                <asp:DropDownList ID="DropDownList5" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr class="myTrDualLine">
            <td align="left">
                收入体积
            </td>
            <td align="left">
                <asp:TextBox ID="txtInVolumn5" CssClass="input_txtInVolumn5 input" runat="server"
                    MaxLength="30"></asp:TextBox>
                    <asp:RangeValidator ID="RangeValidator17" Display="Dynamic" runat="server" ErrorMessage="收入体积应为0到9999999数字"
                                            ControlToValidate="txtInVolumn5"  MinimumValue="0" MaximumValue="9999999"
                                            Type="Double">收入体积应为0到9999999数字</asp:RangeValidator>
            </td>
            <td align="left">
                收入数量
            </td>
            <td align="left">
                <asp:TextBox ID="txtInNum5" CssClass="input_txtInNum5 input" runat="server" MaxLength="20"></asp:TextBox>
                <asp:RangeValidator ID="RangeValidator18" Display="Dynamic" runat="server" ErrorMessage="收入数量应为0到9999999数字"
                                            ControlToValidate="txtInNum5"  MinimumValue="0" MaximumValue="9999999"
                                            Type="Double">收入数量应为0到9999999数字</asp:RangeValidator>
            </td>
        </tr>
        <tr class="myTrDualLine">
            <td align="left">
                发出体积
            </td>
            <td align="left">
                <asp:TextBox ID="txtOutVolumn5" CssClass="input_txtOutVolumn5 input" runat="server"
                    MaxLength="20"></asp:TextBox>
                    <asp:RangeValidator ID="RangeValidator19" Display="Dynamic" runat="server" ErrorMessage="发出体积应为0到9999999数字"
                                            ControlToValidate="txtOutVolumn5"  MinimumValue="0" MaximumValue="9999999"
                                            Type="Double">发出体积应为0到9999999数字</asp:RangeValidator>
            </td>
            <td align="left">
                发出数量
            </td>
            <td align="left">
                <asp:TextBox ID="txtOutNum5" CssClass="input_txtOutNum5 input" runat="server" MaxLength="20"></asp:TextBox>
                <asp:RangeValidator ID="RangeValidator20" Display="Dynamic" runat="server" ErrorMessage="发出数量应为0到9999999数字"
                                            ControlToValidate="txtOutNum5"  MinimumValue="0" MaximumValue="9999999"
                                            Type="Double">发出数量应为0到9999999数字</asp:RangeValidator>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
            </td>
            <td>
            </td>
            <td>
            </td>
        </tr>
        <tr class="myTrSingularLine">
            <td align="left">
                物料名称:
            </td>
            <td colspan="3" align="left">
                <asp:DropDownList ID="DropDownList6" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr class="myTrDualLine">
            <td align="left">
                收入体积
            </td>
            <td align="left">
                <asp:TextBox ID="txtInVolumn6" CssClass="input_txtInVolumn6 input" runat="server"
                    MaxLength="30"></asp:TextBox>
                    <asp:RangeValidator ID="RangeValidator21" Display="Dynamic" runat="server" ErrorMessage="收入体积应为0到9999999数字"
                                            ControlToValidate="txtInVolumn6"  MinimumValue="0" MaximumValue="9999999"
                                            Type="Double">收入体积应为0到9999999数字</asp:RangeValidator>
            </td>
            <td align="left">
                收入数量
            </td>
            <td align="left">
                <asp:TextBox ID="txtInNum6" CssClass="input_txtInNum6 input" runat="server" MaxLength="20"></asp:TextBox>
                <asp:RangeValidator ID="RangeValidator22" Display="Dynamic" runat="server" ErrorMessage="收入数量应为0到9999999数字"
                                            ControlToValidate="txtInNum6"  MinimumValue="0" MaximumValue="9999999"
                                            Type="Double">收入数量应为0到9999999数字</asp:RangeValidator>
            </td>
        </tr>
        <tr class="myTrDualLine">
            <td align="left">
                发出体积
            </td>
            <td align="left">
                <asp:TextBox ID="txtOutVolumn6" CssClass="input_txtOutVolumn6 input" runat="server"
                    MaxLength="20"></asp:TextBox>
                    <asp:RangeValidator ID="RangeValidator23" Display="Dynamic" runat="server" ErrorMessage="发出体积应为0到9999999数字"
                                            ControlToValidate="txtOutVolumn6"  MinimumValue="0" MaximumValue="9999999"
                                            Type="Double">发出体积应为0到9999999数字</asp:RangeValidator>
            </td>
            <td align="left">
                发出数量
            </td>
            <td align="left">
                <asp:TextBox ID="txtOutNum6" CssClass="input_txtOutNum6 input" runat="server" MaxLength="20"></asp:TextBox>
                <asp:RangeValidator ID="RangeValidator24" Display="Dynamic" runat="server" ErrorMessage="发出数量应为0到9999999数字"
                                            ControlToValidate="txtOutNum6"  MinimumValue="0" MaximumValue="9999999"
                                            Type="Double">发出数量应为0到9999999数字</asp:RangeValidator>
            </td>
        </tr>
        <tr>
            <td colspan="4">
            </td>
        </tr>
        <tr class="myTrSubmitLine">
            <td class="td_Submit" colspan="4">
                <asp:Button ID="btnSubmit" runat="server" Text="提交" onclick="btnSubmit_Click"></asp:Button>
                <asp:Button ID="btnCancel" runat="server" Text="取消" CausesValidation="False" onclick="btnCancel_Click1">
                </asp:Button>
            </td>
        </tr>
       
    </table>
  

    <script type="text/javascript">
        function HrefClick(OrderString) {
            document.getElementById("txtOrderString").value = OrderString;
            document.forms[0].btnHREF.click();
        }
        function QueryClick() {
            document.forms[0].btnQuery.click();
        }
    </script>

    <iframe id="hiddenframe" src="" width="0" height="0"></iframe>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Default.Master" AutoEventWireup="true"
    CodeBehind="IODetail.aspx.cs" Inherits="WebMM.Storage.IODetail" %>

<%@ MasterType VirtualPath="~/Master/Default.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../CSS/ManageCommon.css" type="text/css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="AjaxHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BodyHolder" runat="server">
    <table class="managertable">
        <tr>
            <td>
                <table cellspacing="1" cellpadding="3" width="100%" border="1" style="word-break: break-all">
                    <tr>
                        <td id="WebPanel1_header" class="WebPanel1hdrxpnd" align="left">
                            <img id="WebPanel1_header_img" height="0" width="0" style="float: right;" src="../images/igpnl_up.gif"
                                expandedurl="/ig_common/images/igpnl_up.gif" collapsedurl="/ig_common/images/igpnl_dwn.gif" />
                            物料收发明细记录
                        </td>
                    </tr>
                </table>
                <table class="managertable" border="1>
                    <tr class="managertr">
                        <td  class="titletd">
                            物料编号：
                        </td>
                        <td class="contenttd">
                            <asp:TextBox ID="txtItemCode" runat="server" CssClass="input_txtItemCode input" ReadOnly="true"></asp:TextBox>
                        </td>
                        <td class="titletd">
                            物料名称：
                        </td>
                        <td class="contenttd">
                            <asp:TextBox ID="txtItemName" runat="server" CssClass="input_txtItemName input" ReadOnly="true"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="titletd">
                            规格型号：
                        </td>
                        <td class="contenttd">
                            <asp:TextBox ID="txtItemSpec" runat="server" CssClass="input_txtItemSpec input" ReadOnly="true"></asp:TextBox>
                        </td>
                        <td class="titletd">
                            单位：
                        </td>
                        <td class="contenttd">
                            <asp:TextBox ID="txtItemUnit" runat="server" CssClass="input_txtItemUnit input" ReadOnly="true"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
            </td>
        </tr>
        <tr>
            <td>
                <table class="managertable" border="1>
                    <tr class="managertr">
                        <td   class="titletd">
                            开始日期：
                        </td>
                        <td class="contenttd">
                            <mzh:ToolbarCalendar ID="txtStartDate" ReadOnly="true"  runat="server" />
                        </td>
                        <td class="titletd">
                            结束日期：
                        </td>
                        <td class="contenttd">
                                <mzh:ToolbarCalendar ID="txtEndDate" ReadOnly="true" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" align="center"> <asp:Button ID="btnYes" runat="server" Text="确定" onclick="btnYes_Click" 
                                ></asp:Button> </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <mzh:MzhDataGrid ID="DataGrid1" runat="server" IdCell="0" AllowSorting="True" SelectType="MultiSelect"
                    MultiPageShowMode="DropListMode" AllowPaging="true" AutoGenerateColumns="False"
                    name="MzhMultiSelectDataGrid" 
                    ShowPageSize="true"
                    onpageindexchanged="DataGrid1_PageIndexChanged" 
                    onsortcommand="DataGrid1_SortCommand">
                    <Columns>
                        <asp:BoundColumn Visible="False" DataField="PKID" HeaderText="PKID"></asp:BoundColumn>
                        <asp:BoundColumn DataField="EntryNO" HeaderText="单据号">
                            <ItemStyle Width="30px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="DocName" HeaderText="单据类型">
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="OpDate" HeaderText=" 日期" DataFormatString="{0:yyyy-MM-dd}"></asp:BoundColumn>
                        <asp:BoundColumn DataField="ObjName" HeaderText="供应商/部门"><ItemStyle HorizontalAlign="Left" /></asp:BoundColumn>
                        <asp:BoundColumn DataField="ReqReason" HeaderText="用途"><ItemStyle HorizontalAlign="Left" /></asp:BoundColumn>
                        <asp:BoundColumn DataField="StartNum" HeaderText="期初数量">
                            <ItemStyle Width="50px"  HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="InNum" HeaderText="收入数量">
                            <ItemStyle Width="50px"  HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="OutNum" HeaderText="发出数量">
                            <ItemStyle Width="50px"  HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="EndNum" HeaderText="结存数量">
                            <ItemStyle Width="50px"  HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="StoName" HeaderText="仓库"></asp:BoundColumn>
                        <asp:BoundColumn DataField="ConName" HeaderText="架位"></asp:BoundColumn>
                    </Columns>
                </mzh:MzhDataGrid>
            </td>
        </tr>
    </table>
</asp:Content>

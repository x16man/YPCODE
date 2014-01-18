<%@ Page Language="c#" CodeBehind="UsingBrowser.aspx.cs" MasterPageFile="~/Master/Default.Master"
    AutoEventWireup="True" Inherits="MZHMM.WebMM.Storage.UsingBrowser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>�������ɺ���;���</title>
    <link href="../CSS/Storage/UsingBrowser.css" type="text/css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="AjaxHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BodyHolder" runat="server">
    <table cellspacing="0" class="table_toolbar" width="100%">
        <tr>
            <td class="table_toolbar_td td_label">
                ��;���ࣺ
            </td>
            <td class="table_toolbar_td td_Content" colspan="2" align="left">
                <asp:DropDownList ID="dllUsingClassify" runat="server" AutoPostBack="true" onselectedindexchanged="dllUsingClassify_SelectedIndexChanged"
                 >
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="table_toolbar_td td_label">
                ƴ������ĸ��
            </td>
            <td class="table_toolbar_td td_Content" align="left">
                <asp:TextBox ID="txtContent" runat="server" CssClass="input_txtContent input"></asp:TextBox>
            </td>
            <td class="table_toolbar_td">
                <asp:Button ID="btnSearch" runat="server" Text="��ѯ" onclick="btnSearch_Click"></asp:Button>
            </td>
        </tr>
            <tr>
                <td colspan="3">
                    <mzh:MzhDataGrid ID="DataGrid1" runat="server" IdCell="0" selecttype="SingleSelect"
                        AllowSorting="True" MultiPageShowMode="DropListMode" AllowPaging="True" 
                        PageSize="10" AutoGenerateColumns="False" ShowPageSize="true"
                        name="MzhMultiSelectDataGrid" onitemdatabound="DataGrid1_ItemDataBound">
                        <Columns>
                            <asp:BoundColumn Visible="False" DataField="Code" SortExpression="Code" HeaderText="Code">
                            </asp:BoundColumn>
                            <asp:TemplateColumn HeaderText="���">
                                <HeaderStyle Width="30px" HorizontalAlign="Center" CssClass="center"></HeaderStyle>
                                <ItemTemplate>
                                    <%# this.DataGrid1.CurrentPageIndex*this.DataGrid1.PageSize + Container.ItemIndex +1 %>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:BoundColumn DataField="thisYear" SortExpression="thisYear" HeaderText="���">
                                <HeaderStyle Width="50px" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="Code" SortExpression="Code" HeaderText="��;����">
                                <HeaderStyle Width="100px" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="ProjectCode" SortExpression="ProjectCode" HeaderText="����">
                                <HeaderStyle Width="100px" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="Description" SortExpression="Description" HeaderText="��;����">    
                                <ItemStyle CssClass="left" HorizontalAlign="Left" />
                            </asp:BoundColumn>
                            <asp:TemplateColumn HeaderText="">
                                <HeaderStyle Width="30px" />
                                <ItemTemplate>
                                    <%# Eval("Dev_Type").ToString().Trim() == "REPAIR" ? "<a href='/DeviceWeb/maintain/RepairReportDetail.aspx?pkid="+Eval("Dev_ID")+"' target=\"_blank\">��ϸ</a>" : string.Empty%>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                        </Columns>
                    </mzh:MzhDataGrid>
                </td>
            </tr>
    </table>

    <script language="javascript" type="text/javascript">
        function setPurposeInfo(code, name) {
            //codename Ϊ��"���,����"��ɵ��ַ���.
            window.opener.setClassfiyCode(code, name);
            window.close();
        }
    </script>

</asp:Content>

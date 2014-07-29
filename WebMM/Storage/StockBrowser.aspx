<%@ Page Language="c#" CodeBehind="StockBrowser.aspx.cs" AutoEventWireup="True" MasterPageFile="~/Master/Default.Master"
    Inherits="MZHMM.WebMM.Storage.StockBrowser"   %>

<%@ MasterType VirtualPath="~/Master/Default.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>������</title>
   <link href="../CSS/ManageCommon.css" type="text/css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="AjaxHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BodyHolder" runat="server">
    <table class="managertable">
        <tr>
            <td class="td_toolbar">
                 <mzh:MzhToolbar ID="MzhToolbar1" runat="server" SEModuleID="MM-014" SkinID="ABC" IsExpanded="true"
                  OnSEQuery_Click="MzhToolbar1_OnSEQuery_Click"   CheckBoxListRepeatColumns="5">
                  </mzh:MzhToolbar>
                 <asp:HiddenField ID="tb_SelectedArray" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <mzh:MzhDataGrid ID="DataGrid1" name="MzhMultiSelectDataGrid" runat="server" AllowPaging="True"
                    PageSize="<%$ AppSettings:pageSize %>"  AutoGenerateColumns="False"  SelectType="SingleSelect"
                    ShowPageSize="true"
                     AllowSorting="True"
                    IdCell="0"  MultiPageShowMode="DropListMode" 
                    onitemdatabound="DataGrid1_ItemDataBound">
               
                    <Columns>
                        <asp:BoundColumn DataField="NewCode" SortExpression="NewCode" HeaderText="�±��">
                            <HeaderStyle Width="90px" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="ItemCode" SortExpression="ItemCode" HeaderText="���ϱ��">
                            <HeaderStyle Width="60px" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="ItemName" SortExpression="ItemName" HeaderText="��������">
                            <HeaderStyle Width="100px" />
                            <ItemStyle HorizontalAlign="left" VerticalAlign="Middle"></ItemStyle>
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="ItemSpecial" SortExpression="ItemSpecial" HeaderText="����ͺ�">
                            <HeaderStyle Width="150px" />
                            <ItemStyle HorizontalAlign="left" VerticalAlign="Middle"></ItemStyle>
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="ItemUnitName" SortExpression="ItemUnitName" HeaderText="��λ">
                            <HeaderStyle Width="60px" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="ItemNum" SortExpression="ItemNum" HeaderText="����">
                            <HeaderStyle Width="80px" />
                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="ConName" SortExpression="ConName" HeaderText="��λ">
                            <HeaderStyle Width="80px" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="StoName" SortExpression="StoName" HeaderText="�ֿ�">
                            <HeaderStyle Width="150px" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="AcceptDate" SortExpression="AcceptDate" HeaderText="�������" DataFormatString="{0:yyyy\/MM\/dd}">
                            <HeaderStyle Width="80px" />
                        </asp:BoundColumn>
                        <asp:TemplateColumn>
                            <HeaderStyle  />
                            <ItemTemplate>
                                <img alt="" src="../Images/History_info.gif" onclick="ShowIO('<%#  DataBinder.Eval(Container, "DataItem.ItemCode")%>')">
                            </ItemTemplate>
                        </asp:TemplateColumn>
                    </Columns>
                </mzh:MzhDataGrid>
            </td>
        </tr>
    </table>

    <script language="javascript" type="text/javascript">
			function ShowIO(ItemCode)
			{
			    window.open('IODetail.aspx?ItemCode=' + ItemCode, 'newwindow', 'height=450, width=900, top=0, left=0, toolbar=no, menubar=no, scrollbars=no, resizable=no,location=n o, status=no');
			}
			
    </script>

</asp:Content>
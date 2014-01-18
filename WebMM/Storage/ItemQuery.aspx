<%@ Page Language="c#" CodeBehind="ItemQuery.aspx.cs" MasterPageFile="~/Master/Default.Master"
    AutoEventWireup="True" Inherits="MZHMM.WebMM.Storage.ItemQuery" %>

<%@ MasterType VirtualPath="~/Master/Default.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>���ϲ�ѯ</title>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BodyHolder" runat="server">
    <div>
        <table>
            <tr>
                <td width="60px">
                    <asp:RadioButton ID="chkCategory" runat="server" Text="���ࣺ" GroupName="query"></asp:RadioButton>
                </td>
                <td width="120px">
                    <uc1:StorageDropdownlist ID="ddlCategory" runat="server" Width="100%"></uc1:StorageDropdownlist>
                </td>
                <td width="90px">
                    <asp:RadioButton ID="chkContent" runat="server" Text="��ѯ���ݣ�" Checked="True" GroupName="query">
                    </asp:RadioButton>
                </td>
                <td width="100px">
                    <uc1:StorageDropdownlist ID="ddlClass" runat="server" Width="100px"></uc1:StorageDropdownlist>
                </td>
                <td width="150px">
                    <asp:TextBox ID="txtContent" runat="server" Width="150px"></asp:TextBox>
                </td>
                <td width="100px">
                    <asp:Button ID="btnQuery" runat="server" Text="��ѯ" OnClick="btnQuery_Click"></asp:Button>
                </td>
            </tr>
        </table>
        <mzh:MzhDataGrid ID="dgItemQuery" runat="server" IdCell="0" MultiPageShowMode="DropListMode" EnableViewState="true"
            AllowPaging="True" AllowSorting="true" ShowFooter="True" selecttype="SingleSelect"
            name="MzhMultiSelectDataGrid" AutoGenerateColumns="False" OnItemDataBound="dgItemQuery_ItemDataBound"
            CauseValidationWhenPaging="False" CssClass="datagrid" 
            HignLightCSS="m-grid-row-over" IsShowTotalRecorderCount="True" 
            SelectedCSS="m-grid-row-selected" ShowGridOnEmptyData="False" 
            ShowPageSize="True" ShowRecordsCount="True" SORTEXPRESSION="" style="table-layout: fixed;">
            <Columns>
                <asp:BoundColumn DataField="Code" Visible ="False"/>
                <asp:BoundColumn DataField="NewCode" SortExpression="NewCode" HeaderText="�±���">
                    <ItemStyle Width="100px" />
                </asp:BoundColumn>
                <asp:BoundColumn DataField="Code" SortExpression="Code" HeaderText="���ϱ���">
                    <HeaderStyle Width="60px"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Center"/>
                </asp:BoundColumn>
                <asp:BoundColumn DataField="CnName" SortExpression="CnName" HeaderText="��������">
                    <ItemStyle Width="120px" />
                </asp:BoundColumn>
                <asp:BoundColumn DataField="Special" SortExpression="Special" HeaderText="����ͺ�">
                    <ItemStyle Width="100px" />
                </asp:BoundColumn>
                <asp:BoundColumn DataField="Unit_Des" SortExpression="Unit_Des" HeaderText="��λ">
                    <HeaderStyle Width="40px"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Center"/>
                </asp:BoundColumn>
                <asp:BoundColumn DataField="ItemNum" SortExpression="ItemNum" HeaderText="�����">
                    <HeaderStyle Width="60px"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Right"/>
                </asp:BoundColumn>
                <asp:TemplateColumn HeaderText="����">
                    <HeaderStyle Width="60px" />
                    <ItemStyle HorizontalAlign="Right"></ItemStyle>
                    <ItemTemplate>
                        <asp:Label runat="server" 
                            Text='<%# string.IsNullOrEmpty(DataBinder.Eval(Container, "DataItem.CstPrice").ToString())?Eval("EvaPrice"):Eval("CstPrice") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateColumn>
                <asp:BoundColumn DataField="UnitCode" SortExpression="UnitCode" Visible="false">
                </asp:BoundColumn>
                <asp:BoundColumn DataField="Sto_Des" SortExpression="Sto_Des" Visible="false"></asp:BoundColumn>
                <asp:BoundColumn/>
            </Columns>
        </mzh:MzhDataGrid>
        <div>
            <asp:HiddenField ID="TextBox2" runat="server" />
            <asp:Button ID="btnItemRequire" runat="server" Text="����������" OnClick="btnItemRequire_Click">
            </asp:Button><asp:HiddenField ID="txtOpenerURL" runat="server" />
        </div>
    </div>

    <script language="javascript" type="text/javascript">

       

        function onSearchClick() {
            if ((document.getElementById("<%= txtContent.ClientID %>").value == "" || document.getElementById("<%= txtContent.ClientID %>").value == null) && document.getElementById("<%= chkContent.ClientID %>").checked == true) {
                alert("�������ò�ѯ���ݣ�");
                return false;
            }
        }
    </script>

</asp:Content>

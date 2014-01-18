<%@ Page Language="c#" CodeBehind="ItemQuery.aspx.cs" MasterPageFile="~/Master/Default.Master"
    AutoEventWireup="True" Inherits="MZHMM.WebMM.Storage.ItemQuery" %>

<%@ MasterType VirtualPath="~/Master/Default.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>物料查询</title>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BodyHolder" runat="server">
    <div>
        <table>
            <tr>
                <td width="60px">
                    <asp:RadioButton ID="chkCategory" runat="server" Text="分类：" GroupName="query"></asp:RadioButton>
                </td>
                <td width="120px">
                    <uc1:StorageDropdownlist ID="ddlCategory" runat="server" Width="100%"></uc1:StorageDropdownlist>
                </td>
                <td width="90px">
                    <asp:RadioButton ID="chkContent" runat="server" Text="查询内容：" Checked="True" GroupName="query">
                    </asp:RadioButton>
                </td>
                <td width="100px">
                    <uc1:StorageDropdownlist ID="ddlClass" runat="server" Width="100px"></uc1:StorageDropdownlist>
                </td>
                <td width="150px">
                    <asp:TextBox ID="txtContent" runat="server" Width="150px"></asp:TextBox>
                </td>
                <td width="100px">
                    <asp:Button ID="btnQuery" runat="server" Text="查询" OnClick="btnQuery_Click"></asp:Button>
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
                <asp:BoundColumn DataField="NewCode" SortExpression="NewCode" HeaderText="新编码">
                    <ItemStyle Width="100px" />
                </asp:BoundColumn>
                <asp:BoundColumn DataField="Code" SortExpression="Code" HeaderText="物料编码">
                    <HeaderStyle Width="60px"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Center"/>
                </asp:BoundColumn>
                <asp:BoundColumn DataField="CnName" SortExpression="CnName" HeaderText="物料描述">
                    <ItemStyle Width="120px" />
                </asp:BoundColumn>
                <asp:BoundColumn DataField="Special" SortExpression="Special" HeaderText="规格型号">
                    <ItemStyle Width="100px" />
                </asp:BoundColumn>
                <asp:BoundColumn DataField="Unit_Des" SortExpression="Unit_Des" HeaderText="单位">
                    <HeaderStyle Width="40px"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Center"/>
                </asp:BoundColumn>
                <asp:BoundColumn DataField="ItemNum" SortExpression="ItemNum" HeaderText="库存数">
                    <HeaderStyle Width="60px"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Right"/>
                </asp:BoundColumn>
                <asp:TemplateColumn HeaderText="单价">
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
            <asp:Button ID="btnItemRequire" runat="server" Text="申请新物料" OnClick="btnItemRequire_Click">
            </asp:Button><asp:HiddenField ID="txtOpenerURL" runat="server" />
        </div>
    </div>

    <script language="javascript" type="text/javascript">

       

        function onSearchClick() {
            if ((document.getElementById("<%= txtContent.ClientID %>").value == "" || document.getElementById("<%= txtContent.ClientID %>").value == null) && document.getElementById("<%= chkContent.ClientID %>").checked == true) {
                alert("请先设置查询内容！");
                return false;
            }
        }
    </script>

</asp:Content>

<%@ Page Language="c#" CodeBehind="POSBrowser.aspx.cs" MasterPageFile="~/Master/Default.Master"
    AutoEventWireup="True" Title="�ɹ���������ѡ��" Inherits="MZHMM.WebMM.Purchase.POSBrowser" %>

<%@ MasterType VirtualPath="~/Master/Default.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>�ɹ���������ѡ��</title>
    <meta content="��������" name="keywords" />
    <link href="../CSS/ManageCommon.css" type="text/css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="AjaxHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BodyHolder" runat="server">
    <mzh:MzhToolbar ID="MzhToolbar1" runat="server" 
        onitempostback="MzhToolbar1_ItemPostBack">
      <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable"
            itemid="Add" cellspacing="0" nakedlabelclass="nakedLabelCell" isshowtext="True"
            iconclass="present" hasicon="True" text="�����" id="toolbarButtonFirstAudit" onclick="insertItem()">
        </mzh:toolbarbutton>
        <mzh:ToolbarSeparator ID="ToolbarSeparator1" runat="server" 
            CausesValidation="True" ItemId="" SeparatorClass="toolbarIconDivider" />
        <mzh:ToolbarLabel ID="ToolbarLabel1" runat="server" CausesValidation="True" 
            Cellpadding="0" Cellspacing="0" ItemId="" LabelClass="labelCell" Text="���湩Ӧ�̣�" 
            TableClass="labelTable" />
        <mzh:ToolbarDropdownList ID="tbiPrv" runat="server" AutoPostBack="True"
            CausesValidation="False" Cellpadding="0" Cellspacing="0" Enabled="True" 
            ItemId="Prv" SelectedIndex="-1" TableClass="labelTable" />
     </mzh:MzhToolbar>
    <table class="managertable">
        <tr>
            <td class="table_toolbar_ItemList">
                <mzh:MzhDataGrid ID="DGModel_Items1" runat="server" 
                    name="MzhMultiSelectDataGrid" AutoGenerateColumns="False" 
                     SelectType="MultiSelect"
                     CssClass="datagrid" 
                    >
                    <Columns>
                        <asp:BoundColumn Visible="False" DataField="PKID" SortExpression="PKID" HeaderText="PKID">
                        </asp:BoundColumn>
                        <asp:TemplateColumn HeaderText="����" >
                            <HeaderStyle Width="70px" />
                            <EditItemTemplate>
                                <asp:TextBox runat="server" 
                                    Text='<%# DataBinder.Eval(Container, "DataItem.DocName") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label runat="server" 
                                    Text='<%# DataBinder.Eval(Container, "DataItem.DocName").ToString().Substring(0,2)+"(<a target=\"_blank\" href=\""+(Eval("SourceDocCode").ToString()=="1"?"ROSDetail.aspx":"PPDetail.aspx")+"?EntryNo="+Eval("SourceEntry")+"\">"+Eval("SourceEntry")+"</a>)" %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:BoundColumn DataField="SourceDocCode" Visible="false"></asp:BoundColumn>
                        <asp:BoundColumn DataField="ReqDeptName" SortExpression="ReqDeptName" HeaderText="���벿��">
                            <HeaderStyle Width="100px" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="ReqReason" SortExpression="ReqReason" HeaderText="��;">
                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                        </asp:BoundColumn>
                        <asp:TemplateColumn HeaderText="���Ϸ���">
                            <HeaderStyle Width="80px" />
                            <ItemStyle HorizontalAlign="Left" />
                            <EditItemTemplate>
                                <asp:TextBox runat="server" 
                                    Text='<%# DataBinder.Eval(Container, "DataItem.CatName") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label runat="server" 
                                    Text='<%# string.IsNullOrEmpty(DataBinder.Eval(Container, "DataItem.CatName").ToString())?"":DataBinder.Eval(Container, "DataItem.CatName").ToString().Substring(0,DataBinder.Eval(Container, "DataItem.CatName").ToString().Length>5?5:DataBinder.Eval(Container, "DataItem.CatName").ToString().Length) %>' ToolTip='<%# DataBinder.Eval(Container, "DataItem.CatName") %>' ></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        
                        <asp:BoundColumn DataField="PrvName" SortExpression="PrvName" HeaderText="���湩Ӧ��">
                            <HeaderStyle Width="150px" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="NewCode" SortExpression="NewCode" HeaderText="�±��">
                            <HeaderStyle Width="70px" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="ItemCode" SortExpression="ItemCode" HeaderText="���ϱ��">
                            <HeaderStyle Width="70px" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:TemplateColumn HeaderText="��������/����ͺ�">
                            <HeaderStyle Width="160px" />
                            <ItemStyle HorizontalAlign="Left" />
                            <EditItemTemplate>
                                <asp:TextBox runat="server" 
                                    Text='<%# DataBinder.Eval(Container, "DataItem.ItemName") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label runat="server" 
                                    Text='<%# DataBinder.Eval(Container, "DataItem.ItemName")+(string.IsNullOrEmpty(DataBinder.Eval(Container, "DataItem.ItemSpecial").ToString())?"":"/")+ DataBinder.Eval(Container, "DataItem.ItemSpecial")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        
                        <asp:BoundColumn DataField="ItemNum" SortExpression="ItemNum" HeaderText="��Ҫ����">
                            <HeaderStyle Width="60px" />
                            <ItemStyle HorizontalAlign="Right"></ItemStyle>
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="ReqDate" SortExpression="ReqDate" HeaderText="Ҫ������" DataFormatString="{0:yyyy-MM-dd}">
                            <HeaderStyle Width="80px" />
                        </asp:BoundColumn>
                    </Columns>
                </mzh:MzhDataGrid>
            </td>
        </tr>
    </table>

    <script language="javascript" type="text/javascript">

        //���
        function insertItem() {
            window.opener.setPOSData(<%=DGModel_Items1.ClientID%>_obj.getSelectedArray());
             window.close();
        }
    </script>

</asp:Content>

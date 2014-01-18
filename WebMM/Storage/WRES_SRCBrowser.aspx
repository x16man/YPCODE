<%@ Page Language="c#" CodeBehind="WRES_SRCBrowser.aspx.cs" AutoEventWireup="True"
    MasterPageFile="~/Master/Default.Master" Inherits="MZHMM.WebMM.Storage.WRES_SRCBrowser" %>

<%@ MasterType VirtualPath="~/Master/Default.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>委外加工申请单选择</title>
    <meta name="keywords" content="委外加工收料单" />
    <link href="../CSS/ManageCommon.css" type="text/css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="AjaxHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BodyHolder" runat="server">
    <table class="managertable">
        <tr >
            <td style="border-right: #ffcc33 1px solid; border-top: #ffcc33 1px solid; border-left: #ffcc33 1px solid;
                border-bottom: #ffcc33 1px solid; height: 26px; background-color: #ffffcc" height="26" align='left'>
                <mzh:MzhToolbar ID="MzhToolbar1" runat="server">
                  <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable"
                        itemid="Edit" cellspacing="0" nakedlabelclass="nakedLabelCell" isshowtext="True"
                        iconclass="present" hasicon="True" text="选择" id="toolbarButtonFirstAudit" onclick="newItem()">
                    </mzh:toolbarbutton>
                 </mzh:MzhToolbar>
                 
                
                <asp:HiddenField ID="tb_SelectedArray" runat="server" />
                <div class="hidden">
                     <asp:Button ID="btn_Submit" runat="server" Text="提交" Width="0px"></asp:Button>
                </div>
               
            </td>
        </tr>
        <tr>
            <td>
                <mzh:MzhDataGrid ID="DataGrid1" runat="server" AllowPaging="True" PageSize="20" MultiPageShowMode="DropListMode"
                    name="MzhMultiSelectDataGrid" AutoGenerateColumns="False" SelectType="MultiSelect"
                    AllowSorting="True" IdCell="0">
                    <Columns>
                        <asp:BoundColumn Visible="False" DataField="EntryNo" HeaderText="EntryNo"></asp:BoundColumn>
                        <asp:BoundColumn DataField="EntryCode" SortExpression="EntryCode" HeaderText="编号">
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="ReqReason" SortExpression="ReqReason" HeaderText="申请理由">
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="EntryDate" SortExpression="EntryDate" HeaderText="日期"
                            DataFormatString="{0:d}">
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="AuthorDeptName" SortExpression="AuthorDeptName" HeaderText="填写部门">
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="SubTotal" SortExpression="SubTotal" HeaderText="总金额">
                            <ItemStyle HorizontalAlign="Right"></ItemStyle>
                        </asp:BoundColumn>
                    </Columns>
                </mzh:MzhDataGrid>
            </td>
        </tr>
    </table>

    <script language="javascript" type="text/javascript">
        //新增
        function newItem() {
            window.opener.SetEntry(<%=DataGrid1.ClientID%>_obj.getSelectedArray());
            window.close();
        }
    </script>

</asp:Content>

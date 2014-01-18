<%@ Page Language="c#" CodeBehind="StoBrowser.aspx.cs" Title="仓库信息列表" MasterPageFile="~/Master/Default.Master"
    AutoEventWireup="True" Inherits="MZHMM.WebMM.Storage.StoBrowser" %>

<%@ MasterType VirtualPath="~/Master/Default.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>仓库信息列表</title>
 </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="AjaxHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BodyHolder" runat="server">
    <table id="Table1" cellspacing="0" width="100%">
        <tr>
            <td class="td_toolbar">
                <mzh:MzhToolbar ID="MzhToolbar1" runat="server">
                    <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable"
                        itemid="new" cellspacing="0" nakedlabelclass="nakedLabelCell" isshowtext="True"
                        iconclass="add" hasicon="True" text="新建" id="toolbarButtonadd" onclick="addItem()">
                    </mzh:toolbarbutton>
                    <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable"
                        itemid="Edit" cellspacing="0" nakedlabelclass="nakedLabelCell" isshowtext="True"
                        iconclass="edit" hasicon="True" text="编辑" id="toolbarButtonedit" onclick="editItem()">
                    </mzh:toolbarbutton>
                    <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable"
                        itemid="Edit" cellspacing="0" nakedlabelclass="nakedLabelCell" isshowtext="True"
                        iconclass="icon" hasicon="True" text="复制" id="toolbarButtoncopy" onclick="copyItem()">
                    </mzh:toolbarbutton>
                    <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable"
                        itemid="Edit" cellspacing="0" nakedlabelclass="nakedLabelCell" isshowtext="True"
                        iconclass="delete" hasicon="True" text="删除" id="toolbarButtondelete" onclick="deleteItems()">
                    </mzh:toolbarbutton>
                    <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable"
                        itemid="Edit" cellspacing="0" nakedlabelclass="nakedLabelCell" isshowtext="True"
                        iconclass="edit" hasicon="True" text="仓库管理员" id="toolbarButtonManager" onclick="stomanager()">
                    </mzh:toolbarbutton>
                    <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable"
                        itemid="Edit" cellspacing="0" nakedlabelclass="nakedLabelCell" isshowtext="True"
                        iconclass="edit" hasicon="True" text="仓位" id="toolbarButtonCon" onclick="stocon()">
                    </mzh:toolbarbutton>
                </mzh:MzhToolbar>
            </td>
        </tr>
        <tr>
            <td>
                <mzh:MzhDataGrid ID="DataGrid1" name="MzhMultiSelectDataGrid" runat="server" IdCell="0"
                    AllowSorting="true" SelectType="SingleSelect" MultiPageShowMode="DropListMode"
                    AllowPaging="true" AutoGenerateColumns="False" PageSize="<%$ AppSettings:pageSize %>"
                    OnSortCommand="DataGrid1_SortCommand"   ShowPageSize="true"
                    onpageindexchanged="DataGrid1_PageIndexChanged">
                    <Columns>
                        <asp:BoundColumn Visible="False" DataField="Code" HeaderText="Code"></asp:BoundColumn>
                        <asp:BoundColumn DataField="Code" HeaderText="仓库编号">
                            <HeaderStyle Width="8%" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Description" HeaderText="仓库名称">
                              <HeaderStyle Width="15%" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="StorageAcc" HeaderText="库存科目">
                              <HeaderStyle Width="8%" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="TransferAcc" HeaderText="转帐科目">
                              <HeaderStyle Width="8%" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="ReturnAcc" HeaderText="退货科目">
                              <HeaderStyle Width="8%" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Address" HeaderText="地址">
                              <HeaderStyle Width="8%" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Relation" HeaderText="联系人">
                              <HeaderStyle Width="8%" />
                        </asp:BoundColumn>
                    </Columns>
                </mzh:MzhDataGrid>
            </td>
        </tr>
    </table>

    <script language="javascript" type="text/javascript">

        //新建
		function addItem()
		{
		    
		        document.location="StoInput.aspx";	
		    				
		}
			
        //编辑
        function editItem() {
            if (<%=DataGrid1.ClientID%>_obj.getSelectedID() != null && <%=DataGrid1.ClientID%>_obj.getSelectedID() != "") {
                if (<%=DataGrid1.ClientID%>_obj.getSelectedID() != -1) {
                    document.location = "StoInput.aspx?Op=Edit&Code=" + <%=DataGrid1.ClientID%>_obj.getSelectedID();
                }
            }
            else {
                alert("请先选中某一条记录，再进行编辑！");
            }
        }

        //删除
        function deleteItems() {
            if (<%=DataGrid1.ClientID%>_obj.getSelectedArray() != null && <%=DataGrid1.ClientID%>_obj.getSelectedArray() != "") {
                if (confirm("确认要删除选定的内容？")) {
                    document.getElementById("<%=tb_SelectedArray.ClientID%>").value = <%=DataGrid1.ClientID%>_obj.getSelectedArray();
                    document.getElementById("<%=btn_delete.ClientID%>").click();
                }
            }
            else {
                alert("请先选中记录，再进行删除！");
            }
        }

        //复制
        function copyItem() {
            if (<%=DataGrid1.ClientID%>_obj.getSelectedID() != null && <%=DataGrid1.ClientID%>_obj.getSelectedID() != "") {
                if (<%=DataGrid1.ClientID%>_obj.getSelectedID() != -1) {
                    document.location = "StoInput.aspx?Op=Copy&Code=" + <%=DataGrid1.ClientID%>_obj.getSelectedID();
                }
            }
            else {
                alert("请先选中某一条记录，再进行复制！");
            }
        }
        //仓库架位
        function stocon() {
            if (<%=DataGrid1.ClientID%>_obj.getSelectedID() != null && <%=DataGrid1.ClientID%>_obj.getSelectedID() != "") {
                if (<%=DataGrid1.ClientID%>_obj.getSelectedID() != -1) {
                    document.location = "StoConBrowser.aspx?StoCode=" + <%=DataGrid1.ClientID%>_obj.getSelectedID();
                }
            }
            else {
                alert("请先选中某一条记录，再进行操作！");
            }
        }
        //仓库管理员	
        function stomanager() {
            if (<%=DataGrid1.ClientID%>_obj.getSelectedID() != null && <%=DataGrid1.ClientID%>_obj.getSelectedID() != "") {
                if (<%=DataGrid1.ClientID%>_obj.getSelectedID() != -1) {
                  
                    document.location = "StoManagerBrowser.aspx?StoCode=" + <%=DataGrid1.ClientID%>_obj.getSelectedID();
                }
            }
            else {
                alert("请先选中某一条记录，再进行操作！");
            }
        }
    </script>

    <asp:HiddenField ID="tb_SelectedArray" runat="server" />
    <div class="hidden">
        <asp:Button ID="btn_delete" runat="server" Width="0px" Text="删除" OnClick="btn_delete_Click">
        </asp:Button>
        <asp:Button ID="btn_refresh" runat="server" Width="0px" Text="刷新"></asp:Button>
    </div>
</asp:Content>

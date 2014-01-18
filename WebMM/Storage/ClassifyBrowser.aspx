<%@ Page Language="C#" MasterPageFile="~/Master/Default.Master" Title="用途分类" AutoEventWireup="true"
    CodeBehind="ClassifyBrowser.aspx.cs" Inherits="WebMM.Storage.ClassifyBrowser" %>

<%@ MasterType VirtualPath="~/Master/Default.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>用途分类</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="AjaxHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BodyHolder" runat="server">
    <table id="Table1" cellspacing="0" width="100%">
        <tr>
            <td>
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
                </mzh:MzhToolbar>
            </td>
        </tr>
         <tr>
            <td>
                <mzh:MzhDataGrid ID="DataGrid1" runat="server" name="MzhMultiSelectDataGrid" 
                    PageSize="<%$ AppSettings:pageSize %>" 
                    IdCell="0" AllowSorting="True" SelectType="SingleSelect" ShowPageSize="true"
                    MultiPageShowMode="DropListMode"
                    AllowPaging="true"  AutoGenerateColumns="False" 
                    onpageindexchanged="DataGrid1_PageIndexChanged" 
                    onsortcommand="DataGrid1_SortCommand" >
                    <Columns>
                        <asp:BoundColumn Visible="False" DataField="ClassifyID" HeaderText="ClassifyID">
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="ClassifyID" SortExpression="ClassifyID" HeaderText="用途分类代码">
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Description" SortExpression="Description" HeaderText="用途分类描述">
                            <ItemStyle CssClass="left" HorizontalAlign="Left" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="ParentID" SortExpression="ParentID" HeaderText="上级分类">
                        </asp:BoundColumn>
                        <asp:TemplateColumn HeaderText="是否有效">
                            <ItemTemplate>
                                <asp:CheckBox ID="chkEnable" runat="server" Enabled="False" Checked='<%# (int)Eval("Enable")==1?true:false %>'>
                                </asp:CheckBox>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                    </Columns>
                </mzh:MzhDataGrid>
            </td>
        </tr>
    </table>
   
    <div class="hidden">
         <asp:Button ID="btn_delete" runat="server" Text="删除" OnClick="btn_delete_Click">
        </asp:Button>
        <asp:HiddenField ID="tb_SelectedArray" runat="server" />
        <asp:Button ID="btn_refresh" runat="server" Text="刷新"></asp:Button>
    </div>
    
    <script language="javascript" type="text/javascript">
			 //新建
			function addItem()
			{
			    
			        document.location="ClassfiyInput.aspx";	
			    				
			}
			
			//编辑
			function editItem()
			{
				if(<%=DataGrid1.ClientID%>_obj.getSelectedID()!=null&&<%=DataGrid1.ClientID%>_obj.getSelectedID()!="")
				{
					if (<%=DataGrid1.ClientID%>_obj.getSelectedID()!=-1)
					{
						document.location="ClassfiyInput.aspx?Op=Edit&Code="+escape(<%=DataGrid1.ClientID%>_obj.getSelectedID());
					}
				}
				else
				{
					alert("请先选中某一条记录，再进行编辑！");
				}				
			}
						
			//删除
			function deleteItems()
			{
				if(<%=DataGrid1.ClientID%>_obj.getSelectedArray()!=null&&<%=DataGrid1.ClientID%>_obj.getSelectedArray()!="")
				{
					if(confirm("确认要删除选定的内容？"))
					{
						document.getElementById("<%=tb_SelectedArray.ClientID%>").value=<%=DataGrid1.ClientID%>_obj.getSelectedArray();
						document.getElementById("<%=btn_delete.ClientID%>").click();
					}
				}
				else
				{
					alert("请先选中记录，再进行删除！");
				}				
			}

			//复制
			function copyItem()
			{
				if(<%=DataGrid1.ClientID%>_obj.getSelectedID()!=null&&<%=DataGrid1.ClientID%>_obj.getSelectedID()!="")
				{
					if (<%=DataGrid1.ClientID%>_obj.getSelectedID()!=-1)
					{
						document.location="ClassfiyInput.aspx?Op=Copy&Code="+<%=DataGrid1.ClientID%>_obj.getSelectedID();
					}
				}
				else
				{
					alert("请先选中某一条记录，再进行复制！");
				}				
			}
    </script>
</asp:Content>

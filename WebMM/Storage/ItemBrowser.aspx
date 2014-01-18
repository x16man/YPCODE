<%@ Page  Language="C#" MasterPageFile="~/Master/Default.Master" Title="物料信息" AutoEventWireup="true"
    CodeBehind="ItemBrowser.aspx.cs" Inherits="WebMM.Storage.ItemBrowser" %>

<%@ MasterType VirtualPath="~/Master/Default.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>物料信息</title>
    <link href="../CSS/ManageCommon.css" type="text/css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="AjaxHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BodyHolder" runat="server">
    <table class="managertable" border="1">
        <tr>
            <td>
                <mzh:MzhToolbar ID="MzhToolbar1" runat="server" SEModuleID="MM-017" SkinID="ABC"
                  OnSEQuery_Click="MzhToolbar1_OnSEQuery_Click"   CheckBoxListRepeatColumns="5" >
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
                <mzh:MzhDataGrid ID="DataGrid1" runat="server" IdCell="0" AllowSorting="True" SelectType="SingleSelect"
                    MultiPageShowMode="DropListMode" AllowPaging="true" AutoGenerateColumns="False" ShowPageSize="true"
                    PageSize="<%$ AppSettings:pageSize %>" name="MzhMultiSelectDataGrid" OnItemDataBound="DataGrid1_ItemDataBound"
                    OnPageIndexChanged="DataGrid1_PageIndexChanged" OnSortCommand="DataGrid1_SortCommand">
                    <Columns>
                        <asp:BoundColumn Visible="False" DataField="Code" HeaderText="Code"></asp:BoundColumn>
                        <asp:TemplateColumn HeaderText="物料编码">
                            <ItemTemplate>
                                <a href="javascript:{openwindow('ItemUseDetail.aspx?ItemCode=<%#  Eval("Code")%>');}">
                                    <%#  Eval("Code")%></a>
                            </ItemTemplate>
                            <HeaderStyle Width="8%" />
                        </asp:TemplateColumn>
                        <asp:BoundColumn DataField="NewCode" SortExpression="NewCode" HeaderText="新编码"/>
                        <asp:TemplateColumn HeaderText="物料名称">
                            <ItemStyle HorizontalAlign="Left" />
                            <ItemTemplate>
                                <a href="javascript:{openwindow('IODetail.aspx?ItemCode=<%#  Eval("Code")%>');}">
                                    <%# Eval("CnName")%></a>
                            </ItemTemplate>
                            <HeaderStyle Width="10%" />
                        </asp:TemplateColumn>
                        <asp:BoundColumn DataField="Special" SortExpression="Special" HeaderText="规格型号">
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
                             <HeaderStyle Width="8%" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="State" SortExpression="State" HeaderText="状态">
                            <HeaderStyle Width="8%" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Cat_Des" SortExpression="Cat_Des" HeaderText="所属分类">
                            <HeaderStyle Width="8%" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Unit_Des" SortExpression="Unit_Des" HeaderText="单位">
                            <HeaderStyle Width="8%" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                        </asp:BoundColumn>
                        <asp:TemplateColumn HeaderText="平均单价">
                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
                            <HeaderStyle Width="8%" />
                            <ItemTemplate>
                                <a href="javascript:{ShowTrendLine('ItemPriceTrendLine.aspx?ItemCode=<%#  Eval("Code")%>');}">
                                    <%#  Eval("CstPrice")%></a>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:BoundColumn DataField="LowNum" SortExpression="LowNum" HeaderText="最低库存">
                            <HeaderStyle Width="8%" />
                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="UppNum" SortExpression="UppNum" HeaderText="最高库存">
                            <HeaderStyle Width="8%" />
                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Sto_Des" SortExpression="Sto_Des" HeaderText="存放仓库">
                            <HeaderStyle Width="8%" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Con_Des" SortExpression="Con_Des" HeaderText="存放架位">
                            <HeaderStyle Width="8%" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                        </asp:BoundColumn>
                    </Columns>
                </mzh:MzhDataGrid>
            </td>
        </tr>
    </table>
    <asp:HiddenField ID="tb_SelectedArray" runat="server" />
    <div class="hidden">
        <asp:TextBox ID="Textbox1" runat="server"></asp:TextBox>
        <asp:TextBox ID="Textbox2" runat="server"></asp:TextBox>
        <asp:Button ID="btn_delete" runat="server" Text="删除" OnClick="btn_delete_Click">
        </asp:Button>
        <asp:Button ID="btn_refresh" runat="server" Text="刷新"></asp:Button>
        <asp:Button ID="btnSearch" runat="server" Text="查询"></asp:Button>
        <asp:Button ID="btnResetDS" runat="server"></asp:Button>
    </div>

    <script language="javascript" type="text/javascript">
			function openwindow(href)
			{
				window.open(href,"1","toolbar = no,location=no,directories=no,status=no,menubar=no,scrollbars=yes,resizable=yes,copyhistory=no,width=870,height=500,left="+(window.screen.width -780)/2+",top="+(window.screen.height -500)/2);
				return;
			}
			function openwindow1(href)
			{
				window.open(href,"2","toolbar = no,location=no,directories=no,status=no,menubar=no,scrollbars=yes,resizable=yes,copyhistory=no,width=780,height=500,left="+(window.screen.width -780)/2+",top="+(window.screen.height -500)/2);
				return;
			}
			function ShowTrendLine(href)
			{
				window.open(href,"3","toolbar = no,location=no,directories=no,status=no,menubar=no,scrollbars=yes,resizable=yes,copyhistory=no,width=600,height=500,left="+(window.screen.width -420)/2+",top="+(window.screen.height -440)/3);
				return;
			}
			
			
			//显示确定按钮
			//ShowbtnSelect()
			function ShowbtnSelect()
			{
				//if(document.getElementById("ddlQrySolution_thisDDL")==null)
				//	{
				//		document.getElementById("btnSelect").style.visibility = "hidden";
				//	}
	
			}
			//点击搜索按钮时，将查询字符串赋予隐藏文本框
			function SetSQL(sql)
			{
				//document.getElementById("txtSQL").value = sql;
				//alert(sql);
				//document.forms[0].btnSearch.click();
			}
			//点击方案保存后，更新DropDownList的数据源
			function ResetDS()
			{
				//document.forms[0].btnResetDS.click();
			}
			
			//新建
			function addItem()
			{
			    
			        document.location="ItemInput.aspx";	
			    				
			}
			
			//编辑
			function editItem()
			{
				if(<%=DataGrid1.ClientID%>_obj.getSelectedID()!=null&&<%=DataGrid1.ClientID%>_obj.getSelectedID()!="")
				{
					//if (<%=DataGrid1.ClientID%>_obj.getSelectedID()!=-1)
					//{
						document.location="ItemInput.aspx?Op=Edit&Code="+<%=DataGrid1.ClientID%>_obj.getSelectedID();
					//}
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
						document.location="ItemInput.aspx?Op=Copy&Code="+<%=DataGrid1.ClientID%>_obj.getSelectedID();
					}
				}
				else
				{
					alert("请先选中某一条记录，再进行复制！");
				}				
			}
    </script>

</asp:Content>

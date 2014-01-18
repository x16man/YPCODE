<%@ Page Language="c#" CodeBehind="PslpBrowser.aspx.cs" Title="采购员维护" AutoEventWireup="True" Inherits="MZHMM.WebMM.Purchase.PslpBrowser"
    MasterPageFile="~/Master/Default.Master" %>

<%@ MasterType VirtualPath="~/Master/Default.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>采购员维护</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="AjaxHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BodyHolder" runat="server">
    <mzh:MzhToolbar ID="MzhToolbar1" runat="server" 
        onitempostback="MzhToolbar1_ItemPostBack">
        <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable"
            itemid="new" cellspacing="0" nakedlabelclass="nakedLabelCell" isshowtext="True"
            iconclass="add" hasicon="True" text="新建" id="toolbarButtonadd" onclick="newItem()">
        </mzh:toolbarbutton>
        <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable"
            itemid="Delete" cellspacing="0" autopostback="True" nakedlabelclass="nakedLabelCell" isshowtext="True"
            iconclass="delete" hasicon="True" text="删除" id="toolbarButtondelete" onclick="if(!deleteItems()) return false">
        </mzh:toolbarbutton>
    </mzh:MzhToolbar>
    <mzh:MzhDataGrid ID="DataGrid1" name="MzhMultiSelectDataGrid" runat="server" Width="100%"
        MultiPageShowMode="DropListMode" SelectType="MultiSelect" AllowSorting="True"
        IdCell="0" AllowPaging="True" PageSize="20" CssClass="datagrid" AutoGenerateColumns="False"
        CellSpacing="1" BorderWidth="1px" CellPadding="3">
        <Columns>
            <asp:BoundColumn Visible="False" DataField="Code" HeaderText="Code"></asp:BoundColumn>
            <asp:BoundColumn DataField="Code" HeaderText="采购员代码"></asp:BoundColumn>
            <asp:BoundColumn DataField="Description" HeaderText="采购员姓名"></asp:BoundColumn>
        </Columns>
    </mzh:MzhDataGrid>

    <script language="javascript" type="text/javascript">
			function newItem()
			{
			    document.location = 'PslpInput.aspx';
			}
			
		
						
			//删除
			function deleteItems()
			{
				if(<%=DataGrid1.ClientID%>_obj.getSelectedArray() != null&&<%=DataGrid1.ClientID%>_obj.getSelectedArray()!="")
				{
				    if(<%=DataGrid1.ClientID%>_obj.getSelectedArray() != "-1")
					    return confirm("确认要删除选定的内容？");
					else
					    alert('此记录无法删除');
				}
				else
				{
				    alert('请选择删除记录');
				}
			}

			
    </script>

</asp:Content>

<%@ Page Language="c#" CodeBehind="DRWSListBrowser.aspx.cs" Title="可选采购申请单和物料需求单浏览" AutoEventWireup="True"
    MasterPageFile="~/Master/Default.Master" Inherits="MZHMM.WebMM.Storage.DRWSListBrowser" %>

<%@ MasterType VirtualPath="~/Master/Default.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>可选采购申请单和物料需求单浏览</title>
    <meta content="领料单" name="keywords" />
    <link href="../CSS/ManageCommon.css" type="text/css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="AjaxHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BodyHolder" runat="server">
    <table class="managertable">
        <tr>
            <td>
                <mzh:MzhDataGrid ID="DataGrid1" runat="server" selecttype="SingleSelect" AutoGenerateColumns="False" name="MzhMultiSelectDataGrid"
                    IdCell="0" PageSize="14" AllowPaging="True" MultiPageShowMode="DropListMode"
                    >
                    <Columns>
                        <asp:BoundColumn Visible="False" DataField="PKID" HeaderText="PKID"></asp:BoundColumn>
                        <asp:BoundColumn DataField="EntryCode" HeaderText="单据编号"></asp:BoundColumn>
                        <asp:BoundColumn DataField="DocName" HeaderText="单据类型"></asp:BoundColumn>
                        <asp:BoundColumn DataField="AuthorDeptName" HeaderText="填单部门" DataFormatString="{0:d}">
                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Proposer" HeaderText="申请人">
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="EntryDate" HeaderText="日期"></asp:BoundColumn>
                    </Columns>
                </mzh:MzhDataGrid>
            </td>
        </tr>
        <tr>
            <td >
                <div class="hidden">
                    <asp:TextBox ID="Textbox1" runat="server"></asp:TextBox>
                    <asp:Button ID="Button1" runat="server" Text="提交"></asp:Button>
                </div>
                <input onclick="insertItem()" type="button" value="确定" />
            </td>
        </tr>
    </table>

    <script language="javascript" type="text/javascript">
			
			//添加
			function insertItem()
			{
				//window.opener.SetPurpose(getSelectedArray());
				window.opener.SetEntry(<%=DataGrid1.ClientID%>_obj.getSelectedArray());
				window.close();
			}
    </script>

</asp:Content>

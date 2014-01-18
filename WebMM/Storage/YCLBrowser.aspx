<%@ Page Language="c#" CodeBehind="YCLBrowser.aspx.cs" AutoEventWireup="True" Inherits="MZHMM.WebMM.Storage.YCLBrowser" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>���Ϸ������</title>
    <link href="../CSS/StyleSheet.css" type="text/css" rel="stylesheet">

    <script src="../JS/MenuShow.js"></script>

    <script src="../JS/SearchBar.js"></script>

</head>
<body bottommargin="0" leftmargin="0" topmargin="8" rightmargin="0">
    <form id="Form1" method="post" runat="server">
    <table id="Table1" cellspacing="0" cellpadding="0" width="98%" align="center" border="0">
        <tr>
            <td style="border-right: #ffcc33 1px solid; border-top: #ffcc33 1px solid; border-left: #ffcc33 1px solid;
                border-bottom: #ffcc33 1px solid; background-color: #ffffcc" height="25">
                &nbsp;
                <div id="Action_New" style="display: inline; left: 0px; top: 0px">
                    <a href="YCLInput.aspx?Op=New">�½��շ���¼</a>&nbsp;&nbsp;&nbsp;&nbsp;</div>
                <div id="Action_Edit" style="display: inline; left: 0px; top: 0px">
                    <a onclick="editItem()" href="#">�༭</a>&nbsp;&nbsp;&nbsp;&nbsp;</div>
                <div id="Action_Delete" style="display: inline; left: 0px; top: 0px">
                    <a onclick="deleteItems()" href="#">ɾ��</a>&nbsp;&nbsp;&nbsp;&nbsp;</div>
                <asp:Button ID="btn_delete" runat="server" Width="0px" Text="ɾ��" OnClick="btn_delete_Click">
                </asp:Button><asp:TextBox ID="tb_SelectedArray" runat="server" Width="0px"></asp:TextBox><asp:Button
                    ID="btn_refresh" runat="server" Width="0px" Text="ˢ��"></asp:Button><asp:Button ID="btnSearch"
                        runat="server" Width="0px" Text="��ѯ" OnClick="btnSearch_Click"></asp:Button>
                <div id="Action_Search" style="display: inline; left: 0px; top: 0px">
                    <a onclick="ShowSearchBar('../Sys/SelectEngine.aspx?ModuleID=305')" href="#">��ѯ</a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <uc1:StorageDropdownlist ID="ddlQrySolution" runat="server"></uc1:StorageDropdownlist>
                    <asp:Button ID="btnSelect" runat="server" Text="ȷ��" OnClick="btnSelect_Click"></asp:Button></div>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="txtSQL" runat="server" Width="0px"></asp:TextBox>
                <asp:Button ID="btnResetDS" runat="server" Width="0px" OnClick="btnResetDS_Click">
                </asp:Button>
            </td>
        </tr>
        <tr>
            <td>
                <asp:DataGrid ID="DataGrid1" name="MzhMultiSelectDataGrid" runat="server" AllowPaging="True"
                    PageSize="20" CssClass="datagrid" Width="100%" AutoGenerateColumns="False" BorderColor="#0099CC"
                    CellSpacing="1" BorderWidth="1px" CellPadding="3">
                    <AlternatingItemStyle BackColor="#D8F4FF"></AlternatingItemStyle>
                    <ItemStyle BackColor="#F2F8FF"></ItemStyle>
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#99CCFF">
                    </HeaderStyle>
                    <Columns>
                        <asp:BoundColumn Visible="False" DataField="PKID" HeaderText="PKID"></asp:BoundColumn>
                        <asp:BoundColumn DataField="ItemCode" HeaderText="���ϱ��"></asp:BoundColumn>
                        <asp:BoundColumn DataField="ItemName" HeaderText="��������"></asp:BoundColumn>
                        <asp:BoundColumn DataField="PrvName" HeaderText="��Ӧ������"></asp:BoundColumn>
                        <asp:BoundColumn DataField="InVolNum" HeaderText="�������"></asp:BoundColumn>
                        <asp:BoundColumn DataField="InItemNum" HeaderText="��������"></asp:BoundColumn>
                        <asp:BoundColumn DataField="OutVolNum" HeaderText="�������"></asp:BoundColumn>
                        <asp:BoundColumn DataField="OutItemNum" HeaderText="��������"></asp:BoundColumn>
                        <asp:BoundColumn DataField="EndVolNum" HeaderText="������"></asp:BoundColumn>
                        <asp:BoundColumn DataField="EndItemNum" HeaderText="�������"></asp:BoundColumn>
                        <asp:BoundColumn DataField="OpDate" HeaderText="����" DataFormatString="{0:yyyy-MM-dd}">
                        </asp:BoundColumn>
                    </Columns>
                    <PagerStyle HorizontalAlign="Right" Mode="NumericPages"></PagerStyle>
                </asp:DataGrid>
            </td>
        </tr>
    </table>

  
    <script language="javascript" type="text/javascript">
		
			//��ʾȷ����ť
			ShowbtnSelect()
			function ShowbtnSelect()
			{
				if(document.getElementById("ddlQrySolution_thisDDL")==null)
					{
						document.getElementById("btnSelect").style.visibility = "hidden";
					}
	
			}
			//���������ťʱ������ѯ�ַ������������ı���
			function SetSQL(sql)
			{
				document.getElementById("txtSQL").value = sql;
				document.forms[0].btnSearch.click();
			}
			//�����������󣬸���DropDownList������Դ
			function ResetDS()
			{
				document.forms[0].btnResetDS.click();
			}
			//�༭
			function editItem()
			{
				if(<%=DataGrid1.ClientID%>_obj.getSelectedID()!=null && <%=DataGrid1.ClientID%>_obj.getSelectedID()!="")
				{
					if (<%=DataGrid1.ClientID%>_obj.getSelectedID()!=-1)
					{
						document.location="YCLInput.aspx?Op=Edit&PKID="+<%=DataGrid1.ClientID%>_obj.getSelectedID();
					}
				}
				else
				{
					alert("����ѡ��ĳһ����¼���ٽ��б༭��");
				}				
			}
						
			//ɾ��
			function deleteItems()
			{
				if(<%=DataGrid1.ClientID%>_obj.getSelectedArray()!=null && <%=DataGrid1.ClientID%>_obj.getSelectedArray()!="")
				{
					if(confirm("ȷ��Ҫɾ��ѡ�������ݣ�"))
					{
						document.getElementById("<%=tb_SelectedArray.ClientID%>").value=<%=DataGrid1.ClientID%>_obj.getSelectedArray();
						document.getElementById("<%=btn_delete.ClientID %>").click();
					}
				}
				else
				{
					alert("����ѡ�м�¼���ٽ���ɾ����");
				}				
			}
			
		
    </script>

    </form>
</body>
</html>

<%@ Page Language="c#" CodeBehind="PPBrowser.aspx.cs" Title="�ɹ��ƻ�" MasterPageFile="~/Master/Default.Master"
    AutoEventWireup="True" Inherits="MZHMM.WebMM.Purchase.PPBrowser"   %>

<%@ MasterType VirtualPath="~/Master/Default.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>�ɹ��ƻ�</title>
    <meta name="keywords" content="�ɹ��ƻ�" />
    <link href="../CSS/ManageCommon.css" type="text/css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="AjaxHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BodyHolder" runat="server">
    <table class="managertable">
        <tr>
            <td>
                <mzh:MzhToolbar ID="MzhToolbar1" runat="server" SEModuleID="MM-003" SkinID="ABC"
                  OnSEQuery_Click="MzhToolbar1_OnSEQuery_Click"   CheckBoxListRepeatColumns="5">
                    <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable"
                        itemid="new" cellspacing="0" nakedlabelclass="nakedLabelCell" isshowtext="True"
                        iconclass="add" hasicon="True" text="�½�" id="toolbarButtonadd" onclick="newItem()">
                    </mzh:toolbarbutton>
                    <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable"
                        itemid="Edit" cellspacing="0" nakedlabelclass="nakedLabelCell" isshowtext="True"
                        iconclass="edit" hasicon="True" text="�༭" id="toolbarButtonedit" onclick="editItem()">
                    </mzh:toolbarbutton>
                    <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable"
                        itemid="Edit" cellspacing="0" nakedlabelclass="nakedLabelCell" isshowtext="True"
                        iconclass="present" hasicon="True" text="�ύ" id="toolbarButtonPresent" onclick="SubmitItem()">
                    </mzh:toolbarbutton>
                    <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable"
                        itemid="Edit" cellspacing="0" nakedlabelclass="nakedLabelCell" isshowtext="True"
                        iconclass="delete" hasicon="True" text="ɾ��" id="toolbarButtondelete" onclick="deleteItems()">
                    </mzh:toolbarbutton>
                    <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable"
                        itemid="Edit" cellspacing="0" nakedlabelclass="nakedLabelCell" isshowtext="True"
                        iconclass="cancel" hasicon="True" text="����" id="toolbarButtonCancel" onclick="CancelItem()">
                    </mzh:toolbarbutton>
                    <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable"
                        itemid="Edit" cellspacing="0" nakedlabelclass="nakedLabelCell" isshowtext="True"
                        iconclass="audit1" hasicon="True" text="һ������" id="toolbarButtonFirstAudit" onclick="FirstAudit()">
                    </mzh:toolbarbutton>
                    <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable"
                        itemid="Edit" cellspacing="0" nakedlabelclass="nakedLabelCell" isshowtext="True"
                        iconclass="audit2" hasicon="True" text="��������" id="toolbarButtonSecondAudit" onclick="SecondAudit()">
                    </mzh:toolbarbutton>
                    <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable"
                        itemid="Edit" cellspacing="0" nakedlabelclass="nakedLabelCell" isshowtext="True"
                        iconclass="audit3" hasicon="True" text="��������" id="toolbarButtonThirdAudit" onclick="ThirdAudit()">
                    </mzh:toolbarbutton>
                </mzh:MzhToolbar>
                <div class="hidden">
                    <asp:HiddenField ID="tb_SelectedArray" runat="server" />
                    <asp:Button ID="btn_delete" runat="server" Text="ɾ��" OnClick="btn_delete_Click">
                    </asp:Button>
                    <asp:Button ID="btn_cancel" runat="server" Text="����" OnClick="btn_cancel_Click">
                    </asp:Button>
                    <asp:Button ID="btn_present" runat="server" Text="�ύ" OnClick="btn_present_Click">
                    </asp:Button>
                </div>
            </td>
        </tr>
        <tr>
            <td>
            </td>
        </tr>
        <tr>
            <td>
                <mzh:MzhDataGrid ID="DataGrid1" runat="server" AllowPaging="True" 
                    PageSize="<%$ AppSettings:pageSize %>" AutoGenerateColumns="False"
                    name="MzhMultiSelectDataGrid" SelectType="SingleSelect" 
                    AllowSorting="True" IdCell="0" ShowPageSize="true"
                    MultiPageShowMode="DropListMode" onitemdatabound="DataGrid1_ItemDataBound">
                    <Columns>
                        <asp:BoundColumn Visible="False" DataField="EntryNo" HeaderText="EntryNo"></asp:BoundColumn>
                        <asp:BoundColumn DataField="EntryCode" SortExpression="EntryCode" HeaderText="�ƻ����">
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="EntryStateName" SortExpression="EntryStateName" HeaderText="״̬">
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="PlanDate" SortExpression="PlanDate" HeaderText="�ƻ�����"
                            DataFormatString="{0:yyyy-MM-dd}">
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="SubTotal" SortExpression="SubTotal" HeaderText="�ܽ��">
                            <ItemStyle HorizontalAlign="Right"></ItemStyle>
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Assessor3" SortExpression="Assessor3" HeaderText="����">
                        </asp:BoundColumn>
                    </Columns>
                </mzh:MzhDataGrid>
            </td>
        </tr>
        <tr>
            <td class="td_Submit">
                <asp:Button ID="Button1" Visible="false" runat="server" Text="����" OnClick="Button1_Click"></asp:Button>
            </td>
        </tr>
    </table>

    <script language="javascript" type="text/javascript">
			//����
			function newItem()
			{
				document.location = "PPInput.aspx?Op=New";
			}
			//�ַ�
			function SubmitItem()
			{
				/*if(<%=DataGrid1.ClientID%>_obj.getSelectedArray() != null&&<%=DataGrid1.ClientID%>_obj.getSelectedArray()!="")
				{
					if(confirm("ȷ��Ҫ�ύѡ���Ĳɹ��ƻ���"))
					{
						document.forms[0].tb_SelectedArray.value=<%=DataGrid1.ClientID%>_obj.getSelectedArray();
						document.forms[0].btn_present.click();
					}
				}*/
				if(<%=DataGrid1.ClientID%>_obj.getSelectedID()!=null&&<%=DataGrid1.ClientID%>_obj.getSelectedID()!="")
				{
					if (<%=DataGrid1.ClientID%>_obj.getSelectedID()!=-1)
					{
						document.location="PPInput.aspx?Op=Submit&EntryNo="+<%=DataGrid1.ClientID%>_obj.getSelectedID();
					}
				}
				else
				{
					alert("����ѡ��ĳһ����¼���ٽ����ύ��");
				}
			}
			//�༭
			function editItem()
			{
				if(<%=DataGrid1.ClientID%>_obj.getSelectedID()!=null&&<%=DataGrid1.ClientID%>_obj.getSelectedID()!="")
				{
					if (<%=DataGrid1.ClientID%>_obj.getSelectedID()!=-1)
					{
						document.location="PPInput.aspx?Op=Edit&EntryNo="+<%=DataGrid1.ClientID%>_obj.getSelectedID();
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
				if(<%=DataGrid1.ClientID%>_obj.getSelectedArray() != null&&<%=DataGrid1.ClientID%>_obj.getSelectedArray()!="")
				{
					if(confirm("ȷ��Ҫɾ��ѡ�������ݣ�"))
					{
						document.getElementById("<%=tb_SelectedArray.ClientID%>").value=<%=DataGrid1.ClientID%>_obj.getSelectedArray();
						document.getElementById("<%=btn_delete.ClientID%>").click();
					}
				}
				else
				{
					alert("����ѡ�м�¼���ٽ���ɾ����");
				}
			}
			//����
			function copyItem()
			{
				if(<%=DataGrid1.ClientID%>_obj.getSelectedID()!=null&&<%=DataGrid1.ClientID%>_obj.getSelectedID()!="")
				{
					if (<%=DataGrid1.ClientID%>_obj.getSelectedID()!=-1)
					{
						document.location="PPInput.aspx?Op=Copy&EntryNo="+<%=DataGrid1.ClientID%>_obj.getSelectedID();
					}
				}
				else
				{
					alert("����ѡ��ĳһ����¼���ٽ��и��ƣ�");
				}
			}
			//����
			function CancelItem()
			{
				if(<%=DataGrid1.ClientID%>_obj.getSelectedArray() != null&&<%=DataGrid1.ClientID%>_obj.getSelectedArray()!="")
				{
					if(confirm("ȷ��Ҫ����ѡ�������ݣ�"))
					{
						document.getElementById("<%=tb_SelectedArray.ClientID%>").value=<%=DataGrid1.ClientID%>_obj.getSelectedArray();
						document.getElementById("<%=btn_cancel.ClientID%>").click();
					}
				}
				else
				{
					alert("����ѡ�м�¼���ٽ������ϣ�");
				}
			}	
			//һ������		
			function FirstAudit()
			{
				if(<%=DataGrid1.ClientID%>_obj.getSelectedID()!=null&&<%=DataGrid1.ClientID%>_obj.getSelectedID()!="")
				{
					if (<%=DataGrid1.ClientID%>_obj.getSelectedID()!=-1)
					{
						document.location="PPInput.aspx?Op=FirstAudit&EntryNo="+<%=DataGrid1.ClientID%>_obj.getSelectedID();
					}
				}
				else
				{
					alert("����ѡ��ĳһ����¼���ٽ���һ��������");
				}
			}
			//��������
			function SecondAudit()
			{
				if(<%=DataGrid1.ClientID%>_obj.getSelectedID()!=null&&<%=DataGrid1.ClientID%>_obj.getSelectedID()!="")
				{
					if (<%=DataGrid1.ClientID%>_obj.getSelectedID()!=-1)
					{
						document.location="PPInput.aspx?Op=SecondAudit&EntryNo="+<%=DataGrid1.ClientID%>_obj.getSelectedID();
					}
				}
				else
				{
					alert("����ѡ��ĳһ����¼���ٽ��ж���������");
				}
			}
			//��������
			function ThirdAudit()
			{
				if(<%=DataGrid1.ClientID%>_obj.getSelectedID()!=null&&<%=DataGrid1.ClientID%>_obj.getSelectedID()!="")
				{
					if (<%=DataGrid1.ClientID%>_obj.getSelectedID()!=-1)
					{
						document.location="PPInput.aspx?Op=ThirdAudit&EntryNo="+<%=DataGrid1.ClientID%>_obj.getSelectedID();
					}
				}
				else
				{
					alert("����ѡ��ĳһ����¼���ٽ�������������");
				}
			}
    </script>

</asp:Content>

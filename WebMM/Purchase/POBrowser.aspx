<%@ Page Language="c#" CodeBehind="POBrowser.aspx.cs" MasterPageFile="~/Master/Default.Master"
    AutoEventWireup="True" Title="�ɹ�����" Inherits="MZHMM.WebMM.Purchase.POBrowser"   %>

<%@ MasterType VirtualPath="~/Master/Default.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>POBrowser</title>
    <meta content="�ɹ�����" name="keywords" />
    <link href="../CSS/ManageCommon.css" type="text/css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="AjaxHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BodyHolder" runat="server">
    <table class="managertable">
        <tr>
            <td>
                <mzh:MzhToolbar ID="MzhToolbar1" runat="server" SEModuleID="MM-004" SkinID="ABC"
                  OnSEQuery_Click="MzhToolbar1_OnSEQuery_Click"   CheckBoxListRepeatColumns="5">
                    <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable"
                        itemid="new" cellspacing="0" nakedlabelclass="nakedLabelCell" isshowtext="True"
                        iconclass="add" hasicon="True" text="�½�" id="toolbarButtonadd" onclick="newItem()">
                    </mzh:toolbarbutton>
                    <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable"
                        itemid="copy" cellspacing="0" nakedlabelclass="nakedLabelCell" isshowtext="true"
                        iconclass="copy" hasicon="true" text="����" id="toolbarButtonCopy" onclick="copyItem()">
                    </mzh:toolbarbutton>
                    <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable"
                        itemid="Edit" cellspacing="0" nakedlabelclass="nakedLabelCell" isshowtext="True"
                        iconclass="present" hasicon="True" text="ָ��" id="toolbarButtonPresent" onclick="SubmitItem()">
                    </mzh:toolbarbutton>
                    <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable"
                        itemid="Edit" cellspacing="0" nakedlabelclass="nakedLabelCell" isshowtext="True"
                        iconclass="edit" hasicon="True" text="�༭" id="toolbarButtonedit" onclick="editItem()">
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
                        iconclass="audit1" hasicon="True" text="һ������" id="toolbarButtonFirstAudit" onclick="FirstAuditItem()">
                    </mzh:toolbarbutton>
                    <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable"
                        itemid="Edit" cellspacing="0" nakedlabelclass="nakedLabelCell" isshowtext="True"
                        iconclass="audit2" hasicon="True" text="�ɹ�Աȷ��" id="toolbarButtonConfirm" onclick="AffirmItem()">
                    </mzh:toolbarbutton>
                    <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable"
                        itemid="Edit" cellspacing="0" nakedlabelclass="nakedLabelCell" isshowtext="True"
                        iconclass="red" hasicon="True" text="����" id="toolbarButtonCancelOpera" onclick="CancelOperaItem()">
                    </mzh:toolbarbutton>
                </mzh:MzhToolbar>
                <div class="hidden">
                    <asp:HiddenField ID="tb_SelectedArray" runat="server" />
                    <asp:Button ID="btn_delete" runat="server" Text="ɾ��" OnClick="btn_delete_Click">
                    </asp:Button>
                    <asp:Button ID="btn_cancel" runat="server" Text="����" OnClick="btn_cancel_Click">
                    </asp:Button>
                    <asp:Button ID="btn_distribute" runat="server" Text="�ַ�" OnClick="btn_distribute_Click">
                    </asp:Button>
                    <asp:Button ID="btn_Submit" runat="server" Text="ָ��" OnClick="btn_Submit_Click">
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
                <mzh:MzhDataGrid ID="DataGrid1" runat="server" Width="100%" name="MzhMultiSelectDataGrid"
                    AutoGenerateColumns="False" PageSize="<%$ AppSettings:pageSize %>"
                     AllowPaging="True" SelectType="SingleSelect" ShowPageSize="true"
                    MultiPageShowMode="DropListMode" AllowSorting="True" IdCell="0" OnItemDataBound="DataGrid1_ItemDataBound"
                    >
                    <Columns>
                        <asp:BoundColumn Visible="False" DataField="EntryNo" HeaderText="EntryNo"></asp:BoundColumn>
                        <asp:BoundColumn DataField="EntryCode" SortExpression="EntryNo" HeaderText="���">
                            <HeaderStyle Width="60px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="EntryStateName" SortExpression="EntryStateName" HeaderText="״̬">
                            <HeaderStyle Width="60px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="EntryDate" SortExpression="EntryDate" HeaderText="�Ƶ�����"
                            DataFormatString="{0:yyyy-MM-dd}">
                            <HeaderStyle Width="80px" />
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Assessor1" SortExpression="Assessor1" HeaderText="��������">
                            <HeaderStyle Width="80px" />
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="AuditSuggest1" SortExpression="AuditSuggest1" HeaderText="�������">
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="BuyerName" SortExpression="BuyerName" HeaderText="�ɹ�Ա">
                            <HeaderStyle Width="60px" />
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="PrvName" SortExpression="PrvName" HeaderText="��Ӧ��">
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="SubTotal" SortExpression="SubTotal" HeaderText="�ܽ��" >
                            <HeaderStyle Width="80px" />
                            <ItemStyle HorizontalAlign="Right"></ItemStyle>
                        </asp:BoundColumn>
                        <asp:BoundColumn  Visible="False" DataField="ParentEntryNo">
								</asp:BoundColumn>
                    </Columns>
                </mzh:MzhDataGrid>
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:Button ID="Button1" runat="server"  Visible="false"  Text="����" OnClick="Button1_Click"></asp:Button>
            </td>
        </tr>
    </table>

    <script language="javascript" type="text/javascript">
			
			//����
			function newItem()
			{
				//document.location = "POSBrowser.aspx?Op=New&DocCode=3";
				document.location = "POInput.aspx?Op=New";
			}
			//ָ��
			function SubmitItem()
			{
				if(<%=DataGrid1.ClientID%>_obj.getSelectedID()!=null&&<%=DataGrid1.ClientID%>_obj.getSelectedID()!="")
				{
					if (<%=DataGrid1.ClientID%>_obj.getSelectedID()!=-1)
					{
						document.location="POInput.aspx?Op=Assigned&EntryNo="+<%=DataGrid1.ClientID%>_obj.getSelectedID();
					}
				}
				else
				{
					alert("����ѡ��ĳһ����¼���ٽ���ָ�ɣ�");
				}
			}
			function FirstAuditItem()
			{
				if(<%=DataGrid1.ClientID%>_obj.getSelectedID()!=null&&<%=DataGrid1.ClientID%>_obj.getSelectedID()!="")
				{
					if (<%=DataGrid1.ClientID%>_obj.getSelectedID()!=-1)
					{
						document.location="POInput.aspx?Op=FirstAudit&EntryNo="+<%=DataGrid1.ClientID%>_obj.getSelectedID();
					}
				}
				else
				{
					alert("����ѡ��ĳһ����¼���ٽ���һ��������");
				}
			}
            function copyItem()
            {
                if(<%=DataGrid1.ClientID%>_obj.getSelectedID()!=null&&<%=DataGrid1.ClientID%>_obj.getSelectedID()!="")
				{
					if (<%=DataGrid1.ClientID%>_obj.getSelectedID()!=-1)
					{
						document.location="POInput.aspx?Op=Copy&EntryNo="+<%=DataGrid1.ClientID%>_obj.getSelectedID();
					}
				}
				else
				{
					alert("����ѡ��ĳһ����¼���ٽ��и��ƣ�");
				}
            }
			//�༭
			function editItem()
			{
				if(<%=DataGrid1.ClientID%>_obj.getSelectedID()!=null&&<%=DataGrid1.ClientID%>_obj.getSelectedID()!="")
				{
					if (<%=DataGrid1.ClientID%>_obj.getSelectedID()!=-1)
					{
						document.location="POInput.aspx?Op=Edit&EntryNo="+<%=DataGrid1.ClientID%>_obj.getSelectedID();
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

			//�ɹ�Աȷ��
			function AffirmItem()
			{
				if(<%=DataGrid1.ClientID%>_obj.getSelectedID()!=null&&<%=DataGrid1.ClientID%>_obj.getSelectedID()!="")
				{
					if (<%=DataGrid1.ClientID%>_obj.getSelectedID()!=-1)
					{
						document.location="POInput.aspx?Op=Affirm&EntryNo="+<%=DataGrid1.ClientID%>_obj.getSelectedID();
					}
				}
				else
				{
					alert("����ѡ��ĳһ����¼���ٽ���ȷ�ϣ�");
				}
			}
			
			function CancelOperaItem()
			{
				if(<%=DataGrid1.ClientID%>_obj.getSelectedID()!=null&&<%=DataGrid1.ClientID%>_obj.getSelectedID()!="")
				{
					if (<%=DataGrid1.ClientID%>_obj.getSelectedID()!=-1)
					{
						document.location="POInput.aspx?Op=Red&EntryNo="+<%=DataGrid1.ClientID%>_obj.getSelectedID();
					}
				}
				else
				{
					alert("����ѡ��ĳһ����¼���ٽ��б༭��");
				}
			}
    </script>

</asp:Content>

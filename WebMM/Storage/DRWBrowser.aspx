<%@ Page Language="c#" CodeBehind="DRWBrowser.aspx.cs" Title="���ϵ�" MasterPageFile="~/Master/Default.Master"
    AutoEventWireup="True" Inherits="MZHMM.WebMM.Storage.DRWBrowser" %>

<%@ MasterType VirtualPath="~/Master/Default.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>���ϵ�</title>
    <link href="../CSS/ManageCommon.css" type="text/css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="AjaxHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BodyHolder" runat="server">
    <table class="managertable">
        <tr>
            <td>
                <mzh:MzhToolbar ID="MzhToolbar1" runat="server"  SEModuleID="MM-009" SkinID="ABC"
                 OnSEQuery_Click="MzhToolbar1_OnSEQuery_Click"   CheckBoxListRepeatColumns="5"  >
                    <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable"
                        itemid="new" cellspacing="0" nakedlabelclass="nakedLabelCell" isshowtext="True"
                        iconclass="add" hasicon="True" text="�½�" id="toolbarButtonadd" onclick="newItem()">
                    </mzh:toolbarbutton>
                    <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable"
                        itemid="Edit" cellspacing="0" nakedlabelclass="nakedLabelCell" isshowtext="True"
                        iconclass="present" hasicon="True" text="�ύ" id="toolbarButtonPresent" onclick="SubmitItem()">
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
                        itemid="FirstAudit" cellspacing="0" nakedlabelclass="nakedLabelCell" isshowtext="True"
                        iconclass="audit1" hasicon="True" text="��������" id="toolbarButtonFirstAudit" onclick="FirstAudit()">
                    </mzh:toolbarbutton>
                    <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable"
                        itemid="SecondAudit" cellspacing="0" nakedlabelclass="nakedLabelCell" isshowtext="True"
                        iconclass="audit1" hasicon="True" text="�ƻ�����" id="toolbarButtonSecondAudit" onclick="SecondAudit()">
                    </mzh:toolbarbutton>
                    <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable"
                        itemid="Edit" cellspacing="0" nakedlabelclass="nakedLabelCell" isshowtext="True"
                        iconclass="out" hasicon="True" text="����" id="toolbarButtonDraw" onclick="Draw()">
                    </mzh:toolbarbutton>
                    <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable"
                        itemid="Edit" cellspacing="0" nakedlabelclass="nakedLabelCell" isshowtext="True"
                        iconclass="red" hasicon="True" text="����" id="toolbarButtonRed" onclick="Red()">
                    </mzh:toolbarbutton>
                </mzh:MzhToolbar>
                <div class="hidden">
                    <asp:HiddenField ID="tb_SelectedArray" runat="server" />
                    <asp:Button ID="btn_delete" runat="server" Text="ɾ��" OnClick="btn_delete_Click">
                    </asp:Button>
                    <asp:Button ID="btn_cancel" runat="server" Text="����" OnClick="btn_cancel_Click">
                    </asp:Button>
                    <asp:Button ID="btn_Submit" runat="server" Text="�ύ" OnClick="btn_Submit_Click">
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
                    PageSize="<%$ AppSettings:pageSize %>" name="MzhMultiSelectDataGrid"
                    AutoGenerateColumns="False" selecttype="SingleSelect" ShowPageSize="true"  
                    AllowSorting="True" IdCell="0"
                    MultiPageShowMode="DropListMode" 
                    OnItemDataBound="DataGrid1_ItemDataBound" >
                    <Columns>
                        <asp:BoundColumn Visible="False" DataField="EntryNo" HeaderText="EntryNo"></asp:BoundColumn>
                        <asp:BoundColumn DataField="EntryCode" SortExpression="EntryCode" HeaderText="���ݱ��">
                            <HeaderStyle Width="70px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="EntryStateName" SortExpression="EntryStateName" HeaderText="״̬">
                            <HeaderStyle Width="70px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="EntryDate" SortExpression="EntryDate" HeaderText="��������"
                            DataFormatString="{0:yyyy-MM-dd}">
                             <HeaderStyle Width="80px" />
                            <ItemStyle HorizontalAlign="Center" ></ItemStyle>
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="AuthorName" SortExpression="AuthorName" HeaderText="��д��">
                             <HeaderStyle Width="60px" />
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="AuthorDeptName" SortExpression="AuthorDeptName" HeaderText="��д����">
                             <HeaderStyle Width="80px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="ReqReason" SortExpression="ReqReason" HeaderText="��������">
                            <ItemStyle CssClass="left" HorizontalAlign="Left"  />
                             <HeaderStyle Width="120px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="ItemSummary" SortExpression="ItemSummary" HeaderText="����ժҪ">
                             <ItemStyle CssClass="left" HorizontalAlign="Left" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="SubTotal" SortExpression="SubTotal" HeaderText="�ܽ��">
                            <ItemStyle HorizontalAlign="Right"></ItemStyle>
                             <FooterStyle Width="60px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn Visible="False" DataField="ParentEntryNostatus"></asp:BoundColumn>
                    </Columns>
                </mzh:MzhDataGrid>
            </td>
        </tr>
    </table>

    <script type="text/javascript">
			
			//����
			function newItem()
			{
				document.location = "DRWInput.aspx?Op=New";
			}
			//ɾ��
			function SubmitItem()
			{
				/*if(<%=DataGrid1.ClientID%>_obj.getSelectedArray() != null&&<%=DataGrid1.ClientID%>_obj.getSelectedArray()!="")
				{
					if(confirm("ȷ��Ҫ�ύѡ�������ϵ���"))
					{
						document.forms[0].tb_SelectedArray.value=<%=DataGrid1.ClientID%>_obj.getSelectedArray();
						document.forms[0].btn_Submit.click();
					}
				}*/
				if(<%=DataGrid1.ClientID%>_obj.getSelectedID()!=null&&<%=DataGrid1.ClientID%>_obj.getSelectedID()!="")
				{
					if (<%=DataGrid1.ClientID%>_obj.getSelectedID()!=-1)
					{
						document.location="DRWInput.aspx?Op=Submit&EntryNo="+<%=DataGrid1.ClientID%>_obj.getSelectedID();
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
						document.location="DRWInput.aspx?Op=Edit&EntryNo="+<%=DataGrid1.ClientID%>_obj.getSelectedID();
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
						document.location="DRWInput.aspx?Op=Copy&EntryNo="+<%=DataGrid1.ClientID%>_obj.getSelectedID();
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
						document.location="DRWInput.aspx?Op=FirstAudit&EntryNo="+<%=DataGrid1.ClientID%>_obj.getSelectedID();
					}
				}

				else
				{
					alert("����ѡ��ĳһ����¼���ٽ��в���������");
				}								
			}
			//��������
			function SecondAudit()
			{
				if(<%=DataGrid1.ClientID%>_obj.getSelectedID()!=null&&<%=DataGrid1.ClientID%>_obj.getSelectedID()!="")
				{
					if (<%=DataGrid1.ClientID%>_obj.getSelectedID()!=-1)
					{
						document.location="DRWInput.aspx?Op=SecondAudit&EntryNo="+<%=DataGrid1.ClientID%>_obj.getSelectedID();
					}
				}
				else
				{
					alert("����ѡ��ĳһ����¼���ٽ��мƻ�������");
				}				
			}
			//��������
			function ThirdAudit()
			{
				if(<%=DataGrid1.ClientID%>_obj.getSelectedID()!=null&&<%=DataGrid1.ClientID%>_obj.getSelectedID()!="")
				{
					if (<%=DataGrid1.ClientID%>_obj.getSelectedID()!=-1)
					{
						document.location="DRWInput.aspx?Op=ThirdAudit&EntryNo="+<%=DataGrid1.ClientID%>_obj.getSelectedID();
					}
				}
				else
				{
					alert("����ѡ��ĳһ����¼���ٽ�������������");
				}				
			}
			//���ϡ�
			function Draw()
			{
				if (<%=DataGrid1.ClientID%>_obj.getSelectedID() != null && <%=DataGrid1.ClientID%>_obj.getSelectedID() != "")
				{
					if (<%=DataGrid1.ClientID%>_obj.getSelectedID() != -1)
					{
						document.location="DRWInput.aspx?Op=Out&EntryNo="+<%=DataGrid1.ClientID%>_obj.getSelectedID();
					}
				}
				else
				{
					alert("����ѡ��ĳһ����¼���ٽ��з��ϣ�");
				}				
			}
			//����
			function Red()
			{
				if(<%=DataGrid1.ClientID%>_obj.getSelectedID()!=null&&<%=DataGrid1.ClientID%>_obj.getSelectedID()!="")
				{
					if (<%=DataGrid1.ClientID%>_obj.getSelectedID()!=-1)
					{
						document.location="DRWInput.aspx?Op=Red&EntryNo="+<%=DataGrid1.ClientID%>_obj.getSelectedID();
					}
				}
				else
				{
					alert("����ѡ��ĳһ����¼���ٽ������ϣ�");
				}
			}
    </script>

</asp:Content>

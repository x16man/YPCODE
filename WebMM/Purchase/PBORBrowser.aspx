<%@ Page Language="c#" CodeBehind="PBORBrowser.aspx.cs" MasterPageFile="~/Master/Default.Master"
    AutoEventWireup="True" Title="�ɹ����ϵ�" Inherits="MZHMM.WebMM.Purchase.PBORBrowser" %>

<%@ MasterType VirtualPath="~/Master/Default.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>�ɹ����ϵ�</title>
    <link href="../CSS/ManageCommon.css" type="text/css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="AjaxHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BodyHolder" runat="server">
    <table class="managertable">
        <tr>
            <td>
                <mzh:MzhToolbar ID="MzhToolbar1" runat="server" SEModuleID="MM-005" SkinID="ABC"
                    OnSEQuery_Click="MzhToolbar1_OnSEQuery_Click" CheckBoxListRepeatColumns="5">
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
                        itemid="Edit" cellspacing="0" nakedlabelclass="nakedLabelCell" isshowtext="True"
                        iconclass="audit1" hasicon="True" text="һ������" id="toolbarButtonFirstAudit" onclick="FirstAudit()">
                    </mzh:toolbarbutton>
                    <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable"
                        itemid="Edit" cellspacing="0" nakedlabelclass="nakedLabelCell" isshowtext="True"
                        iconclass="audit2" hasicon="True" text="��������" Visible="false" id="toolbarButtonSecondAudit"
                        onclick="SecondAudit()">
                    </mzh:toolbarbutton>
                    <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable"
                        itemid="Edit" cellspacing="0" nakedlabelclass="nakedLabelCell" isshowtext="True"
                        iconclass="audit3" hasicon="True" text="��������" Visible="false" id="toolbarButtonThirdAudit"
                        onclick="ThirdAudit()">
                    </mzh:toolbarbutton>
                    <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable"
                        itemid="Edit" cellspacing="0" nakedlabelclass="nakedLabelCell" isshowtext="True"
                        iconclass="icon" hasicon="True" text="���յ�" Visible="false" id="toolbarButtonCheck"
                        onclick="Check()">
                    </mzh:toolbarbutton>
                    <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable"
                        itemid="Edit" cellspacing="0" nakedlabelclass="nakedLabelCell" isshowtext="True"
                        iconclass="red" hasicon="True" text="����" id="toolbarButtonRed" onclick="Red()">
                    </mzh:toolbarbutton>
                    <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable"
                        itemid="Edit" cellspacing="0" nakedlabelclass="nakedLabelCell" isshowtext="True"
                        iconclass="icon" hasicon="True" text="����" Visible="false" id="toolbarButtonFin"
                        onclick="Fin()">
                    </mzh:toolbarbutton>
                    <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable"
                        itemid="Edit" cellspacing="0" nakedlabelclass="nakedLabelCell" isshowtext="True"
                        iconclass="query" hasicon="True" text="��Ʊ�嵥" id="toolbarButtonInvDetail" onclick="InvDetail()">
                    </mzh:toolbarbutton>
                    <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable"
                        itemid="Edit" cellspacing="0" nakedlabelclass="nakedLabelCell" isshowtext="True"
                        iconclass="edit" hasicon="True" text="�޸ķ�Ʊ" id="toolbarButtonUpdateInvDetail"
                        onclick="UpdateInvDetail()">
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
                    <asp:Button ID="btn_Fin" runat="server" Text="����" OnClick="btn_Fin_Click"></asp:Button>
                    <asp:Button ID="btn_InvDetail" runat="server" Text="��Ʊ�嵥"></asp:Button>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <mzh:MzhDataGrid ID="DataGrid1" runat="server" name="MzhMultiSelectDataGrid" AutoGenerateColumns="False"
                    PageSize="<%$ AppSettings:pageSize %>" AllowPaging="True" SelectType="SingleSelect" ShowPageSize="true"
                    AllowSorting="True" IdCell="0" MultiPageShowMode="DropListMode" OnItemDataBound="DataGrid1_ItemDataBound"
                    >
                    <Columns>
                        <asp:BoundColumn Visible="False" DataField="EntryNo" HeaderText="EntryNo"></asp:BoundColumn>
                        <asp:BoundColumn DataField="EntryCode" SortExpression="EntryCode" HeaderText="���">
                            <HeaderStyle Width="40px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="EntryStateName" SortExpression="EntryStateName" HeaderText="״̬">
                             <HeaderStyle Width="70px" />
                             <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="EntryDate" SortExpression="EntryDate" HeaderText="��������" DataFormatString="{0:yyyy-MM-dd}">
                            <HeaderStyle Width="80px" />
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="ItemSummary" SortExpression="ItemSummary" HeaderText="����ժҪ">
                           <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="PrvName" SortExpression="PrvName" HeaderText="��Ӧ������">
                            <HeaderStyle Width="150px" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="BuyerName" SortExpression="BuyerName" HeaderText="�ɹ�Ա">
                            <HeaderStyle Width="60px" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="AcceptDate" SortExpression="AcceptDate" HeaderText="��������" DataFormatString="{0:yy\/MM\/dd}">
                            <HeaderStyle Width="80px" />
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="SubTotal" SortExpression="SubTotal" HeaderText="�ܽ��">
                            <HeaderStyle Width="80px"/>
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundColumn>
                        <asp:BoundColumn Visible="false" DataField="ParentEntryNo"></asp:BoundColumn>
                    </Columns>
                </mzh:MzhDataGrid>
            </td>
        </tr>
        <tr>
            <td class="td_Submit">
                <asp:Button ID="Button1" runat="server" Text="����" Visible="false" OnClick="Button1_Click">
                </asp:Button>
            </td>
        </tr>
    </table>

    <script language="javascript" type="text/javascript">
			
			//����
			function newItem()
			{
				document.location = "PBORInput.aspx?Op=New";
			}
			//�ύ
			function SubmitItem()
			{
				if(<%=DataGrid1.ClientID%>_obj.getSelectedID()!=null&&<%=DataGrid1.ClientID%>_obj.getSelectedID()!="")
				{
					if (<%=DataGrid1.ClientID%>_obj.getSelectedID()!=-1)
					{
						document.location="PBORInput.aspx?Op=Submit&EntryNo="+<%=DataGrid1.ClientID%>_obj.getSelectedID();
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
						document.location="PBORInput.aspx?Op=Edit&EntryNo="+<%=DataGrid1.ClientID%>_obj.getSelectedID();
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
					alert("����ѡ��ĳһ����¼���ٽ������ϣ�");
				}				
			}	
			//һ������		
			function FirstAudit()
			{
				if(<%=DataGrid1.ClientID%>_obj.getSelectedID()!=null&&<%=DataGrid1.ClientID%>_obj.getSelectedID()!="")
				{
					if (<%=DataGrid1.ClientID%>_obj.getSelectedID()!=-1)
					{
						document.location="PBORInput.aspx?Op=FirstAudit&EntryNo="+<%=DataGrid1.ClientID%>_obj.getSelectedID();
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
						document.location="PBORInput.aspx?Op=SecondAudit&EntryNo="+<%=DataGrid1.ClientID%>_obj.getSelectedID();
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
						document.location="PBORInput.aspx?Op=ThirdAudit&EntryNo="+<%=DataGrid1.ClientID%>_obj.getSelectedID();
					}
				}
				else
				{
					alert("����ѡ��ĳһ����¼���ٽ�������������");
				}			
			}
			//���ϡ�
			function In()
			{
				if(<%=DataGrid1.ClientID%>_obj.getSelectedID()!=null&&<%=DataGrid1.ClientID%>_obj.getSelectedID()!="")
				{
					if (<%=DataGrid1.ClientID%>_obj.getSelectedID()!=-1)
					{
						document.location="PBORInput.aspx?Op=In&EntryNo="+<%=DataGrid1.ClientID%>_obj.getSelectedID();
					}
				}
				else
				{
					alert("����ѡ��ĳһ����¼���ٽ������ϣ�");
				}
			}
			//���յ���
			function Check()
			{
				if(<%=DataGrid1.ClientID%>_obj.getSelectedID()!=null&&<%=DataGrid1.ClientID%>_obj.getSelectedID()!="")
				{
					if (<%=DataGrid1.ClientID%>_obj.getSelectedID()!=-1)
					{
						document.location="PCBRInput.aspx?Op=New&SourceEntry="+<%=DataGrid1.ClientID%>_obj.getSelectedID()+"|6";
					}
				}
			}
			//����
			function Red()
			{
				if(<%=DataGrid1.ClientID%>_obj.getSelectedID()!=null&&<%=DataGrid1.ClientID%>_obj.getSelectedID()!="")
				{
					if (<%=DataGrid1.ClientID%>_obj.getSelectedID()!=-1)
					{
					    //alert(<%=DataGrid1.ClientID%>_obj.getSelectedID());
					    var url = "PBORInput.aspx?Op=Red&EntryNo="+<%=DataGrid1.ClientID%>_obj.getSelectedID();
					    //alert(url);
						document.location = url;
					}
				}
				else
				{
					alert("����ѡ��ĳһ����¼���ٽ������ϣ�");
				}
			}
			//���񸶿�
			function Fin()
			{
				if(<%=DataGrid1.ClientID%>_obj.getSelectedArray() != null&&<%=DataGrid1.ClientID%>_obj.getSelectedArray()!="")
				{
					if(confirm("ȷ��Ҫ��ѡ���ĵ��ݽ��и��"))
					{
						document.getElementById("<%=tb_SelectedArray.ClientID%>").value=<%=DataGrid1.ClientID%>_obj.getSelectedArray();
						document.getElementById("<%=btn_Fin.ClientID%>").click();
					}
				}
				else
				{
					alert("����ѡ��ĳһ����¼���ٽ��и��������");
				}
			}
			//��Ʊ��ϸ
			function InvDetail()
			{
				
				if(<%=DataGrid1.ClientID%>_obj.getSelectedArray() != null&&<%=DataGrid1.ClientID%>_obj.getSelectedArray()!="")
				{
					var ID;
					ID = <%=DataGrid1.ClientID%>_obj.getSelectedArray();
					document.getElementById("<%=tb_SelectedArray.ClientID%>").value = ID;
					window.open('../Report/CommReport.aspx?ReportCode=BorDetailByInvoice&ID=' + ID) ;
				}
				else
				{
					alert("����ѡ��ĳһ����¼���ٽ��з�Ʊ�嵥��ӡ������");
				}
				
			}
			
			//����
			function UpdateInvDetail()
			{
				if(<%=DataGrid1.ClientID%>_obj.getSelectedID()!=null&&<%=DataGrid1.ClientID%>_obj.getSelectedID()!="")
				{
					if (<%=DataGrid1.ClientID%>_obj.getSelectedID()!=-1)
					{
					    //alert(<%=DataGrid1.ClientID%>_obj.getSelectedID());
					    var url = "PBORUpdateInvoice.aspx?Op=Red&EntryNo="+<%=DataGrid1.ClientID%>_obj.getSelectedID();
					    //alert(url);
						window.open(url);
					}
				}
				else
				{
					alert("����ѡ��ĳһ����¼���ٽ������ϣ�");
				}
			}
    </script>

</asp:Content>

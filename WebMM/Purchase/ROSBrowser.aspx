<%@ Page Language="c#" CodeBehind="ROSBrowser.aspx.cs" Title="�����깺��" MasterPageFile="~/Master/Default.Master"
    AutoEventWireup="True" Inherits="MZHMM.WebMM.Purchase.ROSBrowser" %>

<%@ MasterType VirtualPath="~/Master/Default.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>�����깺��</title>
    <link href="../CSS/ManageCommon.css" type="text/css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="AjaxHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BodyHolder" runat="server">
    <mzh:MzhToolbar ID="MzhToolbar1" runat="server" SEModuleID="MM-001" SkinID="ABC"
        OnSEQuery_Click="MzhToolbar1_OnSEQuery_Click" CheckBoxListRepeatColumns="5">
        <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable"
            itemid="new" cellspacing="0" nakedlabelclass="nakedLabelCell" isshowtext="True"
            iconclass="add" hasicon="True" text="�½�" id="toolbarButtonadd" onclick="newItem()">
        </mzh:toolbarbutton>
        <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable"
            itemid="Present" cellspacing="0" nakedlabelclass="nakedLabelCell" isshowtext="True"
            iconclass="present" hasicon="True" text="�ύ" id="toolbarButtonPresent" onclick="SubmitItem()">
        </mzh:toolbarbutton>
        <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable"
            itemid="Edit" cellspacing="0" nakedlabelclass="nakedLabelCell" isshowtext="True"
            iconclass="edit" hasicon="True" text="�༭" id="toolbarButtonedit" onclick="editItem()">
        </mzh:toolbarbutton>
        <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable"
            itemid="Delete" cellspacing="0" nakedlabelclass="nakedLabelCell" isshowtext="True"
            iconclass="delete" hasicon="True" text="ɾ��" id="toolbarButtondelete" onclick="deleteItems()">
        </mzh:toolbarbutton>
        <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable"
            itemid="Cancel" cellspacing="0" nakedlabelclass="nakedLabelCell" isshowtext="True"
            iconclass="cancel" hasicon="True" text="����" id="toolbarButtonCancel" onclick="CancelItem()">
        </mzh:toolbarbutton>
        <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable"
            itemid="FirstAudit" cellspacing="0" nakedlabelclass="nakedLabelCell" isshowtext="True"
            iconclass="audit1" hasicon="True" text="һ������" id="toolbarButtonFirstAudit" onclick="FirstAudit()">
        </mzh:toolbarbutton>
        <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable"
            itemid="SecondAudit" cellspacing="0" nakedlabelclass="nakedLabelCell" isshowtext="True"
            iconclass="audit2" hasicon="True" text="��������" id="toolbarButtonSecondAudit" onclick="SecondAudit()">
        </mzh:toolbarbutton>
        <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable"
            itemid="ThirdAudit" cellspacing="0" nakedlabelclass="nakedLabelCell" isshowtext="True"
            iconclass="audit3" hasicon="True" text="��������" id="toolbarButtonThirdAudit" onclick="ThirdAudit()">
        </mzh:toolbarbutton>
        <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable"
            itemid="WZAudit" cellspacing="0" nakedlabelclass="nakedLabelCell" isshowtext="True"
            iconclass="audit3" hasicon="True" text="�������" id="toolbarButtonWZAudit" onclick="WZAudit()">
        </mzh:toolbarbutton>
    </mzh:MzhToolbar>
    <mzh:MzhDataGrid ID="DataGrid1" runat="server" Width="100%" IdCell="0" selecttype="SingleSelect"
        AllowSorting="True" AllowPaging="True" ShowPageSize="true" PageSize="<%$ AppSettings:pageSize %>"
        AutoGenerateColumns="False" MultiPageShowMode="DropListMode" name="MzhMultiSelectDataGrid"
        OnItemDataBound="DataGrid1_ItemDataBound">
        <Columns>
            <asp:BoundColumn Visible="False" DataField="EntryNo" SortExpression="EntryNo" HeaderText="EntryNo">
            </asp:BoundColumn>
            <asp:BoundColumn DataField="EntryCode" SortExpression="EntryCode" HeaderText="���">
                <ItemStyle Width="50" />
            </asp:BoundColumn>
            <asp:BoundColumn DataField="EntryStateName" SortExpression="EntryStateName" HeaderText="״̬">
                <ItemStyle Width="70" />
            </asp:BoundColumn>
            <asp:BoundColumn DataField="EntryDate" SortExpression="EntryDate" HeaderText="����"
                DataFormatString="{0:yyyy-MM-dd}">
                <ItemStyle HorizontalAlign="Center" Width="70"></ItemStyle>
            </asp:BoundColumn>
            <asp:BoundColumn DataField="Proposer" SortExpression="Proposer" HeaderText="������">
                <ItemStyle HorizontalAlign="Center" Width="50"></ItemStyle>
            </asp:BoundColumn>
            <asp:BoundColumn DataField="ReqDeptName" SortExpression="ReqDeptName" HeaderText="����">
                <ItemStyle Width="90" />
            </asp:BoundColumn>
            <asp:BoundColumn DataField="ReqReason" SortExpression="ReqReason" HeaderText="��;">
                <ItemStyle CssClass="left" HorizontalAlign="Left" />
            </asp:BoundColumn>
            <asp:BoundColumn DataField="SubTotal" SortExpression="SubTotal" HeaderText="���">
                <ItemStyle HorizontalAlign="Right" Width="70"></ItemStyle>
            </asp:BoundColumn>
            <asp:BoundColumn DataField="Assessor1" SortExpression="Assessor1" HeaderText="����">
                <ItemStyle Width="50" />
            </asp:BoundColumn>
            <asp:BoundColumn DataField="Assessor2" SortExpression="Assessor2" HeaderText="����">
                <ItemStyle Width="50" />
            </asp:BoundColumn>
            <asp:BoundColumn DataField="Assessor3" SortExpression="Assessor3" HeaderText="����">
                <ItemStyle Width="50" />
            </asp:BoundColumn>
        </Columns>
    </mzh:MzhDataGrid>
    <div class="hidden">
        <asp:HiddenField ID="tb_SelectedArray" runat="server" />
        <asp:Button ID="btn_delete" runat="server" Text="ɾ��" OnClick="btn_delete_Click">
        </asp:Button>
        <asp:Button ID="btn_cancel" runat="server" Text="����" OnClick="btn_cancel_Click">
        </asp:Button>
        <asp:Button ID="btn_Submit" runat="server" Text="�ύ" OnClick="btn_Submit_Click">
        </asp:Button>
    </div>

    <script language="javascript" type="text/javascript">
		
			//�����������󣬸���DropDownList������Դ
			function ResetDS()
			{
				document.forms[0].btnResetDS.click();
			}
			//����
			function newItem()
			{
				document.location = "ROSInput.aspx?Op=New";
			}
			//ɾ��
			function SubmitItem()
			{
				if(<%=DataGrid1.ClientID%>_obj.getSelectedArray() != null&&<%=DataGrid1.ClientID%>_obj.getSelectedArray()!="")
				{
					/*if(confirm("ȷ��Ҫ�ύѡ�������뵥��"))
					{
						document.forms[0].tb_SelectedArray.value=<%=DataGrid1.ClientID%>_obj.getSelectedArray();
						document.forms[0].btn_Submit.click();
					}*/
					if (<%=DataGrid1.ClientID%>_obj.getSelectedID() != -1)
					{
					document.location = "ROSInput.aspx?Op=Submit&EntryNo="+<%=DataGrid1.ClientID%>_obj.getSelectedID();
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
						document.location="ROSInput.aspx?Op=Edit&EntryNo="+<%=DataGrid1.ClientID%>_obj.getSelectedID();
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
						document.location="ROSInput.aspx?Op=Copy&EntryNo="+<%=DataGrid1.ClientID%>_obj.getSelectedID();
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
						document.getElementById("<%=tb_SelectedArray.ClientID %>").value=<%=DataGrid1.ClientID%>_obj.getSelectedArray();
						document.getElementById("<%=btn_cancel.ClientID %>").click();
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
						document.location="ROSInput.aspx?Op=FirstAudit&EntryNo="+<%=DataGrid1.ClientID%>_obj.getSelectedID();
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
						document.location="ROSInput.aspx?Op=SecondAudit&EntryNo="+<%=DataGrid1.ClientID%>_obj.getSelectedID();
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
						document.location="ROSInput.aspx?Op=ThirdAudit&EntryNo="+<%=DataGrid1.ClientID%>_obj.getSelectedID();
					}
				}
				else
				{
					alert("����ѡ��ĳһ����¼���ٽ�������������");
				}
			}
		    //�������
            function WZAudit()
            {
                if(<%=DataGrid1.ClientID%>_obj.getSelectedID()!=null&&<%=DataGrid1.ClientID%>_obj.getSelectedID()!="")
				{
					if (<%=DataGrid1.ClientID%>_obj.getSelectedID()!=-1)
					{
						document.location="ROSInput.aspx?Op=WZAudit&EntryNo="+<%=DataGrid1.ClientID%>_obj.getSelectedID();
					}
				}
				else
				{
					alert("����ѡ��ĳһ����¼���ٽ���������ˣ�");
				}
            }
    </script>

</asp:Content>

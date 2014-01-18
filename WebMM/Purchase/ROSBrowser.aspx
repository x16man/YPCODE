<%@ Page Language="c#" CodeBehind="ROSBrowser.aspx.cs" Title="紧急申购单" MasterPageFile="~/Master/Default.Master"
    AutoEventWireup="True" Inherits="MZHMM.WebMM.Purchase.ROSBrowser" %>

<%@ MasterType VirtualPath="~/Master/Default.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>紧急申购单</title>
    <link href="../CSS/ManageCommon.css" type="text/css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="AjaxHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BodyHolder" runat="server">
    <mzh:MzhToolbar ID="MzhToolbar1" runat="server" SEModuleID="MM-001" SkinID="ABC"
        OnSEQuery_Click="MzhToolbar1_OnSEQuery_Click" CheckBoxListRepeatColumns="5">
        <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable"
            itemid="new" cellspacing="0" nakedlabelclass="nakedLabelCell" isshowtext="True"
            iconclass="add" hasicon="True" text="新建" id="toolbarButtonadd" onclick="newItem()">
        </mzh:toolbarbutton>
        <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable"
            itemid="Present" cellspacing="0" nakedlabelclass="nakedLabelCell" isshowtext="True"
            iconclass="present" hasicon="True" text="提交" id="toolbarButtonPresent" onclick="SubmitItem()">
        </mzh:toolbarbutton>
        <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable"
            itemid="Edit" cellspacing="0" nakedlabelclass="nakedLabelCell" isshowtext="True"
            iconclass="edit" hasicon="True" text="编辑" id="toolbarButtonedit" onclick="editItem()">
        </mzh:toolbarbutton>
        <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable"
            itemid="Delete" cellspacing="0" nakedlabelclass="nakedLabelCell" isshowtext="True"
            iconclass="delete" hasicon="True" text="删除" id="toolbarButtondelete" onclick="deleteItems()">
        </mzh:toolbarbutton>
        <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable"
            itemid="Cancel" cellspacing="0" nakedlabelclass="nakedLabelCell" isshowtext="True"
            iconclass="cancel" hasicon="True" text="作废" id="toolbarButtonCancel" onclick="CancelItem()">
        </mzh:toolbarbutton>
        <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable"
            itemid="FirstAudit" cellspacing="0" nakedlabelclass="nakedLabelCell" isshowtext="True"
            iconclass="audit1" hasicon="True" text="一级审批" id="toolbarButtonFirstAudit" onclick="FirstAudit()">
        </mzh:toolbarbutton>
        <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable"
            itemid="SecondAudit" cellspacing="0" nakedlabelclass="nakedLabelCell" isshowtext="True"
            iconclass="audit2" hasicon="True" text="二级审批" id="toolbarButtonSecondAudit" onclick="SecondAudit()">
        </mzh:toolbarbutton>
        <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable"
            itemid="ThirdAudit" cellspacing="0" nakedlabelclass="nakedLabelCell" isshowtext="True"
            iconclass="audit3" hasicon="True" text="三级审批" id="toolbarButtonThirdAudit" onclick="ThirdAudit()">
        </mzh:toolbarbutton>
        <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable"
            itemid="WZAudit" cellspacing="0" nakedlabelclass="nakedLabelCell" isshowtext="True"
            iconclass="audit3" hasicon="True" text="物资审核" id="toolbarButtonWZAudit" onclick="WZAudit()">
        </mzh:toolbarbutton>
    </mzh:MzhToolbar>
    <mzh:MzhDataGrid ID="DataGrid1" runat="server" Width="100%" IdCell="0" selecttype="SingleSelect"
        AllowSorting="True" AllowPaging="True" ShowPageSize="true" PageSize="<%$ AppSettings:pageSize %>"
        AutoGenerateColumns="False" MultiPageShowMode="DropListMode" name="MzhMultiSelectDataGrid"
        OnItemDataBound="DataGrid1_ItemDataBound">
        <Columns>
            <asp:BoundColumn Visible="False" DataField="EntryNo" SortExpression="EntryNo" HeaderText="EntryNo">
            </asp:BoundColumn>
            <asp:BoundColumn DataField="EntryCode" SortExpression="EntryCode" HeaderText="编号">
                <ItemStyle Width="50" />
            </asp:BoundColumn>
            <asp:BoundColumn DataField="EntryStateName" SortExpression="EntryStateName" HeaderText="状态">
                <ItemStyle Width="70" />
            </asp:BoundColumn>
            <asp:BoundColumn DataField="EntryDate" SortExpression="EntryDate" HeaderText="日期"
                DataFormatString="{0:yyyy-MM-dd}">
                <ItemStyle HorizontalAlign="Center" Width="70"></ItemStyle>
            </asp:BoundColumn>
            <asp:BoundColumn DataField="Proposer" SortExpression="Proposer" HeaderText="申请人">
                <ItemStyle HorizontalAlign="Center" Width="50"></ItemStyle>
            </asp:BoundColumn>
            <asp:BoundColumn DataField="ReqDeptName" SortExpression="ReqDeptName" HeaderText="部门">
                <ItemStyle Width="90" />
            </asp:BoundColumn>
            <asp:BoundColumn DataField="ReqReason" SortExpression="ReqReason" HeaderText="用途">
                <ItemStyle CssClass="left" HorizontalAlign="Left" />
            </asp:BoundColumn>
            <asp:BoundColumn DataField="SubTotal" SortExpression="SubTotal" HeaderText="金额">
                <ItemStyle HorizontalAlign="Right" Width="70"></ItemStyle>
            </asp:BoundColumn>
            <asp:BoundColumn DataField="Assessor1" SortExpression="Assessor1" HeaderText="主管">
                <ItemStyle Width="50" />
            </asp:BoundColumn>
            <asp:BoundColumn DataField="Assessor2" SortExpression="Assessor2" HeaderText="财务">
                <ItemStyle Width="50" />
            </asp:BoundColumn>
            <asp:BoundColumn DataField="Assessor3" SortExpression="Assessor3" HeaderText="厂部">
                <ItemStyle Width="50" />
            </asp:BoundColumn>
        </Columns>
    </mzh:MzhDataGrid>
    <div class="hidden">
        <asp:HiddenField ID="tb_SelectedArray" runat="server" />
        <asp:Button ID="btn_delete" runat="server" Text="删除" OnClick="btn_delete_Click">
        </asp:Button>
        <asp:Button ID="btn_cancel" runat="server" Text="作废" OnClick="btn_cancel_Click">
        </asp:Button>
        <asp:Button ID="btn_Submit" runat="server" Text="提交" OnClick="btn_Submit_Click">
        </asp:Button>
    </div>

    <script language="javascript" type="text/javascript">
		
			//点击方案保存后，更新DropDownList的数据源
			function ResetDS()
			{
				document.forms[0].btnResetDS.click();
			}
			//新增
			function newItem()
			{
				document.location = "ROSInput.aspx?Op=New";
			}
			//删除
			function SubmitItem()
			{
				if(<%=DataGrid1.ClientID%>_obj.getSelectedArray() != null&&<%=DataGrid1.ClientID%>_obj.getSelectedArray()!="")
				{
					/*if(confirm("确认要提交选定的申请单？"))
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
					alert("请先选中某一条记录，再进行提交！");
				}
			}
			//编辑
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
					alert("请先选中某一条记录，再进行编辑！");
				}
			}
			//删除
			function deleteItems()
			{
				if(<%=DataGrid1.ClientID%>_obj.getSelectedArray() != null&&<%=DataGrid1.ClientID%>_obj.getSelectedArray()!="")
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
						document.location="ROSInput.aspx?Op=Copy&EntryNo="+<%=DataGrid1.ClientID%>_obj.getSelectedID();
					}
				}
				else
				{
					alert("请先选中某一条记录，再进行复制！");
				}
			}
			//作废
			function CancelItem()
			{
				if(<%=DataGrid1.ClientID%>_obj.getSelectedArray() != null&&<%=DataGrid1.ClientID%>_obj.getSelectedArray()!="")
				{
					if(confirm("确认要作废选定的内容？"))
					{
						document.getElementById("<%=tb_SelectedArray.ClientID %>").value=<%=DataGrid1.ClientID%>_obj.getSelectedArray();
						document.getElementById("<%=btn_cancel.ClientID %>").click();
					}
				}
				else
				{
					alert("请先选中记录，再进行作废！");
				}
			}	
			//一级审批		
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
					alert("请先选中某一条记录，再进行一级审批！");
				}
			}
			//二级审批
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
					alert("请先选中某一条记录，再进行二级审批！");
				}
			}
			//三级审批
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
					alert("请先选中某一条记录，再进行三级审批！");
				}
			}
		    //物资审核
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
					alert("请先选中某一条记录，再进行物资审核！");
				}
            }
    </script>

</asp:Content>

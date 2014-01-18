<%@ Register TagPrefix="uc1" TagName="StorageDropdownlist" Src="StorageDropdownlist.ascx" %>
<%@ Register TagPrefix="uc1" TagName="DGModel_Items" Src="DGModel_Items.ascx" %>
<%@ Control Language="c#" AutoEventWireup="True" Codebehind="TRFWebControl.ascx.cs" Inherits="MZHMM.WebMM.Modules.TRFWebControl" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<TABLE id="Table2" cellSpacing="1" cellPadding="1" width="100%" border="0">
	<TR>
		<TD width="122" vAlign="middle" style="WIDTH: 122px">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0" align="center">
				<TR>
					<TD width="80%">
						<asp:textbox id="txtItemCode" Width="100%" runat="server" ToolTip="物料编号"></asp:textbox></TD>
					<TD width="20%"><INPUT width="100%" onclick="window.open('../Storage/ItemQuery.aspx','物料查询','toolbar = no,location=no,directories=no,status=no,menubar=no,scrollbars=no,resizable=no,copyhistory=no,width =640,height = 440,left='+(window.screen.width - 640)/2+',top='+(window.screen.height - 440)/2+'')"
							type="button" value="..."></TD>
				</TR>
			</TABLE>
		</TD>
		<TD width="105" style="WIDTH: 105px"><asp:textbox id="txtItemName" runat="server" Width="100%" ToolTip="物料名称"></asp:textbox></TD>
		<TD width="105" style="WIDTH: 105px"><asp:textbox id="txtItemSpecial" runat="server" Width="100%" ToolTip="规格型号"></asp:textbox></TD>
		<TD width="90" style="WIDTH: 90px"><uc1:storagedropdownlist id="ddlUnit" runat="server"></uc1:storagedropdownlist></TD>
		<TD width="51" style="WIDTH: 51px"><asp:textbox id="txtItemPrice" runat="server" Width="100%" ToolTip="单价"></asp:textbox></TD>
		<TD width="46" style="WIDTH: 46px"><asp:textbox id="txtPlanNum" runat="server" Width="100%" ToolTip="应转数量"></asp:textbox></TD>
		<TD width="46" style="WIDTH: 46px"><asp:textbox id="txtItemNum" runat="server" Width="100%" ToolTip="实转数量" Visible="False"></asp:textbox></TD>
		<TD><asp:button id="btnAddItem" tabIndex="50" runat="server" Text="新增" onclick="btnAddItem_Click"></asp:button><asp:button id="btnDelItem" tabIndex="40" runat="server" Text="删除" onclick="btnDelItem_Click"></asp:button><asp:button id="btnEditItem" tabIndex="40" runat="server" Text="编辑" onclick="btnEdit_Click"></asp:button></TD>
	</TR>
	<TR>
		<TD vAlign="top" colSpan="8" height="160"><uc1:dgmodel_items id="DGModel_Items1" runat="server"></uc1:dgmodel_items></TD>
	</TR>
	<TR>
		<TD colSpan="10">备注
			<asp:TextBox id="txtRemark" runat="server" Width="100%" TextMode="MultiLine" MaxLength="100"></asp:TextBox></TD>
	</TR>
</TABLE>
<div style="LEFT: 0px; VISIBILITY: hidden; POSITION: absolute; TOP: 0px">
	<table>
		<TR>
			<TD><asp:button id="btnForItemCode" runat="server" Width="0px" Text="Button" Height="0" onclick="btnForItemCode_Click"></asp:button></TD>
		</TR>
	</table>
</div>
<script language="javascript">
	function document.all.<%=txtItemCode.ClientID%>.onblur()
	{
		if (document.getElementById("<%=txtItemCode.ClientID%>").value!="")
		{
			document.getElementById("<%=btnForItemCode.ClientID%>").click();
		}
	}
	function document.all.<%=txtItemCode.ClientID%>.onkeypress()
	{
		if(event.keyCode==13)
		{
			document.getElementById("<%=btnForItemCode.ClientID%>").click();
			return false;
		}		
	}
	function document.all.<%=btnDelItem.ClientID%>.onclick()
	{
		if(!confirm("真的删除吗?"))
		{
			return false;
		}
	}
	function setCode(id)
	{
		document.getElementById("<%=txtItemCode.ClientID%>").value=id;
		document.getElementById("<%=btnForItemCode.ClientID%>").click();
	}
	
	
</script>
<INPUT id="txtItemSerial" type="hidden" value="-1" name="Hidden1" runat="server">

<%@ Control Language="c#" AutoEventWireup="True" Codebehind="TRFInWebControl.ascx.cs" Inherits="MZHMM.WebMM.Modules.TRFInWebControl" %>
<script language="JavaScript" src="../Images/calendar/date.js"></script>
<TABLE id="Table2" cellSpacing="1" cellPadding="1" width="100%" border="0">
	<TR>
		<TD vAlign="middle" width="150">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<TR>
					<TD width="67" style="WIDTH: 67px"><asp:textbox id="txtItemCode" runat="server" Width="100%" ToolTip="物料编号"></asp:textbox></TD>
					<TD width="20%"><INPUT width="100%" onclick="window.open('../Storage/ItemQuery.aspx','物料查询','toolbar = no,location=no,directories=no,status=no,menubar=no,scrollbars=no,resizable=no,copyhistory=no,width =640,height = 440,left='+(window.screen.width - 640)/2+',top='+(window.screen.height - 440)/2+'')"
							type="button" value="..."></TD>
				</TR>
			</TABLE>
		</TD>
		<TD width="150"><asp:textbox id="txtItemName" runat="server" Width="100%" ToolTip="物料名称"></asp:textbox></TD>
		<TD width="150"><asp:textbox id="txtItemSpecial" runat="server" Width="100%" ToolTip="规格型号"></asp:textbox></TD>
		<TD width="50"><uc1:storagedropdownlist id="ddlUnit" runat="server"></uc1:storagedropdownlist></TD>
		<TD width="60"><asp:textbox id="txtBatchCode" runat="server" Width="100%" ToolTip="批号"></asp:textbox></TD>
		<TD width="60"><asp:textbox id="txtItemPrice" runat="server" Width="100%" ToolTip="单价"></asp:textbox></TD>
		<TD width="50"><asp:textbox id="txtReqNum" runat="server" Width="100%" ToolTip="应收数量"></asp:textbox></TD>
		<TD width="130">
			<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD><asp:textbox id="txtTaxRate" runat="server" Width="100%" ToolTip="税率"></asp:textbox></TD>
					<TD><asp:textbox id="txtItemNum" runat="server" Width="100%" ToolTip="实收数量"></asp:textbox></TD>
					<TD width="30"><FONT face="宋体"><uc1:storagedropdownlist id="ddlCon" runat="server"></uc1:storagedropdownlist></FONT></TD>
				</TR>
			</TABLE>
		</TD>
		<TD><asp:button id="btnAddItem" tabIndex="50" runat="server" Text="新增" onclick="btnAddItem_Click"></asp:button><asp:button id="btnDelItem" tabIndex="40" runat="server" Text="删除" onclick="btnDelItem_Click"></asp:button><asp:button id="btnEditItem" tabIndex="40" runat="server" Text="编辑" onclick="btnEdit_Click"></asp:button></TD>
	</TR>
	<TR>
		<TD vAlign="top" colSpan="9" height="160"><uc1:dgmodel_items id="DGModel_Items1" runat="server"></uc1:dgmodel_items></TD>
	</TR>
	<TR>
		<TD colSpan="10"><FONT face="宋体">备注<asp:textbox id="txtRemark" runat="server" Width="100%" MaxLength="100" TextMode="MultiLine"></asp:textbox></FONT></TD>
	</TR>
</TABLE>
<script language="javascript">
	function document.all.<%=txtItemCode.ClientID%>.onblur()
	{
		document.getElementById("<%=btnForItemCode.ClientID%>").click();
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
	function setEntry(id)
	{
		document.getElementById("<%=txtEntryNo.ClientID%>").value=id;
		document.getElementById("<%=bntForEntryNo.ClientID%>").click();
	}

	
</script>
<INPUT id="txtItemSerial" type="hidden" value="-1" name="Hidden1" runat="server"> 

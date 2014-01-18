<%@ Control Language="c#" AutoEventWireup="True" CodeBehind="PCBRWebControl.ascx.cs"
    Inherits="MZHMM.WebMM.Modules.PCBRWebControl"  %>

<script language="JavaScript" src="../Images/calendar/date.js" type="text/javascript"></script>

<table id="Table2" cellspacing="1" cellpadding="1" width="100%" border="0">
    <tr>
        <td width="100">
            <asp:TextBox ID="txtCitmCode" runat="server" Width="100%" ToolTip="检验项编号"></asp:TextBox>
        </td>
        </TD>
        <td width="100">
            <asp:TextBox ID="txtCitmName" runat="server" Width="100%" ToolTip="检验项名称"></asp:TextBox>
        </td>
        <td width="100">
            <asp:TextBox ID="txtCitmUnit" runat="server" Width="100%" ToolTip="检验项单位"></asp:TextBox>
        </td>
        <td width="200">
            <asp:TextBox ID="txtCitmValue" runat="server" Width="100%" ToolTip="检验值"></asp:TextBox>
        </td>
        <td>
            <asp:Button ID="btnAddItem" TabIndex="50" runat="server" Text="更新" OnClick="btnAddItem_Click">
            </asp:Button><asp:Button ID="btnDelItem" TabIndex="40" runat="server" Text="取消" OnClick="btnDelItem_Click">
            </asp:Button><asp:Button ID="btnEditItem" TabIndex="40" runat="server" Text="编辑"
                OnClick="btnEdit_Click"></asp:Button>
        </td>
    </tr>
    <tr>
        <td valign="top" colspan="8" height="160">
            <uc1:DGModel_Items ID="DGModel_Items1" runat="server"></uc1:DGModel_Items>
        </td>
    </tr>
    <tr>
        <td colspan="10">
            <font face="宋体">备注<asp:TextBox ID="txtRemark" runat="server" Width="100%" MaxLength="100"
                TextMode="MultiLine"></asp:TextBox></font>
        </td>
    </tr>
</table>
<div style="left: 0px; visibility: hidden; position: absolute; top: 0px">
    <table>
        <tr>
            <td>
                <asp:Button ID="btnForItemCode" runat="server" Width="0px" Text="Button" Height="0">
                </asp:Button>
            </td>
        </tr>
    </table>
</div>

<script language="javascript">
	function document.all.<%=txtCitmCode.ClientID%>.onblur()
	{
		document.getElementById("<%=btnForItemCode.ClientID%>").click();
	}
	function document.all.<%=txtCitmCode.ClientID%>.onkeypress()
	{
		if(event.keyCode==13)
		{
			document.getElementById("<%=btnForItemCode.ClientID%>").click();
			return false;
		}		
	}

	function setCode(id)
	{
		document.getElementById("<%=txtCitmCode.ClientID%>").value=id;
	}

	
</script>

<input id="txtItemSerial" type="hidden" value="-1" name="Hidden1" runat="server">

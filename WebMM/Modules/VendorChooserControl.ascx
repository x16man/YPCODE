<%@ Control Language="c#" AutoEventWireup="True" Codebehind="VendorChooserControl.ascx.cs" Inherits="MZHMM.WebMM.Modules.VendorChooserControl" %>
<SCRIPT language="JavaScript" src="../JS/PopupWindow.js"></SCRIPT>
<SCRIPT language="JavaScript">
var testpopup4 = new PopupWindow();
testpopup4.setSize(550,400);
testpopup4.autoHide();
testpopup4.setUrl("/WebCRM/PPRN/PPRNChooser.aspx");

function setPPRNInfo(s)
{
	var ss;
	ss = s.split("|");
	document.getElementById("<%=txtVendorCode.ClientID%>").value=ss[0];//供应商编号
	document.getElementById("<%=txtVendor.ClientID%>").value=ss[1];//供应商名称
}	

</SCRIPT>
<asp:textbox id="txtVendor" runat="server" MaxLength="30"></asp:textbox><asp:textbox id="txtVendorCode" runat="server" cssClass="Hidden"></asp:textbox><A id="anchor4" onclick="testpopup4.showPopup('anchor4',false);return false;" href="#"
	name="anchor4"><IMG src="../Images/ni_search.gif" align="absMiddle" border="0"></A>

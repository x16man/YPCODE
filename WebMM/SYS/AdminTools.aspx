<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Default.Master" AutoEventWireup="true"
    CodeBehind="AdminTools.aspx.cs" Inherits="WebMM.SYS.AdminTools" %>

<%@ MasterType VirtualPath="~/Master/Default.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../CSS/SYS/AdminTools.css" type="text/css" rel="stylesheet" />

    <script type="text/javascript" >
        function setPPRNInfo(s) {
            var idstatus = document.getElementById('idstatus').value;
            //alert(idstatus);
            var ss;
            ss = s.split("|");
            if (idstatus == "1") {
                document.getElementById("<%=txtVendor1.ClientID%>").value = ss[0]; //供应商编号

            }
            else {
                document.getElementById("<%=txtVendorCode2.ClientID%>").value = ss[0]; //供应商编号
                document.getElementById("<%=Textbox2.ClientID%>").value = ss[1]; //供应商名称	
            }
        }
        function setPPRNInfo1(s) {

            var ss;
            ss = s.split("|");
            document.getElementById("<%=txtVendorCode.ClientID%>").value = ss[0]; //供应商编号
            document.getElementById("<%=txtVendor1.ClientID%>").value = ss[1]; //供应商名称	

        }	
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="AjaxHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BodyHolder" runat="server">
   
    	<input type="hidden" id="idstatus" />
			<table border="0"   class="table_toolbar" >
				<TR>
					<TD colspan="2" style="PADDING-RIGHT: 80px; BORDER-TOP: #003399 1px solid; PADDING-LEFT: 5px; PADDING-BOTTOM: 2px; PADDING-TOP: 2px"><FONT class="bold_text">订单修改</FONT></TD>
				</TR>
				<tr>
					<td>
						<table border="0" width="100%">
							<tr>
								<td class="td_label">请输入订单编号:</td>
								<td class="td_content">
									<asp:textbox id="txtEnyNo" runat="server" CssClass="input_txtEnyNo input" MaxLength="30" onchange=""></asp:textbox>
									<a id="anchor4" onclick="testpopup4.showPopup('anchor4',false);return false;" href="#"
										name="anchor4"><img  alt="" src="../Images/ni_search.gif" class="img_EnyNoSearch" /></a>
									<input id="btnProvicerCom" onclick="document.getElementById('idstatus').value = '0';window.open('/WebMM/Purchase/PBSABrowser.aspx?Op=View&amp;PrvCode='+GetCode(),'订单查询',
							'toolbar = no,location=no,directories=no,status=no,menubar=no,scrollbars=yes,resizable=yes,copyhistory=no,width =640,height = 440,left='+(window.screen.width - 640)/2+',top='+(window.screen.height - 440)/2+'')"
										type="button" value="选择" name="btnProvicerCom" runat="server" />
									<div class="hidden">
										<asp:textbox id="txtVendorCode" runat="server"></asp:textbox>
										<asp:textbox id="Textbox2" runat="server"></asp:textbox>
										<asp:textbox id="txtVendorCode2" runat="server"></asp:textbox>
									</div>
								</td>
							</tr>
							<tr>
								<td>供应商应修改为:</td>
								<td>
									<asp:textbox id="txtVendor1" runat="server" CssClass="input_txtVendor1 input" MaxLength="30"></asp:textbox>
									<a id="anchor5" onclick="document.getElementById('idstatus').value = '1';testpopup5.showPopup('anchor5',false);return false;"
										href="#" name="anchor5"><img src="../Images/ni_search.gif" class="img_VendorSearch" /></a>
								</td>
							</tr>
							<tr>
								<td colspan="2">
									<div class="td_submit">
										<asp:button id="btnChangeOrderVendor1" runat="server" Text="修改" onclick="btnChangeOrderVendor1_Click"></asp:button>
									</div>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		
		<script language="JavaScript" type="text/javascript">
		    var testpopup4 = new PopupWindow();
		    testpopup4.setSize(550, 400);
		    testpopup4.autoHide();
		    testpopup4.setUrl('<%= Master.CrmQueryPath %>');

		    var value = GetCode()

		    var testpopup5 = new PopupWindow();
		    testpopup5.setSize(550, 400);
		    //testpopup5.autoHide();
		    testpopup5.setUrl('<%= Master.CrmQueryPath %>');

		    function GetCode() {
		         return document.getElementById("<%=txtVendorCode2.ClientID%>").value;
		    }

		    function setEntry(id) {
		        // 不需要'|'
		        // -->
		        document.getElementById("<%=txtEnyNo.ClientID%>").value = id.toString().substring(0, id.toString().indexOf("|"));
		        //document.getElementById("<%=txtEnyNo.ClientID%>").value = id;    
		        // <--
		        document.getElementById("<%=btnProvicerCom.ClientID%>").click();
		    }
		    function insertItem() {
		        window.opener.setEntry(getSelectedArray()); //setEntry函数，在PBORWebcontrol.ascx文件中。
		        window.close();
		    }
		</script>

</asp:Content>

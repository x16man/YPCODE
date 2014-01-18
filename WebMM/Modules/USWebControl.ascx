<%@ Control Language="c#" AutoEventWireup="True" CodeBehind="USWebControl.ascx.cs"
    Inherits="MZHMM.WebMM.Modules.USWebControl"  %>
<table style="width: 100%">
    <tr>
        <td>
            <asp:TextBox ID="txtUsing" runat="server" style="width:100%;z-index:99;" toolTip="”√Õæ" ></asp:TextBox>
            <asp:HiddenField ID="txtUsingCode" runat="server" />
        </td>
        <td style="width: 30px">
            <input id="btnSubmit" onclick="OpenPurpose()" type="button" class="Commonbutton" style="width:100%;z-index:100;"
                value="..." name="btnSubmit" runat="server" />
        </td>
      
    </tr>
</table>

<script language="javascript" type="text/javascript">

    function setClassfiyCode(ClassfiyCode, Description) {
        document.getElementById("<%=txtUsing.ClientID%>").value = Description;
        document.getElementById("<%=txtUsingCode.ClientID%>").value = ClassfiyCode;
    }
    function OpenPurpose() {
        window.open('../Storage/UsingBrowser.aspx?Flag=<%=Flag%>',
		            '”√Õæ—°‘Ò',
		            'toolbar= no,location=location=no,directories=no,status=no,menubar=no,scrollbars=yes,resizable=yes,copyhistory=no,width =640,height = 440,left=' + (window.screen.width - 640) / 2 + ',top=' + (window.screen.height - 440) / 2);
    }
</script>


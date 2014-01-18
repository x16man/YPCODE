<%@ Page Language="c#" CodeBehind="WITAInput.aspx.cs" AutoEventWireup="True" Inherits="MZHMM.WebMM.Storage.WITAInput" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head  runat="server">
    <title>物料图片上传</title>
    <link href="../CSS/StyleSheet.css" type="text/css" rel="stylesheet">
</head>
<body>
    <form id="Form1" method="post" runat="server">
    <font face="宋体">图片上传（附件容量限制为16M）：
        <table id="Table2" cellspacing="0" cellpadding="0" width="100%" border="0">
            <tr>
                <td>
                    <input id="uploadFile" type="file" size="47" name="uploadFile" runat="server">&nbsp;
                    <asp:Button ID="AttUpload" runat="server" Text="上传" CausesValidation="False" OnClick="AttUpload_Click">
                    </asp:Button><asp:Button ID="refresh" runat="server" Text="Button" Width="0px"></asp:Button>
                </td>
                <td>
                </td>
            </tr>
        </table>
        <asp:DataList ID="AttList" runat="server" RepeatColumns="5" CellSpacing="5">
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top"></ItemStyle>
            <ItemTemplate>
                <a target="_blank" href='WITAView.aspx?PKID=<%# DataBinder.Eval(Container, "DataItem.PKID") %>'>
                    <img src='<%# DataBinder.Eval(Container, "DataItem.MicroImage") %>' title="打开/下载附件"
                        style="border-top-style: none; border-right-style: none; border-left-style: none;
                        border-bottom-style: none" onmouseover='showDelImg(<%# DataBinder.Eval(Container, "DataItem.PKID") %>)'
                        onmouseout='hideDelImg(<%# DataBinder.Eval(Container, "DataItem.PKID") %>)' width="100"
                        height="100">
                </a>
                <img id='delimg<%# DataBinder.Eval(Container, "DataItem.PKID") %>' width="14" height="14"
                    src='../Images/AttPIC/delete.ico' title="删除附件" onclick='if (confirm("您确认要删除该附件吗？")){document.frames["hiddenframe"].location.replace("WITADelete.aspx?PKID=<%# DataBinder.Eval(Container, "DataItem.PKID") %>")}else{return false;}'
                    style="filter=alpha(opacity=0); cursor: hand" onmouseover='showDelImg(<%# DataBinder.Eval(Container, "DataItem.PKID") %>)'
                    onmouseout='hideDelImg(<%# DataBinder.Eval(Container, "DataItem.PKID") %>)'>
                <br>
            </ItemTemplate>
        </asp:DataList></font></form>
    <iframe id="hiddenframe" src="" width="0" height="0"></iframe>

    <script language="javascript">
			var imgOpacity = new Array();
			var Timer = new Array();
			var opcspeed = 5;
			function showDelImg(ImgID)
			{
				if(Timer[ImgID]!=null)
				{
					clearTimeout(Timer[ImgID]);
				}
				addOpcity(ImgID);
			}
			function hideDelImg(ImgID)
			{
				if(Timer[ImgID]!=null)
				{
					clearTimeout(Timer[ImgID]);
				}
				subOpcity(ImgID);
			}			
			function addOpcity(ImgID)
			{				
				if(imgOpacity[ImgID]==null)
				{
					imgOpacity[ImgID]=0;
				}
				if(imgOpacity[ImgID]<100)
				{
					imgOpacity[ImgID]+=opcspeed;
					document.getElementById("delimg"+ImgID).style.filter="alpha(opacity="+imgOpacity[ImgID]+")";
					Timer[ImgID]=setTimeout('addOpcity('+ImgID+')',30);
				}
			}
			function subOpcity(ImgID)
			{				
				if(imgOpacity[ImgID]>0)
				{
					imgOpacity[ImgID]-=opcspeed;
					document.getElementById("delimg"+ImgID).style.filter="alpha(opacity="+imgOpacity[ImgID]+")";
					Timer[ImgID]=setTimeout('subOpcity('+ImgID+')',30);
				}
			}
    </script>

</body>
</html>

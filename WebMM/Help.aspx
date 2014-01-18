<%@ Page Language="c#" CodeBehind="Help.aspx.cs" AutoEventWireup="True" Inherits="MZHMM.WebMM.Help" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head  runat="server">
    <title>Help</title>
    <link href="CSS/PCSTYLES.css" type="text/css" rel="stylesheet">
    <link href="CSS/MZHREPOSITORY.css" type="text/css" rel="stylesheet">
    <link href="CSS/StyleSheet.css" type="text/css" rel="stylesheet">
</head>
<body bottommargin="0" leftmargin="4" topmargin="4" rightmargin="0">
    <form id="Form1" method="post" runat="server">
    <table id="Table2" cellspacing="0" cellpadding="0" width="96%" align="center" border="0">
        <tr>
            <td>
                <table id="Table3" cellspacing="0" cellpadding="0" width="100%" border="0">
                    <tr>
                        <td class="Bold_Text">
                            <asp:Label ID="lb_mainHelpTitle" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <font face="ËÎÌå">&nbsp;&nbsp;&nbsp;
                                <asp:Label ID="lb_mainHelpContent" runat="server"></asp:Label></font>
                        </td>
                    </tr>
                </table>
                <font face="ËÎÌå"></font>
            </td>
        </tr>
        <tr>
            <td style="padding-left: 10px">
                <asp:Repeater ID="Repeater1" runat="server">
                    <ItemTemplate>
                        <table id="Table4" cellspacing="0" cellpadding="0" width="100%" border="0">
                            <tr>
                                <td class="Bold_Text" style="padding-top: 10px">
                                    <a onclick='ExpandSubHelp(<%# DataBinder.Eval(Container, "DataItem.Code") %>,img<%# DataBinder.Eval(Container, "DataItem.Code") %>)'
                                        style="cursor: hand">
                                        <img id='img<%# DataBinder.Eval(Container, "DataItem.Code") %>' alt="" src="Images/ARROW_EXPAND.gif"
                                            align="absMiddle"><%# DataBinder.Eval(Container, "DataItem.Title") %></a>
                                </td>
                            </tr>
                            <tr id='<%# DataBinder.Eval(Container, "DataItem.Code") %>' style="z-index: -1; left: 0px;
                                visibility: hidden; position: absolute; top: 0px">
                                <td>
                                    &nbsp;&nbsp;&nbsp;
                                    <%# DataBinder.Eval(Container, "DataItem.Content")+(DataBinder.Eval(Container, "DataItem.HasChild").ToString()=="Y"?"<a href='Help.aspx?Code="+Server.UrlEncode(DataBinder.Eval(Container, "DataItem.Code").ToString())+"'>ÏêÏ¸</a>":"") %>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:Repeater>
            </td>
        </tr>
    </table>
    </form>

    <script>
			function ExpandSubHelp(id,img)
			{
				if(id.style.visibility=="hidden")
				{
					img.src="Images/arrow_collaps.gif";
					id.style.visibility="visible";
					id.style.position="static";
				}
				else
				{
					img.src="Images/ARROW_EXPAND.gif";
					id.style.visibility="hidden";
					id.style.position="absolute";
				}
			}			
    </script>

</body>
</html>

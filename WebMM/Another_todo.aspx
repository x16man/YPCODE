<%@ Page Language="c#" CodeBehind="Another_todo.aspx.cs" AutoEventWireup="True" Inherits="MZHMM.WebMM.Another_todo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Another_tod</title>
    <link href="./CSS/Anther_todo.css" type="text/css" rel="stylesheet" />

    <script language="JavaScript" src="js/CheckBox.js" type="text/javascript" ></script>

    <script language="javascript" type="text/javascript">

        var oPopup = window.createPopup();
        function PopUp(TitleString) {
            if ("False" == "False") {
                var iX = window.event.x;
                var iY = window.event.y;
                var sMenuText = "";

                sMenuText = TitleString;

                var oPopupBody = oPopup.document.body;
                oPopupBody.style.padding = "0px";
                oPopupBody.style.backgroundColor = "infobackground";
                oPopupBody.style.color = "infotext";
                oPopupBody.style.borderTop = "1px solid threedshadow";
                oPopupBody.style.borderLeft = "1px solid threedshadow";
                oPopupBody.style.borderBottom = "1px solid threeddarkshadow";
                oPopupBody.style.borderRight = "1px solid threeddarkshadow";
                oPopupBody.style.fontFamily = "Tahoma";
                //oPopupBody.style.fontFamily = "宋体";
                oPopupBody.style.fontSize = "9px";
                oPopupBody.innerHTML = sMenuText;
                oPopupBody.style.overflow = "auto";
                oPopupBody.onclick = doClick;
                oPopup.show(iX, iY, 400, 180, document.body);
            }
        }

        function doClick() {
            oPopup.hide();
        }  //end doClick
    </script>
    
    <style type="text/css">
        .hidden
    {
	    display:none;
	    visibility:hidden;
	 }
    </style>

</head>
<body>
    <form id="Form1" method="post" runat="server">
    <table id="Table4" cellspacing="0" cellpadding="0" class="table_toolbar">
        <tr>
            <td valign="top">
                <table id="Table1" cellspacing="0" cellpadding="0" class="table_toolbar">
                    <tr>
                        <td class="td_Title">
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td class="td_Title">
                            <table>
                                <tr>
                                    <td>
                                        <img alt="" src="Images/todo.jpg" />
                                    </td>
                                    <td align="left">
                                        <asp:Button ID="btnYes_Top" runat="server" Text="通过" OnClick="btnYes_Top_Click">
                                        </asp:Button>
                                    </td>
                                    <td>
                                        <asp:Button ID="btnNo_Top" runat="server" Text="退回" OnClick="btnNo_Top_Click"></asp:Button>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td class="tdtitle_left">
                        </td>
                        <td colspan="2" class="tdtitle_middle">
                        </td>
                        <td class="tdtitle_right">
                        </td>
                    </tr>
                    <tr>
                        <td class="tdGeneral">
                        </td>
                        <td class="tdGeneral" colspan="2">
                            <mzh:MzhDataGrid ID="MzhDataGrid1" runat="server" name="MzhMultiSelectDataGrid" selecttype="None"
                                IdCell="0" selectedcolor="Blue" highlightcolor="Gold" AutoGenerateColumns="False"
                                Width="100%">
                                <Columns>
                                    <asp:TemplateColumn>
                                        <HeaderStyle Width="5%" />
                                        <HeaderTemplate>
                                            <input onclick="CA();" type="checkbox" name="allbox">
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="DeleteThis" onclick="javascript:CCA(this);" runat="server"></asp:CheckBox>
                                            <div class="hidden">
                                                <asp:TextBox ID="txtTask_ID" Width="0" runat="server" Text='<%# Eval("Task_ID") %>'>
                                                </asp:TextBox>
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:BoundColumn DataField="Date_Created" HeaderText="日期" DataFormatString="{0:yyyy-MM-dd}">
                                        <HeaderStyle Width="10%" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="ReqDeptName" HeaderText="发起部门">
                                        <HeaderStyle Width="10%" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="ReqReason" HeaderText="用途">
                                        <HeaderStyle Width="20%" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="EntryStateName" HeaderText="状态">
                                        <HeaderStyle Width="10%" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="Assessor1" HeaderText="部门审批">
                                        <HeaderStyle Width="10%" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="Pri" HeaderText="优先级">
                                        <HeaderStyle Width="10%" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="SubTotal" HeaderText="金额">
                                        <HeaderStyle Width="10%" />
                                    </asp:BoundColumn>
                                    <asp:TemplateColumn HeaderText="任务名称">
                                        <HeaderStyle Width="15%" />
                                        <ItemTemplate>
                                            <a href="#" onclick='PopUp("<%# Eval("TitleString") %>")'>
                                                <%# Eval("Task_Name") %>
                                            </a>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                </Columns>
                            </mzh:MzhDataGrid>
                        </td>
                        <td class="tdGeneral">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td align='left'>
                            <asp:Button ID="btnYes_Bottom" runat="server" Text="通过" OnClick="btnYes_Top_Click">
                            </asp:Button><asp:Button ID="btnNo_Bottom" runat="server" Text="退回" OnClick="btnNo_Top_Click">
                            </asp:Button>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr class="tdHidden">
                        <td>
                        </td>
                        <td>
                            <img alt="" src="Images/doing.jpg" />
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr class="tdHidden">
                        <td class="tdtitle_left">
                        </td>
                        <td colspan="2" class="tdtitle_middle">
                        </td>
                        <td class="tdtitle_right">
                        </td>
                    </tr>
                    <tr class="tdHidden">
                        <td class="tdGeneral">
                        </td>
                        <td class="tdGeneral" colspan="2">
                            <mzh:MzhDataGrid ID="MzhDataGrid2" runat="server" name="MzhMultiSelectDataGrid" selecttype="None"
                                selectedcolor="Blue" highlightcolor="Gold" AutoGenerateColumns="False" Width="100%">
                                <Columns>
                                    <asp:BoundColumn DataField="Date_Created" HeaderText="日期" DataFormatString="{0:d}">
                                        <HeaderStyle Width="15%"></HeaderStyle>
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="AuthorName" HeaderText="发起人">
                                        <HeaderStyle Width="15%"></HeaderStyle>
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="EntryStateName" HeaderText="状态">
                                        <HeaderStyle Width="15%"></HeaderStyle>
                                    </asp:BoundColumn>
                                    <asp:TemplateColumn HeaderText="任务名称">
                                        <HeaderStyle Width="55%"></HeaderStyle>
                                        <ItemTemplate>
                                            <a href="#" onclick='OpenWindow("<%# Eval("Task_URL") %>")'>
                                                <%# Eval("Task_Name") %>
                                            </a>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                </Columns>
                            </mzh:MzhDataGrid>
                        </td>
                        <td class="tdGeneral">
                            &nbsp;
                        </td>
                    </tr>
                    <tr class="tdHidden">
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            <img alt="" src="Images/havedone.jpg" />
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td class="tdtitle_left">
                        </td>
                        <td colspan="2" class="tdtitle_middle">
                        </td>
                        <td class="tdtitle_right">
                        </td>
                    </tr>
                    <tr>
                        <td class="tdGeneral">
                        </td>
                        <td class="tdGeneral" colspan="2">
                            <p>
                                <mzh:MzhDataGrid ID="MzhDataGrid3" runat="server" name="MzhMultiSelectDataGrid" selecttype="None"
                                    IdCell="0" selectedcolor="Blue" highlightcolor="Gold" AutoGenerateColumns="False"
                                    Width="100%">
                                    <Columns>
                                        <asp:BoundColumn Visible="false" DataField="ViewURL"></asp:BoundColumn>
                                        <asp:BoundColumn DataField="Date_Completed" HeaderText="操作日期" DataFormatString="{0:d}">
                                            <HeaderStyle Width="15%"></HeaderStyle>
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="AuthorName" HeaderText="发起人">
                                            <HeaderStyle Width="15%"></HeaderStyle>
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="EntryStateName" HeaderText="状态">
                                            <HeaderStyle Width="15%"></HeaderStyle>
                                        </asp:BoundColumn>
                                        <asp:TemplateColumn HeaderText="任务名称">
                                            <HeaderStyle Width="55%"></HeaderStyle>
                                            <ItemTemplate>
                                                <a href="#" onclick='OpenWindow("<%# Eval("ViewURL") %>")'>
                                                    <%# Eval("Task_Name") %>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                    </Columns>
                                </mzh:MzhDataGrid></p>
                        </td>
                        <td class="tdGeneral">
                            <p>
                                &nbsp;</p>
                        </td>
                    </tr>
                    <tr>
                        <td class="tdGeneral">
                        </td>
                        <td class="tdGeneral" colspan="2">
                           
                        </td>
                    </tr>
                    <tr>
                        <td class="tdtitle_left">
                        </td>
                        <td colspan="2" class="tdtitle_middle">
                        </td>
                        <td class="tdtitle_right">
                        </td>
                    </tr>
                    <tr>
                        <td class="tdGeneral">
                        </td>
                        <td class="tdGeneral" colspan="2">
                            <uc1:WUC_DocDowithCount ID="WUC_DocDowithCount1" runat="server"></uc1:WUC_DocDowithCount>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>

    <script language="javascript" type="text/javascript">
        function OpenWindow(url) {
            window.open(url, "Task", "height=500,width=800,toolbar=no,scrollbars=yes,menubar=no,top=" + (window.screen.height - 500) / 2 + ",left=" + (window.screen.width - 800) / 2 + ",location = no, status=no");
        }
    </script>

    </form>
</body>
</html>

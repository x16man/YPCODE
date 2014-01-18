<%@ Page Language="c#" CodeBehind="UserDocDept.aspx.cs" AutoEventWireup="True" Inherits="MZHMM.WebMM.SYS.UserDocDept" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>UserDocDept</title>
    <style type="text/css">
        body
        {
            font-family: Arial,Helvetica,Sans-Serif,simsun;
            font-size: 12px;
            font-style: normal;
            margin: 0px;
            padding: 0px;
        }
        .mzhTitle
        {
            padding:4px 5pt;
	        position:relative;
	        background:#A0C9EB url(../images/bar_bg.gif) repeat-x scroll 0pt -950px;
	        margin:1px 0 1px;
	        font-weight:bold;
	        text-align:left;
	        font-size:13px;
	        color:#1168BD;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="titleclass">
        <mzh:MzhTitle ID="MzhTitle1" runat="server" />
    </div>
    <div>
        <table id="Table1" cellspacing="0" class="table_toolbar" width="100%" style="height: 400"
            border="1">
            <tr class="tr_list" style="height: 400">
                <td style="height: 400">
                    <asp:ListBox ID="lbRole" Height="400" Width="180" runat="server" CssClass="list_Role"
                        AutoPostBack="True" OnSelectedIndexChanged="lbRole_SelectedIndexChanged"></asp:ListBox>
                </td>
                <td style="height: 400">
                    <asp:ListBox ID="lbUser" Height="400" Width="180" runat="server" CssClass="list_Role"
                        AutoPostBack="True" OnSelectedIndexChanged="lbUser_SelectedIndexChanged"></asp:ListBox>
                </td>
                <td style="height: 400">
                    <asp:ListBox ID="lbDocs" Height="400" Width="180" runat="server" CssClass="list_Role"
                        AutoPostBack="True" OnSelectedIndexChanged="lbDocs_SelectedIndexChanged"></asp:ListBox>
                </td>
                <td style="height: 400" valign="top">
                    <uc1:DeptTreeControls ID="DeptTreeControls1" runat="server"></uc1:DeptTreeControls>
                </td>
            </tr>
            <tr>
                <td colspan="4" class="td_submit" align="center">
                    <asp:Button ID="btnSave" runat="server" Text="±£´æ" OnClick="btnSave_Click"></asp:Button>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>

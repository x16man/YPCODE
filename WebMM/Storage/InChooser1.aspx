<%@ Page Language="c#" CodeBehind="InChooser1.aspx.cs" AutoEventWireup="True" Inherits="MZHMM.WebMM.Storage.InChooser1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head  runat="server">
    <title>收料架位选择</title>
    <link href="../CSS/StyleSheet.css" type="text/css" rel="stylesheet">
</head>
<body bottommargin="0" leftmargin="0" topmargin="8" rightmargin="0">
    <form id="Form1" method="post" runat="server">
    <table id="Table1" cellspacing="0" cellpadding="0" width="98%" align="center" border="0">
        <tr>
            <td style="border-right: #ffcc33 1px solid; border-top: #ffcc33 1px solid; border-left: #ffcc33 1px solid;
                border-bottom: #ffcc33 1px solid; background-color: #ffffcc" height="25">
                &nbsp;仓库收料架位选择
            </td>
        </tr>
        <tr>
            <td style="height: 23px">
                <u><font color="#0000ff">
                    <uc1:ConChooserWebControl id="UCStockChoice" runat="server">
                    </uc1:ConChooserWebControl></font></u>
            </td>
        </tr>
        <tr>
            <td style="border-right: #ffcc33 1px solid; border-top: #ffcc33 1px solid; border-left: #ffcc33 1px solid;
                border-bottom: #ffcc33 1px solid; background-color: #ffffcc" height="25">
                <p align="center">
                    &nbsp;
                    <asp:Button ID="btnYes" runat="server" Text="确定" onclick="btnYes_Click"></asp:Button><asp:TextBox ID="Textbox1"
                        runat="server" Width="0px"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button
                            ID="btnCancel" runat="server" Text="取消" onclick="btnCancel_Click"></asp:Button></p>
            </td>
        </tr>
    </table>

  

  

    
    <font face="宋体">+</font>
    </form>
</body>
</html>

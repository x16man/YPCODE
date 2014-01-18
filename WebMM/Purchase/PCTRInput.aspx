<%@ Page Language="c#" CodeBehind="PCTRInput.aspx.cs" AutoEventWireup="True" Inherits="MZHMM.WebMM.Purchase.PCTRInput" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>采购合同输入</title>
    <link href="../CSS/StyleSheet.css" type="text/css" rel="stylesheet">
</head>
<body bottommargin="0" leftmargin="0" topmargin="0" rightmargin="0">
    <form id="Form1" method="post" enctype="multipart/form-data" runat="server">
    <font face="宋体"></font>
    <table class="myTable" id="Table1" cellspacing="1" cellpadding="3" width="90%" border="0"
        align="center">
        <tr class="myTrTitle">
            <td colspan="4">
                <font face="宋体">录入采购合同</font>
            </td>
        </tr>
        <tr class="myTrDualLine">
            <td width="15%">
                <p align="left">
                    合同号</p>
            </td>
            <td width="35%">
                <asp:TextBox ID="txtEntryCode" runat="server" ToolTip="合同号不能重复" MaxLength="30" Width="92%"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RFVEntryCode" runat="server" ErrorMessage="合同号必须输入"
                    ControlToValidate="txtEntryCode" Display="Dynamic">*</asp:RequiredFieldValidator>
                <asp:TextBox ID="txtOldEntryCode" runat="server" Width="0"></asp:TextBox>
            </td>
            <td width="15%">
                <p align="left">
                    合同名称</p>
            </td>
            <td width="35%">
                <asp:TextBox ID="txtEntryName" runat="server" Width="95%" MaxLength="30" ToolTip="请输入合同名称"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RFVEntryName" runat="server" Display="Dynamic" ControlToValidate="txtEntryName"
                    ErrorMessage="合同名称必须输入">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr class="myTrDualLine">
            <td width="15%">
                <p align="left">
                    <font face="宋体">供应商</font></p>
            </td>
            <td width="35%">
                <uc1:StorageDropdownlist ID="ddlPrv" runat="server"></uc1:StorageDropdownlist>
            </td>
            <td width="15%">
                签订日期
            </td>
            <td width="35%">
                <p align="left">
                    <asp:TextBox ID="txtEntryDate" runat="server" Width="136px" MaxLength="30"></asp:TextBox></p>
            </td>
        </tr>
        <tr class="myTrDualLine">
            <td width="15%">
                <p align="left">
                    合同类型</p>
            </td>
            <td width="35%">
                <font face="宋体">
                    <p align="left">
                        <uc1:StorageDropdownlist ID="ddlType" runat="server"></uc1:StorageDropdownlist>
                    </p>
                </font>
            </td>
            <td width="15%">
                <p align="left">
                    负责人</p>
            </td>
            <td width="35%">
                <p align="left">
                    <asp:TextBox ID="txtManager" runat="server" Width="137px" MaxLength="30"></asp:TextBox></p>
            </td>
        </tr>
        <tr class="myTrDualLine">
            <td width="15%">
                <p align="left">
                    总金额</p>
            </td>
            <td width="35%">
                <font face="宋体">
                    <p align="left">
                        <asp:TextBox ID="txtTotalMoney" runat="server" Width="100%" MaxLength="20"></asp:TextBox></p>
                </font>
            </td>
            <td width="15%">
                <p align="left">
                    印花税</p>
            </td>
            <td width="35%">
                <font face="宋体">
                    <p align="left">
                        <asp:TextBox ID="txtStampTax" runat="server" Width="100%" MaxLength="20"></asp:TextBox></p>
                </font>
            </td>
        </tr>
        <tr class="myTrDualLine">
            <td width="15%">
                <font face="宋体"></font><font face="宋体">
                    <p align="left">
                        累计付款</p>
                </font>
            </td>
            <td width="35%">
                <font face="宋体">
                    <p align="left">
                        <asp:TextBox ID="txtPayMoney" runat="server" MaxLength="20" Width="100%"></asp:TextBox></p>
                </font>
            </td>
            <td width="15%">
                <p align="left">
                    剩余款项</p>
            </td>
            <td width="35%">
                <font face="宋体">
                    <p align="left">
                        <asp:TextBox ID="txtLeftMoney" runat="server" MaxLength="30" Width="100%"></asp:TextBox></p>
                </font>
            </td>
        </tr>
        <tr class="myTrDualLine">
            <td width="15%" style="height: 27px">
                <p align="left">
                    开始日期</p>
            </td>
            <td width="35%" style="height: 27px">
                <p align="left">
                    <asp:TextBox ID="txtStartDate" runat="server" MaxLength="15" Width="100%"></asp:TextBox></p>
            </td>
            <td width="15%" style="height: 27px">
                <p align="left">
                    结束日期</p>
            </td>
            <td width="35%" style="height: 27px">
                <p align="left">
                    <asp:TextBox ID="txtEndDate" runat="server" MaxLength="15" Width="100%"></asp:TextBox></p>
            </td>
        </tr>
        <tr class="myTrDualLine">
            <td width="15%">
                <font face="宋体"></font><font face="宋体">
                    <p align="left">
                        款清日期</p>
                </font>
            </td>
            <td width="35%">
                <p align="left">
                    <font face="宋体">
                        <asp:TextBox ID="txtCleanDate" runat="server" Width="100%" MaxLength="15"></asp:TextBox></font></p>
            </td>
            <td width="15%">
                <p align="left">
                    &nbsp;</p>
            </td>
            <td width="35%">
                <p align="left">
                    &nbsp;</p>
            </td>
        </tr>
        <tr class="myTrDualLine">
            <td width="15%">
                <p align="left">
                    备注</p>
            </td>
            <td colspan="3" width="85%">
                <font face="宋体">
                    <p align="left">
                        <asp:TextBox ID="txtRemark" runat="server" MaxLength="100" Width="100%" TextMode="MultiLine"></asp:TextBox></p>
                </font>
            </td>
        </tr>
        <tr class="myTrSubmitLine">
            <td colspan="4">
                <font face="宋体"></font><font face="宋体">
                    <p align="center">
                        <asp:Button ID="btnSubmit" runat="server" Text="提交" OnClick="btnSubmit_Click"></asp:Button></p>
                </font>
            </td>
        </tr>
        <tr class="myTrDualLine">
            <td colspan="4">
                <font face="宋体"></font><font face="宋体"></font><font face="宋体">
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" Width="100%"></asp:ValidationSummary>
                </font>
            </td>
        </tr>
    </table>
    </form>
    <iframe id="hiddenframe" src="" width="0" height="0"></iframe>
    <uc1:VariableStyle ID="VariableStyle1" runat="server"></uc1:VariableStyle>
</body>
</html>

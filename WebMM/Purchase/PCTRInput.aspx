<%@ Page Language="c#" CodeBehind="PCTRInput.aspx.cs" AutoEventWireup="True" Inherits="MZHMM.WebMM.Purchase.PCTRInput" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>�ɹ���ͬ����</title>
    <link href="../CSS/StyleSheet.css" type="text/css" rel="stylesheet">
</head>
<body bottommargin="0" leftmargin="0" topmargin="0" rightmargin="0">
    <form id="Form1" method="post" enctype="multipart/form-data" runat="server">
    <font face="����"></font>
    <table class="myTable" id="Table1" cellspacing="1" cellpadding="3" width="90%" border="0"
        align="center">
        <tr class="myTrTitle">
            <td colspan="4">
                <font face="����">¼��ɹ���ͬ</font>
            </td>
        </tr>
        <tr class="myTrDualLine">
            <td width="15%">
                <p align="left">
                    ��ͬ��</p>
            </td>
            <td width="35%">
                <asp:TextBox ID="txtEntryCode" runat="server" ToolTip="��ͬ�Ų����ظ�" MaxLength="30" Width="92%"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RFVEntryCode" runat="server" ErrorMessage="��ͬ�ű�������"
                    ControlToValidate="txtEntryCode" Display="Dynamic">*</asp:RequiredFieldValidator>
                <asp:TextBox ID="txtOldEntryCode" runat="server" Width="0"></asp:TextBox>
            </td>
            <td width="15%">
                <p align="left">
                    ��ͬ����</p>
            </td>
            <td width="35%">
                <asp:TextBox ID="txtEntryName" runat="server" Width="95%" MaxLength="30" ToolTip="�������ͬ����"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RFVEntryName" runat="server" Display="Dynamic" ControlToValidate="txtEntryName"
                    ErrorMessage="��ͬ���Ʊ�������">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr class="myTrDualLine">
            <td width="15%">
                <p align="left">
                    <font face="����">��Ӧ��</font></p>
            </td>
            <td width="35%">
                <uc1:StorageDropdownlist ID="ddlPrv" runat="server"></uc1:StorageDropdownlist>
            </td>
            <td width="15%">
                ǩ������
            </td>
            <td width="35%">
                <p align="left">
                    <asp:TextBox ID="txtEntryDate" runat="server" Width="136px" MaxLength="30"></asp:TextBox></p>
            </td>
        </tr>
        <tr class="myTrDualLine">
            <td width="15%">
                <p align="left">
                    ��ͬ����</p>
            </td>
            <td width="35%">
                <font face="����">
                    <p align="left">
                        <uc1:StorageDropdownlist ID="ddlType" runat="server"></uc1:StorageDropdownlist>
                    </p>
                </font>
            </td>
            <td width="15%">
                <p align="left">
                    ������</p>
            </td>
            <td width="35%">
                <p align="left">
                    <asp:TextBox ID="txtManager" runat="server" Width="137px" MaxLength="30"></asp:TextBox></p>
            </td>
        </tr>
        <tr class="myTrDualLine">
            <td width="15%">
                <p align="left">
                    �ܽ��</p>
            </td>
            <td width="35%">
                <font face="����">
                    <p align="left">
                        <asp:TextBox ID="txtTotalMoney" runat="server" Width="100%" MaxLength="20"></asp:TextBox></p>
                </font>
            </td>
            <td width="15%">
                <p align="left">
                    ӡ��˰</p>
            </td>
            <td width="35%">
                <font face="����">
                    <p align="left">
                        <asp:TextBox ID="txtStampTax" runat="server" Width="100%" MaxLength="20"></asp:TextBox></p>
                </font>
            </td>
        </tr>
        <tr class="myTrDualLine">
            <td width="15%">
                <font face="����"></font><font face="����">
                    <p align="left">
                        �ۼƸ���</p>
                </font>
            </td>
            <td width="35%">
                <font face="����">
                    <p align="left">
                        <asp:TextBox ID="txtPayMoney" runat="server" MaxLength="20" Width="100%"></asp:TextBox></p>
                </font>
            </td>
            <td width="15%">
                <p align="left">
                    ʣ�����</p>
            </td>
            <td width="35%">
                <font face="����">
                    <p align="left">
                        <asp:TextBox ID="txtLeftMoney" runat="server" MaxLength="30" Width="100%"></asp:TextBox></p>
                </font>
            </td>
        </tr>
        <tr class="myTrDualLine">
            <td width="15%" style="height: 27px">
                <p align="left">
                    ��ʼ����</p>
            </td>
            <td width="35%" style="height: 27px">
                <p align="left">
                    <asp:TextBox ID="txtStartDate" runat="server" MaxLength="15" Width="100%"></asp:TextBox></p>
            </td>
            <td width="15%" style="height: 27px">
                <p align="left">
                    ��������</p>
            </td>
            <td width="35%" style="height: 27px">
                <p align="left">
                    <asp:TextBox ID="txtEndDate" runat="server" MaxLength="15" Width="100%"></asp:TextBox></p>
            </td>
        </tr>
        <tr class="myTrDualLine">
            <td width="15%">
                <font face="����"></font><font face="����">
                    <p align="left">
                        ��������</p>
                </font>
            </td>
            <td width="35%">
                <p align="left">
                    <font face="����">
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
                    ��ע</p>
            </td>
            <td colspan="3" width="85%">
                <font face="����">
                    <p align="left">
                        <asp:TextBox ID="txtRemark" runat="server" MaxLength="100" Width="100%" TextMode="MultiLine"></asp:TextBox></p>
                </font>
            </td>
        </tr>
        <tr class="myTrSubmitLine">
            <td colspan="4">
                <font face="����"></font><font face="����">
                    <p align="center">
                        <asp:Button ID="btnSubmit" runat="server" Text="�ύ" OnClick="btnSubmit_Click"></asp:Button></p>
                </font>
            </td>
        </tr>
        <tr class="myTrDualLine">
            <td colspan="4">
                <font face="����"></font><font face="����"></font><font face="����">
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

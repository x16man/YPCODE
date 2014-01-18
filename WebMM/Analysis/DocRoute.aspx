<%@ Page Language="c#" CodeBehind="DocRoute.aspx.cs" AutoEventWireup="True" Inherits="WebMM.Analysis.DocRoute" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>������Ϣ</title>
    <link href="../CSS/Analysis/DocRoute.css" type="text/css" rel="stylesheet" />
</head>
<body>
    <form id="Form1" method="post" runat="server">
    <table class="table_toolbar">
        <tr>
            <td>
                <igmisc:WebPanel ID="WebPanel_Item" runat="server" Width="100%">
                    <PanelStyle BorderWidth="1px" BorderColor="#002D96" BorderStyle="Solid">
                        <Padding Bottom="1px" Left="1px" Top="1px" Right="1px"></Padding>
                        <BorderDetails WidthTop="0px"></BorderDetails>
                    </PanelStyle>
                    <Header Text="������Ϣ" TextAlignment="Left">
                        <ExpandedAppearance>
                            <Style Height="20px" BorderWidth="1px" Font-Size="10pt" Font-Names="Times New Roman"
                                Font-Bold="True" BorderColor="#002D96" BorderStyle="Solid" ForeColor="White"
                                BackgroundImage="igpnl_office2k3_drk.png">
                                <Padding Bottom="4px" Left="4px" Top="4px" Right="4px" ></Padding></Style>
                        </ExpandedAppearance>
                    </Header>
                    <Template>
                        <table class="table_Item">
                            <tr>
                                <td class="td_ItemLabel">
                                    ���ϱ�ţ�
                                </td>
                                <td class="td_ItemContent">
                                    <asp:Label ID="lblItemCode" runat="server"></asp:Label></asp:TextBox>
                                </td>
                                <td class="td_ItemLabel">
                                    �������ƣ�
                                </td>
                                <td class="td_ItemContent">
                                    <asp:Label ID="lblItemName" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    ����ͺţ�
                                </td>
                                <td>
                                    <asp:Label ID="lblItemSpec" runat="server"></asp:Label>
                                </td>
                                <td>
                                    ��λ��
                                </td>
                                <td>
                                    <asp:Label ID="lblItemUnit" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    ������
                                </td>
                                <td>
                                    <asp:Label ID="lblItemNum" runat="server"></asp:Label>
                                </td>
                                <td>
                                </td>
                                <td>
                                </td>
                            </tr>
                        </table>
                    </Template>
                </igmisc:WebPanel>
            </td>
        </tr>
        <tr>
            <td>
                <table class="table_Panel">
                    <tr>
                        <td>
                            <igmisc:WebPanel ID="WebPanel_Ros" runat="server" Width="100%">
                                <Header Text="�����깺��" TextAlignment="Left">
                                    <ExpandedAppearance>
                                        <Style Font-Bold="True">
                                            <Padding Left="5px" > </Padding></Style>
                                    </ExpandedAppearance>
                                </Header>
                                <Template>
                                    <table class="table_Ros">
                                        <tr>
                                            <td class="td_RosLabel">
                                                �����ˣ�
                                            </td>
                                            <td class="td_RosContent">
                                                <asp:Label ID="lblRosAuthorName" runat="server"></asp:Label>
                                            </td>
                                            <td class="td_RosLabel">
                                                ����������
                                            </td>
                                            <td class="td_RosContent">
                                                <asp:Label ID="lblRosItemNum" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                ��;��
                                            </td>
                                            <td>
                                                <asp:Label ID="lblRosReqReason" runat="server"></asp:Label>
                                            </td>
                                            <td>
                                                �������ڣ�
                                            </td>
                                            <td>
                                                <asp:Label ID="lblRosEntryDate" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                ����������
                                            </td>
                                            <td>
                                                <asp:Label ID="lblRosAssessor1" runat="server"></asp:Label>
                                            </td>
                                            <td>
                                                �������ڣ�
                                            </td>
                                            <td>
                                                <asp:Label ID="lblRosAuditDate1" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                ����������
                                            </td>
                                            <td>
                                                <asp:Label ID="lblRosAssessor2" runat="server"></asp:Label>
                                            </td>
                                            <td>
                                                �������ڣ�
                                            </td>
                                            <td>
                                                <asp:Label ID="lblRosAuditDate2" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                ����������
                                            </td>
                                            <td>
                                                <asp:Label ID="lblRosAssessor3" runat="server"></asp:Label>
                                            </td>
                                            <td>
                                                �������ڣ�
                                            </td>
                                            <td>
                                                <asp:Label ID="lblRosAuditDate3" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                δ���ɲɹ�����������
                                            </td>
                                            <td>
                                                <asp:Label ID="lblRosItemLackNum" runat="server"></asp:Label>
                                            </td>
                                            <td>
                                                δ�������ϵ�������
                                            </td>
                                            <td>
                                                <asp:Label ID="lblRosItemNodrawNum" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </Template>
                            </igmisc:WebPanel>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <igmisc:WebPanel ID="WebPanel_Mrp" runat="server" Width="100%">
                                <Header Text="�¶ȼƻ�����" TextAlignment="Left">
                                    <ExpandedAppearance>
                                        <Style Font-Bold="True">
                                            <Padding Left="5px"></Padding></Style>
                                    </ExpandedAppearance>
                                </Header>
                                <Template>
                                    <table class="table_Mrp">
                                        <tr>
                                            <td class="td_MrpLabel">
                                                �����ˣ�
                                            </td>
                                            <td class="td_MrpContent">
                                                <asp:Label ID="lblMrpAuthorName" runat="server"></asp:Label>
                                            </td>
                                            <td class="td_MrpLabel">
                                                ����������
                                            </td>
                                            <td class="td_MrpContent">
                                                <asp:Label ID="lblMrpItemNum" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                ��;��
                                            </td>
                                            <td>
                                                <asp:Label ID="lblMrpReqReason" runat="server"></asp:Label>
                                            </td>
                                            <td>
                                                �������ڣ�
                                            </td>
                                            <td>
                                                <asp:Label ID="lblMrpEntryDate" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                ��������
                                            </td>
                                            <td>
                                                <asp:Label ID="lblMrpAssessor1" runat="server"></asp:Label>
                                            </td>
                                            <td>
                                                �������ڣ�
                                            </td>
                                            <td>
                                                <asp:Label ID="lblMrpAuditDate1" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                δ���ɲɹ��ƻ�������
                                            </td>
                                            <td>
                                                <asp:Label ID="lblMrpItemLackNum" runat="server"></asp:Label>
                                            </td>
                                            <td>
                                                δ�������ϵ�������
                                            </td>
                                            <td>
                                                <asp:Label ID="lblMrpItemNodrawNum" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </Template>
                            </igmisc:WebPanel>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <igmisc:WebPanel ID="WebPanel_Plan" runat="server" Width="100%">
                                <Header Text="�ɹ��ƻ�" TextAlignment="Left">
                                    <ExpandedAppearance>
                                        <Style Font-Bold="True">
                                            <Padding Left="5px"></Padding ></Style>
                                    </ExpandedAppearance>
                                </Header>
                                <Template>
                                    <table class="table_Plan">
                                        <tr>
                                            <td class="td_PlanLabel">
                                                �ƻ������ˣ�
                                            </td>
                                            <td class="td_PlanContent">
                                                <asp:Label ID="lblPlanAuthorName" runat="server"></asp:Label>
                                            </td>
                                            <td class="td_PlanLabel">
                                                �ƻ�������
                                            </td>
                                            <td class="td_PlanContent">
                                                <asp:Label ID="lblPlanItemNum" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                ���벿�ţ�
                                            </td>
                                            <td>
                                                <asp:Label ID="lblPlanReqDeptName" runat="server"></asp:Label>
                                            </td>
                                            <td>
                                                ��;��
                                            </td>
                                            <td>
                                                <asp:Label ID="lblPlanReqReason" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                ��������
                                            </td>
                                            <td>
                                                <asp:Label ID="lblPlanAssessor1" runat="server"></asp:Label>
                                            </td>
                                            <td>
                                                �������ڣ�
                                            </td>
                                            <td>
                                                <asp:Label ID="lblPlanAuditDate1" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                 ����������
                                            </td>
                                            <td>
                                                <asp:Label ID="lblPlanAssessor2" runat="server"></asp:Label>
                                            </td>
                                            <td>
                                                �������ڣ�
                                            </td>
                                            <td>
                                                <asp:Label ID="lblPlanAuditDate2" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                ����������
                                            </td>
                                            <td>
                                                <asp:Label ID="lblPlanAssessor3" runat="server"></asp:Label>
                                            </td>
                                            <td>
                                                �������ڣ�
                                            </td>
                                            <td>
                                                <asp:Label ID="lblPlanAuditDate3" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                δ���ɲɹ�����������
                                            </td>
                                            <td>
                                                <asp:Label ID="lblPlanItemLackNum" runat="server"></asp:Label>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label61" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </Template>
                            </igmisc:WebPanel>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <igmisc:WebPanel ID="WebPanel_Order" runat="server" Width="100%">
                                <Header Text="�ɹ�����" TextAlignment="Left">
                                    <ExpandedAppearance>
                                        <Style Font-Bold="True">
                                            <Padding Left="5px"></Padding></Style>
                                    </ExpandedAppearance>
                                </Header>
                                <Template>
                                    <table class="table_Order">
                                        <tr>
                                            <td class="td_OrderLabel">
                                                �Ƶ��ˣ�
                                            </td>
                                            <td class="td_OrderContent">
                                                <asp:Label ID="lblOrderAuthorName" runat="server"></asp:Label>
                                            </td>
                                            <td class="td_OrderLabel">
                                                ����������
                                            </td>
                                            <td class="td_OrderContent">
                                                <asp:Label ID="lblOrderItemNum" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                ��Ӧ�̣�
                                            </td>
                                            <td>
                                                <asp:Label ID="lblOrderPrvName" runat="server"></asp:Label>
                                            </td>
                                            <td>
                                                �ɹ�Ա��
                                            </td>
                                            <td>
                                                <asp:Label ID="lblOrderBuyerName" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                �Ƶ����ڣ�
                                            </td>
                                            <td>
                                                <asp:Label ID="lblOrderEntryDate" runat="server"></asp:Label>
                                            </td>
                                            <td>
                                                �ɹ�ȷ�����ڣ�
                                            </td>
                                            <td>
                                                <asp:Label ID="lblOrderAffirmDate" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                ��������
                                            </td>
                                            <td>
                                                <asp:Label ID="lblOrderAssessor1" runat="server"></asp:Label>
                                            </td>
                                            <td>
                                                �������ڣ�
                                            </td>
                                            <td>
                                                <asp:Label ID="lblOrderAuditDate1" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                δ�������ϵ�������
                                            </td>
                                            <td>
                                                <asp:Label ID="lblOrderItemLackNum" runat="server"></asp:Label>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label55" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </Template>
                            </igmisc:WebPanel>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <igmisc:WebPanel ID="WebPanel_Bor" runat="server" Width="100%">
                                <Header Text="�ɹ����ϵ�" TextAlignment="Left">
                                    <ExpandedAppearance>
                                        <Style Font-Bold="True">
                                            <Padding Left="5px"></Padding></Style>
                                    </ExpandedAppearance>
                                </Header>
                                <Template>
                                    <table class="table_Bor">
                                        <tr>
                                            <td class="td_BorLabel">
                                                �Ƶ��ˣ�
                                            </td>
                                            <td class="td_BorContent">
                                                <asp:Label ID="lblBorAuthorName" runat="server"></asp:Label>
                                            </td>
                                            <td class="td_BorLabel">
                                                �Ƶ����ڣ�
                                            </td>
                                            <td class="td_BorContent">
                                                <asp:Label ID="lblBorEntryDate" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                ��Ӧ�̣�
                                            </td>
                                            <td>
                                                <asp:Label ID="lblBorPrvName" runat="server"></asp:Label>
                                            </td>
                                            <td>
                                                �ɹ�Ա��
                                            </td>
                                            <td>
                                                <asp:Label ID="lblBorBuyerName" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                ��Ʊ�ţ�
                                            </td>
                                            <td>
                                                <asp:Label ID="lblBorInvoiceNo" runat="server"></asp:Label>
                                            </td>
                                            <td>
                                                ��ͬ�ţ�
                                            </td>
                                            <td>
                                                <asp:Label ID="lblBorContractCode" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                ���ۣ�
                                            </td>
                                            <td>
                                                <asp:Label ID="lblBorItemPrice" runat="server"></asp:Label>
                                            </td>
                                            <td>
                                                ʵ��������
                                            </td>
                                            <td>
                                                <asp:Label ID="lblBorItemNum" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                ��
                                            </td>
                                            <td>
                                                <asp:Label ID="lblBorItemSum" runat="server"></asp:Label>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                ����������
                                            </td>
                                            <td>
                                                <asp:Label ID="lblBorAssessor1" runat="server"></asp:Label>
                                            </td>
                                            <td>
                                                �������ڣ�
                                            </td>
                                            <td>
                                                <asp:Label ID="lblBorAuditDate1" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                �ֿ����ϣ�
                                            </td>
                                            <td>
                                                <asp:Label ID="lblBorAcceptName" runat="server"></asp:Label>
                                            </td>
                                            <td>
                                                �������ڣ�
                                            </td>
                                            <td>
                                                <asp:Label ID="lblBorAcceptDate" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </Template>
                            </igmisc:WebPanel>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <igmisc:WebPanel ID="WebPanel_Pay" runat="server" Width="100%">
                                <Header Text="�ɹ����ϸ��" TextAlignment="Left">
                                    <ExpandedAppearance>
                                        <Style Font-Bold="True"><Padding Left="5px"></Padding></Style>
                                    </ExpandedAppearance>
                                </Header>
                                <Template>
                                    <table class="table_Pay">
                                        <tr>
                                            <td class="td_PayLabel">
                                                �Ƶ��ˣ�
                                            </td>
                                            <td class="td_PayContent">
                                                <asp:Label ID="lblPayAuthorName" runat="server"></asp:Label>
                                            </td>
                                            <td class="td_PayLabel">
                                                �Ƶ����ڣ�
                                            </td>
                                            <td class="td_PayContent">
                                                <asp:Label ID="lblPayEntryDate" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                ����������
                                            </td>
                                            <td>
                                                <asp:Label ID="lblPayAssessor3" runat="server"></asp:Label>
                                            </td>
                                            <td>
                                                �������ڣ�
                                            </td>
                                            <td>
                                                <asp:Label ID="lblPayAuditDate3" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                ���񸶿
                                            </td>
                                            <td>
                                                <asp:Label ID="lblPayPayerName" runat="server"></asp:Label>
                                            </td>
                                            <td>
                                                �������ڣ�
                                            </td>
                                            <td>
                                                <asp:Label ID="lblPayPayDate" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </Template>
                            </igmisc:WebPanel>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <igmisc:WebPanel ID="WebPanel_Draw" runat="server" Width="100%">
                                <Header Text="���ϵ�" TextAlignment="Left">
                                    <ExpandedAppearance>
                                        <Style Font-Bold="True">
                                            <Padding Left="5px"></Padding></Style>
                                    </ExpandedAppearance>
                                </Header>
                                <Template>
                                    <table class="table_Draw">
                                        <tr>
                                            <td class="td_DrawLabel">
                                                �����ˣ�
                                            </td>
                                            <td class="td_DrawContent">
                                                <asp:Label ID="lblDrawAuthorName" runat="server"></asp:Label>
                                            </td>
                                            <td class="td_DrawLabel">
                                                �������ڣ�
                                            </td>
                                            <td class="td_DrawContent">
                                                <asp:Label ID="lblDrawAcceptDate" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                ��;��
                                            </td>
                                            <td>
                                                <asp:Label ID="lblDrawReqReason" runat="server"></asp:Label>
                                            </td>
                                            <td>
                                                ����������
                                            </td>
                                            <td>
                                                <asp:Label ID="lblDrawItemNum" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </Template>
                            </igmisc:WebPanel>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <igmisc:WebPanel ID="Webpanel_RTS" runat="server" Width="100%">
                                <Header Text="���ϵ�" TextAlignment="Left">
                                    <ExpandedAppearance>
                                        <Style Font-Bold="True">
                                            <Padding Left="5px"></Padding></Style>
                                    </ExpandedAppearance>
                                </Header>
                                <Template>
                                    <table class="table_RTS">
                                        <tr>
                                            <td class="td_RTSLabel">
                                                �����ˣ�
                                            </td>
                                            <td class="td_RTSContent">
                                                <asp:Label ID="lblRTSAuthorName" runat="server"></asp:Label>
                                            </td>
                                            <td class="td_RTSLabel">
                                                �������ڣ�
                                            </td>
                                            <td class="td_RTSContent">
                                                <asp:Label ID="lblRTSDate" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                ��;��
                                            </td>
                                            <td>
                                                <asp:Label ID="lblRTSReqReason" runat="server"></asp:Label>
                                            </td>
                                            <td>
                                                ����������
                                            </td>
                                            <td>
                                                <asp:Label ID="lblRTSItemNum" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </Template>
                            </igmisc:WebPanel>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>

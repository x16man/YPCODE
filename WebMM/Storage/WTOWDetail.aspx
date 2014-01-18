<%@ Page Language="c#" CodeBehind="WTOWDetail.aspx.cs" AutoEventWireup="True" Inherits="MZHMM.WebMM.Storage.WTOWDetail" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01//EN" "http://www.w3.org/TR/html4/strict.dtd">
<html>
<head>
    <title></title>
    <link href="../CSS/Storage/WTOWDetail.css" rel="Stylesheet" type="text/css" />
    <link href="../CSS/DataGrid.css" rel="Stylesheet" type="text/css" />
    <script src="/aspnet_client/Shmzh.Web.UI/jquery-1.2.6.pack.js" type="text/javascript"></script>
    
</head>
<body>
    <form id="Form1" method="post" runat="server">
    <div id="doc">
        <div id="hd">
        </div>
        <div id="bd">
            <table id="Table2" cellspacing="0" style="word-wrap: break-word; word-break: break-all;width:100%;" >
                <tr>
                    <td>
                        <uc1:DocWebControl ID="DocWebControl1" runat="server"></uc1:DocWebControl>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table id="Table4" cellspacing="0" class="table_Item printTb">
                            <tr>
                                <td width="20%"><asp:Label runat="server" ID="lblPurpose" Text="��;���뼰��;������"></asp:Label></td>
                                <td colspan="3" align="left">
                                    <asp:Label ID="lblReason" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td valign="top"><asp:Label runat="server" ID="lblProcessContent" Text="���ݣ�"></asp:Label></td>
                                <td colspan="3" align="left" valign="top">
        <asp:TextBox ID="txtProcessContent" runat="server" TextMode="MultiLine" style="overflow-x:visible;overflow-y:visible;"></asp:TextBox>
                                    
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    ͼֽ��
                                </td>
                                <td>
                                    <asp:Label ID="lblDrawingCount" runat="server"></asp:Label>
                                </td>
                                <td>
                                    ���ţ�
                                </td>
                                <td>
                                    <asp:Label ID="lblProspectusCount" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr class="gridTr">
                                <td colspan="4">
                                    <mzh:MzhDataGrid ID="DGModel_Items1" runat="server" IdCell="0" MultiPageShowMode="DropListMode"
                                        selecttype="SingleSelect" ShowFooter="true" AllowPaging="false" AllowSorting="false"
                                        name="MzhMultiSelectDataGrid" AutoGenerateColumns="False" PageSize="<%$ AppSettings:pageDetailSize %>"
                                        OnItemDataBound="DGModel_Items1_ItemDataBound">
                                        <Columns>
                                            <asp:BoundColumn DataField="ItemCode" SortExpression="ItemCode" HeaderText="���ϱ��">
                                                <ItemStyle Width="12%" />
                                            </asp:BoundColumn>
                                            <asp:BoundColumn DataField="ItemName" SortExpression="ItemName" HeaderText="��������">
                                                <ItemStyle Width="18%" HorizontalAlign="Left" />
                                            </asp:BoundColumn>
                                            <asp:BoundColumn DataField="ItemSpecial" SortExpression="ItemSpecial" HeaderText="����ͺ�">
                                                <ItemStyle Width="10%" HorizontalAlign="Left" />
                                            </asp:BoundColumn>
                                            <asp:BoundColumn DataField="ItemUnit" Visible="false" SortExpression="ItemUnit" HeaderText="��λ">
                                                <ItemStyle Width="10%" />
                                            </asp:BoundColumn>
                                            <asp:BoundColumn DataField="ItemUnitName" SortExpression="ItemUnitName" HeaderText="��λ">
                                                <ItemStyle Width="10%" />
                                            </asp:BoundColumn>
                                            <asp:BoundColumn DataField="StockNum" SortExpression="StockNum" HeaderText="�������">
                                                <ItemStyle Width="10%" />
                                            </asp:BoundColumn>
                                            <asp:BoundColumn DataField="PlanNum" SortExpression="PlanNum" HeaderText="��������">
                                                <ItemStyle Width="10%" />
                                            </asp:BoundColumn>
                                            <asp:BoundColumn DataField="ItemNum" SortExpression="ItemNum" HeaderText="ʵ������">
                                                <ItemStyle Width="10%" />
                                            </asp:BoundColumn>
                                            <asp:BoundColumn DataField="ItemPrice" SortExpression="ItemPrice" HeaderText="����"
                                                FooterText="�ϼ�:">
                                                <ItemStyle HorizontalAlign="Right" Width="10%" />
                                                <FooterStyle Font-Bold="true" HorizontalAlign="Right" />
                                            </asp:BoundColumn>
                                            <asp:BoundColumn DataField="ItemMoney" SortExpression="ItemMoney" DataFormatString="{0:n3}"
                                                HeaderText="���">
                                                <HeaderStyle Width="10%" />
                                                <ItemStyle HorizontalAlign="Right" />
                                                <FooterStyle HorizontalAlign="Right" />
                                            </asp:BoundColumn>
                                        </Columns>
                                    </mzh:MzhDataGrid>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    ��ע��<asp:Label ID="lblRemark" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    <uc1:DocAuditWebControl ID="DocAuditWebControl1" runat="server"></uc1:DocAuditWebControl>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table id="Table3" cellspacing="0" class="table_Footer">
                            <tr>
                                <td>
                                    �Ƶ����ţ�
                                    <asp:Label ID="lblAuthorDept" runat="server"></asp:Label>
                                </td>
                                <td>
                                    �Ƶ��ˣ�
                                    <asp:Label ID="lblAuthorName" runat="server">Label</asp:Label>
                                </td>
                                <td>
                                    ���벿�ţ�
                                    <asp:Label ID="lblReqDept" runat="server"></asp:Label>
                                </td>
                                <td>
                                    �����ˣ�
                                    <asp:Label ID="lblProposer" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    �����ˣ�<asp:Label ID="lbStoManager" runat="server"></asp:Label>
                                </td>
                                <td>
                                </td>
                                <td>
                                </td>
                                <td>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
        <div id="ft">
        </div>
    </div>
    
    </form>
    
</body>
<script type="text/javascript">
    $(function() {
    var txtProcessContent = document.getElementById("txtProcessContent");
    txtProcessContent.style.height = txtProcessContent.scrollHeight+"px";
    });
    </script>
</html>

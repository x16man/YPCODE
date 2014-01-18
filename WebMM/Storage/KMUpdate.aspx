<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Default.Master" AutoEventWireup="true"
    CodeBehind="KMUpdate.aspx.cs" Inherits="WebMM.Storage.KMUpdate" %>

<%@ MasterType VirtualPath="~/Master/Default.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title></title>
    <link href="../CSS/reset-fonts-grids.css" type="text/css" rel="stylesheet" />
    <link href="../CSS/box.css" type="text/css" rel="stylesheet" />
    <style type="text/css">
        H1
        {
            font-weight: bold;
            font-size: 16px;
            text-align: center;
        }
        .hidden
        {
            display: none;
            visibility: hidden;
        }
        TABLE CAPTION
        {
            padding-right: 3px;
            padding-left: 3px;
            font-weight: bold;
            font-size: 13px;
            padding-bottom: 3px;
            padding-top: 3px;
        }
        .pager TD
        {
            border-top: gray 1px dashed;
            height: 22px;
        }
        .pager TD A
        {
            font-weight: normal;
            font-size: 12px;
            color: blue;
            font-family: Arial;
            text-decoration: none;
        }
        .DataGrid
        {
            font-size: 12px;
            font-names: 宋体;
            border-color: gray;
        }
        .m-grid-hd-row
        {
            text-align: center;
            font-weight: bold;
            height: 22px;
        }
        .m-grid-row
        {
            height: 19px;
        }
        .m-grid-row-alt
        {
            height: 19px;
            background-color: white;
        }
        .m-grid-ft-row
        {
            height: 22px;
            border-color: silver;
        }
        .m-grid-page-row
        {
            height: 20px;
            text-align: right;
            vertical-align: middle;
            border: dashed 1px black;
        }
        .m-grid-row-selected
        {
            background-color: red;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="AjaxHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BodyHolder" runat="server">
    <div id="doc3">
        <div id="hd">
        </div>
        <div id="bd">
            <div id="condition">
                <div class="x-box-tl">
                    <div class="x-box-tr">
                        <div class="x-box-tc">
                        </div>
                    </div>
                </div>
                <div class="x-box-ml">
                    <div class="x-box-mr">
                        <div class="x-box-mc">
                            <table cellspacing="3" cellpadding="3" width="100%">
                                <tr>
                                    <td style="width: 10%">
                                        开始日期:
                                    </td>
                                    <td style="width: 23%" align="left">
                                        <mzh:ToolbarCalendar ID="txtBeginDate" runat="server" ReadOnly="true" />
                                    </td>
                                    <td style="width: 10%">
                                        用途:
                                    </td>
                                    <td style="width: 23%" align="left">
                                        <table  style="width:100%">
                                            <tr>
                                                <td style="width:50%;text-align:right">
                                                    <asp:HiddenField ID="txtReqReasonCode" runat="server" />
                                                    <asp:TextBox ID="txtReqReason" runat="server"></asp:TextBox>
                                                </td>
                                                <td style="text-align:left;width:40%;">
                                                    <asp:Button ID="btnClose" runat="server" Text="..." OnClientClick="OpenPurpose()" />
                                                </td>
                                            </tr>
                                        </table>
                                        </span>
                                    </td>
                                    <td style="width: 10%">
                                        物料编号:
                                    </td>
                                    <td style="width: 23%" align="left">
                                        <asp:TextBox ID="txtEntryNo" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        结束日期:
                                    </td>
                                    <td align="left">
                                        <mzh:ToolbarCalendar ID="txtEndDate" runat="server" ReadOnly="true" />
                                    </td>
                                    <td>
                                        物料名称:
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtItemName" runat="server"></asp:TextBox>
                                    </td>
                                    <td colspan="2" align="center">
                                        <asp:Button ID="btnQuery" runat="server" Text="查询" OnClick="btnQuery_Click"></asp:Button>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>
                <div class="x-box-bl">
                    <div class="x-box-br">
                        <div class="x-box-bc">
                        </div>
                    </div>
                </div>
            </div>
            <div id="result">
                <div class="x-box-tl">
                    <div class="x-box-tr">
                        <div class="x-box-tc">
                        </div>
                    </div>
                </div>
                <div class="x-box-ml">
                    <div class="x-box-mr">
                        <div class="x-box-mc" style="word-break: break-all;">
                            <mzh:MzhDataGrid ID="MzhDataGrid1" runat="server" Caption="查询结果" AllowPaging="True"
                                PageSize="<%$ AppSettings:pageSize %>" AllowSorting="true" MultiPageShowMode="DropListMode"
                                AutoGenerateColumns="False" IdCell="0" selecttype="SingleSelect" name="MzhMultiSelectDataGrid"
                                OnPageIndexChanged="MzhDataGrid1_PageIndexChanged" OnSortCommand="DataGrid1_SortCommand"
                                OnItemDataBound="MzhDataGrid1_ItemDataBound">
                                <Columns>
                                    <asp:BoundColumn HeaderText="EntryNoSerialNo" Visible="false"></asp:BoundColumn>
                                    <asp:BoundColumn DataField="EntryNo" HeaderText="编号">
                                        <HeaderStyle Width="40px" HorizontalAlign="Center"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center" Width="40px"></ItemStyle>
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="SerialNo" Visible="true" HeaderText="序号">
                                        <HeaderStyle Width="40px" HorizontalAlign="Center"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center" Width="40px"></ItemStyle>
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="ItemCode" HeaderText="物料编号">
                                        <HeaderStyle Width="80px" HorizontalAlign="Center"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center" Width="80px"></ItemStyle>
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="ItemName" HeaderText="物料名称">
                                        <HeaderStyle Width="90px" HorizontalAlign="Center"></HeaderStyle>
                                        <ItemStyle Width="90px" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="ItemSpecial" HeaderText="型号">
                                        <HeaderStyle Width="30px" HorizontalAlign="Center"></HeaderStyle>
                                        <ItemStyle Width="30px" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="ItemUnitName" HeaderText="单位">
                                        <HeaderStyle Width="40px" HorizontalAlign="Center"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center" Width="40px"></ItemStyle>
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="ItemPrice" HeaderText="单价" DataFormatString="{0:n2}">
                                        <HeaderStyle Width="60px" HorizontalAlign="Center"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Right" Width="60px"></ItemStyle>
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="ItemNum" HeaderText="数量" DataFormatString="{0:n2}">
                                        <HeaderStyle Width="50px" HorizontalAlign="Center"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Right" Width="50px"></ItemStyle>
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="ItemMoney" HeaderText="金额" DataFormatString="{0:n2}">
                                        <HeaderStyle Width="60px" HorizontalAlign="Center"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Right" Width="60px"></ItemStyle>
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="KM1" HeaderText="一级科目">
                                        <HeaderStyle Width="60px" HorizontalAlign="Center"></HeaderStyle>
                                        <ItemStyle Width="60px" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="KM2" HeaderText="二级科目">
                                        <HeaderStyle Width="60px" HorizontalAlign="Center"></HeaderStyle>
                                        <ItemStyle Width="60px" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="KM3" HeaderText="三级科目">
                                        <HeaderStyle Width="70px" HorizontalAlign="Center"></HeaderStyle>
                                        <ItemStyle Width="70px" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="KM4" HeaderText="四级科目">
                                        <HeaderStyle Width="70px" HorizontalAlign="Center"></HeaderStyle>
                                        <ItemStyle Width="70px" />
                                    </asp:BoundColumn>
                                </Columns>
                            </mzh:MzhDataGrid>
                        </div>
                    </div>
                    <div class="x-box-bl">
                        <div class="x-box-br">
                            <div class="x-box-bc">
                            </div>
                        </div>
                    </div>
                    <div id="SQL">
                        <div class="x-box-tl">
                            <div class="x-box-tr">
                                <div class="x-box-tc">
                                </div>
                            </div>
                        </div>
                        <div class="x-box-ml">
                            <div class="x-box-mr">
                                <div class="x-box-mc">
                                    <table width="100%">
                                        <tr style="height: 30">
                                            <td style="width: 9%">
                                                一级科目:
                                            </td>
                                            <td style="width: 13%">
                                                <asp:DropDownList ID="ddlKM1" runat="server">
                                                    <asp:ListItem Value="2241">2241</asp:ListItem>
                                                    <asp:ListItem Value="1604">1604</asp:ListItem>
                                                    <asp:ListItem Value="1403">1403</asp:ListItem>
                                                    <asp:ListItem Value="5001">5001</asp:ListItem>
                                                    <asp:ListItem Value="5101">5101</asp:ListItem>
                                                    <asp:ListItem Value="1221">1221</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td style="width: 9%">
                                                二级科目:
                                            </td>
                                            <td style="width: 13%">
                                                <asp:TextBox ID="txtKM2" runat="server"></asp:TextBox>
                                            </td>
                                            <td style="width: 9%">
                                                三级科目:
                                            </td>
                                            <td style="width: 13%">
                                                <asp:TextBox ID="txtKM3" runat="server"></asp:TextBox><asp:DropDownList ID="ddlKM3"
                                                    runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlKM3_SelectedIndexChanged">
                                                    <asp:ListItem Value="低值易耗品">低值易耗品</asp:ListItem>
                                                    <asp:ListItem Value="化验费">化验费</asp:ListItem>
                                                    <asp:ListItem Value="运输费">运输费</asp:ListItem>
                                                    <asp:ListItem Value="修理费">修理费</asp:ListItem>
                                                    <asp:ListItem Value="机物料消耗">机物料消耗</asp:ListItem>
                                                    <asp:ListItem Value="">空</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td style="width: 9%">
                                                四级科目:
                                            </td>
                                            <td style="width: 13%">
                                                <asp:TextBox ID="txtKM4" runat="server"></asp:TextBox>
                                            </td>
                                            <td style="width: 16%">
                                                <asp:Button ID="btnUpdate" runat="server" Text="确定" OnClick="btnUpdate_Click"></asp:Button>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                        </div>
                        <div class="x-box-bl">
                            <div class="x-box-br">
                                <div class="x-box-bc">
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="hidden">
                <asp:TextBox ID="txtCurrentEntryNo" runat="server"></asp:TextBox><asp:TextBox ID="txtCurrentSerialNo"
                    runat="server"></asp:TextBox><asp:Button ID="btnEditItemKM" runat="server" Text="Edit KM"
                        OnClick="btnEditItemKM_Click"></asp:Button>
            </div>
            <div class="hidden" id="ft">
            </div>
        </div>

        <script type="text/javascript">
            function OpenPurpose() {
                window.open('UsingBrowser.aspx?Flag=0',
						'用途选择',
						'toolbar= no,location=location=no,directories=no,status=no,menubar=no,scrollbars=yes,resizable=yes,copyhistory=no,width =640,height = 440,left=' + (window.screen.width - 640) / 2 + ',top=' + (window.screen.height - 440) / 2);
            }
            function EditItemKM(/*Int*/entryNo, /*smallint*/serialNo) {
                document.getElementById("<%=txtCurrentEntryNo.ClientID %>").value = entryNo;
                document.getElementById("<%=txtCurrentSerialNo.ClientID %>").value = serialNo;
                document.getElementById("<%=btnEditItemKM.ClientID %>").click();
            }
            function setClassfiyCode(reqReasonCode, reqReason) {
                document.getElementById("<%=txtReqReasonCode.ClientID %>").value = reqReasonCode;
                document.getElementById("<%=txtReqReason.ClientID %>").value = reqReason;
            }
        </script>
</asp:Content>

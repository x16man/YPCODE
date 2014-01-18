<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InventoryDetail.aspx.cs"
    Inherits="WebMM.Storage.InventoryDetail" %>
<html>
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="../CSS/Storage/InventoryDetail.css" />
    <script src="/aspnet_client/Shmzh.Web.UI/jquery-1.2.6.pack.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table width="100%">
            <tr><td colspan="2"><h1>库存盘点记录</h1></td></tr>
            <tr>
                <td width="10%">
                    名称：
                </td>
                <td colspan="3">
                    <asp:TextBox runat="server" ID="txtName" Width="100%" MaxLength="50"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td width="100px">
                    仓库：
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtStorage" Width="100%" ReadOnly="true"></asp:TextBox>
                </td>
                <td width="100px">
                    日期：
                </td>
                <td width="100px">
                    <mzh:ToolbarCalendar ID="txtDate" ReadOnly="True" runat="server"></mzh:ToolbarCalendar>
                </td>
            </tr>
            <tr>
                <td>
                    备注：
                </td>
                <td colspan="3">
                    <asp:TextBox runat="server" ID="txtRemark" TextMode="MultiLine" Width="100%" Rows="3" MaxLength="255"></asp:TextBox>
                </td>
            </tr>
        </table>
        <table width="100%">
            <tr>
                <td width="130px"><table width="100%"><tr><td><asp:TextBox runat="server" ID="txtItemCode"></asp:TextBox></td><td width="30px"><input class="Commonbutton" onclick="window.open('../Storage/ItemQuery.aspx','物料查询','toolbar = no,location=no,directories=no,status=no,menubar=no,scrollbars=yes,resizable=yes,copyhistory=no,width =640,height = 440,left='+(window.screen.width - 640)/2+',top='+(window.screen.height - 440)/2+'')"
                            type="button" value="..." width="100%" /></td></tr></table>
                </td>
                <td Width="100px"><asp:TextBox runat="server" ID="txtItemName" Width="100%"></asp:TextBox></td>
                <td Width="100px"><asp:TextBox runat="server" ID="txtItemSpec" Width="100%"></asp:TextBox></td>
                <td Width="70px"><asp:DropDownList runat="server" ID="ddlUnit" Width="100%"></asp:DropDownList></td>
                <td Width="100px"><asp:DropDownList runat="server" ID="ddlCon" Width="100%"></asp:DropDownList></td>
                <td Width="100px"><asp:TextBox runat="server" ID="txtCarrryingAmount" Width="100%"></asp:TextBox></td>
                <td Width="100px"><asp:TextBox runat="server" ID="txtInventoryAmount" Width="100%"></asp:TextBox></td>
                <td style="text-align:right;"><asp:Button runat="server" ID="btnInit" 
                        Text="以账面数量初始化" onclick="btnInit_Click" /><asp:Button runat="server" ID="btnUpdate" 
                        Text="保存" onclick="btnUpdate_Click" /><asp:Button runat="server" ID="btnAdd" text="新增" 
                        onclick="btnAdd_Click" /><asp:Button runat="server" ID="btnDelete" 
                        text="删除" onclick="btnDelete_Click" /></td>
            </tr>
        </table>
        <mzh:MzhDataGrid ID="DataGrid1" runat="server" 
                    PageSize="<%$ AppSettings:pageSize %>" name="MzhMultiSelectDataGrid"
                    AutoGenerateColumns="False" selecttype="SingleSelect" ShowPageSize="True"  
                    AllowSorting="True" IdCell="0"
                    MultiPageShowMode="DropListMode" CauseValidationWhenPaging="False" 
            CssClass="datagrid" HignLightCSS="m-grid-row-over" 
            IsShowTotalRecorderCount="True" SelectedCSS="m-grid-row-selected" 
            ShowGridOnEmptyData="False" ShowRecordsCount="True" SORTEXPRESSION="" 
                    >
                    <Columns>
                        <asp:BoundColumn Visible="False" DataField="Id" HeaderText="Id"></asp:BoundColumn>
                        <asp:BoundColumn DataField="ItemCode" SortExpression="ItemCode" HeaderText="物料编号">
                            <HeaderStyle Width="60px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="ItemName" SortExpression="ItemName" HeaderText="物料名称">
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="ItemSpec" SortExpression="ItemSpec" HeaderText="规格型号">
                             <HeaderStyle Width="100px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="ItemUnit" SortExpression="ItemUnit" HeaderText="单位">
                             <HeaderStyle Width="60px" />
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="ConName" SortExpression="ConName" HeaderText="架位">
                             <HeaderStyle Width="80px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="CarryingAmount" SortExpression="CarryingAmount" HeaderText="账面数量">
                            <HeaderStyle Width="100px" />
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundColumn>
                        <asp:TemplateColumn HeaderText="盘点数量">
                        <HeaderStyle Width="100px" />
                        <ItemStyle HorizontalAlign="Right" />
                            <ItemTemplate>
                                <asp:TextBox id="txtInventoryAmount" runat="server" width="100%" 
                                    Text='<%# DataBinder.Eval(Container, "DataItem.InventoryAmount") %>'></asp:TextBox></ItemTemplate>
                        </asp:TemplateColumn>
                    </Columns>
                </mzh:MzhDataGrid>
    </div>
    <div class="hidden"><asp:TextBox runat="server" ID="txtId"></asp:TextBox><asp:Button runat="server" ID="btnForItemCode" 
            onclick="btnForItemCode_Click" /></div>
    </form>
    <script type="text/javascript">
        function setCode(id) {
            document.getElementById("<%=txtItemCode.ClientID%>").value = id;
            document.getElementById("<%=btnForItemCode.ClientID%>").click();
        }
    </script>
</body>
</html>

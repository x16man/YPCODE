<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Test.ascx.cs" Inherits="WebMM.Modules.Test" %>
<mzh:MzhDataGrid ID="DataGrid1" runat="server" IdCell="0" MultiPageShowMode="DropListMode"
    selecttype="SingleSelect" name="MzhMultiSelectDataGrid" AutoGenerateColumns="False">
    <Columns>
        <asp:BoundColumn Visible="False" DataField="EntryNo" SortExpression="EntryNo" HeaderText="EntryNo">
        </asp:BoundColumn>
        <asp:BoundColumn DataField="EntryCode" SortExpression="EntryCode" HeaderText="单据编号">
        </asp:BoundColumn>
        <asp:BoundColumn DataField="EntryStateName" SortExpression="EntryStateName" HeaderText="状态">
        </asp:BoundColumn>
        <asp:BoundColumn DataField="EntryDate" SortExpression="EntryDate" HeaderText="申请日期"
            DataFormatString="{0:d}">
            <ItemStyle HorizontalAlign="Center"></ItemStyle>
        </asp:BoundColumn>
        <asp:BoundColumn DataField="Proposer" SortExpression="Proposer" HeaderText="申请人">
            <ItemStyle HorizontalAlign="Center"></ItemStyle>
        </asp:BoundColumn>
        <asp:BoundColumn DataField="ReqDeptName" SortExpression="ReqDeptName" HeaderText="申请部门">
        </asp:BoundColumn>
        <asp:BoundColumn DataField="ReqReason" SortExpression="ReqReason" HeaderText="申请理由">
        </asp:BoundColumn>
        <asp:BoundColumn DataField="SubTotal" SortExpression="SubTotal" HeaderText="总金额">
            <ItemStyle HorizontalAlign="Right"></ItemStyle>
        </asp:BoundColumn>
    </Columns>
</mzh:MzhDataGrid>
<asp:HiddenField ID="tb_SelectedArray" runat="server" />
<asp:HiddenField ID="txtSQL" runat="server" />

<script type="text/javascript">
    function tt() {
        alert(<%=DataGrid1.ClientID%>_obj.getSelectedArray());
    }
</script>

<input type="button" value="2323" onclick="tt()" />

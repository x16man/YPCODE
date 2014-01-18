<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WUCHaveDoneList.ascx.cs"
    Inherits="WebMM.Modules.WUCHaveDoneList" %>
<mzh:MzhDataGrid ID="mzhDataGrid1" runat="server" name="MzhMultiSelectDataGrid" SelectType="None"
    EnableViewState="false" IdCell="0" AutoGenerateColumns="False" Width="100%">
    <Columns>
        <asp:BoundColumn DataField="Date_Completed" HeaderText="操作日期" DataFormatString="{0:yyyy-MM-dd}">
            <HeaderStyle Width="80px"></HeaderStyle>
        </asp:BoundColumn>
        <asp:BoundColumn DataField="AuthorName" HeaderText="发起人">
            <HeaderStyle Width="160px"></HeaderStyle>
        </asp:BoundColumn>
        <asp:BoundColumn DataField="EntryStateName" HeaderText="状态">
            <HeaderStyle Width="80px"></HeaderStyle>
        </asp:BoundColumn>
        <asp:TemplateColumn HeaderText="任务名称">
            <ItemTemplate>
                <a href="#" onclick='OpenWindow("<%# Eval("ViewURL") %>")'>
                    <%# Eval("Task_Name") %>
                </a>
            </ItemTemplate>
        </asp:TemplateColumn>
    </Columns>
</mzh:MzhDataGrid>
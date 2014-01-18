<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WUCToDoList.ascx.cs"
    Inherits="WebMM.Modules.WUCToDoList" %>
<%@ Register Src="WUCToolTip.ascx" TagName="WUCToolTip" TagPrefix="uc2" %>

<script type="text/javascript">

    function TopChick() {
        alert('1');
        document.getElementById('<%=btnYesTop.ClientID%>').click();
    }

    function NotopClick() {
        alert('2'); document.getElementById('<%=btnNoTop.ClientID%>').click();
    }
</script>

<style type="text/css">
    .AllToDoList a
    {
       background:transparent url(./images/button_bg.gif) no-repeat scroll 0 0;
        cursor:pointer;
        font-weight:normal;
        height:21px;
        margin:0 5px;
        padding:3px 8px;
        text-align:center;
        width:50px;
    }
    .AllToDoList a:hover 
    {
    	background:transparent url(./images/button_bg_hover.gif) no-repeat scroll 0 0;
        cursor:pointer;
        height:21px;
        margin:0 5px;
        padding:3px 8px;
        text-align:center;
        width:49px;
    }
</style>
<div class="md">
    <div class="hd">
        <h2 class="todoList">
            <span>待办事宜</span> <span id="spanOP" class="AllToDoList" style="float: left; 
                position: absolute; margin-left: 10px; padding: 2px; margin-top: -4px;" runat="server">
                <asp:LinkButton ID="LkYesTop" runat="server" Text="通过" OnClick="LkYesTop_Click" Height="35px"> </asp:LinkButton>
                <asp:LinkButton ID="LkNoTop" runat="server" Text="退回" OnClick="LkNoTop_Click"> </asp:LinkButton>
            </span>
        </h2>
        <div style="display: none">
            <asp:Button ID="btnYesTop" runat="server" Text="通过" OnClick="btnYesTop_Click"></asp:Button>
            <asp:Button ID="btnNoTop" runat="server" Text="退回" OnClick="btnNoTop_Click"></asp:Button>
        </div>
    </div>
    <div class="bd">
        <mzh:MzhDataGrid ID="mzhDataGrid1" EnableViewState="false" runat="server" name="MzhMultiSelectDataGrid"
            SelectType="None" IdCell="0" AutoGenerateColumns="False" Width="100%">
            <Columns>
                <asp:BoundColumn DataField="Date_Created" HeaderText="日期" DataFormatString="{0:yyyy-MM-dd}">
                    <HeaderStyle Width="80px"></HeaderStyle>
                </asp:BoundColumn>
                <asp:BoundColumn DataField="ReqDeptName" HeaderText="部门">
                    <HeaderStyle Width="100px"></HeaderStyle>
                </asp:BoundColumn>
                <asp:BoundColumn DataField="AuthorName" HeaderText="发起人">
                    <HeaderStyle Width="60px"></HeaderStyle>
                </asp:BoundColumn>
                <asp:BoundColumn DataField="EntryStateName" HeaderText="状态">
                    <HeaderStyle Width="80px"></HeaderStyle>
                </asp:BoundColumn>
                <asp:TemplateColumn HeaderText="任务名称">
                    <HeaderStyle></HeaderStyle>
                    <ItemTemplate>
                        <a href="#" onclick='OpenWindow("<%# Eval("Task_URL") %>")'>
                            <%# Eval("Task_Name") %>
                        </a>
                    </ItemTemplate>
                </asp:TemplateColumn>
            </Columns>
        </mzh:MzhDataGrid>
        <div id="anotherToDoListDiv" runat="server">
            <div>
            </div>
            <mzh:MzhDataGrid ID="mzhDataGrid2" runat="server" DataKeyField="Task_ID" name="MzhMultiSelectDataGrid"
                selecttype="None" IdCell="0" AutoGenerateColumns="False">
                <Columns>
                    <asp:TemplateColumn>
                        <HeaderStyle Width="20px" />
                        <HeaderTemplate>
                            <input id="checkAll" onclick="CA();" type="checkbox" class="checkAll" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:CheckBox ID="checkThis" CssClass="checkThis" onclick="CCA();" runat="server">
                            </asp:CheckBox>
                        </ItemTemplate>
                    </asp:TemplateColumn>
                    <asp:BoundColumn DataField="Date_Created" HeaderText="日期" DataFormatString="{0:yyyy-MM-dd}">
                        <HeaderStyle Width="80px" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="ReqDeptName" HeaderText="发起部门">
                        <HeaderStyle Width="100px" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="ReqReason" HeaderText="用途">
                        <HeaderStyle Width="150px" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="EntryStateName" HeaderText="状态">
                        <HeaderStyle Width="60px" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="Assessor1" HeaderText="部门审批">
                        <HeaderStyle Width="60px" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="Pri" HeaderText="优先级">
                        <HeaderStyle Width="60px" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="SubTotal" HeaderText="金额">
                        <HeaderStyle Width="80px" />
                        <ItemStyle CssClass="right" />
                    </asp:BoundColumn>
                    <asp:TemplateColumn HeaderText="任务名称">
                        <ItemTemplate>
                            <a onmouseover="balloon.showTooltip(event,'点击查看摘要。')" onclick="tooptip_ball(event,'div_<%# Eval("Task_ID") %>_<%# Eval("ENTITY_ID") %>')">
                                <%# Eval("Task_Name") %>
                            </a>
                            <div style="display: none" id='div_<%# Eval("Task_ID") %>_<%# Eval("ENTITY_ID") %>'>
                                <uc2:WUCToolTip ID="WUCToolTip1" runat="server" EntryNo='<%# Eval("ENTITY_ID").ToString() %>'
                                    DocCode='<%# Eval("DocCode").ToString() %>' />
                            </div>
                        </ItemTemplate>
                    </asp:TemplateColumn>
                </Columns>
            </mzh:MzhDataGrid>
        </div>
    </div>
</div>

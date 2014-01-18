<%@ Control Language="c#" AutoEventWireup="True" Codebehind="WUC_DocDowithCount.ascx.cs" Inherits="WebMM.Analysis.WUC_DocDowithCount" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>

<mzh:MzhDataGrid id="MzhDataGrid1" runat="server" name="MzhMultiSelectDataGrid" SelectType="None"
		IdCell="0" AutoGenerateColumns="False" SelectedColor="Blue" HighLightColor="Gold" Width="100%">
		<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
		<Columns>
			<asp:BoundColumn DataField="DocName" HeaderText="��������">
				<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
			</asp:BoundColumn>
			<asp:BoundColumn DataField="thisCount" HeaderText="������Ŀ">
				<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
			</asp:BoundColumn>
			<asp:BoundColumn DataField="thisTotal" HeaderText="���½��">
				<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
			</asp:BoundColumn>
			<asp:BoundColumn DataField="PreCount" HeaderText="������Ŀ">
				<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
			</asp:BoundColumn>
			<asp:BoundColumn DataField="PreTotal" HeaderText="���½��">
				<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
			</asp:BoundColumn>
			<asp:BoundColumn DataField="YearCount" HeaderText="������Ŀ">
				<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
			</asp:BoundColumn>
			<asp:BoundColumn DataField="YearTotal" HeaderText="������">
				<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
			</asp:BoundColumn>
		</Columns>
</mzh:MzhDataGrid>

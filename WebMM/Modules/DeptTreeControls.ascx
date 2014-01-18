<%@ Control Language="c#" AutoEventWireup="True" CodeBehind="DeptTreeControls.ascx.cs"
    Inherits="MZHMM.WebMM.Modules.DeptTreeControls" %>
<asp:Panel ID="Panel" Height="400px" ScrollBars="Vertical" runat="server">
    <asp:TreeView   ID="TreeView1" ShowCheckBoxes="Parent,Leaf" Font-Names="ÐÂËÎÌå" 
     ForeColor="Black" Font-Size="14px"
       runat="server" onselectednodechanged="TreeView1_SelectedNodeChanged">
      
    </asp:TreeView>
</asp:Panel>

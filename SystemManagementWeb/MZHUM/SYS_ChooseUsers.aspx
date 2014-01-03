<%@ Page Language="c#" CodeBehind="SYS_ChooseUsers.aspx.cs" AutoEventWireup="True"
    Inherits="SystemManagement.MZHUM.SYS_ChooseUsers" %>
<html>
<head>
    <title>���û�ѡ��</title>
    <link rel="stylesheet" type="text/css" href="../CSS/common.css" />
    <link rel="Stylesheet" type="text/css" href="../CSS/treeStyle.css" />
    <link rel="Stylesheet" type="text/css" href="../CSS/MZHUM/SYS_ChooseUsers.css" />
    
</head>
<body>
    <form id="Form1" method="post" runat="server">
    <div id="treeWrapper">
        <div class="tabBar">
        <asp:Image ID="Image1" ToolTip="�л����û��б�" Visible="false" runat="server" ImageUrl="../Images/USER.png" onclick="showDeptTree()" style="cursor:pointer;"/>
        <asp:Image ID="Image2" tooltip="�л������б�" Visible="false" runat="server" ImageUrl="../Images/GROUP.png" onclick="showGroupTree()" style="cursor:pointer;"/>
        </div>
        <ComponentArt:TreeView ID="tvDept" runat="server" Height="300px" CssClass="TreeView" NodeCssClass="TreeNode"
            SelectedNodeCssClass="SelectedTreeNode" HoverNodeCssClass="HoverTreeNode" LineImageWidth="19"
            LineImageHeight="20" DefaultImageWidth="16" DefaultImageHeight="16" NodeLabelPadding="3"
            ImagesBaseUrl="../Images/treeview_images/" ParentNodeImageUrl="folders.gif" LeafNodeImageUrl="folder.gif"
            ShowLines="true" LineImagesFolderUrl="../Images/treeview_images/lines/" DragAndDropEnabled="False"
            AutoPostBackOnNodeMove="False" AutoPostBackOnSelect="False" AutoScroll="True"
            CausesValidation="False" CollapseNodeOnSelect="False" RenderSearchEngineStamp="False"
            RenderSearchEngineStructure="False">
        </ComponentArt:TreeView>
        <ComponentArt:TreeView ID="tvGroup" runat="server" Height="300px" CssClass="TreeView" NodeCssClass="TreeNode"
            SelectedNodeCssClass="SelectedTreeNode" HoverNodeCssClass="HoverTreeNode" LineImageWidth="19"
            LineImageHeight="20" DefaultImageWidth="16" DefaultImageHeight="16" NodeLabelPadding="3"
            ImagesBaseUrl="../Images/treeview_images/" ParentNodeImageUrl="folders.gif" LeafNodeImageUrl="Group.png"
            ShowLines="true" LineImagesFolderUrl="../Images/treeview_images/lines/" DragAndDropEnabled="False"
            AutoPostBackOnNodeMove="False" AutoPostBackOnSelect="False" AutoScroll="True"
            CausesValidation="False" CollapseNodeOnSelect="False" RenderSearchEngineStamp="False"
            RenderSearchEngineStructure="False">
        </ComponentArt:TreeView>
    </div>
    <div style="text-align:right;padding-top:10px;padding-right:40px;">
        <asp:Button ID="btnSubmit" runat="server" Text="�ύ" OnClick="btnSubmit_Click" />&nbsp;&nbsp;&nbsp;
        <input onclick="window.close()" type="button" value="ȡ��" />
    </div>

    <script type="text/javascript">
			String.prototype.trim = function()
			{
				// ��������ʽ��ǰ��ո�
				// �ÿ��ַ��������
				return this.replace(/(^\s*)|(\s*$)/g, "");
			}
			function returnValues()
			{
				//window.opener.setUserInfo();
				window.close();
			}
			var ID_container = new Array(<%=IdInitializtion%>);
			var Name_container = new Array(<%=NameInitializtion%>);
			
			
			var ID_container2 = new Array(<%=GroupIdInitializtion%>);
			var Name_container2 = new Array(<%=GroupNameInitializtion%>);			
			
			function showDeptTree()
			{			
				document.getElementById("tvDept").style.visibility="visible";
				document.getElementById("tvDept").style.position="static";
				document.getElementById("tvGroup").style.visibility="hidden";
				document.getElementById("tvGroup").style.position="absolute";
			}
			
			function showGroupTree()
			{
				document.getElementById("tvDept").style.visibility="hidden";
				document.getElementById("tvDept").style.position="absolute";
				document.getElementById("tvGroup").style.visibility="visible";
				document.getElementById("tvGroup").style.position="static";
			}
    </script>

    </form>
</body>
</html>

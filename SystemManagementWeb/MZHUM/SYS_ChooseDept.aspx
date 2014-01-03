<%@ Page language="c#" Codebehind="SYS_ChooseDept.aspx.cs" AutoEventWireup="True" Inherits="SystemManagement.MZHUM.SYS_ChooseDept" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
	<head>
		<title>≤ø√≈—°‘Ò</title>
		<link rel="stylesheet" type="text/css" href="../CSS/reset.css" />
        <link rel="Stylesheet" type="text/css" href="../CSS/treeStyle.css" />
        <script type="text/javascript">
            function tvDept_onNodeSelect(sender, eventArgs) {
                var deptCode = eventArgs.get_node().get_value();
                
                var deptName = eventArgs.get_node().get_text();
                window.opener.setDeptInfo(deptCode,deptName); 
                window.close();
            }
        </script>
        <style type="text/css">#tvDept{height:400px;}</style>
	</head>
	<body>
		<form id="Form1" method="post" runat="server">
		<ComponentArt:TreeView ID="tvDept" runat="server" CssClass="TreeView" NodeCssClass="TreeNode"
            SelectedNodeCssClass="SelectedTreeNode" HoverNodeCssClass="HoverTreeNode" LineImageWidth="19"
            LineImageHeight="20" DefaultImageWidth="16" DefaultImageHeight="16" NodeLabelPadding="3"
            ImagesBaseUrl="../Images/treeview_images/" 
            ParentNodeImageUrl="folders.gif" LeafNodeImageUrl="folder.gif"
            ShowLines="true" LineImagesFolderUrl="../Images/treeview_images/lines/" DragAndDropEnabled="False"
            AutoPostBackOnNodeMove="False" AutoPostBackOnSelect="True" AutoScroll="True"
            CausesValidation="False"
            CollapseNodeOnSelect="False" RenderSearchEngineStamp="False" 
            RenderSearchEngineStructure="False">
            <ClientEvents>
                <NodeSelect EventHandler="tvDept_onNodeSelect" />
            </ClientEvents>
        </ComponentArt:TreeView>
		</form>
	</body>
</html>

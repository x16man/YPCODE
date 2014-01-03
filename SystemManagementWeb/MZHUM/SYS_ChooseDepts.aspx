<%@ Page Language="c#" CodeBehind="SYS_ChooseDepts.aspx.cs" AutoEventWireup="True"
    Inherits="SystemManagement.MZHUM.SYS_ChooseDepts" %>

<html>
<head>
    <title>多部门选择</title>
    <link rel="stylesheet" type="text/css" href="../CSS/common.css" />
    <link rel="Stylesheet" type="text/css" href="../CSS/treeStyle.css" />
    <style type="text/css">#tvDept{height:350px;}</style>
</head>
<body>
    <form id="Form1" method="post" runat="server">
        <div id="tvWrapper">
        <ComponentArt:TreeView ID="tvDept" runat="server" CssClass="TreeView" NodeCssClass="TreeNode"
            SelectedNodeCssClass="SelectedTreeNode" HoverNodeCssClass="HoverTreeNode" LineImageWidth="19"
            LineImageHeight="20" DefaultImageWidth="16" DefaultImageHeight="16" NodeLabelPadding="3"
            ImagesBaseUrl="../Images/treeview_images/" 
            ParentNodeImageUrl="folders.gif" LeafNodeImageUrl="folder.gif"
            ShowLines="true" LineImagesFolderUrl="../Images/treeview_images/lines/" DragAndDropEnabled="False"
            AutoPostBackOnNodeMove="False" AutoPostBackOnSelect="False" AutoScroll="True"
            CausesValidation="False" 
            CollapseNodeOnSelect="False" 
            RenderSearchEngineStamp="False"
            RenderSearchEngineStructure="False">
        </ComponentArt:TreeView>
        </div>
        <div style="text-align:right;padding-top:10px;padding-right:20px;border-top:solid 1px gray;">
            <asp:Button ID="btnSubmit" runat="server" Text="提交" OnClick="btnSubmit_Click" />&nbsp;&nbsp;&nbsp;
            <input onclick="window.close()" type="button" value="取消" />
        </div>
    </form>
    <script type="text/javascript">
			String.prototype.trim = function()
			{
				// 用正则表达式将前后空格
				// 用空字符串替代。
				return this.replace(/(^\s*)|(\s*$)/g, "");
			}
			function returnValues()
			{
				//window.opener.setUserInfo();
				window.close();
			}
			var ID_container = new Array(<%=IdInitializtion%>);
			var Name_container = new Array(<%=NameInitializtion%>);
    </script>
</body>
</html>

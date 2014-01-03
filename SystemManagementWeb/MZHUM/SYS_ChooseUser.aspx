<%@ Page Language="c#" CodeBehind="SYS_ChooseUser.aspx.cs" AutoEventWireup="True"
    Inherits="SystemManagement.MZHUM.SYS_ChooseUser" %>

<html>
<head>
    <title>”√ªß—°‘Ò</title>
    <link rel="stylesheet" type="text/css" href="../CSS/reset.css" />
    <link rel="Stylesheet" type="text/css" href="../CSS/treeStyle.css" />

    <script type="text/javascript">
        function tvUser_onNodeSelect(sender, eventArgs) {
            var selectedNode = eventArgs.get_node();
            var childNodes = selectedNode.get_nodes().get_nodeArray();
            if (childNodes.length == 0) {
                var userInfo = selectedNode.get_value();
                var aUserInfo = userInfo.split("|");
                var loginName = aUserInfo[0];
                var empCode = aUserInfo[1];
                var empName = aUserInfo[2];
                var deptCode = aUserInfo[3];
                var deptName = aUserInfo[4];
                var pkid = aUserInfo[5];
                var dutyName = aUserInfo[6];
                var userName = selectedNode.get_text();
                if (window.opener) {
                    window.opener.setUserInfo(/*string*/loginName, /*string*/empCode, /*string*/empName, /*string*/deptCode, /*string*/deptName, /*int*/pkid, /*string*/dutyName);
                    window.close();
                }
            }
        }
    </script>
    <style type="text/css">#tvUser{height:400px;}</style>
</head>
<body>
    <form id="Form1" method="post" runat="server">
        <ComponentArt:TreeView ID="tvUser" runat="server" CssClass="TreeView" NodeCssClass="TreeNode"
            SelectedNodeCssClass="SelectedTreeNode" HoverNodeCssClass="HoverTreeNode" LineImageWidth="19"
            LineImageHeight="20" DefaultImageWidth="16" DefaultImageHeight="16" NodeLabelPadding="3"
            ImagesBaseUrl="../Images/treeview_images/" ParentNodeImageUrl="folders.gif" LeafNodeImageUrl="folder.gif"
            ShowLines="true" LineImagesFolderUrl="../Images/treeview_images/lines/" AutoScroll="True"
            CausesValidation="False" CollapseNodeOnSelect="False" RenderSearchEngineStamp="False"
            RenderSearchEngineStructure="False" EnableViewState="False">
            <ClientEvents>
                <NodeSelect EventHandler="tvUser_onNodeSelect" />
            </ClientEvents>
        </ComponentArt:TreeView>
    </form>
</body>
</html>

<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Default.Master" AutoEventWireup="true"
    CodeBehind="ChoosePurposeClassify.aspx.cs" Inherits="WebMM.Storage.ChoosePurposeClassify" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>用途分类选择</title>
    <link rel="stylesheet" type="text/css" href="../CSS/reset.css" />
    <link rel="Stylesheet" type="text/css" href="../CSS/treeStyle.css" />

    <script type="text/javascript">
        function tvPurpose_onNodeSelect(sender, eventArgs) {
            var selectedNode = eventArgs.get_node();
           
            var childNodes = selectedNode.get_nodes().get_nodeArray();
            if (childNodes.length == 0) {
                var purposeInfo = selectedNode.get_value();
                var apurposeInfo = purposeInfo.split("|");
                var code = apurposeInfo[0];
                var name = apurposeInfo[1];

                //alert(code);
               // alert(name);
                 window.opener.setPurposeClassifyCode(/*string*/code, /*string*/name);
                 window.close();
            }
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="AjaxHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BodyHolder" runat="server">
    <div style="overflow-y: scroll; overflow-x: hidden; height: 380px;">
        <ComponentArt:TreeView ID="tvPurpose" runat="server" CssClass="TreeView" NodeCssClass="TreeNode"
            SelectedNodeCssClass="SelectedTreeNode" HoverNodeCssClass="HoverTreeNode" LineImageWidth="19"
            LineImageHeight="20" DefaultImageWidth="16" DefaultImageHeight="16" NodeLabelPadding="3"
            ImagesBaseUrl="../Images/treeview_images/" ParentNodeImageUrl="folders.gif" LeafNodeImageUrl="folder.gif"
            ShowLines="true" LineImagesFolderUrl="../Images/treeview_images/lines/" AutoScroll="False"
            CausesValidation="False" CollapseNodeOnSelect="False" RenderSearchEngineStamp="False"
            RenderSearchEngineStructure="False" EnableViewState="False">
            <ClientEvents>
                <NodeSelect EventHandler="tvPurpose_onNodeSelect" />
            </ClientEvents>
        </ComponentArt:TreeView>
    </div>
</asp:Content>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ToDo.aspx.cs" Inherits="WebMM.ToDo" %>

<%@ Import Namespace="MZHMM.WebMM.Common" %>
<%@ Register Src="Modules/WUCFeedBackGrid.ascx" TagName="WUCFeedBackGrid" TagPrefix="uc2" %>
<%@ Register Src="Modules/WUCFeedbackPurchase.ascx" TagName="WUCFeedbackPurchase"
    TagPrefix="uc3" %>
<%@ Register Src="Modules/WUCNoPayed.ascx" TagName="WUCNoPayed" TagPrefix="uc4" %>
<%@ Register Src="Modules/WUCToDoList.ascx" TagName="WUCToDoList" TagPrefix="uc5" %>
<%@ Register Src="Modules/WUCHaveDoneList.ascx" TagName="WUCHaveDoneList" TagPrefix="uc6" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>我的工作</title>
    <link href="CSS/reset-fonts-grids.css" rel="stylesheet" type="text/css" />
    <link href="CSS/DataGrid.css" rel="Stylesheet" type="text/css" />
    <style type="text/css">
        body
        {
            text-align: left;
        }
        .hd
        {
            background-image: url(images/grd-1px_1.4.gif);
            background-repeat: repeat-x;
            background-position: 0 -916px;
            background-color: #ffffff;
            border-color: #B0BEC7 #B0BEC7 #93A6B4;
            border-style: solid;
            border-width: 1px;
            color: #18397C;
            margin: -1px -1px 0;
            padding: 2px 0 0;
        }
        .hd h2
        {
            border-bottom: 1px solid #ffffff;
            font-family: Arial;
            font-size: 100%;
            font-size-adjust: none;
            font-stretch: normal;
            font-style: normal;
            font-variant: normal;
            font-weight: bold;
            line-height: normal;
            padding: 1px 11px;
            position: relative;
        }
        .md
        {
            border: 1px solid #B0BEC7;
            margin: 4px 3px;
        }
        .bd
        {
            padding: 1px 1px;
        }
        a:hover
        {
            text-decoration: underline;
        }
        a:link, a:visited
        {
            text-decoration: none;
        }
        a
        {
            color: #16387C;
        }
    </style>
    <style type="text/css">
        .ReqReason
        {
            border: solid 0px;
            padding: 0px 3px;
            background: #F9F9F9 url(Images/default/grid/grid3-hrow.gif) repeat-x scroll 0 0;
            height: 25px;
        }
        .PurchaseDetailDiv
        {
            border: solid 0px;
            margin-bottom: 3px;
        }
        .PurchaseDetailDiv Table
        {
            width: 100%;
        }
        .PurchaseDetailDiv Table th
        {
            border: solid 1px;
            border-color: #EEEEEE #D0D0D0 #D0D0D0 #EEEEEE;
            text-align: center;
        }
        .PurchaseDetailDiv Table td
        {
            border: solid 1px;
            border-color: #EEEEEE #D0D0D0 #D0D0D0 #EEEEEE;
            border: none;
        }
        h2.todoList a
        {
            font-weight: normal;
        }
        h2.todoList a:hover
        {
            border: solid 1px gray;
            background-color: #eeeeee;
        }
        #rptDraw a
        {
            background: #F9F9F9 url(Images/default/grid/grid3-hrow.gif) repeat-x scroll 0 0;
        }
        #rptDraw a:hover
        {
            background-color: #aaaaaa;
            background: #F9F9F9 url(images/grd-1px_1.4.gif) repeat-x scroll 0 -916px;
        }
        .ReqReason
        {
            border: solid 0px;
            padding: 0px 3px;
            background: #F9F9F9 url(Images/default/grid/grid3-hrow.gif) repeat-x scroll 0 0;
            height: 25px;
        }
        .PurchaseDetailDiv
        {
            border: solid 0px;
            margin-bottom: 3px;
        }
        .PurchaseDetailDiv Table
        {
            width: 100%;
        }
        .PurchaseDetailDiv Table th
        {
            border: solid 1px;
            border-color: #EEEEEE #D0D0D0 #D0D0D0 #EEEEEE;
            text-align: center;
        }
        .PurchaseDetailDiv Table td
        {
            border: solid 1px;
            border-color: #EEEEEE #D0D0D0 #D0D0D0 #EEEEEE;
            border: none;
        }
        #screenshot
        {
            position: absolute;
            border: 1px solid #ccc;
            background: #ccc;
            padding: 1px;
            display: none;
        }
    </style>

    

    <script src="/aspnet_client/Shmzh.Web.UI/jquery-1.2.6.pack.js" type="text/javascript"></script>

    <script src="js/CheckBox.js" type="text/javascript"></script>

    <script src="js/ToDo_ToolTip.js" type="text/javascript"></script>

    <script language="javascript" type="text/javascript">
        function OpenWindow(url) {
            window.open(url, "Task", "height=500,width=800,toolbar=no,scrollbars=yes,menubar=no,top=" + (window.screen.height - 500) / 2 + ",left=" + (window.screen.width - 800) / 2 + ",location = no, status=yes,resizable=yes");
        }

        function popupDraw() {
            var objs = $(".CheckBoxDrawDetail");
            var s = '';
            for (var i = 0; i < objs.length; i++) {
                if (objs[i].checked)
                    s += s == '' ? objs[i].value : ',' + objs[i].value;
            }
            window.open("Storage/DRWInput.aspx?Op=New&TODO=Y&&PKIDs=" + s, '领料单生成', 'toolbar = no,location=no,directories=no,status=no,menubar=no,scrollbars=yes,resizable=yes,copyhistory=no,width =800,height = 600,left=' + (window.screen.width - 800) / 2 + ',top=' + (window.screen.height - 600) / 2 + '');
        }
    </script>
<script type="text/javascript" src="./js/balloon.config.js"></script>

    <script type="text/javascript" src="./js/balloon.js"></script>

    <script type="text/javascript" src="./js/box.js"></script>

    <script type="text/javascript" src="./js/yahoo-dom-event.js"></script>

    <style>
        .tt
        {
            background-color: lightsteelblue;
            color: blue;
            text-decoration: none;
            cursor: pointer;
        }
        .hidden
        {
            display: none;
        }
        pre
        {
            background-color: gainsboro;
            padding: 15px;
            margin-left: 20px;
            margin-right: 20px;
            font-family: courier;
            font-size: 12px;
        }
        b.y
        {
            background-color: yellow;
        }
    </style>
    
    <script type="text/javascript">
        // white balloon with default configuration
        // (see http://www.wormbase.org/wiki/index.php/Balloon_Tooltips)
        var balloon = new Balloon;

        // plain balloon tooltip
        var tooltip = new Balloon;
        BalloonConfig(tooltip, 'GPlain');

        // fading balloon
        var fader = new Balloon;
        BalloonConfig(fader, 'GFade');

        // a plainer popup box
        var box = new Box;
        BalloonConfig(box, 'GBox');

        // a box that fades in/out
        var fadeBox = new Box;
        BalloonConfig(fadeBox, 'GBox');
        fadeBox.bgColor = 'black';
        fadeBox.fontColor = 'white';
        fadeBox.borderStyle = 'none';
        fadeBox.delayTime = 200;
        fadeBox.allowFade = true;
        fadeBox.fadeIn = 750;
        fadeBox.fadeOut = 200;

 </script>
 <script type="text/javascript">
     function refresh() {
         window.history.go(0);
     }
 </script>
</head>
<body>
    <div id="doc1">
        <div id="bd" class="yui-t6">
            <form id="form1" runat="server">
            <div id="yui-main">
                <div class="yui-b" style='<%= this.CurrentUser.HasRight(SysRight.Anothertodo)?"Width:100%;margin-right:0px" : ""  %>'>
                    <uc5:WUCToDoList ID="WUCToDoList1" runat="server" />
                    <div class="md">
                        <div class="hd">
                            <h2>
                                已办事宜</h2>
                        </div>
                        <div class="bd">
                            <uc6:WUCHaveDoneList ID="WUCHaveDoneList1" runat="server" />
                        </div>
                    </div>
                </div>
            </div>
            <div class="yui-b" style='<%= this.CurrentUser.HasRight(SysRight.Anothertodo)?"display:none;margin-right:0px" : "display:block;"  %>'>
                <div class="md">
                    <div class="hd">
                        <h2>
                            待领料信息反馈</h2>
                    </div>
                    <div class="bd">
                        <uc2:WUCFeedBackGrid ID="WUCFeedBackGrid1" runat="server" />
                    </div>
                </div>
                <div class="md">
                    <div class="hd">
                        <h2>
                            采购中信息反馈</h2>
                    </div>
                    <div class="bd">
                        <uc3:WUCFeedbackPurchase ID="WUCFeedbackPurchase1" runat="server" />
                    </div>
                </div>
                <div class="md" style='<%= this.CurrentUser.HasRight(SysRight.TodoWUCNoPayed)?"display:block;": "display:none;"%>'>
                    <div class="hd">
                        <h2>
                            未付款的发票</h2>
                    </div>
                    <div class="bd">
                        <uc4:WUCNoPayed ID="WUCNoPayed1" runat="server" />
                    </div>
                </div>
            </div>
            </form>
        </div>
    </div>
</body>
</html>

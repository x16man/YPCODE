<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SSO.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>LOGIN</title>
    <link href="CSS/login.css" type="text/css" rel="Stylesheet" />
    <!--[if lt IE 7.]>
    <script defer type="text/javascript" src="/aspnet_client/Shmzh.Web.UI/pngfix.js"></script>
    <![endif]-->
    <style type="text/css" media="screen">
        #msg_win{position:absolute;left:0px;display:none;overflow:hidden;z-index:99;border:1px solid #999999;background:#FFFFFF;width:100%;font-size:12px;margin:0px;}
        #msg_win{display:block;top:3px;visibility:visible;opacity:1;}
        #msg_win .icos{position:absolute;top:2px;*top:0px;right:2px;z-index:9;}
        .icos a{float:left;color:#0000FF;margin:1px;text-align:center;font-weight:bold;width:14px;height:22px;line-height:22px;padding:1px;text-decoration:none;font-family:webdings;}
        .icos a:hover{color:#FFCC00;}
        #msg_title{background:#FFFF66;border-bottom:1px solid /*#710B97*/#eeeeee;border-top:1px solid #FFF;border-left:1px solid #FFF;color:#000000;height:25px;line-height:25px;text-indent:5px;font-weight:bold;}
        #msg_content{margin:5px;margin-right:0;width:230px;height:126px;overflow:hidden;}
    </style>
    <style type="text/css" media="print">
	    #msg_win{display:none;}
    </style>
</head>
<body onload="sf();">

    <form id="form1" runat="server">
    <div id="bd">
        <div id="login">
            <table id="content"><tr><td valign="middle" align="right" width="550px"><span id="account">ID：</span><asp:TextBox ID="txtUser" runat="server" TabIndex="1" ></asp:TextBox><span
                    id="password">PW：</span><asp:TextBox ID="txtPassword" runat="server" TextMode="Password"
                        TabIndex="2" onkeyup="if (event.keyCode==13) onClick()"></asp:TextBox></td><td align="left"><a href="#" onclick="onClick();"><img src="Images/登录按钮.jpg" alt="" /></a></td></tr></table>
            <asp:Button ID="btnLogin" runat="server" Text="登 录" Width="60px" OnClick="btnLogin_Click"
                TabIndex="3" style="visibility:hidden;"></asp:Button>
        </div>
    </div>
    <!--<div id="ft">
        <img src="Images\tip.png" width="435px" height="103" alt="" />
        <p>登录成功后，如果没有任何窗口打开，请确认您的浏览器是否开启了弹出窗口拦截功能，如果开启了，请针对本站点关闭弹出窗口拦截功能。</p>
    </div>-->

    <script type="text/javascript">
        function sf() { document.getElementById("txtUser").focus(); }

        function OpenReturnURL(returnURL) {
            var d = new Date();
            window.open(returnURL, "SSORedirect" + d.getTime(), "status=1,toolbar=0,location=1,menubar=0,top=0,left=0,directories=0,resizable=1,scrollbars=1,width=" + screen.width + ",height=" + screen.height);
            window.opener = null;
            window.close();
        }
        function onClick() {
            document.getElementById("btnLogin").click();
        }
        document.getElementById("txtUser").focus();
    </script>

    <!--[if IE 6]>
        <script type="text/JavaScript">
            function OpenReturnURL(returnURL) {
                var d = new Date();
                window.open(returnURL, "SSORedirect"+d.getTime(), "status=1,toolbar=0,location=1,menubar=0,top=0,left=0,directories=0,resizable=1,scrollbars=1,width="+screen.width+",height="+screen.height);
                window.opener=null;
                window.close();
            }
        </script>
    <![endif]-->
    <!--[if GT IE 6]>
        <script type="text/JavaScript">
            function OpenReturnURL(returnURL) {
                var d = new Date();
                window.open(returnURL, "SSORedirect"+d.getTime(), "status=1,toolbar=0,location=1,menubar=0,top=0,left=0,directories=0,resizable=1,scrollbars=1,width="+screen.width+",height="+screen.height);
                window.open('','_top');
                window.opener=null;
                window.close();
            }
        </script>
    <![endif]-->
    </form>
<!-- 窗口内容 -->
<div style="height:20px;"></div>
<div id="msg_win" style="display:block;top:3px;visibility:visible;opacity:1;">
  <div class="icos"><a id="msg_min" title="最小化" href="javascript:void 0">_</a><a id="msg_close" title="关闭" href="javascript:void 0">×</a></div>
  <div id="msg_title">
	  <pre style="text-align:center;font-family:verdana;font-size:80%;height:25px;margin-top:2px;">
	  Welcome! Please used IE7 or IE8, and add this website to your trusted sites.ID is your domain login ID, Initial password is GSKM.
	 </pre>
  </div>
<!--   <div id="msg_content">Welcome! Please used IE7 or IE8, and add this website to your trusted sites.</div>
 --></div>
<script language="javascript">
var Message={
set: function() {//最小化与恢复状态切换
var set=this.minbtn.status == 1?[0,1,'block',this.char[0],'最小化']:[1,0,'none',this.char[1],'恢复'];
this.minbtn.status=set[0];
this.win.style.borderBottomWidth=set[1];
this.content.style.display =set[2];
this.minbtn.innerHTML =set[3]
this.minbtn.title = set[4];
this.win.style.top = this.getY().top;
},
close: function() {//关闭
this.win.style.display = 'none';
window.onscroll = null;
},
setOpacity: function(x) {//设置透明度
var v = x >= 100 ? '': 'Alpha(opacity=' + x + ')';
this.win.style.visibility = x<=0?'hidden':'visible';//IE有绝对或相对定位内容不随父透明度变化的bug
this.win.style.filter = v;
this.win.style.opacity = x / 100;
},
show: function() {//渐显
clearInterval(this.timer2);
var me = this,fx = this.fx(0, 100, 0.1),t = 0;
this.timer2 = setInterval(function() {
t = fx();
me.setOpacity(t[0]);
if (t[1] == 0) {clearInterval(me.timer2)	}
},6);//10 to 6
},
fx: function(a, b, c) {//缓冲计算
var cMath = Math[(a - b) > 0 ? "floor": "ceil"],c = c || 0.1;
return function() {return [a += cMath((b - a) * c), a - b]}
},
getY: function() {//计算移动坐标
var d = document,b = document.body,	e = document.documentElement;
var s = Math.max(b.scrollTop, e.scrollTop);
var h = /BackCompat/i.test(document.compatMode)?b.clientHeight:e.clientHeight;
var h2 = this.win.offsetHeight;
return {foot: s + h + h2 + 2+'px',top: s + h - h2 - 2+'px'}
},
moveTo: function(y) {//移动动画
clearInterval(this.timer);
var me = this,a = parseInt(this.win.style.top)||0;
var fx = this.fx(a, parseInt(y));
var t = 0 ;
this.timer = setInterval(function() {
t = fx();
me.win.style.top = t[0]+'px';
if (t[1] == 0) {
clearInterval(me.timer);
me.bind();
}
},6);//10 to 6
},
bind:function (){//绑定窗口滚动条与大小变化事件
var me=this,st,rt;
window.onscroll = function() {
clearTimeout(st);
clearTimeout(me.timer2);
me.setOpacity(0);
st = setTimeout(function() {
me.win.style.top = me.getY().top;
me.show();
},100);//600 mod 100
};
window.onresize = function (){
clearTimeout(rt);
rt = setTimeout(function() {me.win.style.top = me.getY().top},100);
}
},
init: function() {//创建HTML
function $(id) {return document.getElementById(id)};
this.win=$('msg_win');
var set={minbtn: 'msg_min',closebtn: 'msg_close',title: 'msg_title',content: 'msg_content'};
for (var Id in set) {this[Id] = $(set[Id])};
var me = this;
this.minbtn.onclick = function() {me.set();this.blur()};
this.closebtn.onclick = function() {me.close()};
this.char=navigator.userAgent.toLowerCase().indexOf('firefox')+1?['_','::','×']:['0','2','r'];//FF不支持webdings字体
this.minbtn.innerHTML=this.char[0];
this.closebtn.innerHTML=this.char[2];
setTimeout(function() {//初始化最先位置
me.win.style.display = 'block';
me.win.style.top = me.getY().foot;
me.moveTo(me.getY().top);
},0);
return this;
}
};
Message.init();
</script>
<!-- 浮动提示窗口结束 -->
</body>
</html>

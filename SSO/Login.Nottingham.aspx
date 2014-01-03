<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SSO.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>LOGIN</title>
    <link href="CSS/login.Nottingham.css" type="text/css" rel="Stylesheet" />
    <!--[if lt IE 7.]>
    <script type="text/javascript" src="/aspnet_client/Shmzh.Web.UI/pngfix.js"></script>
    <![endif]-->
</head>
<body onload="sf();">
    <form id="form1" runat="server">
    
    <div id="wrapper">
        <div id="logoWrap">
            <div id="logo">
                <a title="The University of Nottingham Home" href="http://www.nottingham.edu.cn">
                    <img width="170" height="68" style="margin-left: 0px; margin-right: 0px" src="Images/Nottingham/logo.png"
                        alt="The University of Nottingham Logo"></a>
            </div>
        </div>
        <div id="menuWrap">
            <div id="menu">
            </div>
        </div>
        <div id="homepage">
            <div id="otherCampusesWrap">
                <div id="otherCampuses"><table id="content">
                        <tr>
                            <td valign="middle" align="right" width="850px">
                                <span id="account">ID：</span><asp:TextBox ID="txtUser" runat="server" TabIndex="1"></asp:TextBox><span
                                    id="password" style="margin-left:5px;">Password：</span><asp:TextBox ID="txtPassword" runat="server" TextMode="Password"
                                        TabIndex="2" onkeyup="if (event.keyCode==13) onClick()"></asp:TextBox>
                            </td>
                            <td align="left">
                                <ul>
                                    <li><a href="javascript:void(0);" onclick="document.getElementById('btnLogin').click();"><span><span>Sign In</span></span></a> </li>
                                </ul>
                            </td>
                        </tr>
                    </table>
                    
                </div>
            </div>
            <div id="mainFeature">
                <div id="featureWrap1">
                    <div id="featureWrap2">
                        <div id="feature">
                            &nbsp;
                        </div>
                    </div>
                    <div id="slider">
                        <div class="sys_title">
                            <div class="sys_btmWrap" >
                                <div class="sys_btm">
                                    <div style=" color: #ececec;text-align:center;">
                                        <pre style="text-align: center; font-family: verdana; font-size: 13px; height: 16px;line-height:16px;
                margin:0;padding: 0;">
	  Welcome! Please used IE7 or IE8, and add this website to your trusted sites.ID is your domain login ID, Initial password is GSKM.
	 </pre>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="hidden">
            <asp:Button ID="btnLogin" runat="server" Text="登 录" Width="60px" OnClick="btnLogin_Click"
                TabIndex="3" Style="visibility: hidden;"></asp:Button>
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
</body>
</html>

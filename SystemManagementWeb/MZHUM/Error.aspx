<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="SystemManagement.MZHUM.Error" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>错误信息</title>
    <link href="../CSS/Common.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
    html,body
    {
        background:#EBEBEB none repeat scroll 0 0;
        color:#ADADAD;
        font-size:14px;
        font-size-adjust:none;
        font-stretch:normal;
        font-style:normal;
        font-variant:normal;
        font-weight:normal;
        line-height:normal;
    }
    #hd
    {
        background:transparent url(../images/bg-shadow.gif) no-repeat scroll left bottom;
        height:30px;
        margin:0 auto;
        position:relative;
        width:750px;
    }
    #bd
    {
        margin:0 auto;
        position:relative;
        width:750px;
    }
    .block
    {
        background:#ffffff none repeat scroll 0 0;
        border:1px solid #D5D5D5;
        float:left;
        margin-bottom:40px;
        padding:40px 19px 20px;
        position:relative;
        width:710px;
    }
    #bd .block
    {
        height:370px;
        padding:20px 40px 40px;
        width:670px;
    }        
    h1
    {
        color:#A3A1A1;
        font-size:18px;
        text-transform:uppercase;
    }
    #bd h1
    {
        background:transparent url(../images/error.gif) no-repeat scroll left bottom;
        bottom:0;
        height:200px;
        position:absolute;
        right:0px;
        width:200px;
    }
    #bd h1 span,#bd h2 span
    {
        display:none;
    }
    h2
    {
        color:#c6c6c6;
        font-size:16px;
        font-weight:normal;
        margin-bottom:10px;
    }
    #bd h2
    {
        background:transparent url(../images/oops!.gif) no-repeat scroll left top;
        height:105px;
        width:220px;
    }
    #bd .dontWorry
    {
        font-size:15px;
        left:20px;
        position:relative;
        top:3px;
        width:400px;
        text-align:left;
    }
    </style>
</head>
<body>
    <div>   
        <div id="hd"></div> 
        <div id="bd">
            <div class="block">
                <h1><span>Error!</span></h1>
                <h2><span>Oops!</span></h2>
                <div class="dontWorry">
                    <%=ErrorString%><br />
                </div>
            </div>
        </div>
    </div>
</body>
</html>

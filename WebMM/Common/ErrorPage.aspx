﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ErrorPage.aspx.cs" Inherits="MZHMM.WebMM.Common.ErrorPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        	<asp:Label id="Label1" runat="server" Font-Size="Large"></asp:Label>
			<a href="#" onclick="window.history.go(-1)">返回</a>
    </div>
    </form>
</body>
</html>

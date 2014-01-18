<%@ Page Language="c#" CodeBehind="DocStat.aspx.cs" AutoEventWireup="True" Inherits="WebMM.Analysis.DocStat" %>
<%@ Register TagPrefix="uc1" TagName="WUC_DocStatview" Src="WUC_DocStat.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>DocStat</title>
    <link href="../CSS/toolbar.css" type="text/css" rel="stylesheet" />
</head>
<body  bgcolor="#dbeaf5">
    <form id="Form1" method="post" runat="server">
    <uc1:WUC_DocStatview id="WUC_DocStat1" runat="server">
    </uc1:WUC_DocStatview>
    </form>
</body>
</html>

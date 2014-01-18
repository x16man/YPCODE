<%@ Page Language="c#" CodeBehind="CommReport.aspx.cs" AutoEventWireup="True" Inherits="MZHMM.WebMM.Report.CommReport" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>±¨±í</title>
    <meta name="keywords" content="Report">
    <link href="../CSS/Common.css" rel="stylesheet" type="text/css" />
</head>
<body style="height:100%">
    <form id="Form1"  runat="server">
   
        <mzhview:ReportViewer ID="RV_MyReport" runat="server"  height="500px" Width="100%">
        </mzhview:ReportViewer>
    </form>
</body>
</html>

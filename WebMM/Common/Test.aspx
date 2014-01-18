<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="MZHMM.WebMM.Common.Test" %>

<%@ Register src="../Modules/Test.ascx" tagname="Test" tagprefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../CSS/toolbar.css" type="text/css" rel="stylesheet" />
   
</head>
<body>
    <form id="form1" runat="server">
    <div>
       
   <asp:DropDownList ID="dllUsingClassify" runat="server" AutoPostBack="true" onselectedindexchanged="dllUsingClassify_SelectedIndexChanged" 
                 >
                </asp:DropDownList>
                    
                    <asp:Button ID="btn1" runat="server" onclick="btn1_Click" />
            
            
           
    </div>
    </form>
</body>
</html>

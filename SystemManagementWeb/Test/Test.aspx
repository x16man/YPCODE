<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="SystemManagement.Test.Test" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" src="../JS/PopupWindow.js"></script>
    <script type="text/javascript">
        var popupWindow = new PopupWindow();
        function chooseUsers(elmId) {
            var userIds = document.getElementById("txtUserIds").value;
            var groupIds =document.getElementById("txtGroupIds").value;
            popupWindow.setUrl('../MZHUM/SYS_ChooseUsers.aspx?Include=all&WithOutSide=N&WithGroup=Y&UserIds='+userIds+'&GroupIds='+groupIds);
            popupWindow.setSize(250, 400);
            popupWindow.showPopup(elmId, false);
        }
        function setUserInfo(userIds,empCodes,empNames,deptCodes,deptNames,groupIds,groupNames,pkIds) {
            document.getElementById("txtUserIds").value = userIds;//LoginName
	        document.getElementById("txtUserNames").value = empNames;
	        document.getElementById("txtGroupIds").value = groupIds;
	        document.getElementById("txtGroupNames").value = groupNames;
        }


    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        
        <asp:AccessDataSource ID="AccessDataSource1" runat="server" 
            DataFile="~/App_Data/pubdata.mdb" 
            SelectCommand="SELECT [ProductCode], [ProductName], [Isvalid], [Remark] FROM [mySystemProducts]">
        </asp:AccessDataSource>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            DataSourceID="AccessDataSource1">
            <Columns>
                <asp:BoundField DataField="ProductCode" HeaderText="ProductCode" 
                    SortExpression="ProductCode" />
                <asp:BoundField DataField="ProductName" HeaderText="ProductName" 
                    SortExpression="ProductName" />
                <asp:BoundField DataField="Isvalid" HeaderText="Isvalid" 
                    SortExpression="Isvalid" />
                <asp:BoundField DataField="Remark" HeaderText="Remark" 
                    SortExpression="Remark" />
            </Columns>
        </asp:GridView>
        <input type="text" id="txtUserIds"/>
        <input type="text" id="txtUserNames" />
        <input type="text" id="txtGroupIds" />
        <input type="text" id="txtGroupNames" />
        <input type="button" id="btnChooseUser" value="..." onclick="chooseUsers(this.id)"/>
    </div>
    </form>
</body>
</html>

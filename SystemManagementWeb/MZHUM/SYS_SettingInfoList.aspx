<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SYS_SettingInfoList.aspx.cs"
    Inherits="SystemManagement.MZHUM.SYS_SettingInfoList" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../CSS/Common.css" rel="stylesheet" type="text/css" />
    <link href="../CSS/toolbar.css" rel="stylesheet" type="text/css" />
    <link href="../CSS/DataGrid.css" rel="stylesheet" type="text/css" />

    <script src="../JS/jquery-1.2.6.js" type="text/javascript"></script>

    <script src="../JS/PopupWindow.js" type="text/javascript"></script>

    <script language="javascript" type="text/javascript">
        var popupWindow = new PopupWindow();
        popupWindow.setSize(500, 400);
        //新增
        function newItem(elm) {
            popupWindow.setUrl("SYS_SettingInfoEdit.aspx?OP=New" + "&category=" + encodeURIComponent(document.getElementById("<%= hidCategory.ClientID %>").value));
            popupWindow.showPopup(elm, false);
            return false;
        }
        
        //编辑
		function editItem(elm)
		{
			if(<%=dg_SettingInfo.ClientID%>_obj.getSelectedID()!=null&&<%=dg_SettingInfo.ClientID%>_obj.getSelectedID()!="")
			{
				if (<%=dg_SettingInfo.ClientID%>_obj.getSelectedID()!=-1)
				{
					popupWindow.setUrl("SYS_SettingInfoEdit.aspx?Op=Edit&Id="+encodeURIComponent(<%=dg_SettingInfo.ClientID%>_obj.getSelectedID())+"&category=" + encodeURIComponent(document.getElementById("<%= hidCategory.ClientID %>").value));
				    popupWindow.showPopup(elm, false);
                    return false;
				}
			}
			else
			{
				alert("请先选中某一条记录，再进行编辑！");
			}
		}
		//删除
		function deleteItems()
		{
		     if (<%=dg_SettingInfo.ClientID%>_obj.getSelectedArray() != null && <%=dg_SettingInfo.ClientID%>_obj.getSelectedArray() != "") {
                    return confirm("确认要删除选定的内容？")
                }
                else {
                    alert("请先选中记录，再进行删除！");
                    return false;
                }
        }
			
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <mzh:MzhTitle ID="MzhTitle1" runat="server" />
    <div id="main">
        <div class="content">
             <mzh:MzhToolbar ID="MzhToolbar1" runat="server" OnItemPostBack="MzhToolbar1_ItemPostBack">
                <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable"
                        itemid="new" cellspacing="0" nakedlabelclass="nakedLabelCell" isshowtext="True"
                        iconclass="add" hasicon="True" text="新建" id="toolbarButtonadd" onclick="newItem(this.id)">
                    </mzh:toolbarbutton>
                <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable"
                    itemid="Edit" cellspacing="0" nakedlabelclass="nakedLabelCell" isshowtext="True"
                    iconclass="edit" hasicon="True" text="编辑" id="tbiEdit" onclick="editItem(this.id)">
                </mzh:toolbarbutton>
                <mzh:toolbarbutton cellpadding="0" labelclass="labelCell" tableclass="buttonTable"
                    itemid="delete" cellspacing="0" autopostback="True" nakedlabelclass="nakedLabelCell"
                    isshowtext="True" iconclass="delete" hasicon="True" text="删除" id="tbiDelete"
                    onclick="if(!deleteItems()) return;">
                </mzh:toolbarbutton>
            </mzh:MzhToolbar>
            <mzh:MzhDataGrid ID="dg_SettingInfo" runat="server" name="MzhMultiSelectDataGrid"
                selecttype="SingleSelect" IdCell="0" AutoGenerateColumns="False" AllowPaging="True"
                HignLightCSS="m-grid-row-over" cssclassforpagerbuttonjump="m-grid-pager-button-jump"
                SelectedCSS="m-grid-row-selected" CssClass="datagrid" cssclassforpagerinputpage="m-grid-pager-input-page"
                MultiPageShowMode="DropListMode" TotalRecorderCount="0" PageSize="20" AllowSorting="True"
                ShowRecordsCount="True" ShowPageSize="True" ShowGridOnEmptyData="False">
                <HeaderStyle Wrap="False"></HeaderStyle>
                <Columns>
                    <asp:BoundColumn DataField="Key"  SortExpression="Key" HeaderText="关键字">
                        <HeaderStyle Width="200px"/>
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="Value" SortExpression="Value" HeaderText="值">
                        <HeaderStyle Width="100px"></HeaderStyle>
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="Category" SortExpression="Category" HeaderText="类别">
                        <HeaderStyle Width="100px"></HeaderStyle>
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="Remark" SortExpression="Remark" HeaderText="描述">                       
                    </asp:BoundColumn>
                </Columns>
                <PagerStyle HorizontalAlign="Right" Mode="NumericPages"></PagerStyle>
            </mzh:MzhDataGrid>
        </div>
    </div>
    <input type="hidden" id="hidCategory" runat="server" />
    </form>
</body>
</html>

var popupWindow = new PopupWindow();
var tvGroupEventArgument;
function refresh() {
    document.getElementById("btnRefresh").click();
}
function addGroupCat(elm) {
    popupWindow.setSize(400, 300);
    popupWindow.setUrl("SYS_GroupCatEdit.aspx");
    popupWindow.showPopup(elm, false);
    return false;
}
function editGroupCat(elm) {
    var treeview = window.tvGroup;
    if (treeview.SelectedNode == null || treeview.SelectedNode.ID.substr(0,1)!="C") {
        alert("请先选中组分类，再进行编辑！");
    }
    else if (treeview.SelectedNode.Value == 0) {
        alert("其他分类为系统自动生成分类，不能进行编辑！");
    }
    else {
        popupWindow.setSize(400, 300);
        popupWindow.setUrl("SYS_GroupCatEdit.aspx?Id=" + treeview.SelectedNode.ID.substr(1));
        popupWindow.showPopup(elm, false);
        return false;
    }
}
//Confirm Delete Group Cat.
function confirmDeleteGroupCat() {
    var treeview = window.tvGroup;
    if (treeview.SelectedNode == null || treeview.SelectedNode.ID.substr(0, 1) != "C") {
        alert("请先选中组分类，再进行删除！");
    }
    else if (treeview.SelectedNode.Value == 0) {
        alert("其他分类为系统自动生成分类，不能进行删除！");
    }
    //else if (treeview.SelectedNode.Nodes.length > 0) {
    //    alert("该分类下还存在组，不能进行删除！");
    //}
    else {
        return confirm("确认要删除选定的内容？");
    }
}
function addGroup(elm) {
    var treeview = window.tvGroup;
    if (treeview.SelectedNode == null) {
        alert("请先选中组分类，再进行组的添加！");
        return;
    }
    if (treeview.SelectedNode.ID.substr(0,1)=="C") {
        popupWindow.setUrl("SYS_GroupEdit.aspx?GroupCat=" + treeview.SelectedNode.ID.substr(1));
    }
    else {
        popupWindow.setUrl("SYS_GroupEdit.aspx");
    }
    popupWindow.setSize(420, 300);
    
    popupWindow.showPopup(elm, false);
    return false;
}
function editGroup(elm) {
    var treeview = window.tvGroup;
    if (treeview.SelectedNode == null || treeview.SelectedNode.ID.substr(0, 1) == "C") {
        alert("请先选中组，再进行编辑！");
    }
    else {
        popupWindow.setSize(420, 300);
        popupWindow.setUrl("SYS_GroupEdit.aspx?Code=" + treeview.SelectedNode.ID);
        popupWindow.showPopup(elm, false);
        return false;
    }
}

//Confirm Delete Group.
function confirmDeleteGroup() {
    var treeview = window.tvGroup;
    if (treeview.SelectedNode == null || treeview.SelectedNode.ID.substr(0, 1) == "C") {
        alert("请先选中组，再进行删除！");
    }
    else {
        return confirm("确认要删除选定的内容？");
    }
}

//Confirm Delete Group User.
function confirmDeleteGroupUser() {
    if (mdg_GroupUserList_obj.getSelectedArray() != null && mdg_GroupUserList_obj.getSelectedArray() != "") {
        return confirm("确认要删除选定组用户？")
    }
    else {
        alert("请先选中记录，再进行删除组用户操作！");
        return false;
    }
}
/*
* Pop up user chooser window.
*/
function showUserList(elmId) {
    var treeview = window.tvGroup;

    if (treeview.SelectedNode != null && treeview.SelectedNode.ID.substr(0, 1) != "C") {
        popupWindow.setUrl('SYS_ChooseUsers.aspx?Include=user&WithOutSide=Y&withgroup=n');
        popupWindow.setSize(250, 400);
        popupWindow.showPopup(elmId, false);
    }
    else {
        alert("请先选中用户组，再进行添加组用户操作！");
        return false;
    }
}
/*
* Set the user info to the page.
*/
function setUserInfo(userIds, empCodes, empNames, deptCodes, deptNames, groupIds, groupNames) {
    document.getElementById("txtLoginNames").value = userIds;
    document.getElementById("btnAddGroupUser").click();
}
/* 
 * TreeView On Node Move
 */
function tvGroup_onNodeBeforeMove(sender, eventArgs) {
    var p = eventArgs.get_newParentNode();
    var n = eventArgs.get_node();
    if (n.ParentNode == null) {
        alert("不能转移分类！");
        eventArgs.set_cancel(true);
        return;
    }
    if (p.ParentNode == null) {
        if (confirm("您确定要移动该组吗？")) {
            return true;
        }
        else {
            eventArgs.set_cancel(true);
        }
    }
    else {
        alert("只能向分类转移！");
        eventArgs.set_cancel(true);
    }
}
/*
 * Tree Node Select
 */
function tvGroup_onNodeSelect(sender, eventArgs) {
    var n = eventArgs.get_node();

    if (n.ParentNode == null) {
        try{
            eventArgs.set_cancel(true);
        }
        catch(ex){};
    }
    else {
        $.blockUI();
    }
}
/*
 * Delete TreeView Node.
 */
function tvGroup_DeleteNode() {
    window.tvGroup.SelectedNode.remove();
}

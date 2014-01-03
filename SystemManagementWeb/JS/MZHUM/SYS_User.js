//var isLoad = false;
var popupWindow = new PopupWindow();
popupWindow.setSize(800, 500);
//popupWindow.autoHide();
var selectedID;
var lastID;
/*this functin has problem.*/
function enableDeleteButton(item) {
    if (document.getElementById("MzhToolbar1_tbiEnable")) {
        if (UserList_obj.getSelectedID() != "" && UserList_obj.getSelectedArray().length == 1) {
            if (item.cells[4].innerText == "启用 ") {
                $("#MzhToolbar1_tbiEnable td.buttonIconCell div").removeClass("enableUser").toggleClass("disableUser");
            }
            else {
                $("#MzhToolbar1_tbiEnable td.buttonIconCell div").removeClass("disableUser").toggleClass("enableUser");
            }
        }
    }
}
function UserListClick(item) {
    enableDeleteButton(item);set
}
function resetClick() {
    if (UserList_obj.getSelectedArray() != null && UserList_obj.getSelectedArray() != "") {
        return confirm("确认要重置该用户密码吗？\n重置密码后，该用户密码为初始密码。")
    }
    else {
        alert("请先选中记录，再进行重置密码！");
        return false;
    }
}
function showDetail(obj) {
    obj.style.visibility = "visible";
    obj.style.position = "static";
}

function hideDetail(obj) {
    obj.style.visibility = "hidden";
    obj.style.position = "absolute";
}
function getSubstringBySp(srcString, sp) {
    if (srcString != null) {
        return srcString.substring(srcString.indexOf(sp) + 1);
    }
}
function DragEnd() {
    mousedown = false;
    document.body.style.cursor = "";
    UserList.style.cursor = "";
}
function getCatID() {
    return;
}
function transferAticle() {
    if (UserList_obj.getSelectedArray() != null && UserList_obj.getSelectedArray() != "") {
        document.body.style.cursor = "help";
        UserList.style.cursor = "help";
        if (parent.frames["tree"] != null) {
            if (parent.frames["tree"].AtiDrag != null) {
                parent.frames["tree"].DragStart();
            }
        }
    }
}
function showUserDetail(elmId) {
    popupWindow.setUrl("SYS_UserDetail.aspx?PKID=" + UserList_obj.getSelectedID());
    popupWindow.setSize(600, 400);
    popupWindow.showPopup(elmId, false);
    
}
function addUser(elmID) {
    popupWindow.setUrl("SYS_UserEdit.aspx?DeptCode="+document.getElementById("txtDeptCode").value);
    popupWindow.setSize(600, 500);
    popupWindow.showPopup(elmID, false);
    return false;
}
function editUser(elmID) {
    if (UserList_obj.getSelectedID() != null && UserList_obj.getSelectedID() != "") {
        if (UserList_obj.getSelectedID() != -1) {
            popupWindow.setUrl("SYS_UserEdit.aspx?PKID=" + UserList_obj.getSelectedID());
            popupWindow.setSize(600, 500);
            popupWindow.showPopup(elmID, false);
            return false;
        }
    }
    else {
        alert("请先选中某一条记录，再进行编辑！");
    }
}
function confirmDelete() {
    if (UserList_obj.getSelectedArray() != null && UserList_obj.getSelectedArray() != "") {
        return confirm("对于员工记录，建议不要进行删除操作！\r\n确认要删除选定用户？")
    }
    else {
        alert("请先选中记录，再进行删除用户操作！");
        return false;
    }
}

function confirmEnableDisable() {
    if (UserList_obj.getSelectedArray() != null && UserList_obj.getSelectedArray() != "") {
        return confirm("确认要启用/禁用选定用户？")
    }
    else {
        alert("请先选中记录，再进行启用/禁用！");
        return false;
    }
}
function refresh() {
    var btnRefresh = document.getElementById("btnRefresh");
    btnRefresh.click();
}
function tvDept_onNodeSelect(sender, eventArgs) {
    $.blockUI();
}



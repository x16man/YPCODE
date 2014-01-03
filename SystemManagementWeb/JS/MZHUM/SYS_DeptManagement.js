var popupWindow = new PopupWindow();
var userFlag;
/*
 *Before move the treeview's node's event handler.
 */
function tvDept_onNodeBeforeMove(sender, eventArgs) {

    if (isLoad && confirm("您确定要移动该部门吗？")) {
        return true;
    }
    else {
        eventArgs.set_cancel(true);
    }
}
function tvDept_onNodeSelect(sender, eventArgs) {
    $.blockUI();
}
/*
 *Confirm to Delete.
 */
function confirmDelete() {
    if (document.getElementById("txtParentDept").value == "") {
        alert("请先选中一个部门！");
        return;
    }
    return confirm("确认要删除选定的内容？")
}
/*
* Pop up user chooser window.
*/
function ShowUserList(elmId) {

    popupWindow.setUrl('SYS_ChooseUser.aspx?Include=all&WithOutSide=N');
    popupWindow.setSize(250, 400);
    popupWindow.showPopup(elmId, false);
}
/*
* Set the user info to the page.
*/
function setUserInfo(/*string*/loginName,/*string*/empCode, /*string*/empName,/*string*/ deptCode,/*string*/ deptName){
    document.getElementById("txtDeptMgr").value = loginName;
    document.getElementById("txtDeptMgrName").value = empName;
}
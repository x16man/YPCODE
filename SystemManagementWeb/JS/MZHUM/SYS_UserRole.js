var popupWindow1 = new PopupWindow();
/*
 * Add user.
 */
function addUser(elmId) {
    //var popupWindow1 = new PopupWindow();
    var productCode = document.getElementById("tb_ProductCode").value;
    popupWindow1.setUrl("SYS_UserRoleEdit.aspx?ProductCode=" + productCode);
    popupWindow1.setSize(500, 400);
    popupWindow1.showPopup(elmId, false);
}
/*
 * Edit user.
 */
function editUser(elmId) {
    //var popupWindow1 = new PopupWindow();
    var productCode = document.getElementById("tb_ProductCode").value;
    if (MzhDataGrid1_obj.getSelectedArray() != null && MzhDataGrid1_obj.getSelectedArray() != "") {
        popupWindow1.setUrl("SYS_UserRoleEdit.aspx?ProductCode=" + productCode + "&UserId=" + MzhDataGrid1_obj.getSelectedID());
        popupWindow1.setSize(500, 400);
        popupWindow1.showPopup(elmId, false);
    }
    else {
        alert("请先选中记录，再进行编辑！");
    }
}
function ShowUserList(elmId) {
    //var popupWindow1 = new PopupWindow();
    popupWindow1.setUrl('SYS_ChooseUsers.aspx?ids=' + document.getElementById("tb_UserIDs").value + '&Groupids=' + document.getElementById("tb_GroupIDs").value);
    popupWindow1.setSize(250, 400);
    popupWindow1.showPopup(elmId, false);
}
function setUserInfo(userIds, groupIds) {
    document.getElementById("tb_UserIDs").value = userIds;
    document.getElementById("tb_GroupIDs").value = groupIds;
}
function refresh() {
    document.getElementById("btnRefresh").click();
}
//ConfirmDelete
function confirmDelete() {
    if (MzhDataGrid1_obj.getSelectedArray() != null && MzhDataGrid1_obj.getSelectedArray() != "") {
        return confirm("确认要删除选定的内容？")
    }
    else {
        alert("请先选中记录，再进行删除！");
        return false;
    }
}
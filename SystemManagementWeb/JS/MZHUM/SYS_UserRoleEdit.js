/*
 * Pop up user chooser window.
 */
function ShowUserList(elmId) {
    var popupWindow = new PopupWindow();
    popupWindow.setUrl('SYS_ChooseUsers.aspx?Include=all&WithOutSide=Y&withgroup=Y');
    popupWindow.setSize(380, 400);
    popupWindow.showPopup(elmId, false);
}
/*
 * Set the user info to the page.
 */
function setUserInfo(userIds, empCodes, empNames, deptCodes, deptNames, groupIds, groupNames) {
    document.getElementById("tb_UserIDs").value = userIds;
    document.getElementById("tb_UserNames").value = empNames;
    document.getElementById("tb_GroupIDs").value = groupIds;
    document.getElementById("tb_GroupNames").value = groupNames;
    document.getElementById("btn_selectUser").click();
}
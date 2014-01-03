var popupWindow = new PopupWindow();
popupWindow.setSize(400, 280);
//popupWindow.autoHide();

function addOrgType(elmID) {
    popupWindow.setUrl("SYS_OrgTypeEdit.aspx?OP=New");
    popupWindow.showPopup(elmID, false);
    return false;
}

function editOrgType(elmID) {
    if (dg_OrgType_obj.getSelectedID() != null && dg_OrgType_obj.getSelectedID() != "") {
        if (dg_OrgType_obj.getSelectedID() != -1) {
            popupWindow.setUrl("SYS_OrgTypeEdit.aspx?code=" + dg_OrgType_obj.getSelectedID());
            popupWindow.showPopup(elmID, true);
            return false;
        }
    }
    else {
        alert("请先选中某一条记录，再进行编辑！");
    }
}


function DisplayOrgType(elmID) {
    if (dg_OrgType_obj.getSelectedID() != null && dg_OrgType_obj.getSelectedID() != "") {
        if (dg_OrgType_obj.getSelectedID() != -1) {
            popupWindow.setUrl("SYS_OrgTypeEdit.aspx?code=" + dg_OrgType_obj.getSelectedID());
            popupWindow.showPopup("btn_refresh", false);
            return false;
        }
    }
    else {
        alert("请先选中某一条记录，再进行编辑！");
    }
}


//确认删除
function confirmDelete() {
    if (dg_OrgType_obj.getSelectedArray() != null && dg_OrgType_obj.getSelectedArray() != "") {
        return confirm("确认要删除选定的内容？")
    }
    else {
        alert("请先选中记录，再进行删除！");
        return false;
    }
}

function refresh() {
    var btnRefresh = document.getElementById("btnRefresh");
    btnRefresh.click();
}
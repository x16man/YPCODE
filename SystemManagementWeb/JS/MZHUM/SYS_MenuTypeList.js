var popupWindow = new PopupWindow();
popupWindow.setSize(500, 400);

function refresh() {
    var btnRefresh = document.getElementById("btnRefresh");
    btnRefresh.click();
}
function addMenuTypeInfo(elm) {
    popupWindow.setUrl("SYS_MenuTypeEdit.aspx?OP=New");
    popupWindow.showPopup(elm, false);
    return false;
}
function editMenuTypeInfo(elm) {
    if (dg_MenuTypeInfo_obj.getSelectedID() == "") {
        alert("请首先选中要编辑的行！");
    }
    else {
        popupWindow.setUrl("SYS_MenuTypeEdit.aspx?OP=Edit&ID=" + dg_MenuTypeInfo_obj.getSelectedID());
        popupWindow.showPopup(elm, false);
        return false;
    }
}
//确认删除
function confirmDelete() {
    if (dg_MenuTypeInfo_obj.getSelectedArray() != null && dg_MenuTypeInfo_obj.getSelectedArray() != "") {
        return confirm("确认要删除选定的内容？")
    }
    else {
        alert("请先选中记录，再进行删除！");
        return false;
    }
}
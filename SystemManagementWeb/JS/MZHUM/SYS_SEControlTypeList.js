var popupWindow = new PopupWindow();
popupWindow.setSize(500, 400);

function refresh() {
    var btnRefresh = document.getElementById("btnRefresh");
    btnRefresh.click();
}
function add(elm) {
    popupWindow.setUrl("SYS_SEControlTypeEdit.aspx?OP=New");
    popupWindow.showPopup(elm, false);
    return false;
}
function edit(elm) {
    if (dg_SEControlTypeInfo_obj.getSelectedID() == "") {
        alert("请首先选中要编辑的行！");
    }
    else {
        popupWindow.setUrl("SYS_SEControlTypeEdit.aspx?OP=Edit&ID=" + dg_SEControlTypeInfo_obj.getSelectedID());
        popupWindow.showPopup(elm, false);
        return false;
    }
}
//确认删除
function confirmDelete() {
    if (dg_SEControlTypeInfo_obj.getSelectedArray() != null && dg_SEControlTypeInfo_obj.getSelectedArray() != "") {
        return confirm("确认要删除选定的内容？")
    }
    else {
        alert("请先选中记录，再进行删除！");
        return false;
    }
}

var popupWindow = new PopupWindow();
popupWindow.setSize(500, 400);

function refresh() {
    var btnRefresh = document.getElementById("btnRefresh");
    btnRefresh.click();
}
function addSESchemaInfo(elm) {
    popupWindow.setSize(500, 600);
    var moduleId = document.getElementById("hfModuleId").value;
    popupWindow.setUrl("SYS_SESchemaEdit.aspx?ModuleId=" + moduleId + "&OP=New");
    popupWindow.showPopup(elm, false);
    return false;
}
function editSESchemaInfo(elm) {
    popupWindow.setSize(500, 600);
    if (dg_SESchemaInfo_obj.getSelectedID() == "") {
        alert("请首先选中要编辑的行！");
    }
    else {
        var moduleId = document.getElementById("hfModuleId").value;
        var controlId = dg_SESchemaInfo_obj.getSelectedID();
        popupWindow.setUrl("SYS_SESchemaEdit.aspx?ModuleId=" + moduleId + "&OP=Edit&ID=" + controlId);
        popupWindow.showPopup(elm, false);
        return false;
    }
}
function confirmDelete() {
    if (dg_SESchemaInfo_obj.getSelectedArray() != null && dg_SESchemaInfo_obj.getSelectedArray() != "") {
        return confirm("确认要删除选定的内容？")
    }
    else {
        alert("请先选中记录，再进行删除！");
        return false;
    }
}
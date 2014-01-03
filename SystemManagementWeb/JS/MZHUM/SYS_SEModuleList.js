var popupWindow = new PopupWindow();
popupWindow.setSize(500, 400);

function refresh() {
    var btnRefresh = document.getElementById("btnRefresh");
    btnRefresh.click();
}
function addSEModuleInfo(elm) {
    var productCode = document.getElementById("hfProductCode").value;
    popupWindow.setUrl("SYS_SEModuleEdit.aspx?ProductCode="+productCode+"&OP=New");
    popupWindow.showPopup(elm, false);
    return false;
}
function editSEModuleInfo(elm) {
    var moduleId = document.getElementById("hfModuleId").value;
    var productCode = document.getElementById("hfProductCode").value;
    if (moduleId == null || moduleId == "") {
        alert("请先选中查询模块，再进行编辑！");
    }
    else {
        popupWindow.setUrl("SYS_SEModuleEdit.aspx?ProductCode=" + productCode + "&OP=Edit&ID=" + moduleId);
        popupWindow.showPopup(elm, false);
        return false;
    }
}
function confirmDeleteModule() {
    var moduleId = document.getElementById("hfModuleId").value;
    if (moduleId == null || moduleId == "") {
        alert("请先选中记录，再进行删除！");
        return false;
    }
    else {
        return confirm("确认要删除选定的内容？");
    }
}
function addSEControlInfo(elm) {
    popupWindow.setSize(500, 600);
    var moduleId = document.getElementById("hfModuleId").value;
    popupWindow.setUrl("SYS_SEControlEdit.aspx?ModuleId=" + moduleId + "&OP=New");
    popupWindow.showPopup(elm, false);
    return false;
}
function editSEControlInfo(elm) {
    popupWindow.setSize(500, 600);
    if (dg_SEControlInfo_obj.getSelectedID() == "") {
        alert("请首先选中要编辑的行！");
    }
    else {
        var moduleId = document.getElementById("hfModuleId").value;
        var controlId = dg_SEControlInfo_obj.getSelectedID();
        popupWindow.setUrl("SYS_SEControlEdit.aspx?ModuleId=" + moduleId + "&OP=Edit&ID=" + controlId);
        popupWindow.showPopup(elm, false);
        return false;
    }
}
function confirmDeleteControl() {
    if (dg_SEControlInfo_obj.getSelectedArray() != null && dg_SEControlInfo_obj.getSelectedArray() != "") {
        return confirm("确认要删除选定的内容？")
    }
    else {
        alert("请先选中记录，再进行删除！");
        return false;
    }
}
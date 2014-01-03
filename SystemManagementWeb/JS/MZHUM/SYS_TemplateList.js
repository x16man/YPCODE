var popupWindow = new PopupWindow();
popupWindow.setSize(400, 400);

//Add Template
function addTemplate(elmID) {
    var productCode = document.getElementById("txtProductCode").value;
    popupWindow.setUrl("SYS_TemplateEdit.aspx?OP=New&ProductCode="+productCode);
    popupWindow.showPopup(elmID, false);
    return false;
}
//Edit Template
function editTemplate(elmID) {

    if (dg_Template_obj.getSelectedID() != null && dg_Template_obj.getSelectedID() != "") {
        if (dg_Template_obj.getSelectedID() != -1) {
            popupWindow.setUrl("SYS_TemplateEdit.aspx?OP=Edit&ID=" + dg_Template_obj.getSelectedID());
            popupWindow.showPopup(elmID, false);
            return false;
        }
    }
    else {
        alert("请先选中某一条记录，再进行编辑！");
    }
}
//Show Template
function DisplayTemplate(elmID) {
    if (dg_Template_obj.getSelectedID() != null && dg_Template_obj.getSelectedID() != "") {
        if (dg_Template_obj.getSelectedID() != -1) {
            popupWindow.setUrl("SYS_TemplateEdit.aspx?code=" + dg_Template_obj.getSelectedID());
            popupWindow.showPopup(elmID, false);
            return false;
        }
    }
    else {
        alert("请先选中某一条记录，再进行编辑！");
    }
}
//Delete Confirm
function confirmDelete() {
    if (dg_Template_obj.getSelectedArray() != null && dg_Template_obj.getSelectedArray() != "") {
        return confirm("确认要删除选定的内容？")
    }
    else {
        alert("请先选中记录，再进行删除！");
        return false;
    }
}
//Refresh
function refresh() {
    var btnRefresh = document.getElementById("btnRefresh");
    btnRefresh.click();
}

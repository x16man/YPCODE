var popupWindow = new PopupWindow();
popupWindow.setSize(400, 300);
function tvRole_onNodeSelect(sender, eventArgs) {
    $.blockUI();
}


function refresh() {
    window.location = window.location;
}
function addRole(elm) {
    var productCode = document.getElementById("txtProductCode").value;
    popupWindow.setUrl("SYS_RoleEdit.aspx?ProductCode="+productCode);
    popupWindow.showPopup(elm, false);
    return false;
}
function editRole(elm) {
    var productCode = document.getElementById("txtProductCode").value;
    var roleCode = document.getElementById("txtRoleCode").value;
    if (roleCode == null || roleCode == "") {
        alert("请先选中角色，再进行编辑！");
    }
    else {
        popupWindow.setUrl("SYS_RoleEdit.aspx?ProductCode=" + productCode+"&Code="+roleCode);
        popupWindow.showPopup(elm, false);
        return false;
    }
}
function confirmDelete() {
    var roleCode = document.getElementById("txtRoleCode").value;
    if (roleCode == null || roleCode == "") {
        alert("请先选中角色，再进行删除！");
        return false;
    }
    else{
        return confirm("确认要删除选定的内容？")
    }
    
}

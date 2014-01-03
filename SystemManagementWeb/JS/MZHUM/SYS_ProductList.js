var popupWindow = new PopupWindow();
popupWindow.setSize(400, 400);

//Add Product
function addProduct(elmID) {
    popupWindow.setUrl("SYS_ProductEdit.aspx?OP=New");
    popupWindow.showPopup(elmID, false);
    return false;
}
//Edit Product
function editProduct(elmID) {
    if (dg_Product_obj.getSelectedID() != null && dg_Product_obj.getSelectedID() != "") {
        if (dg_Product_obj.getSelectedID() != -1) {
            popupWindow.setUrl("SYS_ProductEdit.aspx?OP=Edit&code=" + dg_Product_obj.getSelectedID());
            popupWindow.showPopup(elmID, false);
            return false;
        }
    }
    else {
        alert("请先选中某一条记录，再进行编辑！");
    }
}
//Register Product
function registerProduct(elmID) {
    if (dg_Product_obj.getSelectedID() != null && dg_Product_obj.getSelectedID() != "") {
        if (dg_Product_obj.getSelectedID() != -1) {
            popupWindow.setUrl("SYS_ProductRegister.aspx?code=" + dg_Product_obj.getSelectedID());
            popupWindow.showPopup(elmID, false);
            return false;
        }
    }
    else {
        alert("请先选中某一条记录，再进行编辑！");
    }
}
//Show Product
function DisplayProduct(elmID) {
    if (dg_Product_obj.getSelectedID() != null && dg_Product_obj.getSelectedID() != "") {
        if (dg_Product_obj.getSelectedID() != -1) {
            popupWindow.setUrl("SYS_ProductEdit.aspx?code=" + dg_Product_obj.getSelectedID());
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
    if (dg_Product_obj.getSelectedArray() != null && dg_Product_obj.getSelectedArray() != "") {
        return confirm("确认要删除选定的内容？")
    }
    else {
        alert("请先选中记录，再进行删除！");
        return false;
    }
}
//Refresh
function refresh() {
    window.location = window.location;
}

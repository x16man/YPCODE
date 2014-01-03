var popupWindow = new PopupWindow();
popupWindow.setSize(500, 400);

function refresh() {
    var btnRefresh = document.getElementById("btnRefresh");
    btnRefresh.click();
}
function addCompanyInfo(elm) {
    popupWindow.setUrl("SYS_CompanyEdit.aspx?OP=New");
    popupWindow.showPopup(elm, false);
    return false;
}


function CompanyInfodisplay() {
    popupWindow.setUrl("SYS_CompanyEdit.aspx?ID=" + dg_CompanyInfo_obj.getSelectedID());
    popupWindow.showPopup('btnCompanyEdit', false);
    return false;
}

function editCompanyInfo(elm) {
    if (dg_CompanyInfo_obj.getSelectedID() == "") {
        alert("请首先选中要编辑的行！");
    }
    else {
        popupWindow.setUrl("SYS_CompanyEdit.aspx?OP=Edit&ID=" + dg_CompanyInfo_obj.getSelectedID());
        popupWindow.showPopup(elm, false);
        return false;
    }
}
//确认删除
function confirmDelete() {
    if (dg_CompanyInfo_obj.getSelectedArray() != null && dg_CompanyInfo_obj.getSelectedArray() != "") {
        return confirm("确认要删除选定的内容？")
    }
    else {
        alert("请先选中记录，再进行删除！");
        return false;
    }
}
function deleteCompany() {
    if (dg_CompanyInfo_obj.getSelectedID() == "") {
        alert("请首先选中要删除的行！");
        return false;
    }
    else {
        if (confirm("您确认要删除选中的行吗？")) {
            document.getElementById("btn_Delete").click();
        }
        else {
            return false;
        }
    }
}
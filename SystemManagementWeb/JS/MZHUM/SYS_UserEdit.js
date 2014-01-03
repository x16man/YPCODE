var popupWindow = new PopupWindow();
function CheckoutEmpCode(source, arguments) {
    if (document.getElementById("tb_EmpCode").value == "") {
        arguments.IsValid = false;
    }
    else {
        arguments.IsValid = true;
    }
}
function CheckoutDept(source, arguments) {
    if (document.getElementById("ddw_IsEmp").value == "Y" && document.getElementById("tb_EmpDept").value == "") {
        arguments.IsValid = false;
    }
    else {
        arguments.IsValid = true;
    }
}
function showEmpPart(obj) {
    try {
        var ddlIsEmp;
        var empInfoBlock;
        ddlIsEmp = document.getElementById("ddw_IsEmp");
        empInfoBlock = document.getElementById("empInfo");
        if (ddlIsEmp.value == "Y") {
            removeClass(empInfoBlock, "hidden");
        }
        else {
            addClass(empInfoBlock, "hidden");
        }
    }
    catch (e) {
    }
}
/*
 * Set the department into to the textbox.
 */
function setDeptInfo(deptCode, deptName) {
    document.getElementById("tb_EmpDept").value = deptCode;
    document.getElementById("tb_DeptCnName").value = deptName;
}

function popupDeptChooser(elmId) {
    popupWindow.setUrl("SYS_ChooseDept.aspx");
    popupWindow.setSize(300, 500);
    popupWindow.showPopup(elmId, false);
}

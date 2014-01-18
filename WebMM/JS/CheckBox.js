//CheckBox全选
function CA() {
    $("span.checkThis>input[type=checkbox]").each(function() { this.checked = $("input[type=checkbox].checkAll").attr("checked"); });
 
}
//CheckBox选择项
function CCA() {
    var checkAll = $("input[type=checkbox].checkAll");
    checkAll.attr("checked", true);
    var checkBoxs = $("span.checkThis>input[type=checkbox]");
   
    for (var i = 0; i < checkBoxs.length; i++) {
        if (checkBoxs[i].checked == false) {
            checkBoxs[i].checked = false;
        }       
   }
}
/*
 *Before move the treeview's node's event handler.
 */
function tvDuty_onNodeBeforeMove(sender, eventArgs) {
    if (confirm("您确定要移动该职务吗？")) {
        return true;
    }
    else {
        eventArgs.set_cancel(true);
    }
}
function tvDuty_onNodeSelect(sender, eventArgs) {
    $.blockUI();
}

/*
 *Confirm to Delete.
 */
function confirmDelete()
{
    return confirm("确认要删除选定的内容？")
}

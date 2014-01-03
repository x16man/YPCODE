var popupWindow = new PopupWindow();
popupWindow.setSize(400, 350);
//popupWindow.autoHide();

function AddRightCode(elmID)
{
    var productCode;
    productCode = document.getElementById("txtProductCode").value;
	popupWindow.setUrl("SYS_RightCodeEdit.aspx?OP=New&productcode="+productCode);
	popupWindow.showPopup(elmID,false);
	return false;
}
function editRightCode(elmID)
{
	if(dg_RightCode_obj.getSelectedID()!=null && dg_RightCode_obj.getSelectedID()!="")
	{
		if (dg_RightCode_obj.getSelectedID()!=-1)
		{
		    var productCode;
		    productCode = document.getElementById("txtProductCode").value;
			popupWindow.setUrl("SYS_RightCodeEdit.aspx?OP=Edit&code="+dg_RightCode_obj.getSelectedID()+"&productcode="+productCode);
			popupWindow.showPopup(elmID,false);
			return false;
		}
	}
	else
	{
		alert("请先选中某一条记录，再进行编辑！");
	}
}
function DisplayRightCode(elmID)
{
	if(dg_RightCode_obj.getSelectedID()!=null && dg_RightCode_obj.getSelectedID()!="")
	{
		if (dg_RightCode_obj.getSelectedID()!=-1)
		{
			popupWindow.setUrl("SYS_RightCodeEdit.aspx?code="+dg_RightCode_obj.getSelectedID());
			popupWindow.showPopup("btn_refresh",false);
			return false;
		}
	}
	else
	{
		alert("请先选中某一条记录，再进行编辑！");
	}
}
function refresh() {
    document.getElementById("btnRefresh").click();
}
//确认删除
function confirmDelete()
{
	if(dg_RightCode_obj.getSelectedArray() != null&&dg_RightCode_obj.getSelectedArray()!="")
	{
		return confirm("确认要删除选定的内容？")
	}
	else
	{
		alert("请先选中记录，再进行删除！");
		return false;
	}				
}
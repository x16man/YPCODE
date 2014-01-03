var popupWindow = new PopupWindow();
popupWindow.setSize(400, 300);
//popupWindow.autoHide();

function addCat(elmID)
{
    var productCode;
    productCode = document.getElementById("txtProductCode").value;
	popupWindow.setUrl("SYS_RightCatEdit.aspx?OP=New&productcode="+productCode);
	popupWindow.showPopup(elmID,false);
	return false;
}
	
function editCat(elmID)
{
	if(dg_RightCat_obj.getSelectedID()!=null && dg_RightCat_obj.getSelectedID()!="")
	{
		if (dg_RightCat_obj.getSelectedID()!=-1)
		{
		    var productCode;
            productCode = document.getElementById("txtProductCode").value;
			popupWindow.setUrl("SYS_RightCatEdit.aspx?OP=Edit&code="+dg_RightCat_obj.getSelectedID()+"&productcode="+productCode);
			popupWindow.showPopup(elmID,false);
			return false;
		}
	}
	else
	{
		alert("请先选中某一条记录，再进行编辑！");
	}
}

function DisplayCat(elmID)
{
	if(dg_RightCat_obj.getSelectedID()!=null && dg_RightCat_obj.getSelectedID()!="")
	{
		if (dg_RightCat_obj.getSelectedID()!=-1)
		{
			popupWindow.setUrl("SYS_RightCatEdit.aspx?code="+dg_RightCat_obj.getSelectedID());
			popupWindow.showPopup("btn_refresh",false);
			return false;
		}
	}
	else
	{
		alert("请先选中某一条记录，再进行编辑！");
	}
}

function refresh()
{
    window.location = window.location;
}


//确认删除
function confirmDelete()
{
	if(dg_RightCat_obj.getSelectedArray() != null&&dg_RightCat_obj.getSelectedArray()!="")
	{
		return confirm("确认要删除选定的内容？")
	}
	else
	{
		alert("请先选中记录，再进行删除！");
		return false;
	}				
}
		var openmenu=true;
		function expandMenu(img)
		{
			if(openmenu)
			{
				ChangeMenuWidth(18);
				document.all.idActionsTable.style.visibility="hidden";
				document.all.idActionsTable.style.position="absolute";
				img.src="images/ARROW_EXPAND.gif";
			}
			else
			{
				ChangeMenuWidth(160);
				document.all.idActionsTable.style.visibility="visible";
				document.all.idActionsTable.style.position="static";
				img.src="images/ARROW.gif";
			}
			openmenu=!openmenu;
		}
		function ChangeMenuWidth(width)
		{
			var colsString=parent.document.all.contentFrameset.cols;
			var newcolsString = width+colsString.substring(colsString.indexOf(","));
			parent.document.all.contentFrameset.cols=newcolsString;
		}
		//左侧导航栏选中。
		function menu_selected(menu)
		{
			//所有项首先都回归到正常模式。
			for(i=0;i<document.all.idSubMenu.length;i++)
			{
				document.all.idSubMenu[i].className="link";
			}
			for(i=0;i<document.all.idSubMenuTD.length;i++)
			{
				document.all.idSubMenuTD[i].className="UserCell";
			}
			//当前选中项改变样式。
			menu.className="selected_link";
			menu.parentElement.className="UserCellSelected";
		}
		//左侧导航栏不选中。（过期）
		function menu_unselected(menu)
		{
			for(i=0;i<document.all.idSubMenu.length;i++)
			{
				document.all.idSubMenu[i].className="link";
			}
			for(i=0;i<document.all.idSubMenuTD.length;i++)
			{
				document.all.idSubMenuTD[i].className="UserCell";
			}
			menu.className="link";
			menu.parentElement.className="UserCell";
		}
		//左侧导航栏鼠标over。
		function menu_mouseover(menu)
		{
			if (menu.parentElement.className != "UserCellSelected")
			{
				menu.className = "selected_link";
				menu.parentElement.className = "UserCellOver";
			}
		}
		//左侧导航栏鼠标out。如果当前MENU项，不是选中项。
		//则回复到正常样式。如果当前MENU项，是选中项，则保持选中样式。
		function menu_mouseout(menu)
		{
			//如果鼠标当前离开导航项不是当前选中项，则回复到正常模式，否则保持选中模式。
			if (menu.parentElement.className != "UserCellSelected")
			{
				menu.className="link";
				menu.parentElement.className="UserCell";
			}
		}

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
		//��ർ����ѡ�С�
		function menu_selected(menu)
		{
			//���������ȶ��ع鵽����ģʽ��
			for(i=0;i<document.all.idSubMenu.length;i++)
			{
				document.all.idSubMenu[i].className="link";
			}
			for(i=0;i<document.all.idSubMenuTD.length;i++)
			{
				document.all.idSubMenuTD[i].className="UserCell";
			}
			//��ǰѡ����ı���ʽ��
			menu.className="selected_link";
			menu.parentElement.className="UserCellSelected";
		}
		//��ർ������ѡ�С������ڣ�
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
		//��ർ�������over��
		function menu_mouseover(menu)
		{
			if (menu.parentElement.className != "UserCellSelected")
			{
				menu.className = "selected_link";
				menu.parentElement.className = "UserCellOver";
			}
		}
		//��ർ�������out�������ǰMENU�����ѡ���
		//��ظ���������ʽ�������ǰMENU���ѡ����򱣳�ѡ����ʽ��
		function menu_mouseout(menu)
		{
			//�����굱ǰ�뿪������ǵ�ǰѡ�����ظ�������ģʽ�����򱣳�ѡ��ģʽ��
			if (menu.parentElement.className != "UserCellSelected")
			{
				menu.className="link";
				menu.parentElement.className="UserCell";
			}
		}

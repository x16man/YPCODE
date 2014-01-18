// Temporary, to stop linking directly to the js file
// Remove these lines before using this code (this will be removed soon)
if (window.location.href.indexOf("turner.com")>-1) { alert("Please stop linking directly to the JS file on mattkruse.com! Please copy the JS files to your server instead!"); window.location.href="http://www.mattkruse.com/"; }

// ===================================================================
// Author: Matt Kruse <matt@mattkruse.com>
// WWW: http://www.mattkruse.com/
//
// NOTICE: You may use this code for any purpose, commercial or
// private, without any further permission from the author. You may
// remove this notice from your final code if you wish, however it is
// appreciated by the author if at least my web site address is kept.
//
// You may *NOT* re-distribute this code in any way except through its
// use. That means, you can include it in your product, or your web
// site, or any other form where the code is actually being used. You
// may not put the plain javascript up on your site for download or
// include it in your javascript libraries for download. 
// If you wish to share this code with others, please just point them
// to the URL instead.
// Please DO NOT link directly to my .js files from your site. Copy
// the files to your server and use them there. Thank you.
// ===================================================================

/* SOURCE FILE: AnchorPosition.js */
function getAnchorPosition(anchorname){var useWindow=false;var coordinates=new Object();var x=0,y=0;var use_gebi=false, use_css=false, use_layers=false;if(document.getElementById){use_gebi=true;}else if(document.all){use_css=true;}else if(document.layers){use_layers=true;}if(use_gebi && document.all){x=AnchorPosition_getPageOffsetLeft(document.all[anchorname]);y=AnchorPosition_getPageOffsetTop(document.all[anchorname]);}else if(use_gebi){var o=document.getElementById(anchorname);x=AnchorPosition_getPageOffsetLeft(o);y=AnchorPosition_getPageOffsetTop(o);}else if(use_css){x=AnchorPosition_getPageOffsetLeft(document.all[anchorname]);y=AnchorPosition_getPageOffsetTop(document.all[anchorname]);}else if(use_layers){var found=0;for(var i=0;i<document.anchors.length;i++){if(document.anchors[i].name==anchorname){found=1;break;}}if(found==0){coordinates.x=0;coordinates.y=0;return coordinates;}x=document.anchors[i].x;y=document.anchors[i].y;}else{coordinates.x=0;coordinates.y=0;return coordinates;}coordinates.x=x;coordinates.y=y;return coordinates;}
//function getAnchorWindowPosition(anchorname){var coordinates=getAnchorPosition(anchorname);	var x=0;var y=0;if(document.getElementById){if(isNaN(window.screenX)){x=coordinates.x-document.body.scrollLeft+window.screenLeft;y=coordinates.y-document.body.scrollTop+window.screenTop;}else{x=coordinates.x+window.screenX+(window.outerWidth-window.innerWidth)-window.pageXOffset;y=coordinates.y+window.screenY+(window.outerHeight-24-window.innerHeight)-window.pageYOffset;}}else if(document.all){x=coordinates.x-document.body.scrollLeft+window.screenLeft;y=coordinates.y-document.body.scrollTop+window.screenTop;}else if(document.layers){x=coordinates.x+window.screenX+(window.outerWidth-window.innerWidth)-window.pageXOffset;y=coordinates.y+window.screenY+(window.outerHeight-24-window.innerHeight)-window.pageYOffset;}coordinates.x=x;coordinates.y=y;return coordinates;}
/*弹出式窗体定位*/
function getAnchorWindowPosition(anchorname)
{
	var coordinates=getAnchorPosition(anchorname);//获取到定位点的在他本身页面的坐标。
	var x=0;
	var y=0;
	if(document.getElementById)//W3C DOM is supported.
	{
		if(isNaN(window.screenX))//isNaN()返回一个 Boolean 值，指明提供的值是否是保留值 NaN （不是数字）。
		{
			//基本都是这个。
			//x=coordinates.x-document.body.scrollLeft+window.screenLeft;
			//y=coordinates.y-document.body.scrollTop+window.screenTop;
			
			
			x=coordinates.x-document.body.scrollLeft+window.screenLeft;	//scrollLeft:设置或获取位于 对象 左边界和窗口中目前可见内容的最左端之间的距离。
																		//window.screenLeft:获取浏览器客户区左上角相对于屏幕左上角的 x 坐标。
			y=coordinates.y-document.body.scrollTop+window.screenTop;	//scrollTop:设置或获取位于 对象 最顶端和窗口中可见内容的最顶端之间的距离。
																		//window.screenTop:获取浏览器客户区左上角相对于屏幕左上角的 y 坐标。
		}
		else
		{
			x=coordinates.x+window.screenX+(window.outerWidth-window.innerWidth)-window.pageXOffset;
			y=coordinates.y+window.screenY+(window.outerHeight-24-window.innerHeight)-window.pageYOffset;
		}
	}
	else if(document.all)//是否支持document.all.据说FireFox不支持也。
	{
		x=coordinates.x-document.body.scrollLeft+window.screenLeft;
		y=coordinates.y-document.body.scrollTop+window.screenTop;
	}
	else if(document.layers)//是否支持document.layers.<div></div>is a Layer.
	{
		x=coordinates.x+window.screenX+(window.outerWidth-window.innerWidth)-window.pageXOffset;
		y=coordinates.y+window.screenY+(window.outerHeight-24-window.innerHeight)-window.pageYOffset;
	}
	coordinates.x=x;
	coordinates.y=y;
	return coordinates;
}
function AnchorPosition_getPageOffsetLeft(el)
{
	var ol=el.offsetLeft;
	//alert(el);
	while((el=el.offsetParent) != null)//依次上升获取 Anchor到页面Body的offsetLeft;
	{
		//alert(el.id);
		ol += el.offsetLeft;
	}
	return ol;
}
function AnchorPosition_getWindowOffsetLeft(el){return AnchorPosition_getPageOffsetLeft(el)-document.body.scrollLeft;}
function AnchorPosition_getPageOffsetTop(el){var ot=el.offsetTop;while((el=el.offsetParent) != null){ot += el.offsetTop;}return ot;}
function AnchorPosition_getWindowOffsetTop(el){return AnchorPosition_getPageOffsetTop(el)-document.body.scrollTop;}


/* SOURCE FILE: PopupWindow.js */

/*弹出窗口定位*/
function PopupWindow_getXYPosition(anchorname)
{
	var coordinates;
	if(this.type == "WINDOW")
	{
		//alert("Windows");
		coordinates = getAnchorWindowPosition(anchorname);
	}
	else
	{coordinates = getAnchorPosition(anchorname);}
	this.x = coordinates.x;
	this.y = coordinates.y;
}
function PopupWindow_setSize(width,height){this.width = width;this.height = height;}
function PopupWindow_populate(contents){this.contents = contents;this.populated = false;}
function PopupWindow_setUrl(url){this.url = url;}
function PopupWindow_setWindowProperties(props){this.windowProperties = props;}
function PopupWindow_refresh(){if(this.divName != null){if(this.use_gebi){document.getElementById(this.divName).innerHTML = this.contents;}else if(this.use_css){document.all[this.divName].innerHTML = this.contents;}else if(this.use_layers){var d = document.layers[this.divName];d.document.open();d.document.writeln(this.contents);d.document.close();}}else{if(this.popupWindow != null && !this.popupWindow.closed){if(this.url!=""){this.popupWindow.location.href=this.url;}else{this.popupWindow.document.open();this.popupWindow.document.writeln(this.contents);this.popupWindow.document.close();}this.popupWindow.focus();}}}
function PopupWindow_showPopup(anchorname, isAnchor)
{
	this.getXYPosition(anchorname);
	this.x += this.offsetX;
	this.y += this.offsetY;
	if(!this.populated &&(this.contents != "")){this.populated = true;this.refresh();}
	if(this.divName != null)
	{
		//alert("divName is not null");
		if(this.use_gebi)
		{
			document.getElementById(this.divName).style.left = this.x + "px";
			document.getElementById(this.divName).style.top = this.y + "px";
			document.getElementById(this.divName).style.visibility = "visible";
		}
		else if(this.use_css)
		{
			document.all[this.divName].style.left = this.x;
			document.all[this.divName].style.top = this.y;
			document.all[this.divName].style.visibility = "visible";
		}
		else if(this.use_layers)
		{
			document.layers[this.divName].left = this.x;
			document.layers[this.divName].top = this.y;
			document.layers[this.divName].visibility = "visible";
		}
	}
	else
	{
		//alert("div is null");
		if(this.popupWindow == null || this.popupWindow.closed)
		{
			//alert("popupwindow null");
			if (isAnchor)
			{
				if(this.x<0){this.x=0;}
				if(this.y<0){this.y=0;}
				
				if(screen && screen.availHeight)
				{
					if((this.y + this.height) > screen.availHeight)
					{
						this.y = screen.availHeight - this.height -35;//35 is zhanghao Adjust.
					}
				}
				if(screen && screen.availWidth)
				{
					if((this.x + this.width) > screen.availWidth)
					{
						this.x = screen.availWidth - this.width -12;//35 is zhanghao Adjust.
					}
				}
			}
			else
			{
				this.x = screen.availWidth/2 - this.width/2;
				this.y = screen.availHeight/2 - this.height/2;
			}
			var avoidAboutBlank = window.opera || (document.layers && !navigator.mimeTypes['*']) || navigator.vendor == 'KDE' || (document.childNodes && !document.all && !navigator.taintEnabled);
			this.popupWindow = window.open(avoidAboutBlank ? "" : "about:blank", "window_" + anchorname.replace(/=/g, '').replace(/#/g, ''), this.windowProperties + ",width=" + this.width + ",height=" + this.height + ",screenX=" + this.x + ",left=" + this.x + ",screenY=" + this.y + ",top=" + this.y + "");
		}
		this.refresh();
	}
}
function PopupWindow_hidePopup(){if(this.divName != null){if(this.use_gebi){document.getElementById(this.divName).style.visibility = "hidden";}else if(this.use_css){document.all[this.divName].style.visibility = "hidden";}else if(this.use_layers){document.layers[this.divName].visibility = "hidden";}}else{if(this.popupWindow && !this.popupWindow.closed){this.popupWindow.close();this.popupWindow = null;}}}
function PopupWindow_isClicked(e){if(this.divName != null){if(this.use_layers){var clickX = e.pageX;var clickY = e.pageY;var t = document.layers[this.divName];if((clickX > t.left) &&(clickX < t.left+t.clip.width) &&(clickY > t.top) &&(clickY < t.top+t.clip.height)){return true;}else{return false;}}else if(document.all){var t = window.event.srcElement;while(t.parentElement != null){if(t.id==this.divName){return true;}t = t.parentElement;}return false;}else if(this.use_gebi && e){var t = e.originalTarget;while(t.parentNode != null){if(t.id==this.divName){return true;}t = t.parentNode;}return false;}return false;}return false;}
function PopupWindow_hideIfNotClicked(e){if(this.autoHideEnabled && !this.isClicked(e)){this.hidePopup();}}
function PopupWindow_autoHide(){this.autoHideEnabled = true;}
function PopupWindow_hidePopupWindows(e){for(var i=0;i<popupWindowObjects.length;i++){if(popupWindowObjects[i] != null){var p = popupWindowObjects[i];p.hideIfNotClicked(e);}}}
function PopupWindow_attachListener(){if(document.layers){document.captureEvents(Event.MOUSEUP);}window.popupWindowOldEventListener = document.onmouseup;if(window.popupWindowOldEventListener != null){document.onmouseup = new Function("window.popupWindowOldEventListener();PopupWindow_hidePopupWindows();");}else{document.onmouseup = PopupWindow_hidePopupWindows;}}
function PopupWindow()
{
	if(!window.popupWindowIndex){window.popupWindowIndex = 0;}
	if(!window.popupWindowObjects){window.popupWindowObjects = new Array();}
	if(!window.listenerAttached){window.listenerAttached = true;PopupWindow_attachListener();}
	this.index = popupWindowIndex++;
	popupWindowObjects[this.index] = this;
	this.divName = null;
	this.popupWindow = null;
	this.width=0;
	this.height=0;
	this.populated = false;
	this.visible = false;
	this.autoHideEnabled = false;
	this.contents = "";
	this.url="";
	this.windowProperties="toolbar=no,location=no,status=no,menubar=no,scrollbars=auto,resizable,alwaysRaised,dependent,titlebar=no";
	if(arguments.length>0)
	{
		this.type="DIV";
		this.divName = arguments[0];
	}
	else
	{
		this.type="WINDOW";
	}
	this.use_gebi = false;
	this.use_css = false;
	this.use_layers = false;
	if(document.getElementById) {this.use_gebi = true;}
	else if(document.all){this.use_css = true;}
	else if(document.layers){this.use_layers = true;}
	else{this.type = "WINDOW";}
	this.offsetX = 0;
	this.offsetY = 0;
	this.getXYPosition = PopupWindow_getXYPosition;
	this.populate = PopupWindow_populate;
	this.setUrl = PopupWindow_setUrl;
	this.setWindowProperties = PopupWindow_setWindowProperties;
	this.refresh = PopupWindow_refresh;
	this.showPopup = PopupWindow_showPopup;
	this.hidePopup = PopupWindow_hidePopup;
	this.setSize = PopupWindow_setSize;
	this.isClicked = PopupWindow_isClicked;
	this.autoHide = PopupWindow_autoHide;
	this.hideIfNotClicked = PopupWindow_hideIfNotClicked;
}


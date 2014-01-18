var SearchBarHeight=0;

function CloseSearch()
{
	parent.document.getElementById("SearchBar").className = "Hidden";
	parent.document.all.contents.style.Height = parent.document.all.contents.style.Height - 100;
}

function UnloadSearch()
{
	var rowsString=parent.document.all.SearchFrameset.rows;
	
	//var newrowsString = 0+rowsString.substring(rowsString.indexOf(","));
	//parent.document.all.SearchFrameset.rows=newrowsString;
	
	if(rowsString != undefined)
	{
	var newrowsString = 0+rowsString.substring(rowsString.indexOf(","));
	parent.document.all.SearchFrameset.rows=newrowsString;
	}
	else
	{
	parent.document.all.SearchFrameset.rows = 0;
	}
	SearchBarHeight=parent.document.all.search.height;
	//parent.document.frames["search"].location.replace("");
	parent.document.frames["search"].src="";
	
}

function ChangeHeight(height)
{
//	var rowsString = parent.document.all.SearchFrameset.rows;
//	var newrowsString = height+rowsString.substring(rowsString.indexOf(","));
//	parent.document.all.SearchFrameset.rows = newrowsString;
//alert(parent.document.all.SearchFrameset1.height);
//	parent.document.all.SearchFrameset1.SearchBar = height;
}

function isShowSearch()
{
	if (parent.document.all.search.height==0)
	{
		return false;
	}
	else
	{
		return true;
	}
}

function ShowSearchBar(url, height)
{
	if (isShowSearch())
	{
		//ChangeHeight(0);
		if (parent.document.frames["search"].SearchBarHeight != null)
		{
			//parent.document.frames["search"].SearchBarHeight = parent.document.all.search.height;
		}
	}
	else
	{
		if(parent.document.frames["search"].SearchBarHeight!=null)
		{
			//SearchBarHeight=parent.document.frames["search"].SearchBarHeight;
		}
		if(!isSameUrl(url))
		{
			parent.document.frames["search"].location.replace(url);
			//if(height!=null)
			//{
				//SearchBarHeight=height;
			//}
			//alert(parent.document.all("mzh_cao_80").value);
			//parent.document.frames["search"].document.all("mzh_cao_80").foucs();
		}
		
		//ChangeHeight(SearchBarHeight);
	}
	
	//alert(parent.document.all.SearchBar.className);
	if (parent.document.all.SearchBar.className == "Hidden")
	{
	    parent.document.all.SearchBar.className = "SearchBar";
	    parent.document.all.contents.style.Height = parent.document.all.contents.style.Height - 100;
	}
	else
	{
	    parent.document.all.SearchBar.className = "Hidden";
	    parent.document.all.contents.style.Height = parent.document.all.contents.style.Height + 100;
	}
	
}

function isSameUrl(url)
{
	var path=document.location.href.substring(0,document.location.href.lastIndexOf("/")+1);
	var wholeUrl = parent.document.frames["search"].location;
	if(path+url==wholeUrl)
	{
		return true;
	}
	else
	{
		return false;
	}
}
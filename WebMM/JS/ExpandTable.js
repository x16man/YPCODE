function ExpandTable(rowID)
{
	rowID.style.visibility="visible";
	rowID.style.position="static";
	rowID.style.zIndex=-1;
}

function CollapseTable(rowID)
{
	rowID.style.visibility="hidden";
	rowID.style.position="absolute";
	rowID.style.zIndex=-1;
}

function flexTable(pic,rowID,valueStore)
{
	if(valueStore.value=="expanding")
	{
		pic.src="../PICS/plus.gif";
		CollapseTable(rowID);
		valueStore.value="collapseing";
	}
	else
	{
		pic.src="../PICS/minus.gif";
		ExpandTable(rowID);
		valueStore.value="expanding";
	}
}

function holdTable(pic,rowID,valueStore)
{
	if(valueStore.value=="expanding")
	{
		pic.src="../PICS/minus.gif";	
		ExpandTable(rowID);
	}
	else
	{
		pic.src="../PICS/plus.gif";
		CollapseTable(rowID);
	}
}
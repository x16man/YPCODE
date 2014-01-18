function ShowOrHideSearchBar(Controlid,staticid)
{
	if (document.getElementById(Controlid).style.display == "block")
	{
		document.getElementById(Controlid).style.display = "none";
		document.getElementById(staticid).value = "none";

	}
	else
	{
		document.getElementById(Controlid).style.display = "block";
		document.getElementById(staticid).value = "block";

	}
	
}

//Set Control Status
function SetControlStatus(ControlID,staticID,className)
{
	document.getElementById(ControlID).className = className;
	document.getElementById(staticID).value = className;
}
  
//Keep Control Status
function KeepControlStatus(ControlID,staticID)
{
	document.getElementById(ControlID).className=document.getElementById(staticID).value;
}


/**/
document.onreadystatechange =  function() 
{
	if(document.readyState=="complete")
	{
		var list=document.getElementsByTagName("input");
        for(var i=0;i<list.length && list[i];i++)
        {
              if(list[i].type=="button"||list[i].type=="submit")   
              {
                 // alert(list[i].value);
                 // list[i].onmouseout = function(){this.className="button"};
                 // list[i].onmouseover = function(){this.className="buttonMouseOver"};
              }
        } 
     }
}
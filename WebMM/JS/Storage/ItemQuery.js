
function HiddenDiv(Codeid)
{
	document.getElementById(Codeid).className = "Hidden";
	document.getElementById("tablecon").className = "";
}
document.onreadystatechange = function ()
{
	if(document.readyState=="complete")
	{
		setTimeout("HiddenDiv('loading_div')",800);
		
	}
}
window.onload   =   function()   
{

}
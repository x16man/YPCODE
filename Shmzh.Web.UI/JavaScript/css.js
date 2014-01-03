/*
 *判断元素是否拥有指定的样式
 */
function hasClass(element,className){
    return new RegExp(("(^|\\s)" + className + "(\\s|$)"), "i").test(element.className);
}
/*
 *给指定的元素增加指定的样式.
 */
function addClass(element,className){
	var currentClass = element.className;
	if (!new RegExp(("(^|\\s)" + className + "(\\s|$)"), "i").test(currentClass)) {
		element.className = currentClass + (currentClass.length? " " : "") + className;
	}
}
/*
 *给指定的元素移除指定的样式.
 */
function removeClass(element,className){
	var classToRemove = new RegExp(("(^|\\s)" + className + "(\\s|$)"), "i");
	element.className = element.className.replace(classToRemove, function (match) {
		var retVal = "";
		if (new RegExp("^\\s+.*\\s+$").test(match)) {
			retVal = match.replace(/(\s+).+/, "$1");
		}
		return retVal;
	}).replace(/^\s+|\s+$/g, "");
}
/*
 *给指定的元素替换指定的样式.
 */
function replaceClass(element,className,newClass) {
	var classToRemove = new RegExp(("(^|\\s)" + className + "(\\s|$)"), "i");
	element.className = element.className.replace(classToRemove, function (match, p1, p2) {
		var retVal = p1 + newClass + p2;
		if (new RegExp("^\\s+.*\\s+$").test(match)) {
			retVal = match.replace(/(\s+).+/, "$1");
		}
		return retVal;
	}).replace(/^\s+|\s+$/g, "");
}
/*
 *给指定的元素自动增加或移除指定的样式.
 */
function toggleClass(element,className){
	if (hasClass(element, className)) {
        removeClass(element, className);
    }
    else {
        addClass(element, className);
    }
}

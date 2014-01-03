/*
 *�ж�Ԫ���Ƿ�ӵ��ָ������ʽ
 */
function hasClass(element,className){
    return new RegExp(("(^|\\s)" + className + "(\\s|$)"), "i").test(element.className);
}
/*
 *��ָ����Ԫ������ָ������ʽ.
 */
function addClass(element,className){
	var currentClass = element.className;
	if (!new RegExp(("(^|\\s)" + className + "(\\s|$)"), "i").test(currentClass)) {
		element.className = currentClass + (currentClass.length? " " : "") + className;
	}
}
/*
 *��ָ����Ԫ���Ƴ�ָ������ʽ.
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
 *��ָ����Ԫ���滻ָ������ʽ.
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
 *��ָ����Ԫ���Զ����ӻ��Ƴ�ָ������ʽ.
 */
function toggleClass(element,className){
	if (hasClass(element, className)) {
        removeClass(element, className);
    }
    else {
        addClass(element, className);
    }
}

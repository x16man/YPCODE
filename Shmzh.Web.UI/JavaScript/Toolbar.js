$(document).ready(function(){
	$("div.toolbar table.buttonTable").bind("mouseover",function(){
		$(this).find("td").each(function(){
			$(this).addClass(this.className+"Over");
		});
	}).bind("mouseout",function(){
		$(this).find("td").each(function(){
			$(this).removeClass(this.className.split(" ")[0]+"Over");
			$(this).removeClass(this.className.split(" ")[0]+"Down");
		});
	}).bind("mousedown",function(){
		$(this).find("td").each(function(){
			$(this).removeClass(this.className.split(" ")[0]+"Over");
			$(this).addClass(this.className.split(" ")[0]+"Down");
		});
	}).bind("mouseup",function(){
		$(this).find("td").each(function(){
			$(this).removeClass(this.className.split(" ")[0]+"Down");
			$(this).addClass(this.className.split(" ")[0]+"Over");
		});
	});
})

this.screenshotPreview = function() {
    /* CONFIG */

    xOffset = 10;
    yOffset = 30;

    // these 2 variable determine popup's distance from the cursor
    // you might want to adjust to get the right result

    /* END CONFIG */
    $("a.screenshot").hover(function(e) {
        this.t = this.title;
        this.title = "";
        $("body").append("<div id='screenshot'></div>");
        var d = this.t;
        //alert(document.getElementById(d).innerHTML);
        if (this.t != "") {
            var dd = document.getElementById(d).innerHTML;
            document.getElementById("screenshot").innerHTML = dd;
            $("#screenshot")
			.css("top", (e.pageY - xOffset + 35) + "px")
			.css("left", (e.pageX + yOffset - 200) + "px")
			.fadeIn("fast");
        }        
        
    },
	function() {
	    this.title = this.t;
	    $("#screenshot").remove();
	});
    $("a.screenshot").mousemove(function(e) {
        $("#screenshot")
			.css("top", (e.pageY - xOffset + 35) + "px")
			.css("left", (e.pageX + yOffset-200) + "px");
    });
};


// starting the script on page load
$(document).ready(function() {
    screenshotPreview();
});

function tooptip_ball(event, id) {
    if (window.event) event = window.event;
    var htmlstr = " ";
    htmlstr = document.getElementById(id).innerHTML;
    balloon.showTooltip(event, htmlstr, 1)
}
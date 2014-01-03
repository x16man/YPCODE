/*------------------------------------------------
 * JavaScript String Extender Library
 * Version 1.0
 * by Shmzh
 * Copyright (c) 2008 Shmzh. All Rights Reserved.
 *------------------------------------------------
 */
 if (!Function.prototype.method) {
 	Function.prototype.method = function (name, fn) {
		if (!this.prototype[name])
			this.prototype[name] = fn;
		return this;
	 }
 }
 
 String.method(	"endsWith",		function(suffix) {
									return (this.substr(this.length - suffix.length) === suffix);
								}
	 ).method( "startsWith",	function(prefix){
									return (this.substr(0, prefix.length) === prefix);
								}
	).method( "trim",			function() {
									return this.replace(/^\s+|\s+$/g, ''); 
								}
	).method( "ltrim",			function() {
									return this.replace(/^\s+/, '');
								}
	).method( "rtrim",			function() {
									return this.replace(/\s+$/, '');
								}
	).method( "format",			function() {
								
								}
	);																
								

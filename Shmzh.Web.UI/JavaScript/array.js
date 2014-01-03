/*------------------------------------------------
 * JavaScript Array Extender Library
 * Version 1.0
 * by Shmzh
 * Copyright (c) 2008 Shmzh. All Rights Reserved.
 *------------------------------------------------
 */
 
Function.prototype.method = function (name, fn) {
	if (!this.prototype[name])
		this.prototype[name] = fn;
	return this;
 }

 
 Array.method(	"add",		function() {
								for(var i=0,l=arguments.length; i<l; i++) {
									this[this.length] = arguments[i];
								}
							}
		).method("insert",function(index, item) {
								if (arguments.length > 1) {
									for(var i=0,l=arguments.length-1; i<l; i++) {
										this.splice(index+i,0,arguments[i+1]);
									}
								}
							}
		).method("indexOf",	function(item, start) {
								var length = this.length;
								if(start == null){
									start=0;
								} else if(start<0) {
									start = Math.max(0,length+start);
								}
								for(var i=start;i<length;i++){
									if(this[i]===item) return i;
								}
								return -1;
							}
		).method("remove",	function(item) {
								var index = this.indexOf(item);
								if (index >= 0) {
									this.splice(index, 1);
								}
								return (index >= 0);
							}
		).method("removeAt",function(index) {
								this.splice(index, 1);
							}
		).method("clear",	function() {
								this.length =0;
							}
		).method("clone",	function() {
								return this.concat();
							}
		).method("lastIndexOf",function(item, start) {
								var length = this.length;
								if (start == null) {
									start = length -1;
								} else if (start<0) {
									start = Math.max(0, length + start);
								}
								for(var i=start;i>=0;i--){
									if(this[i]===item) return i;
								}
								return -1;
							}
		).method("contains",function(item) {
								return this.indexOf(item) != -1;
							}
		).method("forEach", function(execMethod,thisObj) {
								var scope = thisObj||window;
								for(var i=0,l=this.length;i<l;i++) {
									if(i in this) execMethod.call(scope, this[i], i, this);
								}
							}
		).method("every",	function(compareMethod, thisObj) {
								var scope = thisObj||window;
								for( var i=0,l=this.length;i<l;++i) {
									if(!compareMethod.call(scope, this[i],i,this)) {
										return false;
									}
								}
								return true;
							}
		).method("some",	function(compareMethod, thisObj) {
								var scope = thisObj||window;
								for(var i=0, l=this.length; i<l; i++) {
									if(compareMethod.call(scope,this[i],i,this)) {
										return true;
									}
								}
								return false;
							}
		).method("map",		function(convertMethod, thisObj) {
								var scope = thisObj||window;
								var a = [];
								for(var i=0,l=this.length; i<l; i++) {
									a.push(convertMethod.call(scope,this[i],i,this));
								}
								return a;
							}
		).method("filter",	function(compareMethod, thisObj) {
								var scope = thisObj||window;
								var a = [];
								for(var i=0,l=this.length; i<l; i++) {
									if(!compareMethod.call(scope, this[i],i,this)) {
										continue;
									}
									a.push(this[i]);
								}
								return a;
							}
		).method("unique",	function() {
								var a=[];
								for(var i=0,l=this.length;i<l;i++)
								{
									if(!a.contains(this[i]))
										a.push(this[i]);
								}
								return a;
							}
		).method("first",	function() {
								return this[0];
							}
		).method("last",	function() {
								return this[this.length-1];
							}							
		).method("swap",	function(i,j) {
								var temp = this[i];
								this[i] = this[j];
								this[j] = temp;
							}
		).method("sum",		function(convertMethod, thisObj) {
								if (this.length > 0) {
									var scope = thisObj||window;
									var vResult = (convertMethod||function(vVal){return vVal;}).call(scope,this[0],0,this);
									for(var i=1,l=this.length;i<l;++i) {
										if(i in this) vResult += (convertMethod||function(vVal){return vVal;}).call(scope,this[i],i,this);
									}
									return vResult;
								}
								else {
									return null;
								}
							}
		).method("reduce",	function(fun)
							{
							    var len = this.length;
							    if (typeof fun != "function")
							      throw new TypeError();
							
							    // no value to return if no initial value and an empty array
							    if (len == 0 && arguments.length == 1)
							      throw new TypeError();
							
							    var i = 0;
							    if (arguments.length >= 2)
							    {
							      var rv = arguments[1];
							    }
							    else
							    {
							      do
							      {
							        if (i in this)
							        {
							          rv = this[i++];
							          break;
							        }
							
							        // if array contains no values, no initial value to return
							        if (++i >= len)
							          throw new TypeError();
							      }
							      while (true);
							    }
							
							    for (; i < len; i++)
							    {
							      if (i in this)
							        rv = fun.call(null, rv, this[i], i, this);
							    }
							
							    return rv;
							  }
		).method("reduceRight",	function(callbackMethod) {
									var len = this.length;
									if (typeof callbackMethod != "function")
										throw new TypeError();

									// no value to return if no initial value, empty array
									if (len == 0 && arguments.length == 1)
										throw new TypeError();

									var i = len - 1;
									if (arguments.length >= 2)
									{
										var rv = arguments[1];
									}
									else
									{
										do
										{
											if (i in this)
											{
												rv = this[i--];
												break;
											}

											// if array contains no values, no initial value to return
											if (--i < 0)
												throw new TypeError();
										}
										while (true);
									}

									for (; i >= 0; i--)
									{
										if (i in this)
											rv = callbackMethod.call(null, rv, this[i], i, this);
									}

									return rv;
								}
		).method("sameSize",	function(targetArray) {
									return this.length==targetArray.length;
								}
		).method("flatten",		function() {
									var a = this.reduce(function(p,c) {	return p.concat(c);},[]);
									var b = a.reduce(function(p,c) {	return p.concat(c);},[]);
									while(!a.sameSize(b))
									{
										a=b;
										b=b.reduce(function(p,c) {	return p.concat(c);},[]);
									}
									return b;
								}
		);
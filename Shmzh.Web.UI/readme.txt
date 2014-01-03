ASP.NET Web 服务器控件和浏览器功能

不同的浏览器和相同浏览器的不同版本支持不同的功能。
ASP.NET 服务器控件会自动确定发出页面请求的浏览器，
并为该浏览器呈现适当的标记。
但是，部分控件功能无法在较低版本的浏览器上呈现，
因此需要在尽可能多的浏览器类型上查看页的输出，
以确保页以预期方式呈现在所有浏览器中。

这个功能真是让人困惑啊。我想output<div>他则干脆output <table>.firefox，opera，safari下。
为了屏蔽这个让人不胜其烦的功能。
可以在Web.Config的<system.web>节下增加如下内容即可，屏蔽这个越俎代庖的功能。


<browserCaps>
			<!-- 
			Name:    BrowserCaps update for modern browsers, http://slingfive.com/pages/code/browserCaps/
			Author:  Rob Eberhardt, http://slingfive.com/
			History:
			2004-11-19  improved detection of Safari, Konqueror and Mozilla variants, added Opera detection
			2003-12-21  updated TagWriter info
			2003-12-03  first published
            -->
			<!-- GECKO Based Browsers (Netscape 6+, Mozilla/Firefox, ...) //-->
			<case match="^Mozilla/5\.0 \([^)]*\) (Gecko/[-\d]+)(?'VendorProductToken' (?'type'[^/\d]*)([\d]*)/(?'version'(?'major'\d+)(?'minor'\.\d+)(?'letters'\w*)))?">
        browser=Gecko
        <filter>
					<case match="(Gecko/[-\d]+)(?'VendorProductToken' (?'type'[^/\d]*)([\d]*)/(?'version'(?'major'\d+)(?'minor'\.\d+)(?'letters'\w*)))">
            type=${type}
          </case>
					<case>
						<!-- plain Mozilla if no VendorProductToken found -->
            type=Mozilla
          </case>
				</filter>
        frames=true
        tables=true
        cookies=true
        javascript=true
        javaapplets=true
        ecmascriptversion=1.5
        w3cdomversion=1.0
        css1=true
        css2=true
        xml=true
        tagwriter=System.Web.UI.HtmlTextWriter
        <case match="rv:(?'version'(?'major'\d+)(?'minor'\.\d+)(?'letters'\w*))">
          version=${version}
          majorversion=0${major}
          minorversion=0${minor}
          <case match="^b" with="${letters}">
            beta=true
          </case>
				</case>
			</case>
			<!-- AppleWebKit Based Browsers (Safari...) //-->
			<case match="AppleWebKit/(?'version'(?'major'\d?)(?'minor'\d{2})(?'letters'\w*)?)">
        browser=AppleWebKit
        version=${version}
        majorversion=0${major}
        minorversion=0.${minor}
        frames=true
        tables=true
        cookies=true
        javascript=true
        javaapplets=true
        ecmascriptversion=1.5
        w3cdomversion=1.0
        css1=true
        css2=true
        xml=true
        tagwriter=System.Web.UI.HtmlTextWriter
        <case match="AppleWebKit/(?'version'(?'major'\d)(?'minor'\d+)(?'letters'\w*))(.* )?(?'type'[^/\d]*)/.*( |$)">
          type=${type}
        </case>
			</case>
			<!-- Konqueror //-->
			<case match=".+[K|k]onqueror/(?'version'(?'major'\d+)(?'minor'(\.[\d])*)(?'letters'[^;]*));\s+(?'platform'[^;\)]*)(;|\))">
        browser=Konqueror
        version=${version}
        majorversion=0${major}
        minorversion=0${minor}
        platform=${platform}
        type=Konqueror
        frames=true
        tables=true
        cookies=true
        javascript=true
        javaapplets=true
        ecmascriptversion=1.5
        w3cdomversion=1.0
        css1=true
        css2=true
        xml=true
        tagwriter=System.Web.UI.HtmlTextWriter
      </case>
			<!-- Opera //-->
			<case match="Opera[ /](?'version'(?'major'\d+)(?'minor'\.(?'minorint'\d+))(?'letters'\w*))">
				<filter match="[7-9]" with="${major}">
          tagwriter=System.Web.UI.HtmlTextWriter
        </filter>
				<filter>
					<case match="7" with="${major}">
						<filter>
							<case match="[5-9]" with="${minorint}">
                ecmascriptversion=1.5
              </case>
							<case>
                ecmascriptversion=1.4
              </case>
						</filter>
					</case>
					<case match="[8-9]" with="${major}">
            ecmascriptversion=1.5
          </case>
				</filter>
			</case>
		</browserCaps>
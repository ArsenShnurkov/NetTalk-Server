var BrowserDetect = {
	init: function(){
		this.browser = this.searchString(this.dataBrowser) || "An unknown browser";
		this.version = this.searchVersion(navigator.userAgent) ||
		this.searchVersion(navigator.appVersion) ||
		"an unknown version";
	},
	searchString: function(data){
		for (var i = 0; i < data.length; i++) {
			var dataString = data[i].string;
			var dataProp = data[i].prop;
			this.versionSearchString = data[i].versionSearch || data[i].identity;
			if (dataString) {
				if (dataString.indexOf(data[i].subString) != -1) 
					return data[i].identity;
			}
			else 
				if (dataProp) 
					return data[i].identity;
		}
	},
	searchVersion: function(dataString){
		var index = dataString.indexOf(this.versionSearchString);
		if (index == -1) 
			return;
		return parseFloat(dataString.substring(index + this.versionSearchString.length + 1));
	},
	dataBrowser: [{
		string: navigator.userAgent,
		subString: "Chrome",
		identity: "Chrome"
	},
	{
		string: navigator.vendor,
		subString: "Apple",
		identity: "Safari"
	}, {
		prop: window.opera,
		identity: "Opera"
	}, {
		string: navigator.userAgent,
		subString: "Flock",
		identity: "Flock"
	}, {
		string: navigator.userAgent,
		subString: "Firefox",
		identity: "Firefox"
	}, {
		string: navigator.userAgent,
		subString: "MSIE",
		identity: "IExplorer",
		versionSearch: "MSIE"
	}]
};
var BrowserCompatible = {
    check: function() {
        BrowserDetect.init();
        if ((this.useBlackList && this.unCompatibleBrowsers[BrowserDetect.browser] && BrowserDetect.version <= this.unCompatibleBrowsers[BrowserDetect.browser]) ||
		    (!this.useBlackList && (BrowserDetect.version < this.compatibleBrowsers[BrowserDetect.browser] || !this.compatibleBrowsers[BrowserDetect.browser]))) {
            if (!this.readCookie('browsercheck_dontShowAgain'))
                this.showWarning();
        }
    },
    getStyle: function(el, styleProp) {
        var x = el;
        if (x.currentStyle)
            var y = x.currentStyle[styleProp];
        else
            if (window.getComputedStyle)
            var y = document.defaultView.getComputedStyle(x, null).getPropertyValue(styleProp);
        return y;
    },
    createCookie: function(name, value, days) {
        if (days) {
            var date = new Date();
            date.setTime(date.getTime() + (days * 24 * 60 * 60 * 1000));
            var expires = ";expires=" + date.toGMTString();
        }
        else
            var expires = "";
        document.cookie = name + "=" + value + expires + ";path=/";
    },

    readCookie: function(name) {
        var nameEQ = name + "=";
        var ca = document.cookie.split(';');
        for (var i = 0; i < ca.length; i++) {
            var c = ca[i];
            while (c.charAt(0) == ' ')
                c = c.substring(1, c.length);
            if (c.indexOf(nameEQ) == 0)
                return c.substring(nameEQ.length, c.length);
        }
        return null;
    },

    eraseCookie: function(name) {
        this.createCookie(name, "", -1);
    },
    showWarning: function() {
        if (!this.lang) {
            this.lang = navigator.language || navigator.browserLanguage;
            if (!this.langTranslations[this.lang]) this.lang = "en";
        }
        var bg = document.createElement("div");
        bg.id = "browsercheck_bg";
        bg.style["background"] = "#fff";
        bg.style["filter"] = "alpha(opacity=90)";
        bg.style["-moz-opacity"] = "0.90";
        bg.style["opacity"] = "0.9";
        bg.style["position"] = "fixed";
        if (BrowserDetect.browser == "IExplorer" && BrowserDetect.version < 7)
            bg.style["position"] = "absolute";
        bg.style["z-index"] = "9998";
        bg.style["top"] = "0";
        bg.style["left"] = "0";
        bg.style["height"] = (screen.availHeight + 300) + "px";
        bg.style["width"] = (screen.availWidth + 300) + "px";

        var warning_html = "";
        if (this.allowCancel)
            warning_html += '<a href="javascript:BrowserCompatible.cancel()" style="background:url(' + this.images['cancel'] + ') no-repeat; height:15px; width:16px; position:absolute; right:10px; top:7px;" title="' + this.langTranslations[this.lang]['cancel'] + '"></a>';
        warning_html += '<div id="browsercheck_title" style="font-family:arial; font-size:24px; color:#000; margin:15px;">' + this.langTranslations[this.lang]['title'] + '</div>';
        warning_html += '<div id="browsercheck_description" style="font-family:tahoma; font-size:10pt; color:#707070; margin:15px;">' + this.langTranslations[this.lang]['description'] + '</div>';
        warning_html += '<div id="browsercheck_recomendation" style="font-family:tahoma; font-size:10pt; color:#707070; margin:15px;">' + this.langTranslations[this.lang]['recomendation'] + '</div>';
        for (var i = 0; i < this.offeredBrowsers.length; i++) {
            warning_html += '<a href="' + this.browsersList[this.offeredBrowsers[i]].link + '" title="' + this.langTranslations[this.lang][this.offeredBrowsers[i]] + '" style="height:60px; width:165px; display:block; float:left; margin:15px; text-decoration:none; background: url(' + this.browsersList[this.offeredBrowsers[i]].image + ') no-repeat;" target="_blank"> </a>';

        }
        if (this.allowToHide)
            warning_html += '<div style="clear:both;font-family:arial; font-size:12px; color:#707070; padding:7px 15px;"><label><input type="checkbox" id="browsercheck_dontShowAgain" onclick="BrowserCompatible.dontShowAgain()" />' + this.langTranslations[this.lang]['dontShowAgain'] + '</label></div>';
        var warning = document.createElement("div");
        warning.id = "browsercheck_warning";
        warning.style["background"] = "url(" + this.images['background'] + ") no-repeat";
        warning.style["padding"] = "2px";
        warning.style["width"] = "600px";
        warning.style["height"] = "400px";
        warning.style["position"] = "fixed";
        if (BrowserDetect.browser == "IExplorer" && BrowserDetect.version < 7)
            warning.style["position"] = "absolute";
        warning.style["z-index"] = "9999";
        warning.style["top"] = ((window.innerHeight || document.body.parentNode.offsetHeight) - 400) / 2 + "px";
        warning.style["left"] = ((window.innerWidth || document.body.parentNode.offsetWidth) - 600) / 2 + "px";
        warning.innerHTML = warning_html;

        this.old_overflow_style = this.getStyle(document.body.parentNode, "overflow") || this.getStyle(document.body, "overflow");
        if (BrowserDetect.browser == "Opera" && this.old_overflow_style == "visible")
            this.old_overflow_style = "auto";
        document.body.parentNode.style["overflow"] = "hidden";
        document.body.style["overflow"] = "hidden";

        document.body.appendChild(bg);
        document.body.appendChild(warning);

        if (document.addEventListener) {
            document.addEventListener('resize', this.warningPosition, false);
        }
        else {
            document.attachEvent('onresize', this.warningPosition);
        }

    },
    warningPosition: function() {
        var warning = document.getElementById('browsercheck_warning');
        warning.style["top"] = ((window.innerHeight || document.body.parentNode.offsetHeight) - 400) / 2 + "px";
        warning.style["left"] = ((window.innerWidth || document.body.parentNode.offsetWidth) - 600) / 2 + "px";
    },
    dontShowAgain: function() {
        var inpDontShowAgain = document.getElementById('browsercheck_dontShowAgain').checked;
        var dontShowAgain = this.readCookie('browsercheck_dontShowAgain');
        if (inpDontShowAgain) {
            this.createCookie('browsercheck_dontShowAgain', 'on', this.cookiesExpire);
        }
        else {
            this.eraseCookie('browsercheck_dontShowAgain');
        }
    },
    cancel: function() {
        var bg = document.getElementById('browsercheck_bg');
        var warning = document.getElementById('browsercheck_warning');
        bg.parentNode.removeChild(bg);
        warning.parentNode.removeChild(warning);
        document.body.parentNode.style["overflow"] = this.old_overflow_style;
        if (BrowserDetect.browser != "IExplorer")
            document.body.style["overflow"] = this.old_overflow_style;
        document.onresize = this.resize_function;
    },
    old_overflow_style: "",
    resize_function: null,
    allowCancel: false,
    allowToHide: false,
    cookiesExpire: 1,
    images: {
        'background': "/Scripts/stopIE6/images/bg.gif",
        'cancel': "/Scripts/stopIE6/images/cancel.gif"
    },
    useBlackList: false,
    compatibleBrowsers: {
        "Opera": 9.25,
        "Firefox": 2,
        "IExplorer": 7,
        "Safari": 525.17,
        "Flock": 1.1,
        "Chrome": 1
    },
    unCompatibleBrowsers: {
        "IExplorer": 6
    },
    offeredBrowsers: ["Chrome", "Firefox", "Flock", "Safari", "IExplorer", "Opera"],
    browsersList: {
        "Chrome": {
            "image": "/Scripts/stopIE6/images/chrome.gif",
            "link": "\\\\172.16.3.7\\Data Bank\\Internet\\Browsers\\Google\\"
        },
        "Opera": {
            "image": "/Scripts/stopIE6/images/opera.gif",
            "link": "http://www.opera.com/products/desktop/"
        },
        "Firefox": {
            "image": "/Scripts/stopIE6/images/firefox.gif",
            "link": "\\\\172.16.3.7\\Data Bank\\Internet\\Browsers\\Firefox\\"
        },
        "IExplorer": {
            "image": "/Scripts/stopIE6/images/iexplorer.gif",
            "link": "\\\\172.16.3.7\\Data Bank\\Internet\\Browsers\\Internet Explorer\\"
        },
        "Safari": {
            "image": "/Scripts/stopIE6/images/safari.gif",
            "link": "http://www.apple.com/safari/"
        },
        "Flock": {
            "image": "/Scripts/stopIE6/images/flock.gif",
            "link": "http://www.flock.com/"
        }
    },
    lang: "fa",
    langTranslations: {
        "fa": {
            "title": "مرورگر اینترنت شما قدیمی است",
            "description": "مرورگر شما قدیمی است، این بدین معنی است که مرورگر شما حداقل امکانات برای اجرای بسیاری از وب سایتها را ندارد وب سایتهای مدرن امروزی بسیار قوی ساخته می شوند. از طرف دیگر مرورگرهای قدیمی نقات امنیتی بسیار زیادی را دارند که می تواند منجر به سرقت اطلاعات محرنامه شما و یا نصب نرم افزارهای مخرب بدون مجوز شما گردد، در نتیجه با ارتقاء مرورگر خود نتها می توانید مرور وب را با سرعت بیشتری تجربه کنید، بلکه اطلاعات محرنامه خود را نیز محفوظ می دارید.",
            "recomendation": "پیشنهاد ما نصب یکی از مرورگرهای رایگان زیر است! همگی رایگان هستند هیچ پولی نباید بدهید.",
            "cancel": "بستن این اخطار",
            "dontShowAgain": "هرگز نشان نده",
            "Flock": "فلوک بر اساس کدهای موزیلا نوشته شده است",
            "Firefox": "محبوب ترین مرورگر",
            "IExplorer": "رایجترین مرورگر",
            "Safari": "پر سرعت ترین مرورگر",
            "Opera": "اپرا",
            "Chrome": "گوگل کروم ، جدید و تازه وارد"
        },
        "en": {
            "title": "Obsolete browser",
            "description": "Your browser is obsolete, which means it does not contain all of the necessary functions for the correct working of many current web sites. Modern web sites are created to be convenient and effective for you and, together with improvement of web sites themselves, browsers continue to improve. In addition, older browsers have many security glitches which can be maliciously abused to steal personal and financial information; therefore by upgrading your web browser you not only benefit from an enhanced web experience, but ensure that your private data is better protected.",
            "recomendation": "We recommend using the latest version of one of the following browsers. All are free, quick to install and won't cost you anything.",
            "cancel": "Close this warning",
            "dontShowAgain": "Don't show this warning again",
            "Firefox": "Firefox is considered by many to be the most advanced web browser available today it has an ability to adapt to individual usage through a large range of plug-ins and other popular features such as tabbed browsing that offers useful management of the browsing experience.",
            "Flock": "Flock is a web browser that is optimised for blogs, news aggregation, and social networking sites. It is built on Mozilla’s Firefox codebase and has many of the same benefits.",
            "IExplorer": "Internet Explorer has been the default web browser for Windows users for many years.",
            "Safari": "Safari is a web browser developed by Apple Inc. and included in Mac OS X and is also available for Windows.",
            "Opera": "Opera is a web browser and Internet suite developed by the Opera Software company. Opera handles common Internet-related tasks such as displaying web sites, sending and receiving e-mail messages, managing contacts, IRC online chatting, downloading files via BitTorrent, and reading web feeds.",
            "Chrome": "Google Chrome is a browser that combines a minimal design with sophisticated technology to make the web faster, safer, and easier."
        }
    }
}

BrowserCompatible.compatibleBrowsers = { "Firefox": 3, "IExplorer": 7, "Chrome": 5 };
BrowserCompatible.offeredBrowsers = ["Chrome", "Firefox", "IExplorer"];
BrowserCompatible.allowCancel = true;
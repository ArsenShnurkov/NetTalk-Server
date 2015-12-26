var AjaxError = function(x, e) {
    if (x.status == 0) {
        alert('You are offline!!\n Please Check Your Network.');
    } else if (x.status == 404) {
        alert('Requested URL not found.');
    } else if (x.status == 500) {
        alert('Internel Server Error.');
    } else if (e == 'parsererror') {
        alert('Error.\nParsing JSON Request failed.');
    } else if (e == 'timeout') {
        alert('Request Time out.');
    } else {
        alert('Unknow Error.\nCan not find URL\N' + x.responseText);
    }
};
var UrlInfo = function(url) {
    var index = url.indexOf('?', 0);
    var result = [];
    if (index >= 0) {
        index++;
        var tmp = url.substring(index, url.length);
        tmp = tmp.split(/&/g);
        for (var i = 0; i < tmp.length; i++) {
            tmp[i] = tmp[i].split(/=/);
            result[tmp[i][0]] = tmp[i][1];
        };
    };
    return result;
};
//var openLookup = function(src, width, height, onOpen) {
//    var field = UrlInfo(src);
//    field = field["fid"];
//    if (!$("#" + field).attr("disabled")) {
//        var htmlcode = $("#lookupwin").length;
//        if (htmlcode == 0) {
//            $(document.body).append('<div style="text-align:center" id="lookupwin"><iframe id="lookupframe" width="' + width + 'px" height="' + height + 'px" marginWidth="0" marginHeight="0" frameBorder="0" scrolling="auto"></iframe></div>');
//            $("#lookupwin").dialog({
//            autoOpen: false,
//                modal: false,
//                width: width + 15,
//                height: height + 45,
//                close: function() {
//                    $("#lookupframe").attr("src", "about:blank");
//                },
//                resizable: true,
//                resizeStop: function() {
//                    var w = $("#lookupwin").dialog('option', 'width');
//                    var h = $("#lookupwin").dialog('option', 'height');
//                    $('#lookupframe').attr('width', (w - 15) + 'px').attr('height', (h - 45) + 'px');
//                }
//            });
//        };
//        if (onOpen) {
//            var data = onOpen();
//            var str = [];
//            for (var key in data) {
//                str[str.length] = key + '=' + data[key];
//            };
//            src += '&' + str.join('&');
//        };
//        $("#lookupframe").attr("src", src);
//        $("#lookupwin").dialog('open');
//    };
//};
//var openFieldLookup = function(control, field, sort, el, onData, onAjax) {
//    if (el.value) {
//        var f = field + "$" + sort + "$0$" + el.value + "$0$";
//        var id = el.id.split(/_/);
//        id = id[0];
//        if (!$("#" + id).attr("disabled")) {
//            var data = {
//                Filter: f,
//                Sort: '',
//                PageIndex: 0,
//                PageSize: 5
//            };
//            $("#" + id + "_img").show();
//            if (onAjax) {
//                onAjax(data);
//            };
//            $.ajax({
//                url: "/" + control + '/AjaxLookup/',
//                dataType: 'json',
//                type: 'POST',
//                data: data,
//                cache: false,
//                success: function(result) {
//                    if (result.TotalRecords == 0) {
//                        el.value = '';
//                        $("#" + id).val("");
//                        $("#" + id + "_text").val("");
//                    } else if (result.TotalRecords == 1) {
//                        var dataAttr = $(result.Html).attr("data");
//                        dataAttr = eval(dataAttr);
//                        if (dataAttr.ids.length >= 2) {
//                            $("#" + id).val(dataAttr.ids[0].value);
//                            $("#" + id + "_text").val(dataAttr.ids[1].value);
//                            if (onData) {
//                                var tmpData = [];
//                                for (var i = 0; i < data.ids.length; i++) {
//                                    tmpData[data.ids[i].key] = data.ids[i].value;
//                                };
//                                onData(field, tmpData);
//                            }
//                        } else {
//                            $("#" + id).val("");
//                            $("#" + id + "_text").val("");
//                        };
//                    } else {
//                        alert('تعداد موارد پیدا شده ' + result.TotalRecors);
//                    };
//                },
//                error: AjaxError,
//                complete: function() {
//                    $("#" + id + "_img").hide();
//                }
//            });
//        };
//    };
//};
//var closeLookup = function(f, fn, ids) {
//    $("#lookupwin").dialog('close');
//    if (fn) {
//        try {
//            fn2 = eval(fn);
//            if (fn2) {
//                fn2(f, ids);
//            };
//        } catch (ex) { };
//    };
//};
//var openTreeLookup = function(src, width, height, onOpen) {
//    var field = UrlInfo(src);
//    field = field["fid"];
//    if (!$("#" + field).attr("disabled")) {
//        var htmlcode = $("#treelookupwin").length;
//        if (htmlcode == 0) {
//            $(document.body).append('<div style="text-align:center" id="treelookupwin"><iframe id="treelookupframe" width="' + width + 'px" height="' + height + 'px" marginWidth="0" marginHeight="0" frameBorder="0" scrolling="auto"></iframe></div>');
//            $("#treelookupwin").dialog({
//                autoOpen: false,
//                modal: false,
//                width: width + 15,
//                height: height + 45,
//                close: function() {
//                    $("#treelookupframe").attr("src", "about:blank");
//                },
//                resizable: true,
//                resizeStop: function() {
//                    var w = $("#treelookupwin").dialog('option', 'width');
//                    var h = $("#treelookupwin").dialog('option', 'height');
//                    $('#treelookupframe').attr('width', (w - 15) + 'px').attr('height', (h - 45) + 'px');
//                }
//            });
//        };
//        if (onOpen) {
//            var data = onOpen();
//            var str = [];
//            for (var key in data) {
//                str[str.length] = key + '=' + data[key];
//            };
//            src += '&' + str.join('&');
//        };
//        $("#treelookupframe").attr("src", src);
//        $("#treelookupwin").dialog('open');
//    };
//};
//var closeTreeLookup = function(f, fn, ids) {
//    $("#treelookupwin").dialog('close');
//    if (fn) {
//        try {
//            fn2 = eval(fn);
//            if (fn2) {
//                fn2(f, ids);
//            };
//        } catch (ex) { };
//    };
//};
//var closeMultiSelect = function(f, fn, ids) {
//    $("#lookupwin").dialog('close');
//    if (fn) {
//        try {
//            fn2 = eval(fn);
//            if (fn2) {
//                var index = 0;
//                var keylist = [];
//                for (var key in ids) {
//                    keylist[index] = key;
//                    index++;
//                    if (index == 2) {
//                        break;
//                    };
//                };
//                for (index = 0; index < ids[keylist[0]].length; index++) {
//                    fn2.add(ids[keylist[1]][index], ids[keylist[0]][index]);
//                };
//            };
//        } catch (ex) { };
//    };
//};
//var onClear = null;
//var clearLookup = function(name) {
//    if (!$("#" + name).attr("disabled")) {
//        $("#" + name + "_text").val("");
//        $("input[name='" + name + "'").val("");
//        if (onClear) {
//            onClear(name);
//        };
//    };
//};
//var openZoneLookup = function(src, width, height) {
//    var htmlcode = $("#zonelookupwin").length;
//    if (htmlcode == 0) {
//        $(document.body).append('<div id="zonelookupwin"><iframe id="zonelookupframe" width="' + width + 'px" height="' + height + 'px" marginWidth="0" marginHeight="0" frameBorder="0" scrolling="auto"></iframe></div>');
//        $("#zonelookupwin").dialog({
//            autoOpen: false,
//            modal: true,
//            title: 'انتخاب منطقه جغرافیایی',
//            width: width + 20,
//            height: height + 40,
//            close: function() {
//                $("#zonelookupframe").attr("src", "about:blank");
//            },
//            resizable: false
//        });
//    };
//    $("#zonelookupframe").attr("src", src);
//    $("#zonelookupwin").dialog('open');
//};
//var closeZoneLookup = function() {
//    $("#zonelookupwin").dialog('close');
//};
(function() {
    var pageUrl = "";
    var pageName = "";
    var pageSite = "";
    var pageQuerystring = function() {
        var url = window.location.href;
        pageSite = window.location.host;
        pageUrl = window.location.pathname;
        var index = url.indexOf('?', 0);
        var result = [];
        if (index >= 0) {
            index++;
            var tmp = url.substring(index, url.length);
            tmp = tmp.split(/&/g);
            for (var i = 0; i < tmp.length; i++) {
                tmp[i] = tmp[i].split(/=/);
                result[tmp[i][0]] = tmp[i][1];
            };
        };
        pageName = pageUrl.split(/\//g);
        if (pageName.length == 1)
            pageName = pageName[0];
        else
            pageName = pageName[(pageName.length - 1)];
        return result;
    };
    window.page = {
        query: pageQuerystring(),
        name: pageName,
        site: pageSite,
        path: pageUrl
    };
})();
//var ChangeFilePicker = function(id, val) {
//    switch (val) {
//        case "File":
//            $("#" + id + "_chk_File").show();
//            $("#" + id + "_chk_Text").hide();
//            $("#" + id).val("");
//            $("#" + id + "_Link").attr("href", "");
//            break;
//        case "Text":
//            $("#" + id + "_chk_File").html($("#" + id + "_chk_File").html()).hide();
//            $("#" + id + "_File").val("");
//            $("#" + id + "_chk_Text").show();
//            break;
//    };
//};
//var openFilePicker = function(src, width, height) {
//    var htmlcode = $("#fphtmlwin").length;
//    if (htmlcode == 0) {
//        $(document.body).append('<div style="text-align:center" id="fphtmlwin"><iframe id="fphtmlframe" width="' + width + 'px" height="' + height + 'px" marginWidth="0" marginHeight="0" frameBorder="0" scrolling="auto"></iframe></div>');
//        $("#fphtmlwin").dialog({
//            autoOpen: false,
//            modal: true,
//            title: 'انتخاب فایل / عکس',
//            width: width + 5,
//            height: height + 35,
//            close: function() {
//                $("#fphtmlframe").attr("src", "about:blank");
//            },
//            resizable: false
//        });
//    };
//    $("#fphtmlframe").attr("src", src);
//    $("#fphtmlwin").dialog('open');
//};
//var closeFilePicker = function(url, fid) {
//    $("#" + fid).val(url);
//    $("#" + fid + "_Link").attr("href", "/" + url);
//    $("#fphtmlwin").dialog('close');
//};
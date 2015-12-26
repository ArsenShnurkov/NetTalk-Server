var htmlgridData = {
    filter: '<div style="display:none" class="dsPagerFilter" id="dsPagerFilter"><table><tr>' +
'<td id="filterHeader"><a class="dsPagerFilterClose" href="javascript:closeFilter()"></a>فیلتر بر اساس <span id="dsPagerFilterName"></span></td></tr><tr><td>' +
'<select id="dsPagerFilter_CA">' +
'<option value="Equal">برابر باشد</option><option value="NotEqual">برابر نباشد</option>' +
'<option value="Greater">بزرگتر</option><option value="GreaterThan">بزرگتر مساوی</option>' +
'<option value="Lower">کوچکتر</option><option value="LowerThan">کوچکتر مساوی</option>' +
'<option value="StartsWith">شروع شود</option><option value="EndsWith">تمام شود</option>' +
'<option value="Contains">شامل</option></select></td></tr>' +
'<tr><td><input id="dsPagerFilter_CA_value" class="input-text" type="text" /></td></tr><tr><td>و</td></tr>' +
'<tr><td><select id="dsPagerFilter_CB"><option value="Equal">برابر باشد</option><option value="NotEqual">برابر نباشد</option>' +
'<option value="Greater">بزرگتر</option><option value="GreaterThan">بزرگتر مساوی</option>' +
'<option value="Lower">کوچکتر</option><option value="LowerThan">کوچکتر مساوی</option><option value="StartsWith">شروع شود</option>' +
'<option value="EndsWith">تمام شود</option><option value="Contains">شامل</option></select></td></tr><tr><td><input id="dsPagerFilter_CB_value" class="input-text" type="text" /></td></tr>' +
'<tr><td><input id="dsPagerFilter_BTN1" class="input-button" type="button" value="فیلتر" />&nbsp;<input id="dsPagerFilter_BTN2" class="input-button" type="button" value="حذف فیلتر" /></td></tr></table></div>'
};
var PERSIAN_EPOCH = 1948320.5;
function mod(a, b) {
    return a - (b * Math.floor(a / b));
};
function persian_to_jd(year, month, day) {
    var epbase, epyear;

    epbase = year - ((year >= 0) ? 474 : 473);
    epyear = 474 + mod(epbase, 2820);

    return day +
            ((month <= 7) ?
                ((month - 1) * 31) :
                (((month - 1) * 30) + 6)
            ) +
            Math.floor(((epyear * 682) - 110) / 2816) +
            (epyear - 1) * 365 +
            Math.floor(epbase / 2820) * 1029983 +
            (PERSIAN_EPOCH - 1);
};
function leap_gregorian(year) {
    return ((year % 4) == 0) &&
            (!(((year % 100) == 0) && ((year % 400) != 0)));
};
var GREGORIAN_EPOCH = 1721425.5;
function gregorian_to_jd(year, month, day) {
    return (GREGORIAN_EPOCH - 1) +
           (365 * (year - 1)) +
           Math.floor((year - 1) / 4) +
           (-Math.floor((year - 1) / 100)) +
           Math.floor((year - 1) / 400) +
           Math.floor((((367 * month) - 362) / 12) +
           ((month <= 2) ? 0 :
                               (leap_gregorian(year) ? -1 : -2)
           ) +
           day);
};
function jd_to_gregorian(jd) {
    var wjd, depoch, quadricent, dqc, cent, dcent, quad, dquad,
        yindex, dyindex, year, yearday, leapadj;

    wjd = Math.floor(jd - 0.5) + 0.5;
    depoch = wjd - GREGORIAN_EPOCH;
    quadricent = Math.floor(depoch / 146097);
    dqc = mod(depoch, 146097);
    cent = Math.floor(dqc / 36524);
    dcent = mod(dqc, 36524);
    quad = Math.floor(dcent / 1461);
    dquad = mod(dcent, 1461);
    yindex = Math.floor(dquad / 365);
    year = (quadricent * 400) + (cent * 100) + (quad * 4) + yindex;
    if (!((cent == 4) || (yindex == 4))) {
        year++;
    }
    yearday = wjd - gregorian_to_jd(year, 1, 1);
    leapadj = ((wjd < gregorian_to_jd(year, 3, 1)) ? 0
                                                  :
                  (leap_gregorian(year) ? 1 : 2)
              );
    month = Math.floor((((yearday + leapadj) * 12) + 373) / 367);
    day = (wjd - gregorian_to_jd(year, month, 1)) + 1;

    return new Array(year, month, day);
};
function p2g(input) {
    var st = input.split(/\//);
    st = persian_to_jd(eval(st[0]), eval(st[1]), eval(st[2]));
    st = jd_to_gregorian(st);
    return st.join(',');
};
var closeFilter = function() {
    $("#dsPagerFilter").data("isopen", false).animate({ height: 'hide', opacity: 'hide' }, 'fast');
    $("#dsPagerFilter_CA").attr("selectedIndex", 0);
    $("#dsPagerFilter_CB").attr("selectedIndex", 0);
    $("#dsPagerFilter_CA_value").val("");
    $("#dsPagerFilter_CB_value").val("");
};
$(document).ready(function() {
    $('body').append(htmlgridData.filter);
    $("#dsPagerFilter").draggable({ handle: "#filterHeader" });
    $.blockUI.defaults.css.padding = 5;
    $.blockUI.defaults.css.border = '1px solid #aaa';
});
var htmlgrid = function(id, config) {
    var settings = {
        id: id,
        url: "",
        title: "",
        urlparam: { list: '/AjaxList/', del: '/AjaxDelete/', edit: '/Form/?mode=Edit&', insert: '/Form/?mode=New&' },
        blockMessage: 'در حال دریافت اطلاعات',
        columns: [],
        menus: [],
        filter: { data: [], columns: [], index: 0 },
        pager: {
            enable: true,
            size: [10, 20, 30],
            currentSize: 10,
            index: 0,
            totalPages: 0,
            totalRecords: 0
        },
        enableCookie: true,
        showScroll: true,
        autoWidth: true,
        insidetab: false,
        autoHeight: true,
        style: {
            width: '653px',
            height: '400px'
        },
        sort: {
            field: null,
            dir: null,
            imageasc: '<img class="sort" alt="sort asc" src="/Scripts/plugin/ds/images/24/sort_ascend.png" />',
            imagedesc: '<img class="sort" alt="sort desc" src="/Scripts/plugin/ds/images/24/sort_descend.png" />'
        },
        edit: {
            enable: false,
            param: false
        },
        del: {
            enable: false,
            param: false
        },
        insert: {
            enable: false,
            param: false
        },
        exportbtn: true,
        select: null,
        autoLoad: true,
        addCheckbox: true,
        beforeAjax: null,
        afterAjax: null,
        afterRender: null,
        onEdit: null,
        onDelete: null,
        onSort: null,
        onAction: null
    };
    $.extend(true, settings, config);
    return {
        isInit: false,
        flistData: ["برابر باشد", "برابر نباشد", "بزرگتر", "بزرگتر مساوی", "کوچکتر", "کوچکتر مساوی", "شروع شود", "تمام شود", "شامل"],
        flist: {
            "string": [1, 1, 0, 0, 0, 0, 1, 1, 1],
            "number": [1, 1, 1, 1, 1, 1, 0, 0, 0],
            "bool": [1, 1, 0, 0, 0, 0, 0, 0, 0],
            "guid": [1, 1, 1, 1, 1, 1, 0, 0, 0],
            "date": [1, 1, 1, 1, 1, 1, 0, 0, 0],
            "datetime": [1, 1, 1, 1, 1, 1, 0, 0, 0]
        },
        flistDef: {
            "string": 8,
            "number": 0,
            "bool": 0,
            "guid": 0,
            "date": 3,
            "datetime": 3
        },
        settings: settings,
        reload: function() {
            this.getData();
        },
        unfilter: function() {
            this.settings.filter.columns = [];
            this.settings.filter.data = [];
            this.settings.filter.index = 0;
            $("#" + this.settings.id + "_grid thead th span").each(function() {
                $(this).removeClass().addClass("dsPagerAddFilter");
            });
            this.gotoFirstPage();
        },
        setSize: function(el) {
            //هنگامی که در کمبو اندازه صفحات تغییر کند
            var tmp = el.selectedIndex;
            tmp = el.options[tmp].value;
            this.settings.pager.currentSize = tmp;
            this.settings.pager.index = 0;
            this.getData();
        },
        checkAll: function(el) {
            var ischeck = el.checked;
            $("#" + this.settings.id + "_grid tbody tr").each(function(index) {
                if (ischeck)
                    $(this).addClass("selected").find("td:eq(0) :checkbox").attr("checked", "checked");
                else
                    $(this).removeClass("selected").find("td:eq(0) :checkbox").removeAttr("checked");
            });
        },
        showFilter: function(e) {
            var base = this;
            var DataIndex = e.data.index;
            if ($("#dsPagerFilter").data("isopen")) {
                if (base.settings.filter.index == e.data.index) {
                    closeFilter();
                    return;
                };
            };
            if (base.settings.addCheckbox) {
                DataIndex--;
            };
            var pos = $("#" + base.settings.id + "_grid thead th:eq(" + e.data.index + ")").offset();
            pos.top = pos.top + $("#" + base.settings.id + "_grid thead th:eq(" + e.data.index + ")").height() + 5;
            var col = base.settings.columns[DataIndex].bind;
            var colType = base.settings.columns[DataIndex].sort;
            colType = this.flist[colType];
            if ($("#dsPagerFilter").data("isopen")) {
                $("#dsPagerFilter").animate({ opacity: 0.5, top: pos.top, left: pos.left }, 'normal', "", function() {
                    $("#dsPagerFilter").css("opacity", "1");
                });
            } else {
                $("#dsPagerFilter").data("isopen", true).css({ "top": pos.top, "left": pos.left }).animate({ height: 'show', opacity: 'show' }, 'fast');
            };
            base.settings.filter.index = e.data.index;
            var tmp = "";
            for (var index in this.flistData) {
                if (colType[index]) {
                    tmp += '<option value="' + index + '">' + this.flistData[index] + '</option>';
                };
            };
            $("#dsPagerFilter_CA,#dsPagerFilter_CB").html(tmp);
            tmp = base.settings.columns[DataIndex].sort;
            if (tmp == 'date' || tmp == 'datetime') {
                $("#dsPagerFilter_CA_value,#dsPagerFilter_CB_value").addClass("ltr").setMask("1399/19/39");
            } else {
                $("#dsPagerFilter_CA_value,#dsPagerFilter_CB_value").removeClass("ltr").unsetMask();
            };
            var dataIndex = base.settings.filter.columns[col];
            var defSelected = { a: 0, b: 0 };
            if (typeof (dataIndex) == 'number') {
                var d = base.settings.filter.data;
                defSelected.a = d[dataIndex].a.com;
                defSelected.b = d[dataIndex].b.com;
                $("#dsPagerFilter_CA_value").val(d[dataIndex].a.value);
                $("#dsPagerFilter_CB_value").val(d[dataIndex].b.value);
            } else {
                defSelected.a = this.flistDef[tmp];
                defSelected.b = this.flistDef[tmp];
            };
            $("#dsPagerFilter_CA option[value='" + defSelected.a + "']").attr("selected", "selected");
            $("#dsPagerFilter_CB option[value='" + defSelected.b + "']").attr("selected", "selected");
            $("#dsPagerFilter_BTN1").unbind().bind("click", function() {
                base.saveFilter();
            });
            $("#dsPagerFilter_BTN2").unbind().bind("click", function() {
                base.cancelFilter();
            });
            $("#dsPagerFilter_CA_value,#dsPagerFilter_CB_value").unbind().bind("keypress", function(e) {
                var key = (window.event) ? window.event.keyCode : e.which;
                if (key == 13) {
                    if (window.event) {
                        window.event.keyCode = null;
                    };
                    e.returnValue = false;
                    e.cancel = true;
                    if (e.preventDefault) {
                        e.preventDefault();
                    };
                    if (e.stopPropagation) {
                        e.stopPropagation();
                    };
                    base.saveFilter();
                };
            });
        },
        saveFilter: function() {
            var ColIndex = this.settings.filter.index;
            var DataIndex = ColIndex;
            if (this.settings.addCheckbox) {
                DataIndex--;
            };
            var spanTag = $("#" + this.settings.id + "_grid thead th:eq(" + ColIndex + ")").find("span");
            spanTag.removeClass().addClass("dsPagerRemoveFilter");

            var a = { com: $("#dsPagerFilter_CA option:selected").val(), value: $("#dsPagerFilter_CA_value").val() };
            var b = { com: $("#dsPagerFilter_CB option:selected").val(), value: $("#dsPagerFilter_CB_value").val() };
            var col = this.settings.columns[DataIndex].bind;
            var sort = this.settings.columns[DataIndex].sort;
            this.addFilter(col, a, b, sort);
            closeFilter();
        },
        cancelFilter: function() {
            var index = this.settings.filter.index;
            if (this.settings.addCheckbox) {
                index--;
            };
            var col = this.settings.columns[index].bind;
            this.removeFilter(col);
            closeFilter();
        },
        addFilter: function(col, obj1, obj2, sort) {
            var f = this.settings.filter;
            var index;
            if (typeof (f.columns[col]) != 'undefined') {
                index = f.columns[col];
            } else {
                index = f.data.length;
                f.columns[col] = index;
            };
            f.data[index] = { col: col, a: obj1, b: obj2, sort: sort };
            this.gotoFirstPage();
        },
        removeFilter: function(col) {
            debugger;
            var ColIndex = this.settings.filter.index;
            var DataIndex = ColIndex;
            if (this.settings.addCheckbox) {
                DataIndex--;
            };
            var spanTag = $("#" + this.settings.id + "_grid thead th:eq(" + ColIndex + ")").find("span");
            spanTag.removeClass().addClass("dsPagerAddFilter");

            var f = this.settings.filter;
            if (typeof (f.columns[col]) == 'number') {
                var tmp = [];
                var cIndex = f.columns[col];
                for (var key in f.columns) {
                    if (key != col) {
                        tmp[key] = f.columns[key];
                    };
                };
                f.columns = tmp;
                tmp = [];
                for (var key in f.data) {
                    if (key != cIndex) {
                        tmp[key] = f.data[key];
                    };
                };
                f.data = tmp;
                this.gotoFirstPage();
            };
        },
        setSort: function(index, f) {
            if (this.settings.addCheckbox) {
                index++;
            };
            if (this.settings.onSort) {
                this.settings.onSort(index, f);
            } else {
                if (this.settings.sort.field == f) {
                    if (this.settings.sort.dir == "desc") {
                        this.settings.sort.dir = "";
                    } else {
                        this.settings.sort.dir = "desc";
                    };
                } else {
                    this.settings.sort.dir = "";
                    this.settings.sort.field = f;
                };
                $("#" + this.settings.id + "_grid thead img[class='sort']").remove();
                var imgstr = (this.settings.sort.dir == 'desc') ? this.settings.sort.imagedesc : this.settings.sort.imageasc;
                $("#" + this.settings.id + "_grid thead th:eq(" + index + ")").append(imgstr);

                this.getData();
            };
        },
        getKey: function(el, e) {
            //جلوگیری از وارد کردن کاراکتر نامعتبر
            var key = (window.event) ? window.event.keyCode : e.which;
            if (!((key >= 48) && (key <= 57))) {
                if (window.event) {
                    window.event.keyCode = null;
                };
                e.returnValue = false;
                e.cancel = true;
                if (e.preventDefault)
                    e.preventDefault();
                if (e.stopPropagation)
                    e.stopPropagation();
                if (key == 13) {
                    if (el.value) {
                        var newIndex = eval(el.value);
                        if (newIndex > 0)
                            this.gotoPage((newIndex - 1));
                    };
                };
            };
        },
        setPager: function() {
            if (this.settings.pager.enable) {
                var pagerNode = $("#" + this.settings.id + "_pager");
                if (this.settings.pager.totalPages > 0) {
                    $("#" + this.settings.id + "_pager .dsPagerNode").show();
                    if (this.settings.pager.index == 0) {
                        pagerNode.find("td:eq(2)").hide();
                    } else {
                        pagerNode.find("td:eq(2)").show();
                    };
                    if (this.settings.pager.index > 0) {
                        pagerNode.find("td:eq(3)").show();
                    } else {
                        pagerNode.find("td:eq(3)").hide();
                    };
                    pagerNode.find("td input:text").val((this.settings.pager.index + 1));
                    pagerNode.find("td:eq(6)").html(this.settings.pager.totalPages);
                    if (this.settings.pager.index < (this.settings.pager.totalPages - 1)) {
                        pagerNode.find("td:eq(7)").show();
                    } else {
                        pagerNode.find("td:eq(7)").hide();
                    };
                    if (this.settings.pager.index == (this.settings.pager.totalPages - 1)) {
                        pagerNode.find("td:eq(8)").hide();
                    } else {
                        pagerNode.find("td:eq(8)").show();
                    };
                    pagerNode.find("td:eq(10)").html("مجموع رکوردها: " + this.settings.pager.totalRecords);
                } else {
                    $("#" + this.settings.id + "_pager .dsPagerNode").hide();
                };
            };
        },
        getData: function() {
            var url = this.settings.url + this.settings.urlparam.list;
            var f = this.settings.filter;
            var p = this.settings.pager;
            var s = this.settings.sort;

            var fl = [];
            for (var i in f.data) {
                if (f.data[i]) {
                    var arr = [f.data[i].col, f.data[i].sort, f.data[i].a.com, f.data[i].a.value, f.data[i].b.com, f.data[i].b.value];
                    fl[fl.length] = arr.join('$');
                };
            };
            fl = fl.join("|");

            var sortParam = "";
            if (s.field) {
                sortParam = s.field;
                if (s.dir) {
                    sortParam += " " + s.dir;
                };
            };

            var data = { Filter: fl, Sort: sortParam };
            if (p.enable) {
                data.PageIndex = p.index;
                data.PageSize = p.currentSize;
            };

            var base = this;
            this.serverLoad(url, false, data, function(msg) {
                if (!base.isInit) {
                    base.settings.columns = eval("(" + msg.Columns + ")");
                    base.getBody();
                    base.settings.sort.field = msg.SortF;
                    base.settings.sort.dir = msg.SortD;
                    var colindex;
                    for (var i in base.settings.columns) {
                        if (base.settings.columns[i].bind == msg.SortF) {
                            colindex = i;
                            break;
                        };
                    };
                    var imgstr = (base.settings.sort.dir == 'desc') ? base.settings.sort.imagedesc : base.settings.sort.imageasc;
                    $("#" + base.settings.id + "_grid thead th:eq(" + colindex + ")").append(imgstr);
                };
                if (p.enable) {
                    base.settings.pager.totalPages = msg.TotalPages;
                };
                base.settings.pager.totalRecords = msg.TotalRecords;
                if (msg.TotalRecords > 0) {
                    $("#" + base.settings.id + "_grid tbody").html(msg.Html);
                    base.onRender();
                } else {
                    $("#" + base.settings.id + "_grid tbody").html("");
                };
                if (base.settings.afterRender) {
                    base.settings.afterRender();
                };
                base.setPager();
            });
        },
        gotoPage: function(index) {
            if (index >= 0) {
                if (this.settings.pager.totalPages > 0) {
                    if (index > (this.settings.pager.totalPages - 1)) {
                        index = 0;
                    };
                };
                this.settings.pager.index = index;
                this.getData();
            };
        },
        gotoFirstPage: function() {
            this.settings.pager.index = 0;
            this.gotoPage(0);
        },
        gotoPrevPage: function() {
            if (this.settings.pager.index > 0) {
                this.settings.pager.index--;
                this.gotoPage(this.settings.pager.index);
            };
        },
        gotoNextPage: function() {
            if (this.settings.pager.index < (this.settings.pager.totalPages - 1)) {
                this.settings.pager.index++;
                this.gotoPage(this.settings.pager.index);
            };
        },
        gotoLastPage: function() {
            this.settings.pager.index = this.settings.pager.totalPages - 1;
            this.gotoPage(this.settings.pager.index);
        },
        getBody: function() {
            var s = this.settings;
            var html = "";
            html += '<div id="' + s.id + '_menu" class="dsPager"><div class="dsPager-title"><table><tr><td>' + s.title + '</td></tr></table></div></div>';
            var styleStr = "";
            if (s.showScroll) {
                styleStr = ' style="width:' + s.style.width + ';height:' + s.style.height + ';overflow:auto"';
            };
            html += '<div class="dsPager-gridholder"' + styleStr + '>';
            html += '<table id="' + this.settings.id + '_grid" class="dsPager-grid"><thead><tr>';
            for (var i in s.columns) {
                var addSort = false;
                if (s.columns[i].sort) {
                    if (s.columns[i].sort != '') {
                        addSort = true;
                    };
                };
                if (addSort) {
                    html += '<th><span class="dsPagerAddFilter"></span><a href="javascript:' + s.id + '.setSort(' + i + ',\'' + s.columns[i].bind + '\')">' + s.columns[i].name + '</a></th>';
                } else {
                    html += '<th>' + s.columns[i].name + '</th>';
                };
            };
            html += '</tr></thead><tbody></tbody></table></div>';
            html += '<div id="' + s.id + '_pager" class="dsPager" style="height:35px"><table style="width:99%"><tr>';
            if (s.pager.enable) {
                html += '<td class="dsPagerNode" style="width:45px;text-align:center;vertical-align:middle"><select onchange="' + s.id + '.setSize(this)">';
                var tmp = ' selected="selected"';
                for (var i in s.pager.size) {
                    html += '<option' + ((s.pager.currentSize == s.pager.size[i]) ? tmp : "") + ' value="' + s.pager.size[i] + '">' + s.pager.size[i] + '</option>';
                };
                html += '</select></td>';
                html += '<td class="dsPagerNode" style="width:15px;text-align:center;vertical-align:middle"><div class="dsPager-seprator"></div></td>';
                html += '<td class="dsPagerNode" style="width:20px;text-align:center;vertical-align:middle"><a href="javascript:' + s.id + '.gotoFirstPage()" class="dsPager-btn dsPager-first"></a></td>';
                html += '<td class="dsPagerNode" style="width:20px;text-align:center;vertical-align:middle"><a href="javascript:' + s.id + '.gotoPrevPage()" class="dsPager-btn dsPager-prev"></a></td>';
                html += '<td class="dsPagerNode" style="width:60px;text-align:center;vertical-align:middle"><input onkeypress="' + s.id + '.getKey(this,event)" class="text" type="text" value="" /></td>';
                html += '<td class="dsPagerNode" style="width:10px;text-align:center;vertical-align:middle">/</td><td class="dsPagerNode" style="width:25px;text-align:center;vertical-align:middle">&nbsp;</td>';
                html += '<td class="dsPagerNode" style="width:20px;text-align:center;vertical-align:middle"><a href="javascript:' + s.id + '.gotoNextPage()" class="dsPager-btn dsPager-next"></a></td>';
                html += '<td class="dsPagerNode" style="width:20px;text-align:center;vertical-align:middle"><a href="javascript:' + s.id + '.gotoLastPage()" class="dsPager-btn dsPager-last"></a></td>';
                html += '<td class="dsPagerNode" style="width:15px;text-align:center;vertical-align:middle"><div class="dsPager-seprator"></div></td>';
                html += '<td class="dsPagerNode" style="width:100px;text-align:center;vertical-align:middle"></td>';
            }
            html += '<td style="direction:rtl;text-align:right;vertical-align:middle"><table><tr>';
            if (s.insert.enable) {
                html += '<td><a title="اضافه کردن" class="dsPager-btn dsPager-add" href="javascript:' + s.id + '.insert()"></a></td>';
            };
            if (s.edit.enable) {
                html += '<td><a title="ویرایش" class="dsPager-btn dsPager-edit" href="javascript:' + s.id + '.edits()"></a></td>';
            };
            if (s.del.enable) {
                html += '<td><a title="حذف" class="dsPager-btn dsPager-delete" href="javascript:' + s.id + '.del()"></a></td>';
            };
            if (s.select) {
                html += '<td><a title="انتخاب" class="dsPager-btn dsPager-down" href="javascript:' + s.id + '.settings.select(' + s.id + '.getIds())"></a></td>';
            };
            if (s.exportbtn) {
                html += '<td><a title="ذخیره اطلاعات" class="dsPager-btn dsPager-export" href="javascript:' + s.id + '.exportData()"></a></td>';
                html += '<td><a title="پرینت اطلاعات" class="dsPager-btn dsPager-print" href="javascript:' + s.id + '.print()"></a></td>';
            };
            html += '<td><a title="دریافت مجدد اطلاعات" class="dsPager-btn dsPager-reload" href="javascript:' + s.id + '.reload()"></a></td>';
            html += '<td><a title="حذف تمامی فیلترها" class="dsPager-btn dsPager-unfilter" href="javascript:' + s.id + '.unfilter()"></a></td>';
            if (s.menus.length > 0) {
                for (var ii = 0; ii < s.menus.length; ii++) {
                    var cssClass = (s.menus[ii].cssClass) ? s.menus[ii].cssClass : "";
                    html += '<td><a title="' + s.menus[ii].text + '" class="dsPager-btn ' + cssClass + '" href="' + s.menus[ii].link + '"></a></td>';
                };
            };
            html += '</tr></table></td>';
            html += '</tr></table></div>';

            $("#" + s.id).html(html);
        },
        html: function() {
            var base = this;
            var html = '<div id="' + base.settings.id + '" class="dsPager-holder">';
            html += '</div>';
            document.write(html);
            $(document).ready(function() {
                base.htmlInit();
            });
        },
        exportData: function() {
            if ($("#grid_export_data").length == 0) {
                $('<div id="grid_export_data"><div style="padding:5px" class="dsPagerExport"><p>محدوده:<br /><select id="export_range"><option value="0">همین صفحه</option><option value="1">تمامی صفحات</option></select></p>' +
            '<p>فرمت خروجی:<br /><select id="export_format"><option value="xml">XML</option><option value="doc">پرونده Word</option><option value="xls">پرونده Excel</option><option value="html">پرونده HTML</option></select></p>' +
            '<p><input class="input-button" id="export_run" type="button" value="اجرا" /></p></div><div style="display:none"><iframe id="export_frame" src=""></iframe></div></div>').appendTo('body');
                $("#grid_export_data").dialog({
                    modal: true,
                    title: 'خروجی از اطلاعات',
                    autoOpen: false,
                    width: 200
                });
            };
            $("#grid_export_data").dialog('open');
            var base = this;
            $("#export_run").unbind().bind('click', function() {
                base.exportGo($("#export_range option:selected").attr("value"), $("#export_format option:selected").attr("value"));
                $("#grid_export_data").dialog('close');
            });
        },
        print: function() {
            this.exportGo('0', 'print');
        },
        exportGo: function(range, format) {
            var url = this.settings.url + '/ExportList';
            var f = this.settings.filter;
            var p = this.settings.pager;
            var s = this.settings.sort;

            var fl = [];
            for (var i in f.data) {
                if (f.data[i]) {
                    var arr = [f.data[i].col, f.data[i].sort, f.data[i].a.com, f.data[i].a.value, f.data[i].b.com, f.data[i].b.value];
                    fl[fl.length] = arr.join('$');
                };
            };
            fl = fl.join("|");

            var sortParam = "";
            if (s.field) {
                sortParam = s.field;
                if (s.dir) {
                    sortParam += " " + s.dir;
                };
            };

            var data = { Filter: fl, Sort: sortParam };
            data.mode = format;
            data.title = this.settings.title;
            if (p.enable) {
                if (range == "0") {
                    data.PageIndex = p.index;
                    data.PageSize = p.currentSize;
                } else {
                    data.PageIndex = 0;
                    data.PageSize = this.settings.pager.totalRecords;
                };
            };
            if (this.settings.beforeAjax) {
                this.settings.beforeAjax(data);
            };
            var doc;
            if (format != 'print') {
                doc = document.getElementById("export_frame").contentWindow.document;
            } else {
                doc = window.open('', 'GridPrintWindow');
                if (!doc) {
                    alert('پنجره پرینت باز نشد. ممکن است مرورگر شما آنرا بلاک کرده باشد.');
                } else {
                    doc = doc.document;
                };
            };
            if (doc) {
                var htmldoc = '<html><head></head><body>';
                htmldoc += '<form action="' + url + '" method="post">';
                for (var keyi in data) {
                    htmldoc += '<input type="hidden" name="' + keyi + '" value="' + data[keyi] + '" />';
                };
                htmldoc += '</form></body></html>';
                doc.open();
                doc.write(htmldoc);
                doc.close();
                doc.getElementsByTagName("form")[0].submit();
            };
        },
        htmlInit: function() {
            var base = this;
            if (base.settings.showScroll) {
                if (base.settings.autoWidth) {
                    var cw = $("#" + base.settings.id).width();
                    if (base.settings.insidetab) {
                        cw -= 10;
                    };
                    base.settings.style.width = cw + "px";
                };
                $("#" + base.settings.id).css("width", base.settings.style.width);
            };
            if (base.settings.autoLoad) {
                base.getData();
            };
        },
        hide: function() {
            $("#" + this.settings.id).html("");
        },
        show: function() {
            var base = this;
            if (base.settings.showScroll) {
                if (base.settings.autoWidth) {
                    var cw = $("#" + base.settings.id).width();
                    if (base.settings.insidetab) {
                        cw -= 10;
                    };
                    base.settings.style.width = cw + "px";
                };
                $("#" + base.settings.id).css("width", base.settings.style.width);
            };
            base.getData();
        },
        block: function() {
            //استفاده از پلاگین بلاک  
            var msg = this.settings.blockMessage;
            $("#" + this.settings.id).block({ message: msg });
        },
        unblock: function() {
            $("#" + this.settings.id).unblock();
        },
        edit: function(e) {
            var data = eval($("#" + this.settings.id + "_grid tbody tr:eq(" + e.data.index + ")").data("grid.bind"));
            if (this.settings.onEdit) {
                this.settings.onEdit(data.ids);
            } else {
                var dt = '';
                if (data.ids.length > 0) {
                    for (var i in data.ids) {
                        dt += data.ids[i].key + "=" + data.ids[i].value + "&";
                    };
                };
                if (this.settings.edit.param) {
                    dt += this.settings.edit.param();
                };
                window.location.href = this.settings.url + this.settings.urlparam.edit + dt;
            };
        },
        edits: function() {
            debugger;
            var base = this;
            var ids = base.getIds();
            var added = 0;
            var len = 0;
            for (var key in ids) {
                if (ids[key].length > 0) {
                    len = ids[key].length;
                    added++;
                    break;
                };
            };
            if (added > 0) {
                if (len == 1) {
                    var dt = '';
                    for (var i in ids) {
                        dt += i + "=" + ids[i] + "&";
                    };
                    if (this.settings.edit.param) {
                        dt += this.settings.edit.param();
                    };
                    window.location.href = this.settings.url + this.settings.urlparam.edit + dt;
                } else {
                    alert('یک رکورد را انتخاب کنید');
                };
            } else {
                alert('یک رکورد را انتخاب کنید');
            };
        },
        getIds: function() {
            var ids = [];
            $("#" + this.settings.id + " tbody tr").each(function(index) {
                if ($(this).find("td:eq(0) :checkbox").is(":checked")) {
                    var id = eval($(this).data("grid.bind"));
                    var KeyIndex;
                    for (var i in id.ids) {
                        KeyIndex = id.ids[i].key;
                        if (!ids[KeyIndex]) {
                            ids[KeyIndex] = [];
                        };
                        ids[KeyIndex][ids[KeyIndex].length] = id.ids[i].value;
                    };
                };
            });
            return ids;
        },
        doAction: function(cmd) {
            if (this.settings.onAction) {
                this.settings.onAction(cmd, this.getIds());
            };
        },
        del: function() {
            var base = this;
            var ids = base.getIds();
            var data = {};
            var added = 0;
            for (var key in ids) {
                if (ids[key].length > 0) {
                    data[key] = ids[key].join(',');
                    added++;
                };
            };
            if (added > 0) {
                if (window.confirm('آیا موارد انتخاب شده حذف شوند؟')) {
                    if (base.settings.del.param) {
                        $.extend(data, base.settings.del.param());
                    };
                    if (base.settings.onDelete) {
                        base.settings.onDelete(data);
                    };
                    base.serverLoad(base.settings.url + base.settings.urlparam.del, false, data, function(msg) {
                        if (msg.success) {
                            base.getData();
                        } else {
                            alert(msg.message);
                        };
                    });
                };
            };
        },
        insert: function() {
            var dt = '';
            if (this.settings.insert.param) {
                dt += this.settings.insert.param();
            };
            window.location.href = this.settings.url + this.settings.urlparam.insert + dt;
        },
        onRender: function() {
            var id = this.settings.id;
            var base = this;
            if (this.settings.addCheckbox) {
                $("#" + id + "_grid tbody tr").each(function() {
                    $(this).prepend('<td><input type="checkbox" /></td>');
                });
                if (!this.isInit) {
                    $("#" + id + "_grid thead tr").each(function() {
                        $(this).prepend('<th style="width:20px"><input onclick="' + id + '.checkAll(this)" type="checkbox" /></th>');
                    });
                };
            };
            $("#" + id + "_grid tbody tr").each(function(index) {
                if ((index % 2) == 1) {
                    $(this).addClass("altrow");
                };
                var bindvalue = $(this).attr("data");
                $(this).data("grid.bind", bindvalue);
                $(this).removeAttr("data");
                if (base.settings.edit.enable) {
                    $(this).bind("dblclick", { index: index }, function(e) {
                        base.edit(e);
                    });
                };
                var rowTr = $(this);
                $(this).find("td:eq(0) :checkbox").bind("click", function(e) {
                    if ($(this).is(":checked")) {
                        rowTr.data("select", true).addClass("selected");
                    } else {
                        rowTr.data("select", false).removeClass("selected");
                    };
                });
            });
            if (!this.isInit) {
                $("#" + id + "_grid thead th").each(function(index) {
                    $(this).find("span").bind("click", { index: index }, function(e) {
                        base.showFilter(e);
                    });
                });
                this.isInit = true;
            };
            if (base.settings.showScroll) {
                if (base.settings.autoHeight && !base.settings.insidetab) {
                    var len = $("#" + id + "_grid tbody tr").length;
                    if (len == 10) {
                        var h1 = $("#" + id + "_grid").height();
                        base.settings.autoHeight = false;
                        $("#" + id + " .dsPager-gridholder").css("height", (h1 + 10) + "px");
                    };
                };
            };
        },
        serverLoad: function(url, cache, dt, success) {
            if (this.settings.beforeAjax) {
                this.settings.beforeAjax(dt);
            };
            this.block();
            var base = this;
            $.ajax({
                cache: cache,
                url: url,
                type: 'POST',
                data: dt,
                dataType: 'json',
                success: function(result) {
                    if (base.settings.afterAjax) {
                        base.settings.afterAjax(result);
                    };
                    if (success) {
                        success(result);
                    };
                },
                error: function(x, e) {
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
                        alert('Unknow Error.\n' + x.responseText);
                    }
                },
                complete: function() {
                    base.unblock();
                }
            });
        }
    };
};
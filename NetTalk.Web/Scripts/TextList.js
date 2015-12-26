var TextList = function(jq) {
    var jlist = new generic.list();
    var id = $(jq).attr("id");
    var html = '<div class="mlist" id="div_' + id + '">';
    if ($(jq).val()) {
        jlist.addRange($(jq).val().split(/,/g));
        var tgs = $(jq).val().split(/,/g);
        if (tgs.length > 0) {
            for (var i = 0; i < tgs.length; i++) {
                html += '<div title="' + tgs[i] + '" class="mlist-item"';
                html += '><span>x</span><p>' + tgs[i] + '</p></div>';
            };
        };
    };
    html += '<div class="mlist-clear" style="clear:both"></div></div>';
    $(jq).data('tags', jlist);
    $(jq).after(html);
    this.reload = function() {
        $("#div_" + id + " span").unbind().bind('click', function() {
            var val = $(this).parent().attr("title");
            var glist = $(jq).data('tags');
            glist.remove(val);
            $(jq).val(glist.join(','));
            $(this).parent().animate({ 'opacity': 'hide', "backgroundColor": "red" },
                    function() {
                        $(this).remove();
                    });
        });
        $("#div_" + id + " div.mlist-item:last").css("backgroundColor", "#FFFFCC").animate({ "backgroundColor": "#ECFBEC" }, 'slow');
    }
    this.add = function(str) {
        var li = $(jq).data('tags');
        if (li.find(str) == -1) {
            li.add(str);
            $(jq).val(li.join(','));
            $(jq).data('tags', li);
            html = '<div title="' + str + '" class="mlist-item">';
            html += '<span>x</span><p>' + str + '</p></div>';
            $("#div_" + id + " div.mlist-clear").before(html);
            this.reload();
        } else {
            alert("چنین تگی در لیست موجود است");
        };
    };
    this.val = function() {
        return $(jq).val();
    };
    this.reload();
};

var MSelect = function(config) {
    var settings = {
        id: '',
        cssClass: ''
    };
    $.extend(settings, config);

    return {
        settings: settings,
        list: {
            v: new generic.list(),
            t: new generic.list()
        },
        init: function() {
            var c = "mlist";
            if (this.settings.cssClass) {
                c += " " + this.settings.cssClass;
            };
            var html = '<div class="' + c + '" id="div_' + this.settings.id + '">';
            html += '<div class="mlist-clear" style="clear:both"></div></div>';
            $("#" + this.settings.id).after(html);
        },
        clear: function() {
            $("#div_" + this.settings.id + " .mlist-item").remove();
            $("#" + this.settings.id).val("");
            $("#" + this.settings.id + "_text").val("");
            this.list.v = new generic.list();
            this.list.t = new generic.list();
        },
        build: function() {
            $("#div_" + this.settings.id + " .mlist-item").remove();
            if ($("#" + this.settings.id + "_text").val()) {
                var tgs = $("#" + this.settings.id + "_text").val().split(/,/g);
                var vals = $("#" + this.settings.id).val().split(/,/g);
                var html;
                if (tgs.length > 0) {
                    for (var i = 0; i < tgs.length; i++) {
                        html = "";
                        html += '<div title="' + tgs[i] + '" class="mlist-item"';
                        html += '><span>x</span><p>' + tgs[i] + '</p></div>';
                        $("#div_" + this.settings.id + " div.mlist-clear").before(html);
                        this.list.t.add(tgs[i]);
                        this.list.v.add(vals[i]);
                    };
                    var b = this;
                    $("#div_" + b.settings.id + " span").unbind().bind('click', function() {
                        var val = $(this).parent().attr("title");
                        var findex = b.list.t.find(val);
                        if (findex >= 0) {
                            b.list.t.removeAt(findex);
                            b.list.v.removeAt(findex);

                            $("#" + b.settings.id).val(b.list.v.join(','));
                            $("#" + b.settings.id + "_text").val(b.list.t.join(','));
                            $(this).parent().animate({ 'opacity': 'hide'}, function() { $(this).remove(); });
                        };
                    });
                };
            };
        },
        add: function(str, val) {
            if (this.list.v.find(val) == -1) {
                this.list.t.add(str);
                this.list.v.add(val);

                $("#" + this.settings.id + "_text").val(this.list.t.join(','));
                $("#" + this.settings.id).val(this.list.v.join(','));

                var html = '<div title="' + str + '" class="mlist-item">';
                html += '<span>x</span><p>' + str + '</p></div>';
                $("#div_" + this.settings.id + " div.mlist-clear").before(html);
                var b = this;
                $("#div_" + b.settings.id + " div.mlist-item:last span").bind('click', function() {
                    var val = $(this).parent().attr("title");
                    var findex = b.list.t.find(val);
                    if (findex >= 0) {
                        b.list.t.removeAt(findex);
                        b.list.v.removeAt(findex);

                        $("#" + b.settings.id).val(b.list.v.join(','));
                        $("#" + b.settings.id + "_text").val(b.list.t.join(','));
                        $(this).parent().animate({ 'opacity': 'hide' }, 'normal', "", function() { $(this).remove(); });
                    };
                });
            } else {
                alert(str + "\r\nچنین ایتمی در لیست موجود است");
            };
        },
        val: function() {
            return $("#" + this.settings.id).val();
        },
        text: function() {
            return $("#" + this.settings.id + "_text").val();
        }
    };
};
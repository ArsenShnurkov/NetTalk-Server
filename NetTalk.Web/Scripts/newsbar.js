var newsbar = function(name, targetId, speed, timeout) {
    this.id = targetId;
    this.speed = speed || 100;
    this.timeout = timeout || 2000;
    this.position = 0;
    this.index = 0;
    this.name = name;
    this.wait = false;
};
newsbar.prototype.setWait = function(bool) {
    this.wait = bool;
    if (!bool)
        this.start();
    else if (this.end && bool)
        this.stop();
};
newsbar.prototype.init = function() {
    var n = this.name;
    var aTag = '<a onmouseover="' + n + '.setWait(true)" onmouseout="' + n + '.setWait(false)" id="' + n + '_newsbar" href="" title=""></a>';
    document.getElementById(this.id).innerHTML = aTag;
    this.id = this.name + '_newsbar';
    this.start();
};
newsbar.prototype.setData = function(data) {
    this.data = data;
};
newsbar.prototype.next = function() {
    if (!(this.end && this.wait)) {
        this.position++;
        var spd = this.speed;
        var item = this.data[this.index];
        if (this.position > item.text.length) {
            this.clear();
            this.index++;
            if (this.index > (this.data.length - 1)) {
                this.index = 0;
            };
            item = this.data[this.index];
            document.getElementById(this.id).href = item.link;
            document.getElementById(this.id).title = item.title;
        } else {
        	document.getElementById(this.id).href = item.link;
            document.getElementById(this.id).title = item.title;
            document.getElementById(this.id).innerHTML = item.text.substring(0, this.position) + "_";
            if (this.position == item.text.length) {
                spd = this.timeout;
                this.end = true;
            };
        };
        this.timer = window.setTimeout(this.name + ".next()", spd);
    };
};
newsbar.prototype.clear = function() {
    this.position = 0;
    this.end = false;
    document.getElementById(this.id).innerHTML = "";
};
newsbar.prototype.stop = function() {
    window.clearTimeout(this.timer);
};
newsbar.prototype.start = function() {
    window.clearTimeout(this.timer);
    this.end = false;
    this.timer = window.setTimeout(this.name + ".next()", this.speed);
};
newsbar.prototype.position = 0;

var TimeHolder = {};
TimeHolder.start = function(obj) {
    TimeHolder.info = {
        id: obj.id,
        hour: obj.hour,
        minute: obj.minute,
        second: obj.second
    };
    window.setInterval('TimeHolder.setTime()', 1000);
};
TimeHolder.setTime = function() {
    if (TimeHolder.info.second < 59) {
        TimeHolder.info.second++;
    } else {
        TimeHolder.info.second = 0;
        if (TimeHolder.info.minute < 59) {
            TimeHolder.info.minute++;
        } else {
            TimeHolder.info.minute = 0;
            if (TimeHolder.info.hour < 23) {
                TimeHolder.info.hour++;
            } else {
                TimeHolder.info.hour = 0;
            };
        };
    };
    var hh, mm, ss;
    if (TimeHolder.info.hour < 10)
        hh = "0" + TimeHolder.info.hour;
    else
        hh = TimeHolder.info.hour + "";

    if (TimeHolder.info.minute < 10)
        mm = "0" + TimeHolder.info.minute;
    else
        mm = TimeHolder.info.minute + "";

    if (TimeHolder.info.second < 10)
        ss = "0" + TimeHolder.info.second;
    else
        ss = TimeHolder.info.second + "";

    $("#" + TimeHolder.info.id).html(hh + ":" + mm + ":" + ss);
};

var PollSend = function() {
    var id = $("#PollId").val();
    var selected = $("input:radio[name='Poll_" + id + "']:checked").val();
    if (selected) {
        $("#PollHolder").html('<img src="/Content/Images/indicator-orange.gif" style="vertical-align:middle" /><br />در حال دریافت اطلاعات');
        $.ajax({
            type: 'POST',
            url: '/UIModules/Polls',
            data: { 'pl': id, 'pid': selected },
            success: function(result) {
                $("#PollHolder").load("/UIModules/Polls/?show=true");
            }
        });
    } else {
        alert('هیچ گزینه ای انتخاب نشده است');
    };
};

var PollShow = function() {
    $("#PollHolder").html('<img src="/Content/Images/indicator-orange.gif" style="vertical-align:middle" /><br />در حال دریافت اطلاعات');
    $("#PollHolder").load("/UIModules/Polls/?show=true");
};

var GList = {};
GList.Data = [];
GList.Index = 0;
GList.SetIndex = function() {
    if (GList.Data.length > 0) {
        var ShowImg = false;
        if (GList.Data[GList.Index].Img) {
            if (GList.Data[GList.Index].Img != '') {
                ShowImg = true;
                $("#GImg").attr("src", "/Thumb.ashx?q=100&w=195&h=145&url=" + GList.Data[GList.Index].Img).attr("alt", GList.Data[GList.Index].Title);
            };
        };
        if (ShowImg) {
            $("#GImg").show();
        } else {
            $("#GImg").hide();
        };
        $("#GText a").attr("href", GList.Data[GList.Index].Href).html(GList.Data[GList.Index].Html);
    } else {
        $("#GTable").hide();
    };
};
GList.Next = function() {
    if (GList.Data.length > 1) {
        GList.Index++;
        if (GList.Index > (GList.Data.length - 1)) {
            GList.Index = 0;
        };
        GList.SetIndex();
    };
};
GList.Prev = function() {
    if (GList.Data.length > 1) {
        GList.Index--;
        if (GList.Index < 0) {
            GList.Index = (GList.Data.length - 1);
        };
        GList.SetIndex();
    };
};
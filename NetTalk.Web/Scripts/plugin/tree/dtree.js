var Tree = function(BaseId, BaseFolder, enImg) {
    this.id = BaseId;
    this.folder = BaseFolder;
    this.img = enImg;
};

Tree.prototype.changeState = function(nid, icon, openIcon) {
    var el = document.getElementById(this.id + "_TreeNodeState" + nid);
    var elIco = document.getElementById(this.id + "_TreeNodeFolder" + nid);
    if (el.src.indexOf('plus') >= 0) {
        if (el.src.indexOf(this.folder + 'tree/plusbottom.gif') >= 0) {
            el.src = this.folder + 'tree/minusbottom.gif';
        } else {
            el.src = this.folder + 'tree/minus.gif';
        };
        if (this.img)
            elIco.src = (openIcon) ? openIcon : (this.folder + 'tree/folderopen.gif');
        $("#" + this.id + "_TreeNodeChilds" + nid).animate({ height: 'show', opacity: 'show' }, 'fast');
    } else {
        if (el.src.indexOf(this.folder + 'tree/minusbottom.gif') >= 0) {
            el.src = this.folder + 'tree/plusbottom.gif';
        } else {
            el.src = this.folder + 'tree/plus.gif';
        };
        if (this.img)
            elIco.src = (icon) ? icon : (this.folder + 'tree/folder.gif');
        $("#" + this.id + "_TreeNodeChilds" + nid).animate({ height: 'hide', opacity: 'hide' }, 'fast');
    };
};

Tree.prototype.checkNode = function(el, id) {
    var bid = this.id;
    if (el.checked)
        $("#" + bid + "_TreeNodeChilds" + id + " input[name='" + bid + "_CHK']").attr("checked", "checked");
    else
        $("#" + bid + "_TreeNodeChilds" + id + " input[name='" + bid + "_CHK']").removeAttr("checked");
};

Tree.prototype.getNodeData = function(id) {
    var dt = $("#" + this.id + "_TreeNode" + id).attr("data");
    var ssData = [];
    if (dt) {
        dt = eval(dt);
        if (dt.ids.length > 0) {
            for (var i in dt.ids) {
                ssData[dt.ids[i].key] = dt.ids[i].value;
            };
        };
    };
    return ssData;
};

Tree.prototype.selectNode = function(id, isLast) {
    if (this.onSelect) {
        var ssData = this.getNodeData(id);
        this.onSelect(id, ssData);
    };
};

Tree.prototype.selectNodeDBL = function(id, isLast) {
    if (this.onDoubleClick) {
        var ssData = this.getNodeData(id);
        this.onDoubleClick(id, ssData);
    };
};

Tree.prototype.selectNodeContext = function(action, el, pos) {
    if (this.onContextMenu) {
        var id = $(el).attr("id");
        var bid = this.id;
        id = id.replace(bid + "_TreeNode", "");
        var ssData = this.getNodeData(id);
        this.onContextMenu(action, id, ssData);
    };
};

Tree.prototype.checkedNode = function() {
    var result = [];
    $("#" + this.id + " input:checkbox").each(function() {
        if ($(this).is(":checked")) {
            result[result.length] = $(this).val();
        };
    });
    return result;
};

var AjaxTree = function(BaseId, BaseFolder, HolderId, enImg, ajaxUrl) {
    this.id = BaseId;
    this.folder = BaseFolder;
    this.holder = HolderId;
    this.img = enImg;
    this.loading = [];
    this.loaded = [];
    this.menu = [];
    this.ajaxUrl = ajaxUrl;
};

AjaxTree.prototype.addMenu = function(text, action, cssClass, separator) {
    separator = (separator) ? true : false;
    cssClass = (cssClass) ? cssClass : "";
    this.menu[this.menu.length] = {
        text: text,
        action: action,
        cssClass: cssClass,
        separator: separator
    };
    return this;
};

AjaxTree.prototype.initContextMenu = function() {
    if (this.menu.length > 0) {
        var b = this;
        if (this.contextInit) {
            $("#" + b.id + " .TreeNode").destroyContextMenu();
        };
        if ($("#" + b.id + "_ContextMenu").length == 0) {
            var html = "<ul id=\"" + b.id + "_ContextMenu\" class=\"contextMenu\">";
            var tmp;
            for (var i = 0; i < b.menu.length; i++) {
                tmp = b.menu[i].cssClass;
                if (b.menu[i].separator) {
                    if (tmp)
                        tmp += " ";
                    tmp += "separator";
                };
                html += "<li class=\"" + tmp + "\"><a href=\"#" + b.menu[i].action + "\">" + b.menu[i].text + "</a></li>";
            };
            html += "</ul>";
            $(html).insertAfter("#" + b.holder);
        };
        $("#" + b.id + " .TreeNode").contextMenu({ menu: b.id + "_ContextMenu" }, function(action, el, pos) {
            b.selectNodeContext(action, el, pos);
        });
        this.contextInit = true;
    };
};

AjaxTree.prototype.init = function() {
    this.loading = [];
    this.loaded = [];
    var b = this;
    var tmpDiv = '<img src="' + this.folder + 'tree/ajax-loader.gif" alt="Loading" />';
    $("#" + this.holder).html(tmpDiv);
    var baseId = this.id;
    var basef = this.folder;
    var data = {
        islast: false,
        prefix: '',
        id: '',
        baseid: baseId,
        basefolder: basef,
        img: b.img
    };
    if (this.beforeAjax) {
        this.beforeAjax(data);
    };
    var ajurl = this.ajaxUrl;
    var hid = this.holder;
    $.ajax({
        url: ajurl,
        data: data,
        type: 'POST',
        cache: false,
        success: function(result) {
            $("#" + hid).html(result);
            b.initContextMenu();
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
            };
        }
    });
};

AjaxTree.prototype.changeState = function(nid, icon, openIcon, isLast) {
    if (!this.loading[nid] && this.loaded[nid]) {
        var el = document.getElementById(this.id + "_TreeNodeState" + nid);
        var elIco = document.getElementById(this.id + "_TreeNodeFolder" + nid);
        if (el.src.indexOf('plus') >= 0) {
            if (el.src.indexOf(this.folder + 'tree/plusbottom.gif') >= 0) {
                el.src = this.folder + 'tree/minusbottom.gif';
            } else {
                el.src = this.folder + 'tree/minus.gif';
            };
            if (this.img)
                elIco.src = (openIcon) ? openIcon : (this.folder + 'tree/folderopen.gif');
            $("#" + this.id + "_TreeNodeChilds" + nid).animate({ height: 'show', opacity: 'show' }, 'fast');
        } else {
            if (el.src.indexOf(this.folder + 'tree/minusbottom.gif') >= 0) {
                el.src = this.folder + 'tree/plusbottom.gif';
            } else {
                el.src = this.folder + 'tree/plus.gif';
            };
            if (this.img)
                elIco.src = (icon) ? icon : (this.folder + 'tree/folder.gif');
            $("#" + this.id + "_TreeNodeChilds" + nid).animate({ height: 'hide', opacity: 'hide' }, 'fast');
        };
    } else if (!this.loaded[nid] && !this.loading[nid]) {
        this.loading[nid] = true;
        this.loaded[nid] = false;
        var b = this;
        var tmpDiv = $("#" + this.id + "_TreeNodePrefix" + nid).html();
        var tmpDiv2 = '<div class="TreeNodeTemp" id="' + this.id + '_TreeNodeTemp' + nid + '">' + tmpDiv + '<img src="' + this.folder + 'tree/joinbottom.gif" />&nbsp;<img src="' + this.folder + 'tree/ajax-loader.gif" alt="Loading" /></div>';
        $(tmpDiv2).insertAfter("#" + this.id + "_TreeNode" + nid);

        var baseId = this.id;
        var basef = this.folder;
        tmpDiv = escape(tmpDiv);
        var data = {
            islast: isLast,
            prefix: tmpDiv,
            id: nid,
            baseid: baseId,
            basefolder: basef,
            img: b.img
        };
        if (this.beforeAjax) {
            this.beforeAjax(data);
        };
        $.ajax({
            url: b.ajaxUrl,
            data: data,
            type: 'POST',
            cache: false,
            success: function(result) {
                b.loaded[nid] = true;
                var el = document.getElementById(b.id + "_TreeNodeState" + nid);
                var elIco = document.getElementById(b.id + "_TreeNodeFolder" + nid);
                if (result) {
                    $("#" + baseId + "_TreeNodeTemp" + nid).replaceWith(result);
                    if (el.src.indexOf(b.folder + 'tree/plusbottom.gif') >= 0) {
                        el.src = b.folder + 'tree/minusbottom.gif';
                    } else {
                        el.src = b.folder + 'tree/minus.gif';
                    };
                    if (b.img)
                        elIco.src = (openIcon) ? openIcon : (b.folder + 'tree/folderopen.gif');
                } else {
                    if (el.src.indexOf(b.folder + 'tree/plusbottom.gif') >= 0) {
                        el.src = b.folder + 'tree/joinbottom.gif';
                    } else {
                        el.src = b.folder + 'tree/join.gif';
                    };
                    if (b.img)
                        elIco.src = (icon) ? icon : (b.folder + 'tree/page.gif');
                };
                b.initContextMenu();
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
                };
            },
            complete: function() {
                b.loading[nid] = false;
            }
        });
    };
}

AjaxTree.prototype.checkNode = function(el, id) {
    var bid = this.id;
    if (el.checked)
        $("#" + bid + "_TreeNodeChilds" + id + " input[name='" + bid + "_CHK']").attr("checked", "checked");
    else
        $("#" + bid + "_TreeNodeChilds" + id + " input[name='" + bid + "_CHK']").removeAttr("checked");
};

AjaxTree.prototype.getNodeData = function(id) {
    var dt = $("#" + this.id + "_TreeNode" + id).attr("data");
    var ssData = [];
    if (dt) {
        dt = eval(dt);
        if (dt.ids.length > 0) {
            for (var i in dt.ids) {
                ssData[dt.ids[i].key] = dt.ids[i].value;
            };
        };
    };
    return ssData;
};

AjaxTree.prototype.selectNode = function(id, isLast) {
    if (this.onSelect) {
        var ssData = this.getNodeData(id);
        this.onSelect(id, ssData);
    };
};

AjaxTree.prototype.selectNodeDBL = function(id, isLast) {
    if (this.onDoubleClick) {
        var ssData = this.getNodeData(id);
        this.onDoubleClick(id, ssData);
    };
};

AjaxTree.prototype.selectNodeContext = function(action, el, pos) {
    if (this.onContextMenu) {
        var id = $(el).attr("id");
        var bid = this.id;
        id = id.replace(bid + "_TreeNode", "");
        var ssData = this.getNodeData(id);
        this.onContextMenu(action, id, ssData);
    };
};

AjaxTree.prototype.checkedNode = function() {
    var result = [];
    $("#" + this.id + " input:checkbox").each(function() {
        if ($(this).is(":checked")) {
            result[result.length] = $(this).val();
        };
    });
    return result;
};
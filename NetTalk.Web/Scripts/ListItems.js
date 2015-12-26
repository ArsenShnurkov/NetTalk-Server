/*
List Item V2 by 
    Mahdi Yousefi, mahdi@tini.ir
codes published under The Code Project Open License (CPOL)

Insert,Remove, Add function optimize codes by "Jeffrey Scott Flesher"
http://www.codeproject.com/Messages/2781456/Optimize.aspx

*/
(function() {
    window.generic = {
        list: function() {
            return {
                hasValue: function(obj) {
                    return (((typeof (obj) == 'undefined') || (obj == null)) == false);
                },
                items: [],
                item: function(index, obj) {
                    if (this.hasValue(obj))
                        this.items[index] = obj;
                    else
                        return this.items[index];
                },
                property: function(index, pro, value) {
                    if (this.hasValue(value))
                        this.items[index][pro] = value;
                    else
                        return this.items[index][pro];
                },
                extend: function(index, obj) {
                    var key;
                    for (key in obj) {
                        this.property(index, key, obj[key]);
                    }
                },
                add: function(obj) {
                    this.items[this.items.length] = obj;
                },
                addRange: function(objArray) {
                    var i = 0;
                    for (i = 0; i < objArray.length; i++) {
                        this.items[this.items.length] = objArray[i];
                    };
                },
                insert: function(obj, index) {
                    if (this.items.length > 0) {
                        var i = 0;
                        for (i = this.items.length; i > index; i--) {
                            this.items[i] = this.items[(i - 1)];
                        };
                        this.items[index] = obj;
                    } else {
                        this.items[0] = obj;
                    };
                },
                isEqual: function(a, b) {
                    return (a === b);
                },
                find: function(obj) {
                    var result = -1;
                    var i = 0;
                    for (i = 0; i < this.items.length; i++) {
                        if (this.isEqual(this.items[i], obj)) {
                            result = i;
                            break;
                        };
                    };
                    return result;
                },
                clear: function() {
                    this.items = [];
                },
                remove: function(obj) {
                    var tmp = [], i = 0, j = 0;
                    for (i = 0; i < this.items.length; i++) {
                        if (!this.isEqual(this.items[i], obj)) {
                            tmp[j++] = this.items[i];
                        };
                    };
                    this.clear();
                    this.items = tmp;
                },
                removeAt: function(index) {
                    this.remove(this.items[index]);
                },
                join: function(seprator, pro) {
                    var i = 0;
                    var result = "";
                    var count = this.items.length;
                    for (i = 0; i < count; i++) {
                        if (i == (count - 1)) {
                            result += (this.hasValue(pro)) ? this.items[i][pro] : this.items[i];
                        } else {
                            result += (this.hasValue(pro)) ? this.items[i][pro] : this.items[i];
                            result += seprator;
                        };
                    };
                    return result;
                }
            };
        }
    };
})();
// USE WORDWRAP AND MAXIMIZE THE WINDOW TO SEE THIS FILE
c_styles={};c_menus={}; // do not remove this line

// You can remove most comments from this file to reduce the size if you like.




/******************************************************
	(1) GLOBAL SETTINGS
*******************************************************/

c_hideTimeout=500; // 1000==1 second
c_subShowTimeout=250;
c_keepHighlighted=true;
c_findCURRENT=true; // find the item linking to the current page and apply it the CURRENT style class
c_findCURRENTTree=true;
c_overlapControlsInIE=true;
c_rightToLeft = true;  // if the menu text should have "rtl" direction (e.g. Hebrew, Arabic)




/******************************************************
	(2) MENU STYLES (CSS CLASSES)
*******************************************************/

// You can define different style classes here and then assign them globally to the menu tree(s)
// in section 3 below or set them to any UL element from your menu tree(s) in the page source


c_imagesPath = "/Scripts/plugin/menu/"; // path to the directory containing the menu images


c_styles['MM']=[ // MainMenu (the shorter the class name the better)
[
// MENU BOX STYLE
0,		// BorderWidth
'none',	// BorderStyle (CSS valid values except 'none')
'#4880e6', // BorderColor ('color')
0,		// Padding
'#4880e6', // Background ('color','transparent','[image_source]')
'',		// IEfilter (only transition filters work well - not static filters)
'width:150px;'		// Custom additional CSS for the menu box (valid CSS)
],[
// MENU ITEMS STYLE
1,		// BorderWidth
'solid',	// BorderStyle (CSS valid values except 'none')
'solid',	// OVER BorderStyle
'#4880e6', // BorderColor ('color')
'#4880e6', // OVER BorderColor
5,		// Padding
'#b8cdf5', // Background ('color','transparent','[image_source]')
'#4880e6', // OVER Background
'#103478', // Color
'white', // OVER Color
'9pt',		// FontSize (values in CSS valid units - %,em,ex,px,pt)
'tahoma',	// FontFamily
'normal',		// FontWeight (CSS valid values - 'bold','normal','bolder','lighter','100',...,'900')
'none',		// TextDecoration (CSS valid values - 'none','underline','overline','line-through')
'none',		// OVER TextDecoration
'right',		// TextAlign ('left','center','right','justify')
1,		// ItemsSeparatorSize
'solid',	// ItemsSeparatorStyle (border-style valid values)
'white',	// ItemsSeparatorColor ('color','transparent')
0,		// ItemsSeparatorSpacing
true,			// UseSubMenuImage (true,false)
'[v_arrow_left.gif]',	// SubMenuImageSource ('[image_source]')
'[v_arrow_left_over.gif]',	// OverSubMenuImageSource
7,			// SubMenuImageWidth
7,			// SubMenuImageHeight
'10',			// SubMenuImageVAlign ('pixels from item top','middle')
'solid',		// VISITED BorderStyle
'#4880e6', 	// VISITED BorderColor
'#b8cdf5', 	// VISITED Background
'#103478', 	// VISITED Color
'none',			// VISITED TextDecoration
'[v_arrow_left.gif]',	// VISITED SubMenuImageSource
'solid',		// CURRENT BorderStyle
'#4880e6', 	// CURRENT BorderColor
'#4880e6', 	// CURRENT Background
'white', 	// CURRENT Color
'none',			// CURRENT TextDecoration
'[v_arrow_left.gif]',	// CURRENT SubMenuImageSource
'height:15px',		// Custom additional CSS for the items (valid CSS)
'height:15px',		// OVER Custom additional CSS for the items (valid CSS)
'height:15px',		// CURRENT Custom additional CSS for the items (valid CSS)
'height:15px'		// VISITED Custom additional CSS for the items (valid CSS)
]];


c_styles['SM']=[ // SubMenus
[
// MENU BOX STYLE
1,		// BorderWidth
'solid',	// BorderStyle (CSS valid values except 'none')
'#4880e6', // BorderColor ('color')
2,		// Padding
'#b8cdf5', // Background ('color','transparent','[image_source]')
'',		// IEfilter (only transition filters work well - not static filters)
''		// Custom additional CSS for the menu box (valid CSS)
],[
// MENU ITEMS STYLE
1, 	// BorderWidth
'solid', // BorderStyle (CSS valid values except 'none')
'solid', // OVER BorderStyle
'#4880e6', // BorderColor ('color')
'#4880e6', // OVER BorderColor
5, 	// Padding
'#b8cdf5', // Background ('color','transparent','[image_source]')
'#4880e6', // OVER Background
'#103478', // Color
'white', // OVER Color
'9pt', 	// FontSize (values in CSS valid units - %,em,ex,px,pt)
'tahoma', // FontFamily
'normal', 	// FontWeight (CSS valid values - 'bold','normal','bolder','lighter','100',...,'900')
'none', 	// TextDecoration (CSS valid values - 'none','underline','overline','line-through')
'none', 	// OVER TextDecoration
'right', 	// TextAlign ('left','center','right','justify')
1, 	// ItemsSeparatorSize
'solid', // ItemsSeparatorStyle (border-style valid values)
'white', // ItemsSeparatorColor ('color','transparent')
0, 	// ItemsSeparatorSpacing
true, 		// UseSubMenuImage (true,false)
'[v_arrow_left.gif]', // SubMenuImageSource ('[image_source]')
'[v_arrow_left_over.gif]', // OverSubMenuImageSource
7, 		// SubMenuImageWidth
7, 		// SubMenuImageHeight
'10', 		// SubMenuImageVAlign ('pixels from item top','middle')
'solid', 	// VISITED BorderStyle
'#4880e6', 	// VISITED BorderColor
'#b8cdf5', 	// VISITED Background
'#103478', 	// VISITED Color
'none', 		// VISITED TextDecoration
'[v_arrow_left.gif]', // VISITED SubMenuImageSource
'solid', 	// CURRENT BorderStyle
'#4880e6', 	// CURRENT BorderColor
'#4880e6', 	// CURRENT Background
'white', 	// CURRENT Color
'none', 		// CURRENT TextDecoration
'[v_arrow_left.gif]', // CURRENT SubMenuImageSource
'height:15px', 	// Custom additional CSS for the items (valid CSS)
'height:15px', 	// OVER Custom additional CSS for the items (valid CSS)
'height:15px', 	// CURRENT Custom additional CSS for the items (valid CSS)
'height:15px'		// VISITED Custom additional CSS for the items (valid CSS)
]];




/******************************************************
	(3) MENU TREE FEATURES
*******************************************************/

// Normally you would probably have just one menu tree (i.e. one main menu with sub menus).
// But you are actually not limited to just one and you can have as many menu trees as you like.
// Just copy/paste a config block below and configure it for another UL element if you like.

c_menus['Menu1']=[ // the UL element with id="Menu1"
[
// MAIN-MENU FEATURES
'vertical',	// ItemsArrangement ('vertical','horizontal')
'', // Position ('relative','absolute','fixed')
'',		// X Position (values in CSS valid units- px,em,ex)
'',		// Y Position (values in CSS valid units- px,em,ex)
true,		// RightToLeft display of the sub menus
false,		// BottomToTop display of the sub menus
5,		// X SubMenuOffset (pixels)
1,		// Y SubMenuOffset
'150px',		// Width (values in CSS valid units - px,em,ex) (matters for main menu with 'vertical' ItemsArrangement only)
'MM',		// CSS Class (one of the defined in section 2)
false		// Open sub-menus onclick (default is onmouseover)
],[
// SUB-MENUS FEATURES
5,		// X SubMenuOffset (pixels)
1,		// Y SubMenuOffset
'auto',		// Width ('auto',values in CSS valid units - px,em,ex)
'100',		// MinWidth ('pixels') (matters/useful if Width is set 'auto')
'300',		// MaxWidth ('pixels') (matters/useful if Width is set 'auto')
'SM',		// CSS Class (one of the defined in section 2)
false		// Open sub-menus onclick (default is onmouseover)
]];

var menubuilder = function(TagHolder, MenuId, MenuCssClass) {
    var basecontent = '<div><ul id="' + MenuId + '" class="' + MenuCssClass + '"></ul></div>';
    $(document).ready(function() {
        $("#" + TagHolder).html(basecontent);
    });
    return {
        config: {
            TagHolder: TagHolder,
            MenuId: MenuId,
            MenuCssClass: MenuCssClass
        },
        AddChild: function(id, master, name, url, cssclass) {
            var menuli = '<li id="node_' + id + '"><a></a></li>';
            if (master) {
                if ($("#masternode_" + master).length > 0) {
                    $("#masternode_" + master).append(menuli);
                } else {
                    $("li#node_" + master).append('<ul id="masternode_' + master + '">' + menuli + '</ul>');
                };
            } else {
                $("#" + this.config.MenuId).append(menuli);
            };
            var anode = $("#node_" + id + " a");
            anode.html(name);
            if (cssclass) {
                anode.attr("class", cssclass);
            };
            if (url) {
                anode.attr("href", url);
            };
        }
    };
};
/*
========================================
 Fade Animation v1.0
 Add-on for SmartMenus v6.0+
========================================
 (c)2007 ET VADIKOM-VASIL DINKOV
========================================
*/


c_fade_duration=200; // 1000==1 second


// ===
c_fxF={};if(c_iE)c_fade_duration*=1.8;c_fxF.o=!c_gC||c_pS>=20040616?"opacity":"MozOpacity";c_fxF.k=(!c_iEM&&!c_iEW5&&!c_kN&&(!c_gC||c_pS>=20020530)&&(!c_oP||c_oP9)&&(!c_sF||parseFloat(c_a.replace(/.*bkit\//,""))>=400));c_fxF.b=[];c_fxF.O=function(u){if(!u.FX){var i=0,U,US=c_gT(u,"ul");for(;i<US.length;){U=US[i++];U.style.display="none";U.FX=1}u.FX=1}this.s=u.style;this.i=1000/c_fade_duration;this.c=0;this.s[c_fxF.o]="0"};c_fxF.O.prototype.S=function(i){this.c=this.c+this.i;if(this.c+this.i>=100){if(c_gC)this.s[c_fxF.o]=0.99999;else if(this.s.removeProperty)this.s.removeProperty("opacity");else this.s.opacity=1;delete c_fxF.b[i];return}this.s[c_fxF.o]=this.c/100;setTimeout("c_fxF.b["+i+"].S("+i+")",10)};c_fxF.sH=c_sH;c_sH=function(u){if(c_fxF.k){if(c_iE){if(typeof u.filters!="unknown"&&(u.filters||"").length==0)u.style.filter="progid:DXImageTransform.Microsoft.Fade(duration="+(c_fade_duration/1000)+")"}else{var i=0;while(c_fxF.b[i]!=null)i++;c_fxF.b[i]=new c_fxF.O(u)}}c_fxF.sH(u);if(c_fxF.k&&!c_iE)c_fxF.b[i].S(i)}
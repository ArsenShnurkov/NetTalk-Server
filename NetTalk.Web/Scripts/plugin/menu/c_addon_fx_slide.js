/*
========================================
 Slide Animation v1.0.2
 Add-on for SmartMenus v6.0.3+
========================================
 (c)2009 ET VADIKOM-VASIL DINKOV
========================================
*/


c_slide_steps=8;
c_slide_speedGain=0.5; // with each step (pixels)


// ===
c_fxS={};if(c_nS){c_fxS.t="marginTop";c_fxS.l="marginLeft"}else{c_fxS.t="top";c_fxS.l="left"};c_fxS.k=(!c_iEM&&(!c_gC||c_pS>=20020530)&&(!c_oP||c_oPv>=7.5));c_fxS.b=[];c_fxS.O=function(u){if(!u.FX){var i=0,U,US=c_gT(u,"ul");for(;i<US.length;){U=US[i++];U.style.display="none";U.FX=1}u.FX=1}this.u=u;this.s=u.style;this.v=(u.HR&&u.LV==2||u.PP&&u.LV==1);this.P=this.v?u.PP&&u.LV==1?"top":c_fxS.t:c_fxS.l;this.r=(this.v&&u.BT||!this.v&&parseInt(this.s[this.P])<0);this.p=parseInt(this.s[this.P]);this.d=u[this.v?"offsetHeight":"offsetWidth"];if(this.d<c_slide_steps)this.d=c_slide_steps;this.i=this.d/c_slide_steps;this.c=0;this.s.clip="rect(0,0,0,0)"};c_fxS.O.prototype.S=function(i){if(typeof c_shadow_offset!=c_u&&!this.H)try{this.H=c_fxH.s(this.u).style}catch(e){};this.i+=c_slide_speedGain;this.c=parseInt(this.c+this.i);if(this.c>=this.d){this.s[this.P]=this.p+"px";if(this.s.removeProperty&&!c_gCo){this.s.removeProperty("clip");if(this.H)this.H.removeProperty("clip")}else{this.s.clip=c_iE8?"inherit":"rect(auto,auto,auto,auto)";if(this.H)this.H.clip="rect(auto,auto,auto,auto)"}delete c_fxS.b[i];return}this.s[this.P]=this.p+(this.r?this.d-this.c:-this.d+this.c)+"px";if(!this.t&&c_gC){this.s.display="none";this.s.display="block"}this.s.clip="rect("+(this.v&&!this.r?this.d-this.c:"0")+"px,"+(!this.v&&this.r?this.c:"99999")+"px,"+(this.v&&this.r?this.c:"99999")+"px,"+(!this.v&&!this.r?this.d-this.c:"0")+"px)";if(this.H)this.H.clip="rect("+(this.v&&this.r?this.d-this.c:"0")+"px,"+(!this.v&&!this.r?this.c:"99999")+"px,"+(this.v&&!this.r?this.c:"99999")+"px,"+(!this.v&&this.r?this.d-this.c:"0")+"px)";this.t=setTimeout("c_fxS.b["+i+"].S("+i+")",10)};c_fxS.sH=c_sH;c_sH=function(u){if(c_fxS.k){var i=0;while(c_fxS.b[i]!=null)i++;c_fxS.b[i]=new c_fxS.O(u)}c_fxS.sH(u);if(c_fxS.k)c_fxS.b[i].S(i)}
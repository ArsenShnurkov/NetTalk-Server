using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace System.Web
{
    public partial class UIControls
    {
        public class UIGridUrlParam
        {
            public string Edit { get; set; }
            public string Insert { get; set; }
            public string Delete { get; set; }
            public string List { get; set; }
        }

        public class UIGridMenu
        {
            public string Action { get; set; }
            public string CssClass { get; set; }
            public string Text { get; set; }

            public string ToHtml(string baseId)
            {
                return "{" + string.Format("text: '{0}', link: \"javascript:" + baseId + ".doAction('{1}')\", cssClass: '{2}'", Text, Action, CssClass) + "}";
            }
        }

        public class UIGridMenuList : List<UIGridMenu>
        {
            public string ToHtml(string baseId)
            {
                List<string> result = new List<string>();
                foreach (UIGridMenu mnu in this)
                {
                    result.Add(mnu.ToHtml(baseId));
                }
                return "[" + string.Join(",", result.ToArray()) + "]";
            }

            public UIGridMenuList Add(string Text, string Action, string CssClass)
            {
                this.Add(new UIGridMenu { Text = Text, Action = Action, CssClass = CssClass });
                return this;
            }
        }

        public class UIGridCommand
        {
            public string Param { get; set; }
            public bool Enable { get; set; }
        }

        public class UIGridCommandCollection
        {
            public UIGridCommand View { get; set; }
            public UIGridCommand Edit { get; set; }
            public UIGridCommand Delete { get; set; }
            public UIGridCommand Insert { get; set; }

            public UIGridCommandCollection()
            {
                Edit = new UIGridCommand();
                Delete = new UIGridCommand();
                Insert = new UIGridCommand();
                View = new UIGridCommand();
            }
        }

        public class UIGridEvents
        {
            public string Select { get; set; }
            public string BeforeAjax { get; set; }
            public string AfterAjax { get; set; }
            public string AfterRender { get; set; }
            public string OnEdit { get; set; }
            public string OnDelete { get; set; }
            public string OnSort { get; set; }
            public string OnAction { get; set; }
        }

        public class UIGridOption
        {
            public bool AutoSecurity { get; set; }
            public bool? AutoLoad { get; set; }
            public bool AutoTitle { get; set; }

            private bool IsGetSecurity { get; set; }
            public void GetSecurity()
            {
                if (!IsGetSecurity)
                {
                   // not implemented
                    this.Commands.Delete.Enable = true;
                    this.Commands.Edit.Enable = true;
                    this.Commands.Insert.Enable = true;
                    this.Commands.View.Enable = true;
                }
            }

            public bool? EnablePager { get; set; }
            public bool? EnableScroll { get; set; }
            public bool? EnalbeCheckbox { get; set; }

            public bool? AutoWidth { get; set; }
            public bool? AutoHeight { get; set; }

            public bool? InsideTab { get; set; }
            public string Width { get; set; }
            public string Height { get; set; }
            public string Title { get; set; }

            public string[] PagerSize { get; set; }
            public string SelectedPagerSize { get; set; }

            public string Controller { get; set; }
            public string SecurityResource { get; set; }
            public UIGridCommandCollection Commands { get; set; }
            public UIGridEvents Events { get; set; }

            public string BaseId { get; set; }
            public UIGridUrlParam UrlParam { get; set; }
            public UIGridMenuList Menus { get; set; }

            public UIGridOption()
            {
                AutoSecurity = true;
                Commands = new UIGridCommandCollection();
                Events = new UIGridEvents();
                UrlParam = new UIGridUrlParam();
                Menus = new UIGridMenuList();
                AutoTitle = true;
            }
        }

        public static string UIGrid(UIGridOption Config)
        {
            string HtmlResult = "";
            bool CanRender = true;

            if (string.IsNullOrEmpty(Config.SecurityResource))
                Config.SecurityResource = Config.Controller;

            if (Config.AutoSecurity)
            {
                Config.GetSecurity();
                CanRender = Config.Commands.View.Enable;
            }

            if (CanRender)
            {
                List<string> Master = new List<string>();
                List<string> Other = new List<string>();

                Master.Add("id:'" + Config.BaseId + "'");
                Master.Add("url:'/" + Config.Controller + "'");

                if (!string.IsNullOrEmpty(Config.Title))
                    Master.Add("title:'" + Config.Title + "'");
                else if (Config.AutoTitle)
                {
                   //
                }

                if (!string.IsNullOrEmpty(Config.UrlParam.Delete))
                    Other.Add("del:'" + Config.UrlParam.Delete + "'");
                if (!string.IsNullOrEmpty(Config.UrlParam.Edit))
                    Other.Add("edit:'" + Config.UrlParam.Edit + "'");
                if (!string.IsNullOrEmpty(Config.UrlParam.Insert))
                    Other.Add("insert:'" + Config.UrlParam.Insert + "'");
                if (!string.IsNullOrEmpty(Config.UrlParam.List))
                    Other.Add("list:'" + Config.UrlParam.List + "'");

                if (Other.Count > 0)
                    Master.Add("urlparam:{" + string.Join(",", Other.ToArray()) + "}");

                Master.Add("menus:" + Config.Menus.ToHtml(Config.BaseId));

                Other = new List<string>();
                if (Config.EnablePager.HasValue)
                    Other.Add("enable:" + Config.EnablePager.Value.ToJs());
                if (Config.PagerSize != null)
                    Other.Add("size:[" + string.Join(",", Config.PagerSize) + "]");

                if (Other.Count > 0)
                    Master.Add("pager: {" + string.Join(",", Other.ToArray()) + "}");

                if (Config.EnableScroll.HasValue)
                    Master.Add("showScroll:" + Config.EnableScroll.Value.ToJs());
                if (Config.AutoWidth.HasValue)
                    Master.Add("autoWidth:" + Config.AutoWidth.Value.ToJs());
                if (Config.AutoHeight.HasValue)
                    Master.Add("autoHeight:" + Config.AutoHeight.Value.ToJs());
                if (Config.InsideTab.HasValue)
                    Master.Add("insidetab:" + Config.InsideTab.Value.ToJs());
                if (Config.EnalbeCheckbox.HasValue)
                    Master.Add("addCheckbox:" + Config.EnalbeCheckbox.Value.ToJs());
                if (Config.AutoLoad.HasValue)
                    Master.Add("autoLoad:" + Config.AutoLoad.Value.ToJs());

                Other = new List<string>();
                if (!string.IsNullOrEmpty(Config.Width))
                    Other.Add("width:" + Config.Width);
                if (!string.IsNullOrEmpty(Config.Height))
                    Other.Add("height:" + Config.Height);
                if (Other.Count > 0)
                    Master.Add("style: {" + string.Join(",", Other.ToArray()) + "}");

                if (Config.Commands.Edit.Enable)
                {
                    Other = new List<string>();
                    Other.Add("enable:true");
                    if (!string.IsNullOrEmpty(Config.Commands.Edit.Param))
                        Other.Add("param:" + Config.Commands.Edit.Param);

                    Master.Add("edit:{" + string.Join(",", Other.ToArray()) + "}");
                }
                if (Config.Commands.Delete.Enable)
                {
                    Other = new List<string>();
                    Other.Add("enable:true");
                    if (!string.IsNullOrEmpty(Config.Commands.Delete.Param))
                        Other.Add("param:" + Config.Commands.Delete.Param);

                    Master.Add("del:{" + string.Join(",", Other.ToArray()) + "}");
                }
                if (Config.Commands.Insert.Enable)
                {
                    Other = new List<string>();
                    Other.Add("enable:true");
                    if (!string.IsNullOrEmpty(Config.Commands.Insert.Param))
                        Other.Add("param:" + Config.Commands.Insert.Param);

                    Master.Add("insert:{" + string.Join(",", Other.ToArray()) + "}");
                }

                if (!string.IsNullOrEmpty(Config.Events.AfterAjax))
                    Master.Add("afterAjax:" + Config.Events.AfterAjax);
                if (!string.IsNullOrEmpty(Config.Events.AfterRender))
                    Master.Add("afterRender:" + Config.Events.AfterRender);
                if (!string.IsNullOrEmpty(Config.Events.BeforeAjax))
                    Master.Add("beforeAjax:" + Config.Events.BeforeAjax);
                if (!string.IsNullOrEmpty(Config.Events.OnAction))
                    Master.Add("onAction:" + Config.Events.OnAction);
                if (!string.IsNullOrEmpty(Config.Events.OnDelete))
                    Master.Add("onDelete:" + Config.Events.OnDelete);
                if (!string.IsNullOrEmpty(Config.Events.OnEdit))
                    Master.Add("onEdit:" + Config.Events.OnEdit);
                if (!string.IsNullOrEmpty(Config.Events.OnSort))
                    Master.Add("onSort:" + Config.Events.OnSort);
                if (!string.IsNullOrEmpty(Config.Events.Select))
                    Master.Add("select:" + Config.Events.Select);


                HtmlResult = ScriptBegin;
                HtmlResult += "var " + Config.BaseId + " = new htmlgrid(\"" + Config.BaseId + "\", {\r\n";
                HtmlResult += string.Join(",", Master.ToArray()) + "\r\n";
                HtmlResult += "});" + Config.BaseId + ".html();" + ScriptEnd;
            }

            return HtmlResult;
        }
    }
}
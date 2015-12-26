using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;

namespace System.Web.Mvc
{
    public partial class UIControls
    {
        public class MenuItem
        {
            public string Id { get; set; }
            public string CssClass { get; set; }
            public string MasterId { get; set; }
            public string Url { get; set; }
            public string Text { get; set; }

            public override string ToString()
            {
                return string.Format("AddChild('{0}','{1}','{2}','{3}','{4}')", Id, MasterId, Text, Url, CssClass);
            }
        }

        public class MenuItemCollection : List<MenuItem> { }

        public class Menus
        {
            public string HolderId { get; set; }
            public string MenuId { get; set; }
            public string MenuCssClass { get; set; }
            public MenuItemCollection MenuItems { get; set; }

            public object Data { get; set; }

            public string IdField { get; set; }
            public string MasterIdField { get; set; }
            public string TextField { get; set; }
            public string CssClassField { get; set; }
            public string UrlField { get; set; }

            public Menus()
            {
                MenuItems = new MenuItemCollection();
                MenuCssClass = "MM";
                MenuId = "Menu1";
                HolderId = "Div" + (new Random()).Next();
            }

            public delegate MenuItem RenderMenuItem(System.Web.Html.DataBindRow RowData, MenuItem CurrentNode);
            public event RenderMenuItem OnRenderMenuItem;

            public string ToHtml()
            {
                string result = "<div id=\"" + HolderId + "\"></div>";
                result += "\r\n<script type=\"text/javascript\">\r\n";
                result += "$(document).ready(function(){ var " + MenuId + " = new menubuilder('" + HolderId + "','" + MenuId + "','" + MenuCssClass + "');";

                if (Data != null)
                {
                    var dt = (IEnumerable)Data;
                    MenuItem n;
                    foreach (var item in dt)
                    {
                        System.Web.Html.DataBindRow row = new System.Web.Html.DataBindRow( item);

                        n = new MenuItem();
                        n.Id = row[IdField].ToString();
                        if (row[MasterIdField] == null)
                            n.MasterId = null;
                        else
                            n.MasterId = row[MasterIdField].ToString();
                        n.Text = row[TextField].ToString();

                        if (!string.IsNullOrEmpty(UrlField))
                            if (row[UrlField] != null)
                                n.Url = row[UrlField].ToString();

                        if (!string.IsNullOrEmpty(CssClassField))
                            if (row[CssClassField] != null)
                                n.CssClass = row[CssClassField].ToString();                        

                        //NodeList.Add(n);
                        if (OnRenderMenuItem != null)
                        {
                            n = OnRenderMenuItem(row, n);
                        }
                        result += MenuId + "." + n.ToString() + ";";
                    }
                }
                result += "});</script>";
                return result;
            }
        }
    }
}

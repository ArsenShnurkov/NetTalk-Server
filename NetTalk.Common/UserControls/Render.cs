using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Text.RegularExpressions;

namespace NetTalk.Common.UserControls
{
    public class NetTalkRender
    {
        private static string cleanHtml(string html)
        {
            html = Regex.Replace(html, @"<[/]?(form)[^>]*?>", string.Empty, RegexOptions.IgnoreCase);
            return Regex.Replace(html, "<input type=\"hidden\" name=\"__VIEWSTATE\" id=\"__VIEWSTATE\" value=\"[a-zA-Z0-9+_\\\\=/]+\" />", string.Empty, RegexOptions.IgnoreCase);
        }

        public static string RenderUserControl(string path, List<KeyValuePair<string, object>> properties)
        {
            Page pageHolder = new Page();
            UserControl viewControl = (UserControl)pageHolder.LoadControl(path);
            viewControl.EnableViewState = false;
            Type viewControlType = viewControl.GetType();
            foreach (var pair in properties)
            {
                PropertyInfo property = viewControlType.GetProperty(pair.Key);
                if (property != null)
                {
                    property.SetValue(viewControl, pair.Value, null);
                }
            }
            HtmlForm f = new HtmlForm();

            f.Controls.Add(viewControl);

            pageHolder.Controls.Add(f);
            StringWriter output = new StringWriter();
            HttpContext.Current.Server.Execute(pageHolder, output, false);
            return cleanHtml(output.ToString());
        }
    }
}

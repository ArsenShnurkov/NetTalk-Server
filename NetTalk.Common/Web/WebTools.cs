using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetTalk.Common.Web
{
    public class NetTalkWebTools
    {
        public static string SiteRoot()
        {
            HttpRequest Request = HttpContext.Current.Request;
            return Request.Url.Scheme + "://" + Request.Url.Authority + Request.ApplicationPath.TrimEnd('/') + '/';
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Web.Security;

namespace NetTalk.Web.Login
{
    /// <summary>
    /// Summary description for Logout
    /// </summary>
    public class Logout : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            FormsAuthentication.SignOut();


            context.Response.Redirect("~/default.aspx");
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
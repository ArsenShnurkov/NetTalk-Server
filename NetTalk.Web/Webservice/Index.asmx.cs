using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace NetTalk.Web.Webservice
{
    /// <summary>
    /// Summary description for Index
    /// </summary>
    [WebService(Namespace = "http://nettalk.ir/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class Index : System.Web.Services.WebService
    {
        public class ServiceResult
        {
            public bool IsSuccess { get; set; }
            public string Error { get; set; }
            public string Message { get; set; }

            public ServiceResult()
            {
                IsSuccess = false;
                Error = string.Empty;
            }
        }

        [WebMethod]
        public ServiceResult ChangePassword(string username,string oldpass, string newpassword)
        {
            return (new ServiceResult());
        }

        [WebMethod]
        public ServiceResult SendMessage(string fromname, string tousername, string txt, string html, bool sendOffline)
        {
            return (new ServiceResult());
        }

        [WebMethod]
        public ServiceResult IsOnline(string username)
        {
            return (new ServiceResult());
        }
    }
}

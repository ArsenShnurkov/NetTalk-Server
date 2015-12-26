using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NetTalk.Web
{
    public class LogTools
    {
        private static BLL.Log _api;
        private static BLL.Log Api
        {
            get
            {
                if (_api == null)
                    _api = new BLL.Log();
                return _api;
            }
        }

        public static void Write(string SID, Exception ex, string info)
        {
            if (ex != null)
            {
                string Txt = "<error><info>" + info + "</info><main>" + HttpUtility.HtmlEncode(ex.Message) + "</main>";
                if (ex.InnerException != null)
                {
                    Txt += "<sub>" + HttpUtility.HtmlEncode(ex.InnerException.Message) + "</sub>";
                }
                Txt += "</error>";
                Write(SID, Txt);
            }
        }

        public static void Write(string SID, string txt)
        {
            int index;
            if (Codes.ThreadTools.Users.Online.IsSessionExists(SID, out index))
            {
                Guid? UserId = null;
                if (!string.IsNullOrEmpty(Codes.ThreadTools.Users.Online[index].Username))
                {
                    BLL.Users api = new BLL.Users();
                    DAL.TbUsers user = api.Find(Codes.ThreadTools.Users.Online[index].Username);
                    if (user != null)
                    {
                        UserId = user.UserId;
                    }
                }

                Api.Insert(Codes.ThreadTools.Users.Online[index].IPAddress,
                    SID, UserId, txt);
            }
            else
                Api.Insert(null, null, null, txt);
        }
    }
}
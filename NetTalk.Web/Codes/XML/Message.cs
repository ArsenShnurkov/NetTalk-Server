using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using agsXMPP.protocol;
using agsXMPP.protocol.stream;

using agsXMPP.protocol.iq;
using agsXMPP.protocol.iq.auth;
using agsXMPP.protocol.iq.last;
using agsXMPP.protocol.iq.roster;
using agsXMPP.protocol.iq.vcard;
using agsXMPP.protocol.iq.register;
using agsXMPP.protocol.x.data;
using agsXMPP.protocol.extensions.html;

using agsXMPP.protocol.client;
using agsXMPP.protocol.x;
using agsXMPP.protocol.extensions.ping;
using agsXMPP.protocol.extensions.pubsub;
using agsXMPP.protocol.extensions.pubsub.@event;


using agsXMPP.Xml;
using agsXMPP.Xml.Dom;
using System.Text;

namespace NetTalk.Web.Codes.XML
{
    public class Messages
    {
        public static void setTagContent(ref string body, string tag, string tagBody)
        {
            int findex = body.IndexOf("<" + tag + ">");
            if (findex > -1)
            {
                findex += tag.Length + 2;
                int eindex = body.IndexOf("</" + tag + ">");
                if (eindex > -1)
                {
                    int len = eindex - findex;
                    body = body.Replace(body.Substring(findex, len), tagBody);
                }
            }
        }

        public static string Create(string fromuser, string touser, string text, string html, DateTime? DelayTime)
        {
            Message msg = new Message();
            string msgText = "";

            if (!string.IsNullOrEmpty(fromuser))
            {
                if (fromuser != Config.AppSetting.domain)
                    msg.From = new agsXMPP.Jid(fromuser + "@" + Config.AppSetting.domain);
                else
                    msg.From = new agsXMPP.Jid(fromuser);
            }

            if (!string.IsNullOrEmpty(touser))
                msg.To = new agsXMPP.Jid(touser + "@" + Config.AppSetting.domain);

            msg.Body = text;

            if (DelayTime.HasValue)
            {
                Element el = new Element("delay");
                el.Attributes.Add("stamp", DelayTime.Value.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ"));
                el.Attributes.Add("from", Config.AppSetting.domain);
                el.Namespace = "urn:xmpp:delay";
                msg.AddChild(el);
            }

            if (!string.IsNullOrEmpty(html))
            {
                msg.Html = new agsXMPP.protocol.extensions.html.Html();
                msg.Html.Body = new agsXMPP.protocol.extensions.html.Body();
                msg.Html.Body.AddChild(new Element("div", "nbsp"));
                msgText = msg.ToString();
                setTagContent(ref msgText, "div", html);
            }
            else
                msgText = msg.ToString();

            return msgText;
        }

        public static string OfflineMessage(string username)
        {
            NetTalk.BLL.Message MsgApi = new NetTalk.BLL.Message();
            List<NetTalk.DAL.TbMessage> MsgList = MsgApi.ListOffline(username);

            if (MsgList.Count > 0)
            {
                string result = "";
                foreach (NetTalk.DAL.TbMessage msg in MsgList)
                {
                    result += Create(msg.TbUsers1.Username, username, msg.MessageText, msg.MessageHTML, msg.MessageDate);
                }
                return result;
            }
            else
                return string.Empty;
        }

        public static string LastActivity(string fromuser, string touser)
        {
            IQ iq = new IQ();
            iq.From = new agsXMPP.Jid(touser + "@" + Config.AppSetting.domain);
            iq.To = new agsXMPP.Jid(fromuser + "@" + Config.AppSetting.domain);
            Last lt = new Last();

            NetTalk.BLL.Users ApiUser = new NetTalk.BLL.Users();
            DateTime dt = ApiUser.LastActivity(touser);
            TimeSpan sp = DateTime.Now - dt;

            lt.Seconds = Convert.ToInt32(Math.Ceiling(sp.TotalSeconds));
            iq.Type = IqType.result;
            iq.Query = lt;

            return iq.ToString();
        }

        public static void SendAlerts(int time)
        {
            NetTalk.BLL.Alert Api = new NetTalk.BLL.Alert();
            List<NetTalk.DAL.TbAlerts> result = Api.ListFromTime(time);
            if (result.Count > 0)
            {
                string text = "";
                string html = "";
                foreach (NetTalk.DAL.TbAlerts alert in result)
                {
                    text += alert.AlertText + "\r\n";
                    html += "<p>" + alert.AlertHTML + "</p>";
                }
                foreach (ThreadTools.Connection con in ThreadTools.Users.Online)
                {
                    if (con.IsConnected && con.Authenticated)
                    {
                        con.Send(Create(Config.AppSetting.domain, con.Username, text, html, null));
                    }
                }
            }
        }

        public static void SendMessage(string fromuser, Message msg)
        {
            string text = null, html = null;
            if (msg.Html != null)
                if (msg.Html.Body != null)
                    if (!string.IsNullOrEmpty(msg.Html.Body.InnerHtml))
                        html = msg.Html.Body.InnerHtml;

            if (!string.IsNullOrEmpty(msg.Body))
                text = msg.Body;

            int cindex = -1;
            if (msg.To != null)
                ThreadTools.Users.Online.IsAuthenticated(msg.To.User, out cindex);

            if (cindex > -1)
                ThreadTools.Users.Online[cindex].Send(msg);

            if (!string.IsNullOrEmpty(text))
            {
                int findex;
                ThreadTools.Users.Online.IsAuthenticated(fromuser, out findex);

                NetTalk.BLL.Message api = new NetTalk.BLL.Message();
                api.Insert(fromuser, msg.To.User, text, html, ThreadTools.Users.Online[findex].IPAddress, (cindex > -1));
            }
        }

        public static void SendInfo(string fromuser, string touser)
        {
            int FromUserIndex;
            ThreadTools.Users.Online.IsAuthenticated(fromuser, out FromUserIndex);

            NetTalk.BLL.Users apiusers = new NetTalk.BLL.Users();
            NetTalk.DAL.TbUsers user = apiusers.Find(touser);
            if (user != null)
            {
                string CardDataHtml = "<p>", CardDataText = "";

                
                if (user.TbVcard != null)
                {
                    if (!string.IsNullOrEmpty(user.TbVcard.VcardEmail))
                    {
                        CardDataHtml += "ایمیل: " + user.TbVcard.VcardEmail + "<br />";
                        CardDataText += "ایمیل: " + user.TbVcard.VcardEmail + ",";
                    }
                    if (!string.IsNullOrEmpty(user.TbVcard.VcardTelFax))
                    {
                        CardDataHtml += "فکس: " + user.TbVcard.VcardTelFax + "<br />";
                        CardDataText += "فکس: " + user.TbVcard.VcardTelFax + ",";
                    }
                    if (!string.IsNullOrEmpty(user.TbVcard.VcardTelCell))
                    {
                        CardDataHtml += "موبایل: " + user.TbVcard.VcardTelCell + "<br />";
                        CardDataText += "موبایل: " + user.TbVcard.VcardTelCell + ",";
                    }
                    if (!string.IsNullOrEmpty(user.TbVcard.VcardTelVoice))
                    {
                        CardDataHtml += "داخلی: " + user.TbVcard.VcardTelVoice + "<br />";
                        CardDataText += "داخلی: " + user.TbVcard.VcardTelVoice + ",";
                    }
                    if (!string.IsNullOrEmpty(user.TbVcard.VcardTelVoice2))
                    {
                        CardDataHtml += "مستقیم: " + user.TbVcard.VcardTelVoice2 + "<br />";
                        CardDataText += "مستقیم: " + user.TbVcard.VcardTelVoice2 + ",";
                    }
                }
                CardDataHtml += "</p>";

                ThreadTools.Users.Online[FromUserIndex].Send(
                    XML.Messages.Create(touser, fromuser, CardDataText, CardDataHtml, null));
            }
        }
    }
}
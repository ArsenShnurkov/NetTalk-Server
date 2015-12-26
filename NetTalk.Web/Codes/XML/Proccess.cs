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

namespace NetTalk.Web.Codes.XML
{
    public class Proccess
    {
        public static void Messages(string sid, string username, Message msg)
        {
            string TextBody = string.Empty;
            try
            {
                if (!string.IsNullOrEmpty(msg.Body))
                    TextBody = msg.Body;

                if (msg.To != null)
                {
                    if (!string.IsNullOrEmpty(msg.To.User))
                    {
                        if (TextBody == "info")
                        {
                            XML.Messages.SendInfo(username, msg.To.User);
                        }
                        else
                        {
                            XML.Messages.SendMessage(username, msg);
                        }
                    } 
                }
            }
            catch (Exception ex)
            {
                LogTools.Write(sid, ex, "Proccess.Messages");
            }
        }

        public static void Presences(string sid, string username, Presence pre)
        {
            try
            {
                if (pre.HasTag("x"))
                {
                    XML.Rosters.GetUserPicture(username, pre);
                }

                string StatusText = string.Empty;
                int UserIndex;
                if (pre.HasAttribute("type"))
                {
                    XML.Rosters.PresenceProccessTypes(username, pre);
                }
                else
                {
                    ShowType show = ShowType.NONE;
                    if (pre.HasTag("show"))
                        show = pre.Show;
                    if (!string.IsNullOrEmpty(pre.Status))
                        StatusText = pre.Status;

                    ThreadTools.Users.Online.IsAuthenticated(username, out UserIndex);
                    if (UserIndex > -1)
                    {
                        ThreadTools.Users.Online[UserIndex].UserStatus = show;
                        ThreadTools.Users.Online[UserIndex].UserStatusText = StatusText;
                    }
                    XML.Rosters.ChangeStatus(username, StatusText, show, (UserIndex > -1));
                    XML.Rosters.SendStatus(username);
                }
            }
            catch (Exception ex)
            {
                LogTools.Write(sid, ex, "Proccess.Presences");
            }
        }

        public static void IQs(string sid, string username, IQ iq)
        {
            try
            {
                string iqId = string.Empty;
                if (iq.HasAttribute("id"))
                {
                    iqId = iq.Id;
                }

                int UserSessionIndex;
                ThreadTools.Users.Online.IsSessionExists(sid, out UserSessionIndex);

                if (ThreadTools.Users.Online[UserSessionIndex].Authenticated)
                    iq.From = new agsXMPP.Jid(username + "@" + Config.AppSetting.domain);

                if (iq.HasTag("ping"))
                {
                    XML.IQs.PingPong(username, UserSessionIndex, iqId);
                }
                else if (iq.HasTag("vCard"))
                {
                    XML.IQs.ProccessVcard(username, UserSessionIndex, iq);
                }
                else if (iq.HasTag("pubsub"))
                {
                    //to do
                }
                else if (iq.Query != null)
                {
                    if (iq.Query.Namespace == "http://jabber.org/protocol/disco#info" && iq.Type == IqType.get)
                    {
                        ThreadTools.Users.Online[UserSessionIndex].Send(XML.Server.features(username , iq));
                    }
                    else if (iq.Query.GetType() == typeof(Auth))
                    {
                         Auth auth = iq.Query as Auth;
                         switch (iq.Type)
                         {
                             case IqType.get:
                                 XML.IQs.ProccessAuthGet(username, UserSessionIndex, iq);
                                 break;
                             case IqType.set:
                                 XML.IQs.ProccessAuthSet(username, sid, UserSessionIndex, iq);
                                 break;
                         }
                    }
                    else if (iq.Query.GetType() == typeof(Register))
                    {
                        XML.IQs.SubmitChangePassForm(username, iq);
                    }
                    else if (iq.Query.GetType() == typeof(Roster))
                    {
                        if (iq.Type == IqType.get)
                            XML.IQs.ProcessRosterIQGet(username, iq);
                        else
                            XML.IQs.ProcessRosterIQSet(username, iq);
                    }
                    else if (iq.Query.GetType() == typeof(Last))
                    {
                        if (iq.Type == IqType.get)
                        {
                            if (iq.To != null)
                            {
                                BLL.Users api = new BLL.Users();
                                iq.SwitchDirection();
                                iq.Type = IqType.result;
                                DateTime d = api.LastActivity(iq.To.User);
                                TimeSpan diff = DateTime.Now - d;
                                Last lt = iq.Query as Last;
                                lt.Seconds = diff.Seconds;
                                ThreadTools.Users.Online[UserSessionIndex].Send(iq);
                            }
                        }
                    }
                    else if (iq.Query.GetType() == typeof(agsXMPP.protocol.iq.version.Version))
                    {
                        iq.SwitchDirection();
                        if (iq.From != null)
                        {
                            ThreadTools.Users.Online[UserSessionIndex].Send(iq);
                        }
                    }
                    else if (iq.Query.Namespace.IndexOf("avatar") > -1)
                    {
                        XML.IQs.Avatar(username, iq);
                    }
                }
            }
            catch (Exception ex)
            {
                LogTools.Write(sid, ex, "Proccess.IQs");
            }
        }
    }
}
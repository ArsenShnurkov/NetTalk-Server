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
    public class Rosters
    {
        public static ShowType GetShowType(short status)
        {
            return (ShowType)status;
        }

        public static Presence GetPresence(string username)
        {
            Presence p = new Presence();
            NetTalk.BLL.Users api = new NetTalk.BLL.Users();
            NetTalk.DAL.TbUsers user = api.Find(username);

            p.Show = GetShowType(user.TbUserStatus.UserStatus);
            p.Type = (user.TbUserStatus.UserIsOnline) ? PresenceType.available : PresenceType.unavailable;
            p.Status = user.TbUserStatus.UserStatusText;

            if (!string.IsNullOrEmpty(user.TbVcard.VcardPhoto))
            {
                Element xtag = new Element("x");
                xtag.Namespace = "vcard-temp:x:update";
                Element photo = new Element("photo");
                photo.Value = user.TbVcard.VcardPhoto;
                xtag.AddChild(photo);
                p.AddChild(xtag);
            }

            return p;
        }

        public static void PresenceProccessTypes(string username, Presence pre)
        {
            NetTalk.BLL.Users api;
            switch (pre.Type)
            {
                case PresenceType.available:
                    ShowType show = ShowType.NONE;
                    string StatusText = string.Empty;
                    if (!string.IsNullOrEmpty(pre.Status))
                        StatusText = pre.Status;
                    if (pre.HasTag("show"))
                        show = pre.Show;

                    int UserIndex;
                    ThreadTools.Users.Online.IsAuthenticated(username, out UserIndex);
                    if (UserIndex > -1)
                    {
                        ThreadTools.Users.Online[UserIndex].UserStatus = show;
                        ThreadTools.Users.Online[UserIndex].UserStatusText = StatusText;
                    }
                    ChangeStatus(username, StatusText, show, (UserIndex > -1));
                    SendStatus(username);

                    break;
                case PresenceType.subscribe:
                    if (pre.To != null)
                    {
                        if (!string.IsNullOrEmpty(pre.To.User))
                        {
                            api = new NetTalk.BLL.Users();
                            NetTalk.DAL.TbFriend f = api.FindFriend(username, pre.To.User);
                            if (f == null)
                            {
                                api.AddFriend(username, pre.To.User, "");
                                int FIndexSubscribe;
                                if (ThreadTools.Users.Online.IsAuthenticated(pre.To.User, out FIndexSubscribe))
                                {
                                    ThreadTools.Users.Online[FIndexSubscribe].Send(pre);
                                }
                            }
                        }
                    }
                    break;
                case PresenceType.subscribed:
                    api = new NetTalk.BLL.Users();
                    if (pre.To != null)
                    {
                        if (!string.IsNullOrEmpty(pre.To.User))
                        {
                            api.ChangeFriendStatus(username, pre.To.User, "", (byte)2);
                            api.ChangeFriendStatus(pre.To.User, username, "", (byte)2);
                            int FUserSub, UserSub;
                            if (ThreadTools.Users.Online.IsAuthenticated(pre.To.User, out FUserSub))
                            {
                                ThreadTools.Users.Online[FUserSub].Send(pre);
                                ThreadTools.Users.Online[FUserSub].Send(GetPresence(username));
                            }
                            if (ThreadTools.Users.Online.IsAuthenticated(username, out UserSub))
                            {
                                ThreadTools.Users.Online[UserSub].Send(GetPresence(pre.To.User));
                            }
                        }
                    }
                    break;
                case PresenceType.unsubscribe:
                case PresenceType.unsubscribed:
                    api = new NetTalk.BLL.Users();
                    if (pre.To != null)
                    {
                        if (!string.IsNullOrEmpty(pre.To.User))
                        {
                            api.DeleteFriend(username, pre.To.User);
                        }
                    }
                    break;
            }
        }

        public static void SendStatus(string username)
        {
            NetTalk.BLL.Users api = new NetTalk.BLL.Users();
            List<NetTalk.DAL.VwFriend> OnlineFriend = api.ListOnlinFriend(username);

            Presence pre = GetPresence(username);
            pre.From = new agsXMPP.Jid(username + "@" + Config.AppSetting.domain);

            int index;
            foreach (NetTalk.DAL.VwFriend f in OnlineFriend)
            {
                if (ThreadTools.Users.Online.IsAuthenticated(f.FriendUserName, out index))
                {
                    pre.To = new agsXMPP.Jid(f.FriendUserName + "@" + Config.AppSetting.domain);
                    ThreadTools.Users.Online[index].Send(pre);
                }
            }
        }

        public static string FriendStatus(string username)
        {
            NetTalk.BLL.Users api = new NetTalk.BLL.Users();
            List<NetTalk.DAL.VwFriend> OnlineFriend = api.ListOnlinFriend(username);

            ShowType userShowType;
            PresenceType userIsOnline;
            Presence p;

            string list = "";
            string userStatusText = "";
            for (int i = 0; i < OnlineFriend.Count; i++)
            {
                userStatusText = OnlineFriend[i].UserStatusText;
                userIsOnline = PresenceType.available;
                userShowType = (ShowType)OnlineFriend[i].UserStatus;

                p = new Presence();
                p.From = new agsXMPP.Jid(OnlineFriend[i].FriendUserName + "@" + Config.AppSetting.domain);
                p.To = new agsXMPP.Jid(username + "@" + Config.AppSetting.domain);
                p.Type = userIsOnline;
                p.Show = userShowType;
                if (!string.IsNullOrEmpty(userStatusText))
                    p.Status = userStatusText;
                if (!string.IsNullOrEmpty(OnlineFriend[i].VcardPhoto))
                {
                    Element xtag = new Element("x");
                    xtag.Namespace = "vcard-temp:x:update";
                    Element photo = new Element("photo");
                    photo.Value = OnlineFriend[i].VcardPhoto;
                    xtag.AddChild(photo);
                    p.AddChild(xtag);
                }

                list += p.ToString();
            }

            return list;
        }

        public static string PendingStatus(string username)
        {
            BLL.Users api = new BLL.Users();
            List<DAL.VwFriend> FList = api.ListPending(username);
            string rme = "";
            if (FList.Count > 0)
            {
                Presence p;
                for (int i = 0; i < FList.Count; i++)
                {
                    p = new Presence();
                    p.Type = PresenceType.subscribe;
                    p.From = new agsXMPP.Jid(FList[i].FriendUserName + "@" + Config.AppSetting.domain);
                    p.To = new agsXMPP.Jid(username + "@" + Config.AppSetting.domain);
                    rme += p.ToString();
                }
            }
            return rme;
        }

        public static void ChangeStatus(string username, string statustext, ShowType show, bool IsOnline)
        {
            NetTalk.BLL.Users api = new NetTalk.BLL.Users();
            api.ChangeUserStatus(username, statustext, (short)show, IsOnline);
        }

        public static void GetUserPicture(string username, Presence pren)
        {
            if (Config.AppSetting.access.changepic)
            {
                Element av = pren.SelectSingleElement("x");
                NetTalk.DAL.TbUsers user;
                NetTalk.BLL.Users api = new NetTalk.BLL.Users();
                user = api.Find(username);
                if (user != null)
                {
                    if (av.HasTag("hash"))
                    {
                        if (user.TbVcard != null)
                        {
                            Element elhash = av.SelectSingleElement("hash");
                            if (!elhash.Value.Equals(user.TbVcard.VcardPhoto))
                            {
                                IQ uav = new IQ();
                                uav.Vcard = new Vcard();
                                uav.Type = IqType.get;
                                int Index;
                                ThreadTools.Users.Online.IsAuthenticated(username, out Index);
                                if (Index > -1)
                                    ThreadTools.Users.Online[Index].Send(uav);
                            }
                        }
                    }
                    else
                    {
                        api.ChangeUserPicture(username, null);
                    }
                }
            }
        }
    }
}
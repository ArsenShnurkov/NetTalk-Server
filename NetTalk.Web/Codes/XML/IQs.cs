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
    public class IQs
    {
        public static IQ SendChangePassForm(string username, string iqId)
        {
            IQ iq = new IQ();
            iq.Id = iqId;
            iq.Type = IqType.error;

            iq.From = new agsXMPP.Jid(Config.AppSetting.domain);
            iq.To = new agsXMPP.Jid(username + "@" + Config.AppSetting.domain);

            Register reg = new Register();
            reg.Data = new Data();
            reg.Data.Title = "Change Password";
            reg.Data.Instructions = "please provide old password and new password";
            reg.Data.Type = XDataFormType.form;

            Field f;

            f = new Field("oldpassword", "Current Password", FieldType.Text_Private);
            f.IsRequired = true;
            reg.Data.AddField(f);

            f = new Field("password", "New Password", FieldType.Text_Private);
            f.IsRequired = true;
            reg.Data.AddField(f);
            iq.Query = reg;
            iq.Error = new agsXMPP.protocol.client.Error(ErrorType.cancel, ErrorCondition.NotAllowed);
            iq.Error.Code = ErrorCode.NotAllowed;

            return iq;
        }

        public static void SubmitChangePassForm(string username, IQ formdata)
        {
            ErrorCondition Error = ErrorCondition.NotAllowed;
            Register reg = formdata.Query as Register;
            if (formdata.Type == IqType.set)
            {
                if (reg.HasTag("x"))
                {
                    if (reg.Data.Type == XDataFormType.submit)
                    {
                        Field oldpass = reg.Data.GetField("oldpassword");
                        Field pass = reg.Data.GetField("password");
                        if (oldpass != null && pass != null)
                        {
                            if (!string.IsNullOrEmpty(oldpass.Value) && !string.IsNullOrEmpty(pass.Value))
                            {
                                NetTalk.BLL.Users api = new NetTalk.BLL.Users();
                                NetTalk.BLL.BLLResult result = api.ChangePassword(username, oldpass.Value, pass.Value);
                                if (!result.IsSuccess)
                                    Error = ErrorCondition.NotAcceptable;
                            }
                            else
                                Error = ErrorCondition.NotAcceptable;
                        }
                        else
                            Error = ErrorCondition.Forbidden;
                    }
                    else
                        Error = ErrorCondition.Forbidden;
                }
                else
                    Error = ErrorCondition.Forbidden;
            }
            else
                Error = ErrorCondition.FeatureNotImplemented;

            int cindex;
            if (ThreadTools.Users.Online.IsAuthenticated(username, out cindex))
            {
                switch (Error)
                {
                    case ErrorCondition.NotAcceptable:
                        IQ eiq = new IQ();
                        if (formdata.HasAttribute("id"))
                            eiq.Id = formdata.Id;
                        eiq.Type = IqType.error;
                        eiq.Error = new agsXMPP.protocol.client.Error();
                        eiq.Error.Type = ErrorType.modify;
                        eiq.Error.Condition = ErrorCondition.NotAcceptable;
                        eiq.Error.Code = ErrorCode.NotAcceptable;

                        ThreadTools.Users.Online[cindex].Send(eiq);
                        break;
                    case ErrorCondition.Forbidden:
                        ThreadTools.Users.Online[cindex].Send(SendChangePassForm(username, formdata.Id));
                        break;
                    case ErrorCondition.FeatureNotImplemented:
                        IQ eiq2 = new IQ();
                        if (formdata.HasAttribute("id"))
                            eiq2.Id = formdata.Id;
                        eiq2.Type = IqType.error;
                        eiq2.Error = new agsXMPP.protocol.client.Error();
                        eiq2.Error.Type = ErrorType.modify;
                        eiq2.Error.Condition = ErrorCondition.FeatureNotImplemented;
                        eiq2.Error.Code = ErrorCode.NotImplemented;

                        ThreadTools.Users.Online[cindex].Send(eiq2);
                        break;
                    default:
                        IQ success = new IQ();
                        if (formdata.HasAttribute("id"))
                            success.Id = formdata.Id;
                        success.Type = IqType.result;
                        ThreadTools.Users.Online[cindex].Send(success);
                        break;
                }
            }
        }

        public static Vcard CreateUserVcard(string username)
        {
            NetTalk.DAL.TbUsers user;
            NetTalk.BLL.Users api = new NetTalk.BLL.Users();
            user = api.Find(username);
            Vcard card = null;
            if (user != null)
            {
                if (user.TbVcard != null)
                {
                    card = new Vcard();
                    if (!string.IsNullOrEmpty(user.TbVcard.VcardEmail))
                        card.AddEmailAddress(new agsXMPP.protocol.iq.vcard.Email(EmailType.NONE, user.TbVcard.VcardEmail, true));
                    if (!string.IsNullOrEmpty(user.TbVcard.VcardTelFax))
                        card.AddTelephoneNumber(new Telephone(TelephoneLocation.WORK, TelephoneType.FAX, "فکس: " + user.TbVcard.VcardTelFax));
                    if (!string.IsNullOrEmpty(user.TbVcard.VcardTelCell))
                        card.AddTelephoneNumber(new Telephone(TelephoneLocation.WORK, TelephoneType.CELL, "موبایل: " + user.TbVcard.VcardTelCell));
                    if (!string.IsNullOrEmpty(user.TbVcard.VcardTelVoice))
                        card.AddTelephoneNumber(new Telephone(TelephoneLocation.WORK, TelephoneType.VOICE, "داخلی: " + user.TbVcard.VcardTelVoice));
                    if (!string.IsNullOrEmpty(user.TbVcard.VcardTelVoice2))
                        card.AddTelephoneNumber(new Telephone(TelephoneLocation.WORK, TelephoneType.PREF, "مستقیم: " + user.TbVcard.VcardTelVoice2));

                    card.Fullname = user.TbVcard.VcardFirstName + " " + user.TbVcard.VcardLastName;
                    card.Name = new Name(user.TbVcard.VcardLastName, user.TbVcard.VcardFirstName, "");
                    //card.Organization = new Organization("شرکت خدمات انفورماتیک راهبر", cuser.ChatUserGroup);
                    card.Nickname = username;

                    card.JabberId = new agsXMPP.Jid(username + "@" + Config.AppSetting.domain);
                    if (!string.IsNullOrEmpty(user.TbVcard.VcardPhoto))
                    {
                        card.Photo = new Photo();
                        Element BINVAL = new Element("BINVAL");
                        BINVAL.Value = NetTalk.Web.Codes.ImageTools.ToBase64(user.TbVcard.VcardPhoto);
                        card.Photo.AddChild(BINVAL);
                    }
                }
            }
            return card;
        }

        public static void PingPong(string username, int UserIndex, string iqId)
        {
            IQ iq = new IQ();
            iq.Id = iqId;
            iq.To = new agsXMPP.Jid(username + "@" + Config.AppSetting.domain);
            iq.From = new agsXMPP.Jid(Config.AppSetting.domain);
            iq.Type = IqType.result;


            ThreadTools.Users.Online[UserIndex].Send(iq);
        }

        public static void Avatar(string username, IQ iq)
        {
            DAL.TbUsers cuser;
            BLL.Users api = new BLL.Users();
            switch (iq.Type)
            {
                case IqType.get:
                    if (iq.To != null)
                        cuser = api.Find(iq.To.User);
                    else
                        cuser = api.Find(username);

                    if (cuser != null)
                    {
                        if (!string.IsNullOrEmpty(cuser.TbVcard.VcardPhoto))
                        {
                            iq.SwitchDirection();
                            iq.Type = IqType.result;
                            iq.Query.Namespace = "jabber:iq:avatar";
                            iq.Query.ChildNodes.Clear();
                            Element dataEl = new Element("data");
                            dataEl.Value = ImageTools.ToBase64(cuser.TbVcard.VcardPhoto);

                            iq.Query.AddChild(dataEl);
                            int index;
                            if (ThreadTools.Users.Online.IsAuthenticated(username, out index))
                            {
                                ThreadTools.Users.Online[index].Send(iq);
                            }
                        }
                    }
                    break;
                case IqType.set:
                case IqType.result:
                    if (iq.Query.HasTag("data"))
                    {
                        Element el = iq.Query.SelectSingleElement("data");
                        cuser = api.Find(username);
                        string pname;
                        bool isSaved;
                        pname = ImageTools.SaveAvatar(el.Value, out  isSaved);
                        if (isSaved)
                        {
                            api.ChangeUserPicture(username, pname);
                            Rosters.SendStatus(username);
                        }
                    }
                    break;
            }
        }

        public static void SaveVcardAvatar(string username, int UserIndex, IQ vCard)
        {
            string data = "";
            Element p = vCard.SelectSingleElement("vCard");
            if (p.HasTag("PHOTO"))
            {
                p = p.SelectSingleElement("PHOTO");
                if (p.HasTag("BINVAL"))
                {
                    p = p.SelectSingleElement("BINVAL");
                    data = p.Value;
                }
            }

            if (!string.IsNullOrEmpty(data))
            {
                bool res;
                string fname = ImageTools.SaveAvatar(data, out res);
                if (res)
                {
                    BLL.Users api = new BLL.Users();
                    api.ChangeUserPicture(username, fname);
                    IQ iq = new IQ();
                    if (vCard.HasAttribute("id"))
                        iq.Id = vCard.Id;
                    iq.To = new agsXMPP.Jid(username + "@" + Config.AppSetting.domain);
                    iq.Type = IqType.result;
                    iq.Vcard = CreateUserVcard(username);
                    ThreadTools.Users.Online[UserIndex].Send(iq);
                }
            }
        }

        public static void ProccessVcard(string username, int UserIndex, IQ iq)
        {
            if (iq.Type == IqType.get)
            {
                iq.SwitchDirection();
                iq.Type = IqType.result;
                if (iq.To != null)
                {
                    if (!string.IsNullOrEmpty(iq.To.User))
                        iq.Vcard = CreateUserVcard(iq.To.User);
                }
                else
                    iq.Vcard = CreateUserVcard(username);
                ThreadTools.Users.Online[UserIndex].Send(iq);
            }
            else if (iq.Type == IqType.set)
            {
                SaveVcardAvatar(username, UserIndex, iq);
            }
        }

        public static void ProccessAuthGet(string username, int UserSessionIndex, IQ iq)
        {
            Auth auth = iq.Query as Auth;
            iq.SwitchDirection();
            iq.Type = IqType.result;
            if (!auth.HasTag("username"))
                auth.AddChild(new Element("username"));
            auth.AddChild(new Element("digest"));
            auth.AddChild(new Element("resource"));
            ThreadTools.Users.Online[UserSessionIndex].Send(iq);
        }

        public static void ProccessAuthSet(string username, string SID, int UserSessionIndex, IQ iq)
        {
            Auth auth = iq.Query as Auth;
            iq.SwitchDirection();
            string cuser = auth.Username;
            string cpass = auth.Digest;
            if (!string.IsNullOrEmpty(cuser) && !string.IsNullOrEmpty(cpass))
            {
                if (!ThreadTools.Users.Online[UserSessionIndex].Authenticated)
                {
                    int UserIndex;
                    if (!ThreadTools.Users.Online.IsAuthenticated(cuser, out UserIndex))
                    {
                        BLL.Users api = new BLL.Users();
                        if (api.LoginMessenger(cuser, SID, cpass))
                        {
                            iq.Type = IqType.result;
                            ThreadTools.Users.Online[UserSessionIndex].Authenticated = true;
                            ThreadTools.Users.Online[UserSessionIndex].Username = cuser;
                            iq.Query = null;
                            ThreadTools.Users.Online[UserSessionIndex].Send(iq);

                            api.ChangeUserStatus(cuser, true);

                            Presence p = Rosters.GetPresence(cuser);
                            p.To = new agsXMPP.Jid(cuser + "@" + Config.AppSetting.domain);

                            ThreadTools.Users.Online[UserSessionIndex].Send(p);

                            Rosters.SendStatus(cuser);
                        }
                        else
                        {
                            iq.Type = IqType.error;
                            iq.Query = null;
                            iq.AddChild(new agsXMPP.protocol.client.Error(ErrorType.auth, ErrorCondition.NotAuthorized));
                            ThreadTools.Users.Online[UserSessionIndex].Send(iq);
                        }
                    }
                    else
                    {
                        iq.Type = IqType.error;
                        iq.Query = null;
                        iq.AddChild(new agsXMPP.protocol.client.Error(ErrorType.auth, ErrorCondition.Conflict));
                        ThreadTools.Users.Online[UserSessionIndex].Send(iq);
                    }
                }
            }
            else
            {
                iq.Type = IqType.error;
                iq.Query = null;
                iq.AddChild(new agsXMPP.protocol.client.Error(ErrorType.auth, ErrorCondition.NotAcceptable));
                ThreadTools.Users.Online[UserSessionIndex].Send(iq);
            }
        }

        public static void ProcessRosterIQGet(string username, IQ iq)
        {
            iq.Type = IqType.result;
            iq.Query = new Roster();

            BLL.Users api = new BLL.Users();
            List<DAL.VwFriend> FList = api.ListFriend(username);
            for (int i = 0; i < FList.Count; i++)
            {
                RosterItem ri = new RosterItem();
                ri.Name = FList[i].VcardFirstName + " " + FList[i].VcardLastName;
                ri.Subscription = (FList[i].FriendStatus == 1) ? SubscriptionType.from : SubscriptionType.both;
                ri.Jid = new agsXMPP.Jid(FList[i].FriendUserName + "@" + Config.AppSetting.domain);
                if (!string.IsNullOrEmpty(FList[i].GroupName))
                    ri.AddGroup(FList[i].GroupName);
                iq.Query.AddChild(ri);
            }

            int index;
            if (ThreadTools.Users.Online.IsAuthenticated(username, out index))
            {
                ThreadTools.Users.Online[index].Send(iq);
                ThreadTools.Users.Online[index].Send(Rosters.FriendStatus(username));
                ThreadTools.Users.Online[index].Send(Messages.OfflineMessage(username));
                ThreadTools.Users.Online[index].Send(Rosters.PendingStatus(iq.From.User));
            }
        }

        public static void ProcessRosterIQSet(string username, IQ iq)
        {
            if (iq.Query.HasChildElements)
            {
                BLL.Users api = new BLL.Users();
                foreach (Node r in iq.Query.ChildNodes)
                {
                    Element el = r as Element;
                    if (el != null)
                    {
                        RosterItem ri = el as RosterItem;
                        if (el.HasAttribute("subscription"))
                        {
                            if (ri.Subscription == SubscriptionType.remove)
                            {
                                api.DeleteFriend(username, ri.Jid.User);
                            }
                        }
                        if (el.HasChildElements)
                        {
                            NodeList li = el.ChildNodes;
                            ElementList eli = ri.GetGroups();
                            string groupName = null;
                            if (eli.Count > 0)
                            {
                                groupName = eli.Item(0).Value;
                            }
                            if (li.Count > 0)
                                api.ChangeFriendStatus(username, ri.Jid.User, groupName, null, true);
                        }
                    }
                }
                iq.Type = IqType.get;
                ProcessRosterIQGet(username, iq);
            }
        }
    }
}
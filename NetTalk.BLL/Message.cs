using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NetTalk.DAL;

namespace NetTalk.BLL
{
    public class Message: BLLBase<TbMessage>
    {
        NetTalk.DAL.Model.Message Api;
        public Message()
        {
            Api = new NetTalk.DAL.Model.Message();
            BaseApi = Api;
            Key = "MessageId";
        }

        public List<VwMessageOffline> ListOffline(Guid UserId)
        {
            return Api.ListOffline(UserId).OrderBy(c => c.MessageDate).ToList();
        }

        public List<TbMessage> ListOffline(string username)
        {
            List<TbMessage> MsgList = Api.ListOffline(username).OrderBy(c => c.MessageDate).ToList();
            foreach (TbMessage msg in MsgList)
            {
                msg.MessageViewDate = DateTime.Now;
            }
            Api.Save();

            return MsgList;
        }

        public BLLResult Insert(string fromuser, string touser, string text, string html, string senderIP, bool IsSent)
        {
            BLLResult res = new BLLResult();
            TbUsers FUser = Api.FindUser(fromuser);
            TbUsers TUser = Api.FindUser(touser);

            if (FUser != null && TUser != null)
            {
                if (!string.IsNullOrEmpty(text))
                {
                    TbMessage msg = new TbMessage();
                    msg.MessageId = NetTalk.GuidTools.Create();
                    msg.MessageDate = DateTime.Now;
                    msg.MessageFromUserId = FUser.UserId;
                    msg.MessageHTML = html;
                    msg.MessageSenderIP = senderIP;
                    msg.MessageText = text;
                    msg.MessageToUserId = TUser.UserId;
                    msg.TbUsers = TUser;
                    msg.TbUsers1 = FUser;
                    if (IsSent)
                        msg.MessageViewDate = DateTime.Now;

                    Api.Insert(msg);
                    res.IsSuccess = (Api.Save() > 0);
                    res.ErrorMessage = Api.SaveError;
                }
                else
                    res.ErrorMessage = "user not found";
            }            
            return res;
        }
    }
}

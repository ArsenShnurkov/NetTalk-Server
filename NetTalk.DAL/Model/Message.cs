using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects;

namespace NetTalk.DAL.Model
{
    public class Message: ModelBase<TbMessage>
    {
        public IQueryable<VwMessageOffline> ListOffline(Guid userId)
        {
            return DB.VwMessageOffline.Where(c => c.MessageToUserId == userId);
        }

        public IQueryable<TbMessage> ListOffline(string username)
        {
            return (from all in DB.TbMessage
                    where all.TbUsers.Username == username && all.MessageViewDate == null
                    select all);
        }

        public TbUsers FindUser(string username)
        {
            return DB.TbUsers.FirstOrDefault(c => c.Username == username);
        }
    }
}

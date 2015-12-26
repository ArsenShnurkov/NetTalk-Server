using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Data.Objects;

namespace NetTalk.DAL.Model
{
    public class Users: ModelBase<NetTalk.DAL.TbUsers>
    {
        //public enum FriendStatusEnum
        //{
        //    Pending = 0,
        //    From = 1,
        //    Both = 2
        //}

        #region Friends
        public IQueryable<VwFriend> FindFriend(string username , byte friendStatus)
        {
            return (from all in DB.VwFriend
                    where (all.Username == username && all.FriendStatus == friendStatus)
                    select all);
        }

        public IQueryable<VwFriend> FindFriend(string username)
        {
            return (from all in DB.VwFriend
                    where (all.Username == username && all.FriendStatus == 1) || (all.Username == username && all.FriendStatus == 2)
                    select all);
        }

        public IQueryable<VwFriend> FindOnlineFriend(string username)
        {
            return (from all in DB.VwFriend
                    where all.UserIsOnline == true && all.FriendStatus == 2
                    select all);
        }

        public IQueryable<VwFriend> FindPendingFriend(string username)
        {
            return (from all in DB.VwFriend
                    where (all.Username == username && all.FriendStatus == 0)
                    select all);
        }

        public TbFriend FindFriend(string username, string friendUsername)
        {
            return DB.TbFriend.FirstOrDefault(c => c.TbUsers.Username == username && c.TbUsers1.Username == friendUsername);
        }

        public bool IsFriendApproved(string username, string friendName)
        {
            return (DB.TbFriend.Any(c => c.TbUsers.Username == username && c.TbUsers1.Username == friendName && c.FriendStatus == 2));
        }

        public void AddFriend(TbFriend friend)
        {
            DB.TbFriend.Add(friend);
        }

        public void DeleteFriend(TbFriend friend)
        {
            DB.TbFriend.Remove(friend);
        }

        public bool IsFriend(string username, string friendUsername)
        {
            return (from all in DB.TbFriend
                    where all.TbUsers.Username == username && all.TbUsers1.Username == friendUsername
                    select all).Any();
        }
        #endregion

        #region User Status
        public TbUserStatus FindStatus(string username)
        {
            return DB.TbUserStatus.FirstOrDefault(c => c.TbUsers.Username == username);
        }

        public void AddStatus(TbUserStatus status)
        {
            DB.TbUserStatus.Add(status);
        }
        #endregion

        public ObjectQuery<VwUsers> FindVw(string search, ObjectParameter[] keys)
        {
            return ((IObjectContextAdapter) DB).ObjectContext.CreateObjectSet<VwUsers>().FindIn(search, keys);
        }

        public void DeleteUser(Guid userId)
        {
            try
            {
                DB.DeleteUser(userId);
            }
            catch { }
        }
    }
}

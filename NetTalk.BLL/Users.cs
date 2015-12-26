using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NetTalk.DAL;
using System.ComponentModel;

namespace NetTalk.BLL
{
    public class Users: BLLBase<TbUsers>
    {
        NetTalk.DAL.Model.Users Api;
        public Users()
        {
            Api = new NetTalk.DAL.Model.Users();
            BaseApi = Api;
            Key = "UserId";
        }

        public TbUsers Find(string Username)
        {
            return Api.Find("Username", Username);
        }

        #region Friend
        public List<VwFriend> ListFriend(string Username)
        {
            try
            {
                return Api.FindFriend(Username).ToList();
            }
            catch (Exception ex)
            {
                return new List<VwFriend>();
            }
        }

        public List<VwFriend> ListPending(string Username)
        {
            return Api.FindPendingFriend(Username).ToList();
        }

        public List<VwFriend> ListOnlinFriend(string username)
        {
            return Api.FindOnlineFriend(username).ToList();
        }

        public BLLResult AddFriend(string Username, string FriendUsername, string GroupName)
        {
            BLLResult res = new BLLResult();
            if (!Api.IsFriend(Username, FriendUsername))
            {
                TbUsers User = Find(Username);
                TbUsers Friend = Find(FriendUsername);

                if (User != null && Friend != null)
                {
                    TbFriend FromUser = new TbFriend();
                    FromUser.UserId = User.UserId;
                    //FromUser.TbUsers = User;
                    FromUser.FriendId = Friend.UserId;
                    //FromUser.TbUsers1 = Friend;
                    FromUser.FriendStatus = 1;
                    if (!string.IsNullOrEmpty(GroupName))
                        FromUser.GroupName = GroupName;
                    Api.AddFriend(FromUser);

                    TbFriend ToUser = new TbFriend();
                    ToUser.UserId = Friend.UserId;
                    //ToUser.TbUsers = Friend;
                    ToUser.FriendId = User.UserId;
                    //ToUser.TbUsers1 = User;
                    ToUser.FriendStatus = 0;
                    Api.AddFriend(ToUser);

                    res.IsSuccess = Api.Save() > 0;
                    res.ErrorMessage = Api.SaveError;
                }
            }
            return res;
        }

        public TbFriend FindFriend(string username, string friendName)
        {
            return Api.FindFriend(username, friendName);
        }

        public bool IsFriend(string username, string friendName)
        {
            return Api.IsFriendApproved(username, friendName);
        }

        public BLLResult ChangeFriendStatus(string Username, string FriendUsername, string Group, byte? Status)
        {
            BLLResult res = new BLLResult();
            TbFriend Friend = Api.FindFriend(Username, FriendUsername);
            if (Friend != null)
            {
                if (Status.HasValue)
                    Friend.FriendStatus = Status.Value;
                Friend.GroupName = Group;
                res.IsSuccess = (Api.Save() > 0);
                res.ErrorMessage = Api.SaveError;
            }
            return res;
        }

        public BLLResult ChangeFriendStatus(string Username, string FriendUsername, string Group, byte? Status, bool addNew)
        {
            BLLResult res = new BLLResult();
            TbFriend Friend = Api.FindFriend(Username, FriendUsername);
            if (Friend != null)
            {
                if (Status.HasValue)
                    Friend.FriendStatus = Status.Value;
                Friend.GroupName = Group;
                res.IsSuccess = (Api.Save() > 0);
                res.ErrorMessage = Api.SaveError;
            }
            else if(addNew)
            {
                res = this.AddFriend(Username, FriendUsername, Group);
            }
            return res;
        }

        public BLLResult DeleteFriend(string Username, string FriendUsername)
        {
            BLLResult res = new BLLResult();
            TbFriend FA = Api.FindFriend(Username, FriendUsername);
            TbFriend FB = Api.FindFriend(FriendUsername, Username);

            if (FA != null)
                Api.DeleteFriend(FA);
            if (FB != null)
                Api.DeleteFriend(FB);

            res.IsSuccess = (Api.Save() > 0);
            res.ErrorMessage = Api.SaveError;
            return res;
        }
        #endregion

        #region Login
        public bool LoginMessenger(string Username, string SID, string HashedPass)
        {
            TbUsers User = Find(Username);
            bool res = false;
            if (User != null)
            {
                string UserPass = NetTalk.Common.Hash.NetTalkEncrypt.Decrypt(User.UserPassCrypt, User.UserPassSalt);
                UserPass = SID + UserPass;
                UserPass = NetTalk.Common.Hash.NetTalkHash.Sha1Text(UserPass);

                res = (UserPass.ToLower() == HashedPass.ToLower());

                if (res)
                {
                    User.UserPrevLoginDate = User.UserLastLoginDate;
                    User.UserLastLoginDate = DateTime.Now;
                    Api.Save();
                }
            }
            return res;
        }

        public string PassView(string userName)
        {
            TbUsers User = Find(userName);
            return NetTalk.Common.Hash.NetTalkEncrypt.Decrypt(User.UserPassCrypt, User.UserPassSalt);
        }

        public bool LoginWebSite(string Username, string Password)
        {
             TbUsers User = Find(Username);
            bool res = false;
            if (User != null)
            {
                if (User.UserWebAdmin)
                {
                    string UserPass = NetTalk.Common.Hash.NetTalkEncrypt.Decrypt(User.UserPassCrypt, User.UserPassSalt);
                    res = (UserPass == Password);
                }
            }
            return res;
        }
        #endregion

        #region Users
        public DateTime LastActivity(string username)
        {
            return Api.FindStatus(username).UserStatusDate;
        }

        public List<VwUsers> ListVw(string DefaultSort, DynamicSearch.ConditionList Search, string Sort, int PageIndex, int PageSize)
        {
            if (string.IsNullOrEmpty(Sort))
                Sort = DefaultSort;

            return Api.FindVw(Search.GetString(), Search.GetParam())
                .OrderBy("it." + Sort).Skip(PageSize * PageIndex).Take(PageSize).ToList();
        }

        [DataObjectMethod(DataObjectMethodType.Select,false)]
        public List<VwUsers> ListVw(string Sort, int PageIndex, int PageSize)
        {
            if (string.IsNullOrEmpty(Sort))
                Sort = "Username";

            return Api.FindVw(string.Empty, new System.Data.Objects.ObjectParameter[]{})
                .OrderBy("it." + Sort).Skip(PageIndex).Take(PageSize).ToList();
        }

        public int ListVwCount()
        {
            return Api.FindVw(string.Empty, new System.Data.Objects.ObjectParameter[] { }).Count();
        }

        public int ListVwCount(DynamicSearch.ConditionList Search)
        {
            return Api.FindVw(Search.GetString(), Search.GetParam()).Count();
        }

        public BLLResult ChangePassword(string Username, string OldPassword, string NewPassword)
        {
            BLLResult res = new BLLResult();
            TbUsers User = Find(Username);
            if (User != null)
            {
                string UserPass = NetTalk.Common.Hash.NetTalkEncrypt.Decrypt(User.UserPassCrypt, User.UserPassSalt);
                if (UserPass == OldPassword)
                {
                    User.UserPassCrypt = NetTalk.Common.Hash.NetTalkEncrypt.Encrypt(NewPassword, User.UserPassSalt);
                    User.UserLastChangePass = DateTime.Now;
                    res.IsSuccess = Api.Save() > 0;
                    res.ErrorMessage = Api.SaveError;
                }
                else
                    res.ErrorMessage = "password is invalid";
            }
            else
                res.ErrorMessage ="user not found";
            return res;
        }

        public BLLResult ChangePassword(string Username,  string NewPassword)
        {
            BLLResult res = new BLLResult();
            TbUsers User = Find(Username);
            if (User != null)
            {
                User.UserPassCrypt = NetTalk.Common.Hash.NetTalkEncrypt.Encrypt(NewPassword, User.UserPassSalt);
                User.UserLastChangePass = DateTime.Now;
                res.IsSuccess = Api.Save() > 0;
                res.ErrorMessage = Api.SaveError;
            }
            return res;
        }

        /// <summary>
        /// change user status in database
        /// </summary>
        /// <param name="Username"></param>
        /// <param name="UserStatusText"></param>
        /// <param name="UserStatus">ShowType FROM AgsXmpp</param>
        /// <param name="IsOnline">Precence</param>
        /// <returns></returns>
        public BLLResult ChangeUserStatus(string Username, string UserStatusText, short? UserStatus, bool IsOnline)
        {
            BLLResult res = new BLLResult();
            TbUsers User = Find(Username);
            if (User != null)
            {
                if (User.TbUserStatus == null)
                {
                    User.TbUserStatus = new TbUserStatus();
                    User.TbUserStatus.UserStatus = 0;
                }
                User.TbUserStatus.UserStatusText = UserStatusText;
                if (UserStatus.HasValue)
                    User.TbUserStatus.UserStatus = UserStatus.Value;

                User.TbUserStatus.UserStatusDate = DateTime.Now;
                User.TbUserStatus.UserIsOnline = IsOnline;

                res.IsSuccess = (Api.Save() > 0);
                res.ErrorMessage = Api.SaveError;
            }
            return res;
        }

        public BLLResult ChangeUserStatus(string Username,  bool IsOnline)
        {
            BLLResult res = new BLLResult();
            TbUsers User = Find(Username);
            if (User != null)
            {
                if (User.TbUserStatus == null)
                {
                    User.TbUserStatus = new TbUserStatus();
                    User.TbUserStatus.UserStatus = 0;
                }

                User.TbUserStatus.UserStatusDate = DateTime.Now;
                User.TbUserStatus.UserIsOnline = IsOnline;

                res.IsSuccess = (Api.Save() > 0);
                res.ErrorMessage = Api.SaveError;
            }
            return res;
        }

        public BLLResult ChangeUserPicture(string Username, string Picture)
        {
            TbUsers User = Find(Username);
            BLLResult res = new BLLResult();
            if (User != null)
            {
                User.TbVcard.VcardPhoto = Picture;
                res.IsSuccess = (Api.Save() > 0);
                res.ErrorMessage = Api.SaveError;
            }
            return res;
        }

        public BLLResult AddUser(string Username, string Password, bool IsWebAdmin, TbVcard Vcard)
        {
            BLLResult res = new BLLResult();
            TbUsers User = Find(Username);
            if (User == null)
            {
                string Salt = NetTalk.Common.Hash.NetTalkHash.Sha1Text(DateTime.Now.ToString("yyyyMMddHHmmss"));
                User = new TbUsers();
                User.UserId = NetTalk.GuidTools.Create();
                User.Username = Username;
                User.UserWebAdmin = IsWebAdmin;
                User.TbUserStatus = new TbUserStatus();
                User.TbUserStatus.UserIsOnline = false;
                User.TbUserStatus.UserStatus = 0;
                User.TbUserStatus.UserStatusDate = DateTime.Now;
                User.UserPassSalt = Salt;
                User.UserPassCrypt = NetTalk.Common.Hash.NetTalkEncrypt.Encrypt(Password, Salt);
                User.TbVcard = Vcard;
                User.TbUserStatus = new TbUserStatus()
                {
                    UserIsOnline = false,
                    UserId = User.UserId,
                    UserStatus = 0,
                    UserStatusDate = DateTime.Now,
                    UserStatusText = null
                };

                Api.Insert(User);
                res.IsSuccess = (Api.Save() > 0);
                res.ErrorMessage = Api.SaveError;
            }
            else
                res.ErrorMessage = "this user name is taken";

            return res;
        }

        public BLLResult UpdateUser(string Username, string Password, bool IsWebAdmin, TbVcard Vcard)
        {
            BLLResult res = new BLLResult();
            TbUsers User = Find(Username);
            if (User != null)
            {
                User.UserWebAdmin = IsWebAdmin;
                if (!string.IsNullOrEmpty(Password))
                {
                    User.UserPassCrypt = NetTalk.Common.Hash.NetTalkEncrypt.Encrypt(Password, User.UserPassSalt);
                }
                User.TbVcard = Vcard;
                res.IsSuccess = (Api.Save() > 0);
                res.ErrorMessage = Api.SaveError;
            }
            else
                res.ErrorMessage = "user name not found";

            return res;
        }

        public override BLLResult Delete(string idList)
        {
            BLLResult res = new BLLResult();
            res.IsSuccess = true;
            List<Guid> ids = idList.ToGuidArray();
            foreach (Guid Id in ids)
            {
                Api.DeleteUser(Id);
            }
            return res;
        }
        #endregion
    }
}

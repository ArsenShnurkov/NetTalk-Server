using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NetTalk.Web.Codes.ThreadTools
{
    public class ConnectionList : List<Connection>
    {
        public bool IsAuthenticated(string Username, out int Index)
        {
            Index = -1;
            int count = this.Count;
            System.Collections.ArrayList alist = new System.Collections.ArrayList();

            for (int i = 0; i < count; i++)
            {
                if (this[i].Authenticated)
                {
                    if (this[i].Username == Username)
                    {
                        if (this[i].IsConnected)
                        {
                            Index = i;
                        }
                        else if (((this[i].StartTime - DateTime.Now).TotalMinutes > 15))
                        {
                            alist.Add(this[i]);
                        }
                    }
                }
            }

            //close open connection that can not login to server
            foreach (object ci in alist)
            {
                Connection ct = (Connection)ci;
                try
                {
                    ct.Stop();
                }
                catch { }
                this.Remove(ct);
            }

            return (Index > -1);
        }

        public bool IsSessionExists(string SessionId, out int Index)
        {
            Index = -1;
            for (int i = 0; i < this.Count; i++)
            {
                if (this[i].SessionId == SessionId)
                {
                    Index = i;
                    break;
                }
            }
            return (Index > -1);
        }

        public Connection this[string username]
        {
            get
            {
                int cindex = -1;
                if (IsAuthenticated(username, out cindex))
                    return this[cindex];
                else
                    return null;
            }
        }
    }

    public class Users
    {
        private static ConnectionList _Users;
        public static ConnectionList Online
        {
            get
            {
                if (_Users == null)
                    _Users = new ConnectionList();
                return _Users;
            }
        }

        public static ConnectionList GetUsersList()
        {
            return Online;
        }
    }
}
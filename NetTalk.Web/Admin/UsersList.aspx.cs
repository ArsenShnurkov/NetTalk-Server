using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NetTalk.BLL;

namespace NetTalk.Web.Admin
{
    public partial class UsersList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public static string PassView(string userName)
        {
            return (new Users()).PassView(userName);
        }
    }
}
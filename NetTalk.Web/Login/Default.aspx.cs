using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace NetTalk.Web.Login
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_login_Click(object sender, EventArgs e)
        {
            if (username.Text == "admin" && password.Text == "admin")
            {
                FormsAuthentication.RedirectFromLoginPage(username.Text, remember.Checked);
            }
            else
            {
                ErrorMessage.Text = "Invalid Login Information";
                ErrorPanel.Visible = true;
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NetTalk.BLL;

namespace NetTalk.Web
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Common.Dates.NetTalkDate LDate = new Common.Dates.NetTalkDate();
            lbldate.Text = LDate.ToString("$dddd, $d $MMMM $yyyy - $HH:$mm $g");
            //Users user = new Users();
            //BLLResult res = user.ChangePassword("mahdi", "123456");
        }
    }
}
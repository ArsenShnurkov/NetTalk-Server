using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NetTalk.Web.Admin
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BLL.Users api = new BLL.Users();
            lblusercount.Text = api.ListCount(new DynamicSearch.ConditionList()).ToString();

            DynamicSearch.ConditionList li= new DynamicSearch.ConditionList();
            li.Add("UserIsOnline", DynamicSearch.SearchCondition.Equal, true, "bool", false);
            lblonlinecount.Text = api.ListVwCount(li).ToString();

            lblconnectioncount.Text = Codes.ThreadTools.Users.Online.Count.ToString();

            imgserverStatus.ImageUrl = "~/Scripts/Style/images/" + ((Codes.ThreadTools.Main.ThreadIsAlive) ? "active.gif" : "inactive.png");
        }
    }
}
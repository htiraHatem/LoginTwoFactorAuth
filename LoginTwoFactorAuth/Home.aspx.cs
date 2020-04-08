using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LoginTwoFactorAuth
{
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Session["userid"]);
            if (id< 1)
                {
                Response.Redirect("SignIn.aspx");

            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LoginTwoFactorAuth
{
    public partial class SignIn : System.Web.UI.Page
    {
        ServiceReferenceTFA.Service1Client service = new ServiceReferenceTFA.Service1Client();

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnSignIn_Click(object sender, EventArgs e)
        {
            if (service.ValidOTP((TxtLogin.Value).Trim(), (TxtPwd.Value).Trim(), (TxtToken.Value).Trim()))

            {
                //test of session
                Session["userid"] = 1;
                Response.Redirect("Home.aspx");

            }
            else
            {
                Response.Redirect("SignIn.aspx");
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Drawing;

public partial class Account_SiteAccount : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

        RegisterUser.ContinueDestinationPageUrl = Request.QueryString["ReturnUrl"];
    }

    protected void RegisterUser_CreatedUser(object sender, EventArgs e)
    {
        FormsAuthentication.SetAuthCookie(RegisterUser.UserName, true   /* createPersistentCookie */);

        string continueUrl = RegisterUser.ContinueDestinationPageUrl;

        if (String.IsNullOrEmpty(continueUrl))
        {
            continueUrl = "~/Dashboard/";
        }
        Response.Redirect(continueUrl);

        RegisterUser.ActiveStepIndex = 1;
    }
}

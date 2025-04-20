using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyComponents
{
    public partial class HomePage : System.Web.UI.Page
    {
        string username = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            // use session or cookie info to find users name
            // try  session
            if (Session["Username"] != null)
            {
                username = Session["Username"].ToString();
            }
            else // try cookie
            {
                HttpCookie userCookie = Request.Cookies["UserProfile"];
                if (userCookie != null)
                {
                    username = userCookie["Username"];
                }
            }
            // check if session info exists
            if (!string.IsNullOrEmpty(username))
            {
                System.Diagnostics.Debug.WriteLine("session info found in home");
                string welcomeMsg = "Welcome " + username;
                System.Diagnostics.Debug.WriteLine(welcomeMsg);
                WelcomeLabel.Text = welcomeMsg;

            }
            else
            {
                System.Diagnostics.Debug.WriteLine("session info not found");
            }

        }

        protected void transactionistoryButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("TransactionHistory.aspx?username=" + HttpUtility.UrlEncode(username));
        }

        protected void atmButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Withdraw_DepositUI.aspx?username=" + HttpUtility.UrlEncode(username));
        }
    }
}
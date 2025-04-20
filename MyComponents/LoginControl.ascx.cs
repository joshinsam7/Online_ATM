using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyComponents
{
    public partial class LoginControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string username = null;
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
                    System.Diagnostics.Debug.WriteLine("session info found");
                    Response.Redirect("HomePage.aspx");
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("session info not found");
                }
            }
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            // retrieve the username and password
            String username = UsernameTextBox.Text;
            String password = PasswordTextBox.Text;

            // service call to User Exists
            IUserInfoStorage storage = new Service();
            bool loginSuccess = storage.UserExists(username, password);

            if (loginSuccess) // User was found, so redirect to home page.
            {
                // store info in a sessionuser stays logged in
                Session["Username"] = username;
                // set cookie
                HttpCookie userCookie = new HttpCookie("UserProfile");
                userCookie["Username"] = username;
                userCookie.Expires = DateTime.Now.AddMinutes(30);
                Response.Cookies.Add(userCookie);

                Response.Redirect("HomePage.aspx");
            }
            else // User was not found, login failed
            {
                LoginResult.Text = "Invalid credentials";
            }
         
        }

        protected void DirectToCreateButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("CreateUserPage.aspx");
        }
    }
}
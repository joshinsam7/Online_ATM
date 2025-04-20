using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyComponents
{
    public partial class CreateUserControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CreateUserButton_Click(object sender, EventArgs e)
        {
            // retrieve the username and password
            String username = UsernameTextBox.Text;
            String password = PasswordTextBox.Text;

            // Service call to Save User
            IUserInfoStorage storage = new Service();  
            bool success = storage.SaveUser(username, password);

            if (success) // New User was created
            {
                CreateUserResult.Text = "User Successfully Created";
            }
            else // User was already exists
            {
                CreateUserResult.Text = "User already exists";
            }
        }

        protected void DirectToLoginButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("LoginPage.aspx");
        }
    }
}
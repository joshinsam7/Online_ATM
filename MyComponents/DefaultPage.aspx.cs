using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyComponents
{
    public partial class DefaultPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("LoginPage.aspx");
        }

        protected void StemmingButton_Click(object sender, EventArgs e)
        {
            String inputText = StemmingInput.Text;
            StemmingService.Service1Client service1Client = new StemmingService.Service1Client();
            String result = service1Client.Stemming(inputText); // Use service reference to call Stemming()
            StemmingResult.Text = result;   
        }
    }
}
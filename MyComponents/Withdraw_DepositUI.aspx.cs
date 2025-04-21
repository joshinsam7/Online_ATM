using System;
using System.Collections.Generic;
using System.EnterpriseServices.CompensatingResourceManager;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyComponents
{
    public partial class Withdraw_DepositUI : System.Web.UI.Page
    {
        public string name = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            pnlWithdraw.Visible = false;
            pnlDeposit.Visible = false;
//            inputCustomD.Visible = false;
//            inputCustomW.Visible = false;

            string username = Request.QueryString["username"];
            if (string.IsNullOrEmpty(username))
            {
                // Handle the case where username is missing
                Response.Write("Username is missing in the query string.");
                return;
            }
        }

        protected void depositButton_Click(object sender, EventArgs e)
        {
            pnlDeposit.Visible = true;
            pnlWithdraw.Visible = false;
        }

        protected void withdrawButton_Click(object sender, EventArgs e)
        {
            pnlWithdraw.Visible = true;
            pnlDeposit.Visible = false;
        }

        protected void Withdraw_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            if (!int.TryParse(btn.CommandArgument, out int val))
            {
                Response.Write("Invalid input. Please enter a numeric value.");
                return;
            }

            string username = Request.QueryString["username"];
            if (string.IsNullOrEmpty(username))
            {
                Response.Write("Username is missing in the query string.");
                return;
            }

            wdService.IwithdrawDepositClient prxy = new wdService.IwithdrawDepositClient();
            Boolean check = prxy.withdraw(val, username); 

            if (check)
            {
                Response.Write("Withdrawal successful.");
            }
            else
            {
                Response.Write("Withdrawal failed. Please try again.");
            }
        }


        protected void deposit_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            if (!int.TryParse(btn.CommandArgument, out int val))
            {
                Response.Write("Invalid input. Please enter a numeric value.");
                return;
            }

            string username = Request.QueryString["username"];
            if (string.IsNullOrEmpty(username))
            {
                Response.Write("Username is missing in the query string.");
                return;
            }

            wdService.IwithdrawDepositClient prxy = new wdService.IwithdrawDepositClient();
            Boolean check = prxy.deposit(val, username);

            if (check)
            {
                Response.Write("Deposit successful.");
            }
            else
            {
                Response.Write("Deposit failed. Please try again.");
            }
        }

        protected void btnDCustom_Click(object sender, EventArgs e)
        {
            inputCustomD.Visible = true; 
            inputCustomW.Visible = false; 
        }

        protected void btnWCustom_Click(object sender, EventArgs e)
        {
            inputCustomW.Visible = true;
            inputCustomD.Visible = false; 
        }


        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Homepage.aspx");
        }

        protected void submitCustomTransactionWithdraw_Click(object sender, EventArgs e)
        {
            // Initialize the proxy object to interact with the service
            wdService.IwithdrawDepositClient prxy = new wdService.IwithdrawDepositClient();
            int val = 0;

            Boolean check = false;

            if (int.TryParse(txtCustomW.Text, out val) && val > 0)
            {
                check = prxy.withdraw(val, Request.QueryString["username"]);
            }
            else
            {
                Response.Write("Invalid Withdrawal amount. Please enter a valid positive number.");
                return;
            }

            if (check)
            {
                Response.Write("Withdrawal successful.");
            }
            else
            {
                Response.Write("Withdrawal failed. Please try again.");
            }

        }


        protected void submitCustomTransactionDeposit_Click(object sender, EventArgs e)
        {
            // Initialize the proxy object to interact with the service
            wdService.IwithdrawDepositClient prxy = new wdService.IwithdrawDepositClient();
            int val = 0;

            Boolean check = false;

            if (int.TryParse(TextBox1.Text, out val) && val > 0)
            {
                // Attempt to withdraw the entered value
                check = prxy.deposit(val, Request.QueryString["username"]);
            }
            else
            {
                // Show an error if the input is not a valid positive number
                Response.Write("Invalid deposit amount. Please enter a valid positive number.");
                return;
            }

            if (check)
            {
                Response.Write("Deposit successful.");
            }
            else
            {
                Response.Write("Deposit failed. Please try again.");
            }
        }

    }
}
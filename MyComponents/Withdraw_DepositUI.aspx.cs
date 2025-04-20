using System;
using System.Collections.Generic;
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
            Button btn = (Button)sender;

            //int val = Convert.ToInt32(btn.Text);

            //wdService.IwithdrawDepositClient prxy = new wdService.IwithdrawDepositClient();

            //Boolean check = prxy.deposit(val, Request.QueryString["username"]);
        }

        protected void btnWCustom_Click(object sender, EventArgs e)
        {

        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Homepage.aspx");
        }
    }
}
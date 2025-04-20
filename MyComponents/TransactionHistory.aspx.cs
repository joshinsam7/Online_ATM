using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
//using MyComponents.ShowTransactionsServiceReference; // Namespace for the WCF service reference

namespace MyComponents
{
    public partial class TransactionHistory : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadTransactionHistory();
            }
        }

        private void LoadTransactionHistory()
        {

            // Create a proxy to consume the WCF service
            ServiceReference1.IshowTransactionsClient prxy = new ServiceReference1.IshowTransactionsClient();

            // Fetch transaction history
            List<ServiceReference1.Transaction> transactions = prxy.GetTransactionHistory().ToList();

            // Check if transactions are available
            if (transactions != null && transactions.Count > 0)
            {
                // Bind the transaction history to the GridView
                GridViewTransactions.DataSource = transactions;
                GridViewTransactions.DataBind();
            }
            else
            {
                // Handle the case where no transactions are found
                System.Diagnostics.Debug.WriteLine("No transactions found.");
            }
        }
    }
}
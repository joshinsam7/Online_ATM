using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
//using MyComponents.ShowTransactionsServiceReference; // Namespace for the WCF service reference

namespace MyComponents
{
    public partial class TransactionHistory : Page
    {
        private readonly encryptdecrypt _encryptionService = new encryptdecrypt(); // Instance of encryptdecrypt class
        private List<ServiceReference1.Transaction> _transactions;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadTransactionHistory(encrypt:true);
            }
        }

        private void LoadTransactionHistory(bool encrypt)
        {
            // Create a proxy to consume the WCF service
            ServiceReference1.IshowTransactionsClient prxy = new ServiceReference1.IshowTransactionsClient();

            // Fetch transaction history
            _transactions = prxy.GetTransactionHistory().ToList();

            if (_transactions != null && _transactions.Count > 0)
            {
                // Encrypt or decrypt based on the parameter
                foreach (var transaction in _transactions)
                {
                    if (encrypt)
                    {
                        transaction.Type = _encryptionService.encrypt(transaction.Type);
                        transaction.Value = _encryptionService.encrypt(transaction.Value);
                        transaction.TotalAmount = _encryptionService.encrypt(transaction.TotalAmount);
                        transaction.User = _encryptionService.encrypt(transaction.User);
                    }
                    else
                    {
                        try
                        {
                            transaction.Type = _encryptionService.decrypt(transaction.Type);
                        }
                        catch
                        {
                            transaction.Type = "Could not be decrypted";
                        }

                        try
                        {
                            transaction.Value = _encryptionService.decrypt(transaction.Value);
                        }
                        catch
                        {
                            transaction.Value = "Could not be decrypted";
                        }

                        try
                        {
                            transaction.TotalAmount = _encryptionService.decrypt(transaction.TotalAmount);
                        }
                        catch
                        {
                            transaction.TotalAmount = "Could not be decrypted";
                        }

                        try
                        {
                            transaction.User = _encryptionService.decrypt(transaction.User);
                        }
                        catch
                        {
                            transaction.User = "Could not be decrypted";
                        }
                    }
                }

                // Bind the transaction history to the GridView
                GridViewTransactions.DataSource = _transactions;
                GridViewTransactions.DataBind();
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("No transactions found.");
            }
        }
        protected void btnEncrypt_Click(object sender, EventArgs e)
        {
            LoadTransactionHistory(encrypt: true); // Show encrypted data
        }

        protected void btnDecrypt_Click(object sender, EventArgs e)
        {
            LoadTransactionHistory(encrypt: false); // Show decrypted data
        }


    }
}
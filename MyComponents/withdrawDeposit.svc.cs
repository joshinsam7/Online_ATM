using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Windows.Documents;
using System.Xml.Linq;
using System.Xml.XPath;

namespace MyComponents
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "withdrawDeposite" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select withdrawDeposite.svc or withdrawDeposite.svc.cs at the Solution Explorer and start debugging.
    public class WithdrawDepositService : IwithdrawDeposit
    {
        private static string xmlPath = System.Web.HttpContext.Current.Server.MapPath("~/App_Data/transactions.xml");
        private readonly encryptdecrypt _encryptionService = new encryptdecrypt(); // Instance of encryptdecrypt class
        public bool deposit(int value, string user)
        {
            int totAmount = 0;
            XDocument doc;

            if (File.Exists(xmlPath))
            {
                doc = XDocument.Load(xmlPath);
                var lastAmountElement = doc.Root?.Elements("Transaction").LastOrDefault()?.Element("TotalAmount");

                totAmount = lastAmountElement != null && int.TryParse(lastAmountElement.Value, out int parsedAmount) ? parsedAmount : 0;
                totAmount += value;
            }
            else
            {
                doc = new XDocument(new XElement("Transactions"));
                totAmount = value;
            }

            return add_transaction(doc, totAmount, "Deposit", user, value);
        }

        public bool withdraw(int value, string user)
        {
            if (!File.Exists(xmlPath)) return false;

            XDocument doc = XDocument.Load(xmlPath);
            var lastAmountElement = doc.Root?.Elements("Transaction").LastOrDefault()?.Element("TotalAmount");

            if (lastAmountElement == null) return false;

            int currentAmount = (int)lastAmountElement;
            int newAmount = currentAmount - value;

            if (newAmount < 0) return false;

            return add_transaction(doc, newAmount, "Withdraw", user, value);
        }

        private bool add_transaction(XDocument doc, int amount, string type, string user, int value)
        {
            // Encrypt sensitive data
            string encryptedType = _encryptionService.encrypt(type);
            string encryptedValue = _encryptionService.encrypt(value.ToString());
            string encryptedTotalAmount = _encryptionService.encrypt(amount.ToString());
            string encryptedUser = _encryptionService.encrypt(user);

            foreach (XElement existingTransaction in doc.Root.Elements("Transaction")) // Renamed variable
            {
                if (string.IsNullOrEmpty(existingTransaction.Element("Type")?.Value) || !IsBase64(existingTransaction.Element("Type").Value))
                {
                    existingTransaction.Element("Type").Value = _encryptionService.encrypt(existingTransaction.Element("Type").Value);
                }
                if (string.IsNullOrEmpty(existingTransaction.Element("Value")?.Value) || !IsBase64(existingTransaction.Element("Value").Value))
                {
                    existingTransaction.Element("Value").Value = _encryptionService.encrypt(existingTransaction.Element("Value").Value);
                }
                if (string.IsNullOrEmpty(existingTransaction.Element("TotalAmount")?.Value) || !IsBase64(existingTransaction.Element("TotalAmount").Value))
                {
                    existingTransaction.Element("TotalAmount").Value = _encryptionService.encrypt(existingTransaction.Element("TotalAmount").Value);
                }
                if (string.IsNullOrEmpty(existingTransaction.Element("User")?.Value) || !IsBase64(existingTransaction.Element("User").Value))
                {
                    existingTransaction.Element("User").Value = _encryptionService.encrypt(existingTransaction.Element("User").Value);
                }
            }

            // Create the transaction element with encrypted data
            XElement transaction = new XElement("Transaction",
                new XElement("Type", encryptedType),
                new XElement("Value", encryptedValue),
                new XElement("TotalAmount", encryptedTotalAmount),
                new XElement("User", encryptedUser));

            doc.Root.Add(transaction);
            doc.Save(xmlPath);

            return true;
        }

        private bool IsBase64(string input)
        {
            try
            {
                Convert.FromBase64String(input);
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}

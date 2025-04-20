using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Xml.Linq;
using System.Xml.XPath;

namespace MyComponents
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "withdrawDeposite" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select withdrawDeposite.svc or withdrawDeposite.svc.cs at the Solution Explorer and start debugging.
    public class WithdrawDepositService : IwithdrawDeposit
    {
        private static string xmlPath = System.Web.HttpContext.Current.Server.MapPath("~/App_Data/transactions.xml");

        public bool deposit(int value, string user)
        {
            int totAmount = 0;
            XDocument doc;

            if (File.Exists(xmlPath))
            {
                doc = XDocument.Load(xmlPath);
                var lastAmountElement = doc.Root?.Elements("Transaction").LastOrDefault()?.Element("TotalAmount");

                totAmount = lastAmountElement != null ? (int)lastAmountElement : 0;
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
            XElement transaction = new XElement("Transaction",
                new XElement("Type", type),
                new XElement("Value", value),
                new XElement("TotalAmount", amount),
                new XElement("User", user));

            doc.Root.Add(transaction);
            doc.Save(xmlPath);

            return true;
        }

    }
}

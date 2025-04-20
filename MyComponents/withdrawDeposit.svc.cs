using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Xml.Linq;
using System.Xml.XPath;
using System.IO;

namespace MyComponents
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "withdrawDeposit" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select withdrawDeposit.svc or withdrawDeposit.svc.cs at the Solution Explorer and start debugging.
    public class withdrawDeposit : IwithdrawDeposit
    {
        private static string xmlPath = System.Web.HttpContext.Current.Server.MapPath("~/App_Data/transactions.xml");

        public Boolean deposit(int value, string user)
        {
            XDocument doc;

            if (File.Exists(xmlPath))
            {
                doc = XDocument.Load(xmlPath);
                int valuefromXML = (int)doc.XPathSelectElement(".//*[local-name()='Total Amount']");
                int totAmoutn = valuefromXML + value;
                return add_transaction(totAmoutn, "Deposit", user, value);
            }
            else
            {
                return add_transaction(value, "Deposit", user, 0);
            }
        }


        public Boolean withdraw(int value, string user)
        {
            XDocument doc;

            if (File.Exists(xmlPath))
            {
                doc = XDocument.Load(xmlPath);
                int valuefromXML = (int)doc.XPathSelectElement(".//*[local-name()='Total Amount']");
                int totAmount = valuefromXML - value;

                if (totAmount < 0)
                {
                    return false;
                }

                return add_transaction(totAmount, "Deposit", user, value);
            }
            else
            {
                return false;
            }
        }

        private Boolean add_transaction(int amount, string type, string user, int value)
        {
            XDocument doc;

            if (File.Exists(xmlPath))
            {
                doc = XDocument.Load(xmlPath);
            }
            else
            {
                doc = new XDocument(new XElement("Transactions"));
            }

            XElement transaction = new XElement("Transactions", new XElement("Type", type), new XElement("Value", value), new XElement("TotalAmount", amount), new XElement("User", user));

            doc.Root.Add(transaction);
            doc.Save(xmlPath);

            return true;
        }
    }
}

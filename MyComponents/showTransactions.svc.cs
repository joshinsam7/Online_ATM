using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Web;
using System.Xml.Linq;

namespace MyComponents
{
    public class showTransactions : IshowTransactions
    {
        private static string xmlPath = HttpContext.Current.Server.MapPath("~/App_Data/transactions.xml");

        public List<Transaction> GetTransactionHistory()
        {
            var transactions = new List<Transaction>();

            if (File.Exists(xmlPath))
            {
                XDocument doc = XDocument.Load(xmlPath);

                foreach (XElement transaction in doc.Descendants("Transaction"))
                {
                    Console.WriteLine(transaction.ToString());

                    transactions.Add(new Transaction
                    {
                        Type = transaction.Element("Type")?.Value,
                        Value = transaction.Element("Value")?.Value,
                        TotalAmount = transaction.Element("TotalAmount")?.Value,
                        User = transaction.Element("User")?.Value
                    });
                }
            }
            else
            {
                Console.WriteLine("Nothing");
            }

            return transactions;
        }
    }

    [DataContract]
    public class Transaction
    {
        [DataMember]
        public string Type { get; set; }

        [DataMember]
        public string Value { get; set; }

        [DataMember]
        public string TotalAmount { get; set; }

        [DataMember]
        public string User { get; set; }
    }
}
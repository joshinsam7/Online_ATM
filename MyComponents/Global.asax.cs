using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace MyComponents
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup

            // Initialize the XML file for transaction history
            string xmlPath = Server.MapPath("~/App_Data/transactions.xml");

            // Check if the XML file exists, if not create it
            if (!System.IO.File.Exists(xmlPath))
            {
                // Create a new XML document
                System.Xml.XmlDocument xmlDoc = new System.Xml.XmlDocument();
                System.Xml.XmlElement root = xmlDoc.CreateElement("Transactions");
                xmlDoc.AppendChild(root);

                // Create a root element
                xmlDoc.Save(xmlPath);
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web;
using System.Xml;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service" in code, svc and config file together.
public class Service : IService
{
    // creates the path to the xml file that will be used to store user info
    public static readonly string filePath = System.Web.HttpContext.Current.Server.MapPath("~/App_Data/users.xml");

    // function to store username and password
    public bool SaveUser(string username, string password)
    {
        System.Diagnostics.Debug.WriteLine(typeof(Service).FullName);

        System.Diagnostics.Debug.WriteLine("In Save Users");
        string dirPath = HttpContext.Current.Server.MapPath("~/App_Data");
        if (!Directory.Exists(dirPath))
        {
            System.Diagnostics.Debug.WriteLine("creating directory");
            Directory.CreateDirectory(dirPath);
        }
        // If the file doesn't exist, create it with root and first user
        if (!File.Exists(filePath))
        {
            System.Diagnostics.Debug.WriteLine("creating file");
            using (XmlTextWriter writer = new XmlTextWriter(filePath, null))
            {
                writer.Formatting = Formatting.Indented;
                writer.WriteStartDocument();
                // Users will act as the root
                writer.WriteStartElement("Users");
                // create a user element with the given username and password
                writer.WriteStartElement("User");
                writer.WriteElementString("Username", username);
                writer.WriteElementString("Password", password);
                writer.WriteEndElement(); // </User>
                writer.WriteEndElement(); // </Users>
                writer.WriteEndDocument();
            }
        }
        else
        {
            // Load the existing file and append
            XmlDocument doc = new XmlDocument();
            doc.Load(filePath);
            // create a user node with the given information
            XmlNode userNode = doc.CreateElement("User");
            XmlElement usernameElem = doc.CreateElement("Username");
            usernameElem.InnerText = username;
            userNode.AppendChild(usernameElem);
            XmlElement passwordElem = doc.CreateElement("Password");
            passwordElem.InnerText = password;
            userNode.AppendChild(passwordElem);
            // check if user exists before adding
            bool exists = UserExists(username, password);
            if (exists) // user already exists, so we dont need to add it to the xml file again
            {
                System.Diagnostics.Debug.WriteLine("user already exists");
                return false;
            }
            else // user is new, so we add it to the xml file
            {
                // saves the user to xml file, the file can be found in the file explorer under MyComponents -> App_Data -> Users
                System.Diagnostics.Debug.WriteLine("user doesnt exist");
                doc.DocumentElement.AppendChild(userNode);
                doc.Save(filePath);
                return true;
            }
        }
        return false;
    }

    // function used to check if a user already exists in the xml file 
    public bool UserExists(string username, string password)
    {
        System.Diagnostics.Debug.WriteLine("username: " + username);
        System.Diagnostics.Debug.WriteLine("password: " + password + "\n");
        // use xml reader
        using (XmlReader reader = XmlReader.Create(filePath))
        {
            string currUsername = "";
            string currPassword = "";
            while (reader.Read())
            {
                // for each element, check if its username and password exist
                if (reader.IsStartElement())
                {
                    if (reader.Name == "Username")
                    {
                        // read in username and set it to currUsername
                        reader.Read();
                        currUsername = reader.Value;
                        System.Diagnostics.Debug.WriteLine("curr username " + currUsername);

                    }
                    else if (reader.Name == "Password")
                    {
                        // read in password and set it to currPassword
                        reader.Read();
                        currPassword = reader.Value;
                        System.Diagnostics.Debug.WriteLine("curr password " + currPassword + "\n");

                        // check that both fields are non empty
                        if (!string.Equals(currUsername, "") && !string.Equals(currPassword, ""))
                        {
                            System.Diagnostics.Debug.WriteLine("both things are filled out\n");
                            // check if current element equals the credentials of the given user
                            if (string.Equals(username, currUsername) && string.Equals(password, currPassword)) // user exists to return true
                            {
                                System.Diagnostics.Debug.WriteLine("user exists");
                                return true;
                            }
                            else // user doesn't match, so reset curr vals and keep searching
                            {
                                currUsername = "";
                                currPassword = "";
                            }
                        }
                        else
                        {
                            System.Diagnostics.Debug.WriteLine("both things are not filled out\n");
                        }

                    }
                }

                /*if (currUsername != null && currPassword != null)
                {
                    if (currUsername == username && currPassword == password)
                    {
                        System.Diagnostics.Debug.WriteLine("user exists");
                        return true;
                    }
                    else
                    {
                        currUsername = null;
                        currPassword = null;
                    }
                }*/
            }
        }
        // if we go through the entire file without findign a matching username then the user is new
        System.Diagnostics.Debug.WriteLine("user does not exist");
        return false;
    }
}

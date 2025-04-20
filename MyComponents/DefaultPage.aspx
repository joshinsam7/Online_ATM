<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DefaultPage.aspx.cs" Inherits="MyComponents.DefaultPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Default Page</h1>
            <h2>Application and Components Summary table</h2>
            <div>
                <table border="1">
                    <tr>
                        <td style="word-wrap: break-word; white-space: normal; width: 300px;">Provider Name</td>
                        <td style="word-wrap: break-word; white-space: normal; width: 300px;">Page and component type</td>
                        <td style="word-wrap: break-word; white-space: normal; width: 300px;">Component Description</td>
                        <td style="word-wrap: break-word; white-space: normal; width: 300px;">Reasources and methods used to implement component and where it is used</td>
                    </tr>
                    <tr>
                        <td style="word-wrap: break-word; white-space: normal; width: 300px;">Xavier Flores, (you guys can add your names here too)</td>
                        <td style="word-wrap: break-word; white-space: normal; width: 300px;">DefaultPage.aspx</td>
                        <td style="word-wrap: break-word; white-space: normal; width: 300px;">Allows user to test the various components of the app.</td>
                        <td style="word-wrap: break-word; white-space: normal; width: 300px;">HTML is used to create the UI For the page.</td>

                    </tr>
                    <tr>
                        <td style="word-wrap: break-word; white-space: normal; width: 300px;">Xavier Flores</td>
                        <td style="word-wrap: break-word; white-space: normal; width: 300px;">LoginPage.aspx. Login user control.</td>
                        <td style="word-wrap: break-word; white-space: normal; width: 300px;">Provides user with a UI to login with username and password, along with a button to redirect user to "Create User Page". When valid user credentials are entered, user is taken to the "Home Page".</td>
                        <td style="word-wrap: break-word; white-space: normal; width: 300px;">LoginControl.aspx provides functionality for the login button, and redirect to "Create User Page" button. LoginControl.aspx is linked to LoginPage.aspx to provide functionality to the UI.</td>

                    </tr>
                    <tr>
                        <td style="word-wrap: break-word; white-space: normal; width: 300px;">Xavier Flores</td>
                        <td style="word-wrap: break-word; white-space: normal; width: 300px;">CreateUserPage.aspx. Create user control</td>
                        <td style="word-wrap: break-word; white-space: normal; width: 300px;">Provides user with a UI to create an account, when a user creates an account their information is saved to an xml file.</td>
                        <td style="word-wrap: break-word; white-space: normal; width: 300px;">UserInfoSotrage.cs provides functions to save user credentials to an xml file, and check if a user exists in the xml file. CreateUserControl.ascx provides functionality for the "Create User" button, and redirect to "Login Page" button. CreateUserControl.ascx is linked to CreateUserPage.aspx to provide functionality to the UI.</td>

                    </tr>
                    <tr>
                        <td style="word-wrap: break-word; white-space: normal; width: 300px;">Xavier Flores</td>
                        <td style="word-wrap: break-word; white-space: normal; width: 300px;">Cookies</td>
                        <td style="word-wrap: break-word; white-space: normal; width: 300px;">Saves a users session state, after a user logs in the cookie will save this state for the next minute.</td>
                        <td style="word-wrap: break-word; white-space: normal; width: 300px;">User cookie is created in LoginControl.ascx.cs when user clicks "Login" button and successfully logs in. Additionally, when LoginPage.aspx is loaded, LoginControl.ascx.cs checks for the existence of a cookie. If a cookie is found the user is immediatley direcred to the Home Page.</td>

                    </tr>
                    <tr>
                        <td style="word-wrap: break-word; white-space: normal; width: 300px;">Xavier Flores</td>
                        <td style="word-wrap: break-word; white-space: normal; width: 300px;">Stemming Service</td>
                        <td style="word-wrap: break-word; white-space: normal; width: 300px;">Given a list of words, the service removes their suffix's. For example: capable -> cap, creative -> creat.</td>
                        <td style="word-wrap: break-word; white-space: normal; width: 300px;">In the WSDL Stemming project, Service1.svc provides the logic for taking the input and stemming each word. Then this service is connected to the main project so it can be called in DefaultPage.aspx.cs.</td>

                    </tr>
                </table>
            </div>
            <h2>Test User Login/Create User user controls & Cookies, by Xavier Flores</h2>
            <asp:Button ID="Button1" runat="server" Text="Click here" OnClick="Button1_Click" />
            
            <h2>Test Stemming Service, by Xavier Flores</h2>
            <asp:Label ID="StemmingLabel" runat="server" Text="Enter Words to be stemmed"></asp:Label>
            <asp:TextBox ID="StemmingInput" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="StemmingButton" runat="server" Text="Click to Stem" OnClick="StemmingButton_Click" />
            <asp:Label ID="StemmingResult" runat="server" Text="Result: enter words in the following format: word1 word2 ..."></asp:Label>

        </div>
    </form>
</body>
</html>

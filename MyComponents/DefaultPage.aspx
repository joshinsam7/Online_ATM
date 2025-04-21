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
                        <td style="word-wrap: break-word; white-space: normal; width: 300px;">Xavier Flores, Joshin San, Samay Sharma</td>
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
                    <tr>
                        <td style="word-wrap: break-word; white-space: normal; width: 300px;">Joshin Sam</td>
                        <td style="word-wrap: break-word; white-space: normal; width: 300px;">wdService / withdrawDeposit.svc</td>
                        <td style="word-wrap: break-word; white-space: normal; width: 300px;">The service deposites and or withdraw money from the users account. </td>
                        <td style="word-wrap: break-word; white-space: normal; width: 300px;">In the WSDL withdrawDeposite.svc , IwithdrawDeposit provides the logic for withdrawing and depositing money and adding it into the XML database under the users account. This service is used in the Withdraw_DepositUI.aspx, and can be accessed in the Default.aspax.</td>
                    </tr>

                    <tr>
                        <td style="word-wrap: break-word; white-space: normal; width: 300px;">Joshin Sam</td>
                        <td style="word-wrap: break-word; white-space: normal; width: 300px;">Withdraw_DepositUI.aspx</td>
                        <td style="word-wrap: break-word; white-space: normal; width: 300px;">Provides user with a UI to deposit and withdraw money from their account.</td>
                        <td style="word-wrap: break-word; white-space: normal; width: 300px;">Withdraw_DepositUI.aspx.cs provides the logic for displaying the deposit and withdraw buttons. It returns a Total amount available in the users account. This file is connected to the link attached in the button of the HomePage.aspax</td>
                    </tr>
                    <tr>
                        <td style="word-wrap: break-word; white-space: normal; width: 300px;">Joshin Sam</td>
                        <td style="word-wrap: break-word; white-space: normal; width: 300px;">HomePage.aspx</td>
                        <td style="word-wrap: break-word; white-space: normal; width: 300px;">Provides user with a UI to either withdraw or deposit and view transaction history.</td>
                        <td style="word-wrap: break-word; white-space: normal; width: 300px;">HomePage.aspx.cs is just a UI web page to direct user to either Transaction web page or Withdraw_Deposit web page.</td>
                    </tr>

                    <tr>
                         <td style="word-wrap: break-word; white-space: normal; width: 300px;">Joshin Sam</td>
                         <td style="word-wrap: break-word; white-space: normal; width: 300px;">Global.asax</td>
                        <td style="word-wrap: break-word; white-space: normal; width: 300px;">This file contains the function to initialize the transactions.xml file when the application is started, if it is not initialized. </td>
                        <td style="word-wrap: break-word; white-space: normal; width: 300px;">Global.asax.cs provides the logic to intialize the xml file. his file is used in wdService, and transcation service. This is used for showing all the transaction history, and to deposit and withdraw funds from the users account.  </td>
                    </tr>
                    <tr>
                        <td style="word-wrap: break-word; white-space: normal; width: 300px;">Samay Sharma</td>
                        <td style="word-wrap: break-word; white-space: normal; width: 300px;">TransactionHistory.aspx</td>
                        <td style="word-wrap: break-word; white-space: normal; width: 300px;">Provides user with a UI to view which type of ecryption the user would like to visualize.</td>
                        <td style="word-wrap: break-word; white-space: normal; width: 300px;">TransactionHistory.aspx.cs provides the logic for displaying the transaction history.</td>
                    </tr>

                    <tr>
                        <td style="word-wrap: break-word; white-space: normal; width: 300px;">Samay Sharma</td>
                        <td style="word-wrap: break-word; white-space: normal; width: 300px;">DLL / </td>
                        <td style="word-wrap: break-word; white-space: normal; width: 300px;">This class is implemented as a WCF service and is used to encrypt username/password and its transaction details.  </td>
                        <td style="word-wrap: break-word; white-space: normal; width: 300px;"></td>
                    </tr>

                    <tr>
                        <td style="word-wrap: break-word; white-space: normal; width: 300px;">Samay Sharma</td>
                        <td style="word-wrap: break-word; white-space: normal; width: 300px;">ServiceReference1</td>
                        <td style="word-wrap: break-word; white-space: normal; width: 300px;">This is the service implemented to list all the transactions of the user from the xml database.  </td>
                        <td style="word-wrap: break-word; white-space: normal; width: 300px;">It is located in IshowTransactins.cs, showTransactions.svc, and contains the logic to output the list of transactions from the xml file.This functions are used in the TransactionsHistory.aspx.cs</td>
                    </tr>

                     <tr>
                        <td style="word-wrap: break-word; white-space: normal; width: 300px;">Samay Sharma</td>
                        <td style="word-wrap: break-word; white-space: normal; width: 300px;">TransactionEcrypt/Decrypt.aspx</td>
                        <td style="word-wrap: break-word; white-space: normal; width: 300px;">  </td>
                        <td style="word-wrap: break-word; white-space: normal; width: 300px;"></td>
                    </tr>


                    </table>
            </div>

            <h2>Test User Login/Create User user controls & Cookies, by Xavier Flores</h2>
            <asp:Button ID="Button1" runat="server" Text="Click here" OnClick="Button1_Click" />
            

            <h3>Test Depositing and Withdrawing User Control, Global.asax by Joshin Sam</h3>
            <p>This function requires user to login in at least once so that it is saved as a cookie to bypass the login page</p>
            <asp:Button ID="Button2" runat="server" Text="Click here" OnClick="Button2_Click" />


            <h3>Test DLL, TransactionHistory User Control by Samay Sharma</h3>
            <p>This function requires user to login in at least once so that it is saved as a cookie to bypass the login page, and needs to have atleast one transaction to list any details under the user account. </p>
            <asp:Button ID="Button3" runat="server" Text="Click here" OnClick="Button3_Click" />
        </div>
    </form>
</body>
</html>

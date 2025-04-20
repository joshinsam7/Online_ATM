<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="MyComponents.HomePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Home Page</h2>
            <asp:Label ID="WelcomeLabel" runat="server" Text="Welcome"></asp:Label>
            <h3>To test cookies: </h3>
            <h4 style="font-weight: normal; width: 800px;">Now that you have logged in, a cookie will store your session state for 1 minute. If you exit the application and run it again, when you press the "click here" button you will be redirected to this page as opposed to the login page. After the minute is up, the "click here" button will take you to the login page.</h4>
        </div>
    </form>
</body>
</html>

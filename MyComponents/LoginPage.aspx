<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="MyComponents.LoginPage" %>
<%@ Register Src="~/LoginControl.ascx" TagPrefix="uc" TagName="LoginControl" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login Page</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <uc:LoginControl ID="LoginControl1" runat="server" />
            <h3>To test login user control: </h3>
            <h4 style="font-weight: normal; width: 800px;">First navigate to create accout page and create an account. After doing so you can navigate back to this page and use your credentials to log in, if successful you will be taken to a home page with your username displayed.</h4>
        </div>
    </form>
</body>
</html>

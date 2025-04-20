<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateUserPage.aspx.cs" Inherits="MyComponents.CreateUserPage" %>
<%@ Register Src="~/CreateUserControl.ascx" TagPrefix="uc" TagName="CreateUserControl" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Create User Page</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <uc:CreateUserControl ID="CreateUserControl1" runat="server" />
            <h3>To test create user control: </h3>
            <h4 style="font-weight: normal; width: 800px;">Enter in a username and password and press Create User to create an account with those credentials. Then you can press the already have an account button to go back to the login page. Once an account is created, your username and passowrd will be saved, so you can use those credentials to login on future runs.</h4>
        </div>
    </form>
</body>
</html>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CreateUserControl.ascx.cs" Inherits="MyComponents.CreateUserControl" %>
<h2>Create User Page</h2>
<asp:Label ID="UsernameLabel" runat="server" Text="Enter Username " Style="margin-right: 20px"></asp:Label>
<asp:TextBox ID="UsernameTextBox" runat="server"></asp:TextBox>
<br /><br />
<asp:Label ID="PasswordLabel" runat="server" Text="Enter Password " Style="margin-right: 20px"></asp:Label>
<asp:TextBox ID="PasswordTextBox" runat="server"></asp:TextBox>
<br /><br />
<asp:Button ID="CreateUserButton" runat="server" Text="Create User" OnClick="CreateUserButton_Click" Style="margin-right: 20px"/>
<asp:Label ID="CreateUserResult" runat="server" Text=""></asp:Label>
<br /><br />
<asp:Button ID="DirectToLogin" runat="server" Text="Already have an account? Click to go to login" OnClick="DirectToLoginButton_Click" Style="margin-right: 20px"/>

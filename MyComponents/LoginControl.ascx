<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LoginControl.ascx.cs" Inherits="MyComponents.LoginControl" %>
<h2>Login Page</h2>
<asp:Label ID="UsernameLabel" runat="server" Text="Enter Username " Style="margin-right: 20px"></asp:Label>
<asp:TextBox ID="UsernameTextBox" runat="server"></asp:TextBox>
<br /><br />
<asp:Label ID="PasswordLabel" runat="server" Text="Enter Password " Style="margin-right: 20px"></asp:Label>
<asp:TextBox ID="PasswordTextBox" runat="server"></asp:TextBox>
<br /><br />
<asp:Button ID="LoginButton" runat="server" Text="Login" OnClick="LoginButton_Click" Style="margin-right: 20px"/>
<asp:Label ID="LoginResult" runat="server" Text=""></asp:Label>
<br /><br />
<asp:Button ID="DirectToCreate" runat="server" Text="New User? Click to create account" OnClick="DirectToCreateButton_Click" Style="margin-right: 20px"/>

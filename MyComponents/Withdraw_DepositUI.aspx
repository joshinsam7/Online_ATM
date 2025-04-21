<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Withdraw_DepositUI.aspx.cs" Inherits="MyComponents.Withdraw_DepositUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="text-align:center">
            
                                <br /><br />
                 <asp:Label ID="Label1" runat="server" Text="  Choose a Transaction    "></asp:Label>
            
                                <br /><br />

                <asp:Panel ID="Panel1" runat="server">
	                <asp:Panel ID="pnlWithdraw" runat="server" Visible="false">
    	                <div style="border: 1px solid black; padding: 10px;">
                               <asp:Label ID="lblAmount" runat="server" Text="Choose Withdrawal Amount:" Font-Size="Large" />
                                
                                <br /><br />

                                <asp:Button ID="btn20" runat="server" Text="$20" OnClick="Withdraw_Click" CommandArgument="20" />
                                <asp:Button ID="btn50" runat="server" Text="$50" OnClick="Withdraw_Click" CommandArgument="50" />
                                <asp:Button ID="btn100" runat="server" Text="$100" OnClick="Withdraw_Click" CommandArgument="100" />
                                <asp:Button ID="btnCustom" runat="server" Text="Custom Amount" OnClick="btnWCustom_Click" />
                                
                                 <asp:Panel ID="inputCustomW" runat="server">
                                     <asp:Label ID="Label5" runat="server" Text="Enter Amount: " />
                                        <asp:TextBox ID="txtCustomW" runat="server" />
                                    <asp:Button ID="submitCustomTransaction" runat="server" Text=" Submit" OnClick="submitCustomTransactionWithdraw_Click" />
                                 </asp:Panel>
    	                </div>
	                </asp:Panel>

	                <asp:Panel ID="pnlDeposit" runat="server" Visible="false">
                        <div style="border: 1px solid black; padding: 10px;">
                               <asp:Label ID="Label4" runat="server" Text="Choose Deposit amount:" Font-Size="Large" />
                                
                                <br /><br />

                                <asp:Button ID="Button1" runat="server" Text="$20" OnClick="deposit_Click" CommandArgument="20" />
                                <asp:Button ID="Button2" runat="server" Text="$50" OnClick="deposit_Click" CommandArgument="50" />
                                <asp:Button ID="Button3" runat="server" Text="$100" OnClick="deposit_Click" CommandArgument="100" />
                                <asp:Button ID="Button4" runat="server" Text="Custom Amount" OnClick="btnDCustom_Click" />
                                
                                 <asp:Panel ID="inputCustomD" runat="server">
                                     <asp:Label ID="Label6" runat="server" Text="Enter Amount: " />
                                        <asp:TextBox ID="TextBox1" runat="server" />
                                    <asp:Button ID="Button5" runat="server" Text=" Submit" OnClick="submitCustomTransactionDeposit_Click" />
                                 </asp:Panel>
    	                </div>
	                </asp:Panel>
                </asp:Panel>

            <br /><br />

            <asp:Button ID="withdrawButton" runat="server" Text="" OnClick="withdrawButton_Click" /> 
            <asp:Label ID="Label2" runat="server" Text="  Withdrawal    "></asp:Label>

            <br /><br />
            <asp:Button ID="depositButton" runat="server" Text="" OnClick="depositButton_Click" /> 
            <asp:Label ID="Label3" runat="server" Text="   Deposit    "></asp:Label>
          </div>

        <br /><br />
            <br /><br />
            <asp:Button ID="btnBack" runat="server" Text="Back to Home Page" OnClick="btnBack_Click" />
    </form>
</body>
</html>

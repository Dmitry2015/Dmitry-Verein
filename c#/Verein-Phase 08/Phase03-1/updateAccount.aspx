<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="updateAccount.aspx.cs" Inherits="Phase03_1.updateAccount" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
        <form id="form1" method ="get" runat="server">
    <div>
        <strong>First Name</strong>
        <asp:TextBox ID="txt_FName" runat="server"></asp:TextBox>
        <br/>
        <strong>Last Name</strong>
        <asp:TextBox ID="txt_LName" runat="server"></asp:TextBox>
        <br/>
        <strong>Username</strong>
        <asp:TextBox ID="txt_UName" runat="server"></asp:TextBox>
        <br/>
        <strong>Password</strong>

        <asp:TextBox runat="server" id="txt_Psw"></asp:TextBox>

        <asp:RegularExpressionValidator runat="server"
            ControlToValidate="txt_Psw"
            ErrorMessage="You are missing @ or #"
            ValidationExpression=".*[@#].*">
        </asp:RegularExpressionValidator>

        <asp:RegularExpressionValidator runat="server"
            ControlToValidate="txt_Psw"
            ErrorMessage="Must be between 4 and 10 characters"
            ValidationExpression="[^\s]{4,10}">
        </asp:RegularExpressionValidator>

        <br/>
        <strong>Address</strong>
        <asp:TextBox ID="txt_Addr" runat="server"></asp:TextBox>
        <br/>
        <strong>Email</strong>
        <asp:TextBox ID="txt_Email" runat="server"></asp:TextBox>
        <br/>
        <strong>Phone number</strong>
        <asp:TextBox ID="txt_Phone" runat="server"></asp:TextBox>
        <strong>Card number</strong>
        <asp:TextBox ID="txt_Card" runat="server"></asp:TextBox>
        <br/>
        <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
        <br/>
        <asp:Button ID="btnReturn" runat="server" Text="Return" OnClick="btnReturn_Click" />
        <br/>
    </div>
    </form>
</body>
</html>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Phase03_1.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>

    <form id="form1" method ="get" runat="server" >
    <div>
        <strong>WELCOME TO OUR WEB SITE!</strong>
        <br/>
        <br/>
        <br/>
        <strong>Username</strong>
        <asp:TextBox ID="txt_Uname" runat="server" />
        <br/>
        <strong>Password</strong>
        <asp:TextBox ID="txt_Psw" runat="server" TextMode="Password"></asp:TextBox>
        <br/>
        <asp:Button ID="submitButton" runat="server" Text="Login" OnClick="submitButton_Click" />
        <asp:Button ID="regButton" runat="server" Text="Register" OnClick="regButton_Click" />
        <asp:Label ID="lbl_id" runat="server"></asp:Label>
        <asp:Label ID="lbl_dName" runat="server"></asp:Label>
    </div>
    </form>
</body>
</html>

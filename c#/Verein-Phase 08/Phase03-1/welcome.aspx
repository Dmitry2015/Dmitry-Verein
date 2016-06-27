<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="welcome.aspx.cs" Inherits="Phase03_1.welcome" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
        <form id="form1" method ="get" runat="server" action ="updateAccount.aspx">
    <div>
        <strong>Welcome</strong>
        <asp:Label ID="lbl_FName" runat="server"></asp:Label>
        <asp:Label ID="lbl_dName" runat="server"></asp:Label>
        <br/>
        <br/>

        <a href="productManagement/showAllProducts.aspx" > Show all Products</a>

        <br/>
        <br/>
        <asp:Button ID="UpdateButton" runat="server" Text="Update my profile" OnClick="UpdateButton_Click" />
        <strong><asp:Label ID="lbl_id" runat="server"></asp:Label>
        </strong>
    </div>
    </form>
</body>
</html>


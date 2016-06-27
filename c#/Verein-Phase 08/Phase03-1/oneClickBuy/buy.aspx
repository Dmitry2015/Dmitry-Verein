<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="buy.aspx.cs" Inherits="Phase03_1.oneClickBuy.buy" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" method ="get" runat="server">
    <div>

    <strong>The info about the product:</strong>
    <br/>
    <strong>Product</strong>
    <asp:Label ID="lbl_PName" runat="server"></asp:Label>
    <br/>
    <strong>Description</strong>
    <asp:Label ID="lbl_Descr" runat="server"></asp:Label>
    <br/>
    <strong>Price</strong>
    <asp:Label ID="lbl_Price" runat="server"></asp:Label>
    <br/>
    <br/>

    <strong>The info about the user:</strong>
    <br/>
        <strong>First Name</strong>
        <asp:Label ID="lbl_FName" runat="server"></asp:Label>
        <br/>
        <strong>Last Name</strong>
        <asp:Label ID="lbl_LName" runat="server"></asp:Label>
        <br/>
        <strong>Username</strong>
        <asp:Label ID="lbl_UName" runat="server"></asp:Label>
        <br/>
        <strong>Address</strong>
        <asp:Label ID="lbl_Addr" runat="server"></asp:Label>
        <br/>
        <strong>Email</strong>
        <asp:Label ID="lbl_Email" runat="server"></asp:Label>
        <br/>
        <strong>Phone number</strong>
        <asp:Label ID="lbl_Phone" runat="server"></asp:Label>
        <br/>
        <strong>Card number</strong>
        <asp:Label ID="lbl_Card" runat="server"></asp:Label>
        <br/>
        <br/>
        <br/>
        <br/>
        <br/>
        <strong>Thanks for buying </strong> 
        <asp:Label ID="lbl_PName1" runat="server"></asp:Label>
        <strong> ! 
            <br/>
            Your credit card has been charged $ </strong> 
        <asp:Label ID="lbl_Price1" runat="server"></asp:Label> 
            <br/>
        <strong> and your product will be delivered</strong>
        <strong>to Address: </strong>  
        <asp:Label ID="lbl_Addr1" runat="server"></asp:Label> 
        <strong> within the next week.</strong>
        <br/>

    

    </div>
    </form>

        <asp:Label runat="server" id="lbl_dbg"/>

</body>
</html>





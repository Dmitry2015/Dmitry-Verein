<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="newProduct.aspx.cs" Inherits="Phase03_1.productManagement.newProduct" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>

            <form id="form2" method ="get" runat="server">
    <div>
    
        <strong>Name</strong>
        <asp:TextBox ID="txt_Name" runat="server"></asp:TextBox>
        <br />
        <strong>Description</strong>
        <asp:TextBox ID="txt_Descr" runat="server"></asp:TextBox>
        <br />
        <strong>Prise</strong>
        <asp:TextBox ID="txt_Prise" runat="server"></asp:TextBox>
        <br />
        <strong>Amount</strong>
        <asp:TextBox ID="txt_Amnt" runat="server"></asp:TextBox>
        <br />
        

        <asp:Button ID="btnSubmitTest" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
        <br />

    </div>
    </form>
</body>
</html>

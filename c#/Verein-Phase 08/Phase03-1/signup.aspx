<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="signup.aspx.cs" Inherits="Phase03_1.signup" %>

<!DOCTYPE html>



<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
            <form id="form2" method ="get" runat="server" >
    <div>
        <strong>First Name</strong>
        <input type="text" name="txt_FName"/>
        <br/>
        <strong>Last Name</strong>
        <input type="text" name="txt_Lname"/>
        <br/>
        <strong>Username</strong>
        <input type="text" name="txt_Uname"/>
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

        <asp:CompareValidator runat="server"
        ControlToCompare="txt_Psw"
        ControlToValidate="txt_Psw1"
        ErrorMessage="the Passwords not equal" BackColor="#CC66FF"
        ></asp:CompareValidator>

        <br/>
        <strong>Please re-enter the Password</strong>
        <asp:TextBox runat="server" id="txt_Psw1"></asp:TextBox>
        <br/>


        <strong>Address</strong>
        <input type="text" name="txt_Addr"/>
        <br/>
        <strong>Email</strong>
        <input type="text" name="txt_Email"/>
        <br/>
        <strong>Phone number</strong>
        <input type="text" name="txt_Phone"/>
        <br/>
        <strong>Card number</strong>
        <input type="text" name="txt_Card"/>
        <br/>
        <asp:Button ID="submitButton1" runat="server" Text="Submit" OnClick="submitButton1_Click" />
        <asp:Label ID="lbl_id" runat="server"></asp:Label>
    </div>
    </form>
        <asp:Label runat="server" ID="lbl_dbg"></asp:Label>
</body>
</html>
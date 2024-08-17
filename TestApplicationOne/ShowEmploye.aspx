<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowEmploye.aspx.cs" Inherits="TestApplicationOne.ShowEmploye" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="ADD" />
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="UsingFun" />

        </div>
    </form>
</body>
</html>

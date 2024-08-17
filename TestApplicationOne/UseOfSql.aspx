<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UseOfSql.aspx.cs" Inherits="TestApplicationOne.UseOfSql" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        &nbsp;<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="BookID" DataSourceID="SqlDataSource1">
                <Columns>
                    <asp:BoundField DataField="BookID" HeaderText="BookID" InsertVisible="False" ReadOnly="True" SortExpression="BookID" />
                    <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
                    <asp:BoundField DataField="Author" HeaderText="Author" SortExpression="Author" />
                    <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" />
                    <asp:BoundField DataField="Stock" HeaderText="Stock" SortExpression="Stock" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DBconn %>" SelectCommand="SELECT * FROM [Books]"></asp:SqlDataSource>
            <br />
            <br />
            <br />
            Title:&nbsp;
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />
            <br />
            Author:
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <br />
            <br />
            Price:
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            <br />
            <br />
            Stock:
            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Add Book" />
            <br />
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="UPDATE BOOK"></asp:Label>
            <br />
            Book Id
            <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
            <br />
            NewStock<asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Update" />
            <br />
            <br />
            <br />
            Delete Book
            <br />
            Enter the Book ID&nbsp; :
            <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Delete" />
            <br />
            <br />
            <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="GetStockValue" />
            <br />
            <br />
            <br />
         
            <br />
            <br />
        </div>



        <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
<asp:Button ID="Button6" runat="server" Text="Search Book" OnClick="Button5_Click" />
<asp:GridView ID="GridViewBookDetails" runat="server" AutoGenerateColumns="True"></asp:GridView>
<asp:Label ID="LabelMessage" runat="server" Text=""></asp:Label>


    </form>
</body>
</html>

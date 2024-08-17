<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TestApplicationOne._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
       <form id="form1" runat="server" class="container mt-5">
           <h1>Employee Registration</h1>
        <div class="form-group">
            <label for="TextBox1">Name</label>
            <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="TextBox2">Email</label>
            <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="TextBox3">Bank Email</label>
            <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="TextBox4">IFSC Code</label>
            <asp:TextBox ID="TextBox4" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="TextBox5">Bank AC</label>
            <asp:TextBox ID="TextBox5" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="TextBox6">PAN</label>
            <asp:TextBox ID="TextBox6" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="TextBox7">Aadhaar</label>
            <asp:TextBox ID="TextBox7" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="TextBox8">Date of Joining</label>
            <asp:TextBox ID="TextBox8" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="TextBox9">Password</label>
            <asp:TextBox ID="TextBox9" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Button ID="Button1" runat="server" Text="Register" CssClass="btn btn-primary" OnClick="Button1_Click" />
        </div>
      <div class="form-group">
       <asp:Button ID="Button2" runat="server" Text="Login" CssClass="btn btn-primary" OnClick="Button2_Click" />
   </div>
    </form>
    </main>

</asp:Content>

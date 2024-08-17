<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowBooks.aspx.cs" Inherits="TestApplicationOne.ShowBooks" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ListView ID="ListViewBooks" runat="server" OnItemCommand="ListViewBooks_ItemCommand">
                <LayoutTemplate>
                    <ul>
                        <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
                    </ul>
                </LayoutTemplate>
                <ItemTemplate>
                    <li>
                        <strong>Title:</strong> <%# Eval("Title") %><br />
                        <strong>Author:</strong> <%# Eval("Author") %><br />
                        <strong>Price:</strong> <%# Eval("Price", "{0:C}") %><br />
                        <strong>Stock:</strong> 
                        <asp:TextBox ID="TextBoxStock" runat="server" Text='<%# Eval("Stock") %>' />
                        <br />
                        <asp:Button ID="ButtonUpdate" runat="server" Text="Update" 
                            CommandName="UpdateStock" CommandArgument='<%# Eval("BookID") %>' />
                    </li>
                </ItemTemplate>
            </asp:ListView>
        </div>
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Hello.aspx.cs" Inherits="Hello.Hello" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="LabelName" runat="server" Text="Enter your name: "></asp:Label>
            <asp:TextBox ID="TextBoxName" runat="server"></asp:TextBox>
            <asp:Button ID="ButtonSayHello" runat="server" Text="Click Me!" />
        </div>
        <div>
            <asp:Label ID="LabelHello" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>

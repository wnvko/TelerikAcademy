<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="main.aspx.cs" Inherits="SessionAppendText.main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="textBoxInput" runat="server"></asp:TextBox>
            <asp:Button ID="buttonSubmit" runat="server" Text="Send Text" />
        </div>
        <div>
            <asp:Label ID="labelResult" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>

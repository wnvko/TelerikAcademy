<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="main.aspx.cs" Inherits="Escaping.main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div>
                <asp:TextBox ID="textInput" runat="server"></asp:TextBox>
            </div>
            <div>
                <asp:Button ID="buttonSubmit" runat="server" Text="Submit Text" />
            </div>
            <div>
                <asp:TextBox ID="textResult" runat="server"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="labelResult" runat="server"></asp:Label>
            </div>
        </div>
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Calculator.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Panel ID="Panel1" runat="server" Height="191px">
            <asp:TextBox ID="TextBox1" runat="server" OnTextChanged="TextBox_TextChanged" Width="49px"></asp:TextBox>
            <asp:Label ID="Label1" runat="server" Text="   +   "></asp:Label>
            <asp:TextBox ID="TextBox2" runat="server" OnTextChanged="TextBox_TextChanged" Width="50px"></asp:TextBox>
            <asp:Button ID="ButtonSum" runat="server" OnClick="OnButtonSumClick" Text="   =   " />
            <asp:TextBox ID="TextBox3" runat="server" Width="49px"></asp:TextBox>
        </asp:Panel>
    
    </div>
    </form>
</body>
</html>

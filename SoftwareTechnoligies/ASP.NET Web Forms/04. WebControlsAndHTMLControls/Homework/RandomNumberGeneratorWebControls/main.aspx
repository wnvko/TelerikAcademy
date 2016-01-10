<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="main.aspx.cs" Inherits="RandomNumberGeneratorWebControls.main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div>
                <asp:Label ID="lableMin" runat="server">Enter Min value: </asp:Label>
                <asp:TextBox ID="textMin" runat="server"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="lableMax" runat="server">Enter Max value: </asp:Label>
                <asp:TextBox ID="textMax" runat="server"></asp:TextBox>
            </div>
            <div>
                <asp:Button ID="buttonGenerate" runat="server" Text="Generate Random Number" />
            </div>
            <div>
                <asp:Label ID="labelResult" runat="server"></asp:Label>
            </div>
        </div>
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="main.aspx.cs" Inherits="Calc.main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Panel ID="panelMain" runat="server" Width="180">
            <asp:Panel ID="panelResult" runat="server">
                <asp:TextBox ID="textResult" runat="server"></asp:TextBox>
            </asp:Panel>
            <asp:Panel ID="panelInput" runat="server">
                <asp:Panel ID="panelFirstRow" runat="server">
                    <asp:Button ID="button1" runat="server" Text ="1" Width="40"/>
                    <asp:Button ID="button2" runat="server" Text ="2" Width="40"/>
                    <asp:Button ID="button3" runat="server" Text ="3" Width="40"/>
                    <asp:Button ID="buttonPlus" runat="server" Text ="+" Width="40"/>
                </asp:Panel>
                <asp:Panel ID="panelsecondRow" runat="server">
                    <asp:Button ID="button4" runat="server" Text ="4" Width="40"/>
                    <asp:Button ID="button5" runat="server" Text ="5" Width="40"/>
                    <asp:Button ID="button6" runat="server" Text ="6" Width="40"/>
                    <asp:Button ID="buttonMinus" runat="server" Text ="-" Width="40"/>
                </asp:Panel>
                <asp:Panel ID="panelThirdRow" runat="server">
                    <asp:Button ID="button7" runat="server" Text ="7" Width="40"/>
                    <asp:Button ID="button8" runat="server" Text ="8" Width="40"/>
                    <asp:Button ID="button9" runat="server" Text ="9" Width="40"/>
                    <asp:Button ID="buttonMultiply" runat="server" Text ="X" Width="40"/>
                </asp:Panel>
                <asp:Panel ID="panelFourthRow" runat="server">
                    <asp:Button ID="buttonClear" runat="server" Text ="Clear" Width="40"/>
                    <asp:Button ID="button0" runat="server" Text ="0" Width="40"/>
                    <asp:Button ID="buttonDivide" runat="server" Text ="/" Width="40"/>
                    <asp:Button ID="buttonSquareRoot" runat="server" Text ="&#8730;" Width="40"/>
                </asp:Panel>
            </asp:Panel>
            <asp:Panel ID="panelEqual" runat="server">
                <asp:Button ID="buttonEqual" runat="server" Text="=" Width="175"/>
            </asp:Panel>
        </asp:Panel>
        <asp:Label ID="labelOperand" runat="server"></asp:Label>
        <asp:Label ID="lableResult" runat="server"></asp:Label>
        <asp:Label ID="labelNewNumber" runat="server"></asp:Label>
    </form>
</body>
</html>

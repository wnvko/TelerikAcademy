<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="main.aspx.cs" Inherits="Cars.main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table id="layuotTable">
            <tr>
                <td>Choose car made</td>
                <td><asp:DropDownList ID="ddlMade" runat="server"></asp:DropDownList></td>
            </tr>
            <tr>
                <td>Choose model</td>
                <td><asp:DropDownList ID="ddlModel" runat="server"></asp:DropDownList></td>
            </tr>
            <tr>
                <td>Choose Extras</td>
                <td><asp:CheckBoxList ID="cblExtras" runat="server"></asp:CheckBoxList></td>
            </tr>
            <tr>
                <td>Choose Engine Type</td>
                <td><asp:RadioButtonList ID="rblEngine" runat="server"></asp:RadioButtonList></td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="buttonSubmit" runat="server"/>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Literal ID="literalResult" runat="server"></asp:Literal>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
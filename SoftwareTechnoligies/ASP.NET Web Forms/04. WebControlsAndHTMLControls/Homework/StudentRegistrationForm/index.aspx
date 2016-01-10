<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="StudentRegistrationForm.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div>
                <asp:Label ID="labelFirstName" runat="server">First Name: </asp:Label>
                <asp:TextBox ID="textFirstName" runat="server"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="labelLastName" runat="server">Last Name: </asp:Label>
                <asp:TextBox ID="textLastName" runat="server"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="labelFNumber" runat="server">Faculty Number: </asp:Label>
                <asp:TextBox ID="textFNumber" runat="server"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="labelUniversity" runat="server">University: </asp:Label>
                <asp:DropDownList ID="comboUniversity" runat="server" AutoPostBack="true"></asp:DropDownList>
            </div>
            <div>
                <asp:Label ID="labelSpecialty" runat="server">Specialty: </asp:Label>
                <asp:DropDownList ID="comboSpecialty" runat="server" AutoPostBack="true"></asp:DropDownList>
            </div>
            <div>
                <asp:Label ID="labelCourses" runat="server">Courses: </asp:Label>
                <asp:CheckBoxList ID="listCourses" runat="server" AutoPostBack="true"></asp:CheckBoxList>
            </div>
            <div>
                <asp:Button ID="buttonSubmit" runat="server" Text="Submit" />
            </div>
        </div>
        <asp:PlaceHolder ID="placeHolderStudent" runat="server"></asp:PlaceHolder>
    </form>
</body>
</html>

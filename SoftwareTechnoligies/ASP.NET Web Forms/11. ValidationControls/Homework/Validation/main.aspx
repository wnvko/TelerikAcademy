<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="main.aspx.cs" Inherits="Validation.main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap.min.css" type="text/css" rel="stylesheet" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="row">
            <div class="col-md-offset-2 col-md-8">
                <div class="row">
                    <asp:Panel ID="panelLogon" runat="server" GroupingText="Logon Infromation" CssClass="col-md-4 form-group">
                        <asp:Label ID="labelUserName" runat="server" Text="User Name" AssociatedControlID="tbUserName" />
                        <asp:TextBox ID="tbUserName" runat="server" ValidationGroup="vgLogon" placeholder="Enter User Name" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rvUserName" runat="server"
                            ControlToValidate="tbUserName" ErrorMessage="You must enter User name"
                            Display="Dynamic" Text="Required field" CssClass="label label-danger"
                            ValidationGroup="vgLogon"></asp:RequiredFieldValidator>
                        <br />
                        <asp:Label ID="labelPassword" runat="server" Text="Password" AssociatedControlID="tbPassword" />
                        <asp:TextBox ID="tbPassword" runat="server" ValidationGroup="vgLogon" placeholder="Enter Password" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rvPassword" runat="server"
                            ControlToValidate="tbPassword" ErrorMessage="You must enter password"
                            Display="Dynamic" Text="Required field" CssClass="label label-danger"
                            ValidationGroup="vgLogon"></asp:RequiredFieldValidator>
                        <br />
                        <asp:Label ID="labelRepeatPassword" runat="server" Text="Repeate Password" AssociatedControlID="tbRepeatePassword" />
                        <asp:TextBox ID="tbRepeatePassword" runat="server" ValidationGroup="vgLogon" placeholder="Repeate Password" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rvRepeatePassword" runat="server"
                            ControlToValidate="tbPassword" ErrorMessage="You must confirm password"
                            Display="Dynamic" Text="Required field" CssClass="label label-danger"
                            ValidationGroup="vgLogon"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="cvRepeatePassword" runat="server"
                            ControlToCompare="tbPassword" ControlToValidate="tbRepeatePassword" ErrorMessage="You must enter same passwords"
                            Display="Dynamic" Text="Passwords must match" CssClass="label label-danger"
                            ValidationGroup="vgLogon"></asp:CompareValidator>
                        <asp:ValidationSummary ID="ValidationSummary2" runat="server" DisplayMode="List" ValidationGroup="vgLogon" CssClass="alert alert-danger" />
                    </asp:Panel>
                    <asp:Panel ID="panelPersonal" runat="server" GroupingText="Personal Infromation" CssClass="col-md-4 form-group">
                        <asp:Label ID="labelFirstName" runat="server" Text="First Name" AssociatedControlID="tbFirstName" />
                        <asp:TextBox ID="tbFirstName" runat="server" ValidationGroup="vgPersonal" placeholder="Enter First Name" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rvFirstName" runat="server"
                            ControlToValidate="tbFirstName" ErrorMessage="You must enter First name"
                            Display="Dynamic" Text="Required field" CssClass="label label-danger"
                            ValidationGroup="vgPersonal"></asp:RequiredFieldValidator>
                        <br />
                        <asp:Label ID="labelLastName" runat="server" Text="Last Name" AssociatedControlID="tbLastName" />
                        <asp:TextBox ID="tbLastName" runat="server" ValidationGroup="vgPersonal" placeholder="Enter Last Name" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rvLastName" runat="server"
                            ControlToValidate="tbLastName" ErrorMessage="You must enter Last name"
                            Display="Dynamic" Text="Required field" CssClass="label label-danger"
                            ValidationGroup="vgPersonal"></asp:RequiredFieldValidator>
                        <br />
                        <asp:Label ID="labelAge" runat="server" Text="Age" AssociatedControlID="tbAge" />
                        <asp:TextBox ID="tbAge" runat="server" ValidationGroup="vgPersonal" placeholder="Enter Age" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rvAge" runat="server"
                            ControlToValidate="tbAge" ErrorMessage="You must enter Age"
                            Display="Dynamic" Text="Required field" CssClass="label label-danger"
                            ValidationGroup="vgPersonal"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revAge" runat="server"
                            ControlToValidate="tbAge" ErrorMessage="Age must be a number, I'm not kidding :)"
                            Display="Dynamic" Text="Enter a number!" CssClass="label label-danger"
                            ValidationGroup="vgPersonal" ValidationExpression="\d+"></asp:RegularExpressionValidator>
                        <asp:RangeValidator ID="rangeAge" runat="server"
                            ControlToValidate="tbAge" ErrorMessage="Age must be between 12 - 81"
                            Display="Dynamic" Text="Allowed ages 18 - 81" CssClass="label label-danger"
                            ValidationGroup="vgPersonal" MinimumValue="18" MaximumValue="81"></asp:RangeValidator>
                        <asp:ValidationSummary ID="vsPersonal" runat="server" DisplayMode="List" ValidationGroup="vgPersonal" CssClass="alert alert-danger" />
                    </asp:Panel>
                    <asp:Panel ID="panelAddress" runat="server" GroupingText="Address Infromation" CssClass="col-md-4 form-group">
                        <asp:Label ID="labelEmail" runat="server" Text="Email" AssociatedControlID="tbEmail" />
                        <asp:TextBox ID="tbEmail" runat="server" ValidationGroup="vgAddress" placeholder="Enter Email" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rvEmail" runat="server"
                            ControlToValidate="tbEmail" ErrorMessage="You must enter Email"
                            Display="Dynamic" Text="Required field" CssClass="label label-danger"
                            ValidationGroup="vgAddress"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                            ControlToValidate="tbEmail" ErrorMessage="You must enter Email, not this shit!"
                            Display="Dynamic" Text="Enter a valid Email!" CssClass="label label-danger"
                            ValidationGroup="vgAddress" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                        <br />
                        <asp:Label ID="labelAddress" runat="server" Text="Address" AssociatedControlID="tbAddress" />
                        <asp:TextBox ID="tbAddress" runat="server" ValidationGroup="vgAddress" placeholder="Enter Address" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rvAddress" runat="server"
                            ControlToValidate="tbAddress" ErrorMessage="You must enter Address"
                            Display="Dynamic" Text="Required field" CssClass="label label-danger"
                            ValidationGroup="vgAddress"></asp:RequiredFieldValidator>
                        <br />
                        <asp:Label ID="labelPhone" runat="server" Text="Phone" AssociatedControlID="tbPhone" />
                        <asp:TextBox ID="tbPhone" runat="server" ValidationGroup="vgAddress" placeholder="Enter Phone" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rvPhone" runat="server"
                            ControlToValidate="tbPhone" ErrorMessage="You must enter Phone"
                            Display="Dynamic" Text="Required field" CssClass="label label-danger"
                            ValidationGroup="vgAddress"></asp:RequiredFieldValidator>
                        <asp:ValidationSummary ID="vsAddress" runat="server" DisplayMode="List" ValidationGroup="vgAddress" CssClass="alert alert-danger" />
                    </asp:Panel>
                </div>
                <div class="row">
                    <div class="col-md-4">
                        <asp:Button ID="buttonSubmit" runat="server" Text="Submit" CssClass="btn btn-default" />
                    </div>
                    <div class="col-md-4">
                        <asp:RadioButtonList ID="rbSex" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal" CssClass="btn-group" AutoPostBack="true">
                            <asp:ListItem Value="male" class="btn btn-default">Male</asp:ListItem>
                            <asp:ListItem Value="female" class="btn btn-default">Female</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                    <div class="col-md-4">
                        <asp:CheckBoxList ID="cblBestForHim" runat="server">
                            <asp:ListItem Text="BMW"></asp:ListItem>
                            <asp:ListItem Text="Audi"></asp:ListItem>
                            <asp:ListItem Text="Mercedes"></asp:ListItem>
                        </asp:CheckBoxList>
                        <asp:CheckBoxList ID="cblBestForHer" runat="server">
                            <asp:ListItem Text="Lavazza"></asp:ListItem>
                            <asp:ListItem Text="New Brasil"></asp:ListItem>
                        </asp:CheckBoxList>
                    </div>
                </div>
            </div>
        </div>
    </form>
    <script src="https://code.jquery.com/jquery-2.2.0.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js"></script>
</body>
</html>

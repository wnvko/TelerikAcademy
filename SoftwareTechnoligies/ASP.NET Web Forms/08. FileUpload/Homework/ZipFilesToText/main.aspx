<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="main.aspx.cs" Inherits="ZipFilesToText.main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap.min.css" rel="stylesheet" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="row">
            <asp:FileUpload ID="fileUpload" runat="server" CssClass="col-md-4" />
            <asp:Button ID="buttonUpload" runat="server" Text="Upload" CssClass="col-md-2 btn btn-primary" />
        </div>
        <div class="row">
            <asp:Label ID="labelResult" runat="server" CssClass="col-md-6"></asp:Label>
        </div>
    </form>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js"></script>
</body>
</html>

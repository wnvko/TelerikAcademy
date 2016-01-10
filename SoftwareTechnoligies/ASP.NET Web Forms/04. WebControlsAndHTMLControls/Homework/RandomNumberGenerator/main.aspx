<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="main.aspx.cs" Inherits="RandomNumberGenerator.main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div>
                <span>Enter Min nimber: </span>
                <input type="text" runat="server" id="textMin" />
            </div>
            <div>
                <span>Enter Max nimber: </span>
                <input type="text" runat="server" id="textMax" />
            </div>
            <div>
                <button runat="server" id="buttonGenerate">Generate Random Number</button>
            </div>
            <div>
                <span runat="server" id="result"></span>
            </div>
        </div>
    </form>
</body>
</html>

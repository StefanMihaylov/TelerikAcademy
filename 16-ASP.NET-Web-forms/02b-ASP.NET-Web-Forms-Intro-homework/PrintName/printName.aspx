<%@ Page Language="C#"
    AutoEventWireup="true"
    CodeBehind="printName.aspx.cs"
    Inherits="PrintName.printName" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label Text="Enter your name: " runat="server" />
            <asp:TextBox ID="name" runat="server" />
        </div>
        <div>
            <asp:Button id="btnSubmit" Text="Submit" runat="server" OnClick="BtnSubmit_Click"/>
        </div>
        <div>
            <asp:Label id="result" runat="server" />
        </div>
    </form>
</body>
</html>

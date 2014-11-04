<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="AppendToSession.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="Input" runat="server"></asp:TextBox>
            <asp:Button ID="Submit" runat="server" OnClick="Submit_Click" Text="Save" />
        </div>
        <div>
            <asp:Label ID="Result" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>

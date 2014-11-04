<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RandomGenerator.aspx.cs" Inherits="RandomGenerator.RandomGenerator" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Random Generator</h1>
        <div>
            
            Range: [<asp:TextBox ID="From" runat="server"></asp:TextBox>;<asp:TextBox ID="To" runat="server"></asp:TextBox>]
            <asp:Button ID="SubmitButtom" runat="server" Text="Generate" OnClick="SubmitButtom_Click"/>
        </div>
        <div>
            Result: <asp:TextBox ID="Result" runat="server" disabled="disabled"></asp:TextBox>
        </div>
    </form>
</body>
</html>

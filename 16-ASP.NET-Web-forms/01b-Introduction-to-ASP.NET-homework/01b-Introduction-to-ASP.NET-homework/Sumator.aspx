<%@ Page Language="C#" 
    AutoEventWireup="true" 
    CodeBehind="Sumator.aspx.cs" 
    Inherits="SumatorWebForms.Sumator" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="LabelFirstNumber" runat="server" Text="First Number:" AssociatedControlID="TextBoxFirstNumber"></asp:Label>
            <asp:TextBox ID="TextBoxFirstNumber" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="LabelSecondNumber" runat="server" Text="Second Number:" AssociatedControlID="TextBoxSecondNumber"></asp:Label>
            <asp:TextBox ID="TextBoxSecondNumber" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Button ID="ButtonSum" runat="server" Text="Calculate Sum" OnClick="ButtonSum_Click" />
        </div>
        <div>
            <asp:Label ID="LabelResult" runat="server" Text="Result:"></asp:Label>
            <asp:TextBox ID="TextBoxResult" runat="server" Enabled="False"></asp:TextBox>
        </div>
    </form>
</body>
</html>

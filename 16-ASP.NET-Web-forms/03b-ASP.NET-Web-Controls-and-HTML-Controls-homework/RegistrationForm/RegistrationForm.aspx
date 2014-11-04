<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistrationForm.aspx.cs" Inherits="RegistrationForm.RegistrationForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Registration form</title>
    <link href="site.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <h2>Registration form</h2>
        <div>
            <asp:Label Text="First name:" runat="server" AssociatedControlID="firstName" />
            <asp:TextBox runat="server" ID="firstName" />
        </div>
        <div>
            <asp:Label Text="Last name:" runat="server" AssociatedControlID="lastName" />
            <asp:TextBox runat="server" ID="lastName" />
        </div>
        <div>
            <asp:Label Text="Faculty number:" runat="server" AssociatedControlID="facultyNumber" />
            <asp:TextBox runat="server" ID="facultyNumber" />
        </div>
        <div>
            <asp:Label Text="University :" runat="server" AssociatedControlID="university" />
            <asp:DropDownList runat="server" ID="university">
                <asp:ListItem Value="Sofia university" Text ="Sofia university" />
                <asp:ListItem value="Technical university - Sofia" Text="Technical university - Sofia" />
                <asp:ListItem value="MIT" Text="MIT" />
            </asp:DropDownList>
        </div>
        <div>
            <asp:Label Text="Specialty  :" runat="server" AssociatedControlID="specialty" />
            <asp:DropDownList runat="server" ID="specialty">
                <asp:ListItem Value="Computer science" Text="Computer science" />
                <asp:ListItem Value="Informatics" Text="Informatics" />
                <asp:ListItem value="Mathematics" Text="Mathematics" />
            </asp:DropDownList>
        </div>
        <div>
            <asp:Label Text="Courses  :" runat="server" AssociatedControlID="courses" />
            <asp:ListBox ID="courses" runat="server" SelectionMode="Multiple">
                <asp:ListItem value="ASP.NET Web forms" Text="ASP.NET Web forms" />
                <asp:ListItem value="ASP.NET MVC" Text="ASP.NET MVC" />
                <asp:ListItem value="Node.js" Text="Node.js" />
                <asp:ListItem value="C# fundamentals" Text="C# fundamentals" />
                <asp:ListItem value="C# OOP" Text="C# OOP" />
            </asp:ListBox>
        </div>
        <div>
            <asp:Button Text="Submit" runat="server" ID="buttonSubmit" OnClick="buttonSubmit_Click" />
        </div>
        <div>
            <asp:Label Text="" runat="server" id="result"/>
        </div>
    </form>
</body>
</html>

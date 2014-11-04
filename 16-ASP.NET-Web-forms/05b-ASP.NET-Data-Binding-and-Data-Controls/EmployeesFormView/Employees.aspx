<%@ Page Language="C#"
    AutoEventWireup="true"
    CodeBehind="Employees.aspx.cs"
    Inherits="EmployeesFormView.Employees" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Northwind Employees</title>
    <link href="site.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:GridView ID="EmployeesGridView" runat="server" AutoGenerateColumns="false">
            <Columns>
                <asp:HyperLinkField HeaderText="Full Name" DataTextField="FullName"
                    DataNavigateUrlFields="Id"
                    DataNavigateUrlFormatString="~/Employees.aspx?id={0}" />
            </Columns>
        </asp:GridView>

        <asp:FormView runat="server" ID="EmployeesFormView" ItemType="NorthwindData.Employee">
            <ItemTemplate>
                <ul>
                    <li><strong>Full name:</strong>  <%#: Item.TitleOfCourtesy + " " + Item.FirstName + " " + Item.LastName %></li>
                    <li><strong>Title:</strong>  <%#: Item.Title %></li>
                    <li><strong>Birth Date:</strong>  <%#: string.Format("{0:dd/MM/yyyy}",Item.BirthDate) %></li>
                    <li><strong>Hire Date:</strong>  <%#: string.Format("{0:dd/MM/yyyy}",Item.HireDate) %></li>
                    <li><strong>Country:</strong>  <%#: Item.Country %></li>
                    <li><strong>City:</strong>  <%#: Item.City %></li>
                    <li><strong>Address:</strong>  <%#: Item.Address %></li>
                    <li><strong>Home Phone:</strong>  <%#: Item.HomePhone %></li>
                    <li><strong>Notes:</strong>  <%#: Item.Notes %></li>
                </ul>
                <asp:HyperLink runat="server" NavigateUrl="~/Employees.aspx" Text="Close"></asp:HyperLink>
            </ItemTemplate>
        </asp:FormView>
    </form>
</body>
</html>

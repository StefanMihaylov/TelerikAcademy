<%@ Page Language="C#"
    AutoEventWireup="true"
    CodeBehind="Employees.aspx.cs"
    Inherits="EmployeesRepeater.Employees" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="description" content="The description of my page" />
    <title>Employees</title>
    <style>
        table, td, th {
            padding: 5px 10px;
            border: 1px solid black;
            border-collapse: collapse;
            text-align: center;
        }

        h2, table {
            text-align: center;
        }
    </style>
</head>
<body>
    <h2>Northwind Employees</h2>
    <form id="form1" runat="server">
        <asp:Repeater runat="server" ID="EmployeesRepeater" ItemType="NorthwindData.Employee">
            <HeaderTemplate>
                <table>
                    <tr>
                        <th>FirstName</th>
                        <th>LastName</th>
                        <th>Title</th>
                        <th>BirthDate</th>
                        <th>HireDate</th>
                        <th>Country</th>
                        <th>City</th>
                        <th>Address</th>
                        <th>HomePhone</th>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><%#: Item.FirstName %></td>
                    <td><%#: Item.LastName %></td>
                    <td><%#: Item.Title %></td>
                    <td><%#: string.Format("{0:dd/MM/yyyy}",Item.BirthDate) %></td>
                    <td><%#: string.Format("{0:dd/MM/yyyy}",Item.HireDate) %></td>
                    <td><%#: Item.Country %></td>
                    <td><%#: Item.City %></td>
                    <td><%#: Item.Address %></td>
                    <td><%#: Item.HomePhone %></td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    </form>
</body>
</html>

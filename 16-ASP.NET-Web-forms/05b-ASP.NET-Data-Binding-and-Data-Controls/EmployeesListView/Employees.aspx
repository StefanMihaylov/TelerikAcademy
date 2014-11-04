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
        <asp:ListView runat="server" ID="EmployeesListView" ItemType="NorthwindData.Employee">
            <LayoutTemplate>
                <table>
                    <thead>
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
                    </thead>
                    <tbody>
                        <asp:PlaceHolder ID="itemPlaceholder" runat="server"></asp:PlaceHolder>
                    </tbody>
                </table>
            </LayoutTemplate>
            <ItemSeparatorTemplate>
                <tr></tr>
            </ItemSeparatorTemplate>
            <ItemTemplate>
                <td><%#: Item.FirstName %></td>
                <td><%#: Item.LastName %></td>
                <td><%#: Item.Title %></td>
                <td><%#: string.Format("{0:dd/MM/yyyy}",Item.BirthDate) %></td>
                <td><%#: string.Format("{0:dd/MM/yyyy}",Item.HireDate) %></td>
                <td><%#: Item.Country %></td>
                <td><%#: Item.City %></td>
                <td><%#: Item.Address %></td>
                <td><%#: Item.HomePhone %></td>
            </ItemTemplate>
        </asp:ListView>

        <asp:DataPager ID="DataPagerEmployees" runat="server"
            PagedControlID="EmployeesListView" PageSize="5"
            QueryStringField="page">
            <Fields>
                <asp:NextPreviousPagerField ShowFirstPageButton="true" ShowNextPageButton="false" ShowPreviousPageButton="false" />
                <asp:NumericPagerField />
                <asp:NextPreviousPagerField ShowLastPageButton="true" ShowNextPageButton="false" ShowPreviousPageButton="false" />
            </Fields>
        </asp:DataPager>
    </form>
</body>
</html>

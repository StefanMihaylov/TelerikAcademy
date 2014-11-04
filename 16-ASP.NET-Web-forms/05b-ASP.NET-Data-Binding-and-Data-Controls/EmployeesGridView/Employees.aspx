<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Employees.aspx.cs" Inherits="EmployeesGridView.Employees" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Nortwind Employees</title>
    <link href="site.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:GridView id="EmployeesGridView" runat="server" AutoGenerateColumns="false">
            <Columns>
                <asp:HyperLinkField HeaderText ="Full Name" DataTextField="FullName" 
                    DataNavigateUrlFields="Id"
                    DataNavigateUrlFormatString="~/EmployeeDetails.aspx?id={0}"/>  
            </Columns>
        </asp:GridView>
    </form>
</body>
</html>

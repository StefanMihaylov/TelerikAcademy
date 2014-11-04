<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeeDetails.aspx.cs" Inherits="EmployeesGridView.EmployeeDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:DetailsView id="EmployeeDetailsView" runat="server" AutoGenerateRows="true"/>
        <asp:HyperLink NavigateUrl="~/Employees.aspx" Text="Back" runat="server" />
    </form>
</body>
</html>

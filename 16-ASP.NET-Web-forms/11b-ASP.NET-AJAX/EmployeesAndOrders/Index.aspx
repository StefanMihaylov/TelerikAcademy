<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="EmployeesAndOrders.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        .update {
            padding: 10px;
            background-color: red;
            color: yellow;
        }

        table {
            margin: 20px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager" runat="server"></asp:ScriptManager>

            <asp:UpdatePanel runat="server" ID="UpdatePanelEmployees">
                <ContentTemplate>
                    <asp:GridView runat="server" ID="EmployeeGridView" SelectMethod="EmployeeGridView_GetData" DataKeyNames="EmployeeID" AutoGenerateColumns="false" OnSelectedIndexChanged="EmployeeGridView_SelectedIndexChanged" AutoPostBack="true">
                        <Columns>
                            <asp:CommandField ShowSelectButton="true" HeaderText="Action" />
                            <asp:BoundField DataField="FirstName" HeaderText="FirstName" />
                            <asp:BoundField DataField="LastName" HeaderText="LastName" />
                        </Columns>
                    </asp:GridView>
                </ContentTemplate>
            </asp:UpdatePanel>

            <asp:UpdateProgress runat="server">
                <ProgressTemplate>
                    <div class="update">Updating ... </div>
                </ProgressTemplate>
            </asp:UpdateProgress>

            <asp:UpdatePanel runat="server" ID="UpdatePaneOrders">
                <ContentTemplate>
                    <asp:GridView runat="server" ID="OrderGridView" DataKeyNames="OrderID"
                        AutoGenerateColumns="false">
                        <Columns>
                            <asp:BoundField DataField="OrderDate" DataFormatString="{0:dd-MM-yyyy}" HeaderText="OrderDate" />
                            <asp:BoundField DataField="RequiredDate" DataFormatString="{0:dd-MM-yyyy}" HeaderText="RequiredDate" />
                            <asp:BoundField DataField="ShippedDate" DataFormatString="{0:dd-MM-yyyy}" HeaderText="ShippedDate" />
                            <asp:BoundField DataField="Customer.CompanyName" HeaderText="Customer" />
                        </Columns>
                    </asp:GridView>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </form>
</body>
</html>

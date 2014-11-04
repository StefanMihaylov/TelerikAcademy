<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="DeleteViewState.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="jquery.min.js"></script>
</head>
<body>    
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="TextBox" runat="server"></asp:TextBox>
            <asp:Button ID="SubmitButton" OnClick="SubmitButton_Click" runat="server" Text="Submit" />
            <button id="delete-viewstate">Delete ViewState</button>

            <asp:Label ID="Label" runat="server"></asp:Label>
        </div>
    </form>

    <script>
        $(document).ready(
            $("#form1").on("click", "#delete-viewstate", function () {
                $("#__VIEWSTATE").val("");
            })
        );
    </script>
</body>
</html>

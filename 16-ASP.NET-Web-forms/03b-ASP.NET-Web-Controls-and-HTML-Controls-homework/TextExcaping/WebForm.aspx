<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm.aspx.cs" Inherits="TextExcaping.WebForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h2>Text Excaping</h2>
        <div>
            <asp:TextBox runat="server" ID="Input" />
            <asp:Button Text="Submit" runat="server" ID="Button" OnClick="Button_Click" />
        </div>
        <div>
           Label: <asp:Label Text="" runat="server" ID="LabelResult" mode="Encode" />
        </div>
        <div>
           Textbox: <asp:TextBox runat="server" ID="InputResult" Enabled="False" Mode="Encode"/>
        </div>
    </form>
</body>
</html>

<%@ Page Language="C#"
    AutoEventWireup="true"
    CodeBehind="WebForm.aspx.cs"
    Inherits="MobileBg.WebForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Mobile.bg</title>
    <link href="site.css" rel="stylesheet" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="row">
            <strong>Producer:</strong>
            <asp:DropDownList ID="ProducersDropDownList" runat="server" DataTextField="Name" AutoPostBack="true" OnSelectedIndexChanged="ProducersDropDownList_SelectedIndexChanged" />
        </div>
        <div class="row">
            <strong>Model:</strong>
            <asp:DropDownList ID="ModelsDropDownList" runat="server" DataTextField="Name" />
        </div>
        <div class="row">
            <strong>Extras:</strong>
            <asp:CheckBoxList ID="ExtrasCheckBoxList" runat="server" DataTextField="Name" />
        </div>
        <div class="row">
            <strong>Engine:</strong>
            <asp:RadioButtonList ID="EngineRadioButtonList" runat="server" RepeatDirection="Horizontal" />
        </div>
        <div class="row">
            <asp:Button ID="ButtonSubmit" Text="Submit" runat="server" OnClick="ButtonSubmit_Click" />
        </div>
        <div class="row">
            <asp:Literal ID="result" runat="server"></asp:Literal>
        </div>
    </form>
</body>
</html>

<%@ Page Language="C#"
    AutoEventWireup="true"
    CodeBehind="Calculator.aspx.cs"
    Inherits="Calculator.Calculator" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Calculator</title>
    <link href="site.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:Panel runat="server" CssClass="panel">
            <asp:TextBox runat="server" ID="result" Enabled="False" />
        </asp:Panel>
        <asp:Panel runat="server" CssClass="panel">
            <p>
                <asp:Button CssClass="button" Text="7" runat="server" CommandName="digit" CommandArgument="7" OnCommand="buttonCommand" />
                <asp:Button CssClass="button" Text="8" runat="server" CommandName="digit" CommandArgument="8" OnCommand="buttonCommand" />
                <asp:Button CssClass="button" Text="9" runat="server" CommandName="digit" CommandArgument="9" OnCommand="buttonCommand" />
                <asp:Button CssClass="button" Text="+" runat="server" CommandName="operand" CommandArgument="+" OnCommand="buttonCommand" />
            </p>
            <p>
                <asp:Button CssClass="button" Text="4" runat="server" CommandName="digit" CommandArgument="4" OnCommand="buttonCommand" />
                <asp:Button CssClass="button" Text="5" runat="server" CommandName="digit" CommandArgument="5" OnCommand="buttonCommand" />
                <asp:Button CssClass="button" Text="6" runat="server" CommandName="digit" CommandArgument="6" OnCommand="buttonCommand" />
                <asp:Button CssClass="button" Text="-" runat="server" CommandName="operand" CommandArgument="-" OnCommand="buttonCommand" />
            </p>
            <p>
                <asp:Button CssClass="button" Text="1" runat="server" CommandName="digit" CommandArgument="1" OnCommand="buttonCommand" />
                <asp:Button CssClass="button" Text="2" runat="server" CommandName="digit" CommandArgument="2" OnCommand="buttonCommand" />
                <asp:Button CssClass="button" Text="3" runat="server" CommandName="digit" CommandArgument="3" OnCommand="buttonCommand" />
                <asp:Button CssClass="button" Text="*" runat="server" CommandName="operand" CommandArgument="*" OnCommand="buttonCommand" />
            </p>
            <p>
                <asp:Button CssClass="button" Text="C" runat="server" CommandName="clear" OnCommand="buttonCommand" />
                <asp:Button CssClass="button" Text="0" runat="server" CommandName="digit" CommandArgument="0" OnCommand="buttonCommand" />
                <asp:Button CssClass="button" Text="&radic;" runat="server" CommandName="root" OnCommand="buttonCommand" />
                <asp:Button CssClass="button" Text="/" runat="server" CommandName="operand" CommandArgument="/" OnCommand="buttonCommand" />
            </p>
        </asp:Panel>
        <asp:Panel runat="server" CssClass="panel">
            <asp:Button CssClass="button" Text="=" runat="server" CommandName="result" OnCommand="buttonCommand" />
        </asp:Panel>
    </form>
</body>
</html>

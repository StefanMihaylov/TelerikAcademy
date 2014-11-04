<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="SimpleChat.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Chat</title>
    <style>
        body {
            text-align: center;
        }

        .board {
            margin: 0 auto;
            width: 500px;
            height: 500px;
            border: 1px solid black;
            text-align: left;
            overflow-y: scroll;
            overflow-x: hidden;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager" runat="server" />
            <h3>Messages</h3>
            <asp:UpdatePanel runat="server" ID="UpdatePanelMessages" class="board">
                <Triggers>
                       <asp:AsyncPostBackTrigger EventName="Tick" ControlID="TimerTimeRefresh" />
                </Triggers>
                <ContentTemplate>
                    <asp:ListView runat="server" ID="ListVewMessages" ItemType="SimpleChat.Message" DataKeyNames="MessageId">
                        <LayoutTemplate>
                            <ul>
                                <li runat="server" id="itemPlaceholder"></li>
                            </ul>
                        </LayoutTemplate>
                        <ItemTemplate>
                            <li> <%#: Item.Username %>: [<%#: Item.PostDate.ToString("hh:mm:ss") %>] <%#: Item.Content %></li>
                        </ItemTemplate>
                    </asp:ListView>
                </ContentTemplate>
            </asp:UpdatePanel>
            <div>
                <asp:TextBox runat="server" ID="TextBoxUserName" placeholder="Enter your username" />
                <asp:TextBox runat="server" ID="TextBoxNewMessage" placeholder="Enter new message..." />
                <asp:Button runat="server" ID="ButtonSend" Text="Send" OnClick="ButtonSend_Click" />
            </div>
            <asp:Timer ID="TimerTimeRefresh" runat="Server" Interval="500"/>
        </div>
    </form>
    <script>
        var myDiv = document.getElementById("UpdatePanelMessages");
        myDiv.scrollTop = myDiv.scrollHeight;
    </script>
</body>
</html>

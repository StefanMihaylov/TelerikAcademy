<%@ Page Title="Chat" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ChatChannel.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">    
    <h3>Messages</h3>
    <asp:UpdatePanel runat="server" ID="UpdatePanelMessages" class="board">
        <Triggers>
            <asp:AsyncPostBackTrigger EventName="Tick" ControlID="TimerTimeRefresh" />
        </Triggers>
        <ContentTemplate>
            <asp:ListView runat="server" ID="ListVewMessages" ItemType="ChatChannel.Models.Message" DataKeyNames="MessageId">
                <LayoutTemplate>
                    <ul>
                        <li runat="server" id="itemPlaceholder"></li>
                    </ul>
                </LayoutTemplate>
                <ItemTemplate>
                    <li><%#: Item.Author.FullName %>: [<%#: Item.PostDate.ToString("hh:mm:ss") %>] <%#: Item.Content %></li>
                </ItemTemplate>
            </asp:ListView>
        </ContentTemplate>
    </asp:UpdatePanel>
    <div>
        <asp:TextBox runat="server" ID="TextBoxNewMessage" placeholder="Enter new message..." />
        <asp:Button runat="server" ID="ButtonSend" Text="Send" OnClick="ButtonSend_Click" />
    </div>
    <asp:Timer ID="TimerTimeRefresh" runat="Server" Interval="500" />
</asp:Content>

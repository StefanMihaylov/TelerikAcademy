<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MenuControl.ascx.cs" Inherits="MenuControl.Control.MenuControl" %>

<asp:DataList runat="server" ID="DataListMenu" ItemType="MenuControl.Control.CustomMenuItem">
    <ItemTemplate>
        <asp:HyperLink runat="server" id="MenuItemLink" 
            NavigateUrl='<%# Item.Url %>' Text='<%#: Item.Name %>' ForeColor='<%# Item.FontColor %>'/>
    </ItemTemplate>
</asp:DataList>

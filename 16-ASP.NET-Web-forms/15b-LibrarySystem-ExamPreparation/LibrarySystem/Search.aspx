<%@ Page Title="Search" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="LibrarySystem.Search" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Search results for Query "<asp:Literal ID="LiteralQuery" runat="server" Mode="Encode" />"</h1>

    <asp:Repeater runat="server" ID="RepeaterSearch" ItemType="LibrarySystem.Models.Book"
        SelectMethod="RepeaterSearch_GetData">
        <HeaderTemplate>
            <ul>
        </HeaderTemplate>
        <ItemTemplate>
            <li>
                <asp:HyperLink runat="server" NavigateUrl='<%# string.Format("/BooksDetails?id={0}", Item.BookId) %>'
                    Text='<%# string.Format("{0} <i>by {1} </i>", Item.Title, Item.Author)  %>' />
                <%#: string.Format(" (Category {0})",Item.Category.Name) %>
            </li>
        </ItemTemplate>
        <FooterTemplate>
            </ul>
        </FooterTemplate>
    </asp:Repeater>

    <div>
        <asp:HyperLink Text="Back to Home" runat="server" NavigateUrl="/" />
    </div>
</asp:Content>

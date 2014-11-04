<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BooksDetails.aspx.cs" Inherits="LibrarySystem.BooksDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1><%:Page.Title %></h1>

    <asp:FormView runat="server" ID="FormViewBooksDetails"
        SelectMethod="FormViewBooksDetails_GetItem"
        ItemType="LibrarySystem.Models.Book">
        <ItemTemplate>
            <p>
                <h3 class="well"><%#: Item.Title %></h3>
            </p>
            <p>by <i><%#: Item.Author %> </i></p>
            <p runat="server" visible="<%# Item.ISBN != null %>"> <i>ISBN <%#: Item.ISBN %></i> </p>
            <p runat="server" visible="<%# Item.WebSite != null %>">
                Web site:
                <asp:HyperLink NavigateUrl="<%#: Item.WebSite %>" Text="<%#: Item.WebSite %>" runat="server" />
            </p>
            <p><%#: Item.Description %> </p>
        </ItemTemplate>
    </asp:FormView>
    <div>
        <asp:HyperLink Text="Back to Home" runat="server" NavigateUrl="/" />
    </div>
</asp:Content>

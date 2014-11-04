<%@ Page Title="Books" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Books.aspx.cs" Inherits="LibrarySystem.Books" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-2">
            <h1><%:Page.Title %></h1>
        </div>
        <div class="col-md-10">
            <div class="pull-right">
                <asp:TextBox runat="server" ID="TextBoxSearch" Placeholder="Search by author/title" />
                <asp:Button Text="Search" runat="server" ID="SearchButton" CssClass="btn btn-info"
                    OnClick="SearchButton_Click" />
            </div>
        </div>
    </div>
    <div class="row">
        <asp:ListView runat="server" ID="ListViewCategories" ItemType="LibrarySystem.Models.Category" SelectMethod="ListViewCategories_GetData" GroupItemCount="3">
            <GroupTemplate>
                <div class="row">
                    <asp:PlaceHolder runat="server" ID="ItemPlaceholder" />
                </div>
            </GroupTemplate>
            <ItemTemplate>
                <div class="col-md-4">
                    <h2><%#: Item.Name %></h2>
                    <asp:ListView runat="server" ID="ListViewBooks" ItemType="LibrarySystem.Models.Book" DataSource="<%# Item.Books %>">
                        <LayoutTemplate>
                            <ul>
                                <asp:PlaceHolder runat="server" ID="ItemPlaceholder" />
                            </ul>
                        </LayoutTemplate>
                        <EmptyDataTemplate>
                            <div>No books in this category</div>
                        </EmptyDataTemplate>

                        <ItemTemplate>
                            <li>
                                <asp:HyperLink runat="server" ID="HyperLinkBooks"
                                    NavigateUrl='<%#: String.Format("~/BooksDetails.aspx?id={0}",Item.BookId) %>'
                                    Text='<%# String.Format("{0} by <i>{1}</i>", Server.HtmlEncode(Item.Title), Server.HtmlEncode(Item.Author)) %>' />
                            </li>
                        </ItemTemplate>
                    </asp:ListView>
                </div>
            </ItemTemplate>
        </asp:ListView>
    </div>


</asp:Content>

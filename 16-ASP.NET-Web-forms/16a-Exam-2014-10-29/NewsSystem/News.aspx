<%@ Page Title="News" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="News.aspx.cs" 
    Inherits="NewsSystem.News" Culture="en-US"%>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1><%:Page.Title %></h1>
    <h2>Most popular articles</h2>

    <asp:ListView runat="server" ID="ListViewTopArticles"
        SelectMethod="ListViewTopArticles_GetData"
        ItemType="NewsSystem.Models.Article">
        <EmptyDataTemplate>
            <div runat="server" style="">
                No atricles was found.
            </div>
        </EmptyDataTemplate>
        <ItemTemplate>
            <div class="row">
                <h3>
                    <asp:HyperLink NavigateUrl='<%# string.Format("~/ViewArticle.aspx?id={0}", Item.ArticleId) %>'
                        runat="server" Text="<%#:Item.Title %>" />
                    <small><%#: Item.Category.Name %></small>
                </h3>
                <p>
                    <%#: GetContent(Item.Content) %>
                </p>
                <p>Likes: <%# GetLikes(Item.Likes) %></p>
                <div>
                    <i>by <%#: Item.Author.UserName %>></i>
                    <i>created on: <%#: Item.DateCreated %></i>
                </div>
            </div>
        </ItemTemplate>
    </asp:ListView>

    <h2>All categories</h2>
    <asp:ListView runat="server" GroupItemCount="2" ID="ListViewTopCalegories"
        ItemType="NewsSystem.Models.Category"
        SelectMethod="ListViewTopCalegories_GetData">
        <GroupTemplate>
            <div class="row">
                <asp:PlaceHolder runat="server" ID="itemPlaceholder" />
            </div>
        </GroupTemplate>
        <ItemTemplate>
            <div class="col-md-6">
                <h3><%#: Item.Name %></h3>
                <asp:ListView runat="server" ID="ListViewArticles"
                    ItemType="NewsSystem.Models.Article" DataSource="<%# GetLatestArticles(Item.Articles) %>">
                    <LayoutTemplate>
                        <ul>
                            <asp:PlaceHolder runat="server" ID="itemPlaceholder" />
                        </ul>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <li>
                            <asp:HyperLink runat="server"
                                NavigateUrl='<%# string.Format("~/ViewArticle.aspx?id={0}", Item.ArticleId) %>'
                                Text='<%# string.Format("<strong>{0}</strong> <i> by {1}</i>", Item.Title, Item.Author.UserName) %>' />
                        </li>
                    </ItemTemplate>
                    <EmptyDataTemplate>
                        No articles.
                    </EmptyDataTemplate>
                </asp:ListView>
            </div>
        </ItemTemplate>
    </asp:ListView>

</asp:Content>

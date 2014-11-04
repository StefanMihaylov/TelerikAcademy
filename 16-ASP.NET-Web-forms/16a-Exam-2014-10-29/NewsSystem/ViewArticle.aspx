<%@ Page Title="View Article" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewArticle.aspx.cs" Inherits="NewsSystem.ViewArticle" Culture="en-US" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:FormView runat="server" ID="FormViewArticle"
        ItemType="NewsSystem.Models.Article"
        SelectMethod="FormViewArticle_GetItem" DataKeyNames="">
        <ItemTemplate>
            <table cellspacing="0" style="border-collapse: collapse;">
                <tbody>
                    <tr>
                        <td>
                            <div id="LikeButtons" runat="server">
                                <asp:UpdatePanel runat="server" ID="updatePanelInsertBook" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <div class="like-control col-md-1">
                                            <div>Likes</div>
                                            <div>
                                                <asp:LinkButton ID="ButtonLike" runat="server"
                                                    CssClass="btn btn-default glyphicon glyphicon-chevron-up"
                                                    OnClick="ButtonLike_Click" />
                                                <asp:Label id="LikesCount" Text="<%# GetLikes() %>" runat="server" CssClass="like-value" />
                                                <asp:LinkButton ID="ButtonDislike" runat="server"
                                                    CssClass="btn btn-default glyphicon glyphicon-chevron-down"
                                                    OnClick="ButtonDislike_Click" />
                                            </div>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </td>
                        <td>
                            <h2><%#: Item.Title %> <small>Category: <%#: Item.Category.Name %></small></h2>
                            <p><%#: Item.Content %></p>
                            <p>
                                <span>Author: <%#: Item.Author.UserName %></span>
                                <span class="pull-right"><%#:Item.DateCreated %></span>
                            </p>
                        </td>
                    </tr>
                </tbody>
            </table>
        </ItemTemplate>
    </asp:FormView>
    <div>
        <asp:HyperLink NavigateUrl="/" runat="server" Text="Back to Home" />
    </div>
</asp:Content>

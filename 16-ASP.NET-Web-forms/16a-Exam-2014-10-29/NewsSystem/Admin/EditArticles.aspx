<%@ Page Title="Edit Articles" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditArticles.aspx.cs" Inherits="NewsSystem.Admin.EditArticles" Culture="en-US" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ListView ID="ListViewEditArticles" runat="server" ItemType="NewsSystem.Models.Article"
        SelectMethod="ListViewEditArticles_GetData"
        InsertMethod="ListViewEditArticles_InsertItem"
        DeleteMethod="ListViewEditArticles_DeleteItem"
        UpdateMethod="ListViewEditArticles_UpdateItem"
        DataKeyNames="ArticleId"
        OnItemInserted="ListViewEditArticles_ItemInserted">
        <LayoutTemplate>
            <div class="row">
                <asp:LinkButton ID="ListViewSortTitle" runat="server" Text="Sort by Title"
                    CommandName="Sort" CommandArgument="Title" CssClass="col-md-2 btn btn-default" />
                <asp:LinkButton ID="LinkButtonSortByDate" runat="server" Text="Sort by Date"
                    CommandName="Sort" CommandArgument="DateCreated" CssClass="col-md-2 btn btn-default" />
                <%--                <asp:LinkButton ID="LinkButtonSortByCategory" runat="server" Text="Sort by Category"
                    CommandName="Sort" CommandArgument="Category" CssClass="col-md-2 btn btn-default" />
                <asp:LinkButton ID="LinkButtonSortByLikes" runat="server" Text="Sort by Likes"
                    CommandName="Sort" CommandArgument="Likes" CssClass="col-md-2 btn btn-default" />--%>
            </div>
            <asp:PlaceHolder runat="server" ID="itemPlaceholder" />
            <div class="row">
                <div class="col-md-3">
                    <asp:DataPager ID="DataPager" runat="server" PageSize="5">
                        <Fields>
                            <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="false" ShowNextPageButton="false" ShowPreviousPageButton="true" />
                            <asp:NumericPagerField />
                            <asp:NextPreviousPagerField ButtonType="Button" ShowLastPageButton="false" ShowNextPageButton="true" ShowPreviousPageButton="false" />
                        </Fields>
                    </asp:DataPager>
                </div>
                <div class="col-md-3">
                    <asp:Button ID="ButtonInsertArticle" runat="server" Text="Insert New Article" OnClick="ButtonInsertArticle_Click" CssClass="btn btn-primary" />
                </div>
            </div>
        </LayoutTemplate>
        <ItemTemplate>
            <div class="row">
                <h3><%#:Item.Title %>
                    <asp:LinkButton ID="ButtonEdit" runat="server" CssClass="btn btn-info"
                        CommandName="Edit" Text="Edit" />
                    <asp:LinkButton ID="ButtonDelete" runat="server"
                        CommandName="Delete" Text="Delete" CssClass="btn btn-danger"
                        OnClientClick=<%# string.Format("return confirm('Do you want to delete Article \"{0}\"?')", Item.Title) %> />
                </h3>
                <p>Category: <%#: Item.Category.Name %></p>
                <p>
                    <%#: GetContent(Item.Content) %>
                </p>
                <p>Likes count: <%# Item.Likes.Sum(z => z.Value) %> </p>
                <div>
                    <i>by <%#: Item.Author.UserName %></i>
                    <i>created on: <%#: Item.DateCreated %></i>
                </div>
            </div>
        </ItemTemplate>
        <EditItemTemplate>
            <div class="row">
                <h3>Title:			       
                    <asp:TextBox ID="TextBoxEditTitle" runat="server" Text="<%# BindItem.Title %>" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorTitle" ControlToValidate="TextBoxEditTitle" runat="server" Display="Dynamic" Text="Required Field" ErrorMessage="Title field is required!" ForeColor="Red" />
                </h3>
                <p>
                    Category:                                    
                    <asp:DropDownList ID="DropDownListCategories" runat="server"
                        SelectMethod="SelectCategories"
                        DataValueField="CategoryId"
                        DataTextField="Name"
                        SelectedValue="<%# BindItem.CategoryId %>"
                        AppendDataBoundItems="true">
                        <asp:ListItem Text="(no categoty)" Value="" />
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorCategory" ControlToValidate="DropDownListCategories" runat="server" Display="Dynamic" Text="Required Field" ErrorMessage="Category field is required!" ForeColor="Red" />
                </p>
                <p>
                    Content:		
                    <asp:TextBox ID="TextBoxEditContent" runat="server" Text="<%# BindItem.Content %>" TextMode="MultiLine" Rows="6" Columns="100" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorContent" ControlToValidate="TextBoxEditContent" runat="server" Display="Dynamic" Text="Required Field" ErrorMessage="Content field is required!" ForeColor="Red" />
                </p>
                <asp:ValidationSummary runat="server" ForeColor="Red" />
                <div>
                    <asp:Button ID="UpdateButton" runat="server" CssClass="btn btn-success" CommandName="Update" Text="Save" />
                    <asp:Button ID="Button1" runat="server" CssClass="btn btn-danger" CommandName="Cancel" Text="Cancel" CausesValidation="False" />
                </div>
            </div>
        </EditItemTemplate>
        <InsertItemTemplate>
            <div class="row">
                <asp:Label ID="LabelInsertErrors" runat="server" CssClass="errors" />
                <h3>Title:			       
                    <asp:TextBox ID="TextBoxInsertTitle" runat="server" Text="<%# BindItem.Title %>" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorTitle" ControlToValidate="TextBoxInsertTitle" runat="server" Display="Dynamic" Text="Required Field" ErrorMessage="Title field is required!" ForeColor="Red" />
                </h3>
                <p>
                    Category:                                    
                    <asp:DropDownList ID="DropDownListCategories" runat="server"
                        SelectMethod="SelectCategories"
                        DataValueField="CategoryId"
                        DataTextField="Name"
                        SelectedValue="<%# BindItem.CategoryId %>"
                        AppendDataBoundItems="true">
                        <asp:ListItem Text="(no categoty)" Value="" />
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorCategory" ControlToValidate="DropDownListCategories" runat="server" Display="Dynamic" Text="Required Field" ErrorMessage="Category field is required!" ForeColor="Red" />
                </p>
                <p>
                    Content:		
                    <asp:TextBox ID="TextBoxInsertContent" runat="server" Text="<%# BindItem.Content %>" TextMode="MultiLine" Rows="6" Columns="60" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorContent" ControlToValidate="TextBoxInsertContent" runat="server" Display="Dynamic" Text="Required Field" ErrorMessage="Content field is required!" ForeColor="Red" />
                </p>
                <asp:ValidationSummary runat="server" ForeColor="Red" />
                <div>
                    <asp:Button ID="InsertButton" runat="server" CssClass="btn btn-primary" CommandName="Insert" Text="Save" />
                    <asp:Button ID="ClearButton" runat="server" CssClass="btn btn-danger" CommandName="Cancel" Text="Clear" CausesValidation="False" />
                    <asp:Button ID="CancelButton" runat="server" CssClass="btn" Text="Cancel" OnClick="CancelButton_Click" CausesValidation="False" />
                </div>
            </div>
        </InsertItemTemplate>
    </asp:ListView>
</asp:Content>

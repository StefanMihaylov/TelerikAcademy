<%@ Page Title="Edit categories" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditCategories.aspx.cs" Inherits="LibrarySystem.Admin.EditCategories" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1><%: Page.Title %></h1>

    <asp:ListView ID="EditCategoryListView" runat="server" ItemType="LibrarySystem.Models.Category"
        SelectMethod="EditCategoryListView_GetData"
        InsertMethod="EditCategoryListView_InsertItem"
        DeleteMethod="EditCategoryListView_DeleteItem"
        UpdateMethod="EditCategoryListView_UpdateItem"
        DataKeyNames="CategoryId"
        OnItemInserted="EditCategoryListView_ItemInserted">
        <LayoutTemplate>
            <div class="row text-center">
                <div class="col-md-6 col-offset-3">
                    <table class="table table-striped table-hover">
                        <thead>
                            <tr class="active">
                                <th class="text-center">
                                    <asp:LinkButton ID="ListViewSortName" runat="server" Text=" Category Name" CommandName="Sort" CommandArgument="Name" />
                                </th>
                                <th class="text-center">Action</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:PlaceHolder runat="server" ID="ItemPlaceholder" />
                        </tbody>
                    </table>
                    <div class="col-md-2">
                        <asp:Button ID="ButtonInsertCategory" runat="server" Text="Insert" OnClick="ButtonInsertCategory_Click" />
                    </div>
                    <div class="col-md-8">
                        <asp:DataPager ID="DataPager" runat="server" PageSize="5">
                            <Fields>
                                <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
                                <asp:NumericPagerField />
                                <asp:NextPreviousPagerField ButtonType="Button" ShowLastPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
                            </Fields>
                        </asp:DataPager>
                    </div>
                    <div class="col-md-2">
                    </div>
                </div>
            </div>
        </LayoutTemplate>
        <EmptyDataTemplate>
            <table runat="server" style="">
                <tr>
                    <td>No data was returned.</td>
                </tr>
            </table>
        </EmptyDataTemplate>
        <ItemSeparatorTemplate>
            <tr>
                <asp:PlaceHolder runat="server" ID="ItemPlaceholder" />
            </tr>
        </ItemSeparatorTemplate>
        <ItemTemplate>
            <td><%#: Item.Name %></td>
            <td>
                <asp:LinkButton ID="ButtonEdit" runat="server" CommandName="Edit" Text="Edit" />
                <asp:LinkButton ID="ButtonDelete" runat="server" CommandName="Delete" Text="Delete" />
            </td>
        </ItemTemplate>
        <InsertItemTemplate>
            <td>
                <asp:TextBox ID="NameTextBox" runat="server" Text='<%# Bind("Name") %>' />
            </td>
            <td>
                <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="Insert" />
                <asp:Button ID="ClearButton" runat="server" CommandName="Cancel" Text="Clear" />
                <asp:Button ID="CancelButton" runat="server" Text="Cancel" OnClick="CancelButton_Click" />
            </td>
        </InsertItemTemplate>
        <EditItemTemplate>
            <insertitemtemplate>
            <td>
                <asp:TextBox ID="NameTextBox" runat="server" Text='<%# Bind("Name") %>' />
            </td>
            <td>
                <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="Update" />
                <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancel" />
            </td>
        </insertitemtemplate>
        </EditItemTemplate>
    </asp:ListView>
</asp:Content>

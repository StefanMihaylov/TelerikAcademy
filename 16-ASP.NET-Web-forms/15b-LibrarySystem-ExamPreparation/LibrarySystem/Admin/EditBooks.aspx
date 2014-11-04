<%@ Page Title="Edit Books" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditBooks.aspx.cs" Inherits="LibrarySystem.Admin.EditBooks" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1><%: Page.Title %></h1>
    <asp:ListView runat="server" ID="ListViewBooks" ItemType="LibrarySystem.Models.Book"
        DataKeyNames="BookId"
        SelectMethod="ListViewBooks_GetData"
        UpdateMethod="ListViewBooks_UpdateItem"
        DeleteMethod="ListViewBooks_DeleteItem"
        InsertMethod="ListViewBooks_InsertItem"
        OnItemInserted="ListViewBooks_ItemInserted">
        <LayoutTemplate>
            <div class="row">
                <div>
                    <table class="table table-striped table-hover">
                        <thead>
                            <tr>
                                <th>
                                    <asp:LinkButton ID="ListViewSortTitle" runat="server" Text="Title" CommandName="Sort" CommandArgument="Title" />
                                </th>
                                <th>
                                    <asp:LinkButton ID="LinkButtonAuthor" runat="server" Text="Author" CommandName="Sort" CommandArgument="Author" />
                                </th>
                                <th>
                                    <asp:LinkButton ID="LinkButton1" runat="server" Text="ISBN" CommandName="Sort" CommandArgument="ISBN" />
                                </th>
                                <th>
                                    <asp:LinkButton ID="LinkButton2" runat="server" Text="WebSite" CommandName="Sort" CommandArgument="WebSite" />
                                </th>
                                <th>
                                    <asp:LinkButton ID="LinkButton3" runat="server" Text="Category" CommandName="Sort" CommandArgument="Category" />
                                </th>
                                <th>Action</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:PlaceHolder runat="server" ID="itemPlaceholder" />
                        </tbody>
                    </table>
                </div>
                <div class="row">
                    <div class="col-md-2">
                        <asp:Button ID="ButtonInsertBook" runat="server" Text="Insert" OnClick="ButtonInsertBook_Click" />
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
        <ItemTemplate>
            <tr>
                <td><%#: Item.Title %></td>
                <td><%#: Item.Author %></td>
                <td><%#: Item.ISBN %></td>
                <td>
                    <asp:HyperLink NavigateUrl="<%#: Item.WebSite %>" runat="server" Text="<%#: Item.WebSite %>" />
                </td>
                <td><%#: Item.Category.Name %></td>
                <td>
                    <asp:LinkButton ID="ButtonEdit" runat="server" CommandName="Edit" Text="Edit" />
                    <asp:LinkButton ID="ButtonDelete" runat="server" CommandName="Delete" Text="Delete"
                        OnClientClick=<%# string.Format("return confirm('Do you want to delete book \"{0}\"?')", Item.Title) %> />
                </td>
            </tr>
        </ItemTemplate>
        <EditItemTemplate>
            <tr>

                <td>
                    <asp:TextBox ID="TitleTextBox" runat="server" Text='<%# BindItem.Title %>' />
                </td>
                <td>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# BindItem.Author %>' />
                </td>
                <td>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# BindItem.ISBN %>' />
                </td>
                <td>
                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# BindItem.WebSite %>' TextMode="Url" />
                </td>
                <td>
                    <asp:DropDownList ID="DropDownListCategories" runat="server"
                        SelectMethod="SelectCategories"
                        DataValueField="CategoryId"
                        DataTextField="Name"
                        SelectedValue="<%# BindItem.CategoryId %>"
                        AppendDataBoundItems="true">
                        <asp:ListItem Text="(no categoty)" Value="" />
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="Update" />
                    <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancel" />
                </td>
            </tr>
            <tr>
                <td colspan="6">Description:
                    <asp:TextBox ID="TextBox4" runat="server" Text='<%# BindItem.Description %>' TextMode="MultiLine" />
                </td>
            </tr>
        </EditItemTemplate>
        <InsertItemTemplate>
            <tr>
                <td>
                    <asp:TextBox ID="TitleTextBox" runat="server" Text='<%# BindItem.Title %>' />
                </td>
                <td>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# BindItem.Author %>' />
                </td>
                <td>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# BindItem.ISBN %>' />
                </td>
                <td>
                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# BindItem.WebSite %>' TextMode="Url" />
                </td>
                <td>
                    <asp:DropDownList ID="DropDownListCategories" runat="server"
                        SelectMethod="SelectCategories"
                        DataValueField="CategoryId"
                        DataTextField="Name"
                        SelectedValue="<%# BindItem.CategoryId %>"
                        AppendDataBoundItems="true">
                        <asp:ListItem Text="(no categoty)" Value="" />
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="Insert" />
                    <asp:Button ID="ClearButton" runat="server" CommandName="Cancel" Text="Clear" />
                    <asp:Button ID="CancelButton" runat="server" Text="Cancel" OnClick="CancelButton_Click" />
                </td>
            </tr>
            <tr>
                <td colspan="6">Description:
                    <asp:TextBox ID="TextBox4" runat="server" Text='<%# BindItem.Description %>' TextMode="MultiLine" />
                </td>
            </tr>
        </InsertItemTemplate>
    </asp:ListView>


    <asp:LinkButton ID="LinkButtonInsertBook" runat="server" Text="Insert2" OnClick="LinkButtonInsertBook_Click" />
    <asp:UpdatePanel runat="server" ID="updatePanelInsertBook">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="LinkButtonInsertBook" EventName="Click" />
            <asp:PostBackTrigger ControlID="HiddenButton" />
        </Triggers>
        <ContentTemplate>
            <asp:FormView runat="server" ID="FormViewInsertBook" DefaultMode="Insert"
                ItemType="LibrarySystem.Models.Book"
                InsertMethod="FormViewInsertBook_InsertItem"
                Visible="false" CssClass="form-horizontal">
                <InsertItemTemplate>
                    <fieldset>
                        <legend>Insert new book</legend>
                        <div class="form-group row">
                            <label class="control-label col-md-3" for="TitleTextBox">Title: </label>
                            <div class="col-md-9">
                                <asp:TextBox ID="TitleTextBox" runat="server" Text='<%# BindItem.Title %>' CssClass="form-control" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-md-3">Author: </label>
                            <div class="col-md-9">
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# BindItem.Author %>' CssClass="form-control" />
                            </div>
                        </div>
                        <div>
                            ISBN: 
                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# BindItem.ISBN %>' />
                        </div>
                        <div>
                            Website: 
                        <asp:TextBox ID="TextBox3" runat="server" Text='<%# BindItem.WebSite %>' TextMode="Url" />
                        </div>
                        <div>
                            Description:
                        <asp:TextBox ID="TextBox4" runat="server" Text='<%# BindItem.Description %>' TextMode="MultiLine" Height="160" />
                        </div>
                        <div>
                            Category: 
                        <asp:DropDownList ID="DropDownListCategories" runat="server"
                            SelectMethod="SelectCategories"
                            DataValueField="CategoryId"
                            DataTextField="Name"
                            SelectedValue="<%# BindItem.CategoryId %>"
                            AppendDataBoundItems="true">
                            <asp:ListItem Text="(no categoty)" Value="" />
                        </asp:DropDownList>
                        </div>
                        <div>
                            <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="Insert" 
                                OnClientClick="javascript:document.getElementById('MainContent_HiddenButton').click();"/>
                            <asp:Button ID="ClearButton" runat="server" CommandName="Cancel" Text="Clear" />
                            <asp:Button ID="CancelButtonInsert" runat="server" Text="Cancel" OnClick="CancelButtonInsert_Click" />
                        </div>
                    </fieldset>
                </InsertItemTemplate>
            </asp:FormView>

            <div style="visibility: hidden">
                <asp:Button ID="HiddenButton" runat="server" OnClick="HiddenButton_Click" Text="Button" UseSubmitBehavior="false" />
            </div>

        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Todos.aspx.cs" Inherits="TodoList.Todos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Todo list</title>
    <link href="site.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="todoListMaster">
            <h1>TODO List</h1>
            <asp:ListView ID="TodoListView" runat="server"
                ItemType="TodoList.Model.TodoItem"
                SelectMethod="TodoListView_GetData"
                UpdateMethod="TodoListView_UpdateItem"
                InsertMethod="TodoListView_InsertItem"
                DeleteMethod="TodoListView_DeleteItem"
                DataKeyNames="TodoItemId"
                OnItemInserted="TodoListView_ItemInserted">
                <LayoutTemplate>
                    <table runat="server">
                        <tr runat="server">
                            <td runat="server">
                                <table id="itemPlaceholderContainer" runat="server" class="todoList">
                                    <tbody>
                                        <tr runat="server">
                                            <th>Commands</th>
                                            <th runat="server">
                                                <asp:LinkButton ID="ListViewSortTodoItemName" runat="server"
                                                    Text="Title" CommandName="Sort" CommandArgument="Title" />
                                            </th>
                                            <th runat="server">
                                                <asp:LinkButton ID="ListViewSortTodoItemBody" runat="server"
                                                    Text="Body" CommandName="Sort" CommandArgument="Body" />
                                            </th>
                                            <th runat="server">
                                                <asp:LinkButton ID="ListViewSortTodoItemLastChanged" runat="server"
                                                    Text="LastChanged" CommandName="Sort" CommandArgument="LastChanged" />
                                            </th>
                                            <th runat="server">Category</th>
                                        </tr>
                                        <tr id="itemPlaceholder" runat="server">
                                        </tr>
                                    </tbody>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="ButtonInsertTodo" Text="Add new TODO" runat="server"
                                    OnClick="ButtonInsertTodo_Click" />
                            </td>
                        </tr>
                        <tr runat="server">
                            <td runat="server" style="">
                                <asp:DataPager ID="DataPager" runat="server" PageSize="5">
                                    <Fields>
                                        <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
                                        <asp:NumericPagerField />
                                        <asp:NextPreviousPagerField ButtonType="Button" ShowLastPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
                                    </Fields>
                                </asp:DataPager>
                            </td>
                        </tr>
                    </table>
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
                        <td>
                            <asp:Button ID="ButtonEdit" runat="server" CommandName="Edit" Text="Edit" />
                            <asp:Button ID="ButtonDelete" runat="server" CommandName="Delete" Text="Delete" />
                        </td>
                        <td><%#: Item.Title %></td>
                        <td><%#: Item.Body %></td>
                        <td><%#: Item.LastChanged %></td>
                        <td><%#: Item.Category.Name %></td>
                    </tr>
                </ItemTemplate>
                <InsertItemTemplate>
                    <tr style="">
                        <td>
                            <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="Insert" />
                            <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Clear" />
                            <asp:Button ID="ButtonCancelInsertTodo" runat="server" Text="Cancel" OnClick="ButtonCancelInsertTodo_Click" />
                        </td>
                        <td>
                            <asp:TextBox ID="TitleTextBox" runat="server" Text='<%# BindItem.Title %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="BodyTextBox" runat="server" TextMode="MultiLine" Text='<%# BindItem.Body %>' />
                        </td>
                        <td></td>
                        <td>
                            <asp:DropDownList ID="DropDownListCountries" runat="server"
                                SelectMethod="CategoriesGridView_GetData"
                                DataValueField="CategoryId"
                                DataTextField="Name"
                                SelectedValue="<%# BindItem.CategoryId %>"
                                AppendDataBoundItems="true">
                                <asp:ListItem Text="(no Category)" Value="" />
                            </asp:DropDownList>
                        </td>
                    </tr>
                </InsertItemTemplate>
                <EditItemTemplate>
                    <tr style="">
                        <td>
                            <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="Update" />
                            <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancel" />
                        </td>
                        <td>
                            <asp:TextBox ID="TitleTextBox" runat="server" Text='<%# BindItem.Title %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="BodyTextBox" runat="server" TextMode="MultiLine" Text='<%# BindItem.Body %>' />
                        </td>
                        <td></td>
                        <td>
                            <asp:DropDownList ID="DropDownListCountries" runat="server"
                                SelectMethod="CategoriesGridView_GetData"
                                DataValueField="CategoryId"
                                DataTextField="Name"
                                SelectedValue="<%# BindItem.CategoryId %>"
                                AppendDataBoundItems="true">
                                <asp:ListItem Text="(no Category)" Value="" />
                            </asp:DropDownList>
                        </td>
                    </tr>
                </EditItemTemplate>
            </asp:ListView>
        </div>

        <div class="CategoryList">
            <h1>Categories</h1>
            <asp:GridView ID="CategoriesGridView" runat="server"
                ItemType="TodoList.Model.Category"
                SelectMethod="CategoriesGridView_GetData"
                UpdateMethod="CategoriesGridView_UpdateItem"
                DeleteMethod="CategoriesGridView_DeleteItem"
                AllowSorting="true" AllowPaging="true" PageSize="5"
                DataKeyNames="CategoryId"
                AutoGenerateColumns="false">
                <Columns>
                    <asp:CommandField HeaderText="Commands" ShowEditButton="true" ShowDeleteButton="true" />
                    <asp:BoundField HeaderText="Name" DataField="Name" SortExpression="Name" />

                </Columns>
            </asp:GridView>
            <asp:Button ID="AddNewCategory" Text="Add new Category" runat="server" OnClick="AddNewCategory_Click" />
            <div runat="server" id="InsertCategoryForm" style="display: none">
                <asp:TextBox ID="TextBoxInsertCategory" runat="server" />
                <asp:Button ID="InsertCategory" Text="Insert" runat="server" OnClick="InsertCategory_Click" />
                <asp:Button ID="CancelCategory" Text="Cancel" runat="server" OnClick="CancelCategory_Click" />
            </div>
        </div>
    </form>
</body>
</html>

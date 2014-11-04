<%@ Page Title="Edit Categories" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditCategories.aspx.cs" Inherits="NewsSystem.Admin.EditCategories" Culture="en-US" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <asp:ListView runat="server" ID="ListViewEditCategory"
        ItemType="NewsSystem.Models.Category"
        SelectMethod="ListViewEditCategory_GetData"
        InsertMethod="ListViewEditCategory_InsertItem"
        DeleteMethod="ListViewEditCategory_DeleteItem"
        UpdateMethod="ListViewEditCategory_UpdateItem"
        DataKeyNames="CategoryId"
        OnItemInserted="ListViewEditCategory_ItemInserted">
        <LayoutTemplate>
            <div class="row">
                <asp:LinkButton ID="ListViewSortName" runat="server" CssClass="btn btn-default"
                    Text="Category Name" CommandName="Sort" CommandArgument="Name" />
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
                    <asp:Button ID="ButtonInsertCategory" runat="server" Text="Insert New Category" OnClick="ButtonInsertCategory_Click" CssClass="btn btn-primary" />
                </div>

            </div>
        </LayoutTemplate>
        <ItemTemplate>
            <div class="row">
                <div class="col-md-3"><%#: Item.Name %></div>
                <asp:LinkButton ID="ButtonEdit" runat="server" CssClass="btn btn-info"
                    CommandName="Edit" Text="Edit" />
                <asp:LinkButton ID="ButtonDelete" runat="server"
                    CommandName="Delete" Text="Delete" CssClass="btn btn-danger"
                    OnClientClick=<%# string.Format("return confirm('Do you want to delete Category \"{0}\"?')", Item.Name) %> />
            </div>
        </ItemTemplate>
        <InsertItemTemplate>
            <div class="row">
                <div class="col-md-3">
                    <asp:TextBox ID="TextBoxCategoryName" runat="server" Text="<%#: BindItem.Name %>" MaxLength="50"/>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorTitle" ControlToValidate="TextBoxCategoryName" runat="server" Display="Dynamic" Text="Required!" ErrorMessage="Title field is required!" ForeColor="Red" />
                </div>
                <asp:Button ID="InsertButton" runat="server" CssClass="btn btn-primary" CommandName="Insert" Text="Save" />
                <asp:Button ID="ClearButton" runat="server" CssClass="btn btn-danger" CommandName="Cancel" Text="Clear" CausesValidation="False" />
                <asp:Button ID="CancelButton" runat="server" CssClass="btn" Text="Cancel" OnClick="CancelButton_Click" CausesValidation="False" />
            </div>
        </InsertItemTemplate>
        <EditItemTemplate>
            <div class="row">
                <div class="col-md-3">
                    <asp:TextBox ID="TextBoxCategoryNameEdit" runat="server" Text="<%# BindItem.Name %>" MaxLength="50"/>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorTitle" ControlToValidate="TextBoxCategoryNameEdit" runat="server" Display="Dynamic" Text="Required!" ErrorMessage="Title field is required!" ForeColor="Red" />
                </div>
                <asp:Button ID="UpdateButton" runat="server" CssClass="btn btn-success" CommandName="Update" Text="Save" />
                <asp:Button ID="Button1" runat="server" CssClass="btn btn-danger" CommandName="Cancel" Text="Cancel" CausesValidation="False" />
            </div>
        </EditItemTemplate>
    </asp:ListView>
</asp:Content>

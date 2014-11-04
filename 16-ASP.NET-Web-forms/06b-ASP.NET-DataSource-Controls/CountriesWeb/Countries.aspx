<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Countries.aspx.cs" Inherits="CountriesWeb.Countries" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Countries</title>
    <link href="site.css" rel="stylesheet" />
</head>
<body>
    <%--Data sources--%>
    <asp:EntityDataSource ID="EntityDataSourceContinents" runat="server"
        ConnectionString="name=CountriesDBEntities"
        DefaultContainerName="CountriesDBEntities"
        EnableFlattening="False" EntitySetName="Continents"
        EnableDelete="True" EnableInsert="True" EnableUpdate="True">
    </asp:EntityDataSource>

    <asp:EntityDataSource ID="EntityDataSourceCountries" runat="server"
        ConnectionString="name=CountriesDBEntities"
        DefaultContainerName="CountriesDBEntities"
        EnableFlattening="False" EntitySetName="Countries" Include="Continent"
        EnableDelete="True" EnableInsert="True" EnableUpdate="True"
        Where="It.ContinentId=@ContinentId">
        <WhereParameters>
            <asp:ControlParameter Name="ContinentId" Type="Int32" ControlID="ContinentListBox" />
        </WhereParameters>
    </asp:EntityDataSource>

    <asp:EntityDataSource ID="EntityDataSourceTowns" runat="server"
        ConnectionString="name=CountriesDBEntities"
        DefaultContainerName="CountriesDBEntities"
        EnableFlattening="False" EntitySetName="Towns" Include="Country"
        EnableDelete="True" EnableInsert="True" EnableUpdate="True"
        Where="It.CountryId=@CountryId">
        <WhereParameters>
            <asp:ControlParameter Name="CountryId" Type="Int32" ControlID="CountriesGridView" />
        </WhereParameters>
    </asp:EntityDataSource>

    <%--Form--%>
    <form id="form1" runat="server">
        <div class="continents">
            <h3>Continents</h3>
            <div>
                <asp:ListBox ID="ContinentListBox" runat="server" DataSourceID="EntityDataSourceContinents"
                    DataTextField="Name" DataValueField="ContinentId" AutoPostBack="True" Rows="6"></asp:ListBox>
            </div>
        </div>

        <%--Countries--%>
        <div class="countries">
            <h3>Countries</h3>
            <asp:GridView ID="CountriesGridView" runat="server"
                DataSourceID="EntityDataSourceCountries"
                AllowSorting="True"
                AllowPaging="True" PageSize="3"
                AutoGenerateColumns="False"
                DataKeyNames="CountryId"
                ItemType="CountriesWeb.Country"
                SelectedRowStyle-BackColor="#00ffcc">
                <Columns>
                    <%--<asp:BoundField HeaderText="name" DataField="Name"/>--%>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <th></th>
                            <th>
                                <asp:Button ID="ButtonInsertCountry" runat="server"
                                    Text="Insert" OnClick="ButtonInsertCountry_Click" />
                            </th>
                            <th>
                                <asp:LinkButton runat="server" ID="SortByNameCountry" CommandName="Sort" Text="Name" CommandArgument="Name" />
                            </th>
                            <th>
                                <asp:LinkButton runat="server" ID="SortByPopulationCountry" CommandName="Sort" Text="Population" CommandArgument="Population" />
                            </th>
                            <th>
                                <asp:LinkButton runat="server" ID="LanguigeBtn" CommandName="Sort" Text="Language" CommandArgument="Language" />
                            </th>
                            <th>Continent</th>
                            <th>Flag</th>
                        </HeaderTemplate>

                        <ItemTemplate>
                            <td>
                                <asp:Button ID="SelectButtonCountry" runat="server" CommandName="Select" Text="Select" />
                            </td>
                            <td>
                                <asp:Button ID="ButtonEdit" runat="server" CommandName="Edit" Text="Edit" />
                                <asp:Button ID="ButtonDelete" runat="server" CommandName="Delete" Text="Delete" /></td>
                            <td>
                                <%#:Item.Name %>
                            </td>
                            <td>
                                <%#: string.Format("{0:n0}", Item.Population) %>
                            </td>
                            <td>
                                <%#:Item.Language %>
                            </td>
                            <td>
                                <%#:Item.Continent.Name %>
                            </td>
                            <td>
                                <img src="data:image/png;base64,<%#:Item.Flag !=null?Convert.ToBase64String(Item.Flag):"" %> " />
                            </td>
                        </ItemTemplate>

                        <EditItemTemplate>
                            <td></td>
                            <td>
                                <asp:Button ID="ButtonUpdateCountry" runat="server" CommandName="Update" Text="Update" />
                                <asp:Button ID="ButtonCancelCountry" runat="server" CommandName="Cancel" Text="Cancel" />
                            </td>

                            <td>
                                <asp:TextBox ID="CountryNameBind" runat="server" Text="<%#: BindItem.Name %>" /></td>
                            <td>
                                <asp:TextBox ID="CountryPopulationBind" runat="server" Text="<%#: BindItem.Population %>" /></td>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="CountryPopulationBind" runat="server" ErrorMessage="Only Numbers allowed" ValidationExpression="\d+"></asp:RegularExpressionValidator>
                            <td>
                                <asp:TextBox ID="CountryLanguage" runat="server" Text="<%#: BindItem.Language %>" /></td>
                            <td>
                                <asp:DropDownList ID="DropDownListContinents" runat="server"
                                    DataSourceID="EntityDataSourceContinents"
                                    DataValueField="ContinentId"
                                    DataTextField="Name"
                                    SelectedValue="<%# BindItem.ContinentId %>"
                                    AppendDataBoundItems="true">
                                    <asp:ListItem Text="(no continent)" Value="" />
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:FileUpload ID="FileUpload1" filebytes='<%#: BindItem.Flag %>' runat="server" />
                            </td>
                        </EditItemTemplate>

                        <FooterTemplate>
                            <td></td>
                            <td>
                                <asp:Button CommandName="Insert" ID="ButtonAdd" runat="server"
                                    Text="Insert" OnClick="ButtonAdd_Click" />
                                <asp:Button ID="ButtonCancelInsertCountry" runat="server"
                                    Text="Cancel" OnClick="ButtonCancelInsertCountry_Click" />
                            </td>
                            <td>
                                <asp:TextBox ID="CountryNameInsertTb" runat="server" Text="<%#: BindItem.Name %>"
                                    AutoPostBack="true" OnPreRender="CountryNameInsertTb_PreRender"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="CountryPopulationBind" runat="server" Text="<%#: BindItem.Population %>"
                                    AutoPostBack="true" OnPreRender="CountryPopulationBind_PreRender"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="CountryPopulationBind" runat="server" ErrorMessage="Only Numbers allowed" ValidationExpression="\d+"></asp:RegularExpressionValidator>
                            </td>
                            <td>
                                <asp:TextBox ID="CountryLanguageBind" runat="server" Text="<%#: BindItem.Language %>"
                                    AutoPostBack="true" OnPreRender="LanguageId_PreRender"></asp:TextBox>
                            </td>
                            <td>
                                <asp:DropDownList ID="DropDownListContinents" runat="server"
                                    DataSourceID="EntityDataSourceContinents"
                                    DataValueField="ContinentId"
                                    DataTextField="Name"
                                    SelectedValue="<%# BindItem.ContinentId %>"
                                    AppendDataBoundItems="true"
                                    OnPreRender="CountinentId_PreRender"
                                    AutoPostBack="true">
                                    <asp:ListItem Text="(no continent)" Value="" />
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:FileUpload ID="FileUpload1" filebytes='<%#: BindItem.Flag %>' runat="server" />
                            </td>
                        </FooterTemplate>

                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>

        <%--Towns--%>
        <div class="towns">
            <h3>Towns</h3>
            <asp:ListView ID="TownsListView" runat="server"
                ItemType="CountriesWeb.Town"
                DataSourceID="EntityDataSourceTowns"
                DataKeyNames="TownId"
                InsertItemPosition="None"
                OnItemInserted="TownsListView_ItemInserted">
                <LayoutTemplate>
                    <table runat="server">
                        <tr runat="server">
                            <td runat="server">
                                <table id="itemPlaceholderContainer" runat="server" border="0" style="">
                                    <tr runat="server" style="">
                                        <th>
                                            <asp:Button ID="ButtonInsertTown" Text="Insert" runat="server"
                                                OnClick="ButtonInsertTown_Click" />
                                        </th>
                                        <th runat="server">
                                            <asp:LinkButton ID="ListViewSortName" runat="server"
                                                Text="Name" CommandName="Sort" CommandArgument="Name" />
                                        </th>
                                        <th runat="server">
                                            <asp:LinkButton ID="ListViewSortPopulation" runat="server"
                                                Text="Population" CommandName="Sort" CommandArgument="Population" />
                                        </th>
                                        <th runat="server">Country</th>
                                    </tr>
                                    <tr id="itemPlaceholder" runat="server">
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr runat="server">
                            <td runat="server" style="">
                                <asp:DataPager ID="DataPager" runat="server" PageSize="4">
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
                        <td><%#: Item.Name %></td>
                        <td><%#: string.Format("{0:n0}", Item.Population) %></td>
                        <td><%#: Item.Country.Name %></td>
                    </tr>
                </ItemTemplate>
                <InsertItemTemplate>
                    <tr style="">
                        <td>
                            <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="Insert" />
                            <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Clear" />
                        </td>
                        <td>
                            <asp:TextBox ID="NameTextBox" runat="server" Text='<%# Bind("Name") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="PopulationTextBox" runat="server" Text='<%# Bind("Population") %>' />
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="PopulationTextBox" runat="server" ErrorMessage="Only Numbers allowed" ValidationExpression="\d+"></asp:RegularExpressionValidator>
                        </td>
                        <td>
                            <asp:DropDownList ID="DropDownListCountries" runat="server"
                                DataSourceID="EntityDataSourceCountries"
                                DataValueField="CountryId"
                                DataTextField="Name"
                                SelectedValue="<%# BindItem.CountryId %>"
                                AppendDataBoundItems="true">
                                <asp:ListItem Text="(no country)" Value="" />
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
                            <asp:TextBox ID="NameTextBox" runat="server" Text='<%# Bind("Name") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="PopulationTextBox" runat="server" Text='<%# Bind("Population") %>' />
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="PopulationTextBox" runat="server" ErrorMessage="Only Numbers allowed" ValidationExpression="\d+"></asp:RegularExpressionValidator>
                        </td>
                        <td>
                            <asp:DropDownList ID="DropDownListCountries" runat="server"
                                DataSourceID="EntityDataSourceCountries"
                                DataValueField="CountryId"
                                DataTextField="Name"
                                SelectedValue="<%# BindItem.CountryId %>"
                                AppendDataBoundItems="true">
                                <asp:ListItem Text="(no country)" Value="" />
                            </asp:DropDownList>
                        </td>
                    </tr>
                </EditItemTemplate>
            </asp:ListView>
        </div>
    </form>
</body>
</html>

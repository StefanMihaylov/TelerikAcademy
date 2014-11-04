<%@ Page Title="Offices" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Offices.aspx.cs" Inherits="Navigation_and_Site_Maps.Offices" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <p>We have offices in the following countries</p>
    <asp:Menu ID="NavigationMenu" runat="server" CssClass="verticalMenu"
        EnableViewState="False" IncludeStyleBlock="False" SkipLinkText=""
        DataSourceID="SiteMapDataSource">
    </asp:Menu>
    <asp:SiteMapDataSource ID="SiteMapDataSource" runat="server"
        ShowStartingNode="False" StartingNodeOffset="1" />
</asp:Content>

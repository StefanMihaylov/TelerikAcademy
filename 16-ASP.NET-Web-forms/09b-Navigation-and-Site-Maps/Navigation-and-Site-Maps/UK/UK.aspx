<%@ Page Title="UK" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UK.aspx.cs" Inherits="Navigation_and_Site_Maps.UK.UK" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <p>In United kingdom we have offices in the following cities</p>
    <asp:Menu ID="NavigationMenu" runat="server" CssClass="verticalMenu"
        EnableViewState="False" IncludeStyleBlock="False" SkipLinkText=""
        DataSourceID="SiteMapDataSource">
    </asp:Menu>
    <asp:SiteMapDataSource ID="SiteMapDataSource" runat="server"
        ShowStartingNode="False" StartingNodeOffset="2" />
</asp:Content>

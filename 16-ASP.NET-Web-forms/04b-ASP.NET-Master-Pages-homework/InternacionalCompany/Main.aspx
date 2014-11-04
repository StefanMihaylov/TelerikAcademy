<%@ Page Title="Home" 
    Language="C#" 
    MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" 
    CodeBehind="Main.aspx.cs" 
    Inherits="InternacionalCompany.Main" %>


<asp:Content ID="MainContent" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <asp:HyperLink runat="server" NavigateUrl="~/English/EnglishHome.aspx" 
        Text="" CssClass="icon English"/>
    <asp:HyperLink runat="server" NavigateUrl="~/Bulgarian/BulgarianHome.aspx" 
        Text="" CssClass="icon Bulgarian"/>
</asp:Content>

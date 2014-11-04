<%@ Page Title="Profile" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="UserProfile.Profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <div class="contentDiv">
        <asp:Image ImageUrl="images/1413763845_man.png" runat="server" CssClass="profileImg" />
        <p>Nickname: <strong>Pesho</strong></p>
        <p>Sex: <strong>Male</strong></p>
        <p>Age: <strong>24</strong></p>
    </div>
</asp:Content>

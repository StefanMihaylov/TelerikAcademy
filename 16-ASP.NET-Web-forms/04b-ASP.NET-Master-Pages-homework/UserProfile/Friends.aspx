<%@ Page Title="Friends"
    Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="Friends.aspx.cs"
    Inherits="UserProfile.Friends" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta name="author" content="Telerik Academy student" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <div class="contentDiv">
        <p class="friendContent">
            <asp:Image ImageUrl="images/1413763783_wooman.png" CssClass="friendImg" runat="server" />
            <br />
            <strong>Mariika</strong>
        </p>

        <p class="friendContent">
            <asp:Image ImageUrl="images/1413763353_Teacher-male-128.png" CssClass="friendImg" runat="server" />
            <br />
            <strong>Gosho</strong>
        </p>

        <p class="friendContent">
            <asp:Image ImageUrl="images/1413763327_Caucasian_boss.png" CssClass="friendImg" runat="server" />
            <br />
            <strong>Vankata</strong>
        </p>

        <p class="friendContent">
            <asp:Image ImageUrl="images/1413763336_user.png" CssClass="friendImg" runat="server" />
            <br />
            <strong>Stamat</strong>
        </p>
    </div>
</asp:Content>

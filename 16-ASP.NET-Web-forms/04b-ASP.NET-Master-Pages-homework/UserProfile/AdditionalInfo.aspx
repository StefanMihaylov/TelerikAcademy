<%@ Page Title="Additional info" 
    Language="C#" 
    MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" 
    CodeBehind="AdditionalInfo.aspx.cs" 
    Inherits="UserProfile.AdditionalInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
        <div class="contentDiv">
        <p>Real Name: <strong>Peter Petrov</strong></p>
        <p>Email: <strong>Peter@peter.bg</strong></p>
        <p>Country: <strong>Bulgaria</strong></p>
        <p>City: <strong>Sofia</strong></p>
    </div>
</asp:Content>

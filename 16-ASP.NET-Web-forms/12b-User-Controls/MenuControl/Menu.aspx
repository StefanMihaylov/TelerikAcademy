<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="MenuControl.Menu" %>

<%@ Register Src="~/Control/MenuControl.ascx" TagPrefix="uc" TagName="MenuControl" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <uc:MenuControl runat="server" id="LinksMenu" FontColour="yellowgreen" FontFamily="Verdana" />
    </div>
    </form>
</body>
</html>

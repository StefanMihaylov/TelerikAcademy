<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PhotoAlbum.aspx.cs" Inherits="PhotoAlbumAjaxToolkit.PhotoAlbum" %>

<%@ Register TagPrefix="ajaxToolkit" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Photo Album</title>
    <style>
        .container {
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></ajaxToolkit:ToolkitScriptManager>

            <asp:Label runat="Server" ID="imageTitle" CssClass="slideTitle" /><br />
            <asp:Image ID="imageContainer" runat="server" />

            <ajaxToolkit:SlideShowExtender ID="SlideShowExtender1" runat="server"
                TargetControlID="imageContainer"
                SlideShowServiceMethod="GetSlides"
                AutoPlay="true"
                ImageTitleLabelID="imageTitle"
                PreviousButtonID="prevButton"
                NextButtonID="nextButton"
                PlayButtonID="playButton"
                PlayButtonText="Play"
                StopButtonText="Stop"
                Loop="true" />

            <div>
                <asp:Button Text="Previous" runat="server" ID="prevButton" />
                <asp:Button Text="Play" runat="server" ID="playButton" />
                <asp:Button Text="Next" runat="server" ID="nextButton" />
            </div>
        </div>
    </form>

    <script src="jquery.min.js"></script>
    <script>
        (function () {
            $(document).ready(function () {
                $("#form1").on("click", "#imageContainer", function (ev) {
                    var attr = $("#imageContainer").attr("src");

                    var popupWindow = window.open("", 'Popup', 'width=820,height=620');
                    popupWindow.document.write("<img src='" + attr + "' width='800' height='600' />");
                })
            });
        })();
    </script>
</body>
</html>

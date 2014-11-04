<%@ Page Language="C#"
    AutoEventWireup="true"
    CodeBehind="Home.aspx.cs"
    Inherits="FileUpload.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>File upload</title>

    <link href="KendoUi/kendo.common.min.css" rel="stylesheet" />
    <link href="KendoUi/kendo.default.min.css" rel="stylesheet" />
    <script src="KendoUi/jquery.min.js"></script>
    <script src="KendoUi/kendo.web.min.js"></script>

</head>
<body>
    <input type="file" runat="server" id="uploaded" name="uploaded" />
    <div>Refresh the page to see the texts in the database</div>
    <div runat="server" id="uploadedStuff">
        <%= FileOutput %>
    </div>

    <script>
        function onUpload(e) {
            var files = e.files;
            $.each(files, function () {
                if (this.extension.toLowerCase() != ".zip") {
                    alert("Only .zip files can be uploaded");
                    e.preventDefault();
                }
            });
        }

        $(document).ready(function () {
            $("#uploaded").kendoUpload({
                async: {
                    saveUrl: "Upload.aspx",
                    autoUpload: true,
                },
                upload: onUpload
            });
        });
    </script>
</body>
</html>

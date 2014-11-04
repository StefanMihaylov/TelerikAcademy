<%@ Page Language="C#"
    AutoEventWireup="true"
    CodeBehind="RandomGenerator.aspx.cs"
    Inherits="RandomGeneratorHtmlControls.RandomGenerator" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Random Generator</h1>
        <div>
            Range: [<input id="From" type="number" runat="server" />;<input id="To" type="number" runat="server" />]
            <input id="SubmitButtom" type="submit" runat="server" value="Generate" onserverclick="GenerateRandomNumber" />
        </div>
        <div>
            Result:
            <input id="Result" type="number" runat="server" disabled="disabled" />
        </div>
    </form>
</body>
</html>

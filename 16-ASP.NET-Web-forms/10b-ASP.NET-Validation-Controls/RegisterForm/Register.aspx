<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="RegisterForm.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Register</title>
    <style>
        div > input {
            margin: 5px 10px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label Text="User Name: " runat="server" />
            <asp:TextBox ID="UserNameTextBox" runat="server" placeholder="User name" />

            <asp:RequiredFieldValidator ID="RequiredFieldValidatorUserName" ControlToValidate="UserNameTextBox" runat="server" Display="Dynamic" Text="Required Field" ErrorMessage="User name field is required!" ForeColor="Red" />
        </div>
        <div>
            <asp:Label Text="Password: " runat="server" ty/>
            <asp:TextBox ID="PasswordTextBox" runat="server" placeholder="Password" TextMode="Password"/>

            <asp:RequiredFieldValidator ID="RequiredFieldValidatorPassword" ControlToValidate="PasswordTextBox" runat="server" Display="Dynamic" Text="Required Field" ErrorMessage="Password field is required!" ForeColor="Red" />
        </div>
        <div>
            <asp:Label Text="Confirm Password: " runat="server" />
            <asp:TextBox ID="ConfirmPasswordTextBox" runat="server" placeholder="Confirm password" TextMode="Password"/>

            <asp:RequiredFieldValidator ID="RequiredFieldValidatorConfirmPassword" ControlToValidate="ConfirmPasswordTextBox" runat="server" Display="Dynamic" Text="Required Field" ErrorMessage="Confirm password field is required!" ForeColor="Red" />
            <asp:CompareValidator ID="CompareValidatorPassword" runat="server"
                ControlToCompare="PasswordTextBox"
                ControlToValidate="ConfirmPasswordTextBox" Display="Dynamic"
                ErrorMessage="Password doesn't match!" ForeColor="Red" EnableClientScript="False" />
        </div>
        <div>
            <asp:Label Text="First Name: " runat="server" />
            <asp:TextBox ID="FirstNameTextBox" runat="server" placeholder="First name" />

            <asp:RequiredFieldValidator ID="RequiredFieldValidatorFirstName" ControlToValidate="FirstNameTextBox" runat="server" Display="Dynamic" Text="Required Field" ErrorMessage="First name field is required!" ForeColor="Red" />
        </div>
        <div>
            <asp:Label Text="Last Name: " runat="server" />
            <asp:TextBox ID="LastNameTextBox" runat="server" placeholder="last name" />

            <asp:RequiredFieldValidator ID="RequiredFieldValidatorLastName" ControlToValidate="LastNameTextBox" runat="server" Display="Dynamic" Text="Required Field" ErrorMessage="Last name field is required!" ForeColor="Red" />
        </div>
        <div>
            <asp:Label Text="Age: " runat="server" />
            <asp:TextBox ID="AgeTextBox" runat="server" placeholder="Age" TextMode="Number"/>

            <asp:RequiredFieldValidator ID="RequiredFieldValidatorAge" ControlToValidate="AgeTextBox" runat="server"
                Display="Dynamic" Text="Required Field" ErrorMessage="Age field is required!" ForeColor="Red" />
            <asp:RangeValidator ID="RangeFieldValidatorAge" ControlToValidate="AgeTextBox" runat="server"
                Display="Dynamic" Type="Integer" MinimumValue="18" MaximumValue="81"
                ErrorMessage="Age must be in range [18..81]" ForeColor="Red" />
        </div>
        <div>
            <asp:Label Text="Email: " runat="server" />
            <asp:TextBox ID="EmailTextBox" runat="server" placeholder="Email" TextMode="Email" />

            <asp:RequiredFieldValidator ID="RequiredFieldValidatorEmail" ControlToValidate="EmailTextBox" runat="server"
                Display="Dynamic" Text="Required Field" ErrorMessage="Email field is required!" ForeColor="Red" />
            <asp:RegularExpressionValidator ID="RegularExpressionValidatorEmail" runat="server" ForeColor="Red" Display="Dynamic" ErrorMessage="Email address is incorrect!" ControlToValidate="EmailTextBox" EnableClientScript="False"
                ValidationExpression="[a-zA-Z][a-zA-Z0-9\-\.]*[a-zA-Z]@[a-zA-Z][a-zA-Z0-9\-\.]+[a-zA-Z]+\.[a-zA-Z]{2,4}" />
        </div>
        <div>
            <asp:Label Text="Local Address: " runat="server" />
            <asp:TextBox ID="LocalAddressTextBox" runat="server" placeholder="Local address" />

            <asp:RequiredFieldValidator ID="RequiredFieldValidatorAddress" ControlToValidate="LocalAddressTextBox" runat="server"
                Display="Dynamic" Text="Required Field" ErrorMessage="Local Address field is required!" ForeColor="Red" />
        </div>
        <div>
            <asp:Label Text="Phone number: " runat="server" />
            <asp:TextBox ID="PhoneTextBox" runat="server" placeholder="Phone number"  TextMode="Phone"/>

            <asp:RequiredFieldValidator ID="RequiredFieldValidatorPhone" ControlToValidate="PhoneTextBox" runat="server"
                Display="Dynamic" Text="Required Field" ErrorMessage="Phone number field is required!" ForeColor="Red" />
            <asp:RegularExpressionValidator ID="RegularExpressionValidatorPhone" runat="server" ForeColor="Red" Display="Dynamic" ErrorMessage="Phone number is incorrect!" ControlToValidate="PhoneTextBox" EnableClientScript="False" ValidationExpression="^\+?(\d[\d-. ]+)?(\([\d-. ]+\))?[\d-. ]+\d$" />
        </div>
        <div>
            <asp:CheckBox ID="AcceptCheckBox" Text="I accept" runat="server" />

            <asp:CustomValidator ID="CustomValidatorAccept" runat="server"
                ErrorMessage="Please accept the terms..."
                OnServerValidate="CustomValidatorAccept_ServerValidate"></asp:CustomValidator>
        </div>
        <div>
            <asp:Button ID="SubmitButton" Text="Submit" runat="server" OnClick="SubmitButton_Click" />
        </div>
        <asp:ValidationSummary runat="server" ForeColor="Red" />
    </form>
</body>
</html>

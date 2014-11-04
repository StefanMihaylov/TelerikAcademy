<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="GroupValidation.Register" %>

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
        <asp:Panel runat="server" ID="LoginGroup" GroupingText="Login">
            <div>
                <asp:Label Text="User Name: " runat="server" />
                <asp:TextBox ID="UserNameTextBox" runat="server" placeholder="User name" 
                    ValidationGroup="LoginGroup"/>

                <asp:RequiredFieldValidator ID="RequiredFieldValidatorUserName" ControlToValidate="UserNameTextBox" runat="server" Display="Dynamic" Text="Required Field" ErrorMessage="User name field is required!" ForeColor="Red" ValidationGroup="LoginGroup"/>
            </div>
            <div>
                <asp:Label Text="Password: " runat="server" ty />
                <asp:TextBox ID="PasswordTextBox" runat="server" placeholder="Password" TextMode="Password" 
                    ValidationGroup="LoginGroup"/>

                <asp:RequiredFieldValidator ID="RequiredFieldValidatorPassword" ControlToValidate="PasswordTextBox" runat="server" Display="Dynamic" Text="Required Field" ErrorMessage="Password field is required!" ForeColor="Red" ValidationGroup="LoginGroup"/>
            </div>
            <div>
                <asp:Label Text="Confirm Password: " runat="server" />
                <asp:TextBox ID="ConfirmPasswordTextBox" runat="server" placeholder="Confirm password" TextMode="Password" 
                    ValidationGroup="LoginGroup"/>

                <asp:RequiredFieldValidator ID="RequiredFieldValidatorConfirmPassword" ControlToValidate="ConfirmPasswordTextBox" runat="server" Display="Dynamic" Text="Required Field" ErrorMessage="Confirm password field is required!" ForeColor="Red" ValidationGroup="LoginGroup"/>
                <asp:CompareValidator ID="CompareValidatorPassword" runat="server"
                    ControlToCompare="PasswordTextBox" ValidationGroup="LoginGroup"
                    ControlToValidate="ConfirmPasswordTextBox" Display="Dynamic"
                    ErrorMessage="Password doesn't match!" ForeColor="Red" EnableClientScript="False" />
            </div>
            <asp:Button ID="LoginButton" Text="Submit" runat="server" OnClick="LoginButton_Click" ValidationGroup="LoginGroup" />
            <asp:ValidationSummary runat="server" ForeColor="Red" ValidationGroup="LoginGroup"/>
        </asp:Panel>

        <asp:Panel runat="server" ID="PersonalInfoGroupPanel" GroupingText="Personal info">
            <div>
                <asp:Label Text="First Name: " runat="server" />
                <asp:TextBox ID="FirstNameTextBox" runat="server" placeholder="First name" 
                    ValidationGroup="PersonalInfoGroup"/>

                <asp:RequiredFieldValidator ID="RequiredFieldValidatorFirstName" ControlToValidate="FirstNameTextBox" runat="server" Display="Dynamic" Text="Required Field" ErrorMessage="First name field is required!" ForeColor="Red" ValidationGroup="PersonalInfoGroup"/>
            </div>
            <div>
                <asp:Label Text="Last Name: " runat="server" />
                <asp:TextBox ID="LastNameTextBox" runat="server" placeholder="last name" ValidationGroup="PersonalInfoGroup"/>

                <asp:RequiredFieldValidator ID="RequiredFieldValidatorLastName" ControlToValidate="LastNameTextBox" runat="server" Display="Dynamic" Text="Required Field" ErrorMessage="Last name field is required!" ForeColor="Red" ValidationGroup="PersonalInfoGroup"/>
            </div>
            <div>
                <asp:Label Text="Age: " runat="server" />
                <asp:TextBox ID="AgeTextBox" runat="server" placeholder="Age" TextMode="Number" ValidationGroup="PersonalInfoGroup"/>

                <asp:RequiredFieldValidator ID="RequiredFieldValidatorAge" ControlToValidate="AgeTextBox" runat="server"
                    Display="Dynamic" Text="Required Field" ErrorMessage="Age field is required!" ForeColor="Red" ValidationGroup="PersonalInfoGroup"/>
                <asp:RangeValidator ID="RangeFieldValidatorAge" ControlToValidate="AgeTextBox" runat="server"
                    Display="Dynamic" Type="Integer" MinimumValue="18" MaximumValue="81"
                    ErrorMessage="Age must be in range [18..81]" ForeColor="Red" ValidationGroup="PersonalInfoGroup"/>
            </div>
            <asp:Button ID="PersonalInfoButton" Text="Submit" runat="server" OnClick="PersonalInfoButton_Click" ValidationGroup="PersonalInfoGroup"/>
            <asp:ValidationSummary runat="server" ForeColor="Red" ValidationGroup="PersonalInfoGroup"/>
        </asp:Panel>

        <asp:Panel runat="server" ID="AddressGroupPanel" GroupingText="Address">
            <div>
                <asp:Label Text="Email: " runat="server" />
                <asp:TextBox ID="EmailTextBox" runat="server" placeholder="Email" TextMode="Email" ValidationGroup="AddressGroup"/>

                <asp:RequiredFieldValidator ID="RequiredFieldValidatorEmail" ControlToValidate="EmailTextBox" runat="server"
                    Display="Dynamic" Text="Required Field" ErrorMessage="Email field is required!" ForeColor="Red" ValidationGroup="AddressGroup"/>
                <asp:RegularExpressionValidator ID="RegularExpressionValidatorEmail" runat="server" ForeColor="Red" Display="Dynamic" ErrorMessage="Email address is incorrect!" ControlToValidate="EmailTextBox" EnableClientScript="False"
                    ValidationExpression="[a-zA-Z][a-zA-Z0-9\-\.]*[a-zA-Z]@[a-zA-Z][a-zA-Z0-9\-\.]+[a-zA-Z]+\.[a-zA-Z]{2,4}" ValidationGroup="AddressGroup"/>
            </div>
            <div>
                <asp:Label Text="Local Address: " runat="server" />
                <asp:TextBox ID="LocalAddressTextBox" runat="server" placeholder="Local address" ValidationGroup="AddressGroup"/>

                <asp:RequiredFieldValidator ID="RequiredFieldValidatorAddress" ControlToValidate="LocalAddressTextBox" runat="server"
                    Display="Dynamic" Text="Required Field" ErrorMessage="Local Address field is required!" ForeColor="Red" ValidationGroup="AddressGroup"/>
            </div>
            <div>
                <asp:Label Text="Phone number: " runat="server" />
                <asp:TextBox ID="PhoneTextBox" runat="server" placeholder="Phone number" TextMode="Phone" ValidationGroup="AddressGroup"/>

                <asp:RequiredFieldValidator ID="RequiredFieldValidatorPhone" ControlToValidate="PhoneTextBox" runat="server"
                    Display="Dynamic" Text="Required Field" ErrorMessage="Phone number field is required!" ForeColor="Red" ValidationGroup="AddressGroup"/>
                <asp:RegularExpressionValidator ID="RegularExpressionValidatorPhone" runat="server" ForeColor="Red" Display="Dynamic" ErrorMessage="Phone number is incorrect!" ControlToValidate="PhoneTextBox" EnableClientScript="False" ValidationExpression="^\+?(\d[\d-. ]+)?(\([\d-. ]+\))?[\d-. ]+\d$" ValidationGroup="AddressGroup"/>
            </div>
            <div>
                <asp:CheckBox ID="AcceptCheckBox" Text="I accept" runat="server" ValidationGroup="AddressGroup"/>

                <asp:CustomValidator ID="CustomValidatorAccept" runat="server"
                    ErrorMessage="Please accept the terms..."
                    OnServerValidate="CustomValidatorAccept_ServerValidate" ValidationGroup="AddressGroup"></asp:CustomValidator>
            </div>
            <div>
                <asp:Button ID="SubmitButton" Text="Submit" runat="server" OnClick="SubmitButton_Click" 
                    ValidationGroup="AddressGroup"/>
                <asp:ValidationSummary runat="server" ForeColor="Red" ValidationGroup="AddressGroup"/>
            </div>

        </asp:Panel>        
    </form>
</body>
</html>

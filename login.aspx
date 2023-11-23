<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="SGICUwebApp.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Log In</title>
    <style type="text/css">
        body {
            font-family: Arial, sans-serif;
            background-color: #f4f4f4;
            margin: 0;
            padding: 0;
        }

        #formContainer {
            width: 400px;
            margin: 150px auto;
            background-color: #fff;
            border-radius: 5px;
            padding: 20px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }

        #formContainer h1 {
            text-align: center;
            color: #333;
        }

        #formContainer hr {
            margin: 10px 0;
            border: 0;
            border-top: 1px solid #ddd;
        }

        #formContainer label {
            display: block;
            margin-bottom: 8px;
        }

        #formContainer input {
            width: 100%;
            padding: 8px;
            margin-bottom: 16px;
            box-sizing: border-box;
        }

        #formContainer .logButton {
            background-color: #4caf50;
            color: #fff;
            padding: 10px;
            border: none;
            border-radius: 3px;
            cursor: pointer;
        }

        #formContainer .logButton:hover {
            background-color: #45a049;
        }

        #formContainer .errorText {
            color: red;
            font-weight: bold;
        }
    </style>
</head>
<body>

    <form id="form1" runat="server">
        <div id="formContainer">
            <h1>Login</h1>
            <hr />
            <label for="txtCodePermanent">Code Permanent:</label>
            <asp:TextBox ID="txtCode" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvCodePermanent" runat="server" ControlToValidate="txtCode" ErrorMessage="Code Permanent is required" ForeColor="Red"></asp:RequiredFieldValidator>

            <label for="txtPassword">Mot de Passe:</label>
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword" ErrorMessage="Mot de Passe is required" ForeColor="Red"></asp:RequiredFieldValidator>

            <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="logButton" OnClick="btnLogin_Click" />

            <asp:Label ID="lblError" runat="server" Text="" CssClass="errorText"></asp:Label>
        </div>
    </form>

</body>
</html>

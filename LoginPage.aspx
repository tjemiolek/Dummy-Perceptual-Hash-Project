<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="DPHAlgorithmProject.LoginPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">


    </style>
         <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/StyleProject.css" rel="stylesheet" />
    <script src="Scripts/jquery-3.3.1.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="appHeader">
            <span class="TitleHeader">Panel Logowania</span>
            </div>
        <div>
        </div>
        <div id="LoginPanel">
        <asp:Login ID="Login1" runat="server" OnAuthenticate="Login1_Authenticate" OnLoginError="Login1_LoginError" FailureText="There was an error while logging you in. Please try again.">
            <FailureTextStyle ForeColor="White" BackColor="Red"></FailureTextStyle>
            <LayoutTemplate>
                <table cellpadding="1" cellspacing="0" style="border-collapse:collapse;">
                    <tr>
                        <td>
                            <table cellpadding="0">
                                <tr>
                                    <td align="right" colspan="2">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="2">Zaloguj się</td>
                                </tr>
                                <tr>
                                    <td align="right" colspan="2">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        &nbsp;</td>
                                    <td class="auto-style2">
                                        <asp:TextBox ID="UserName" runat="server" CssClass="form-control" placeholder="nazwa użytkownika"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" ErrorMessage="Wprowadź nazwę użytkownika." ToolTip="Pole Nazwa użytkownika jest wymagane." ValidationGroup="Login1"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        &nbsp;</td>
                                    <td class="auto-style2">
                                        <asp:TextBox ID="Password" runat="server" CssClass="form-control" placeholder="hasło" TextMode="Password"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" ErrorMessage="Wprowadź hasło." ToolTip="Hasło jest wymagane." ValidationGroup="Login1"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="2" style="color:Red;">
                                        <asp:Button ID="LoginButton" runat="server" CssClass="btn btn-primary" CommandName="Login" Text="Zaloguj" ValidationGroup="Login1" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" colspan="2">
                                        &nbsp;</td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </LayoutTemplate>
        </asp:Login>
            </div>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DPHConnectionString %>" SelectCommand="SELECT * FROM [UserData]"></asp:SqlDataSource>
    </form>
</body>
</html>

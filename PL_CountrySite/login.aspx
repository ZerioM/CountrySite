<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PL_CountrySite.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Login</title>
      <link rel="stylesheet" href="~/Styles/styles.css"  type="text/css"/>
</head>
<body>
     <div id="wrapper">
    <form id="form1" runat="server">
        <div style="margin-left: 0px">
        <h1>Login/Registrieren</h1>
            <p>
                <asp:Label ID="lblErrorLogin" runat="server"></asp:Label>
            </p>
            <p>
                <asp:Label ID="lblUsername" runat="server" Text="Username:"></asp:Label>
                <asp:TextBox ID="tbUsername" runat="server" Width="175px"></asp:TextBox>
            </p>
            <p>
                <asp:Label ID="lblPassword" runat="server" Text="Passwort:"></asp:Label>
                <asp:TextBox ID="tbPassword" TextMode="Password" runat="server" Width="181px"></asp:TextBox>
            </p>
            <p>&nbsp;</p>
            <p>
                <asp:Button ID="btnLogin" runat="server" Text="Login/Registrieren" OnClick="btnLogin_Click" />
            </p> 


           </div>

    </form>
        </div>
</body>
</html>

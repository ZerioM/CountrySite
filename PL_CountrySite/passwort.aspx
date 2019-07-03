<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Passwort.aspx.cs" Inherits="PL_CountrySite.passwort" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Passwort ändern</title>
     <link rel="stylesheet" href="~/Styles/styles.css"  type="text/css"/>
</head>
<body>
    <div id="wrapper">
    <form id="form1" runat="server">
        <div style="margin-left: 0px">
        <h1>Passwort ändern</h1>
            <p>
                <asp:Label ID="lblErrorLogin" runat="server"></asp:Label>
            </p>
            <p>
                <asp:Label ID="lblCurrentPassword" runat="server" Text="Altes Passwort:"></asp:Label>
                <asp:TextBox ID="tbOldPassword" runat="server" Width="175px"></asp:TextBox>
            </p>
            <p>
                <asp:Label ID="lblNewPassword" runat="server" Text="Neues Passwort:"></asp:Label>
                <asp:TextBox ID="tbNewPassword" runat="server" Width="181px"></asp:TextBox>
            </p>
            <p>&nbsp;</p>
            <p>
                <asp:Button ID="btnSave" runat="server" Text="Speichern" OnClick="btnSave_Click" />
            </p> 


           </div>

    </form>
        </div>
</body>
</html>

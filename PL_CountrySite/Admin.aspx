<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="PL_CountrySite.Admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Admin</title>
    <link rel="stylesheet" href="~/Styles/styles.css"  type="text/css"/>
</head>
<body>
      <div id="wrapper">
    <form id="form1" runat="server">
        <div style="margin-left: 0px">
        <h1>Admin-Seite</h1>
             <asp:LinkButton ID="lbtnToHome"  runat="server" OnClick="lbtnToHome_Click">Home</asp:LinkButton>
            <p>
                <asp:Label ID="lblErrorAdmin" runat="server"></asp:Label>
            </p>
            <p>
                <asp:Label ID="lblNewCountry" runat="server" Text="Neues Land:"></asp:Label>
                <asp:TextBox ID="tbNewCountry" runat="server" Width="175px"></asp:TextBox>
            </p>
            <p>
                <asp:Button ID="btnAddCountry" runat="server" Text="Hinzufügen" />
            </p>
            <p>
                &nbsp;</p>
            <p>
                <asp:Label ID="lblNewTransport" runat="server" Text="Neues Transportmittel:"></asp:Label>
                <asp:TextBox ID="tbNewTransport" runat="server" Width="181px"></asp:TextBox>
            </p>
            <p>
                <asp:Button ID="btnAddTransport" runat="server" Text="Hinzufügen" />
            </p>
            <p>
                &nbsp;</p> 


           </div>

    </form>
        </div>
</body>
</html>

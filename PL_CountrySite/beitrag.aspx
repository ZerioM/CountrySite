<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Beitrag.aspx.cs" Inherits="PL_CountrySite.Beitrag" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Neuer Beitrag</title>
      <link rel="stylesheet" href="~/Styles/styles.css"  type="text/css"/>
</head>

<body>
   <div id="wrapper">
    <form id="form1" runat="server">
        <div style="margin-left: 0px">
        <h1>Neuer Beitrag</h1>
            <p>
                <asp:Label ID="lblErrorLogin" runat="server"></asp:Label>
            </p>
            <p>
                <asp:Label ID="lblCountry" runat="server" Text="Land:"></asp:Label>
                <asp:DropDownList ID="ddCountry" runat="server">
                </asp:DropDownList>
            </p>
            <p>
                <asp:Label ID="lblTransport" runat="server" Text="Transportmittel:"></asp:Label>
            </p>
            <p>
                <asp:Label ID="lblContent" runat="server" Text="Beitrag:"></asp:Label>
                <asp:TextBox ID="tbContent" runat="server" Height="113px"></asp:TextBox>
            </p>
            <p>&nbsp;</p>
            <p>
                <asp:Button ID="btnSave" runat="server" Text="Speichern" />
            </p> 


           </div>

    </form>
        </div>
</body>
</html>

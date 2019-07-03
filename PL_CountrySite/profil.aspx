<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Profil.aspx.cs" Inherits="Profil" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Profil</title>
     <link rel="stylesheet" href="~/Styles/styles.css"  type="text/css"/>
</head>
<body>
<div id="wrapper">
    <form id="form1" runat="server">
        <div style="margin-left: 0px">
         <h1>Profil von <% =Session["UserName"]%></h1>
        <asp:LinkButton ID="lbtnToNewPost"  runat="server">+</asp:LinkButton>
        <asp:LinkButton ID="lbtnToPWchange"  runat="server">Passwort ändern</asp:LinkButton>
        <asp:LinkButton ID="lbtnToHome"  runat="server" OnClick="lbtnToHome_Click">Home</asp:LinkButton>
      

            <h2>Beiträge</h2>
           
          <asp:GridView ID="gvPosts" runat="server"
                AutoGenerateColumns="False"
                 BorderStyle="None" BorderWidth="0px" CellPadding="20" 
                EmptyDataText="Keine Beiträge vorhanden" AutoGenerateSelectButton="False" > 
              

                <Columns>

                     <asp:TemplateField HeaderText="Land">
                        <ItemTemplate>
                            <asp:LinkButton ID="lbtnToCountry" runat="server" OnClick="lbtnToCountry_Click"  commandargument="<%# Container.DataItemIndex %>">
                                 <%#Eval("country.countryName") %>
                            </asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>

                     <asp:TemplateField HeaderText="Transportmittel">
                        <ItemTemplate>
                            <asp:LinkButton ID="lbtnToTransport" runat="server" OnClick="lbtnToTransport_Click" commandargument="<%# Container.DataItemIndex %>">
                                 <%#Eval("transport.transportName") %>
                            </asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:BoundField DataField="date" HeaderText="Datum" />
                    <asp:BoundField DataField="content" HeaderText="Inhalt" />
                </Columns>
                
            </asp:GridView>        </div>
    </form>
        </div>
</body>
</html>

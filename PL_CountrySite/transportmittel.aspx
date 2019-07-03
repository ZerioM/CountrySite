<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Transportmittel.aspx.cs" Inherits="PL_CountrySite.transportmittel" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Transportmittel</title>
      <link rel="stylesheet" href="~/Styles/styles.css"  type="text/css"/>
</head>
<body>
   <div id="wrapper">
    <form id="form1" runat="server">
        <div style="margin-left: 0px">
         <h1><% =Session["TransportName"]%></h1>
        <asp:LinkButton ID="lbtnToNewPost"  runat="server">+</asp:LinkButton>
        <asp:LinkButton ID="lbtnToProfile"  runat="server">Profil</asp:LinkButton>
        <asp:LinkButton ID="lbtnToHome"  runat="server">Home</asp:LinkButton>
      

            <h2>Beiträge</h2>
           
           <asp:GridView ID="gvPosts" runat="server"
                AutoGenerateColumns="False"
                 BorderStyle="None" BorderWidth="0px" CellPadding="20" 
                EmptyDataText="Keine Beiträge vorhanden"
              >

                <Columns>

                    <asp:TemplateField HeaderText="Username">
                        <ItemTemplate>
                            <asp:LinkButton ID="lbtnToUser" runat="server">
                                 <%#Eval("user.userName") %>
                            </asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>

                     <asp:TemplateField HeaderText="Land">
                        <ItemTemplate>
                            <asp:LinkButton ID="lbtnToCountry" runat="server">
                                 <%#Eval("country.countryName") %>
                            </asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>

                     <asp:TemplateField HeaderText="Transportmittel">
                        <ItemTemplate>
                            <asp:LinkButton ID="lbtnToTransport" runat="server">
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

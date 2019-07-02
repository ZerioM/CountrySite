<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="PL_CountrySite.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Country Site</title>
    <link rel="stylesheet" href="~/Styles/styles.css"  type="text/css"/>
</head>
<body>
    <div id="wrapper">
    <form id="form1" runat="server">
        <div style="margin-left: 0px">
        <h1>Country Site</h1> 
        <asp:LinkButton ID="lbtnToNewPost"  runat="server">+</asp:LinkButton>
        <asp:LinkButton ID="lbtnToProfile"  runat="server">Profile</asp:LinkButton>
        <asp:LinkButton ID="lbtnToAdmin" runat="server">Admin Seite</asp:LinkButton>

            <br />
            <br />
            <asp:TextBox ID="tbSuche" runat="server" OnTextChanged="tbSuche_TextChanged"></asp:TextBox>

            <asp:Button ID="btnSuche" runat="server" Text="Suche" />
            <br />
            <br />

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
                                 Text='<%#Eval("user.userName") %>'
                            </asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>

                     <asp:TemplateField HeaderText="Land">
                        <ItemTemplate>
                            <asp:LinkButton ID="lbtnToCountry" runat="server">
                                 Text='<%#Eval("country.countryName") %>'
                            </asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>

                     <asp:TemplateField HeaderText="Transportmittel">
                        <ItemTemplate>
                            <asp:LinkButton ID="lbtnToTransport" runat="server">
                                 Text='<%#Eval("transport.transportName") %>'
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

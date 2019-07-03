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
        <asp:LinkButton ID="lbtnToNewPost"  runat="server" OnClick="lbtnToNewPost_Click">+</asp:LinkButton>
        <asp:LinkButton ID="lbtnToProfile"  runat="server" OnClick="lbtnToProfile_Click">Profil</asp:LinkButton>
        <asp:LinkButton ID="lbtnToAdmin" runat="server" OnClick="lbtnToAdmin_Click">Admin Seite</asp:LinkButton>

            <br />
            <br />
            <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>

            <br />
            <br />
            <asp:TextBox ID="tbSearch" runat="server" OnTextChanged="tbSuche_TextChanged"></asp:TextBox>

            <asp:Button ID="btnSuche" runat="server" Text="Suche" OnClick="btnSuche_Click" />
            <br />
            <br />

            <h2>Beiträge</h2>
           
           <asp:GridView ID="gvPosts" runat="server"
               onselectedindexchanged="gvPosts_SelectedIndexChanged"  
                AutoGenerateColumns="False"
                 BorderStyle="None" BorderWidth="0px" CellPadding="20" 
                EmptyDataText="Keine Beiträge vorhanden" AutoGenerateSelectButton="False">
                <Columns>
                    <asp:CommandField ShowSelectButton="True" SelectText="Bearbeiten" />

                    <asp:TemplateField HeaderText="Username">
                        <ItemTemplate>
                            <asp:LinkButton ID="lbtnToUser" runat="server" OnClick="lbtnToUser_Click" commandargument="<%# Container.DataItemIndex %>" >
                                 <%#Eval("user.userName") %>
                            </asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>

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

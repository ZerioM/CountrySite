using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL_CountrySite;


namespace PL_CountrySite
{
    public partial class index : System.Web.UI.Page { 

        private Posts allePosts;
    
        protected void Page_Load(object sender, EventArgs e)
        {
           
           
                allePosts = Starter.getAllPosts(); 
                gvPosts.DataSource = allePosts;
                gvPosts.DataBind(); 
           
           
        }

        protected void tbSuche_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnSuche_Click(object sender, EventArgs e)
        {
            Object suche = Starter.searchByName(tbSearch.Text);
            if (suche == null)
            {
                lblError.Text = "Land/User/Transportmittel wurde nicht gefunden";
            }
            else if (suche.GetType()==typeof(Country)){
                Country country = (Country)suche;
                lblError.Text = "Land wurde gefunden";
                Session["Country"] = country;
                Session["CountryName"] = country.countryName;
                Response.Redirect("Land.aspx");

            }else if (suche.GetType() == typeof(User)) {
                User user = (User)suche;
                lblError.Text = "User wurde gefunden";
                Session["User"] = user;
                Session["UserName"] = user.userName;
                Response.Redirect("Profil.aspx");

            }
            else if (suche.GetType() == typeof(Transport))
            {
                Transport transport = (Transport)suche;
                lblError.Text = "Transport wurde gefunden";
                Session["Transport"] = transport;
                Session["TransportName"] = transport.transportName;
                Response.Redirect("Transportmittel.aspx");
            }
        }

        protected void gvPosts_SelectedIndexChanged(object sender, EventArgs e)
        {
          
            GridViewRow row = gvPosts.SelectedRow;
            // die Zeilennummer in der GridView entsricht der Position in der Liste
            Session["PostID"] = allePosts[row.RowIndex].postID; 
            Response.Redirect("Land.aspx"); 
        }

        protected void lbtnToUser_Click(object sender, EventArgs e)
        {
            GridViewRow row = gvPosts.SelectedRow;
            // die Zeilennummer in der GridView entsricht der Position in der Liste
            Session["Post"] = allePosts[row.RowIndex];
            Response.Redirect("Profil.aspx");
        }
    }
}
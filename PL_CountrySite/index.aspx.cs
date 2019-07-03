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
                lblError.Text = "Land bzw. User wurde nicht gefunden";
            }
            else if (suche.GetType()==typeof(Country)){

                lblError.Text = "Land wurde gefunden";
                Session["Country"] = suche;
                Response.Redirect("Land.aspx");

            }else if (suche.GetType() == typeof(User)) {

                lblError.Text = "User wurde gefunden";
                Session["User"] = suche;
                Response.Redirect("Profil.aspx");

            }
            else if (suche.GetType() == typeof(Transport))
            {
                lblError.Text = "Transport wurde gefunden";
                Session["Transport"] = suche;
                Response.Redirect("Transportmittel.aspx");
            }
        }

        protected void gvPosts_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
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
        private Object searchObject;
    
        protected void Page_Load(object sender, EventArgs e)
        {
           
           
                allePosts = Starter.getAllPosts();

                //List<Post> descAllPosts = allePosts.OrderByDescending(Post => Post.date).ToList<Post>();
                gvPosts.DataSource = allePosts;
                gvPosts.DataBind();

            if (Session["AdminUser"] != null)
            {
                lbtnToAdmin.Visible = true;
            }
            else {
                lbtnToAdmin.Visible = false;
            }

            if (Session["loggedInUser"] != null)
            {
                lbtnLogout.Visible = true;
                lbtnLogin.Visible = false;
            }
            else {
                lbtnLogout.Visible = false;
                lbtnLogin.Visible = true;
            }
           
        }

        protected void tbSuche_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnSuche_Click(object sender, EventArgs e)
        {
             searchObject = Starter.searchByName(tbSearch.Text);
            suche();
            
        }

        private void suche()
        {
            if (searchObject == null)
            {
                lblError.Text = "Land/User/Transportmittel wurde nicht gefunden";
            }
            else if (searchObject.GetType() == typeof(Country))
            {
                Country country = (Country)searchObject;
                Session["Country"] = country;
                Session["CountryName"] = country.countryName;
                Response.Redirect("Land.aspx");

            }
            else if (searchObject.GetType() == typeof(User))
            {
                User user = (User)searchObject;
                Session["User"] = user;
                Session["WayToProfile"] = "search";
                Session["UserName"] = user.userName;
                Response.Redirect("Profil.aspx");

            }
            else if (searchObject.GetType() == typeof(Transport))
            {
                Transport transport = (Transport)searchObject;
                Session["Transport"] = transport;
                Session["TransportName"] = transport.transportName;
                Response.Redirect("Transportmittel.aspx");
            }

        }

       

        protected void lbtnToUser_Click(object sender, EventArgs e)
        {
            LinkButton lbtnCopyToUser = (LinkButton)sender;
            int RowIndex = Convert.ToInt32(lbtnCopyToUser.CommandArgument.ToString());
            Session["Post"] = allePosts[RowIndex];
            Session["WayToProfile"] = "name";
            Response.Redirect("Profil.aspx");

           
        }

        protected void lbtnToCountry_Click(object sender, EventArgs e)
        {
            LinkButton lbtnCopyToCountry = (LinkButton)sender;
            int RowIndex = Convert.ToInt32(lbtnCopyToCountry.CommandArgument.ToString());
            Session["Post"] = allePosts[RowIndex];
            Response.Redirect("Land.aspx");


        }

        protected void lbtnToTransport_Click(object sender, EventArgs e)
        {
            LinkButton lbtnCopyToTransport = (LinkButton)sender;
            int RowIndex = Convert.ToInt32(lbtnCopyToTransport.CommandArgument.ToString());
            Session["Post"] = allePosts[RowIndex];
            Response.Redirect("Transportmittel.aspx");


        }

        protected void gvPosts_SelectedIndexChanged(object sender, EventArgs e)
        {

           GridViewRow row = gvPosts.SelectedRow;
            Session["Post"] = allePosts[row.RowIndex];
            Post selectedPost = (Post)Session["Post"];
            if (Session["loggedInUser"] != null)
            {
                loggedInUser lu = (loggedInUser)Session["loggedInUser"];
                if (selectedPost.getUser().userName.Equals(lu.userName)) { 
                    Session["WayToPost"] = "edit";
                    Response.Redirect("Beitrag.aspx");
                }
                else return;
            }
               

            Session["WayToLogin"] = "plus";
            Response.Redirect("Login.aspx");
        
           
            


        }

        protected void lbtnToNewPost_Click(object sender, EventArgs e)
        {
            Session["WayToPost"] = "plus";
            if (Session["loggedInUser"] != null) Response.Redirect("Beitrag.aspx");

            Session["WayToLogin"] = "plus";
            
            Response.Redirect("Login.aspx");
            
        }

        protected void lbtnToProfile_Click(object sender, EventArgs e)
        {
            Session["WayToLogin"] = "profile";
            Session["WayToProfile"] = "profile";
            if (Session["loggedInUser"] != null) Response.Redirect("Profil.aspx");

       
            Response.Redirect("Login.aspx");
        }

        protected void lbtnToAdmin_Click(object sender, EventArgs e)
        {
            Response.Redirect("Admin.aspx");
        }

        protected void lbtnLogout_Click(object sender, EventArgs e)
        {
            Session["loggedInUser"] = null;
            Session["AdminUser"] = null;
            Response.Redirect("index.aspx");
        }

        protected void lbtnLogin_Click(object sender, EventArgs e)
        {
            Session["WayToLogin"] = "index";
            Response.Redirect("Login.aspx");
        }

        /*protected void gvPosts_RowDataBound(object sender, GridViewRowEventArgs e) //falls man auswählen button ausblenden mag
        {
            if (e.Row.RowType == DataControlRowType.Header)
                e.Row.Cells[0].Style.Add(HtmlTextWriterStyle.Display, "none");
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[0].Style.Add(HtmlTextWriterStyle.Display, "none");
               
               
            }

        }*/
    }
}
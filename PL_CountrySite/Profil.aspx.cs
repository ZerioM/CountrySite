using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL_CountrySite;

namespace PL_CountrySite
{
    public partial class Profil : System.Web.UI.Page
    {
        private Posts allePosts;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] != null) {

                User user = (User)Session["User"];
                allePosts = user.getPosts();
                gvPosts.DataSource = allePosts;
                gvPosts.DataBind();

                Session["User"] = null;

            }
            else
            {
                Post post = (Post) Session["Post"];
                if (post != null)
                {
                    User user = post.getUser();
                    Session["UserName"] = user.userName;
                    allePosts = user.getPosts();
                    gvPosts.DataSource = allePosts;
                    gvPosts.DataBind();

                } 
            }

            if (Session["loggedInUser"] != null) {
                lbtnToPWchange.Visible = true;
            } else
            {
                lbtnToPWchange.Visible = false;
            }

           
  
            

        }

        protected void lbtnToHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
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

        protected void lbtnToPWchange_Click(object sender, EventArgs e)
        {
            Response.Redirect("Passwort.aspx");
        }
    }
}
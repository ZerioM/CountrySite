using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL_CountrySite;

namespace PL_CountrySite
{
    public partial class profil : System.Web.UI.Page
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
                User user = post.getUser();
                allePosts = user.getPosts();
                gvPosts.DataSource = allePosts;
                gvPosts.DataBind();


            }

           
  
            

        }

        protected void lbtnToHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }
    }
}
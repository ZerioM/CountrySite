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
            User user = (User)Session["User"];

            allePosts = user.getPosts();
                gvPosts.DataSource = allePosts;
                gvPosts.DataBind();
  
            

        }

       
    }
}
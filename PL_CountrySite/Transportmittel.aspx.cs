using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL_CountrySite;

namespace PL_CountrySite
{
    public partial class transportmittel : System.Web.UI.Page
    {
        private Posts allePosts;
        protected void Page_Load(object sender, EventArgs e)

        {
            Transport transport = (Transport)Session["Transport"];
            allePosts = transport.getPosts();
            gvPosts.DataSource = allePosts;
            gvPosts.DataBind();

        }

        protected void lbtnToHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }
    }
}
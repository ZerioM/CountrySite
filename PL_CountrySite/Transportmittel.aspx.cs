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

            if (Session["Transport"] != null)
            {

                Transport transport = (Transport)Session["Transport"];
                allePosts = transport.getPosts();
                gvPosts.DataSource = allePosts;
                gvPosts.DataBind();

                Session["Transport"] = null;

            }
            else
            {
                Post post = (Post)Session["Post"];
                if (post != null)
                {
                    Transport transport = post.getTransport();
                    Session["TransportName"] = transport.transportName;
                    allePosts = transport.getPosts();
                    gvPosts.DataSource = allePosts;
                    gvPosts.DataBind();

                }
            }


        }

        protected void lbtnToHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }


        protected void lbtnToUser_Click(object sender, EventArgs e)
        {
            LinkButton lbtnCopyToUser = (LinkButton)sender;
            int RowIndex = Convert.ToInt32(lbtnCopyToUser.CommandArgument.ToString());
            Session["Post"] = allePosts[RowIndex];
            Response.Redirect("Profil.aspx");


        }

        protected void lbtnToCountry_Click(object sender, EventArgs e)
        {
            LinkButton lbtnCopyToCountry = (LinkButton)sender;
            int RowIndex = Convert.ToInt32(lbtnCopyToCountry.CommandArgument.ToString());
            Session["Post"] = allePosts[RowIndex];
            Response.Redirect("Land.aspx");


        }

     
    }
}
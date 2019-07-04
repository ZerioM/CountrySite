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
            if (!IsPostBack)
            {
                if (Session["WayToProfile"].ToString().Equals("search"))
                {

                    User user = (User)Session["User"];
                    allePosts = user.getPosts();
                    Session["allePosts"] = allePosts;
                    //List<Post> descAllPosts = allePosts.OrderByDescending(Post => Post.date).ToList<Post>();
                    gvPosts.DataSource = allePosts;
                    gvPosts.DataBind();

                    Session["User"] = null;

                }
                if (Session["WayToProfile"].ToString().Equals("name"))
                {
                    Post post = (Post)Session["Post"];
                    User user = post.getUser();
                    Session["UserName"] = user.userName;
                    allePosts = user.getPosts();
                    Session["allePosts"] = allePosts;
                    // List<Post> descAllPosts = allePosts.OrderByDescending(Post => Post.date).ToList<Post>();
                    gvPosts.DataSource = allePosts;
                    gvPosts.DataBind();


                }
                if (Session["WayToProfile"].ToString().Equals("profile"))
                {
                    User user = (User)Session["loggedInUser"];
                    allePosts = user.getPosts();
                    Session["allePosts"] = allePosts;
                    // List<Post> descAllPosts = allePosts.OrderByDescending(Post => Post.date).ToList<Post>();
                    gvPosts.DataSource = allePosts;
                    gvPosts.DataBind();

                }


                if (Session["loggedInUser"] != null)
                {
                    lbtnToPWchange.Visible = true;
                    lbtnLogout.Visible = true;
                }
                else
                {
                    lbtnToPWchange.Visible = false;
                    lbtnLogout.Visible = false;
                }
            }

            allePosts = (Posts) Session["allePosts"];
            

    



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

        protected void gvPosts_SelectedIndexChanged(object sender, EventArgs e)
        {

            GridViewRow row = gvPosts.SelectedRow;
            Session["Post"] = allePosts[row.RowIndex];
            Post selectedPost = (Post)Session["Post"];
            if (Session["loggedInUser"] != null)
            {
                loggedInUser lu = (loggedInUser)Session["loggedInUser"];
                if (selectedPost.getUser().userName.Equals(lu.userName))
                {
                    Session["WayToPost"] = "edit";
                    Response.Redirect("Beitrag.aspx");
                }
                else
                {
                    lblError.Text = "Sie können nicht Beiträge anderer User bearbeiten.";
                    return;
                }
            }


            Session["WayToLogin"] = "plus";
            Response.Redirect("Login.aspx");





        }

        protected void lbtnToPWchange_Click(object sender, EventArgs e)
        {
            Response.Redirect("Passwort.aspx");
        }

        protected void lbtnToNewPost_Click(object sender, EventArgs e)
        {
            Response.Redirect("Beitrag.aspx");
        }

        protected void lbtnLogout_Click(object sender, EventArgs e)
        {
            Session["loggedInUser"] = null;
            Session["AdminUser"] = null;
            Response.Redirect("index.aspx");
        }
    }
}
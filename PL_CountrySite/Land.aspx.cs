﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL_CountrySite;

namespace PL_CountrySite
{
    public partial class Land : System.Web.UI.Page
    
    { private Posts allePosts;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["Country"] != null)
            {

                Country country = (Country)Session["Country"];
                allePosts = country.getPosts();
                //List<Post> descAllPosts = allePosts.OrderByDescending(Post => Post.date).ToList<Post>();
                gvPosts.DataSource = allePosts;
                gvPosts.DataBind();

                Session["Country"] = null;

            }
            else
            {

                Post post = (Post)Session["Post"];
                if (post != null)
                {
                    Country country = post.getCountry();
                    Session["CountryName"] = country.countryName;
                    allePosts = country.getPosts();
                    gvPosts.DataSource = allePosts;
                    gvPosts.DataBind();
                }

            }

            if (Session["loggedInUser"] != null)
            {
                lbtnLogout.Visible = true;
            }
            else
            {
                lbtnLogout.Visible = false;
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
                    Response.Redirect("Beitrag.aspx");
                else
                {
                    lblError.Text = "Sie können nicht Beiträge anderer User bearbeiten.";
                    return;
                }
            }


            Session["WayToLogin"] = "plus";
            Response.Redirect("Login.aspx");





        }

        protected void lbtnLogout_Click(object sender, EventArgs e)
        {
            Session["loggedInUser"] = null;
            Session["AdminUser"] = null;
            Response.Redirect("index.aspx");

        }
    }
}
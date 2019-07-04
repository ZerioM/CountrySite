using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL_CountrySite;

namespace PL_CountrySite
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string enteredUsername = tbUsername.Text; 
            string enteredPassword = tbPassword.Text;

            loggedInUser result = Starter.login(enteredUsername, enteredPassword);

            if (result != null) {
                if(result.GetType() == typeof(AdminUser))
                {
                    Session["AdminUser"] = result;
                }
                Session["loggedInUser"] = result;
                
                if (Session["WayToLogin"].ToString().Equals("plus")) {   
                    if(Session["Post"] != null)
                    {
                        Post selectedPost = (Post)Session["Post"];

                        loggedInUser lu = result;
                        if (selectedPost.getUser().userName.Equals(lu.userName))
                                Response.Redirect("Beitrag.aspx");
                        else Response.Redirect("index.aspx");
                        
                    }
                    Response.Redirect("Beitrag.aspx");
                }
                if (Session["WayToLogin"].ToString().Equals("index"))
                    Response.Redirect("index.aspx");
                Session["User"] = result;
                Session["UserName"] = result.userName;
                Response.Redirect("Profil.aspx");
            }

            lblErrorLogin.Text = "Login hat nicht funktioniert.";


        }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL_CountrySite;

namespace PL_CountrySite
{
    public partial class login : System.Web.UI.Page
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
                    Response.Redirect("Beitrag.aspx");
                }
                Session["User"] = result;
                Session["UserName"] = result.userName;
                Response.Redirect("Profil.aspx");
            }

            lblErrorLogin.Text = "Login hat nicht funktioniert.";


        }
    }
}
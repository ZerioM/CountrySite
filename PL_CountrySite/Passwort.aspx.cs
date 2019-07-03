using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL_CountrySite;

namespace PL_CountrySite
{
    public partial class Passwort : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string oldPassword = tbOldPassword.Text;
            string newPassword = tbNewPassword.Text;

            loggedInUser currentUser = (loggedInUser) Session["loggedInUser"];
            if(currentUser.changePassword(oldPassword, newPassword)) Response.Redirect("Profil.aspx");

            lblErrorLogin.Text = "Das Ändern des Passwortes hat leider nicht funktioniert. \n Bitte überprüfen Sie Ihr altes Passwort!";
        }
    }
}
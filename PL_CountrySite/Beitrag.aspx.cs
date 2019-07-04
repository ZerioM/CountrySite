using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL_CountrySite;

namespace PL_CountrySite
{
    public partial class Beitrag : System.Web.UI.Page
    {
       

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Post"] != null)
            {
                Post currentPost =(Post) Session["Post"];
                string content = currentPost.content;
                 string cid = currentPost.country.cID.ToString();
                 string tid = currentPost.transport.transportID.ToString();

                tbContent.Text = content;

                ddCountry.SelectedValue = cid;
                ddTransport.SelectedValue = tid;
               

            }

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string selectedCountry = ddCountry.SelectedItem.Text;
            //int selectedCountryID = Int32.Parse(ddCountry.SelectedValue);

            string selectedTransport = ddTransport.SelectedItem.Text;
            //int selectedTransportID = Int32.Parse(ddTransport.SelectedValue);

            Post newPost = new Post();
            newPost.country.countryName = selectedCountry;
            newPost.transport.transportName = selectedTransport;
            newPost.content = tbContent.Text;

            loggedInUser currentUser = (loggedInUser) Session["loggedInUser"];

            if (newPost.save(currentUser)) {
                Response.Redirect("index.aspx");
            }

            lblErrorLogin.Text = "Beitrag konnte aufgrund eines Fehlers nicht gespeichert werden.";
            
        }
    }
}
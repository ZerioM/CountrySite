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
        private Countries alleLänder;

        protected void Page_Load(object sender, EventArgs e)
        {
            

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

            loggedInUser currentUser = (loggedInUser)Session["loggedInUser"];

            newPost.save(currentUser);

            Response.Redirect("index.aspx");*/
        }
    }
}
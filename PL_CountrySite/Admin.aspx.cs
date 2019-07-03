using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL_CountrySite;

namespace PL_CountrySite
{
    public partial class Admin : System.Web.UI.Page
    {
        AdminUser admin;


        protected void Page_Load(object sender, EventArgs e)
        {
            admin = (AdminUser)Session["AdminUser"];
        }

        protected void lbtnToHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }

        protected void btnAddCountry_Click(object sender, EventArgs e)
        {
            

            Country country = new Country();
            country.countryName = tbNewCountry.Text;

            if (country.save(admin))
            {
                lblErrorAdmin.Text = "Neues Land hinzugefügt!";
            }
            else {
                lblErrorAdmin.Text = "Land konnte nicht hinzugefügt werden!";
            }
           
        }

        protected void btnAddTransport_Click(object sender, EventArgs e)
        {

            Transport transport = new Transport();
            transport.transportName = tbNewTransport.Text;

            if (transport.save(admin))
            {
                lblErrorAdmin.Text = "Neues Transportmittel hinzugefügt!";
            }
            else {
                lblErrorAdmin.Text = "Transportmittel konnte nicht hinzugefügt werden!";
            }
           
        }
    }
}
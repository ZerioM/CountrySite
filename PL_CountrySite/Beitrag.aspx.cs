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
            alleLänder = Starter.getAllCountries();
            ddCountry.DataSource = alleLänder;

           /* ddCountry.DataValueField = 
            ddCountry.DataTextField = "countryName";
            ddCountry.DataBind();*/

        }
    }
}
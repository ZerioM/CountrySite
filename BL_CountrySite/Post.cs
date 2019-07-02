using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL_CountrySite
{
    public class Post
    {
        public int postID { get; internal set; }
        public string content { get; set; }
        public string date { get; internal set; }
        public Country country { get; set; }
        public User user { get; set; }
        public Transport transport { get; set; }


        internal Post(){
            //postID = null;
        }

        public User getUser() {
            //Load user from DB
            return null;
        }

        public Country getCountry() {
            //Load country from DB
            return null;
        }

        public Transport getTransport() {
            //Load transport from DB
            return null;
        }

        public Posts save(loggedInUser currentUser) {
            return null;
        }

        

    }
}

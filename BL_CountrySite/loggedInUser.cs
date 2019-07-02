using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL_CountrySite
{
    public class loggedInUser : User
    {
        public loggedInUser changePassword(string oldPassword, string newPassword) {
            return this;
        }
    }
}

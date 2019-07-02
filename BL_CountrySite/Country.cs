using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL_CountrySite
{
    public class Country
    {
        public int cID { get; internal set; }
        public int countryName { get; set; }
        public List<int> postIDs { get; internal set; }

        public Posts getPosts()
        {
            return null;
        }

        public Country save(AdminUser admin)
        {
            return this;
        }
    }
}

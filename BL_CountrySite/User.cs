using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL_CountrySite
{
    public class User
    {
        public int uID { get; internal set; }
        public string userName { get; set; }
        public List<int> postIDs { get; internal set; }

        public Posts getPosts()
        {
            return null;
        }

    }
}

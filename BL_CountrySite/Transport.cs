using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL_CountrySite
{
    public class Transport
    {
        public int transportID { get; internal set; }
        public string transportName { get; set; }
        public List<int> postIDs { get; internal set; }

        public Posts getPosts() {
            return null;
        }

        public Transport save(AdminUser admin) {
            return this;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Entity
{
    public class Country : Entity
    {
        public virtual string Country_name { get; set; }
        public virtual int Code_Postal { get; set; }

        public virtual IList<User> User { get; set; }
    }
}

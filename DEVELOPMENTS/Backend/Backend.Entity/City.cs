using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Entity
{
    public class City : Entity
    {
        public virtual string City_Name { get; set; }
        public virtual IList<User> User { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Entity.Services
{
    public class CountryReq
    {
        public virtual string Country_Name { get; set; }
        public virtual int Code_Postal { get; set; }
    }
}

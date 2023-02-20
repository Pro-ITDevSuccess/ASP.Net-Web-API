using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Entity.Services
{
    public class ContactReq
    {
        public virtual string Email { get; set; }
        public virtual string Number { get; set; }
    }
}

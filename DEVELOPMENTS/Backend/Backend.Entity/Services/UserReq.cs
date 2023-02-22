using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Entity.Services
{
    public class UserReq
    {
        public virtual string User_FirstName { get; set; }
        public virtual string User_LastName { get; set; }
        public virtual string User_CIN { get; set; }
        public virtual DateTime User_BirthDay { get; set; }
        public virtual bool User_Genre { get; set; }
        public virtual List<ContactReq> User_Contact { get; set; }
    }
}

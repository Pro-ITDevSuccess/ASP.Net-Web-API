using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Entity.Mapping
{
    public class ContactMap : SubclassMap<Contacts>
    {
        public ContactMap()
        {
            Abstract();
            Map(x => x.Email).Not.Nullable();
            Map(x => x.Number).Not.Nullable();

            References(x => x.User)
                /*.Column("UserId")*/
                .Column("User_Id")
                .Nullable().Not.LazyLoad();
        }
    }
}

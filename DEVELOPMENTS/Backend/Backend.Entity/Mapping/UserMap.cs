using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Entity.Mapping
{
    class UserMap : SubclassMap<User>
    {
        public UserMap()
        {
            Abstract();
            Map(x => x.User_FirstName).Not.Nullable();
            Map(x => x.User_LastName).Not.Nullable();
            Map(x => x.User_CIN).Not.Nullable();
            Map(x => x.User_BirthDay).Not.Nullable();
            Map(x => x.User_Genre).Not.Nullable();

            HasManyToMany<Country>(x => x.User_Country)
                .Table("Users_Country")
                .Cascade.All()
                .Not.LazyLoad();
            
            HasManyToMany<City>(x => x.User_City)
                .Table("Users_City")
                .Cascade.All()
                .Not.LazyLoad();
            
            HasMany(x => x.User_Contacts)
                //.KeyColumn("User_Id")
                .Cascade.AllDeleteOrphan()
                //.Inverse()
                .Not.LazyLoad()
                ;
        }
    }
}

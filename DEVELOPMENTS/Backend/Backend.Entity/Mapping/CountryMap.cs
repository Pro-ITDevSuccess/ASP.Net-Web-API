using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Entity.Mapping
{
    public class CountryMap : SubclassMap<Country>
    {
        public CountryMap()
        {
            Abstract();
            Map(x => x.Country_Name).Not.Nullable();
            Map(x => x.Code_Postal).Not.Nullable();

            HasManyToMany<User>(x => x.User)
                .Table("Users_Country")
                .Cascade.All()
                .Inverse()     
                .Not.LazyLoad();
        }
    }
}

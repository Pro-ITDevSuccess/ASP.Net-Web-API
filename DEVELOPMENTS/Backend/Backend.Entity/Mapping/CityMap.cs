using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Entity.Mapping
{
    public class CityMap : SubclassMap<City>
    {
        public CityMap()
        {
            Abstract();
            Map(x => x.City_Name).Not.Nullable();

            HasManyToMany<User>(x => x.User)
                .Inverse()
                .Cascade.All()
                .Table("Adress")
                .Not.LazyLoad();
        }
    }
}

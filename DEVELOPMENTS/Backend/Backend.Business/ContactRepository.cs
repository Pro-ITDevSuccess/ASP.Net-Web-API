using Backend.Entity;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Business
{
    public class ContactRepository : EntityRepository<Contacts>
    {

        public virtual void AddContactForUser(Guid User_Id)
        {
            using(ISession session = NHibernateHelper.GetSessionFactory().OpenSession())
            {
                using(ITransaction transaction = session.BeginTransaction())
                {
                    
                 
                }
            }
        }
    }
}

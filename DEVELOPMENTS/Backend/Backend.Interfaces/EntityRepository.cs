using Backend.Entity;
using NHibernate;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Interfaces
{
    public class EntityRepository<T> where T : Backend.Entity.Entity
    {
        public virtual async Task<T> FindById(Guid Id)
        {
            using (ISession session = NHibernateHelper.GetSessionFactory().OpenSession())
            {
                return await session.GetAsync<T>(Id);
            }
        }

        public virtual async Task<List<T>> FindAll(int skip=0, int take = -1)
        {
            using (ISession session = NHibernateHelper.GetSessionFactory().OpenSession())
            {
                IQueryable<T> query = session.Query<T>();

                if (skip > 0)
                {
                    query = query.Skip(skip);
                }
                if (take > 0)
                {
                    query = query.Take(skip);
                }

                var a = await query.ToListAsync<T>();
                return a;
            }
        }

        public virtual async Task SaveOrUpdateAsynk(T entity)
        {
            using (ISession session= NHibernateHelper.GetSessionFactory().OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        await session.SaveOrUpdateAsync(entity);
                        transaction.Commit();
                    }
                    catch (Exception e)
                    {
                        transaction.Rollback();
                        throw e;
                    }
                }
            }
        }

        public virtual void SaveOrUpdate(T entity)
        {
            using (ISession session = NHibernateHelper.GetSessionFactory().OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        session.SaveOrUpdateAsync(entity);
                        transaction.Commit();
                    }
                    catch (Exception e)
                    {
                        transaction.Rollback();
                        throw e;
                    }
                }
            }
        }

        public virtual async Task DeleteById(Guid Id)
        {
            using (ISession session = NHibernateHelper.GetSessionFactory().OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        T entity = session.Get<T>(Id);
                        await session.DeleteAsync(entity);
                        transaction.Commit();
                    }
                    catch (Exception e)
                    {
                        transaction.Rollback();
                        throw e;
                    }
                }
            }
        }

        public Task DeleteByUser(User userValue)
        {
            throw new NotImplementedException();
        }
    }
}

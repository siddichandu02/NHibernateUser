using NHibernate;
using NHibernateUser.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NHibernateUser.Repository
{
    public class StoreInfoRepository : IStoreInfoRepository
    {

        public void InsertOrUpdate(StoreInfo store)
        {
            try
            {
                using (ISession session = NhibernateSession.OpenSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.SaveOrUpdate(store);
                        transaction.Commit();
                    }
                }



            }
            catch (Exception exe)
            {
                throw exe;
            }
        }

        public StoreInfo GetById(int id)
        {
            using (ISession session = NhibernateSession.OpenSession())
            {

                var store = session.Get<StoreInfo>(id);
                return store;
            }
        }

        public IEnumerable<StoreInfo> GetAll()
        {
            using (ISession session = NhibernateSession.OpenSession())
            {
                var store = session.Query<StoreInfo>().ToList();
                return store;
            }

        }

        public void Delete(int id)
        {
            try
            {

                using (ISession session = NhibernateSession.OpenSession())
                {
                    var storetoDelete = session.Get<StoreInfo>(id);

                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Delete(storetoDelete);
                        transaction.Commit();
                    }
                }

            }
            catch
            {
                return;
            }
        }
    }
}
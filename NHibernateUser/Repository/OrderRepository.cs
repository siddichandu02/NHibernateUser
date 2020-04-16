using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NHibernateUser.Repository
{
    public class OrderRepository : IOrderRepository
    {
        public void InsertOrUpdate(Orders order)
        {
            try
            {
                using (ISession session = NhibernateSession.OpenSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.SaveOrUpdate(order);
                        transaction.Commit();
                    }
                }



            }
            catch (Exception exe)
            {
                throw exe;
            }
        }

        public Orders GetById(int id)
        {
            using (ISession session = NhibernateSession.OpenSession())
            {

                var order = session.Get<Orders>(id);
                return order;
            }
        }

        public IEnumerable<Orders> GetAll()
        {
            using (ISession session = NhibernateSession.OpenSession())
            {
                var order = session.Query<Orders>().ToList();
                return order;
            }

        }

        public void Delete(int id)
        {
            try
            {

                using (ISession session = NhibernateSession.OpenSession())
                {
                    var ordertoDelete = session.Get<Orders>(id);

                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Delete(ordertoDelete);
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
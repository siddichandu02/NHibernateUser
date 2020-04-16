using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NHibernateUser.Repository
{
    public interface IOrderRepository
    {
        IEnumerable<Orders> GetAll();
        Orders GetById(int orderId);
        void InsertOrUpdate(Orders order);
        void Delete(int orderId);
        void Save();
    }
}
using NHibernateUser.Domain;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHibernateUser.Repository
{
    public interface IRepository
    {
        IEnumerable<Customer> GetAll();
        Customer GetByUserName(string UserName);
        void Insert(Customer customer);
        void Update(Customer customer,string UserName);
        void Delete(string UserName);
        void Save();
    }
}

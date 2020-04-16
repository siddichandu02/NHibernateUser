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
        IEnumerable<Users> GetAll();
        Users GetByUserName(string UserName);
        void Insert(Users customer);
        void Update(Users customer,string UserName);
        void Delete(string UserName);
        void Save();
    }
}

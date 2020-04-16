
using NHibernate;
using NHibernateUser.Domain;
using NHibernateUser.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NHibernateUser.Repository
{
    public class Repository: IRepository
    {
     
        //public Repository(EmployeeEntity _context)
        //{
        //    this._context = _context;
        //    table = _context.Set<T>();
        //}

        public void Delete(string Username)
        {
            try
            {

                using (ISession session = NhibernateSession.OpenSession())
                {
                    var usertoDelete = session.Get<Users>(Username);

                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Delete(usertoDelete);
                        transaction.Commit();
                    }
                }
                
            }
            catch 
            {
                return ;
            }
        }

        public IEnumerable<Users> GetAll()
        {
            using (ISession session = NhibernateSession.OpenSession())
            {
                var user = session.Query<Users>().ToList();
                return user;
            }

            }

        public Users GetByUserName(string Username)
        {
            using (ISession session = NhibernateSession.OpenSession())
            {
                //var customertoDelete = session.Get<Customer>(UserName);

                var user = session.Get<Users>(Username);
                return user;
            }

        }

        public void Insert(Users user)
        {
            try
            {
               

                using (ISession session = NhibernateSession.OpenSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {

                        session.Save(user);
                        transaction.Commit();
                    }
                }
               // return RedirectToAction("Index");

            }
            catch (Exception exe)
            {
                throw exe;
            }
        }

        public void Save()
        {
        }

        public void Update(Users user,string Username)
        {
            try
            {
                using (ISession session = NhibernateSession.OpenSession())
                {
                    var usertoUpdate = session.Get<Users>(Username);



                    usertoUpdate.UserPassword = user.UserPassword;
                    usertoUpdate.Firstname = user.Firstname;
                    usertoUpdate.Lastname = user.Lastname;
                    usertoUpdate.Phone = user.Phone;



                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Save(usertoUpdate);
                        transaction.Commit();
                    }
                }
                
            }
            catch
            {
                return ;
            }

        }
    }
}
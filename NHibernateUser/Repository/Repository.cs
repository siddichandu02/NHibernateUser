
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
        public bool checkUserName(string UserName)
        {
            try
            {

                using (ISession session = NhibernateSession.OpenSession())
                {
                    
                    var User = session.Get<Customer>(UserName);
                    if (User == null)
                    {
                        return true;
                    }
                    else return false;
                }

            }
            catch
            {
                return false;
            }
            
        }     
        public void Delete(string UserName)
        {
            try
            {

                using (ISession session = NhibernateSession.OpenSession())
                {
                    var customertoDelete = session.Get<Customer>(UserName);

                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Delete(customertoDelete);
                        transaction.Commit();
                    }
                }
                
            }
            catch 
            {
                return ;
            }
        }

        public IEnumerable<Customer> GetAll()
        {
            using (ISession session = NhibernateSession.OpenSession())
            {
                var customer = session.Query<Customer>().ToList();
                return customer;
            }

            }

        public Customer GetByUserName(string UserName)
        {
            using (ISession session = NhibernateSession.OpenSession())
            {
                
                var customer = session.Get<Customer>(UserName);
                return customer;
            }

        }

        public void Insert(Customer customer)
        {
            try
            {
               

                using (ISession session = NhibernateSession.OpenSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {

                        session.Save(customer);
                        transaction.Commit();
                    }
                }

            }
            catch (Exception exe)
            {
                throw exe;
            }
        }

        public void Save()
        {
        }

        public void Update(Customer customer,string UserName)
        {
            try
            {
                using (ISession session = NhibernateSession.OpenSession())
                {
                    var customertoUpdate = session.Get<Customer>(UserName);



                    customertoUpdate.Password = customer.Password;
                    customertoUpdate.FirstName = customer.FirstName;
                    customertoUpdate.LastName = customer.LastName;
                    customertoUpdate.PhoneNumber = customer.PhoneNumber;



                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Save(customertoUpdate);
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
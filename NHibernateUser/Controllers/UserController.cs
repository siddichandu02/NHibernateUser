using NHibernate;
using NHibernateUser.Domain;
using NHibernateUser.Models;
using NHibernateUser.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
//using System.ServiceModel.Channels;
using System.Web;
using System.Web.Mvc;

namespace NHibernateUser.Controllers
{
    public class UserController : Controller
    {
        IRepository repository = null;
       public  UserController(IRepository repository)
        {
            this.repository = repository;
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection collection)
        {
            try
            {
                
                string Username = collection["Username"];
                Users user = repository.GetByUserName(Username);
                if(user!=null)
                {
                    if(string.Equals(collection["UserPassword"],user.UserPassword))
                    return RedirectToAction("Index");
                    else
                        return RedirectToAction("Login");

                }
                else
                {
                    return RedirectToAction("Create");
                }

            }
            catch(Exception exception)
            {
                throw exception;
            }
        }
                // GET: Customer
        public ActionResult Index()
        {
            var users = repository.GetAll();
            return View(users);
        }

        // GET: Customer/Details/5
        public ActionResult Details(string UserName)
        {
            var user = repository.GetByUserName(UserName);
            return View(user);
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                Users user = new Users();
                user.Username = collection["Username"].ToString();
                user.Firstname = collection["Firstname"].ToString();
                user.Lastname = collection["Lastname"].ToString();
                user.UserPassword = collection["UserPassword"].ToString();
                user.Phone = collection["Phone"].ToString();
                repository.Insert(user);

                //using (ISession session = NhibernateSession.OpenSession())
                //{
                //    using (ITransaction transaction = session.BeginTransaction())
                //    {
                        
                //        session.Save(customer);
                //        transaction.Commit();
                //    }
                //}
                return RedirectToAction("Index");

            }
            catch(Exception exe)
            {
                throw exe;
            }
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(string UserName)
        {
            return View();
        }

        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult Edit(string UserName, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                Users user = new Users();

                user.Firstname = collection["Firstname"].ToString();
                user.Lastname = collection["Lastname"].ToString();
                user.UserPassword = collection["UserPassword"].ToString();
                user.Phone = collection["Phone"].ToString();
                repository.Update(user, UserName);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Delete/5
       
    }
}

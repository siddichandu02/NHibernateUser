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
    public class CustomerController : Controller
    {
        IRepository repository = null;
        public  CustomerController(IRepository repository)
        {
            this.repository = repository;
        }
        // GET: Customer
        public ActionResult Index()
        {
            var customers = repository.GetAll();
            return View(customers);
        }

        // GET: Customer/Details/5
        public ActionResult Details(string UserName)
        {
            var customer = repository.GetByUserName(UserName);
            return View(customer);
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
                Customer customer = new Customer();
                customer.UserName = collection["UserName"].ToString();
                customer.FirstName = collection["FirstName"].ToString();
                customer.LastName = collection["LastName"].ToString();
                customer.Password = collection["Password"].ToString();
                customer.PhoneNumber = collection["PhoneNumber"].ToString();
                if(repository.checkUserName(customer.UserName) == false)
                {
                    return RedirectToAction("Index");
                }
                repository.Insert(customer);
                                
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
                Customer customer = new Customer();
              
                customer.FirstName = collection["FirstName"].ToString();
                customer.LastName = collection["LastName"].ToString();
                customer.Password = collection["Password"].ToString();
                customer.PhoneNumber = collection["PhoneNumber"].ToString();
                repository.Update(customer,UserName);

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

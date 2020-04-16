using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NHibernateUser.Domain
{
    public class Customer
    {
        public virtual string UserName { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string Password { get; set; }
        public virtual string PhoneNumber { get; set; }
    }
}
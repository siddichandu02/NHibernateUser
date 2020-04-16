using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NHibernateUser.Domain
{
    public class Users
    {
        public virtual string Username { get; set; }
        public virtual string Firstname { get; set; }
        public virtual string Lastname { get; set; }
        public virtual string UserPassword { get; set; }
        public virtual string Phone { get; set; }
    }
}
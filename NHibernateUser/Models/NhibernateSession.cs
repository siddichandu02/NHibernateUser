using NHibernate.Cfg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;

namespace NHibernateUser.Models
{
    public class NhibernateSession
    {
        public static ISession OpenSession()
        {
            var configuration = new Configuration();
            var configurationPath =
                HttpContext.Current.Server.MapPath(@"~\Models\hibernate.cfg.xml");
            configuration.Configure(configurationPath);
            var employeeConfigurationFile =
                HttpContext.Current.Server.MapPath(@"~\Mappings\Customer.hbm.xml");
            configuration.AddFile(employeeConfigurationFile);
            NHibernate.ISessionFactory sessionFactory = configuration.BuildSessionFactory();
            return sessionFactory.OpenSession();
        }
    }
}
using NHibernate;
using NHibernateUser.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NHibernateUser.Repository
{
    public class ItemCatalogueRepository : IItemCatalogueRepository
    {
        public ItemsCatalogue GetById(int id)
        {
            using (ISession session = NhibernateSession.OpenSession())
            {

                var Item = session.Get<ItemsCatalogue>(id);
                return Item;
            }
        }

        public IEnumerable<ItemsCatalogue> GetAll()
        {
            using (ISession session = NhibernateSession.OpenSession())
            {
                var Item = session.Query<ItemsCatalogue>().ToList();
                return Item;
            }

        }
    }
}
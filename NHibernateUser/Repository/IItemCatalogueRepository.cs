using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHibernateUser.Repository
{
    public interface IItemCatalogueRepository
    {
        ItemsCatalogue GetById(int id);
        Enumerable<ItemsCatalogue> GetAll();
    }
}

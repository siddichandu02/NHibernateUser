using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NHibernateUser.Repository
{
    public class IStoreInfoRepository
    {
        IEnumerable<StoreInfo> GetAll();
        StoreInfo GetById(int StoreId);
        void InsertOrUpdate(StoreInfo store);
        void Delete(int storeId);
        void Save();

    }
}
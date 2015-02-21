using System;
using System.Collections.Generic;
using MyHibernate.BusinessObjects;
using MyHibernate.DataAccessLayer;
using NHibernate;

namespace MyHibernate.DataAccessLayer
{
    public class WarehouseDao : GenericDao<Warehouse>
    {
        public void SaveBatch(IList<Warehouse> lst)
        {
            using (ISession session = getSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        foreach (Warehouse wh in lst)
                        {
                            session.SaveOrUpdate("Warehouse", wh);
                        }
                        transaction.Commit();
                    }
                    catch
                    {
                        if (!transaction.WasRolledBack)
                            transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public IList<Warehouse> GetWarehouseList()
        {
            using (ISession session = getSession())
            {
                return
                    session.CreateQuery(string.Format("from Warehouse")).List<Warehouse>();
            }
        }

        public Warehouse GetWHById(string ID)
        {
            using (ISession session = getSession())
            {
                return
                    session.CreateQuery(string.Format("from Warehouse as W where W.ID='{0}'", ID)).UniqueResult<Warehouse>();
            }
        }

        public string GetWarehouseCode()
        {
            string WHCode = "";
            using (ISession session = getSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try 
                    {
                        Warehouse wh = session.CreateQuery("from Warehouse as WH where WH.isDefault=1").UniqueResult<Warehouse>();

                        if (wh != null)
                        {
                            WHCode = wh.ID;
                        }
                    }
                    catch
                    {
                        if (!transaction.WasRolledBack)
                            transaction.Rollback();
                        throw;
                    }
 
                }
            }

            return WHCode;
        }
    }
}

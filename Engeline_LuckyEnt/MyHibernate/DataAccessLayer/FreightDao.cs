using System;
using System.Collections.Generic;
using MyHibernate.BusinessObjects;
using MyHibernate.DataAccessLayer;
using NHibernate;

namespace MyHibernate.DataAccessLayer
{
    public class FreightDao : GenericDao<Freight>
    {
        public IList<StockIn> GetAllStockInByFreightID(Int32 ID)
        {
            using (ISession session = getSession())
            {
                return session.CreateQuery("from StockIn as SI where SI.freight.ID=" + ID).List<StockIn>();
            }
        }

        public void Save(Freight freight, IList<StockIn> lstSI)
        {
            using (ISession session = getSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        session.SaveOrUpdate("Freight", freight);

                        string SQL = "update StockIn as SI SET SI.freight.ID=0 where SI.freight.ID=" + freight.ID;
                        session.CreateQuery(SQL).ExecuteUpdate();

                        foreach (StockIn si in lstSI)
                        {
                            si.freight = freight;
                            session.SaveOrUpdate("StockIn", si);

                            SQL = string.Format("update StockInDetails as sid SET sid.freight={0} where sid.stockin.ID={1}",
                                                freight.FreightPercentage, si.ID);
                            session.CreateQuery(SQL).ExecuteUpdate();
                        }
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        if (!transaction.WasRolledBack)
                            transaction.Rollback();
                        throw;
                    }
                }
            }
        }
    }
}
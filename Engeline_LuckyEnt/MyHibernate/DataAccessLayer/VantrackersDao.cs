using System;
using System.Collections.Generic;
using MyHibernate.BusinessObjects;
using MyHibernate.DataAccessLayer;
using NHibernate;

namespace MyHibernate.DataAccessLayer
{
    public class VantrackersDao : GenericDao<Vantrackers>
    {
        public void SaveBatch(IList<Vantrackers> lst)
        {
            using (ISession session = getSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        foreach (Vantrackers V in lst)
                        {
                            session.SaveOrUpdate("Vantrackers", V);
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
    }
}

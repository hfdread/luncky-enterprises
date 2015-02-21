using System;
using System.Collections.Generic;
using MyHibernate.BusinessObjects;
using MyHibernate.DataAccessLayer;
using NHibernate;
using NHibernate.Criterion;

namespace MyHibernate.DataAccessLayer
{
    public class ShippingDao : GenericDao<Shipping>
    {
        public void SaveBatch(IList<Shipping> lst)
        {
            using (ISession session = getSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        foreach (Shipping ship in lst)
                        {
                            session.Save("Shipping", ship);
                        }
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        SetErrorMessage(ex);
                        if (!transaction.WasRolledBack)
                            transaction.Rollback();
                        throw;
                    }
                }
            }
        }
    }
}

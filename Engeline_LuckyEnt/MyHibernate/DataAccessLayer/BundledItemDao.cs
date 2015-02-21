using System;
using System.Collections.Generic;
using MyHibernate.BusinessObjects;
using MyHibernate.DataAccessLayer;
using NHibernate;

namespace MyHibernate.DataAccessLayer
{
    public class BundledItemDao : GenericDao<BundledItem>
    {
        public override void Save(BundledItem BI)
        {
            using (ISession session = getSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        session.SaveOrUpdate("BundledItem", BI);

                        session.Delete("from BundledItemDetails as bid where bid.bundleditem.ID=" + BI.ID);
                        foreach (BundledItemDetails bid in BI.details)
                        {
                            bid.bundleditem = BI;
                            session.SaveOrUpdate("BundledItemDetails", bid);
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

        public override void Delete(BundledItem BI)
        {
            using (ISession session = getSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        foreach (BundledItemDetails bid in BI.details)
                        {
                            session.Delete("BundledItemDetails", bid);
                        }
                        session.Delete("BundledItem", BI);
                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public IList<BundledItem> getAllRecordsByCriteria(string Condition)
        {
            using (ISession session = getSession())
            {
                if (Condition != "")
                {
                    string SQL = string.Format(
                       "from BundledItem as bi where bi.Name like '{0}' or bi.Description like '{0}'", Condition);
                    return session.CreateQuery(SQL).List<BundledItem>();
                }
                else
                {
                    return session.CreateQuery("from BundledItem").List<BundledItem>();
                }
            }
        }

        public bool AllowModify(Int32 BundleID)
        {
            using (ISession session = getSession())
            {
                return true;
                //Int32 count = session.CreateQuery("select count(*) from ")
            }
        }
    }
}
using System;
using System.Collections.Generic;
using MyHibernate.BusinessObjects;
using MyHibernate.DataAccessLayer;
using NHibernate;

namespace MyHibernate.DataAccessLayer
{
    public class AgentQuotaDao : GenericDao<AgentQuota>
    {
        public override void Save(AgentQuota AQ)
        {
            using (ISession session = getSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        //save FixSalesDetails
                        session.Save("AgentQuotaFixSalesDetails", AQ.FixSalesDetails);

                        //save main AgentQuota
                        session.Save("AgentQuota", AQ);

                        //save item details
                        foreach (AgentQuotaItemDetails aqid in AQ.ItemDetails)
                        {
                            aqid.quota = AQ;
                            session.SaveOrUpdate("AgentQuotaItemDetails", aqid);
                            foreach (AgentQuotaExemptItem exemptitem in aqid.ExemptedItems)
                            {
                                exemptitem.ItemDetail = aqid;
                                session.SaveOrUpdate("AgentQuotaExemptItem", exemptitem);
                            }
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

        public override void Delete(AgentQuota AQ)
        {
            using (ISession session = getSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        AgentQuota quota = session.Get<AgentQuota>(AQ.ID);
                        //remove item details exempt items
                        foreach (AgentQuotaItemDetails detail in quota.ItemDetails)
                        {
                            session.Delete("from AgentQuotaExemptItem as e where e.ItemDetail.ID=" + detail.ID);
                        }

                        //delete also agent commission item details based on this quota
                        string SQL = "";
                        string SQL2 = "";

                        SQL2 = string.Format("select ID from AgentQuotaItemDetails aqid where aqid.quota.ID={0}", quota.ID);
                        SQL = string.Format("from AgentCommissionItemDetails acid where acid.ItemDetails.ID in ({0})", SQL2);
                        session.Delete(SQL);

                        //remove item details
                        session.Delete(string.Format("from AgentQuotaItemDetails as I where I.quota.ID={0}", quota.ID));

                        //delete from main table
                        session.Delete("AgentQuota", quota);

                        //remove fix sales 
                        session.Delete("AgentQuotaFixSalesDetails", quota.FixSalesDetails);

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

        public IList<AgentQuota> getAllRecordsByAgent(Int32 AgentID)
        {
            using (ISession session = getSession())
            {
                return
                   session.CreateQuery(string.Format("from AgentQuota as a where a.Agent.ID={0}", AgentID)).List<AgentQuota>
                      ();
            }
        }

        public IList<Int32> getAllExemptedItemsByAgent(Int32 AgentID)
        {
            using (ISession session = getSession())
            {
                //AgentQuotaExemptItem ex;
                string SQL =
                   string.Format("select e.ItemID from AgentQuotaExemptItem as e where e.ItemDetail.quota.Agent.ID={0}",
                                 AgentID);
                return session.CreateQuery(SQL).List<Int32>();
            }
        }

        public IList<Int32> getAllHandledItemsByAgent(IList<string> lstItemNames)
        {
            if (lstItemNames.Count == 0)
                return new List<Int32>();

            using (ISession session = getSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    IList<Int32> lstID = new List<Int32>();
                    IMultiQuery query = session.CreateMultiQuery();
                    foreach (string item in lstItemNames)
                    {
                        query.Add(
                           session.CreateQuery(string.Format("select I.ID from Items as I where I.Name like '{0}'", item)));
                    }
                    //IList<IList<Int32>> lstresult = query.List();
                    System.Collections.IList colResult = query.List();

                    foreach (System.Collections.ArrayList lst in colResult)
                    {
                        foreach (Int32 ID in lst)
                        {
                            if (!lstID.Contains(ID))
                                lstID.Add(ID);
                        }
                    }
                    return lstID;
                }
            }
        }
    }
}

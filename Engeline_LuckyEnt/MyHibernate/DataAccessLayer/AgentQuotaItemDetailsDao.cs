using System;
using System.Collections.Generic;
using MyHibernate.BusinessObjects;
using MyHibernate.DataAccessLayer;
using NHibernate;

namespace MyHibernate.DataAccessLayer
{
    public class AgentQuotaItemDetailsDao : GenericDao<AgentQuotaItemDetails>
    {
        public override void Save(AgentQuotaItemDetails AQID)
        {
            using (ISession session = getSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        bool bNewItem = (AQID.ID == 0);

                        session.SaveOrUpdate("AgentQuotaItemDetails", AQID);

                        //clear exempt items
                        session.Delete("from AgentQuotaExemptItem as e where e.ItemDetail.ID=" + AQID.ID);
                        foreach (AgentQuotaExemptItem e in AQID.ExemptedItems)
                        {
                            e.ItemDetail = AQID;
                            session.Save("AgentQuotaExemptItem", e);
                        }

                        //also add this item to all other existing quotas
                        IList<AgentQuota> lstQuota =
                           session.CreateQuery("from AgentQuota as q where q.Agent.ID=" + AQID.quota.Agent.ID).List
                              <AgentQuota>();
                        bool bFound = false;
                        AgentQuotaItemDetails detail = null;
                        foreach (AgentQuota quota in lstQuota)
                        {
                            if (quota.ID == AQID.quota.ID)
                                continue;

                            bFound = false;
                            foreach (AgentQuotaItemDetails detail_ in quota.ItemDetails)
                            {
                                if (detail_.ItemName == AQID.ItemName)
                                {
                                    bFound = true;
                                    detail = detail_;
                                    break;
                                }
                            }
                            if (!bFound)
                            {
                                //new item
                                detail = new AgentQuotaItemDetails();
                                detail.ItemName = AQID.ItemName;
                                detail.LimitValue = AQID.LimitValue;
                                detail.PercentCommission = AQID.PercentCommission;
                                detail.quota = quota;
                                session.Save("AgentQuotaItemDetails", detail);

                                //save exempt items
                                session.Delete("from AgentQuotaExemptItem as e where e.ItemDetail.ID=" + AQID.ID);
                                foreach (AgentQuotaExemptItem e in AQID.ExemptedItems)
                                {
                                    AgentQuotaExemptItem exempt = new AgentQuotaExemptItem();
                                    exempt.ItemID = e.ItemID;
                                    exempt.ItemDetail = detail;
                                    session.Save("AgentQuotaExemptItem", exempt);
                                }
                            }
                            else
                            {
                                detail = session.Get<AgentQuotaItemDetails>(detail.ID);

                                session.Delete("from AgentQuotaExemptItem as e where e.ItemDetail.ID=" + detail.ID);
                                foreach (AgentQuotaExemptItem e in AQID.ExemptedItems)
                                {
                                    AgentQuotaExemptItem exempt = new AgentQuotaExemptItem();
                                    exempt.ItemID = e.ItemID;
                                    exempt.ItemDetail = detail;
                                    session.Save("AgentQuotaExemptItem", exempt);
                                }
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

        public override void Delete(AgentQuotaItemDetails AQID)
        {
            using (ISession session = getSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        //also delete item from other quotas
                        IList<AgentQuota> lstQuota =
                           session.CreateQuery("from AgentQuota as q where q.Agent.ID=" + AQID.quota.Agent.ID).List
                              <AgentQuota>();
                        foreach (AgentQuota quota in lstQuota)
                        {
                            if (quota.ID != AQID.quota.ID)
                            {
                                AgentQuotaItemDetails itemd =
                                   session.CreateQuery(
                                      string.Format(
                                         "from AgentQuotaItemDetails as a where a.quota.ID={0} and a.ItemName='{1}'", quota.ID,
                                         AQID.ItemName)).UniqueResult<AgentQuotaItemDetails>();
                                session.Delete("from AgentQuotaExemptItem as e where e.ItemDetail.ID=" + itemd.ID);
                                session.Delete("from AgentQuotaItemDetails as a where a.ID=" + itemd.ID);
                            }
                        }

                        //AgentQuotaItemDetails detail = session.Get<AgentQuotaItemDetails>(AQID.ID);

                        //clear exempt items
                        session.Delete("from AgentQuotaExemptItem as e where e.ItemDetail.ID=" + AQID.ID);
                        //delete from main table
                        session.Delete("from AgentQuotaItemDetails as a where a.ID=" + AQID.ID);

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

        public IList<Int32> getHandledItems(string ItemName)
        {
            using (ISession session = getSession())
            {
                string SQL = string.Format(
                   "select I.ID from Items as I where I.Name like '{0}' or I.Description like '{0}'", ItemName);
                IList<Int32> result = session.CreateQuery(SQL).List<Int32>();
                return result;
            }
        }

        public IList<AgentQuotaItemDetails> getAllByQuota(Int32 QuotaID)
        {
            using (ISession session = getSession())
            {
                string SQL = string.Format("from AgentQuotaItemDetails as a where a.quota.ID={0}", QuotaID);
                return session.CreateQuery(SQL).List<AgentQuotaItemDetails>();
            }
        }
    }
}
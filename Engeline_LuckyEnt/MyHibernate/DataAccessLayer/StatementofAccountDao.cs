using System;
using System.Collections.Generic;
using MyHibernate.BusinessObjects;
using MyHibernate.DataAccessLayer;
using NHibernate;
using NHibernate.Criterion;

namespace MyHibernate.DataAccessLayer
{
    public class StatementofAccountDao : GenericDao<StatementofAccount>
    {
        public void Save(StatementofAccount SOC)
        {
            using (ISession session = getSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        session.SaveOrUpdate("StatementofAccount", SOC);
                        int i = 1;
                        foreach (StatementofAccountDetails socd in SOC.details)
                        {
                            socd.statementofaccount = SOC;
                            socd.ItemIndex = i;
                            session.SaveOrUpdate("StatementofAccountDetails", socd);
                            i += 1;
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

        public void StatusUpdate(StatementofAccount SOC)
        {
            using (ISession session = getSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        session.SaveOrUpdate("StatementofAccount", SOC);
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

        public IList<StatementofAccount> GetAllRecordsByDateRange(DateTime from, DateTime to, bool bIncludeSupplierManila, bool bIncluceCanceled, string BillofLeading, string vanStatus)
        {
            int iJoin = 0;
            using (ISession session = getSession())
            {
                string SQL = string.Format("from StatementofAccount soc where soc.TransactionDate between '{0}' and '{1}'", from.ToString(FMT_MYSQL_DATE_START), to.ToString(FMT_MYSQL_DATE_END));
                switch (vanStatus.ToLower())
                {
                    case "arrived":
                        SQL = string.Format("select distinct soc.* from StatementofAccount soc inner join statementofaccountdetails socd ON soc.ID=socd.SOC_ID where soc.TransactionDate between '{0}' and '{1}' and socd.Status=0",
                            from.ToString(FMT_MYSQL_DATE_START), to.ToString(FMT_MYSQL_DATE_END));
                        iJoin = 1;
                        break;
                    case "shutout":
                        SQL = string.Format("select distinct soc.* from StatementofAccount soc inner join statementofaccountdetails socd ON soc.ID=socd.SOC_ID where soc.TransactionDate between '{0}' and '{1}' and socd.Status=1",
                            from.ToString(FMT_MYSQL_DATE_START), to.ToString(FMT_MYSQL_DATE_END));
                        iJoin = 1;
                        break;
                    case "cancelled":
                        SQL = string.Format("select distinct soc.* from StatementofAccount soc inner join statementofaccountdetails socd ON soc.ID=socd.SOC_ID where soc.TransactionDate between '{0}' and '{1}' and socd.Status=2",
                            from.ToString(FMT_MYSQL_DATE_START), to.ToString(FMT_MYSQL_DATE_END));
                        iJoin = 1;
                        break;
                    default:
                        break;
                }

                if (!bIncludeSupplierManila)
                    SQL += string.Format(" and soc.Supplier.ContactType!={0}", (int)Contacts.eContactType.SuppliersManila);
                if (!bIncluceCanceled)
                    SQL += " and soc.Canceled=0";

                if (BillofLeading.Length > 0)
                    SQL += string.Format(" and soc.BillofLeading LIKE '%{0}%'", BillofLeading);

                if (iJoin != 0)
                {
                    return session.CreateSQLQuery(SQL).AddEntity(typeof(StatementofAccount)).List<StatementofAccount>();
                }
                else
                {
                    return session.CreateQuery(SQL).List<StatementofAccount>();
                }
            }
        }

        public IList<StatementofAccount> GetAllArrivedShipment(DateTime from, DateTime to)
        {
            using (ISession session = getSession())
            {
                string SQL = string.Format("from StatementofAccount SOC where SOC.EstimatedArrival between '{0}' and '{1}'", from.ToString(FMT_MYSQL_DATE), to.ToString(FMT_MYSQL_DATE_END));
                return session.CreateQuery(SQL).List<StatementofAccount>();
            }
        }

        public IList<StatementofAccount> GetAllSOCforStockIn(string conditionIDs, string fld, Int32 value)
        {
            using (ISession session = getSession())
            {
                string SQL = "";
                if(conditionIDs.Length > 0)
                    SQL = string.Format("from StatementofAccount soc where soc.ID not in {0} and soc.{1}={2}", conditionIDs, fld, value);
                else
                    SQL = string.Format("from StatementofAccount soc where soc.{1}={2}", conditionIDs, fld, value);
                return session.CreateQuery(SQL).List<StatementofAccount>();
            }
        }

        public double GetTotalAmountDue(Int32 socID)
        {
            using (ISession session = getSession())
            {
                string SQL = string.Format("from StatementofAccount soc where soc.ID={0}", socID);
                StatementofAccount soc = session.CreateQuery(SQL).UniqueResult<StatementofAccount>();

                return soc.AmountDue;
            }
        }

        public Int32 GetLastID()
        {
            using (ISession session = getSession())
            {
                string SQL = string.Format("select MAX(soc.ID) from StatementofAccount soc");
                Int32 lastID = session.CreateQuery(SQL).UniqueResult<Int32>();

                return lastID;
            }
        }
    }
}

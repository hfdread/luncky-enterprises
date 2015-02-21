using System;
using System.Collections.Generic;
using MyHibernate.BusinessObjects;
using MyHibernate.DataAccessLayer;
using NHibernate;
using NHibernate.Criterion;

namespace MyHibernate.DataAccessLayer
{
    public class SOC_PaymentsDao : GenericDao<SOC_Payments>
    {
        public void Save(SOC_Payments soc_p)
        {
            using (ISession session = getSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try 
                    {
                        session.Save("SOC_Payments", soc_p);
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        if (!transaction.WasRolledBack)
                            transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }

        public IList<SOC_Payments> GetAllPartialPayments(Int32 SOC_ID)
        {
            using (ISession session = getSession())
            {
                string SQL = string.Format("from SOC_Payments as SOCP where SOCP.statementofaccount.ID={0} order by ctr asc", SOC_ID);
                return session.CreateQuery(SQL).List<SOC_Payments>();
            }
        }

        public int GetLastCounter(Int32 SOC_ID)
        {
            using (ISession session = getSession())
            {
                string SQL = string.Format("from SOC_Payments as SOCP where SOCP.statementofaccount.ID={0} order by SOCP.ctr desc LIMIT 0,1", SOC_ID);
                SOC_Payments payment = session.CreateQuery(SQL)
                    .SetMaxResults(1)
                    .UniqueResult<SOC_Payments>();
                if (payment != null)
                    return payment.ctr;
                else
                    return 0;
            }
        }

        public IList<SOC_Payments> GetAllPayments(Int32 SOC_ID)
        {
            using (ISession session = getSession())
            {
                string SQL = string.Format("from SOC_Payments as SOCP where SOCP.statementofaccount.ID={0} order by SOCP.ctr asc", SOC_ID);
                return session.CreateQuery(SQL).List<SOC_Payments>();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using MyHibernate.BusinessObjects;
using MyHibernate.DataAccessLayer;
using NHibernate;
using NHibernate.Criterion;

namespace MyHibernate.DataAccessLayer
{
    public class AgentCommissionDao : GenericDao<AgentCommission>
    {
        public IList<AgentCommission> getAllRecordsByCriteria(Int32 AgentID, DateTime dateFrom, DateTime dateTo)
        {
            using (ISession session = getSession())
            {
                string SQL = string.Format("from AgentCommission as ac where ac.Agent.ID={0} and ac.Invoice.Deleted=0 and ac.Invoice.InvoiceDate between '{1}' and '{2}'",
                      AgentID, dateFrom.ToString(FMT_MYSQL_DATE_START), dateTo.ToString(FMT_MYSQL_DATE_END));
                return session.CreateQuery(SQL).List<AgentCommission>();
            }
        }

        public IList<AgentCommission> getAllRecordsByCriteria(string AgentIDs, DateTime dateFrom, DateTime dateTo, string sOrder = "")
        {
            using (ISession session = getSession())
            {
                AgentCommission ac;

                string SQL = string.Format("from AgentCommission as ac where ac.Agent.ID in ({0}) and ac.Invoice.Deleted=0 and ac.Invoice.InvoiceDate between '{1}' and '{2}'",
                      AgentIDs, dateFrom.ToString(FMT_MYSQL_DATE_START), dateTo.ToString(FMT_MYSQL_DATE_END));

                if (sOrder != "")
                {
                    SQL += string.Format(" order by {0}", sOrder);
                }
                return session.CreateQuery(SQL).List<AgentCommission>();
            }
        }
    }
}
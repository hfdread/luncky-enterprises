using System;
using System.Collections.Generic;
using MyHibernate.BusinessObjects;
using MyHibernate.DataAccessLayer;
using NHibernate;
using NHibernate.Criterion;


namespace MyHibernate.DataAccessLayer
{
    public class StatementofAccountDetailsDao : GenericDao<StatementofAccountDetails>
    {
        public IList<StatementofAccountDetails> getTrxVan(StatementofAccountDetails socd)
        {
            using (ISession session = getSession())
            {
                return session.CreateQuery("from StatementofAccountDetails as SOCD where SOCD.statementofaccount.ID=" 
                    + socd.statementofaccount.ID + " AND SOCD.VanNumber=" + socd.VanNumber).List<StatementofAccountDetails>();
            }
        }

        public IList<StatementofAccountDetails> GetDetailsByVan(StatementofAccount soc)
        {
            using (ISession session = getSession())
            {
                string SQL = string.Format("from StatementofAccountDetails as socd where socd.statementofaccount.ID={0} group by socd.VanNumber", soc.ID);
                return session.CreateQuery(SQL).List<StatementofAccountDetails>();
            }
        }
    }
}

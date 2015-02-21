using System;
using System.Collections.Generic;
using MyHibernate.BusinessObjects;
using MyHibernate.DataAccessLayer;
using NHibernate;

namespace MyHibernate.DataAccessLayer
{
    public class RequestApprovalDao : GenericDao<RequestApproval>
    {
        public IList<RequestApproval> getAllPendingRequest()
        {
            using (ISession session = getSession())
            {
                string SQL = string.Format("from RequestApproval as ra where ra.Status={0} ORDER BY ra.RequestDate DESC", (Int32)RequestApproval.eStatus.Pending);
                return session.CreateQuery(SQL).List<RequestApproval>();
            }
        }

        public IList<RequestApproval> getAllNewPendingRequest(string IDs)
        {
            using (ISession session = getSession())
            {
                string SQL = string.Format("FROM RequestApproval as ra where ra.Status={0} and ra.ID not in ({1}) order by ra.RequestDate DESC",
                                           (Int32)RequestApproval.eStatus.Pending, IDs);
                return session.CreateQuery(SQL).List<RequestApproval>();
            }
        }

        //cleaning
        public int RemoveOldPendingRequests(DateTime dtFrom)
        {
            using (ISession session = getSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        string SQL = string.Format("DELETE FROM RequestApproval ra where ra.Status={0} and ra.RequestDate<='{1}' order by ra.RequestDate DESC", (int)RequestApproval.eStatus.Pending, dtFrom.ToString(FMT_MYSQL_DATE));
                        session.CreateQuery(SQL).ExecuteUpdate();
                        transaction.Commit();
                        return 0;
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        return -1;
                    }

                }
            }
        }
    }
}

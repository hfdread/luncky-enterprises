using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using MyHibernate.BusinessObjects;
using MyHibernate.DataAccessLayer;
using NHibernate;

namespace MyHibernate.DataAccessLayer
{
    public class ReleaseOrderDao : GenericDao<ReleaseOrder>
    {
        public IList<SalesInvoice> GetPendingDRs(string DRList)
        {
            using (ISession session = getSession())
            {
                string SQL = "";
                if (DRList.Trim() != "")
                {
                    string[] parts = new Regex("[,]+").Split(DRList);
                    string newDRs = "";
                    foreach (string s in parts)
                    {
                        newDRs += Convert.ToInt32(s).ToString() + ",";
                    }

                    SQL = string.Format("from SalesInvoice siv where siv.ID NOT IN({0}) order by siv.ID", newDRs.Remove(newDRs.LastIndexOf(",")));
                }
                else
                {
                    SQL = string.Format("from SalesInvoice siv order by siv.ID");
                }
                return session.CreateQuery(SQL).List<SalesInvoice>();
            }
        }

        public string GetDRList(string DRList)//parameter is also the return value
        {
            using (ISession session = getSession())
            {
                string SQL = "";
                SQL = string.Format("from ReleaseOrder");
                IList<ReleaseOrder> roList = session.CreateQuery(SQL).List<ReleaseOrder>();

                if (roList.Count > 0)
                {
                    foreach (ReleaseOrder ro in roList)
                    {
                        DRList += ro.DR_Number;
                    }

                    DRList = DRList.Remove(DRList.LastIndexOf(","));
                }
            }

            return DRList;
        }
    }
}

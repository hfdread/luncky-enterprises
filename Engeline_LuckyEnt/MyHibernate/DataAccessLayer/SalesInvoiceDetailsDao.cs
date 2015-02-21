using System;
using System.Collections.Generic;
using MyHibernate.BusinessObjects;
using MyHibernate.DataAccessLayer;
using NHibernate;

namespace MyHibernate.DataAccessLayer
{
    public class SalesInvoiceDetailsDao : GenericDao<SalesInvoiceDetails>
    {
        public IList<SalesInvoiceDetails> GetDRDetails(string lstDR)
        {
            using (ISession session = getSession())
            {
                
                string SQL = string.Format("from SalesInvoiceDetails sivd where sivd.salesinvoice.ID in ({0})", lstDR.Remove(lstDR.LastIndexOf(",")));
                return session.CreateQuery(SQL).List<SalesInvoiceDetails>();
            }
        }

        public string GetWarehouseForReleaseOrder(SalesInvoiceDetails sivd)
        {
            using (ISession session = getSession())
            {
                string SQL = "";
                SQL = string.Format("from SalesInvoiceDetails_StockIn sivd_si where sivd_si.salesinvoicedetails.ID={0}", sivd.ID);
                SalesInvoiceDetails_StockIn sivd_si = session.CreateQuery(SQL).UniqueResult<SalesInvoiceDetails_StockIn>();

                SQL = string.Format("from StockInDetails sid where sid.ID={0}", sivd_si.stockindetails.ID);
                StockInDetails sid = session.CreateQuery(SQL).UniqueResult<StockInDetails>();

                SQL = string.Format("from Warehouse w where w.ID='{0}'", sid.WarehouseStockin);
                Warehouse W = session.CreateQuery(SQL).UniqueResult<Warehouse>();

                string wrehouse = string.Format("{0},{1}", W.ID, W.Name);
                return wrehouse;
            }
        }
    }
}
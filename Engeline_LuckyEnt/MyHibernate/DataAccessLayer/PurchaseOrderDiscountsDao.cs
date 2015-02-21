using System;
using System.Collections.Generic;
using MyHibernate.BusinessObjects;
using MyHibernate.DataAccessLayer;
using NHibernate;

namespace MyHibernate.DataAccessLayer
{
    public class PurchaseOrderDiscountsDao : GenericDao<PurchaseOrderDiscounts>
    {
        public IList<PurchaseOrderDiscounts> GetItemDiscounts(Int32 SupplierID, Int32 ItemID)
        {
            using (ISession session = getSession())
            {
                return
                   session.CreateQuery(
                      string.Format("from PurchaseOrderDiscounts as POD where POD.Supplier.ID={0} and POD.item.ID={1}",
                                    SupplierID, ItemID)).List<PurchaseOrderDiscounts>();
            }
        }

        public bool DiscountExists(Int32 SupplierID, Int32 ItemID, string Discount)
        {
            using (ISession session = getSession())
            {
                string SQL =
                   string.Format(
                      "from PurchaseOrderDiscounts as POD where POD.Supplier.ID={0} and  POD.item.ID={1} and  POD.Discount='{2}'",
                      SupplierID, ItemID, Discount);
                if (session.CreateQuery(SQL).UniqueResult<PurchaseOrderDiscounts>() != null)
                    return true;
                else
                    return false;
            }
        }
    }
}
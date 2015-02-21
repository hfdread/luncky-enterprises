using System;
using System.Collections.Generic;
using MyHibernate.BusinessObjects;
using MyHibernate.DataAccessLayer;
using NHibernate;

namespace MyHibernate.DataAccessLayer
{
    public class PurchaseOrderDao : GenericDao<PurchaseOrder>
    {
        public override void Save(PurchaseOrder PO)
        {
            using (ISession session = getSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        Int32 index = 0;
                        //save parent
                        session.SaveOrUpdate("PurchaseOrder", PO);

                        foreach (PurchaseOrderDetails POD in PO.details)
                        {
                            index++;
                            POD.purchaseorder = PO;
                            POD.ItemIndex = index;
                            session.SaveOrUpdate("PurchaseOrderDetails", POD);

                            if (POD.tradingitem != null)
                            {
                                //TradingItem TI = new TradingItem();
                                //TI.purchaseorder = PO;
                                //TI.Name = POD.tradingitem.Name;
                                //TI.Description = POD.tradingitem.Description;
                                //TI.QTY = POD.QTY1;
                                //TI.UnitPrice = POD.SellingPrice1;
                                POD.tradingitem.purchaseorder = PO;
                                session.Save("TradingItem", POD.tradingitem);
                            }
                            else if (POD.fabricateditem != null)
                            {
                                //FabricatedItem FI = new FabricatedItem();
                                //FI.purchaseorder = PO;
                                //FI.Name = POD.fabricateditem.Name;
                                //FI.Description = POD.fabricateditem.Description;
                                //FI.QTY = POD.QTY1;
                                //FI.UnitPrice = POD.SellingPrice1;
                                POD.fabricateditem.purchaseorder = PO;
                                session.Save("FabricatedItem", POD.fabricateditem);
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

        public bool AllowCancel(PurchaseOrder PO)
        {
            using (ISession session = getSession())
            {
                IList<StockIn> lstSI =
                   session.CreateQuery("from StockIn as SI where SI.purchaseorder.ID=" + PO.ID).List<StockIn>();
                if (lstSI.Count == 0)
                    return true;
                else
                    return false;
            }
        }

        public IList<PurchaseOrder> GetAllRecordsByDateRange(DateTime from, DateTime to, bool bIncludeSupplierManila, bool bIncluceCanceled)
        {
            using (ISession session = getSession())
            {
                string SQL = string.Format("from PurchaseOrder po where po.TransactionDate between '{0}' and '{1}'", from.ToString(FMT_MYSQL_DATE_START), to.ToString(FMT_MYSQL_DATE_END));
                if (!bIncludeSupplierManila)
                    SQL += string.Format(" and po.Supplier.ContactType!={0}", (int)Contacts.eContactType.SuppliersManila);
                if (!bIncluceCanceled)
                    SQL += " and po.Canceled=0";
                return session.CreateQuery(SQL).List<PurchaseOrder>();
            }
        }
    }
}
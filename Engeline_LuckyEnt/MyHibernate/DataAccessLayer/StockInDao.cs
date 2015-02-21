using System;
using System.Collections.Generic;
using MyHibernate.BusinessObjects;
using MyHibernate.DataAccessLayer;
using NHibernate;
using NHibernate.Criterion;

namespace MyHibernate.DataAccessLayer
{
    public class StockInDao : GenericDao<StockIn>
    {
        public IList<StockIn> GetAllByPO_ID(Int32 PO_ID, bool IncludeCanceled)
        {
            using (ISession session = getSession())
            {
                if (IncludeCanceled)
                    return
                       session.CreateQuery(string.Format("from StockIn as SI where SI.purchaseorder.ID={0}", PO_ID)).List
                          <StockIn>();
                else
                    return
                       session.CreateQuery(
                          string.Format("from StockIn as SI where SI.purchaseorder.ID={0} and SI.Canceled=False", PO_ID)).
                          List<StockIn>();
            }
        }

        public IList<StockIn> GetAllBySOC_ID(Int32 SOC_ID)
        {
            using (ISession session = getSession())
            {
                return
                    session.CreateQuery(string.Format("from StockIn as SI where SI.statementofaccount.ID={0}", SOC_ID)).
                    List<StockIn>();
            }
        }

        public IList<StockIn> GetUnpaidStockIn()
        {
            using (ISession session = getSession())
            {
                string SQL = string.Format("from StockIn si where si.Canceled=0 and si.Paid=0");
                return session.CreateQuery(SQL).List<StockIn>();
            }
        }

        public IList<StockIn> GetUnpaidStockIn(DateTime from, DateTime to)
        {
            using (ISession session = getSession())
            {
                string dateFrom = from.ToString(FMT_MYSQL_DATE_START);
                string dateTo = to.ToString(FMT_MYSQL_DATE_END);
                string SQL =
                   string.Format(
                      "from StockIn si where si.Canceled=0 and si.Paid=0 and si.StockInDate between '{0}' and '{1}'",
                      dateFrom, dateTo);

                return session.CreateQuery(SQL).List<StockIn>();
            }
        }

        public IList<StockIn> GetUnpaidStockIn(DateTime from, DateTime to, Int32 supplierID)
        {
            using (ISession session = getSession())
            {
                string dateFrom = from.ToString(FMT_MYSQL_DATE_START);
                string dateTo = to.ToString(FMT_MYSQL_DATE_END);
                string SQL =
                   string.Format(
                      "from StockIn si where si.Canceled=0 and si.Paid=0 and si.purchaseorder.Supplier.ID={0} and si.StockInDate between '{1}' and '{2}'",
                      supplierID, dateFrom, dateTo);

                return session.CreateQuery(SQL).List<StockIn>();
            }
        }

        public IList<StockIn> SearchStockInByItem(string sSearch)
        {
            using (ISession session = getSession())
            {
                string SQL =
                   string.Format(
                      "select distinct si.* from stockin si inner join stockindetails sid on si.ID=sid.StockInID inner join items on items.ID=sid.ItemID where items.Name like '{0}'",
                      sSearch);
                return session.CreateSQLQuery(SQL).AddEntity(typeof(StockIn)).List<StockIn>();
            }
        }

        public IList<StockIn> SearchStockInByItem(string sSearch, Int32 SupplierID)
        {
            using (ISession session = getSession())
            {
                //string SQL = string.Format("select distinct si.* from stockin si inner join stockindetails sid on si.ID=sid.StockInID inner join items on items.ID=sid.ItemID where items.Name like '{0}' and si.purchaseorder.Supplier.ID={1}", sSearch,SupplierID);
                string SQL =
                   string.Format(
                      @"select distinct si.* from stockin si inner join stockindetails sid 
                                                on si.ID=sid.StockInID inner join items on items.ID=sid.ItemID 
                                                inner join purchaseorder po on po.ID=si.PO_ID inner join contacts c on c.ID=po.SupplierID
                                                where items.Name like '{0}' and c.ID={1}",
                      sSearch, SupplierID);
                return session.CreateSQLQuery(SQL).AddEntity(typeof(StockIn)).List<StockIn>();
            }
        }

        public IList<StockIn> SearchStockInBySupplier(string sSearch)
        {
            using (ISession session = getSession())
            {
                string SQL =
                   string.Format(
                      "select distinct si.* from stockin si where si.purchaseorder.Supplier.CompanyName like '{0}'", sSearch);
                return session.CreateSQLQuery(SQL).AddEntity(typeof(StockIn)).List<StockIn>();
            }
        }

        public void SaveDMitems(StockIn SI, Int32 stockinDetailsID, Int32 itemID, int qtyDM)
        {
            using (ISession session = getSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        //session.SaveOrUpdate("StockIn", SI);
                        //save details
                        foreach (StockInDetails SID in SI.details)
                        {
                            if (SID.ID == stockinDetailsID)
                            {
                                SID.stockin = SI;
                                session.SaveOrUpdate("StockInDetails", SID);

                                //update Item Inventory
                                ItemDao iDao = new ItemDao();
                                Items I = iDao.GetById(itemID);
                                if (I != null)
                                {
                                    I.QTYOnHand1 -= qtyDM;
                                    session.SaveOrUpdate("Items", I);
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

        public void Save(StockIn SI, bool Excess)
        {
            using (ISession session = getSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        session.SaveOrUpdate("StockIn", SI);

                        //save details
                        foreach (StockInDetails SID in SI.details)
                        {
                            SID.stockin = SI;
                            session.SaveOrUpdate("StockInDetails", SID);

                            //update Item Inventory
                            if (SID.item != null)
                            {
                                Items item = (Items)session.Get<Items>(SID.item.ID);
                                item.QTYOnHand1 += SID.QTY_OnHand1;
                                item.QTYOnHand2 += SID.QTY_OnHand2;
                                session.SaveOrUpdate("Items", item);
                            }
                        }

                        #region commented
                        //update PO
                        //if (SI.purchaseorder.ID != null)
                        //{
                        //    PurchaseOrder PO = (PurchaseOrder)session.Get<PurchaseOrder>(SI.purchaseorder.ID);
                        //    if (PO.Excess != Excess)
                        //    {
                        //        PO.Excess = Excess;
                        //    }
                        

                        //    //update PO status
                        //    string SQL = string.Format("from StockIn AS SI where SI.purchaseorder.ID={0} and SI.Canceled=False",
                        //                               SI.purchaseorder.ID);
                        //    IList<StockIn> lstSI = session.CreateQuery(SQL).List<StockIn>();
                        //    bool Complete = true;
                        //    int qty1 = 0;
                        //    foreach (PurchaseOrderDetails pod in SI.purchaseorder.details)
                        //    {
                        //        qty1 = pod.QTY1;
                        //        foreach (StockIn si in lstSI)
                        //        {
                        //            foreach (StockInDetails sid in si.details)
                        //            {
                        //                if (sid.ItemIndex == pod.ItemIndex)
                        //                {
                        //                    qty1 -= sid.QTY1;
                        //                }
                        //            }
                        //        }

                        //        if (qty1 > 0)
                        //        {
                        //            //po not complete yet, not all stocks have arrived
                        //            Complete = false;
                        //        }
                        //    }

                        //    if (Complete)
                        //        PO.Status = (int)PurchaseOrder.eStatus.OK;
                        //    else
                        //        PO.Status = (int)PurchaseOrder.eStatus.PENDING;

                        //    session.SaveOrUpdate("PurchaseOrder", PO);
                        //}
                        #endregion

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

        public void CancelStockIn(StockIn SI)
        {
            using (ISession session = getSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        SI.Canceled = true;
                        session.SaveOrUpdate("StockIn", SI);

                        foreach (StockInDetails SID in SI.details)
                        {
                            //update Item Inventory
                            if (SID.item != null)
                            {
                                Items item = (Items)session.Get<Items>(SID.item.ID);
                                item.QTYOnHand1 -= SID.QTY1;
                                item.QTYOnHand2 -= SID.QTY2;
                                session.SaveOrUpdate("Items", item);
                            }
                        }

                        //update PO status
                        PurchaseOrder PO = (PurchaseOrder)session.Get<PurchaseOrder>(SI.purchaseorder.ID);

                        string SQL =
                           string.Format(
                              "from StockIn AS SI where SI.purchaseorder.ID={0} and SI.ID!={1} and SI.Canceled=false", PO.ID,
                              SI.ID);
                        IList<StockIn> lstSI = session.CreateQuery(SQL).List<StockIn>();

                        bool Complete = true, bExcess = false;
                        int qty1 = 0;

                        foreach (PurchaseOrderDetails pod in PO.details)
                        {
                            qty1 = pod.QTY1;
                            foreach (StockIn si in lstSI)
                            {
                                foreach (StockInDetails sid in si.details)
                                {
                                    if (sid.ItemIndex == pod.ItemIndex)
                                    {
                                        qty1 -= sid.QTY1;
                                    }
                                }
                            }

                            if (qty1 > 0)
                            {
                                //PO not complete yet, not all stocks have arrived
                                Complete = false;
                            }

                            if (qty1 < 0)
                            {
                                bExcess = true;
                            }
                        }
                        PO.Excess = bExcess;
                        if (Complete)
                            PO.Status = (int)PurchaseOrder.eStatus.OK;
                        else
                            PO.Status = (int)PurchaseOrder.eStatus.PENDING;


                        session.SaveOrUpdate("PurchaseOrder", PO);
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

        public bool AllowCancel(StockIn SI)
        {
            using (ISession session = getSession())
            {
                return true;

                //check if StockIn not used in other transactions (Sales Invoice, Bad Order, etc...)
            }
        }

        public IList<StockIn> GetAllStockInID()
        {
            using (ISession session = getSession())
            {
                string SQL = string.Format("from StockIn");
                return session.CreateQuery(SQL).List<StockIn>();
            }
        }

        public StockIn ChangePaymentStatusPaid(Int32 soc_ID)
        {
            using (ISession session = getSession())
            {
                string SQL = "";

                SQL += string.Format("from StockIn si where si.statementofaccount.ID={0}", soc_ID);

                return session.CreateQuery(SQL).UniqueResult<StockIn>();
            }
        }

        public Int32 GetLastStockInforDamagesMissing()
        {
            using (ISession session = getSession())
            {
                string SQL = "";
                Int32 baseID_dm = 9000001, stockinID_dm=0,newID=0;

                SQL = string.Format("select MAX(si.ID) from StockIn si");
                
               stockinID_dm =session.CreateQuery(SQL).UniqueResult<Int32>();

                if (baseID_dm > stockinID_dm)
                    newID = baseID_dm;
                else
                    newID = stockinID_dm + 1;

                return newID;
            }
        }
    }
}
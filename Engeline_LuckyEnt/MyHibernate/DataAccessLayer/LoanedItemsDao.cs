using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyHibernate.BusinessObjects;
using NHibernate;

namespace MyHibernate.DataAccessLayer
{
    public class LoanedItemsDao : GenericDao<LoanedItems>
    {
        public override void Save(LoanedItems li)
        {
            using (ISession session = getSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        session.SaveOrUpdate("LoanedItems", li);

                        string SQL = "";

                        //save details
                        foreach (LoanedItemsDetails lid in li.details)
                        {
                            lid.loanedItems = li;
                            session.SaveOrUpdate("LoanedItemsDetails", lid);

                            foreach (LoanedItemsDetails_StockIn lid_si in lid.stockindetails)
                            {
                                lid_si.loanedItemsDetails = lid;

                                //update item onhand
                                StockInDetails sid = session.Get<StockInDetails>(lid_si.stockindetails.ID);

                                if (sid.item != null)
                                {
                                    Items item = session.Get<Items>(sid.item.ID);

                                    if (!item.IsWire)
                                    {
                                        //normal item
                                        sid.QTY_OnHand1 -= lid_si.QTY1;
                                        if (sid.QTY_OnHand1 < 0)
                                        {
                                            throw new Exception(string.Format("Not enough stocks for item '{0}' in StockIn '{1}'",
                                                                              sid.item.Name, sid.stockin.ID));
                                        }
                                        session.SaveOrUpdate("StockInDetails", sid);

                                        item.QTYOnHand1 -= lid_si.QTY1;
                                        session.SaveOrUpdate("Items", item);
                                    }
                                    else
                                    {
                                        //wire
                                        if (lid_si.QTY1 == 0)
                                        {
                                            //per meter
                                            if (lid_si.wirebreakdown.BreakDownID != 0 && lid_si.wirebreakdown.NewBreakdown)
                                            {
                                                WireBreakdown wb = new WireBreakdown();
                                                wb.BreakDownID = lid_si.wirebreakdown.BreakDownID;
                                                wb.NewBreakdown = lid_si.wirebreakdown.NewBreakdown;
                                                wb.QTY_OnHand = lid_si.wirebreakdown.QTY_OnHand;
                                                wb.QTY_Original = lid_si.wirebreakdown.QTY_Original;
                                                wb.SID = lid_si.wirebreakdown.SID;

                                                //check if the ID assigned is not taken by another
                                                //WireBreakdown wb_temp = session.Get<WireBreakdown>(siv_si.wirebreakdown.ID);
                                                SQL = string.Format("from WireBreakdown wb where wb.SID.ID={0} and wb.BreakDownID={1}", sid.ID, wb.BreakDownID);
                                                WireBreakdown wb_temp = session.CreateQuery(SQL).UniqueResult<WireBreakdown>();

                                                if (wb_temp != null)
                                                {
                                                    throw new Exception(
                                                       string.Format(
                                                          "Roll ID has already been used. Please remove and add this item again.\nItem: {0} x {1}mtrs\n",
                                                          lid.item.Name, lid.QTY2));
                                                }

                                                wb.QTY_OnHand -= lid_si.QTY2;

                                                //minus 1 to number of rolls
                                                item.QTYOnHand1 -= 1;
                                                sid.QTY_OnHand1 -= 1;
                                                if (wb.NewBreakdown)
                                                    session.Save("WireBreakdown", wb);
                                                else
                                                    session.SaveOrUpdate("WireBreakdown", wb);

                                                lid_si.wirebreakdown = wb;
                                            }
                                            else
                                            {
                                                //BreakDownID == 0 because this from a previous cut wire, update parent wb
                                                WireBreakdown wb2 = session.CreateQuery(string.Format("from WireBreakdown wb where wb.BreakDownID={0} and wb.SID.ID={1}", lid_si.wirebreakdown.BreakDownID_Source, sid.ID)).UniqueResult<WireBreakdown>();
                                                wb2.QTY_OnHand -= lid_si.QTY2;

                                                if (wb2.QTY_OnHand < 0)
                                                {
                                                    throw new Exception(string.Format("Not enough stocks for item:\n{0} [{1}mtrs]", sid.item.Name, lid_si.QTY2));
                                                }
                                                session.SaveOrUpdate("WireBreakdown", wb2);
                                                lid_si.wirebreakdown = null;
                                            }

                                            item.QTYOnHand2 -= lid_si.QTY2;
                                            session.SaveOrUpdate("Items", item);

                                            sid.QTY_OnHand2 -= lid_si.QTY2;
                                            if (sid.QTY_OnHand1 < 0 || sid.QTY_OnHand2 < 0)
                                            {
                                                throw new Exception(
                                                   string.Format("Not enough stocks for item '{0}' in StockIn '{1}'", sid.item.Name,
                                                                 sid.stockin.ID));
                                            }
                                            session.SaveOrUpdate("StockInDetails", sid);

                                        }
                                        else
                                        {
                                            //per roll
                                            sid.QTY_OnHand1 -= lid_si.QTY1;
                                            sid.QTY_OnHand2 -= (lid_si.QTY1 * lid_si.QTY2);
                                            if (sid.QTY_OnHand1 < 0 || sid.QTY_OnHand2 < 0)
                                            {
                                                throw new Exception(
                                                   string.Format("Not enough stocks for item '{0}' in StockIn '{1}'", sid.item.Name,
                                                                 sid.stockin.ID));
                                            }
                                            session.SaveOrUpdate("StockInDetails", sid);

                                            item.QTYOnHand1 -= lid_si.QTY1;
                                            item.QTYOnHand2 -= (lid_si.QTY1 * lid_si.QTY2);
                                            session.SaveOrUpdate("Items", item);
                                        }
                                    }
                                }
                                else
                                {
                                    //other item (Fab,Trade), update only StockInDetails
                                    sid.QTY_OnHand1 -= lid_si.QTY1;
                                    if (sid.QTY_OnHand1 < 0)
                                    {
                                        if (sid.fabricateditem != null)
                                        {
                                            throw new Exception(string.Format("Not enough stocks for item '{0}' in StockIn '{1}'",
                                                                              sid.fabricateditem.Name, sid.stockin.ID));
                                        }
                                        else if (sid.tradingitem != null)
                                        {
                                            throw new Exception(string.Format("Not enough stocks for item '{0}' in StockIn '{1}'",
                                                                              sid.tradingitem.Name, sid.stockin.ID));
                                        }
                                    }

                                    session.SaveOrUpdate("StockInDetails", sid);
                                }
                                session.Save("LoanedItemsDetails_StockIn", lid_si);
                            }
                        }
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        if (!transaction.WasRolledBack)
                            transaction.Rollback();
                        SetErrorMessage(ex);
                        throw;
                    }
                }
            }
        }

        public override void Delete(LoanedItems invoice)
        {
            if (invoice.Canceled)
                return; //already deleted/canceled, just return

            using (ISession session = getSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        invoice.Canceled = true;
                        session.SaveOrUpdate("LoanedItems", invoice);

                        //get invoice details
                        invoice.details =
                           session.CreateQuery(string.Format("from LoanedItemsDetails lid where lid.loanedItems.ID={0}",
                                                             invoice.ID)).List<LoanedItemsDetails>();

                        //update inventory
                        foreach (LoanedItemsDetails d in invoice.details)
                        {
                            foreach (LoanedItemsDetails_StockIn lid_si in d.stockindetails)
                            {
                                //update item onhand
                                StockInDetails sid = session.Get<StockInDetails>(lid_si.stockindetails.ID);

                                if (sid.item != null)
                                {
                                    Items item = session.Get<Items>(sid.item.ID);

                                    if (!item.IsWire)
                                    {
                                        //normal item
                                        sid.QTY_OnHand1 += lid_si.QTY1;
                                        session.SaveOrUpdate("StockInDetails", sid);

                                        //update item
                                        item.QTYOnHand1 += lid_si.QTY1;
                                        session.SaveOrUpdate("Items", item);
                                    }
                                    else
                                    {
                                        //wire item
                                        if (lid_si.QTY1 == 0)
                                        {
                                            //per meter sales, return as wire breakdown
                                            WireBreakdown wb = new WireBreakdown();
                                            wb.SID = sid;
                                            wb.QTY_Original = sid.QTY2; //original meters/roll
                                            wb.QTY_OnHand = lid_si.QTY2; //meters sold

                                            //get BreakDownID
                                            StockInDetailsDao sidDao = new StockInDetailsDao();
                                            wb.BreakDownID = sidDao.GetNextWireBreakdownID(sid.ID, session);

                                            session.SaveOrUpdate("WireBreakdown", wb);

                                            //update sid
                                            sid.QTY_OnHand2 += lid_si.QTY2;
                                            session.SaveOrUpdate("StockInDetails", sid);

                                            //update item
                                            item.QTYOnHand2 += lid_si.QTY2;
                                            session.SaveOrUpdate("Items", item);
                                        }
                                        else
                                        {
                                            //per roll sales, return whole roll
                                            sid.QTY_OnHand1 += lid_si.QTY1;
                                            sid.QTY_OnHand2 += (lid_si.QTY1 * lid_si.QTY2);
                                            session.SaveOrUpdate("StockInDetails", sid);

                                            //update item
                                            item.QTYOnHand1 += lid_si.QTY1;
                                            item.QTYOnHand2 += lid_si.QTY1 * lid_si.QTY2;
                                            session.SaveOrUpdate("Items", item);
                                        }
                                    }
                                }
                                else
                                {
                                    //for Fab/Trade items
                                    sid.QTY_OnHand1 += lid_si.QTY1;
                                    session.SaveOrUpdate("StockInDetails", sid);
                                }
                            }
                        }

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        SetErrorMessage(ex);
                        invoice.Canceled = false;
                        throw;
                    }
                }
            }
        }

        public int InvoiceItemsCancel(Int32 LoanedItemID, SalesInvoice si, ISession session)
        {
            try
            {
                LoanedItems li = session.Get<LoanedItems>(LoanedItemID);
                li.details = session.CreateQuery("from LoanedItemsDetails lid where lid.loanedItems.ID=" + LoanedItemID).List<LoanedItemsDetails>();
                foreach (LoanedItemsDetails lid in li.details)
                {
                    //get matching salesinvoicedetails
                    int qtytoreturn = 0;
                    foreach (SalesInvoiceDetails sivd in si.details)
                    {
                        if (sivd.LoanedItemDetailsID == lid.ID)
                        {
                            if (sivd.item != null && sivd.item.IsWire && sivd.QTY1 == 0)
                            {
                                //wire na putol, only 1 stockin details
                                LoanedItemsDetails_StockIn lid_si = lid.stockindetails[0];
                                lid_si.QTY_Invoiced -= sivd.QTY2;
                                session.SaveOrUpdate("LoanedItemsDetails_StockIn", lid_si);

                                lid.QTY_Invoiced -= sivd.QTY2;
                                qtytoreturn = 0;
                            }
                            else
                            {
                                qtytoreturn = sivd.QTY1;
                                lid.QTY_Invoiced -= qtytoreturn;

                                //rollback qty details
                                foreach (LoanedItemsDetails_StockIn lid_si in lid.stockindetails)
                                {
                                    int qtymissing = lid_si.QTY_Invoiced;
                                    if (qtymissing >= qtytoreturn)
                                    {
                                        lid_si.QTY_Invoiced -= qtytoreturn;
                                        session.SaveOrUpdate("LoanedItemsDetails_StockIn", lid_si);

                                        //lid.QTY_Invoiced -= qtytoreturn;
                                        qtytoreturn = 0;
                                    }
                                    else
                                    {
                                        lid_si.QTY_Invoiced -= qtymissing;
                                        session.SaveOrUpdate("LoanedItemsDetails_StockIn", lid_si);

                                        //lid.QTY_Invoiced -= qtymissing;
                                        qtytoreturn -= qtymissing;
                                    }
                                    if (qtytoreturn == 0)
                                        break;
                                }
                            }
                            lid.Selected = true;
                            break;
                        }
                    }
                    if (lid.Selected)
                        session.SaveOrUpdate("LoanedItemsDetails", lid);
                }

                UpdateStatus(li);
                session.SaveOrUpdate("LoanedItems", li);
                return 0;
            }
            catch (Exception ex)
            {
                SetErrorMessage(ex);
                return -1; throw;
            }
        }

        public int InvoiceItems(LoanedItems li, ISession session)
        {
            try
            {
                foreach (LoanedItemsDetails lid in li.details)
                {
                    if (lid.QTY_ToReturn == 0)
                        continue;

                    //auto select lid_si to return
                    int qtytoreturn = lid.QTY_ToReturn;
                    foreach (LoanedItemsDetails_StockIn lid_si in lid.stockindetails)
                    {
                        int unreturned = 0;

                        if (lid.item != null)
                        {
                            Items item = session.Get<Items>(lid.item.ID);
                            if (item.IsWire)
                            {
                                if (lid.QTY1 == 0)
                                {
                                    //wire na putol
                                    unreturned = lid_si.QTY2 - lid_si.QTY_Invoiced - lid_si.QTY_Returned;
                                    if (unreturned > 0 && unreturned == qtytoreturn)
                                    {
                                        lid_si.QTY_Invoiced += unreturned;
                                        session.SaveOrUpdate("LoanedItemsDetails_StockIn", lid_si);
                                        qtytoreturn = 0;
                                    }
                                }
                                else
                                {
                                    //per roll
                                    unreturned = lid_si.QTY1 - lid_si.QTY_Invoiced - lid_si.QTY_Returned;
                                    if (unreturned > 0)
                                    {
                                        if (unreturned >= qtytoreturn)
                                        {
                                            lid_si.QTY_Invoiced += qtytoreturn;
                                            session.SaveOrUpdate("LoanedItemsDetails_StockIn", lid_si);
                                            qtytoreturn = 0;
                                        }
                                        else
                                        {
                                            lid_si.QTY_Invoiced += unreturned;
                                            session.SaveOrUpdate("LoanedItemsDetails_StockIn", lid_si);
                                            qtytoreturn -= unreturned;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                //normal item
                                unreturned = lid_si.QTY1 - lid_si.QTY_Invoiced - lid_si.QTY_Returned;
                                if (unreturned > 0)
                                {
                                    if (unreturned >= qtytoreturn)
                                    {
                                        lid_si.QTY_Invoiced += qtytoreturn;
                                        session.SaveOrUpdate("LoanedItemsDetails_StockIn", lid_si);
                                        qtytoreturn = 0;
                                    }
                                    else
                                    {
                                        lid_si.QTY_Invoiced += unreturned;
                                        session.SaveOrUpdate("LoanedItemsDetails_StockIn", lid_si);
                                        qtytoreturn -= unreturned;
                                    }
                                }
                            }
                        }
                        else
                        {
                            //other items
                            unreturned = lid_si.QTY1 - lid_si.QTY_Invoiced - lid_si.QTY_Returned;
                            if (unreturned >= qtytoreturn)
                            {
                                lid_si.QTY_Invoiced += qtytoreturn;
                                session.SaveOrUpdate("LoanedItemsDetails_StockIn", lid_si);
                                qtytoreturn = 0;
                            }
                            else
                            {
                                lid_si.QTY_Invoiced += unreturned;
                                session.SaveOrUpdate("LoanedItemsDetails_StockIn", lid_si);
                                qtytoreturn -= unreturned;
                            }
                        }
                        if (qtytoreturn == 0)
                            break;
                    }

                    if (qtytoreturn == 0)
                    {
                        lid.QTY_Invoiced += lid.QTY_ToReturn;
                        session.SaveOrUpdate("LoanedItemsDetails", lid);
                    }
                    else
                    {
                        //something's wrong, not all qty is returned
                        throw new Exception("Operation failed", new Exception("Not all qty returned."));
                    }
                }

                UpdateStatus(li);
                session.SaveOrUpdate("LoanedItems", li);

                return 0;
            }
            catch (Exception ex)
            {
                SetErrorMessage(ex);
                return -1;
            }
        }

        public int ReturnItems(LoanedItems loaneditem)
        {
            using (ISession session = getSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        foreach (LoanedItemsDetails lid in loaneditem.details)
                        {
                            if (lid.QTY_ToReturn == 0)
                                continue;

                            //auto select lid_si to return
                            int qtytoreturn = lid.QTY_ToReturn;
                            foreach (LoanedItemsDetails_StockIn lid_si in lid.stockindetails)
                            {
                                int unreturned = 0;

                                StockInDetails sid = session.Get<StockInDetails>(lid_si.stockindetails.ID);
                                if (lid.item != null)
                                {
                                    Items item = session.Get<Items>(lid.item.ID);
                                    if (item.IsWire)
                                    {
                                        if (lid.QTY1 == 0)
                                        {
                                            //wire na putol
                                            unreturned = lid_si.QTY2 - lid_si.QTY_Invoiced - lid_si.QTY_Returned;
                                            if (unreturned > 0 && unreturned == qtytoreturn)
                                            {
                                                lid_si.QTY_Returned += unreturned;
                                                session.SaveOrUpdate("LoanedItemsDetails_StockIn", lid_si);

                                                //create new wirebreakdown
                                                StockInDetailsDao dao = new StockInDetailsDao();
                                                WireBreakdown wb = new WireBreakdown();
                                                wb.BreakDownID = dao.GetNextWireBreakdownID(lid_si.stockindetails.ID);
                                                wb.NewBreakdown = lid_si.wirebreakdown.NewBreakdown;
                                                wb.QTY_OnHand = lid_si.wirebreakdown.QTY_Original;
                                                wb.QTY_Original = lid_si.wirebreakdown.QTY_Original;
                                                wb.SID = lid_si.wirebreakdown.SID;
                                                session.Save("WireBreakdown", wb);

                                                //update inventory
                                                sid.QTY_OnHand2 += unreturned;
                                                session.SaveOrUpdate("StockInDetails", sid);

                                                item.QTYOnHand2 += unreturned;
                                                session.SaveOrUpdate("Items", item);

                                                qtytoreturn = 0;
                                            }
                                        }
                                        else
                                        {
                                            //per roll
                                            unreturned = lid_si.QTY1 - lid_si.QTY_Invoiced - lid_si.QTY_Returned;
                                            if (unreturned > 0)
                                            {
                                                if (unreturned >= qtytoreturn)
                                                {
                                                    lid_si.QTY_Returned += qtytoreturn;
                                                    session.SaveOrUpdate("LoanedItemsDetails_StockIn", lid_si);

                                                    //update stockin
                                                    sid.QTY_OnHand1 += qtytoreturn;
                                                    sid.QTY_OnHand2 += (qtytoreturn * lid_si.QTY2);
                                                    session.SaveOrUpdate("StockInDetails", sid);

                                                    //update item
                                                    item.QTYOnHand1 += qtytoreturn;
                                                    item.QTYOnHand2 += qtytoreturn * lid_si.QTY2;
                                                    session.SaveOrUpdate("Items", item);
                                                    qtytoreturn = 0;
                                                }
                                                else
                                                {
                                                    lid_si.QTY_Returned += unreturned;
                                                    session.SaveOrUpdate("LoanedItemsDetails_StockIn", lid_si);

                                                    //update stockin
                                                    sid.QTY_OnHand1 += unreturned;
                                                    sid.QTY_OnHand2 += (unreturned * lid_si.QTY2);
                                                    session.SaveOrUpdate("StockInDetails", sid);

                                                    //update item
                                                    item.QTYOnHand1 += unreturned;
                                                    item.QTYOnHand2 += unreturned * lid_si.QTY2;
                                                    session.SaveOrUpdate("Items", item);
                                                    qtytoreturn -= unreturned;
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        //normal item
                                        unreturned = lid_si.QTY1 - lid_si.QTY_Invoiced - lid_si.QTY_Returned;
                                        if (unreturned > 0)
                                        {
                                            if (unreturned >= qtytoreturn)
                                            {
                                                lid_si.QTY_Returned += qtytoreturn;
                                                session.SaveOrUpdate("LoanedItemsDetails_StockIn", lid_si);

                                                //update stockin
                                                sid.QTY_OnHand1 += qtytoreturn;
                                                session.SaveOrUpdate("StockInDetails", sid);

                                                //update item
                                                item.QTYOnHand1 += qtytoreturn;
                                                session.SaveOrUpdate("Items", item);
                                                qtytoreturn = 0;
                                            }
                                            else
                                            {
                                                lid_si.QTY_Returned += unreturned;
                                                session.SaveOrUpdate("LoanedItemsDetails_StockIn", lid_si);

                                                //update stockin
                                                sid.QTY_OnHand1 += unreturned;
                                                session.SaveOrUpdate("StockInDetails", sid);

                                                //update item
                                                item.QTYOnHand1 += unreturned;
                                                session.SaveOrUpdate("Items", item);
                                                qtytoreturn -= unreturned;
                                            }
                                        }
                                        else
                                        {

                                        }
                                    }
                                }
                                else
                                {
                                    //other items
                                    unreturned = lid_si.QTY1 - lid_si.QTY_Invoiced - lid_si.QTY_Returned;
                                    if (unreturned >= qtytoreturn)
                                    {
                                        lid_si.QTY_Returned += qtytoreturn;
                                        session.SaveOrUpdate("LoanedItemsDetails_StockIn", lid_si);

                                        //update stockin
                                        sid.QTY_OnHand1 += qtytoreturn;
                                        session.SaveOrUpdate("StockInDetails", sid);

                                        qtytoreturn = 0;
                                    }
                                    else
                                    {
                                        lid_si.QTY_Returned += unreturned;
                                        session.SaveOrUpdate("LoanedItemsDetails_StockIn", lid_si);

                                        //update stockin
                                        sid.QTY_OnHand1 += unreturned;
                                        session.SaveOrUpdate("StockInDetails", sid);

                                        qtytoreturn -= unreturned;
                                    }
                                }
                                if (qtytoreturn == 0)
                                    break;
                            }

                            if (qtytoreturn == 0)
                            {
                                lid.QTY_Returned += lid.QTY_ToReturn;
                                session.SaveOrUpdate("LoanedItemsDetails", lid);
                            }
                            else
                            {
                                //something's wrong, not all qty is returned
                                throw new Exception("Operation failed", new Exception("Not all qty returned."));
                            }
                        }

                        UpdateStatus(loaneditem);
                        session.SaveOrUpdate("LoanedItems", loaneditem);

                        transaction.Commit();
                        return 0;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        SetErrorMessage(ex);
                        return -1;
                    }
                }
            }
        }

        private void UpdateStatus(LoanedItems li)
        {
            LoanedItems.eStatus status = LoanedItems.eStatus.ForCollection;
            int qty = 0, qty_returned = 0;
            foreach (LoanedItemsDetails lid in li.details)
            {
                if (lid.item != null && lid.item.IsWire)
                {
                    if (lid.QTY1 == 0)
                    {
                        qty += lid.QTY2;
                    }
                    else
                    {
                        qty += lid.QTY1;
                    }
                }
                else
                {
                    qty += lid.QTY1;
                }
                qty_returned += (lid.QTY_Invoiced + lid.QTY_Returned);
            }

            if (qty_returned == 0)
            {
                li.Status = LoanedItems.eStatus.ForCollection;
            }
            else if (qty_returned >= qty)
            {
                li.Status = LoanedItems.eStatus.Returned;
            }
            else
            {
                li.Status = LoanedItems.eStatus.Partial;
            }
        }

        public IList<LoanedItemsDetails> GetDetails(Int32 ID)
        {
            using (ISession session = getSession())
            {
                string SQL = string.Format("from LoanedItemsDetails lid where lid.loanedItems.ID={0}", ID);
                return session.CreateQuery(SQL).List<LoanedItemsDetails>();
            }
        }

        public IList<LoanedItems> GetAllRecordsByDateRange(DateTime from, DateTime to, int customerID, bool bIncludeCanceled, int status)
        {
            using (ISession session = getSession())
            {
                LoanedItems li;

                string SQL = string.Format("from LoanedItems li where li.TransactionDate between '{0}' and '{1}'", from.ToString(FMT_MYSQL_DATE_START), to.ToString(FMT_MYSQL_DATE_END));
                if (customerID != 0)
                    SQL += string.Format(" and li.Customer.ID={0}", customerID);
                if (!bIncludeCanceled)
                    SQL += " and li.Canceled=0";
                if (status >= 0)
                    SQL += string.Format(" and li.Status={0}", status);
                return session.CreateQuery(SQL).List<LoanedItems>();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using MyHibernate.BusinessObjects;
using MyHibernate.DataAccessLayer;
using NHibernate;

namespace MyHibernate.DataAccessLayer
{
    public class ReturnedItemsDao : GenericDao<ReturnedItems>
    {
        public override void Save(ReturnedItems RI)
        {
            using (ISession session = getSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        //save main object
                        session.Save("ReturnedItems", RI);

                        //save details
                        foreach (ReturnedItemsDetails rid in RI.details)
                        {
                            rid.returneditems = RI;
                            session.Save("ReturnedItemsDetails", rid);
                            //save stockin details
                            foreach (ReturnedItemsDetails_StockIn rid2 in rid.stockindetails)
                            {
                                if (rid2.wirebreakdown != null)
                                {
                                    //get new ID for wirebreakdown
                                    StockInDetailsDao dao = new StockInDetailsDao();
                                    rid2.wirebreakdown.BreakDownID = dao.GetNextWireBreakdownID(rid2.stockindetails.ID);
                                    //save new wirebreakdown
                                    session.Save("WireBreakdown", rid2.wirebreakdown);
                                }

                                //save stockin details
                                rid2.returneditemsdetail = rid;
                                session.Save("ReturnedItemsDetails_StockIn", rid2);

                                //update inventory
                                StockInDetails sid = session.Get<StockInDetails>(rid2.stockindetails.ID);
                                if (sid.item != null)
                                {
                                    //update Item inventory
                                    Items item = session.Get<Items>(sid.item.ID);

                                    if (!item.IsWire)
                                    {
                                        item.QTYOnHand1 += rid2.QTY1;
                                        sid.QTY_OnHand1 += rid2.QTY1;
                                    }
                                    else
                                    {
                                        //wire
                                        if (rid2.QTY1 == 0)
                                        {
                                            //per meter
                                            item.QTYOnHand2 += rid2.QTY2;
                                            sid.QTY_OnHand2 += rid2.QTY2;
                                        }
                                        else
                                        {
                                            //per roll
                                            item.QTYOnHand1 += rid2.QTY1;
                                            item.QTYOnHand2 += (rid2.QTY1 * rid2.QTY2);
                                            sid.QTY_OnHand1 += rid2.QTY1;
                                            sid.QTY_OnHand2 += (rid2.QTY1 * rid2.QTY2);
                                        }
                                    }

                                    session.SaveOrUpdate("Items", item);
                                    session.SaveOrUpdate("StockInDetails", sid);
                                }
                                else
                                {
                                    //fab/trade... update stockin details
                                    sid.QTY_OnHand1 += rid2.QTY1;
                                    session.SaveOrUpdate("StockInDetails", sid);
                                }
                            }

                            //update SalesInvoiceDetails
                            SalesInvoiceDetails invoice_detail = session.Get<SalesInvoiceDetails>(rid.SID.ID);
                            if (rid.QTY1 > 0)
                            {
                                //normal item / per roll
                                invoice_detail.QTY_Returned += rid.QTY1;
                            }
                            else
                            {
                                //per meter sales
                                invoice_detail.QTY_Returned += rid.QTY2;
                            }
                            session.Update("SalesInvoiceDetails", invoice_detail);
                        }

                        //update invoice
                        SalesInvoice invoice = session.Get<SalesInvoice>(RI.Invoice.ID);
                        invoice.AmountReturned += RI.Amount;
                        SalesInvoiceDao invoiceDao = new SalesInvoiceDao();
                        invoiceDao.UpdateInvoicePaymentStatus(invoice, session, false);

                        //update counter
                        if (RI.Invoice.CounterID != 0)
                        {
                            Counter counter = session.Get<Counter>(RI.Invoice.CounterID);
                            counter.Amount -= RI.Amount;
                            CounterDao counterDao = new CounterDao();
                            counterDao.UpdateCounterStatus(counter, session, false);
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

        public virtual void Cancel(Int32 ID)
        {
            using (ISession session = getSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        ReturnedItems RI = session.Get<ReturnedItems>(ID);
                        RI.Canceled = true;
                        session.SaveOrUpdate("ReturnedItems", RI);

                        //get details
                        RI.details =
                           session.CreateQuery(string.Format(
                              "from ReturnedItemsDetails as rid where rid.returneditems.ID={0}", RI.ID)).List
                              <ReturnedItemsDetails>();

                        //update inventory
                        foreach (ReturnedItemsDetails rid in RI.details)
                        {
                            foreach (ReturnedItemsDetails_StockIn rid2 in rid.stockindetails)
                            {
                                if (rid2.wirebreakdown != null)
                                {
                                    //delete wirebreakdown
                                    session.Delete("WireBreakdown", rid2.wirebreakdown);
                                }

                                StockInDetails sid = session.Get<StockInDetails>(rid2.stockindetails.ID);
                                if (rid2.stockindetails.item != null)
                                {
                                    //update Items and StockInDetails
                                    Items item = session.Get<Items>(rid2.stockindetails.item.ID);
                                    if (!item.IsWire)
                                    {
                                        item.QTYOnHand1 -= rid2.QTY1;
                                        sid.QTY_OnHand1 -= rid2.QTY1;
                                    }
                                    else
                                    {
                                        //wire
                                        if (rid2.QTY1 == 0)
                                        {
                                            //per meter
                                            item.QTYOnHand2 += rid2.QTY2;
                                            sid.QTY_OnHand2 += rid2.QTY2;
                                        }
                                        else
                                        {
                                            //per roll
                                            item.QTYOnHand1 += rid2.QTY1;
                                            item.QTYOnHand2 += (rid2.QTY1 * rid2.QTY2);
                                            sid.QTY_OnHand1 += rid2.QTY1;
                                            sid.QTY_OnHand2 += (rid2.QTY1 * rid2.QTY2);
                                        }
                                    }
                                    session.SaveOrUpdate("Items", item);
                                    session.SaveOrUpdate("StockInDetails", sid);
                                }
                                else
                                {
                                    //fab or trade item
                                    sid.QTY_OnHand1 -= rid2.QTY1;
                                    session.SaveOrUpdate("StockInDetails", sid);
                                }
                            }

                            //update SalesInvoiceDetails
                            SalesInvoiceDetails invoice_detail = session.Get<SalesInvoiceDetails>(rid.SID.ID);
                            if (rid.QTY1 > 0)
                            {
                                //normal item / per roll
                                invoice_detail.QTY_Returned -= rid.QTY1;
                            }
                            else
                            {
                                //per meter sales
                                invoice_detail.QTY_Returned -= rid.QTY2;
                            }
                            session.Update("SalesInvoiceDetails", invoice_detail);
                        }

                        //update sales invoice
                        RI.Invoice.AmountReturned -= RI.Amount;
                        SalesInvoiceDao invoiceDao = new SalesInvoiceDao();
                        invoiceDao.UpdateInvoicePaymentStatus(RI.Invoice, session, false);

                        //update counter
                        if (RI.Invoice.CounterID != 0)
                        {
                            Counter counter = session.Get<Counter>(RI.Invoice.CounterID);
                            counter.Amount += RI.Amount;
                            CounterDao counterDao = new CounterDao();
                            counterDao.UpdateCounterStatus(counter, session, false);
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

        public virtual IList<ReturnedItemsDetails> GetDetails(Int32 ID)
        {
            using (ISession session = getSession())
            {
                string SQL = string.Format("from ReturnedItemsDetails as rid where rid.returneditems.ID={0}", ID);
                return session.CreateQuery(SQL).List<ReturnedItemsDetails>();
            }
        }

        public virtual IList<ReturnedItems> GetAllRecordsByDateRange(DateTime start, DateTime end, bool bIncludeCanceled)
        {
            string datestart = start.ToString("yyyy-MM-dd 00:00:00");
            string dateend = end.ToString("yyyy-MM-dd 23:59:59");

            using (ISession session = getSession())
            {
                string SQL = string.Format("from ReturnedItems as tbl where tbl.TransactionDate BETWEEN '{0}' AND '{1}'",
                                           datestart, dateend);
                if (!bIncludeCanceled)
                    SQL += " and tbl.Canceled=false";
                return session.CreateQuery(SQL).List<ReturnedItems>();
            }
        }

        public virtual IList<ReturnedItems> getAllByInvoiceID(Int32 InvoiceID)
        {
            using (ISession session = getSession())
            {
                string SQL = string.Format("from ReturnedItems ri where ri.Canceled=false and ri.Invoice.ID={0}", InvoiceID);
                return session.CreateQuery(SQL).List<ReturnedItems>();
            }
        }
    }
}
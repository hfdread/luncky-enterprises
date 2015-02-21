using System;
using System.Collections.Generic;
using MyHibernate.BusinessObjects;
using MyHibernate.DataAccessLayer;
using NHibernate;
using NHibernate.Criterion;

namespace MyHibernate.DataAccessLayer
{
    public class SalesInvoiceDao : GenericDao<SalesInvoice>
    {
        public void Save(SalesInvoice si, AgentCommission commission, double customerCommission, LoanedItems li)
        {
            using (ISession session = getSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        session.Save("SalesInvoice", si);

                        //update & check inventory
                        string sql = "";
                        foreach (SalesInvoiceDetails sivd in si.details)
                        {
                            sivd.salesinvoice = si;
                            session.Save("SalesInvoiceDetails", sivd);

                            //update inventory of loaneditem is null
                            foreach (SalesInvoiceDetails_StockIn siv_si in sivd.stockindetails)
                            {
                                siv_si.salesinvoicedetails = sivd;
                                //session.Save("SalesInvoiceDetails_StockIn", siv_si);

                                //update item onhand
                                StockInDetails sid = session.Get<StockInDetails>(siv_si.stockindetails.ID);

                                if (sid.item != null)
                                {
                                    Items item = session.Get<Items>(sid.item.ID);
                                    //item = session.Get<Items>(sid.item.ID);

                                    if (li == null)
                                    {
                                        //normal item
                                        sid.QTY_OnHand1 -= siv_si.QTY1;
                                        if (sid.QTY_OnHand1 < 0)
                                        {
                                            throw new Exception(string.Format("Not enough stocks for item '{0}' in StockIn '{1}'",
                                                                                sid.item.Name, sid.stockin.ID));
                                        }
                                        session.SaveOrUpdate("StockInDetails", sid);

                                        item.QTYOnHand1 -= siv_si.QTY1;
                                        session.SaveOrUpdate("Items", item);
                                    }
                                    #region wire code
                                    //else
                                    //{
                                    //    //wire
                                    //    if (siv_si.QTY1 == 0)
                                    //    {
                                    //        //per meter
                                    //        if (siv_si.wirebreakdown.BreakDownID != 0 && siv_si.wirebreakdown.NewBreakdown)
                                    //        {
                                    //            if (li == null)
                                    //            {
                                    //                WireBreakdown wb = new WireBreakdown();
                                    //                wb.BreakDownID = siv_si.wirebreakdown.BreakDownID;
                                    //                wb.BreakDownID_Source = siv_si.wirebreakdown.BreakDownID_Source;
                                    //                wb.NewBreakdown = siv_si.wirebreakdown.NewBreakdown;
                                    //                wb.QTY_OnHand = siv_si.wirebreakdown.QTY_OnHand;
                                    //                wb.QTY_Original = siv_si.wirebreakdown.QTY_Original;
                                    //                wb.SID = siv_si.wirebreakdown.SID;

                                    //                //check if the ID assigned is not taken by another
                                    //                //WireBreakdown wb_temp = session.Get<WireBreakdown>(siv_si.wirebreakdown.ID);
                                    //                sql = string.Format("from WireBreakdown wb where wb.SID.ID={0} and wb.BreakDownID={1}", sid.ID, wb.BreakDownID);
                                    //                WireBreakdown wb_temp = session.CreateQuery(sql).UniqueResult<WireBreakdown>();

                                    //                if (wb_temp != null)
                                    //                {
                                    //                    throw new Exception(string.Format("Roll ID has already been used. Please remove and add this item again.\nItem: {0} x {1}mtrs\n",
                                    //                                         sivd.item.Name, sivd.QTY2));
                                    //                }
                                    //                wb.QTY_OnHand -= siv_si.QTY2;

                                    //                //minus 1 to number of rolls
                                    //                item.QTYOnHand1 -= 1;
                                    //                sid.QTY_OnHand1 -= 1;

                                    //                if (wb.NewBreakdown)
                                    //                    session.Save("WireBreakdown", wb);
                                    //                else
                                    //                    session.SaveOrUpdate("WireBreakdown", wb);

                                    //                siv_si.wirebreakdown = wb;
                                    //            }
                                    //            else
                                    //            {
                                    //                siv_si.wirebreakdown = null;
                                    //            }

                                    //        }
                                    //        else
                                    //        {
                                    //            //BreakDownID == 0 because this from a previous cut wire, update parent wb
                                    //            if (li == null)
                                    //            {
                                    //                WireBreakdown wb2 = session.CreateQuery(string.Format("from WireBreakdown wb where wb.BreakDownID={0} and wb.SID.ID={1}", siv_si.wirebreakdown.BreakDownID_Source, sid.ID)).UniqueResult<WireBreakdown>();
                                    //                wb2.QTY_OnHand -= siv_si.QTY2;

                                    //                if (wb2.QTY_OnHand < 0)
                                    //                {
                                    //                    throw new Exception(string.Format("Not enough stocks for item:\n{0} [{1}mtrs]", sid.item.Name, siv_si.QTY2));
                                    //                }
                                    //                session.SaveOrUpdate("WireBreakdown", wb2);
                                    //            }
                                    //            siv_si.wirebreakdown = null;
                                    //        }

                                    //        if (li == null)
                                    //        {
                                    //            item.QTYOnHand2 -= siv_si.QTY2;
                                    //            session.SaveOrUpdate("Items", item);

                                    //            sid.QTY_OnHand2 -= siv_si.QTY2;
                                    //            if (sid.QTY_OnHand1 < 0 || sid.QTY_OnHand2 < 0)
                                    //            {
                                    //                throw new Exception(
                                    //                   string.Format("Not enough stocks for item '{0}' in StockIn '{1}'", sid.item.Name,
                                    //                                 sid.stockin.ID));
                                    //            }
                                    //            session.SaveOrUpdate("StockInDetails", sid);
                                    //        }
                                    //    }
                                    //    else
                                    //    {
                                    //        //per roll
                                    //        if (li == null)
                                    //        {
                                    //            sid.QTY_OnHand1 -= siv_si.QTY1;
                                    //            sid.QTY_OnHand2 -= (siv_si.QTY1 * siv_si.QTY2);
                                    //            if (sid.QTY_OnHand1 < 0 || sid.QTY_OnHand2 < 0)
                                    //            {
                                    //                throw new Exception(
                                    //                   string.Format("Not enough stocks for item '{0}' in StockIn '{1}'", sid.item.Name,
                                    //                                 sid.stockin.ID));
                                    //            }
                                    //            session.SaveOrUpdate("StockInDetails", sid);

                                    //            item.QTYOnHand1 -= siv_si.QTY1;
                                    //            item.QTYOnHand2 -= (siv_si.QTY1 * siv_si.QTY2);
                                    //            session.SaveOrUpdate("Items", item);
                                    //        }
                                    //    }
                                    //}
                                    #endregion
                                }
                                else
                                {
                                    //other item (Fab,Trade), update only StockInDetails
                                    if (li == null)
                                    {
                                        sid.QTY_OnHand1 -= siv_si.QTY1;
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
                                }
                                session.Save("SalesInvoiceDetails_StockIn", siv_si);
                            }
                        }

                        //save payments
                        foreach (Payments payment in si.paymentdetails)
                        {
                            payment.invoice = si;
                            session.Save("Payments", payment);

                            if (payment.PDCdetail != null)
                            {
                                payment.PDCdetail.payment = payment;
                                payment.PDCdetail.ClearingDate = PaymentsPDC.GetClearingDate(payment.PDCdetail.CheckDate);
                                session.Save("PaymentsPDC", payment.PDCdetail);
                            }

                            foreach (PaymentsDetail pd in payment.details)
                            {
                                pd.payment = payment;
                                pd.invoice = si;
                                session.Save("PaymentsDetail", pd);
                            }
                        }

                        //apply agent commission
                        if (si.Customer.Agent != null)
                        {
                            if (commission.ItemDetails.Count != 0)
                            {
                                //compute agent commission
                                commission.Invoice = si;
                                session.Save("AgentCommission", commission);

                                foreach (AgentCommissionItemDetails comDetails in commission.ItemDetails)
                                {
                                    comDetails.commission = commission;
                                    session.Save("AgentCommissionItemDetails", comDetails);
                                }
                            }
                        }

                        //apply customer commission
                        if (customerCommission > 0)
                        {
                            CustomerCommission custCom = new CustomerCommission();
                            custCom.Customer = si.Customer;
                            custCom.Amount = customerCommission;
                            custCom.Invoice = si;
                            custCom.Status = (Int32)CustomerCommission.eStatus.Pending;
                            session.Save("CustomerCommission", custCom);
                        }

                        //update customer balance
                        if (si.InvoiceType == (Int32)SalesInvoice.eInvoiceType.Accounts ||
                            si.InvoiceType == (Int32)SalesInvoice.eInvoiceType.DeliveryReceipt)
                        {
                            if ((si.AmountDue - si.PaymentCash) > 0)
                            {
                                Contacts customer = session.Get<Contacts>(si.Customer.ID);
                                customer.CreditUsed += (si.AmountDue - si.PaymentCash);
                                session.SaveOrUpdate("Contacts", customer);
                            }
                        }

                        //if (li != null)
                        //{
                        //    //update LoanedItem
                        //    LoanedItemsDao dao = new LoanedItemsDao();
                        //    if (dao.InvoiceItems(li, session) == 0)
                        //    {
                        //        //si.LoanedItemID = li.ID;
                        //    }
                        //    else
                        //    {
                        //        throw new Exception(dao.ErrorMessage);
                        //    }
                        //}

                        ////save PO
                        //if (lstPO != null && lstPO.Count > 0)
                        //{
                        //    foreach (PurchaseOrder po in lstPO)
                        //    {
                        //        session.Save(po);
                        //        foreach (PurchaseOrderDetails po_details in po.details)
                        //        {
                        //            po_details.purchaseorder = po;
                        //            session.Save(po_details);
                        //        }

                        //        si.PO_Number += string.Format("{0},", po.ID);
                        //        session.SaveOrUpdate(si);
                        //    }
                        //}

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        SetErrorMessage(ex);
                        if (!transaction.WasRolledBack)
                            transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public void UpdateInvoicePaymentStatus(SalesInvoice invoice, ISession session, bool bStartNewTransaction)
        {
            ITransaction transaction = null;
            if (bStartNewTransaction)
                transaction = session.BeginTransaction();

            try
            {
                invoice.PaymentStatus = (int)SalesInvoice.ePaymentStatus.Unpaid;

                bool bForDeposit = false;
                double paymentsCash, paymentsForDeposit, paymentsPDC, paymentsWithHolding;
                string SQL = string.Format(
                   "from PaymentsDetail as pd where pd.invoice.ID={0} and pd.payment.Canceled=false", invoice.ID);
                IList<PaymentsDetail> lstInvoicePayments = session.CreateQuery(SQL).List<PaymentsDetail>();

                paymentsCash = paymentsForDeposit = paymentsPDC = paymentsWithHolding = 0;
                foreach (PaymentsDetail pd in lstInvoicePayments)
                {
                    if (pd.payment.PDCdetail != null)
                    {
                        //PDC payment
                        switch (pd.payment.PDCdetail.Status)
                        {
                            case PaymentsPDC.eStatus.Bounced:
                            case PaymentsPDC.eStatus.Returned: break;
                            case PaymentsPDC.eStatus.Good:
                                paymentsPDC += pd.Amount;
                                break;
                            case PaymentsPDC.eStatus.ForDeposit:
                                //we have a PDC payment which is for deposit
                                bForDeposit = true;
                                paymentsForDeposit += pd.Amount;
                                break;
                            default:
                                break;
                        }
                    }
                    else
                    {
                        //cash payment or Withholding
                        if (pd.payment.PaymentType == (Int32)Payments.ePaymentType.Cash)
                            paymentsCash += pd.Amount;
                        else if (pd.payment.PaymentType == (Int32)Payments.ePaymentType.WithHolding)
                            paymentsWithHolding += pd.Amount;
                    }
                }
                invoice.PaymentCash = paymentsCash;
                invoice.PaymentWithholding = paymentsWithHolding;
                invoice.PaymentPDC = paymentsPDC;
                invoice.PaymentForDeposit = paymentsForDeposit;

                if (bForDeposit)
                {
                    //has pending PDC payment for deposit
                    if (invoice.getTotalPayments() >= (invoice.AmountDue - invoice.AmountReturned))
                        invoice.PaymentStatus = (Int32)SalesInvoice.ePaymentStatus.ForDeposit;
                    else if (invoice.getTotalPayments() > 0)
                        invoice.PaymentStatus = (Int32)SalesInvoice.ePaymentStatus.Partial;
                }
                else
                {
                    if (invoice.getTotalPayments() >= (invoice.AmountDue - invoice.AmountReturned))
                        invoice.PaymentStatus = (Int32)SalesInvoice.ePaymentStatus.Paid;
                    else if (invoice.getTotalPayments() > 0)
                        invoice.PaymentStatus = (Int32)SalesInvoice.ePaymentStatus.Partial;
                }

                //save changes to invoice
                session.SaveOrUpdate("SalesInvoice", invoice);

                if (transaction != null)
                    transaction.Commit();
            }
            catch (Exception)
            {
                if (transaction != null)
                    transaction.Rollback();
                throw;
            }
        }

        public void UpdateDeliveredStatus(SalesInvoice invoice, bool deliverStatus)
        {
            using (ISession session = getSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        invoice.is_delivered = deliverStatus;

                        session.SaveOrUpdate(invoice);
                        transaction.Commit();
                    }
                    catch(Exception ex)
                    {
                        SetErrorMessage(ex);
                        if (!transaction.WasRolledBack)
                            transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public override void Delete(SalesInvoice invoice)
        {
            using (ISession session = getSession())
            {
                //get updated version of this invoice
                invoice = session.Get<SalesInvoice>(invoice.ID);
                if (invoice.Deleted)
                    return; //already deleted/canceled, just return

                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        invoice.Deleted = true;
                        session.SaveOrUpdate("SalesInvoice", invoice);

                        //get invoice details
                        invoice.details =
                           session.CreateQuery(string.Format("from SalesInvoiceDetails sid where sid.salesinvoice.ID={0}",
                                                             invoice.ID)).List<SalesInvoiceDetails>();

                        //update inventory (skip if from LoanedItem)
                        if (invoice.LoanedItemID == 0)
                        {
                            foreach (SalesInvoiceDetails d in invoice.details)
                            {
                                foreach (SalesInvoiceDetails_StockIn siv_si in d.stockindetails)
                                {
                                    //update item onhand
                                    StockInDetails sid = session.Get<StockInDetails>(siv_si.stockindetails.ID);

                                    if (sid.item != null)
                                    {
                                        Items item = session.Get<Items>(sid.item.ID);
                                        //normal item
                                        sid.QTY_OnHand1 += siv_si.QTY1;
                                        session.SaveOrUpdate("StockInDetails", sid);

                                        //update item
                                        item.QTYOnHand1 += siv_si.QTY1;
                                        session.SaveOrUpdate("Items", item);                                        
                                    }
                                    else
                                    {
                                        //for Fab/Trade items
                                        sid.QTY_OnHand1 += siv_si.QTY1;
                                        session.SaveOrUpdate("StockInDetails", sid);
                                    }
                                }
                            }
                        }

                        //roll back payments
                        IList<PaymentsDetail> payments =
                           session.CreateQuery(string.Format("from PaymentsDetail pd where pd.invoice.ID={0}", invoice.ID)).
                              List<PaymentsDetail>();
                        foreach (PaymentsDetail pd in payments)
                        {
                            pd.payment.AmountUsed -= pd.Amount;
                            if (pd.payment.AmountUsed == 0)
                            {
                                //should cancel this payment as it is not used
                                pd.payment.Canceled = true;
                            }
                            session.SaveOrUpdate("Payments", pd.payment);
                            session.Delete(pd);
                        }

                        //update counter status
                        if (invoice.CounterID != 0)
                        {
                            CounterDao counterDao = new CounterDao();
                            Counter counter = session.Get<Counter>(invoice.CounterID);
                            counter.Amount -= invoice.AmountDue;
                            counterDao.UpdateCounterStatus(counter, session, false);
                        }

                        //remove agent commision
                        AgentCommission ac = session.CreateQuery(string.Format("from AgentCommission ac where ac.Invoice.ID={0}", invoice.ID)).
                              UniqueResult<AgentCommission>();
                        if (ac != null)
                        {
                            session.Delete(string.Format("from AgentCommissionItemDetails acd where acd.commission.ID={0}",
                                                         ac.ID));
                            session.Delete(ac);
                        }

                        //delete customer commision
                        session.Delete(string.Format("from CustomerCommission cc where cc.Invoice.ID={0}", invoice.ID));

                        //update customer balance
                        if (invoice.InvoiceType == (Int32)SalesInvoice.eInvoiceType.Accounts ||
                            invoice.InvoiceType == (Int32)SalesInvoice.eInvoiceType.DeliveryReceipt)
                        {
                            if ((invoice.AmountDue - invoice.PaymentCash) > 0)
                            {
                                Contacts customer = session.Get<Contacts>(invoice.Customer.ID);
                                customer.CreditUsed -= (invoice.AmountDue - invoice.PaymentCash);
                                session.SaveOrUpdate("Contacts", customer);
                            }
                        }

                        //update LoanedItem
                        if (invoice.LoanedItemID != 0)
                        {
                            LoanedItemsDao dao = new LoanedItemsDao();
                            if (dao.InvoiceItemsCancel(invoice.LoanedItemID, invoice, session) != 0)
                            {
                                throw new Exception(ErrorMessage);
                            }
                        }

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        SetErrorMessage(ex);
                        invoice.Deleted = false;
                        throw;
                    }
                }
            }
        }

        public IList<SalesInvoice> getAllRecordsByCriteria(Int32 CustomerID, DateTime dateFrom, DateTime dateTo,
                                                           Int32 PaymentStatus, Int32 DeliverStatus)
        {
            using (ISession session = getSession())
            {
                string SQL = string.Format("from SalesInvoice si where si.InvoiceDate between '{0}' and '{1}'", dateFrom.ToString(FMT_MYSQL_DATE_START), dateTo.ToString(FMT_MYSQL_DATE_END));

                if (CustomerID > 0)
                {
                    SQL += string.Format(" and si.Customer.ID={0}", CustomerID);
                }

                if (PaymentStatus != -1)
                {
                    SQL += string.Format(" and si.PaymentStatus={0}", PaymentStatus);
                }

                if (DeliverStatus != -1)
                {
                    SQL += string.Format(" and si.is_delivered={0}", DeliverStatus);
                }

                return session.CreateQuery(SQL).List<SalesInvoice>();
            }
            /*
            using (ISession session = getSession())
            {
            
               ICriteria result = session.CreateCriteria<SalesInvoice>();

               if (CustomerID > 0)
                  result.Add(Expression.Eq("Customer.ID", CustomerID));

               result.Add(Expression.Between("InvoiceDate", dateFrom, dateTo));

               if (PaymentStatus != -1)
                  result.Add(Expression.Eq("PaymentStatus", PaymentStatus));

               return result.List<SalesInvoice>();
            }
             * */
        }



        public IList<SalesInvoice> getAllRecordsForCounter(Int32 CustomerID, DateTime DueDate)
        {
            using (ISession session = getSession())
            {
                string SQL =
                   string.Format(
                      "from SalesInvoice as s where s.InvoiceType={0} and s.PaymentType={1} and s.CounterID=0 and s.BadDebt=false and s.Deleted=false ",
                      (Int32)SalesInvoice.eInvoiceType.Accounts, (Int32)SalesInvoice.ePaymentType.Terms);
                if (CustomerID > 0)
                    SQL += string.Format(" and s.Customer.ID={0}", CustomerID);
                SQL += string.Format(" and adddate(s.InvoiceDate,s.Terms)<='{0}'", DueDate.ToString("yyyy-MM-dd 23:59:59"));
                return session.CreateQuery(SQL).List<SalesInvoice>();
            }
        }

        public IList<SalesInvoice> getAllRecordsForCounter(Int32 CustomerID, Int32 CounterID, bool bUnPaidOnly)
        {
            using (ISession session = getSession())
            {
                string SQL = string.Format("from SalesInvoice as s where s.Customer.ID={0} and s.CounterID={1}", CustomerID,
                                           CounterID);
                if (bUnPaidOnly)
                    SQL += string.Format(" and s.PaymentStatus!={0}", (Int32)SalesInvoice.ePaymentStatus.Paid);
                return session.CreateQuery(SQL).List<SalesInvoice>();
            }
        }

        public IList<SalesInvoiceDetails> GetDetails(Int32 ID)
        {
            using (ISession session = getSession())
            {
                string SQL = string.Format("from SalesInvoiceDetails as sd where sd.salesinvoice.ID={0}", ID);
                return session.CreateQuery(SQL).List<SalesInvoiceDetails>();
            }
        }

        public int SetBadDebt(SalesInvoice invoice)
        {
            if (invoice.BadDebt)
                return 0;

            using (ISession session = getSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        invoice.BadDebt = true;
                        session.SaveOrUpdate("SalesInvoice", invoice);
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

        //public double getCashPayments(Int32 InvoiceID)
        //{
        //   using (ISession session = getCurrentSession())
        //   {
        //      SalesInvoice s;

        //      string SQL = string.Format("from SalesInvoice as s where s.Customer.ID={0} and s.CounterID={1}", CustomerID, CounterID);
        //      if (bUnPaidOnly)
        //         SQL += string.Format(" and s.PaymentStatus!={0}", (Int32)SalesInvoice.ePaymentStatus.Paid);
        //      return session.CreateQuery(SQL).List<SalesInvoice>();
        //   }         
        //}
    }
}
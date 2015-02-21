using System;
using System.Collections.Generic;
using MyHibernate.BusinessObjects;
using MyHibernate.DataAccessLayer;
using NHibernate;

namespace MyHibernate.DataAccessLayer
{
    public class CounterDao : GenericDao<Counter>
    {
        public override void Save(Counter item)
        {
            using (ISession session = getSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        session.Save("Counter", item);

                        //save details
                        foreach (CounterDetails cd in item.details)
                        {
                            //save detail
                            cd.counter = item;
                            session.Save("CounterDetails", cd);

                            //update invoice
                            SalesInvoice si = session.Get<SalesInvoice>(cd.invoice.ID);
                            si.CounterID = item.ID;
                            session.SaveOrUpdate("SalesInvoice", si);

                            //update payments made for this Invoice, add to counter 
                            IList<Payments> lstPayments =
                               session.CreateQuery(string.Format("from Payments p where p.invoice.ID={0}", cd.invoice.ID)).List
                                  <Payments>();
                            foreach (Payments P in lstPayments)
                            {
                                P.counter = item;
                                session.SaveOrUpdate("Payments", P);
                            }
                        }

                        //update payment status
                        UpdateCounterStatus(item, session, false);

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

        public void UpdateCounterStatus(Counter item, ISession session, bool bStartNewTransaction)
        {
            ITransaction transaction = null;
            if (bStartNewTransaction)
                transaction = session.BeginTransaction();

            try
            {
                //update counter payments
                string SQL = string.Format("from Payments as p where p.counter.ID={0} and p.Canceled=false", item.ID);

                //get all payments made for this counter
                IList<Payments> lstCounterPayments = session.CreateQuery(SQL).List<Payments>();

                //reset variables
                bool bForDeposit = false;
                double PaymentCash, PaymentWithholding, PaymentPDC, PaymentForDeposit;
                PaymentCash = PaymentWithholding = PaymentPDC = PaymentForDeposit = 0;
                foreach (Payments p in lstCounterPayments)
                {
                    switch (p.PaymentType)
                    {
                        case (Int32)Payments.ePaymentType.Cash:
                            PaymentCash += p.Amount;
                            break;
                        case (Int32)Payments.ePaymentType.WithHolding:
                            PaymentWithholding += p.Amount;
                            break;
                        case (Int32)Payments.ePaymentType.PDC:
                            switch (p.PDCdetail.Status)
                            {
                                case PaymentsPDC.eStatus.Returned:
                                case PaymentsPDC.eStatus.Bounced:
                                    break;
                                case PaymentsPDC.eStatus.ForDeposit:
                                    bForDeposit = true;
                                    PaymentForDeposit += p.Amount;
                                    break;
                                case PaymentsPDC.eStatus.Good:
                                    PaymentPDC += p.Amount;
                                    break;
                                default:
                                    break;
                            }
                            break;
                        default:
                            break;
                    }
                }
                item.PaymentCash = PaymentCash;
                item.PaymentPDC = PaymentPDC;
                item.PaymentWithHolding = PaymentWithholding;
                item.PaymentForDeposit = PaymentForDeposit;
                item.Balance = item.Amount - PaymentCash - PaymentPDC - PaymentWithholding - PaymentForDeposit;

                if (bForDeposit)
                {
                    if (item.GetTotalPayments() == 0)
                        item.Status = (Int32)Counter.eStatus.Partial;
                    else if (item.GetTotalPayments() >= item.Amount)
                        item.Status = (Int32)Counter.eStatus.ForClearing;
                    else
                        item.Status = (Int32)Counter.eStatus.Partial;
                }
                else
                {
                    if (item.GetTotalPayments() == 0)
                        item.Status = (Int32)Counter.eStatus.Unpaid;
                    else if (item.GetTotalPayments() >= item.Amount)
                        item.Status = (Int32)Counter.eStatus.Paid;
                    else
                        item.Status = (Int32)Counter.eStatus.Partial;
                }
                session.SaveOrUpdate("Counter", item);

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

        public override void Delete(Counter item)
        {
            using (ISession session = getSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        //delete payments
                        string lstP_IDs = "";
                        string SQL = string.Format("from Payments p where p.counter.ID={0}", item.ID);
                        IList<Payments> lstP = session.CreateQuery(SQL).List<Payments>();
                        foreach (Payments P in lstP)
                        {
                            if (lstP_IDs != "")
                                lstP_IDs += ",";
                            lstP_IDs += P.ID.ToString();
                        }
                        if (lstP.Count > 0)
                        {
                            session.Delete(string.Format("from PaymentsPDC as pdc where pdc.payment.ID in ({0})", lstP_IDs));
                            session.Delete(string.Format("from PaymentsDetail pd where pd.payment.ID in ({0})", lstP_IDs));
                            session.Delete(string.Format("from Payments as p where p.ID in ({0})", lstP_IDs));
                        }

                        bool bForDeposit = false;
                        double paymentsCash, paymentsPDC, paymentsForDeposit, paymentsWithHolding;

                        Counter counter = session.Get<Counter>(item.ID);
                        counter.details = (List<CounterDetails>)session.CreateQuery("from CounterDetails as cd where cd.counter.ID=" + counter.ID.ToString()).List
                              <CounterDetails>();
                        //update invoices
                        foreach (CounterDetails cd in counter.details)
                        {
                            SalesInvoice invoice = session.Get<SalesInvoice>(cd.invoice.ID);
                            invoice.CounterID = 0;

                            //update payment status
                            SQL =
                               string.Format(
                                  "from PaymentsDetail as pd where pd.invoice.ID={0} and pd.payment.Canceled=false", invoice.ID);
                            IList<PaymentsDetail> lstInvoicePaymens = session.CreateQuery(SQL).List<PaymentsDetail>();

                            bForDeposit = false;
                            paymentsCash = paymentsForDeposit = paymentsPDC = paymentsWithHolding = 0;
                            foreach (PaymentsDetail pd2 in lstInvoicePaymens)
                            {
                                if (pd2.payment.PDCdetail != null)
                                {
                                    //PDC payment
                                    switch (pd2.payment.PDCdetail.Status)
                                    {
                                        case PaymentsPDC.eStatus.Bounced:
                                        case PaymentsPDC.eStatus.Returned:
                                            break;
                                        case PaymentsPDC.eStatus.Good:
                                            paymentsPDC += pd2.Amount;
                                            break;
                                        case PaymentsPDC.eStatus.ForDeposit:
                                            //we have a PDC payment which is for deposit
                                            bForDeposit = true;
                                            paymentsForDeposit += pd2.Amount;
                                            break;
                                        default:
                                            break;
                                    }
                                }
                                else
                                {
                                    //cash payment or Withholding
                                    if (pd2.payment.PaymentType == (Int32)Payments.ePaymentType.Cash)
                                        paymentsCash += pd2.Amount;
                                    else if (pd2.payment.PaymentType == (Int32)Payments.ePaymentType.WithHolding)
                                        paymentsWithHolding += pd2.Amount;
                                }
                            }
                            invoice.PaymentCash = paymentsCash;
                            invoice.PaymentWithholding = paymentsWithHolding;
                            invoice.PaymentPDC = paymentsPDC;
                            invoice.PaymentForDeposit = paymentsForDeposit;

                            if (bForDeposit)
                            {
                                //has pending PDC payment for deposit
                                if ((invoice.getTotalPayments() + invoice.PaymentForDeposit) >= invoice.AmountDue)
                                    invoice.PaymentStatus = (Int32)SalesInvoice.ePaymentStatus.ForDeposit;
                                else if (invoice.getTotalPayments() > 0)
                                    invoice.PaymentStatus = (Int32)SalesInvoice.ePaymentStatus.Partial;
                            }
                            else
                            {
                                if (invoice.getTotalPayments() >= invoice.AmountDue)
                                    invoice.PaymentStatus = (Int32)SalesInvoice.ePaymentStatus.Paid;
                                else if (invoice.getTotalPayments() > 0)
                                    invoice.PaymentStatus = (Int32)SalesInvoice.ePaymentStatus.Partial;
                                else
                                    invoice.PaymentStatus = (Int32)SalesInvoice.ePaymentStatus.Unpaid;
                            }

                            //save changes to invoice
                            session.SaveOrUpdate("SalesInvoice", invoice);
                        }

                        //delete details
                        session.Delete("from CounterDetails as cd where cd.counter.ID=" + counter.ID.ToString());

                        //delete main table
                        session.Delete(counter);
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        if (!transaction.WasRolledBack)
                            transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }

        public IList<Counter> getAllRecordsByCriteria(Int32 CustomerID, Int32 Status, DateTime from, DateTime to,
                                                      bool bFilterDate)
        {
            using (ISession session = getSession())
            {
                string SQL = string.Format("from Counter as c where 1=1");
                if (CustomerID > 0)
                    SQL += string.Format(" and c.Customer.ID={0}", CustomerID);
                if (Status >= 0)
                    SQL += string.Format(" and c.Status={0}", Status);
                if (bFilterDate)
                    SQL += string.Format(" and c.CounterDueDate between '{0}' and '{1}'", from.ToString(FMT_MYSQL_DATE_START),
                                         to.ToString(FMT_MYSQL_DATE_END));

                return session.CreateQuery(SQL).List<Counter>();
            }
        }

        public IList<Counter> getAllRecordsByCriteria(Int32 CustomerID, bool bUnpaidOnly, DateTime from, DateTime to,
                                                      bool bFilterDate)
        {
            using (ISession session = getSession())
            {
                string SQL = string.Format("from Counter as c where 1=1");
                if (CustomerID > 0)
                    SQL += string.Format(" and c.Customer.ID={0}", CustomerID);
                if (bUnpaidOnly)
                    SQL += string.Format(" and c.Status!={0}", (Int32)Counter.eStatus.Paid);
                if (bFilterDate)
                    SQL += string.Format(" and c.CounterDueDate between '{0}' and '{1}'", from.ToString(FMT_MYSQL_DATE_START),
                                         to.ToString(FMT_MYSQL_DATE_END));

                return session.CreateQuery(SQL).List<Counter>();
            }
        }

        public IList<SalesInvoice> GetInvoiceDetails(Int32 CounterID)
        {
            using (ISession session = getSession())
            {
                string SQL = string.Format("from SalesInvoice si where si.CounterID={0} and si.Deleted=0", CounterID);
                return session.CreateQuery(SQL).List<SalesInvoice>();
            }
        }

        public IList<CounterDetails> GetDetails(Int32 CounterID)
        {
            using (ISession session = getSession())
            {
                CounterDetails cd;

                string SQL = string.Format("from CounterDetails cd where cd.counter.ID={0}", CounterID);
                return session.CreateQuery(SQL).List<CounterDetails>();
            }
        }

        public IList<Payments> GetPaymentDetails(Int32 CounterID)
        {
            using (ISession session = getSession())
            {
                string SQL = string.Format("from Payments p where p.counter.ID={0} and p.Canceled=false", CounterID);
                return session.CreateQuery(SQL).List<Payments>();
            }
        }

        public void SetStatusPaid(Counter counter)
        {
            using (ISession session = getSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        //get invoice details
                        string SQL = string.Format("from SalesInvoice si where si.CounterID={0}", counter.ID);
                        IList<SalesInvoice> lstSI = session.CreateQuery(SQL).List<SalesInvoice>();

                        //update all invoices and set to PAID
                        foreach (SalesInvoice si in lstSI)
                        {
                            si.PaymentStatus = (Int32)SalesInvoice.ePaymentStatus.Paid;
                            session.SaveOrUpdate("SalesInvoice", si);
                        }

                        counter.Status = (Int32)Counter.eStatus.Paid;
                        session.SaveOrUpdate("Counter", counter);
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        if (!transaction.WasRolledBack)
                            transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }
    }
}
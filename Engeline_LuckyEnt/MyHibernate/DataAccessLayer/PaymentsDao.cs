using System;
using System.Collections.Generic;
using MyHibernate.BusinessObjects;
using MyHibernate.DataAccessLayer;
using NHibernate;

namespace MyHibernate.DataAccessLayer
{
    public class PaymentsDao : GenericDao<Payments>
    {
        //This is for Payments made for a Counter. Payments made during Sales Invoice is handled in 
        //SalesInvoiceDao.
        public override void Save(Payments payment)
        {
            using (ISession session = getSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        session.Save("Payments", payment);

                        //save check details
                        if (payment.PDCdetail != null)
                        {
                            payment.PDCdetail.payment = payment;
                            payment.PDCdetail.ClearingDate = PaymentsPDC.GetClearingDate(payment.PDCdetail.CheckDate);
                            session.Save("PaymentsPDC", payment.PDCdetail);
                        }

                        //save details
                        SalesInvoiceDao invoiceDao = new SalesInvoiceDao();
                        foreach (PaymentsDetail pd in payment.details)
                        {
                            pd.payment = payment;
                            session.Save("PaymentsDetail", pd);

                            //update invoice payment status
                            SalesInvoice invoice = session.Get<SalesInvoice>(pd.invoice.ID);
                            invoiceDao.UpdateInvoicePaymentStatus(invoice, session, false);
                        }

                        //update counter payment status
                        if (payment.counter != null)
                        {
                            Counter counter = session.Get<Counter>(payment.counter.ID);
                            CounterDao counterDao = new CounterDao();
                            counterDao.UpdateCounterStatus(counter, session, false);
                        }

                        //update customer balance
                        if (payment.PaymentType == (Int32)Payments.ePaymentType.PDC)
                        {
                        }
                        else
                        {
                            //cash or withholding payment
                            Contacts customer = null;

                            if (payment.Customer != null)
                            {
                                customer = session.Get<Contacts>(payment.Customer.ID);
                                customer.CreditUsed -= payment.Amount;
                            }
                            else
                            {
                                foreach (PaymentsDetail details in payment.details)
                                {
                                    SalesInvoice si = session.Get<SalesInvoice>(details.invoice.ID);
                                    customer = session.Get<Contacts>(si.Customer.ID);

                                    customer.CreditUsed -= details.Amount;
                                }
                            }

                            
                            session.SaveOrUpdate("Contacts", customer);
                        }

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

        //update Payment, payment amount cannot be changed though
        public int UpdatePDC(Payments payment, Int32 oldStatus, Int32 newStatus)
        {
            using (ISession session = getSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        string SQL = "";

                        //save PDC detail
                        payment.PDCdetail.Status = (PaymentsPDC.eStatus)newStatus;
                        session.Update("PaymentsPDC", payment.PDCdetail);

                        //update counter/invoices affected
                        SQL = string.Format("from PaymentsDetail pd where pd.payment.ID={0}", payment.ID);
                        payment.details = session.CreateQuery(SQL).List<PaymentsDetail>();

                        //update invoices
                        SalesInvoiceDao invoiceDao = new SalesInvoiceDao();
                        foreach (PaymentsDetail pd in payment.details)
                        {
                            //update invoice
                            SalesInvoice invoice = session.Get<SalesInvoice>(pd.invoice.ID);
                            invoiceDao.UpdateInvoicePaymentStatus(invoice, session, false);
                        }

                        if (payment.counter != null)
                        {
                            //update counter
                            Counter counter = session.Get<Counter>(payment.counter.ID);
                            CounterDao counterDao = new CounterDao();
                            counterDao.UpdateCounterStatus(counter, session, false);
                        }

                        //update customer balance
                        if (payment.PaymentType == (Int32)Payments.ePaymentType.PDC)
                        {
                            Contacts customer = null;
                            if (oldStatus != (Int32)PaymentsPDC.eStatus.Good && newStatus == (Int32)PaymentsPDC.eStatus.Good)
                            {
                                customer = session.Get<Contacts>(payment.Customer.ID);
                                customer.CreditUsed -= payment.Amount;
                                session.SaveOrUpdate("Contacts", customer);
                            }
                            else if (oldStatus == (Int32)PaymentsPDC.eStatus.Good &&
                                     newStatus != (Int32)PaymentsPDC.eStatus.Good)
                            {
                                customer = session.Get<Contacts>(payment.Customer.ID);
                                customer.CreditUsed += payment.Amount;
                                session.SaveOrUpdate("Contacts", customer);
                            }
                        }
                        transaction.Commit();
                        return 0;
                    }
                    catch (Exception ex)
                    {
                        if (!transaction.WasRolledBack)
                            transaction.Rollback();
                        SetErrorMessage(ex);
                        return -1;
                    }
                }
            }
        }

        public void CancelPayment(Int32 PaymentID)
        {
            using (ISession session = getSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    string SQL = "";

                    try
                    {
                        Payments payment = session.Get<Payments>(PaymentID);
                        payment.Canceled = true;
                        session.SaveOrUpdate("Payments", payment);

                        SQL = string.Format("from PaymentsDetail as pd where pd.payment.ID={0}", payment.ID);
                        payment.details = session.CreateQuery(SQL).List<PaymentsDetail>();

                        //update all affected invoices
                        SalesInvoiceDao invoiceDao = new SalesInvoiceDao();
                        foreach (PaymentsDetail pd in payment.details)
                        {
                            SalesInvoice invoice = session.Get<SalesInvoice>(pd.invoice.ID);
                            invoiceDao.UpdateInvoicePaymentStatus(invoice, session, false);
                        }

                        //update counter
                        if (payment.counter != null)
                        {
                            Counter counter = session.Get<Counter>(payment.counter.ID);
                            CounterDao counterDao = new CounterDao();
                            counterDao.UpdateCounterStatus(counter, session, false);
                        }

                        //update customer balance
                        if (payment.PDCdetail != null && payment.PDCdetail.Status != PaymentsPDC.eStatus.Good)
                        {
                        }
                        else
                        {
                            Contacts customer = session.Get<Contacts>(payment.Customer.ID);
                            customer.CreditUsed += payment.Amount;
                            session.SaveOrUpdate("Contacts", customer);
                        }

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

        public virtual int UpdateReviewStatus(IList<Payments> lstP)
        {
            using (ISession session = getSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    int ctr = 0;
                    try
                    {
                        foreach (Payments p in lstP)
                        {
                            if (p.Selected)
                            {
                                session.SaveOrUpdate("Payments", p);
                                ctr++;
                            }
                        }
                        transaction.Commit();
                        return ctr;
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

        public IList<Payments> getAllPaymentsPDC(Int32 CustomerID, Int32 Status, DateTime from, DateTime to)
        {
            using (ISession session = getSession())
            {
                string SQL = string.Format("from Payments as p where p.PaymentType={0}", (Int32)Payments.ePaymentType.PDC);
                if (CustomerID > 0)
                {
                    SQL += string.Format(" and p.Customer.ID={0}", CustomerID);
                }
                if (Status >= 0)
                {
                    SQL += string.Format(" and p.PDCdetail.Status={0}", Status);
                }
                if (from != null && to != null)
                    SQL += string.Format(" and p.PaymentDate between '{0}' and '{1}'", from.ToString("yyyy-MM-dd 00:00:00"),
                                         to.ToString("yyyy-MM-dd 23:59:59"));

                return session.CreateQuery(SQL).List<Payments>();
            }
        }

        public IList<Payments> getAllPaymentsForClearing(DateTime date)
        {
            using (ISession session = getSession())
            {
                string SQL = string.Format("from Payments as p where p.PDCdetail is not null and p.PDCdetail.");
                return session.CreateQuery(SQL).List<Payments>();
            }
        }

        public IList<Payments> getAllPaymentsForReview()
        {
            using (ISession session = getSession())
            {
                string SQL = string.Format("from Payments as p where p.Reviewed=false and p.Canceled=false");
                return session.CreateQuery(SQL).List<Payments>();
            }
        }

        public IList<Payments> GetPaymentsByCounterID(Int32 CounterID)
        {
            using (ISession session = getSession())
            {
                string SQL = string.Format("from Payments p where p.counter.ID={0}", CounterID);
                return session.CreateQuery(SQL).List<Payments>();
            }
        }

        public IList<PaymentsDetail> GetPaymentDetails(Int32 PaymentID)
        {
            using (ISession session = getSession())
            {
                string SQL = string.Format("from PaymentsDetail pd where pd.payment.ID={0}", PaymentID);
                return session.CreateQuery(SQL).List<PaymentsDetail>();
            }
        }

        public virtual IList<Payments> GetChecksForClearing(DateTime date)
        {
            using (ISession session = getSession())
            {
                string SQL =
                   string.Format(
                      "from Payments p where p.Canceled=false and p.PDCdetail.Status={0} and p.PDCdetail.ClearingDate<='{1} 23:59:59' and p.PaymentType={2}",
                      (Int32)PaymentsPDC.eStatus.ForDeposit, date.ToString("yyyy-MM-dd"), (Int32)Payments.ePaymentType.PDC);
                return session.CreateQuery(SQL).List<Payments>();
            }
        }
    }
}
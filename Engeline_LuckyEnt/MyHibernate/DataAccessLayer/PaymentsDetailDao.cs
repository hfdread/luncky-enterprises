using System;
using System.Collections.Generic;
using MyHibernate.BusinessObjects;
using MyHibernate.DataAccessLayer;
using NHibernate;
using NHibernate.Criterion;

namespace MyHibernate.DataAccessLayer
{
    public class PaymentsDetailDao : GenericDao<PaymentsDetail>
    {
        public IList<PaymentsDetail> getAllPaymentsPDC(Int32 CustomerID, Int32 Status, DateTime from, DateTime to)
        {
            using (ISession session = getSession())
            {
                string SQL = string.Format("from PaymentsDetail as pd where pd.PDCdetail is not null");
                if (CustomerID > 0)
                {
                    SQL += string.Format(" and pd.Customer.ID={0}", CustomerID);
                }
                if (Status >= 0)
                {
                    SQL += string.Format(" and pd.PDCdetail.Status={0}", Status);
                }
                if (from != null && to != null)
                    SQL += string.Format(" and pd.payment.PaymentDate between '{0}' and '{1}'",
                                         from.ToString("yyyy-MM-dd 00:00:00"), to.ToString("yyyy-MM-dd 23:59:59"));

                return session.CreateQuery(SQL).List<PaymentsDetail>();
            }
        }

        public IList<PaymentsDetail> getAllPaymentsByInvoice(Int32 InvoiceID)
        {
            using (ISession session = getSession())
            {
                string SQL = string.Format("from PaymentsDetail as pd where pd.invoice.ID={0}", InvoiceID);
                return session.CreateQuery(SQL).List<PaymentsDetail>();
            }
        }

        public IList<PaymentsDetail> GetAllPaymentsByPaymentID(Int32 PaymentID)
        {
            using (ISession session = getSession())
            {
                string SQL = string.Format("from PaymentsDetail pd where pd.payment.ID={0}", PaymentID);
                return session.CreateQuery(SQL).List<PaymentsDetail>();
            }
        }

        public double GetInvoicePayments(int InvoiceID)
        {
            double retAmount = 0;
            using (ISession session = getSession())
            {
                string SQL = string.Format("from PaymentsDetail pd where pd.invoice.ID={0}", InvoiceID);

                IList<PaymentsDetail> lstSalesAmount = session.CreateQuery(SQL).List<PaymentsDetail>();

                foreach (PaymentsDetail p in lstSalesAmount)
                {
                    retAmount += p.Amount;
                }
            }

            return retAmount;
        }
    }
}
using System;
using System.Collections.Generic;

namespace MyHibernate.BusinessObjects
{
   public partial class Counter
   {
      public virtual Int32 ID { get; set; }
      public virtual Contacts Customer { get; set; }
      public virtual DateTime CounterDate { get; set; }
      public virtual DateTime CounterDueDate { get; set; }
      public virtual double Amount { get; set; }
      public virtual double Balance { get; set; }
      public virtual double PaymentCash { get; set; }
      public virtual double PaymentPDC { get; set; }
      public virtual double PaymentForDeposit { get; set; }
      public virtual double PaymentWithHolding { get; set; }
      public virtual Int32 Status { get; set; }
      public virtual Int32 PrintStatus { get; set; }
      public virtual IList<CounterDetails> details { get; set; }

      //unmapped
      public virtual bool Selected { get; set; }

      public Counter()
      {
         details = new List<CounterDetails>();
      }

      public override string ToString()
      {
         return ID.ToString("00000");
      }

      public double GetTotalPayments()
      {
         return PaymentCash + PaymentPDC + PaymentWithHolding;
      }

      public enum eStatus
      {
         Unpaid = 0,
         Partial,
         Paid,
         ForClearing
      }

      public DateTime GetDueDate(DateTime invoicedate, int terms)
      {
         DateTime datedue = invoicedate.AddDays(terms);
         if (datedue.Day <= 15)
         {
            return
               DateTime.Parse(string.Format("{0} 15, {1} 11:59 PM", datedue.ToString("MMM"), datedue.ToString("yyyy")));
         }
         else
         {
            int iEnd = DateTime.DaysInMonth(datedue.Year, datedue.Month);
            if (iEnd > 30)
               iEnd = 30;
            return
               DateTime.Parse(string.Format("{0} {1}, {2} 11:59 PM", datedue.ToString("MMM"), iEnd,
                                            datedue.ToString("yyyy")));
         }
      }

      public DateTime GetDueDate(DateTime invoicedate)
      {
         DateTime datedue = invoicedate;
         if (datedue.Day <= 15)
         {
            return
               DateTime.Parse(string.Format("{0} 15, {1} 11:59:59 PM", datedue.ToString("MMM"), datedue.ToString("yyyy")));
         }
         else
         {
            int iEnd = DateTime.DaysInMonth(datedue.Year, datedue.Month);
            if (iEnd > 30)
               iEnd = 30;
            return
               DateTime.Parse(string.Format("{0} {1}, {2} 11:59:59 PM", datedue.ToString("MMM"), iEnd,
                                            datedue.ToString("yyyy")));
         }
      }
   }
}
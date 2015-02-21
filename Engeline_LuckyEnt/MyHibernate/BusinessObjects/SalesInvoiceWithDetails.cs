using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyHibernate.BusinessObjects
{
   public partial class SalesInvoiceWithDetails
   {
      public virtual Int32 ID { get; set; }
      public virtual Int32 InvoiceType { get; set; }
      public virtual string ReceiptNumber { get; set; }
      public virtual string PO_Number { get; set; }
      public virtual Contacts Customer { get; set; }
      //public virtual Contacts Agent { get; set; }
      public virtual DateTime InvoiceDate { get; set; }
      public virtual Int32 PaymentType { get; set; }
      public virtual Int32 Terms { get; set; }
      public virtual string Notes { get; set; }
      public virtual double AmountDue { get; set; }
      public virtual double AmountReturned { get; set; }
      public virtual double PaymentCash { get; set; }
      public virtual double PaymentPDC { get; set; }
      public virtual double PaymentForDeposit { get; set; }
      public virtual double PaymentWithholding { get; set; }
      public virtual Int32 CounterID { get; set; }
      public virtual Int32 LoanedItemID { get; set; }
      public virtual bool Printed { get; set; }
      public virtual bool Deleted { get; set; }
      public virtual bool BadDebt { get; set; }
      public virtual bool Withheld { get; set; }
      public virtual double WithholdingAmount { get; set; }
      public virtual Int32 PaymentStatus { get; set; }
      public virtual Users EnteredBy { get; set; }
      public virtual IList<SalesInvoiceDetails> details { get; set; }
      public virtual IList<Payments> paymentdetails { get; set; }

      //unmapped
      public virtual bool Selected { get; set; }

      public SalesInvoiceWithDetails()
      {
         details = new List<SalesInvoiceDetails>();
         paymentdetails = new List<Payments>();
         Selected = false;
      }
   }
}
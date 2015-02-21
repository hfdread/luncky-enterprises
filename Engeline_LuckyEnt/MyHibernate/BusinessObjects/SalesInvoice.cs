using System;
using System.Collections.Generic;

namespace MyHibernate.BusinessObjects
{
   public partial class SalesInvoice
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
      public virtual bool is_delivered { get; set; }

      //unmapped
      public virtual bool Selected { get; set; }

      public SalesInvoice()
      {
         details = new List<SalesInvoiceDetails>();
         paymentdetails = new List<Payments>();
         Selected = false;
      }

      public double getTotalPayments()
      {
         return PaymentCash + PaymentPDC + PaymentForDeposit + PaymentWithholding;
      }

      public enum eInvoiceType
      {
         Cash = 0,
         Accounts,
         DeliveryReceipt
      }

      public enum ePaymentType
      {
         CBD = 0,
         COD,
         Terms,
         PDC,
         MultiPDC
      }

      public enum ePaymentStatus
      {
         Unpaid = 0,
         Partial,
         Paid,
         ForDeposit
      }

      public static string GetInvoiceType(Int32 iType)
      {
         switch (iType)
         {
            case (int) eInvoiceType.Accounts:
               return "Account";
            case (int) eInvoiceType.Cash:
               return "Cash";
            case (int) eInvoiceType.DeliveryReceipt:
               return "Delivery Receipt";
            default:
               return "";
         }
      }

      public static string GetPaymentType(Int32 iPaymentType)
      {
         switch (iPaymentType)
         {
            case (Int32) ePaymentType.CBD:
               return "C.B.D.";
            case (Int32) ePaymentType.COD:
               return "C.O.D.";
            case (Int32) ePaymentType.Terms:
               return "Terms";
            case (Int32) ePaymentType.PDC:
               return "P.D.C.";
            case (Int32) ePaymentType.MultiPDC:
               return "Multi P.D.C.";
            default:
               return "";
         }
      }

      public static Int32 GetPaymentType(string paymenttype)
      {
         switch (paymenttype)
         {
            case "C.B.D.":
               return (int) ePaymentType.CBD;
            case "C.O.D.":
               return (Int32) ePaymentType.COD;
            case "Terms":
               return (Int32) ePaymentType.Terms;
            case "P.D.C.":
               return (Int32) ePaymentType.PDC;
            case "Multi P.D.C.":
               return (Int32) ePaymentType.MultiPDC;
            default:
               return -1;
         }
      }

      public static DateTime GetDueDate(DateTime date, int terms)
      {
         DateTime duedate = date.AddDays(terms);
         int days = DateTime.DaysInMonth(duedate.Year, duedate.Month);
         int daystoadd = 0;

         if (duedate.Day >= 1 && duedate.Day <= 15)
            daystoadd = 15 - duedate.Day;
         else
            daystoadd = 30 - duedate.Day;

         return duedate.AddDays(daystoadd);
      }
   }
}
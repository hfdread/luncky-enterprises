using System;
using System.Collections.Generic;

namespace MyHibernate.BusinessObjects
{
   public partial class Payments
   {
      public virtual Int32 ID { get; set; }
      public virtual Contacts Customer { get; set; }
      public virtual Counter counter { get; set; }
      public virtual SalesInvoice invoice { get; set; }
      public virtual DateTime PaymentDate { get; set; }
      public virtual PaymentsPDC PDCdetail { get; set; }
      public virtual Double Amount { get; set; }
      public virtual Double AmountApplied { get; set; }
      public virtual Double AmountUsed { get; set; }
      public virtual Int32 PaymentType { get; set; }
      public virtual bool Canceled { get; set; }
      public virtual bool Reviewed { get; set; }
      public virtual Users user { get; set; }
      public virtual IList<PaymentsDetail> details { get; set; }

      //unbound
      public virtual bool Selected { get; set; }

      public Payments()
      {
         details = new List<PaymentsDetail>();
      }

      public enum ePaymentType
      {
         Cash = 0,
         PDC,
         WithHolding
      }

      public string GetPaymentType(int iType)
      {
         switch (iType)
         {
            case (int) ePaymentType.Cash:
               return "Cash";
            case (int) ePaymentType.PDC:
               return "PDC";
            case (int) ePaymentType.WithHolding:
               return "WithHolding";
            default:
               return "";
         }
      }
   }
}
using System;
using System.Collections.Generic;

namespace MyHibernate.BusinessObjects
{
   public partial class PaymentsDetail
   {
      public virtual Int32 ID { get; set; }
      public virtual Payments payment { get; set; }
      public virtual SalesInvoice invoice { get; set; }
      public virtual Double Amount { get; set; }
      //public virtual PaymentsPDC PDCdetail { get; set; }
   }
}
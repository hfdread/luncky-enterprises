using System;
using System.Collections.Generic;

namespace MyHibernate.BusinessObjects
{
   public partial class Voucher
   {
      public virtual Int32 ID { get; set; }
      public virtual Contacts Supplier { get; set; }
      public virtual DateTime VoucherDate { get; set; }
      public virtual Double Amount { get; set; }
      public virtual Double AmountBO { get; set; }
      public virtual Int32 BadOrderID { get; set; }
      public virtual bool Cancelled { get; set; }

      public virtual IList<VoucherDetails> details { get; set; }
      public virtual IList<VoucherPayment> payments { get; set; }

      public Voucher()
      {
         details = new List<VoucherDetails>();
         payments = new List<VoucherPayment>();
      }
   }
}
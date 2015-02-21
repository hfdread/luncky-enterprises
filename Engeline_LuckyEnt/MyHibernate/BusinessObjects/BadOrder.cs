using System;
using System.Collections.Generic;

namespace MyHibernate.BusinessObjects
{
   public partial class BadOrder
   {
      public virtual Int32 ID { get; set; }
      public virtual DateTime BO_Date { get; set; }
      public virtual Double Amount { get; set; }
      public virtual Int32 VoucherID { get; set; }
      public virtual Boolean Cancelled { get; set; }
      public virtual IList<BadOrderDetails> details { get; set; }
   }
}
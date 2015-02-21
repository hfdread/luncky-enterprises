using System;
using System.Collections.Generic;

namespace MyHibernate.BusinessObjects
{
   public partial class VoucherDetails
   {
      public virtual Int32 ID { get; set; }
      public virtual Int32 VoucherID { get; set; }
      public virtual StockIn stockin { get; set; }
   }
}
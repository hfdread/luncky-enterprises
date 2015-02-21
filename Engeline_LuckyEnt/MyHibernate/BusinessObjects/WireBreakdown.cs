using System;
using System.Collections.Generic;

namespace MyHibernate.BusinessObjects
{
   public partial class WireBreakdown
   {
      public virtual Int32 ID { get; set; }
      public virtual StockInDetails SID { get; set; }
      public virtual Int32 BreakDownID { get; set; }
      public virtual Int32 QTY_OnHand { get; set; }
      public virtual Int32 QTY_Original { get; set; }
      public virtual bool NewBreakdown { get; set; }

      //unmapped properties
      public virtual Int32 BreakDownID_Source { get; set; }
   }
}
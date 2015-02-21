using System;
using System.Collections.Generic;

namespace MyHibernate.BusinessObjects
{
   public partial class BadOrderDetails
   {
      public virtual Int32 ID { get; set; }
      public virtual BadOrder badorder { get; set; }
      public virtual Int32 QTY { get; set; }
      public virtual StockInDetails sid { get; set; }
   }
}
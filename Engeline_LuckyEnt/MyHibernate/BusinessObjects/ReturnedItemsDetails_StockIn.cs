using System;
using System.Collections.Generic;

namespace MyHibernate.BusinessObjects
{
   public partial class ReturnedItemsDetails_StockIn
   {
      public virtual Int32 ID { get; set; }
      public virtual ReturnedItemsDetails returneditemsdetail { get; set; }
      public virtual StockInDetails stockindetails { get; set; }
      public virtual Int32 QTY1 { get; set; }
      public virtual Int32 QTY2 { get; set; }
      public virtual WireBreakdown wirebreakdown { get; set; }
   }
}
using System;
using System.Collections.Generic;

namespace MyHibernate.BusinessObjects
{
   public partial class FabricatedItem
   {
      public virtual Int32 ID { get; set; }
      public virtual PurchaseOrder purchaseorder { get; set; }
      public virtual StockIn stockin { get; set; }
      public virtual string Name { get; set; }
      public virtual string Description { get; set; }
      public virtual Int32 QTY { get; set; }
      public virtual double UnitPrice { get; set; }
      public virtual bool Invoiced { get; set; }
      public virtual bool Added { get; set; }
   }
}
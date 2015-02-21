using System;
using System.Collections.Generic;

namespace MyHibernate.BusinessObjects
{
   public partial class BundledItemDetails
   {
      public virtual Int32 ID { get; set; }
      public virtual BundledItem bundleditem { get; set; }
      public virtual Items item { get; set; }
      public virtual FabricatedItem FabItem { get; set; }
      public virtual Int32 QTY { get; set; }
      public virtual double UnitPrice { get; set; }
   }
}
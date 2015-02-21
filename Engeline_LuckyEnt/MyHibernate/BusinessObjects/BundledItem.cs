using System;
using System.Collections.Generic;

namespace MyHibernate.BusinessObjects
{
   public partial class BundledItem
   {
      public virtual Int32 ID { get; set; }
      public virtual string Name { get; set; }
      public virtual string Description { get; set; }
      public virtual double UnitPrice { get; set; }
      public virtual double ComputedPrice { get; set; }
      public virtual IList<BundledItemDetails> details { get; set; }
   }
}
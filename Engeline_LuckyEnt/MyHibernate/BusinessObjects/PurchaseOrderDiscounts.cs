using System;
using MyHibernate.BusinessObjects;

namespace MyHibernate.BusinessObjects
{
   public partial class PurchaseOrderDiscounts
   {
      public virtual Int32 ID { get; set; }
      public virtual Contacts Supplier { get; set; }
      public virtual Items item { get; set; }
      public virtual string Discount { get; set; }
   }
}
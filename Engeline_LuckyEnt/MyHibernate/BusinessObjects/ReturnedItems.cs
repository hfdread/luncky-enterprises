using System;
using System.Collections.Generic;

namespace MyHibernate.BusinessObjects
{
   public partial class ReturnedItems
   {
      public virtual Int32 ID { get; set; }
      public virtual SalesInvoice Invoice { get; set; }
      public virtual DateTime TransactionDate { get; set; }
      public virtual double Amount { get; set; }
      public virtual string Notes { get; set; }
      public virtual bool Canceled { get; set; }
      public virtual IList<ReturnedItemsDetails> details { get; set; }
      public virtual Users EnteredBy { get; set; }

      public ReturnedItems()
      {
         details = new List<ReturnedItemsDetails>();
      }
   }
}
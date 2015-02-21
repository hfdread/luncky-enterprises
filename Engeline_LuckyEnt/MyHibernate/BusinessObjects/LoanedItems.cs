using System;
using System.Collections.Generic;

namespace MyHibernate.BusinessObjects
{
   public class LoanedItems
   {
      public virtual Int32 ID { get; set; }
      public virtual Contacts Customer { get; set; }
      public virtual DateTime TransactionDate { get; set; }
      public virtual Int32 Terms { get; set; }
      public virtual string Notes { get; set; }
      public virtual double AmountDue { get; set; }
      public virtual bool Canceled { get; set; }
      public virtual eStatus Status { get; set; }
      public virtual Users EnteredBy { get; set; }

      public virtual IList<LoanedItemsDetails> details { get; set; }

      public enum eStatus
      {
         ForCollection = 0,
         Partial,
         Returned
      }

      public LoanedItems()
      {
         details = new List<LoanedItemsDetails>();
      }
   }
}
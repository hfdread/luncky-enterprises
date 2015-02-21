using System;
using System.Collections.Generic;
using MyHibernate.BusinessObjects;

namespace MyHibernate.BusinessObjects
{
   public partial class PurchaseOrder
   {
      public virtual Int32 ID { get; set; }
      public virtual Contacts Supplier { get; set; }
      public virtual string WarehouseID { get; set; }
      public virtual Int32 GracePeriod { get; set; }
      public virtual DateTime TransactionDate { get; set; }
      public virtual Int32 Status { get; set; }
      public virtual string Notes { get; set; }
      public virtual Double AmountDue { get; set; }
      public virtual Boolean Fabricated { get; set; }
      public virtual Boolean Trading { get; set; }
      public virtual Boolean Excess { get; set; }
      public virtual IList<PurchaseOrderDetails> details { get; set; }
      public virtual bool Canceled { get; set; }
      public virtual Users user { get; set; }
      public virtual string wh_id { get; set; }

       //unmapped properties
      public virtual int mItemIndex { get; set; }
      public enum eStatus
      {
         OK = 0,
         NG,
         PENDING
      }

      public int GetStatus(string status)
      {
         switch (status.ToLower())
         {
            case "ok":
               return (int) eStatus.OK;
            case "ng":
               return (int) eStatus.NG;
            case "pending":
               return (int) eStatus.PENDING;
            default:
               return -1;
         }
      }
   }
}
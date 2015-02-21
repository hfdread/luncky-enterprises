using System;
using System.Collections.Generic;

namespace MyHibernate.BusinessObjects
{
   public partial class StockIn
   {
      public virtual Int32 ID { get; set; }
      public virtual PurchaseOrder purchaseorder { get; set; }
      public virtual StatementofAccount statementofaccount { get; set; }
      public virtual DamagedMissing damagedmissing { get; set; }
      public virtual DateTime StockInDate { get; set; }
      public virtual Int32 Status { get; set; }
      public virtual double AmountDue { get; set; }
      public virtual double AmountPaid { get; set; }
      public virtual string Notes { get; set; }
      public virtual string InvoiceNo { get; set; }
      public virtual string DeliveryReceipt { get; set; }
      public virtual string PackingListNo { get; set; }
      public virtual DateTime InvoiceDate { get; set; }
      public virtual string Shipper { get; set; }
      public virtual string WaybillNo { get; set; }
      public virtual DateTime ShippingDate { get; set; }
      public virtual DateTime ArrivalDate { get; set; }
      public virtual Int32 DueDays { get; set; }
      public virtual DateTime DueDate { get; set; }
      public virtual Freight freight { get; set; }
      public virtual IList<StockInDetails> details { get; set; }
      public virtual bool Canceled { get; set; }
      public virtual bool Paid { get; set; }
      public virtual Users user { get; set; }
      public virtual string wh_id { get; set; }

      //unmapped property
      public virtual bool Selected { get; set; }

      public enum eStatus
      {
         UNPAID = 0,
         PAID
      }

      public string returnID()
      {
          return ID.ToString();
      }
   }
}
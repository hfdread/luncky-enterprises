using System;
using System.Collections.Generic;

namespace MyHibernate.BusinessObjects
{
   public partial class ReturnedItemsDetails
   {
      public virtual Int32 ID { get; set; }
      public virtual ReturnedItems returneditems { get; set; }
      public virtual SalesInvoiceDetails SID { get; set; }
      public virtual Int32 QTY1 { get; set; }
      public virtual Int32 QTY2 { get; set; }
      public virtual IList<ReturnedItemsDetails_StockIn> stockindetails { get; set; }

      public ReturnedItemsDetails()
      {
         stockindetails = new List<ReturnedItemsDetails_StockIn>();
      }
   }
}
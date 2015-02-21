using System;
using System.Collections.Generic;
using System.Text;

namespace MyHibernate.BusinessObjects
{
   public class LoanedItemsDetails_StockIn
   {
      public virtual Int32 ID { get; set; }
      public virtual LoanedItemsDetails loanedItemsDetails { get; set; }
      public virtual StockInDetails stockindetails { get; set; }
      public virtual Int32 QTY1 { get; set; }
      public virtual Int32 QTY2 { get; set; }
      public virtual Int32 QTY_Returned { get; set; }
      public virtual Int32 QTY_Invoiced { get; set; }
      public virtual string SellingDiscount1 { get; set; }
      public virtual string SellingDiscount2 { get; set; }
      public virtual double SellingPrice1 { get; set; }
      public virtual double SellingPrice2 { get; set; }
      public virtual WireBreakdown wirebreakdown { get; set; }
   }
}
using System;
using MyHibernate.BusinessObjects;

namespace MyHibernate.BusinessObjects
{
   public partial class PurchaseOrderDetails
   {
      public virtual Int32 ID { get; set; }
      public virtual Int32 ItemIndex { get; set; }
      public virtual PurchaseOrder purchaseorder { get; set; }
      public virtual Items item { get; set; }
      public virtual FabricatedItem fabricateditem { get; set; }
      public virtual TradingItem tradingitem { get; set; }
      public virtual Int32 QTY1 { get; set; }
      public virtual Int32 QTY2 { get; set; }
      public virtual Double SellingPrice1 { get; set; }
      public virtual Double SellingPrice2 { get; set; }
      public virtual String Discount { get; set; }
      public virtual String Status { get; set; }
   }
}
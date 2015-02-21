using System;
using System.Collections.Generic;

namespace MyHibernate.BusinessObjects
{
   public partial class QuotationDetails
   {
      public virtual Int32 ID { get; set; }
      public virtual Quotation quotation { get; set; }
      public virtual Items item { get; set; }
      public virtual TradingItem tradeitem { get; set; }
      public virtual FabricatedItem fabitem { get; set; }
      public virtual BundledItem bundleditem { get; set; }
      public virtual Int32 QTY1 { get; set; }
      public virtual Int32 QTY2 { get; set; }
      public virtual string AgentDiscount { get; set; }
      public virtual double AgentPrice1 { get; set; }
      public virtual double AgentPrice2 { get; set; }
      public virtual double CustomerPrice1 { get; set; }
      public virtual double CustomerPrice2 { get; set; }
      public virtual String CustomerDiscount { get; set; }
   }
}
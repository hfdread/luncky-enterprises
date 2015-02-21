using System;
using System.Collections.Generic;
using System.Text;

namespace MyHibernate.BusinessObjects
{
   public class LoanedItemsDetails
   {
      public virtual int ID { get; set; }
      public virtual LoanedItems loanedItems { get; set; }
      public virtual Items item { get; set; }
      public virtual TradingItem tradeitem { get; set; }
      public virtual FabricatedItem fabitem { get; set; }
      public virtual BundledItem bundleditem { get; set; }
      public virtual Int32 QTY1 { get; set; }
      public virtual Int32 QTY2 { get; set; }
      public virtual Int32 QTY_Returned { get; set; }
      public virtual Int32 QTY_Invoiced { get; set; }

      public virtual string AgentDiscount { get; set; }
      public virtual double AgentPrice1 { get; set; }
      public virtual double AgentPrice2 { get; set; }
      public virtual double CustomerPrice1 { get; set; }
      public virtual double CustomerPrice2 { get; set; }
      public virtual String CustomerDiscount { get; set; }
      public virtual IList<LoanedItemsDetails_StockIn> stockindetails { get; set; }

      //unmapped property
      public virtual bool Selected { get; set; }
      public virtual Int32 QTY_ToReturn { get; set; }
   }
}
using System;
using System.Collections.Generic;

namespace MyHibernate.BusinessObjects
{
   public partial class StockInDetails
   {
      public virtual Int32 ID { get; set; }
      public virtual StockIn stockin { get; set; }
      public virtual Int32 ItemIndex { get; set; }
      public virtual Items item { get; set; }
      public virtual FabricatedItem fabricateditem { get; set; }
      public virtual TradingItem tradingitem { get; set; }
      public virtual Int32 QTY1 { get; set; }
      public virtual Int32 QTY2 { get; set; }
      public virtual Int32 QTY_OnHand1 { get; set; }
      public virtual Int32 QTY_OnHand2 { get; set; }
      public virtual string QTY_OnHandWire { get; set; }
      public virtual Int32 QTY_BadOrder { get; set; }
      public virtual double Price1 { get; set; }
      public virtual double Price2 { get; set; }
      public virtual double SellingPrice1 { get; set; }
      public virtual double SellingPrice2 { get; set; }
      public virtual string SellingDiscount1 { get; set; }
      public virtual string SellingDiscount2 { get; set; }
      public virtual Int32 Status { get; set; }
      public virtual double freight { get; set; }
      public virtual string Discount { get; set; }
      public virtual string WarehouseStockin { get; set; }

      //unmapped properties
      public virtual int QTY_To_Return { get; set; }
      public virtual double SubTotal { get; set; }

      public virtual IList<WireBreakdown> wirebreakdown_details { get; set; }

      public enum eStatus
      {
         Unlocked = 0,
         Locked
      }

      public virtual string GetItemName()
      {
         if (item != null)
            return item.Name;
         else if (fabricateditem != null)
            return fabricateditem.Name;
         else if (tradingitem != null)
            return tradingitem.Name;
         else
            return "";
      }

      public virtual string GetItemNameFull()
      {
         if (item != null)
            return string.Format("{0}\n{1}", item.Name, item.Description);
         else if (fabricateditem != null)
            return string.Format("{0}\n{1}", fabricateditem.Name, fabricateditem.Description);
         else if (tradingitem != null)
            return string.Format("{0}\n{1}", tradingitem.Name, tradingitem.Description);
         else
            return "";
      }

      public bool HasSellingPrice()
      {
         if (SellingPrice1 == 0 && SellingDiscount1 == "")
            return false;
         else
            return true;
      }
   }
}
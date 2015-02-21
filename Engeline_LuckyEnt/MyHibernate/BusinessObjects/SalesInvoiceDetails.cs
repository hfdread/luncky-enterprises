using System;
using System.Collections.Generic;

namespace MyHibernate.BusinessObjects
{
   public partial class SalesInvoiceDetails
   {
      public virtual Int32 ID { get; set; }
      public virtual SalesInvoice salesinvoice { get; set; }
      public virtual Items item { get; set; }
      public virtual TradingItem tradeitem { get; set; }
      public virtual FabricatedItem fabitem { get; set; }
      public virtual BundledItem bundleditem { get; set; }
      public virtual Int32 QTY1 { get; set; }
      public virtual Int32 QTY2 { get; set; }
      public virtual Int32 QTY_Returned { get; set; }

      public virtual string AgentDiscount { get; set; }
      public virtual double AgentPrice1 { get; set; }
      public virtual double AgentPrice2 { get; set; }
      public virtual double CustomerPrice1 { get; set; }
      public virtual double CustomerPrice2 { get; set; }
      public virtual String CustomerDiscount { get; set; }
      public virtual Int32 LoanedItemDetailsID { get; set; }
      public virtual IList<SalesInvoiceDetails_StockIn> stockindetails { get; set; }

      //unmapped properties
      public virtual Int32 QTY_InInvoice { get; set; } //used for bundled items validation
      //public virtual bool b_PO { get; set; }
      //public virtual Warehouse whPO { get; set; }
      public virtual Warehouse whStockin { get; set; }

      public string GetLabelQTYFull()
      {
         if (item != null)
         {
            if (item.IsWire)
            {
               if (QTY1 != 0)
               {
                  //per roll
                  if (QTY1 > 1)
                     return string.Format("{0} rolls\n@{1} mtrs", QTY1, QTY2);
                  else
                     return string.Format("{0} roll@{1} mtrs", QTY1, QTY2);
               }
               else
               {
                  //pre meter
                  if (QTY1 > 1)
                     return string.Format("{0} mtrs", QTY2);
                  else
                     return string.Format("{0} mtr", QTY2);
               }
            }
            else
            {
               if (QTY1 > 1)
                  return string.Format("{0} pcs", QTY1);
               else
                  return string.Format("{0} pc", QTY1);
            }
         }
         else
         {
            if (QTY1 > 1)
               return string.Format("{0} pcs", QTY1);
            else
               return string.Format("{0} pc", QTY1);
         }
      }

      public string GetLabelQTY()
      {
         if (item != null)
         {
            if (item.IsWire)
            {
               if (QTY1 != 0)
               {
                  return QTY1.ToString();
               }
               else
               {
                  return QTY2.ToString();
               }
            }
            else
            {
               return QTY1.ToString();
            }
         }
         else
         {
            return QTY1.ToString();
         }
      }

      public string GetItemName()
      {
         if (item != null)
         {
            return item.Name;
         }
         else if (fabitem != null)
         {
            return fabitem.Name;
         }
         else if (tradeitem != null)
         {
            return tradeitem.Name;
         }
         else if (bundleditem != null)
         {
            return bundleditem.Name;
         }
         else
            return "{null}";
      }

      public string GetItemNameFull()
      {
         if (item != null)
         {
            return string.Format("{0}\n{1}", item.Name, item.Description);
         }
         else if (fabitem != null)
         {
            return string.Format("{0}\n{1}", fabitem.Name, fabitem.Description);
         }
         else if (tradeitem != null)
         {
            return string.Format("{0}\n{1}", tradeitem.Name, tradeitem.Description);
         }
         else if (bundleditem != null)
         {
            return string.Format("{0}\n{1}", bundleditem.Name, bundleditem.Description);
         }
         else
            return "{null}";
      }

      public double GetAgentPriceUsed()
      {
         if (item != null)
         {
            if (item.IsWire && QTY1 == 0)
               return AgentPrice2;
            else
               return AgentPrice1;
         }
         else
            return AgentPrice1;
      }
   }
}
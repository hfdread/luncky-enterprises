using System;
using System.Collections.Generic;

namespace MyHibernate.BusinessObjects
{
   public partial class AgentQuotaItemDetails
   {
      public virtual Int32 ID { get; set; }
      public virtual AgentQuota quota { get; set; }
      public virtual string ItemName { get; set; }
      public virtual double LimitValue { get; set; }
      public virtual double PercentCommission { get; set; }
      public virtual IList<AgentQuotaExemptItem> ExemptedItems { get; private set; }

      public AgentQuotaItemDetails()
      {
         ExemptedItems = new List<AgentQuotaExemptItem>();
      }

      public static string STR_FAB = "Fabricated Items";
      public static string STR_TRADE = "Trading Items";
   }
}
using System;
using System.Collections.Generic;

namespace MyHibernate.BusinessObjects
{
   public partial class AgentCommissionItemDetails
   {
      public virtual Int32 ID { get; set; }
      public virtual AgentCommission commission { get; set; }
      public virtual AgentQuotaItemDetails ItemDetails { get; set; }
      public virtual double AmountSales { get; set; }
   }
}
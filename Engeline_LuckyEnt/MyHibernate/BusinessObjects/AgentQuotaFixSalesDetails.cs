using System;
using System.Collections.Generic;

namespace MyHibernate.BusinessObjects
{
   public partial class AgentQuotaFixSalesDetails
   {
      public virtual Int32 ID { get; set; }
      //public virtual AgentQuota quota { get; set; }
      public virtual Double Quota { get; set; }
      public virtual Double Commission { get; set; }
   }
}
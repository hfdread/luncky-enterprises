using System;
using System.Collections.Generic;

namespace MyHibernate.BusinessObjects
{
   public partial class AgentQuotaExemptItem
   {
      public virtual Int32 ID { get; set; }
      public virtual AgentQuotaItemDetails ItemDetail { get; set; }
      public virtual Int32 ItemID { get; set; }
   }
}
using System;
using System.Collections.Generic;

namespace MyHibernate.BusinessObjects
{
    public partial class AgentQuota
    {
        public virtual Int32 ID { get; set; }
        public virtual Contacts Agent { get; set; }
        public virtual double Quota { get; set; }
        public virtual AgentQuotaFixSalesDetails FixSalesDetails { get; set; }
        public virtual IList<AgentQuotaItemDetails> ItemDetails { get; private set; }

        public AgentQuota()
        {
            ItemDetails = new List<AgentQuotaItemDetails>();
        }
    }
}
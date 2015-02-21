using System;
using System.Collections.Generic;

namespace MyHibernate.BusinessObjects
{
   public partial class AgentCommission
   {
      public virtual Int32 ID { get; set; }
      public virtual SalesInvoice Invoice { get; set; }
      public virtual Contacts Agent { get; set; }
      public virtual double SalesTotal { get; set; }
      public virtual double SalesItem { get; set; }
      public virtual double SalesTrading { get; set; }
      public virtual double SalesFab { get; set; }
      public virtual double SalesMiscItems { get; set; }
      public virtual bool Canceled { get; set; }
      public virtual IList<AgentCommissionItemDetails> ItemDetails { get; private set; }

      public AgentCommission()
      {
         ItemDetails = new List<AgentCommissionItemDetails>();
         Canceled = false;
      }
   }
}
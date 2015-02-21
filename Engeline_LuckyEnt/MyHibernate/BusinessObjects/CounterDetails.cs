using System;
using System.Collections.Generic;

namespace MyHibernate.BusinessObjects
{
   public partial class CounterDetails
   {
      public virtual Int32 ID { get; set; }
      public virtual Counter counter { get; set; }
      public virtual SalesInvoice invoice { get; set; }

      public CounterDetails()
      {
      }
   }
}
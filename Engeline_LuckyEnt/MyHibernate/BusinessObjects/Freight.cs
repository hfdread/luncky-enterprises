using System;
using System.Collections.Generic;

namespace MyHibernate.BusinessObjects
{
   public partial class Freight
   {
      public virtual Int32 ID { get; set; }
      public virtual double SI_Amount { get; set; }
      public virtual double Total_Amount { get; set; }
      public virtual double FreightPercentage { get; set; }
   }
}
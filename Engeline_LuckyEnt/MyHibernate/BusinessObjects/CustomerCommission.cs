using System;
using System.Collections.Generic;

namespace MyHibernate.BusinessObjects
{
   public partial class CustomerCommission
   {
      public virtual Int32 ID { get; set; }
      public virtual Contacts Customer { get; set; }
      public virtual SalesInvoice Invoice { get; set; }
      public virtual double Amount { get; set; }
      public virtual Int32 Status { get; set; }

      public enum eStatus
      {
         Pending = 0,
         Released
      }
   }
}
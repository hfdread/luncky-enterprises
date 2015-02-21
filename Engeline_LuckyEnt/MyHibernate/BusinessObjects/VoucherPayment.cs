using System;
using System.Collections.Generic;

namespace MyHibernate.BusinessObjects
{
   public partial class VoucherPayment
   {
      public virtual Int32 ID { get; set; }
      public virtual Int32 VoucherID { get; set; }
      public virtual Banks bank { get; set; }
      public virtual string AccountNumber { get; set; }
      public virtual string CheckNumber { get; set; }
      public virtual double Amount { get; set; }
      public virtual DateTime CheckDate { get; set; }
      public virtual DateTime ClearingDate { get; set; }
      public virtual eStatus Status { get; set; }

      public enum eStatus
      {
         ForDeposit = 0,
         Good,
         Bounced,
         Returned
      }
   }
}
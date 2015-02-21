using System;
using System.Collections.Generic;

namespace MyHibernate.BusinessObjects
{
   public partial class RequestApproval
   {
      public virtual Int32 ID { get; set; }
      public virtual eRequestType RequestType { get; set; }
      public virtual DateTime RequestDate { get; set; }
      public virtual string Terminal { get; set; }
      public virtual Users Sender { get; set; }
      public virtual string Message { get; set; }
      public virtual eStatus Status { get; set; }

      public enum eStatus
      {
         Pending = 0,
         Approved,
         Declined
      }

      public enum eRequestType
      {
         General=0,
         TermsExtension,
         PriceApproval,
         CreditExtension
      }
   }
}
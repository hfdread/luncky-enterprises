using System;
using System.Collections.Generic;

namespace MyHibernate.BusinessObjects
{
   public partial class Quotation
   {
      public virtual Int32 ID { get; set; }
      public virtual Contacts Customer { get; set; }
      public virtual DateTime QuotationDate { get; set; }
      public virtual string Notes { get; set; }
      public virtual double AmountDue { get; set; }
      public virtual Users EnteredBy { get; set; }
      public virtual IList<QuotationDetails> details { get; set; }

      public Quotation()
      {
         details = new List<QuotationDetails>();
      }
   }
}
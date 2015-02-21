using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyHibernate.BusinessObjects
{
   public class SalesReportDetails
   {
      public virtual Int32 InvoiceID { get; set; }
      public virtual string ReceiptNo { get; set; }
      public virtual DateTime InvoiceDate { get; set; }
      public virtual string Customer { get; set; }
      public virtual double GrossSales { get; set; }
      public virtual double Capital { get; set; }
      public virtual double Profit { get; set; }
   }
}

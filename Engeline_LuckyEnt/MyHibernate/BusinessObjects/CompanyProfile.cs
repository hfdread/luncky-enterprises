using System;

namespace MyHibernate.BusinessObjects
{
   public class CompanyProfile
   {
      public virtual int ID { get; set; }
      public virtual string CompanyName { get; set; }
      public virtual string Address { get; set; }
      public virtual string Phone { get; set; }
      public virtual string Fax { get; set; }
      public virtual string Email { get; set; }
      public virtual string Website { get; set; }
      public virtual string SSS { get; set; }
      public virtual string TIN { get; set; }
   }
}
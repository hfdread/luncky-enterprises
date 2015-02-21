using System;

namespace MyHibernate.BusinessObjects
{
   public partial class Settings
   {
      public virtual Int32 ID { get; set; }
      public virtual String Name { get; set; }
      public virtual String Value { get; set; }

      public enum eSettings
      {
         ShowSellingPrice
      }
   }
}

using System;

namespace MyHibernate.BusinessObjects
{
   public partial class Items
   {
      public virtual Int32 ID { get; set; }
      public virtual string Name { get; set; }
      public virtual string Description { get; set; }
      public virtual DateTime ItemDate { get; set; }
      public virtual Double Price1 { get; set; }
      public virtual Double Price2 { get; set; }
      public virtual Int32 QTYOnHand1 { get; set; }
      public virtual Int32 QTYOnHand2 { get; set; }
      public virtual ItemCategory category { get; set; }
      public virtual Int32 LowThreshold { get; set; }
      public virtual Int32 ItemType { get; set; }
      public virtual Int32 QTY2 { get; set; }
      public virtual Boolean IsWire { get; set; }
      public virtual string Unit { get; set; }
      public virtual string wh_id { get; set; }
      public virtual string Code { get; set; }

      //not mapped
      public virtual bool Selected { get; set; }
      public virtual int totalQty { get; set; }

      public enum eItemType
      {
         Wire = 0,
         Normal
      }

      public override string ToString()
      {
          if (Name == "")
              return Description;
          else
              return Name;
      }
   }
}
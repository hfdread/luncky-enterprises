using System;

namespace MyHibernate.BusinessObjects
{
    public partial class Banks
    {
        public virtual Int32 ID { get; set; }
        public virtual string Name { get; set; }
        public virtual string ShortDescription { get; set; }

        public override string ToString()
        {
            return ShortDescription;
        }
    }
}
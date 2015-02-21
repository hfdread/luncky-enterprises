using System;
using System.Collections.Generic;

namespace MyHibernate.BusinessObjects
{
    public partial class Warehouse
    {
        public virtual string ID { get; set; }
        public virtual string Name { get; set; }
        public virtual string Address { get; set; }
        public virtual string Phone { get; set; }
        public virtual string Fax { get; set; }
        public virtual Boolean isDefault { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
